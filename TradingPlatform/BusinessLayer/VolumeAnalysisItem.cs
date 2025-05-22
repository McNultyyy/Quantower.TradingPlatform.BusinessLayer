// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.VolumeAnalysisItem
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>
/// Represent item with Volume Analysis calculation results
/// </summary>
[Published]
public class VolumeAnalysisItem : IVolumeAnalysisItem
{
  private const double 핁픓 = 1.7976931348623157E+308;
  private const double 핁픩 = -1.7976931348623157E+308;
  internal double 핁핊;

  public int Trades { get; set; }

  public int BuyTrades { get; set; }

  public int SellTrades { get; set; }

  public double Volume { get; set; }

  public double BuyVolume { get; set; }

  public double SellVolume { get; set; }

  public double FilteredTotalVolume { get; [param: In] private set; }

  public double FilteredBuyVolume { get; [param: In] private set; }

  public double FilteredSellVolume { get; [param: In] private set; }

  public double MaxOneTradeVolume { get; set; }

  public double MinDelta { get; set; }

  public double MaxDelta { get; set; }

  public double BuyVolumePercent => this.Volume <= 0.0 ? 0.0 : this.BuyVolume / this.Volume * 100.0;

  public double SellVolumePercent
  {
    get => this.Volume <= 0.0 ? 0.0 : this.SellVolume / this.Volume * 100.0;
  }

  public double Delta => this.BuyVolume - this.SellVolume;

  public double DeltaPercent => this.Volume == 0.0 ? 0.0 : this.Delta / this.Volume * 100.0;

  public double CumulativeDelta => this.핁핊 + this.Delta;

  public double FilteredTotalVolumePercent
  {
    get => this.Volume <= 0.0 ? 0.0 : this.FilteredTotalVolume / this.Volume * 100.0;
  }

  public double FilteredBuyVolumePercent
  {
    get => this.Volume <= 0.0 ? 0.0 : this.FilteredBuyVolume / this.Volume * 100.0;
  }

  public double FilteredSellVolumePercent
  {
    get => this.Volume <= 0.0 ? 0.0 : this.FilteredSellVolume / this.Volume * 100.0;
  }

  public double MaxOneTradeVolumePercent
  {
    get => this.Volume <= 0.0 ? 0.0 : this.MaxOneTradeVolume / this.Volume * 100.0;
  }

  public double AverageSize => this.Trades <= 0 ? 0.0 : this.Volume / (double) this.Trades;

  public double AverageBuySize
  {
    get => this.BuyTrades <= 0 ? 0.0 : this.BuyVolume / (double) this.BuyTrades;
  }

  public double AverageSellSize
  {
    get => this.SellTrades <= 0 ? 0.0 : this.SellVolume / (double) this.SellTrades;
  }

  public double DeltaFinish
  {
    get
    {
      return this.Delta - (Math.Abs(this.MinDelta) > Math.Abs(this.MaxDelta) ? this.MinDelta : this.MaxDelta);
    }
  }

  public VolumeAnalysisItem()
  {
    this.MinDelta = double.MaxValue;
    this.MaxDelta = double.MinValue;
  }

  internal VolumeAnalysisItem([In] VolumeAnalysisItem obj0)
  {
    this.Trades = obj0.Trades;
    this.BuyTrades = obj0.BuyTrades;
    this.SellTrades = obj0.SellTrades;
    this.Volume = obj0.Volume;
    this.BuyVolume = obj0.BuyVolume;
    this.SellVolume = obj0.SellVolume;
    this.FilteredTotalVolume = obj0.FilteredTotalVolume;
    this.FilteredBuyVolume = obj0.FilteredBuyVolume;
    this.FilteredSellVolume = obj0.FilteredSellVolume;
    this.MaxOneTradeVolume = obj0.MaxOneTradeVolume;
    this.MinDelta = obj0.MinDelta;
    this.MaxDelta = obj0.MaxDelta;
    this.핁핊 = obj0.핁핊;
  }

