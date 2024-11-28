﻿

using System;


namespace Opc.Da
{
  [Serializable]
  public class BrowseElement : ICloneable
  {
    private string m_name;
    private string m_itemName;
    private string m_itemPath;
    private bool m_isItem;
    private bool m_hasChildren;
    private ItemProperty[] m_properties = new ItemProperty[0];

    public string Name
    {
      get => this.m_name;
      set => this.m_name = value;
    }

    public string ItemName
    {
      get => this.m_itemName;
      set => this.m_itemName = value;
    }

    public string ItemPath
    {
      get => this.m_itemPath;
      set => this.m_itemPath = value;
    }

    public bool IsItem
    {
      get => this.m_isItem;
      set => this.m_isItem = value;
    }

    public bool HasChildren
    {
      get => this.m_hasChildren;
      set => this.m_hasChildren = value;
    }

    public ItemProperty[] Properties
    {
      get => this.m_properties;
      set => this.m_properties = value;
    }

    public virtual object Clone()
    {
      BrowseElement browseElement = (BrowseElement) this.MemberwiseClone();
      browseElement.m_properties = (ItemProperty[]) Opc.Convert.Clone((object) this.m_properties);
      return (object) browseElement;
    }
  }
}
