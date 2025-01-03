﻿

using OpcRcw.Comn;

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;


namespace OpcRcw
{
    public class ServerEnumerator : IDisposable
    {
        private IOPCServerList2 m_server;
        private string m_host;
        private static readonly Guid OPCEnumCLSID = new Guid("13486D51-4821-11D2-A494-3CB306C10000");

        public ServerEnumerator() => Initialize();

        private void Initialize()
        {
            m_server = (IOPCServerList2)null;
            m_host = (string)null;
        }

        ~ServerEnumerator() => Dispose(false);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize((object)this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (m_server == null)
                return;
            Utils.ReleaseServer((object)m_server);
            m_server = (IOPCServerList2)null;
        }

        public void Connect()
        {
            Connect((string)null, (string)null, (string)null, (string)null);
        }

        public void Connect(
          string host,
          string username,
          string password,
          string domain,
          bool useConnectSecurity = false)
        {
            Disconnect();
            object instance;
            try
            {
                instance = Utils.CreateInstance(ServerEnumerator.OPCEnumCLSID, host, username, password, domain, useConnectSecurity);
            }
            catch (Exception ex)
            {
                throw Utils.CreateComException(ex);
            }
            m_server = instance as IOPCServerList2;
            if (m_server == null)
            {
                Utils.ReleaseServer(instance);
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("Server does not support IOPCServerList2. ");
                stringBuilder.Append("The OPC proxy/stubs may not be installed properly or the client or server machine. ");
                stringBuilder.Append("The also could be a problem with DCOM security configuration.");
                throw Utils.CreateComException(-2147467262, stringBuilder.ToString());
            }
            m_host = host;
            if (!string.IsNullOrEmpty(m_host))
                return;
            m_host = "localhost";
        }

        public void Disconnect()
        {
            try
            {
                if (m_server == null)
                    return;
                Utils.ReleaseServer((object)m_server);
                m_server = (IOPCServerList2)null;
            }
            catch (Exception ex)
            {
                object[] objArray = Array.Empty<object>();
                throw Utils.CreateComException(ex, -2147467259, "Could not release OPCEnum server.", objArray);
            }
        }

        public ServerDescription[] GetAvailableServers(params Guid[] catids)
        {
            try
            {
                IOPCEnumGUID ppenumClsid = (IOPCEnumGUID)null;
                m_server.EnumClassesOfCategories(catids.Length, catids, 0, (Guid[])null, out ppenumClsid);

                List<Guid> guidList = ServerEnumerator.ReadClasses(ppenumClsid);
                Utils.ReleaseServer((object)ppenumClsid);
                ServerDescription[] availableServers = new ServerDescription[guidList.Count];
                for (int index = 0; index < availableServers.Length; ++index)
                    availableServers[index] = ReadServerDetails(guidList[index]);
                return availableServers;
            }
            catch (Exception ex)
            {
                object[] objArray = Array.Empty<object>();
                throw Utils.CreateComException(ex, -2147467259, "Could not enumerate COM servers.", objArray);
            }
        }

        public Guid CLSIDFromProgID(string progID)
        {
            Guid clsid;
            try
            {
                m_server.CLSIDFromProgID(progID, out clsid);
            }
            catch
            {
                clsid = Guid.Empty;
            }
            return clsid;
        }

        private static List<Guid> ReadClasses(IOPCEnumGUID enumerator)
        {
            List<Guid> guidList = new List<Guid>();
            int pceltFetched = 0;
            Guid[] guidArray = new Guid[10];
            do
            {
                try
                {
                    IntPtr num = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(Guid)) * guidArray.Length);
                    try
                    {
                        enumerator.Next(guidArray.Length, num, out pceltFetched);
                        if (pceltFetched > 0)
                        {
                            IntPtr ptr = num;
                            for (int index = 0; index < pceltFetched; ++index)
                            {
                                guidArray[index] = (Guid)Marshal.PtrToStructure(ptr, typeof(Guid));
                                ptr = (nint)(ptr.ToInt64() + (long)Marshal.SizeOf(typeof(Guid)));
                                guidList.Add(guidArray[index]);
                            }
                        }
                    }
                    finally
                    {
                        Marshal.FreeCoTaskMem(num);
                    }
                }
                catch
                {
                    break;
                }
            }
            while (pceltFetched > 0);
            return guidList;
        }

        private ServerDescription ReadServerDetails(Guid clsid)
        {
            ServerDescription serverDescription = new ServerDescription();
            serverDescription.HostName = m_host;
            serverDescription.Clsid = clsid;
            string ppszProgID = (string)null;
            try
            {
                string ppszUserType = (string)null;
                string ppszVerIndProgID = (string)null;
                m_server.GetClassDetails(ref clsid, out ppszProgID, out ppszUserType, out ppszVerIndProgID);
                if (!string.IsNullOrEmpty(ppszVerIndProgID))
                    ppszProgID = ppszVerIndProgID;
                serverDescription.Description = ppszUserType;
                serverDescription.VersionIndependentProgId = ppszVerIndProgID;
            }
            catch
            {
                ppszProgID = (string)null;
            }
            serverDescription.ProgId = ppszProgID;
            return serverDescription;
        }
    }
}
