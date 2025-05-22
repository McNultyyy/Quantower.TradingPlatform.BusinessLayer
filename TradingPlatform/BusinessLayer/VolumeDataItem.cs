// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.VolumeDataItem
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

#nullable disable
namespace TradingPlatform.BusinessLayer;

public sealed class VolumeDataItem : IVolumeData
{
  public double Volume { get; set; }

  public double BuyVolume { get; set; }

  public double SellVolume { get; set; }

  public int Trades { get; set; }

  public int BuyTrades { get; set; }

  public int SellTrades { get; set; }

  public VolumeDataItem()
  {
  }

  public VolumeDataItem(VolumeDataItem volumeData)
  {
    this.Volume = volumeData.Volume;
    this.BuyVolume = volumeData.BuyVolume;
    this.SellVolume = volumeData.SellVolume;
    this.Trades = volumeData.Trades;
    this.BuyTrades = volumeData.BuyTrades;
    this.SellTrades = volumeData.SellTrades;
  }
}
