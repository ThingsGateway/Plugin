﻿

using System;
using System.Runtime.InteropServices;


namespace OpcRcw.Da
{
    [Guid("39c13a72-011e-11d0-9675-0020afd8adb3")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IOPCItemProperties
    {
        void QueryAvailableProperties(
          [MarshalAs(UnmanagedType.LPWStr)] string szItemID,
          [MarshalAs(UnmanagedType.I4)] out int pdwCount,
          out IntPtr ppPropertyIDs,
          out IntPtr ppDescriptions,
          out IntPtr ppvtDataTypes);

        void GetItemProperties(
          [MarshalAs(UnmanagedType.LPWStr)] string szItemID,
          [MarshalAs(UnmanagedType.I4)] int dwCount,
          [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1, ArraySubType = UnmanagedType.I4)] int[] pdwPropertyIDs,
          out IntPtr ppvData,
          out IntPtr ppErrors);

        void LookupItemIDs(
          [MarshalAs(UnmanagedType.LPWStr)] string szItemID,
          [MarshalAs(UnmanagedType.I4)] int dwCount,
          [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1, ArraySubType = UnmanagedType.I4)] int[] pdwPropertyIDs,
          out IntPtr ppszNewItemIDs,
          out IntPtr ppErrors);
    }
}
