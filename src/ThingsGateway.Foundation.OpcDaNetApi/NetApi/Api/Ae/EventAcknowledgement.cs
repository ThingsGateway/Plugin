﻿

using System;


namespace Opc.Ae
{
  [Serializable]
  public class EventAcknowledgement : ICloneable
  {
    private string m_sourceName;
    private string m_conditionName;
    private DateTime m_activeTime = DateTime.MinValue;
    private int m_cookie;

    public string SourceName
    {
      get => this.m_sourceName;
      set => this.m_sourceName = value;
    }

    public string ConditionName
    {
      get => this.m_conditionName;
      set => this.m_conditionName = value;
    }

    public DateTime ActiveTime
    {
      get => this.m_activeTime;
      set => this.m_activeTime = value;
    }

    public int Cookie
    {
      get => this.m_cookie;
      set => this.m_cookie = value;
    }

    public EventAcknowledgement()
    {
    }

    public EventAcknowledgement(EventNotification notification)
    {
      this.m_sourceName = notification.SourceID;
      this.m_conditionName = notification.ConditionName;
      this.m_activeTime = notification.ActiveTime;
      this.m_cookie = notification.Cookie;
    }

    public virtual object Clone() => this.MemberwiseClone();
  }
}
