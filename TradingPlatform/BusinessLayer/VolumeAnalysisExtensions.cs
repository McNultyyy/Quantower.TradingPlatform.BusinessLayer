// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.VolumeAnalysisExtensions
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using TradingPlatform.BusinessLayer.Utils;

#nullable enable
namespace TradingPlatform.BusinessLayer;

public static class VolumeAnalysisExtensions
{
  public static 
  #nullable disable
  IEnumerable<VolumeAnalysisData> AggregateVolumeAnalysis(
    this IEnumerable<IVolumeTickData> tickItems,
    Period period,
    CancellationToken cancellationToken,
    double minVolumeAnalysisTickSize = double.NaN)
  {
    if (tickItems != null)
    {
      VolumeAnalysisData volumeAnalysisData = (VolumeAnalysisData) null;
      Interval<DateTime> interval = new Interval<DateTime>();
      IEnumerator<IVolumeTickData> enumerator = tickItems.GetEnumerator();
      while (enumerator.MoveNext())
      {
        IVolumeTickData volumeTickData = enumerator.Current;
        if (cancellationToken.IsCancellationRequested)
        {
          // ISSUE: reference to a compiler-generated method
          this.퓬();
          yield break;
        }
        DateTime dateTime = new DateTime(volumeTickData.Time, DateTimeKind.Utc);
        if (!interval.Contains(dateTime))
        {
          if (volumeAnalysisData != null)
            yield return volumeAnalysisData;
          interval = period.FindInterval(dateTime);
          volumeAnalysisData = (VolumeAnalysisData) null;
        }
        if (volumeAnalysisData == null)
          volumeAnalysisData = new VolumeAnalysisData()
          {
            TimeLeft = interval.From
          };
        double price = volumeTickData.Price;
        if (!double.IsNaN(minVolumeAnalysisTickSize))
          price = CoreMath.RoundToIncrement(price, minVolumeAnalysisTickSize);
        volumeAnalysisData.Calculate(price, volumeTickData.Volume, Symbol.ConvertTickDirection(volumeTickData.TickDirection));
        volumeTickData = (IVolumeTickData) null;
      }
      // ISSUE: reference to a compiler-generated method
      this.퓬();
      enumerator = (IEnumerator<IVolumeTickData>) null;
      if (volumeAnalysisData != null)
        yield return volumeAnalysisData;
    }
  }

  public static IEnumerable<VolumeAnalysisData> AggregateVolumeAnalysisByAgressor(
    this IEnumerable<IVolumeTickData> tickItems,
    Period period,
    CancellationToken cancellationToken,
    double minVolumeAnalysisTickSize = double.NaN)
  {
    if (tickItems != null)
    {
      VolumeAnalysisData volumeAnalysisData = (VolumeAnalysisData) null;
      Interval<DateTime> interval = new Interval<DateTime>();
      IEnumerator<IVolumeTickData> enumerator = tickItems.GetEnumerator();
      while (enumerator.MoveNext())
      {
        IVolumeTickData volumeTickData = enumerator.Current;
        if (cancellationToken.IsCancellationRequested)
        {
          // ISSUE: reference to a compiler-generated method
          this.퓬();
          yield break;
        }
        DateTime dateTime = new DateTime(volumeTickData.Time, DateTimeKind.Utc);
        if (!interval.Contains(dateTime))
        {
          if (volumeAnalysisData != null)
            yield return volumeAnalysisData;
          interval = period.FindInterval(dateTime);
          volumeAnalysisData = (VolumeAnalysisData) null;
        }
        if (volumeAnalysisData == null)
          volumeAnalysisData = new VolumeAnalysisData()
          {
            TimeLeft = interval.From
          };
        double price = volumeTickData.Price;
        if (!double.IsNaN(minVolumeAnalysisTickSize))
          price = CoreMath.RoundToIncrement(price, minVolumeAnalysisTickSize);
        volumeAnalysisData.Calculate(price, volumeTickData.Volume, volumeTickData.AggressorFlag);
        volumeTickData = (IVolumeTickData) null;
      }
      // ISSUE: reference to a compiler-generated method
      this.퓬();
      enumerator = (IEnumerator<IVolumeTickData>) null;
      if (volumeAnalysisData != null)
        yield return volumeAnalysisData;
    }
  }

  public static IEnumerable<VolumeAnalysisData> AggregateVolumeAnalysis(
    this IEnumerable<VolumeAnalysisData> dataItems,
    Period period,
    CancellationToken cancellationToken)
  {
    if (dataItems != null)
    {
      VolumeAnalysisData volumeAnalysisData = (VolumeAnalysisData) null;
      Interval<DateTime> interval = new Interval<DateTime>();
      IEnumerator<VolumeAnalysisData> enumerator = dataItems.GetEnumerator();
      while (enumerator.MoveNext())
      {
        VolumeAnalysisData data = enumerator.Current;
        if (cancellationToken.IsCancellationRequested)
        {
          // ISSUE: reference to a compiler-generated method
          this.퓬();
          yield break;
        }
        DateTime timeLeft = data.TimeLeft;
        if (!interval.Contains(timeLeft))
        {
          if (volumeAnalysisData != null)
            yield return volumeAnalysisData;
          interval = period.FindInterval(timeLeft);
          volumeAnalysisData = (VolumeAnalysisData) null;
        }
        if (volumeAnalysisData == null)
          volumeAnalysisData = new VolumeAnalysisData()
          {
            TimeLeft = interval.From
          };
        volumeAnalysisData.Combine(data);
        data = (VolumeAnalysisData) null;
      }
      // ISSUE: reference to a compiler-generated method
      this.퓬();
      enumerator = (IEnumerator<VolumeAnalysisData>) null;
      if (volumeAnalysisData != null)
        yield return volumeAnalysisData;
    }
  }

  public static IList<VolumeAnalysisData> Combine(
    this IEnumerable<VolumeAnalysisData> dataItems,
    IEnumerable<VolumeAnalysisData> anotherItems)
  {
    Dictionary<DateTime, VolumeAnalysisData> dictionary = dataItems.ToDictionary<VolumeAnalysisData, DateTime, VolumeAnalysisData>((Func<VolumeAnalysisData, DateTime>) (([In] obj0) => obj0.TimeLeft), (Func<VolumeAnalysisData, VolumeAnalysisData>) (([In] obj0) => obj0));
    foreach (VolumeAnalysisData anotherItem in anotherItems)
    {
      VolumeAnalysisData volumeAnalysisData;
      if (dictionary.TryGetValue(anotherItem.TimeLeft, out volumeAnalysisData))
        volumeAnalysisData.Combine(anotherItem);
      else
        dictionary.Add(anotherItem.TimeLeft, anotherItem);
    }
    return (IList<VolumeAnalysisData>) dictionary.Select<KeyValuePair<DateTime, VolumeAnalysisData>, VolumeAnalysisData>((Func<KeyValuePair<DateTime, VolumeAnalysisData>, VolumeAnalysisData>) (([In] obj0) => obj0.Value)).OrderBy<VolumeAnalysisData, DateTime>((Func<VolumeAnalysisData, DateTime>) (([In] obj0) => obj0.TimeLeft)).ToList<VolumeAnalysisData>();
  }

  public static VolumeAnalysisData Collapse(this IEnumerable<VolumeAnalysisData> dataItems)
  {
    VolumeAnalysisData volumeAnalysisData = new VolumeAnalysisData();
    foreach (VolumeAnalysisData dataItem in dataItems)
      volumeAnalysisData.Combine(dataItem);
    return volumeAnalysisData;
  }
}
