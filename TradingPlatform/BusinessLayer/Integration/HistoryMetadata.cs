// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.HistoryMetadata
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using ProtoBuf;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

/// <summary>
/// Mediates a history meta data with available data types and intervals on vendor side
/// </summary>
[ProtoContract]
public sealed class HistoryMetadata
{
  [ProtoMember(1)]
  public string[] AllowedAggregations { get; set; }

  [ProtoMember(2)]
  public Period[] AllowedPeriodsHistoryAggregationTime { get; set; }

  [ProtoMember(3)]
  public BasePeriod[] AllowedBasePeriodsHistoryAggregationTime { get; set; }

  [ProtoMember(4)]
  public HistoryType[] AllowedHistoryTypesHistoryAggregationTime { get; set; }

  [ProtoMember(5)]
  public HistoryType[] AllowedHistoryTypesHistoryAggregationTick { get; set; }

  [ProtoMember(6)]
  public Period[] AllowedPeriodsHistoryAggregationTimeStatistics { get; set; }

  [ProtoMember(7)]
  public BasePeriod[] AllowedBasePeriodsHistoryAggregationTimeStatistics { get; set; }

  [ProtoMember(8)]
  public TimeSpan DownloadingStep_Tick { get; set; }

  [ProtoMember(9)]
  public TimeSpan DownloadingStep_Second { get; set; }

  [ProtoMember(10)]
  public TimeSpan DownloadingStep_Minute { get; set; }

  [ProtoMember(11)]
  public TimeSpan DownloadingStep_Day { get; set; }

  [ProtoMember(12)]
  public int DegreeOfParallelism { get; set; }

  [ProtoMember(13, IsRequired = true)]
  public bool UseHistoryLocalCache { get; set; }

  [ProtoMember(14)]
  public bool BuildUncompletedBars { get; set; }

  [ProtoMember(15)]
  public bool ServerSideTickDirectionAvailable { get; set; }

  public HistoryMetadata()
  {
    this.AllowedAggregations = Array.Empty<string>();
    this.AllowedPeriodsHistoryAggregationTime = Array.Empty<Period>();
    this.AllowedHistoryTypesHistoryAggregationTime = Array.Empty<HistoryType>();
    this.AllowedHistoryTypesHistoryAggregationTick = Array.Empty<HistoryType>();
    this.AllowedBasePeriodsHistoryAggregationTime = Array.Empty<BasePeriod>();
    this.AllowedPeriodsHistoryAggregationTimeStatistics = Array.Empty<Period>();
    this.AllowedBasePeriodsHistoryAggregationTimeStatistics = Array.Empty<BasePeriod>();
    this.DownloadingStep_Tick = TimeSpan.FromDays(10.0);
    this.DownloadingStep_Second = TimeSpan.FromDays(10.0);
    this.DownloadingStep_Minute = TimeSpan.FromDays(1000.0);
    this.DownloadingStep_Day = TimeSpan.FromDays(10000.0);
    this.DegreeOfParallelism = Environment.ProcessorCount;
    this.UseHistoryLocalCache = true;
    this.BuildUncompletedBars = false;
    this.ServerSideTickDirectionAvailable = false;
  }

