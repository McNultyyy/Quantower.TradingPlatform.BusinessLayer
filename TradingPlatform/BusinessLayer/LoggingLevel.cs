// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.LoggingLevel
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.ComponentModel;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[Flags]
public enum LoggingLevel
{
  System = 1,
  [Description("Exception")] Error = 2,
  Trading = 4,
  Verbose = 8,
  Quotes = 16, // 0x00000010
  Painting = 32, // 0x00000020
  Performance = 64, // 0x00000040
}
