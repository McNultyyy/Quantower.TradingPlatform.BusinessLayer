// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.VolumeAnalysisData
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[Published]
public class VolumeAnalysisData
{
  public DateTime TimeLeft { get; set; }

  /// <summary>Summary calculated Volume info</summary>
  public VolumeAnalysisItem Total { get; set; }

  /// <summary>Volume info for each price</summary>
  public Dictionary<double, VolumeAnalysisItem> PriceLevels { get; set; }

  /// <summary>
  /// Fire in case of price level was added or existing was updated
  /// </summary>
  public event EventHandler<VolumeAnalysisDataEventArgs> ItemUpdated;

  public VolumeAnalysisData()
  {
    this.Total = new VolumeAnalysisItem();
    this.PriceLevels = new Dictionary<double, VolumeAnalysisItem>();
  }

  internal VolumeAnalysisData([In] VolumeAnalysisData obj0)
  {
    this.TimeLeft = obj0.TimeLeft;
    this.Total = new VolumeAnalysisItem(obj0.Total);
    this.PriceLevels = new Dictionary<double, VolumeAnalysisItem>();
    foreach (KeyValuePair<double, VolumeAnalysisItem> priceLevel in obj0.PriceLevels)
      this.PriceLevels.Add(priceLevel.Key, new VolumeAnalysisItem(priceLevel.Value));
  }

  internal void 퓏([In] VolumeAnalysisCalculationRequest obj0, [In] HistoricalData obj1)
  {
    foreach (object obj in obj1)
      this.퓏(obj0, obj);
  }

  internal void 퓏([In] VolumeAnalysisCalculationRequest obj0, [In] MessageQuote obj1)
  {
    this.퓏(obj0, (object) obj1);
  }

  internal void 퓏([In] VolumeAnalysisCalculationRequest obj0, [In] IVolumeTickData obj1)
  {
    this.퓏(obj0, (object) obj1);
  }

  internal void 퓏([In] VolumeAnalysisCalculationRequest obj0, [In] object obj1)
  {
    if (!(obj1 is IVolumeTickData volumeTickData))
      return;
    double price = volumeTickData.Price;
    double volume = volumeTickData.Volume;
    AggressorFlag aggressorFlag = obj0.DeltaCalculationType == DeltaCalculationType.TickDirection ? Symbol.ConvertTickDirection(volumeTickData.TickDirection) : volumeTickData.AggressorFlag;
    bool flag = volumeTickData.VolumeTickDataType == VolumeTickDataType.Ticks;
    long time = volumeTickData.Time;
    if (obj0.SessionsContainer != null && !obj0.SessionsContainer.ContainsDate(time))
      return;
    double increment = obj0.Symbol.GetTickSize(price);
    if (!obj0.CustomTickSize.IsNanOrDefault())
      increment = obj0.CustomTickSize;
    if (obj0.CustomStep > 1)
      increment *= (double) obj0.CustomStep;
    if (!double.IsNaN(obj0.Symbol.MinVolumeAnalysisTickSize) && increment < obj0.Symbol.MinVolumeAnalysisTickSize)
      increment = obj0.Symbol.MinVolumeAnalysisTickSize;
    this.퓏(CoreMath.RoundToIncrement(price, increment), volume, aggressorFlag, flag, obj0.FilteredVolume);
  }

  private void 퓏([In] double obj0, [In] double obj1, [In] AggressorFlag obj2, [In] bool obj3, [In] double obj4)
  {
    this.Total.퓏(obj1, obj2, obj3, obj4);
    VolumeAnalysisItem volumeAnalysisItem;
    if (!this.PriceLevels.TryGetValue(obj0, out volumeAnalysisItem))
      this.PriceLevels.Add(obj0, volumeAnalysisItem = new VolumeAnalysisItem());
    volumeAnalysisItem.퓏(obj1, obj2, obj3, obj4);
    this.퓏(obj0, volumeAnalysisItem);
  }

  public void Calculate(double price, double size, AggressorFlag aggressorFlag)
  {
    this.퓏(price, size, aggressorFlag, false, 0.0);
  }

  public VolumeAnalysisData CreateAggregatedSnapshot(double aggregationStep)
  {
    VolumeAnalysisData aggregatedSnapshot = new VolumeAnalysisData();
    try
    {
      aggregatedSnapshot.Total = this.Total;
      foreach (KeyValuePair<double, VolumeAnalysisItem> priceLevel in this.PriceLevels)
      {
        double increment = CoreMath.RoundToIncrement(priceLevel.Key, aggregationStep);
        VolumeAnalysisItem volumeAnalysisItem;
        if (!aggregatedSnapshot.PriceLevels.TryGetValue(increment, out volumeAnalysisItem))
          aggregatedSnapshot.PriceLevels.Add(increment, volumeAnalysisItem = new VolumeAnalysisItem());
        volumeAnalysisItem.Combine(priceLevel.Value);
      }
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
    return aggregatedSnapshot;
  }

  private void 퓏([In] double obj0, [In] VolumeAnalysisItem obj1)
  {
    // ISSUE: reference to a compiler-generated field
    EventHandler<VolumeAnalysisDataEventArgs> 핇퓛 = this.핇퓛;
    if (핇퓛 == null)
      return;
    핇퓛((object) this, new VolumeAnalysisDataEventArgs(obj0, obj1));
  }

  public void Combine(VolumeAnalysisData data)
  {
    this.Total.Combine(data.Total);
    foreach (KeyValuePair<double, VolumeAnalysisItem> priceLevel in data.PriceLevels)
    {
      VolumeAnalysisItem volumeAnalysisItem;
      if (!this.PriceLevels.TryGetValue(priceLevel.Key, out volumeAnalysisItem))
        this.PriceLevels[priceLevel.Key] = volumeAnalysisItem = new VolumeAnalysisItem();
      volumeAnalysisItem.Combine(priceLevel.Value);
    }
  }

  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 2);
    interpolatedStringHandler.AppendFormatted<DateTime>(this.TimeLeft);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픆());
    interpolatedStringHandler.AppendFormatted<int>(this.PriceLevels.Count);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픅());
    return interpolatedStringHandler.ToStringAndClear();
  }
}
