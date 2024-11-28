﻿

using System;
using System.Runtime.InteropServices;


namespace OpcRcw.Hda
{
  [Guid("1F1217B2-DEE0-11d2-A5E5-000086339399")]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [ComImport]
  public interface IOPCHDA_SyncRead
  {
    void ReadRaw(
      ref OPCHDA_TIME htStartTime,
      ref OPCHDA_TIME htEndTime,
      [MarshalAs(UnmanagedType.I4)] int dwNumValues,
      [MarshalAs(UnmanagedType.I4)] int bBounds,
      [MarshalAs(UnmanagedType.I4)] int dwNumItems,
      [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4, ArraySubType = UnmanagedType.I4)] int[] phServer,
      out IntPtr ppItemValues,
      out IntPtr ppErrors);

    void ReadProcessed(
      ref OPCHDA_TIME htStartTime,
      ref OPCHDA_TIME htEndTime,
      OPCHDA_FILETIME ftResampleInterval,
      [MarshalAs(UnmanagedType.I4)] int dwNumItems,
      [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3, ArraySubType = UnmanagedType.I4)] int[] phServer,
      [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3, ArraySubType = UnmanagedType.I4)] int[] haAggregate,
      out IntPtr ppItemValues,
      out IntPtr ppErrors);

    void ReadAtTime(
      [MarshalAs(UnmanagedType.I4)] int dwNumTimeStamps,
      [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStruct)] OPCHDA_FILETIME[] ftTimeStamps,
      [MarshalAs(UnmanagedType.I4)] int dwNumItems,
      [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2, ArraySubType = UnmanagedType.I4)] int[] phServer,
      out IntPtr ppItemValues,
      out IntPtr ppErrors);

    void ReadModified(
      ref OPCHDA_TIME htStartTime,
      ref OPCHDA_TIME htEndTime,
      [MarshalAs(UnmanagedType.I4)] int dwNumValues,
      [MarshalAs(UnmanagedType.I4)] int dwNumItems,
      [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3, ArraySubType = UnmanagedType.I4)] int[] phServer,
      out IntPtr ppItemValues,
      out IntPtr ppErrors);

    void ReadAttribute(
      ref OPCHDA_TIME htStartTime,
      ref OPCHDA_TIME htEndTime,
      [MarshalAs(UnmanagedType.I4)] int hServer,
      [MarshalAs(UnmanagedType.I4)] int dwNumAttributes,
      [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3, ArraySubType = UnmanagedType.I4)] int[] pdwAttributeIDs,
      out IntPtr ppAttributeValues,
      out IntPtr ppErrors);
  }
}
