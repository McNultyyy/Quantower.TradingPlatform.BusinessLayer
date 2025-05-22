// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.TradesHistoryMetadata
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

public class TradesHistoryMetadata
{
  public bool AllowLocalStorage { get; set; }

  public bool AllowSingleSymbolLoading { get; set; }

  public bool AllowReloadFromServer { get; set; } = true;

  public bool LoadTradesFromCurrentTradingDate { get; set; }

  public TradesHistoryMetadata()
  {
  }

  public TradesHistoryMetadata(TradesHistoryMetadata origin)
    : this()
  {
    this.AllowLocalStorage = origin.AllowLocalStorage;
    this.AllowSingleSymbolLoading = origin.AllowSingleSymbolLoading;
    this.AllowReloadFromServer = origin.AllowReloadFromServer;
    this.LoadTradesFromCurrentTradingDate = origin.LoadTradesFromCurrentTradingDate;
  }
}
