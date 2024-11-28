﻿

using System;


namespace Opc.Dx
{
  [Serializable]
  public class SourceServer : ItemIdentifier
  {
    private string m_name;
    private string m_description;
    private string m_serverType;
    private string m_serverURL;
    private bool m_defaultConnected;
    private bool m_defaultConnectedSpecified;

    public string Name
    {
      get => this.m_name;
      set => this.m_name = value;
    }

    public string Description
    {
      get => this.m_description;
      set => this.m_description = value;
    }

    public string ServerType
    {
      get => this.m_serverType;
      set => this.m_serverType = value;
    }

    public string ServerURL
    {
      get => this.m_serverURL;
      set => this.m_serverURL = value;
    }

    public bool DefaultConnected
    {
      get => this.m_defaultConnected;
      set => this.m_defaultConnected = value;
    }

    public bool DefaultConnectedSpecified
    {
      get => this.m_defaultConnectedSpecified;
      set => this.m_defaultConnectedSpecified = value;
    }

    public SourceServer()
    {
    }

    public SourceServer(ItemIdentifier item)
      : base(item)
    {
    }

    public SourceServer(SourceServer server)
      : base((ItemIdentifier) server)
    {
      if (server == null)
        return;
      this.m_name = server.m_name;
      this.m_description = server.m_description;
      this.m_serverType = server.m_serverType;
      this.m_serverURL = server.m_serverURL;
      this.m_defaultConnected = server.m_defaultConnected;
      this.m_defaultConnectedSpecified = server.m_defaultConnectedSpecified;
    }
  }
}
