﻿

using System;
using System.Runtime.InteropServices;


namespace OpcRcw.Da
{
    [Guid("39c13a53-011e-11d0-9675-0020afd8adb3")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IOPCAsyncIO
    {
        void Read(
          [MarshalAs(UnmanagedType.I4)] int dwConnection,
          OPCDATASOURCE dwSource,
          [MarshalAs(UnmanagedType.I4)] int dwCount,
          [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2, ArraySubType = UnmanagedType.I4)] int[] phServer,
          [MarshalAs(UnmanagedType.I4)] out int pTransactionID,
          out IntPtr ppErrors);

        void Write(
          [MarshalAs(UnmanagedType.I4)] int dwConnection,
          [MarshalAs(UnmanagedType.I4)] int dwCount,
          [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1, ArraySubType = UnmanagedType.I4)] int[] phServer,
          [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1, ArraySubType = UnmanagedType.Struct)] object[] pItemValues,
          [MarshalAs(UnmanagedType.I4)] out int pTransactionID,
          out IntPtr ppErrors);

        void Refresh([MarshalAs(UnmanagedType.I4)] int dwConnection, OPCDATASOURCE dwSource, [MarshalAs(UnmanagedType.I4)] out int pTransactionID);

        void Cancel([MarshalAs(UnmanagedType.I4)] int dwTransactionID);
    }
}
