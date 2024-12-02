﻿

using System;
using System.Runtime.InteropServices;


namespace OpcRcw.Hda
{
    [Guid("1F1217B5-DEE0-11d2-A5E5-000086339399")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IOPCHDA_AsyncRead
    {
        void ReadRaw(
          [MarshalAs(UnmanagedType.I4)] int dwTransactionID,
          ref OPCHDA_TIME htStartTime,
          ref OPCHDA_TIME htEndTime,
          [MarshalAs(UnmanagedType.I4)] int dwNumValues,
          [MarshalAs(UnmanagedType.I4)] int bBounds,
          [MarshalAs(UnmanagedType.I4)] int dwNumItems,
          [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5, ArraySubType = UnmanagedType.I4)] int[] phServer,
          out int pdwCancelID,
          out IntPtr ppErrors);

        void AdviseRaw(
          [MarshalAs(UnmanagedType.I4)] int dwTransactionID,
          ref OPCHDA_TIME htStartTime,
          OPCHDA_FILETIME ftUpdateInterval,
          [MarshalAs(UnmanagedType.I4)] int dwNumItems,
          [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3, ArraySubType = UnmanagedType.I4)] int[] phServer,
          out int pdwCancelID,
          out IntPtr ppErrors);

        void ReadProcessed(
          [MarshalAs(UnmanagedType.I4)] int dwTransactionID,
          ref OPCHDA_TIME htStartTime,
          ref OPCHDA_TIME htEndTime,
          OPCHDA_FILETIME ftResampleInterval,
          [MarshalAs(UnmanagedType.I4)] int dwNumItems,
          [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4, ArraySubType = UnmanagedType.I4)] int[] phServer,
          [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4, ArraySubType = UnmanagedType.I4)] int[] haAggregate,
          out int pdwCancelID,
          out IntPtr ppErrors);

        void AdviseProcessed(
          [MarshalAs(UnmanagedType.I4)] int dwTransactionID,
          ref OPCHDA_TIME htStartTime,
          OPCHDA_FILETIME ftResampleInterval,
          [MarshalAs(UnmanagedType.I4)] int dwNumItems,
          [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2, ArraySubType = UnmanagedType.I4)] int[] phServer,
          [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2, ArraySubType = UnmanagedType.I4)] int[] haAggregate,
          [MarshalAs(UnmanagedType.I4)] int dwNumIntervals,
          out int pdwCancelID,
          out IntPtr ppErrors);

        void ReadAtTime(
          [MarshalAs(UnmanagedType.I4)] int dwTransactionID,
          [MarshalAs(UnmanagedType.I4)] int dwNumTimeStamps,
          [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1, ArraySubType = UnmanagedType.LPStruct)] OPCHDA_FILETIME[] ftTimeStamps,
          [MarshalAs(UnmanagedType.I4)] int dwNumItems,
          [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3, ArraySubType = UnmanagedType.I4)] int[] phServer,
          out int pdwCancelID,
          out IntPtr ppErrors);

        void ReadModified(
          [MarshalAs(UnmanagedType.I4)] int dwTransactionID,
          ref OPCHDA_TIME htStartTime,
          ref OPCHDA_TIME htEndTime,
          [MarshalAs(UnmanagedType.I4)] int dwNumValues,
          [MarshalAs(UnmanagedType.I4)] int dwNumItems,
          [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4, ArraySubType = UnmanagedType.I4)] int[] phServer,
          out int pdwCancelID,
          out IntPtr ppErrors);

        void ReadAttribute(
          [MarshalAs(UnmanagedType.I4)] int dwTransactionID,
          ref OPCHDA_TIME htStartTime,
          ref OPCHDA_TIME htEndTime,
          [MarshalAs(UnmanagedType.I4)] int hServer,
          [MarshalAs(UnmanagedType.I4)] int dwNumAttributes,
          [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4, ArraySubType = UnmanagedType.I4)] int[] dwAttributeIDs,
          out int pdwCancelID,
          out IntPtr ppErrors);

        void Cancel([MarshalAs(UnmanagedType.I4)] int dwCancelID);
    }
}
