// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.TimeInForce
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.ComponentModel;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public enum TimeInForce
{
  [Description("Default")] Default,
  [Description("Day")] Day,
  [Description("Fill Or Kill")] FOK,
  [Description("Good Till Cancel")] GTC,
  [Description("Immediate Or Cancel")] IOC,
  [Description("Good Till Date")] GTD,
  [Description("Good Till Time")] GTT,
  [Description("Fill And Kill")] FAK,
  [Description("At The Open")] ATO,
  [Description("At The Close")] ATC,
}
