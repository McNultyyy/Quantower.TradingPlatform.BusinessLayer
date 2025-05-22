// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.HistoryAggregationHeikenAshi
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Integration;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[Published]
public sealed class HistoryAggregationHeikenAshi : 
  HistoryAggregation,
  IHistoryAggregationHistoryTypeSupport
{
  public override string Name => \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓫();

  public int Value { get; set; }

  public HeikenAshiSource Source { get; set; }

  [NotPublished]
  public override TimeScaleType TimeScaleType
  {
    get
    {
      TimeScaleType timeScaleType;
      switch (this.Source)
      {
        case HeikenAshiSource.Tick:
        case HeikenAshiSource.Volume:
          timeScaleType = TimeScaleType.NonLinear;
          break;
        default:
          timeScaleType = TimeScaleType.Linear;
          break;
      }
      return timeScaleType;
    }
  }

  public HistoryType HistoryType { get; set; }

  public override IList<SettingItem> Settings
  {
    get
    {
      List<SelectItem> list = Enum.GetValues(typeof (HeikenAshiSource)).Cast<HeikenAshiSource>().Select<HeikenAshiSource, SelectItem>((Func<HeikenAshiSource, SelectItem>) (([In] obj0) => new SelectItem(obj0.ToString(), (IComparable) obj0))).ToList<SelectItem>();
      List<SelectItem> selectItemList = new List<SelectItem>()
      {
        new SelectItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣핌(), 3),
        new SelectItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓩(), 5),
        new SelectItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓨(), 0),
        new SelectItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓱(), 1),
        new SelectItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픹(), 2)
      };
      List<SettingItem> settings = new List<SettingItem>();
      SettingItemInteger settingItemInteger = new SettingItemInteger(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇핌(), this.Value);
      settingItemInteger.Text = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓣(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓺());
      settingItemInteger.Minimum = 1;
      settings.Add((SettingItem) settingItemInteger);
      SettingItemSelectorLocalized selectorLocalized1 = new SettingItemSelectorLocalized(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픊(), list.FirstOrDefault<SelectItem>((Func<SelectItem, bool>) (([In] obj0) => obj0.Value.Equals((object) this.Source))), list);
      selectorLocalized1.Text = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픈(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓺());
      settings.Add((SettingItem) selectorLocalized1);
      SettingItemSelectorLocalized selectorLocalized2 = new SettingItemSelectorLocalized(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓒(), selectItemList.FirstOrDefault<SelectItem>((Func<SelectItem, bool>) (([In] obj0) => (HistoryType) obj0.Value == this.HistoryType)) ?? selectItemList.FirstOrDefault<SelectItem>(), selectItemList);
      selectorLocalized2.SortIndex = 11;
      settings.Add((SettingItem) selectorLocalized2);
      return (IList<SettingItem>) settings;
    }
    set
    {
      this.Value = value.GetValueOrDefault<int>(this.Value, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇핌());
      this.Source = value.GetValueOrDefault<HeikenAshiSource>(this.Source, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픊());
      this.HistoryType = value.GetValueOrDefault<HistoryType>(this.HistoryType, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓒());
    }
  }

  public HistoryAggregationHeikenAshi(HeikenAshiSource source, int value, HistoryType historyType)
  {
    this.Source = source;
    this.Value = value;
    this.HistoryType = historyType;
  }

  [NotPublished]
  public override Period GetPeriod
  {
    get
    {
      return this.Source != HeikenAshiSource.Volume ? new Period((BasePeriod) this.Source, this.Value) : Period.TICK1;
    }
  }

  [NotPublished]
  public override HistoryType GetHistoryType => this.HistoryType;

  [NotPublished]
  public override Period DefaultRange
  {
    get
    {
      if (this.Source == HeikenAshiSource.Volume || this.Source == HeikenAshiSource.Tick)
        return Period.HOUR1;
      if (this.Source <= HeikenAshiSource.Minute)
        return Period.DAY1;
      return this.Source <= HeikenAshiSource.Day ? Period.MONTH1 : new Period(BasePeriod.Year, 10);
    }
  }

  [NotPublished]
  public override string FormatTime(DateTime dt) => this.GetPeriod.Format(dt);

  [NotPublished]
  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 3);
    interpolatedStringHandler.AppendFormatted(this.Name);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓛());
    interpolatedStringHandler.AppendFormatted<int>(this.Value);
    interpolatedStringHandler.AppendFormatted(this.Source == HeikenAshiSource.Volume ? \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.피() : Period.BasePeriodToShortString((BasePeriod) this.Source));
    return interpolatedStringHandler.ToStringAndClear();
  }

  protected HistoryAggregationHeikenAshi(HistoryAggregationHeikenAshi aggregation)
    : base((HistoryAggregation) aggregation)
  {
    this.Source = aggregation.Source;
    this.Value = aggregation.Value;
    this.HistoryType = aggregation.HistoryType;
  }

  [NotPublished]
  public override object Clone() => (object) new HistoryAggregationHeikenAshi(this);

  public override HistoryAggregation GetAggregationToDirectDownload(HistoryMetadata metadata)
  {
    HistoryAggregation historyAggregation;
    switch (this.Source)
    {
      case HeikenAshiSource.Tick:
        historyAggregation = (HistoryAggregation) new HistoryAggregationTickBars(this.Value, this.HistoryType);
        break;
      case HeikenAshiSource.Volume:
        historyAggregation = (HistoryAggregation) new HistoryAggregationVolume(this.Value);
        break;
      default:
        historyAggregation = (HistoryAggregation) new HistoryAggregationTime(new Period((BasePeriod) this.Source, this.Value), this.HistoryType);
        break;
    }
    return historyAggregation.GetAggregationToDirectDownload(metadata);
  }
}
