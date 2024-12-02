﻿

using System;
using System.Runtime.InteropServices;


namespace OpcRcw.Ae
{
    [Guid("94C955DC-3684-4ccb-AFAB-F898CE19AAC3")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IOPCEventSubscriptionMgt2
    {
        void SetFilter(
          [MarshalAs(UnmanagedType.I4)] int dwEventType,
          [MarshalAs(UnmanagedType.I4)] int dwNumCategories,
          [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1, ArraySubType = UnmanagedType.I4)] int[] pdwEventCategories,
          [MarshalAs(UnmanagedType.I4)] int dwLowSeverity,
          [MarshalAs(UnmanagedType.I4)] int dwHighSeverity,
          [MarshalAs(UnmanagedType.I4)] int dwNumAreas,
          [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5, ArraySubType = UnmanagedType.LPWStr)] string[] pszAreaList,
          [MarshalAs(UnmanagedType.I4)] int dwNumSources,
          [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 7, ArraySubType = UnmanagedType.LPWStr)] string[] pszSourceList);

        void GetFilter(
          [MarshalAs(UnmanagedType.I4)] out int pdwEventType,
          [MarshalAs(UnmanagedType.I4)] out int pdwNumCategories,
          out IntPtr ppdwEventCategories,
          [MarshalAs(UnmanagedType.I4)] out int pdwLowSeverity,
          [MarshalAs(UnmanagedType.I4)] out int pdwHighSeverity,
          [MarshalAs(UnmanagedType.I4)] out int pdwNumAreas,
          out IntPtr ppszAreaList,
          [MarshalAs(UnmanagedType.I4)] out int pdwNumSources,
          out IntPtr ppszSourceList);

        void SelectReturnedAttributes([MarshalAs(UnmanagedType.I4)] int dwEventCategory, [MarshalAs(UnmanagedType.I4)] int dwCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1, ArraySubType = UnmanagedType.I4)] int[] dwAttributeIDs);

        void GetReturnedAttributes([MarshalAs(UnmanagedType.I4)] int dwEventCategory, [MarshalAs(UnmanagedType.I4)] out int pdwCount, out IntPtr ppdwAttributeIDs);

        void Refresh([MarshalAs(UnmanagedType.I4)] int dwConnection);

        void CancelRefresh([MarshalAs(UnmanagedType.I4)] int dwConnection);

        void GetState(
          [MarshalAs(UnmanagedType.I4)] out int pbActive,
          [MarshalAs(UnmanagedType.I4)] out int pdwBufferTime,
          [MarshalAs(UnmanagedType.I4)] out int pdwMaxSize,
          [MarshalAs(UnmanagedType.I4)] out int phClientSubscription);

        void SetState(
          IntPtr pbActive,
          IntPtr pdwBufferTime,
          IntPtr pdwMaxSize,
          [MarshalAs(UnmanagedType.I4)] int hClientSubscription,
          [MarshalAs(UnmanagedType.I4)] out int pdwRevisedBufferTime,
          [MarshalAs(UnmanagedType.I4)] out int pdwRevisedMaxSize);

        void SetKeepAlive([MarshalAs(UnmanagedType.I4)] int dwKeepAliveTime, [MarshalAs(UnmanagedType.I4)] out int pdwRevisedKeepAliveTime);

        void GetKeepAlive([MarshalAs(UnmanagedType.I4)] out int pdwKeepAliveTime);
    }
}
