﻿

using System;


namespace Opc.Hda
{
  [Serializable]
  public class ItemResult : Item, IResult
  {
    private ResultID m_resultID = ResultID.S_OK;
    private string m_diagnosticInfo;

    public ItemResult()
    {
    }

    public ItemResult(ItemIdentifier item)
      : base(item)
    {
    }

    public ItemResult(Item item)
      : base(item)
    {
    }

    public ItemResult(ItemResult item)
      : base((Item) item)
    {
      if (item == null)
        return;
      this.ResultID = item.ResultID;
      this.DiagnosticInfo = item.DiagnosticInfo;
    }

    public ResultID ResultID
    {
      get => this.m_resultID;
      set => this.m_resultID = value;
    }

    public string DiagnosticInfo
    {
      get => this.m_diagnosticInfo;
      set => this.m_diagnosticInfo = value;
    }
  }
}