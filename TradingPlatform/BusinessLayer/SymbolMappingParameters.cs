// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SymbolMappingParameters
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

#nullable disable
namespace TradingPlatform.BusinessLayer;

public class SymbolMappingParameters
{
  public bool IsActive { get; set; }

  public Symbol TradableSymbol { get; set; }

  public Symbol QuotesSymbol { get; set; }

  public Symbol TickHistorySymbol { get; set; }

  public Symbol MinuteHistorySymbol { get; set; }

  public Symbol DayHistorySymbol { get; set; }

  public Symbol VolumeAnalysisSymbol { get; set; }

  public SymbolMappingParameters(Symbol tradableSymbol) => this.TradableSymbol = tradableSymbol;

  public SymbolMappingParameters(SymbolMap symbolMap)
  {
    this.IsActive = symbolMap.IsActive;
    this.TradableSymbol = symbolMap.TradableSymbol;
    this.QuotesSymbol = symbolMap.QuotesSymbol;
    this.TickHistorySymbol = symbolMap.TickHistorySymbol;
    this.MinuteHistorySymbol = symbolMap.MinuteHistorySymbol;
    this.DayHistorySymbol = symbolMap.DayHistorySymbol;
    this.VolumeAnalysisSymbol = symbolMap.VolumeAnalysisSymbol;
  }
}
