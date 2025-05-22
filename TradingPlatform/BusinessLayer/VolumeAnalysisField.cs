// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.VolumeAnalysisField
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Reflection;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[Published]
[Obfuscation(ApplyToMembers = true, Exclude = true)]
public enum VolumeAnalysisField
{
  Trades,
  BuyTrades,
  SellTrades,
  Volume,
  BuyVolume,
  SellVolume,
  BuySellVolume,
  FilteredVolume,
  FilteredBuyVolume,
  FilteredSellVolume,
  MaxOneTradeVolume,
  BuyVolumePercent,
  SellVolumePercent,
  Delta,
  DeltaPercent,
  CumulativeDelta,
  FilteredTotalVolumePercent,
  FilteredBuyVolumePercent,
  FilteredSellVolumePercent,
  MaxOneTradeVolumePercent,
  AverageSize,
  AverageBuySize,
  AverageSellSize,
  OpenInterest,
  MinDelta,
  MaxDelta,
  DeltaFinish,
}
