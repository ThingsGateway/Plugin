﻿

using System;
using System.Collections;


namespace Opc.Hda
{
  [Serializable]
  public class TrendCollection : ICollection, IEnumerable, ICloneable, IList
  {
    private ArrayList m_trends = new ArrayList();

    public Trend this[int index] => (Trend) this.m_trends[index];

    public Trend this[string name]
    {
      get
      {
        foreach (Trend trend in this.m_trends)
        {
          if (trend.Name == name)
            return trend;
        }
        return (Trend) null;
      }
    }

    public TrendCollection()
    {
    }

    public TrendCollection(TrendCollection items)
    {
      if (items == null)
        return;
      foreach (Trend trend in items)
        this.Add(trend);
    }

    public virtual object Clone()
    {
      TrendCollection trendCollection = (TrendCollection) this.MemberwiseClone();
      trendCollection.m_trends = new ArrayList();
      foreach (Trend trend in this.m_trends)
        trendCollection.m_trends.Add(trend.Clone());
      return (object) trendCollection;
    }

    public bool IsSynchronized => false;

    public int Count => this.m_trends == null ? 0 : this.m_trends.Count;

    public void CopyTo(Array array, int index)
    {
      if (this.m_trends == null)
        return;
      this.m_trends.CopyTo(array, index);
    }

    public void CopyTo(Trend[] array, int index) => this.CopyTo((Array) array, index);

    public object SyncRoot => (object) this;

    public IEnumerator GetEnumerator() => this.m_trends.GetEnumerator();

    public bool IsReadOnly => false;

    object IList.this[int index]
    {
      get => this.m_trends[index];
      set
      {
        this.m_trends[index] = typeof (Trend).IsInstanceOfType(value) ? value : throw new ArgumentException("May only add Trend objects into the collection.");
      }
    }

    public void RemoveAt(int index) => this.m_trends.RemoveAt(index);

    public void Insert(int index, object value)
    {
      if (!typeof (Trend).IsInstanceOfType(value))
        throw new ArgumentException("May only add Trend objects into the collection.");
      this.m_trends.Insert(index, value);
    }

    public void Remove(object value) => this.m_trends.Remove(value);

    public bool Contains(object value) => this.m_trends.Contains(value);

    public void Clear() => this.m_trends.Clear();

    public int IndexOf(object value) => this.m_trends.IndexOf(value);

    public int Add(object value)
    {
      return typeof (Trend).IsInstanceOfType(value) ? this.m_trends.Add(value) : throw new ArgumentException("May only add Trend objects into the collection.");
    }

    public bool IsFixedSize => false;

    public void Insert(int index, Trend value) => this.Insert(index, (object) value);

    public void Remove(Trend value) => this.Remove((object) value);

    public bool Contains(Trend value) => this.Contains((object) value);

    public int IndexOf(Trend value) => this.IndexOf((object) value);

    public int Add(Trend value) => this.Add((object) value);
  }
}