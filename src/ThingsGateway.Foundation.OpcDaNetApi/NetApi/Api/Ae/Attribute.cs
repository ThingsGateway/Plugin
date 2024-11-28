﻿

using System;


namespace Opc.Ae
{
  [Serializable]
  public class Attribute : ICloneable
  {
    private int m_id;
    private string m_name;
    private System.Type m_datatype;

    public int ID
    {
      get => this.m_id;
      set => this.m_id = value;
    }

    public string Name
    {
      get => this.m_name;
      set => this.m_name = value;
    }

    public System.Type DataType
    {
      get => this.m_datatype;
      set => this.m_datatype = value;
    }

    public override string ToString() => this.Name;

    public virtual object Clone() => this.MemberwiseClone();
  }
}