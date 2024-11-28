﻿

using System;


namespace Opc.Ae
{
  [Serializable]
  public class BrowseElement
  {
    private string m_name;
    private string m_qualifiedName;
    private BrowseType m_nodeType;

    public string Name
    {
      get => this.m_name;
      set => this.m_name = value;
    }

    public string QualifiedName
    {
      get => this.m_qualifiedName;
      set => this.m_qualifiedName = value;
    }

    public BrowseType NodeType
    {
      get => this.m_nodeType;
      set => this.m_nodeType = value;
    }

    public virtual object Clone() => this.MemberwiseClone();
  }
}
