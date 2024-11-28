﻿

using System;
using System.Runtime.InteropServices;


namespace OpcRcw.Hda
{
  [Guid("1F1217B0-DEE0-11d2-A5E5-000086339399")]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [ComImport]
  public interface IOPCHDA_Server
  {
    void GetItemAttributes(
      [MarshalAs(UnmanagedType.I4)] out int pdwCount,
      out IntPtr ppdwAttrID,
      out IntPtr ppszAttrName,
      out IntPtr ppszAttrDesc,
      out IntPtr ppvtAttrDataType);

    void GetAggregates(
      [MarshalAs(UnmanagedType.I4)] out int pdwCount,
      out IntPtr ppdwAggrID,
      out IntPtr ppszAggrName,
      out IntPtr ppszAggrDesc);

    void GetHistorianStatus(
      out OPCHDA_SERVERSTATUS pwStatus,
      out IntPtr pftCurrentTime,
      out IntPtr pftStartTime,
      [MarshalAs(UnmanagedType.I2)] out short pwMajorVersion,
      [MarshalAs(UnmanagedType.I2)] out short wMinorVersion,
      [MarshalAs(UnmanagedType.I2)] out short pwBuildNumber,
      [MarshalAs(UnmanagedType.I4)] out int pdwMaxReturnValues,
      [MarshalAs(UnmanagedType.LPWStr)] out string ppszStatusString,
      [MarshalAs(UnmanagedType.LPWStr)] out string ppszVendorInfo);

    void GetItemHandles(
      [MarshalAs(UnmanagedType.I4)] int dwCount,
      [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[] pszItemID,
      [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I4)] int[] phClient,
      out IntPtr pphServer,
      out IntPtr ppErrors);

    void ReleaseItemHandles([MarshalAs(UnmanagedType.I4)] int dwCount, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I4)] int[] phServer, out IntPtr ppErrors);

    void ValidateItemIDs([MarshalAs(UnmanagedType.I4)] int dwCount, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[] pszItemID, out IntPtr ppErrors);

    void CreateBrowse(
      [MarshalAs(UnmanagedType.I4)] int dwCount,
      [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I4)] int[] pdwAttrID,
      [MarshalAs(UnmanagedType.LPArray)] OPCHDA_OPERATORCODES[] pOperator,
      [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct)] object[] vFilter,
      out IOPCHDA_Browser pphBrowser,
      out IntPtr ppErrors);
  }
}
