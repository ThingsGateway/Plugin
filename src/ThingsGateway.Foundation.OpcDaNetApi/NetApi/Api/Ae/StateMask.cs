﻿

using System;


namespace Opc.Ae
{
  [Flags]
  public enum StateMask
  {
    Name = 1,
    ClientHandle = 2,
    Active = 4,
    BufferTime = 8,
    MaxSize = 16, // 0x00000010
    KeepAlive = 32, // 0x00000020
    All = 65535, // 0x0000FFFF
  }
}
