// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.HistoryItemTimeStatistics
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

#nullable disable
namespace TradingPlatform.BusinessLayer;

public sealed class HistoryItemTimeStatistics : HistoryItem, IVolumeData
{
  public HistoryItemTimeStatistics()
  {
  }

  public HistoryItemTimeStatistics(HistoryItemTimeStatistics item)
    : base((HistoryItem) item)
  {
    this.TicksRight = item.TicksRight;
    this.Volume = item.Volume;
    this.BuyVolume = item.BuyVolume;
    this.SellVolume = item.SellVolume;
    this.Trades = item.Trades;
    this.BuyTrades = item.BuyTrades;
    this.SellTrades = item.SellTrades;
  }

  public override long TicksRight { get; set; }

  public double Volume { get; set; }

  public int Trades { get; set; }

  public double BuyVolume { get; set; }

  public int BuyTrades { get; set; }

  public double SellVolume { get; set; }

  public int SellTrades { get; set; }

  public override object Clone() => (object) new HistoryItemTimeStatistics(this);
}