  public HistoryMetadata(HistoryMetadata historyMetadata)
  {
    this.AllowedAggregations = new string[historyMetadata.AllowedAggregations.Length];
    Array.Copy((Array) historyMetadata.AllowedAggregations, (Array) this.AllowedAggregations, historyMetadata.AllowedAggregations.Length);
    this.AllowedPeriodsHistoryAggregationTime = new Period[historyMetadata.AllowedPeriodsHistoryAggregationTime.Length];
    Array.Copy((Array) historyMetadata.AllowedPeriodsHistoryAggregationTime, (Array) this.AllowedPeriodsHistoryAggregationTime, this.AllowedPeriodsHistoryAggregationTime.Length);
    this.AllowedBasePeriodsHistoryAggregationTime = new BasePeriod[historyMetadata.AllowedBasePeriodsHistoryAggregationTime.Length];
    Array.Copy((Array) historyMetadata.AllowedBasePeriodsHistoryAggregationTime, (Array) this.AllowedBasePeriodsHistoryAggregationTime, historyMetadata.AllowedBasePeriodsHistoryAggregationTime.Length);
    this.AllowedHistoryTypesHistoryAggregationTime = new HistoryType[historyMetadata.AllowedHistoryTypesHistoryAggregationTime.Length];
    Array.Copy((Array) historyMetadata.AllowedHistoryTypesHistoryAggregationTime, (Array) this.AllowedHistoryTypesHistoryAggregationTime, historyMetadata.AllowedHistoryTypesHistoryAggregationTime.Length);
    this.AllowedHistoryTypesHistoryAggregationTick = new HistoryType[historyMetadata.AllowedHistoryTypesHistoryAggregationTick.Length];
    Array.Copy((Array) historyMetadata.AllowedHistoryTypesHistoryAggregationTick, (Array) this.AllowedHistoryTypesHistoryAggregationTick, historyMetadata.AllowedHistoryTypesHistoryAggregationTick.Length);
    this.AllowedPeriodsHistoryAggregationTimeStatistics = new Period[historyMetadata.AllowedPeriodsHistoryAggregationTimeStatistics.Length];
    Array.Copy((Array) historyMetadata.AllowedPeriodsHistoryAggregationTimeStatistics, (Array) this.AllowedPeriodsHistoryAggregationTimeStatistics, this.AllowedPeriodsHistoryAggregationTimeStatistics.Length);
    this.AllowedBasePeriodsHistoryAggregationTimeStatistics = new BasePeriod[historyMetadata.AllowedBasePeriodsHistoryAggregationTimeStatistics.Length];
    Array.Copy((Array) historyMetadata.AllowedBasePeriodsHistoryAggregationTimeStatistics, (Array) this.AllowedBasePeriodsHistoryAggregationTimeStatistics, historyMetadata.AllowedBasePeriodsHistoryAggregationTimeStatistics.Length);
    this.DownloadingStep_Tick = historyMetadata.DownloadingStep_Tick;
    this.DownloadingStep_Second = historyMetadata.DownloadingStep_Second;
    this.DownloadingStep_Minute = historyMetadata.DownloadingStep_Minute;
    this.DownloadingStep_Day = historyMetadata.DownloadingStep_Day;
    this.DegreeOfParallelism = historyMetadata.DegreeOfParallelism;
    this.UseHistoryLocalCache = historyMetadata.UseHistoryLocalCache;
    this.BuildUncompletedBars = historyMetadata.BuildUncompletedBars;
    this.ServerSideTickDirectionAvailable = historyMetadata.ServerSideTickDirectionAvailable;
  }

  internal HistoryMetadata Copy => new HistoryMetadata(this);

  internal TimeSpan 퓏([In] HistoryAggregation obj0)
  {
    Period getPeriod = obj0.GetPeriod;
    int basePeriod = (int) getPeriod.BasePeriod;
    TimeSpan timeSpan;
    long val1;
    if (basePeriod >= 4)
    {
      timeSpan = this.DownloadingStep_Day;
      val1 = getPeriod.Ticks / Period.DAY1.Ticks;
    }
    else if (basePeriod >= 2)
    {
      timeSpan = this.DownloadingStep_Minute;
      val1 = getPeriod.Ticks / Period.MIN1.Ticks;
    }
    else if (basePeriod >= 1)
    {
      timeSpan = this.DownloadingStep_Second;
      val1 = getPeriod.Ticks / Period.SECOND1.Ticks;
    }
    else
      return getPeriod.BasePeriod == BasePeriod.Tick && getPeriod.PeriodMultiplier != 1 ? TimeSpan.Zero : this.DownloadingStep_Tick;
    return TimeSpan.FromTicks(Math.Min(timeSpan.Ticks * Math.Max(val1, 1L), 31536000000000000L));
  }
}
