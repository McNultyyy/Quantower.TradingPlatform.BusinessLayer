// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.VolumeAnalysisMetadata
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

[ProtoContract]
public class VolumeAnalysisMetadata
{
  private readonly Dictionary<Period, TimeSpan> 핂픚;

  public VolumeAnalysisAvailability VolumeAnalysisAvailability { get; init; }

  public Dictionary<Period, TimeSpan> DownloadingStepByPeriod
  {
    private get => this.핂픚;
    init
    {
      this.핂픚 = value;
      if (this.DownloadingLevelsStepByPeriod != null && this.DownloadingLevelsStepByPeriod.Count != 0)
        return;
      this.DownloadingLevelsStepByPeriod = new Dictionary<Period, TimeSpan>((IDictionary<Period, TimeSpan>) value);
    }
  }

  public Dictionary<Period, TimeSpan> DownloadingLevelsStepByPeriod { private get; init; }

  internal bool IsVolumeAnalysisAvailable
  {
    get
    {
      return this.VolumeAnalysisAvailability == VolumeAnalysisAvailability.Available && this.DownloadingStepByPeriod.Count > 0;
    }
  }

  public bool BuildUncompletedBars { get; set; }

  public TimeSpan MaxTicksLoadingPeriod { get; set; }

  public VolumeAnalysisMetadata()
  {
    this.VolumeAnalysisAvailability = VolumeAnalysisAvailability.NotAvailable;
    this.MaxTicksLoadingPeriod = TimeSpan.FromHours(1.0);
    this.DownloadingStepByPeriod = new Dictionary<Period, TimeSpan>();
  }

  internal VolumeAnalysisMetadata Copy
  {
    get
    {
      return new VolumeAnalysisMetadata()
      {
        VolumeAnalysisAvailability = this.VolumeAnalysisAvailability,
        BuildUncompletedBars = this.BuildUncompletedBars,
        MaxTicksLoadingPeriod = this.MaxTicksLoadingPeriod,
        DownloadingStepByPeriod = new Dictionary<Period, TimeSpan>((IDictionary<Period, TimeSpan>) this.DownloadingStepByPeriod),
        DownloadingLevelsStepByPeriod = new Dictionary<Period, TimeSpan>((IDictionary<Period, TimeSpan>) this.DownloadingLevelsStepByPeriod)
      };
    }
  }

  public IDictionary<Period, TimeSpan> GetDownloadingStepByPeriod(bool includePriceLevels)
  {
    return !includePriceLevels ? (IDictionary<Period, TimeSpan>) this.DownloadingStepByPeriod : (IDictionary<Period, TimeSpan>) this.DownloadingLevelsStepByPeriod;
  }

  public Period[] GetAllowedPeriods(bool includePriceLevels)
  {
    IDictionary<Period, TimeSpan> downloadingStepByPeriod = this.GetDownloadingStepByPeriod(includePriceLevels);
    return downloadingStepByPeriod == null ? (Period[]) null : downloadingStepByPeriod.Keys.OrderByDescending<Period, long>((Func<Period, long>) (([In] obj0) => obj0.Ticks)).ToArray<Period>();
  }

  public bool TryFindLargestLoadingPeriod(
    DateTime from,
    DateTime to,
    bool includeLevels,
    out Period period)
  {
    return this.TryFindLargestLoadingPeriod(new Interval<DateTime>(from, to), includeLevels, out period);
  }

  public bool TryFindLargestLoadingPeriod(
    Interval<DateTime> interval,
    bool includeLevels,
    out Period period)
  {
    period = new Period();
    foreach (Period allowedPeriod in this.GetAllowedPeriods(includeLevels))
    {
      if (interval.Contains(allowedPeriod))
      {
        period = allowedPeriod;
        return true;
      }
    }
    return false;
  }
}