  public double GetValue(VolumeAnalysisField field)
  {
    double num;
    switch (field)
    {
      case VolumeAnalysisField.Trades:
        num = (double) this.Trades;
        break;
      case VolumeAnalysisField.BuyTrades:
        num = (double) this.BuyTrades;
        break;
      case VolumeAnalysisField.SellTrades:
        num = (double) this.SellTrades;
        break;
      case VolumeAnalysisField.Volume:
        num = this.Volume;
        break;
      case VolumeAnalysisField.BuyVolume:
        num = this.BuyVolume;
        break;
      case VolumeAnalysisField.SellVolume:
        num = this.SellVolume;
        break;
      case VolumeAnalysisField.BuySellVolume:
        num = this.Volume;
        break;
      case VolumeAnalysisField.FilteredVolume:
        num = this.FilteredTotalVolume;
        break;
      case VolumeAnalysisField.FilteredBuyVolume:
        num = this.FilteredBuyVolume;
        break;
      case VolumeAnalysisField.FilteredSellVolume:
        num = this.FilteredSellVolume;
        break;
      case VolumeAnalysisField.MaxOneTradeVolume:
        num = this.MaxOneTradeVolume;
        break;
      case VolumeAnalysisField.BuyVolumePercent:
        num = this.BuyVolumePercent;
        break;
      case VolumeAnalysisField.SellVolumePercent:
        num = this.SellVolumePercent;
        break;
      case VolumeAnalysisField.Delta:
        num = this.Delta;
        break;
      case VolumeAnalysisField.DeltaPercent:
        num = this.DeltaPercent;
        break;
      case VolumeAnalysisField.CumulativeDelta:
        num = this.CumulativeDelta;
        break;
      case VolumeAnalysisField.FilteredTotalVolumePercent:
        num = this.FilteredTotalVolumePercent;
        break;
      case VolumeAnalysisField.FilteredBuyVolumePercent:
        num = this.FilteredBuyVolumePercent;
        break;
      case VolumeAnalysisField.FilteredSellVolumePercent:
        num = this.FilteredSellVolumePercent;
        break;
      case VolumeAnalysisField.MaxOneTradeVolumePercent:
        num = this.MaxOneTradeVolumePercent;
        break;
      case VolumeAnalysisField.AverageSize:
        num = this.AverageSize;
        break;
      case VolumeAnalysisField.AverageBuySize:
        num = this.AverageBuySize;
        break;
      case VolumeAnalysisField.AverageSellSize:
        num = this.AverageSellSize;
        break;
      case VolumeAnalysisField.MinDelta:
        num = this.MinDelta != double.MaxValue ? this.MinDelta : 0.0;
        break;
      case VolumeAnalysisField.MaxDelta:
        num = this.MaxDelta != double.MinValue ? this.MaxDelta : 0.0;
        break;
      case VolumeAnalysisField.DeltaFinish:
        num = this.DeltaFinish;
        break;
      default:
        num = 0.0;
        break;
    }
    return num;
  }

  public void Combine(VolumeAnalysisItem item)
  {
    this.Trades += item.Trades;
    this.BuyTrades += item.BuyTrades;
    this.SellTrades += item.SellTrades;
    this.Volume += item.Volume;
    this.BuyVolume += item.BuyVolume;
    this.SellVolume += item.SellVolume;
    this.FilteredTotalVolume += item.FilteredTotalVolume;
    this.FilteredBuyVolume += item.FilteredBuyVolume;
    this.FilteredSellVolume += item.FilteredSellVolume;
    this.MaxOneTradeVolume = Math.Max(item.MaxOneTradeVolume, this.MaxOneTradeVolume);
    this.MinDelta = this.MinDelta == double.MaxValue ? Math.Min(this.MinDelta, item.MinDelta) : double.NaN;
    this.MaxDelta = this.MaxDelta == double.MinValue ? Math.Max(this.MaxDelta, item.MaxDelta) : double.NaN;
  }

  internal void 퓏([In] double obj0, AggressorFlag _param2 = AggressorFlag.None, bool _param3 = false, double _param4 = 0.0)
  {
    this.Volume += obj0;
    this.BuyVolume += _param2 == AggressorFlag.Buy ? obj0 : 0.0;
    this.SellVolume += _param2 == AggressorFlag.Sell ? obj0 : 0.0;
    double delta = this.Delta;
    this.MinDelta = Math.Min(this.MinDelta, delta);
    this.MaxDelta = Math.Max(this.MaxDelta, delta);
    if (_param3)
      return;
    ++this.Trades;
    if (obj0 > this.MaxOneTradeVolume)
      this.MaxOneTradeVolume = obj0;
    if (obj0 >= _param4)
      this.FilteredTotalVolume += obj0;
    switch (_param2)
    {
      case AggressorFlag.Buy:
        ++this.BuyTrades;
        if (obj0 < _param4)
          break;
        this.FilteredBuyVolume += obj0;
        break;
      case AggressorFlag.Sell:
        ++this.SellTrades;
        if (obj0 < _param4)
          break;
        this.FilteredSellVolume += obj0;
        break;
    }
  }
}
