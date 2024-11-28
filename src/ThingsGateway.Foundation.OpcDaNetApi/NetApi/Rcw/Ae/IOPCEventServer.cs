﻿

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;


namespace OpcRcw.Ae
{
  [Guid("65168851-5783-11D1-84A0-00608CB8A7E9")]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [ComImport]
  public interface IOPCEventServer
  {
    void GetStatus(out IntPtr ppEventServerStatus);

    void CreateEventSubscription(
      [MarshalAs(UnmanagedType.I4)] int bActive,
      [MarshalAs(UnmanagedType.I4)] int dwBufferTime,
      [MarshalAs(UnmanagedType.I4)] int dwMaxSize,
      [MarshalAs(UnmanagedType.I4)] int hClientSubscription,
      ref Guid riid,
      [MarshalAs(UnmanagedType.IUnknown)] out object ppUnk,
      [MarshalAs(UnmanagedType.I4)] out int pdwRevisedBufferTime,
      [MarshalAs(UnmanagedType.I4)] out int pdwRevisedMaxSize);

    void QueryAvailableFilters([MarshalAs(UnmanagedType.I4)] out int pdwFilterMask);

    void QueryEventCategories(
      [MarshalAs(UnmanagedType.I4)] int dwEventType,
      [MarshalAs(UnmanagedType.I4)] out int pdwCount,
      out IntPtr ppdwEventCategories,
      out IntPtr ppszEventCategoryDescs);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    int QueryConditionNames([MarshalAs(UnmanagedType.I4)] int dwEventCategory, [MarshalAs(UnmanagedType.I4)] out int pdwCount, out IntPtr ppszConditionNames);

    void QuerySubConditionNames(
      [MarshalAs(UnmanagedType.LPWStr)] string szConditionName,
      [MarshalAs(UnmanagedType.I4)] out int pdwCount,
      out IntPtr ppszSubConditionNames);

    void QuerySourceConditions([MarshalAs(UnmanagedType.LPWStr)] string szSource, [MarshalAs(UnmanagedType.I4)] out int pdwCount, out IntPtr ppszConditionNames);

    void QueryEventAttributes(
      [MarshalAs(UnmanagedType.I4)] int dwEventCategory,
      [MarshalAs(UnmanagedType.I4)] out int pdwCount,
      out IntPtr ppdwAttrIDs,
      out IntPtr ppszAttrDescs,
      out IntPtr ppvtAttrTypes);

    void TranslateToItemIDs(
      [MarshalAs(UnmanagedType.LPWStr)] string szSource,
      [MarshalAs(UnmanagedType.I4)] int dwEventCategory,
      [MarshalAs(UnmanagedType.LPWStr)] string szConditionName,
      [MarshalAs(UnmanagedType.LPWStr)] string szSubconditionName,
      [MarshalAs(UnmanagedType.I4)] int dwCount,
      [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4, ArraySubType = UnmanagedType.I4)] int[] pdwAssocAttrIDs,
      out IntPtr ppszAttrItemIDs,
      out IntPtr ppszNodeNames,
      out IntPtr ppCLSIDs);

    void GetConditionState(
      [MarshalAs(UnmanagedType.LPWStr)] string szSource,
      [MarshalAs(UnmanagedType.LPWStr)] string szConditionName,
      [MarshalAs(UnmanagedType.I4)] int dwNumEventAttrs,
      [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2, ArraySubType = UnmanagedType.I4)] int[] pdwAttributeIDs,
      out IntPtr ppConditionState);

    void EnableConditionByArea([MarshalAs(UnmanagedType.I4)] int dwNumAreas, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[] pszAreas);

    void EnableConditionBySource([MarshalAs(UnmanagedType.I4)] int dwNumSources, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[] pszSources);

    void DisableConditionByArea([MarshalAs(UnmanagedType.I4)] int dwNumAreas, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[] pszAreas);

    void DisableConditionBySource([MarshalAs(UnmanagedType.I4)] int dwNumSources, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[] pszSources);

    void AckCondition(
      [MarshalAs(UnmanagedType.I4)] int dwCount,
      [MarshalAs(UnmanagedType.LPWStr)] string szAcknowledgerID,
      [MarshalAs(UnmanagedType.LPWStr)] string szComment,
      [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[] pszSource,
      [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[] szConditionName,
      [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStruct)] FILETIME[] pftActiveTime,
      [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I4)] int[] pdwCookie,
      out IntPtr ppErrors);

    void CreateAreaBrowser(ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppUnk);
  }
}
