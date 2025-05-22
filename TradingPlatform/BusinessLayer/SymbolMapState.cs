// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SymbolMapState
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public sealed class SymbolMapState
{
  public bool IsActive { get; }

  public Symbol TradableSymbol { get; }

  public Symbol QuotesSymbol { get; }

  public Symbol TickHistorySymbol { get; }

  public Symbol MinuteHistorySymbol { get; }

  public Symbol DayHistorySymbol { get; }

  public Symbol VolumeAnalysisSymbol { get; }

  internal SymbolMapState([In] SymbolMap obj0)
  {
    this.IsActive = obj0.IsActive;
    this.TradableSymbol = obj0.TradableSymbol;
    this.QuotesSymbol = obj0.QuotesSymbol;
    this.TickHistorySymbol = obj0.TickHistorySymbol;
    this.MinuteHistorySymbol = obj0.MinuteHistorySymbol;
    this.DayHistorySymbol = obj0.DayHistorySymbol;
    this.VolumeAnalysisSymbol = obj0.VolumeAnalysisSymbol;
  }
}
