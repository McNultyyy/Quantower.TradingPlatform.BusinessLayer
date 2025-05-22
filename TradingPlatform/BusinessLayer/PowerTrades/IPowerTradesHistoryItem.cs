// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.PowerTrades.IPowerTradesHistoryItem
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;

#nullable disable
namespace TradingPlatform.BusinessLayer.PowerTrades;

public interface IPowerTradesHistoryItem : IHistoryItem, ICloneable
{
  double Cumulative { get; }

  double Delta { get; }

  double DeltaPercent { get; }

  double MaxPrice { get; }

  double MinPrice { get; }

  double BasisRatioPercent { get; }

  DateTime LeftTime { get; }

  DateTime RightTime { get; }
}
