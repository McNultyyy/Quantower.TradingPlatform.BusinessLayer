// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.VwapPriceType
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.ComponentModel;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public enum VwapPriceType
{
  [Description("Open")] Open,
  [Description("High")] High,
  [Description("Low")] Low,
  [Description("Close")] Close,
  [Description("HL/2")] HL2,
  [Description("HLC/3")] HLC3,
  [Description("OHLC/4")] OHLC4,
}
