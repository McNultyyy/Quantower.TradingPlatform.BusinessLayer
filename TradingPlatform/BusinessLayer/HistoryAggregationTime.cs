// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.HistoryAggregationTime
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Integration;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[Published]
public class HistoryAggregationTime : HistoryAggregation, IHistoryAggregationHistoryTypeSupport
{
  public override string Name => \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픂();

  public Period Period { get; set; }

  public HistoryType HistoryType { get; set; }

  public bool UsePrevCloseAsOpenPriceBar { get; set; }

  private protected virtual IList<HistoryType> SupportedHistoryTypes
  {
    get
    {
      return (IList<HistoryType>) new List<HistoryType>()
      {
        HistoryType.Last,
        HistoryType.Mark,
        HistoryType.Bid,
        HistoryType.Ask,
        HistoryType.Midpoint
      };
    }
  }

  public override IList<SettingItem> Settings
  {
    get
    {
      List<SelectItem> list = this.SupportedHistoryTypes.Select<HistoryType, SelectItem>((Func<HistoryType, SelectItem>) (([In] obj0) => new SelectItem(obj0.GetDescription(), (int) obj0))).ToList<SelectItem>();
      List<SettingItem> settings = new List<SettingItem>();
      List<SettingItem> settingItemList1 = settings;
      SettingItemPeriod settingItemPeriod1 = new SettingItemPeriod(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓾(), this.Period);
      settingItemPeriod1.SortIndex = 10;
      settingItemPeriod1.ExcludedPeriods = new BasePeriod[1];
      settingItemPeriod1.Description = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓟();
      SettingItemPeriod settingItemPeriod2 = settingItemPeriod1;
      settingItemList1.Add((SettingItem) settingItemPeriod2);
      List<SettingItem> settingItemList2 = settings;
      SettingItemSelectorLocalized selectorLocalized = new SettingItemSelectorLocalized(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓒(), list.FirstOrDefault<SelectItem>((Func<SelectItem, bool>) (([In] obj0) => (HistoryType) obj0.Value == this.HistoryType)) ?? list.FirstOrDefault<SelectItem>(), list);
      selectorLocalized.SortIndex = 11;
      settingItemList2.Add((SettingItem) selectorLocalized);
      return (IList<SettingItem>) settings;
    }
    set
    {
      if (value == null)
        return;
      foreach (SettingItem settingItem in (IEnumerable<SettingItem>) value)
      {
        string name = settingItem.Name;
        if (!(name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓾()))
        {
          if (name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓒())
            this.HistoryType = (HistoryType) ((SelectItem) settingItem.Value).Value;
        }
        else
          this.Period = (Period) settingItem.Value;
      }
    }
  }

  public HistoryAggregationTime(Period period, HistoryType historyType)
  {
    this.Period = period;
    this.HistoryType = historyType;
  }

  [NotPublished]
  public override Period GetPeriod => this.Period;

  [NotPublished]
  public override HistoryType GetHistoryType => this.HistoryType;

  [NotPublished]
  public override TimeScaleType TimeScaleType => TimeScaleType.Linear;

  [NotPublished]
  public override string ToString()
  {
    return this.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓛() + this.Period.Format();
  }

  protected HistoryAggregationTime(HistoryAggregationTime aggregation)
    : base((HistoryAggregation) aggregation)
  {
    this.Period = aggregation.Period;
    this.HistoryType = aggregation.HistoryType;
  }

  [NotPublished]
  public override object Clone() => (object) new HistoryAggregationTime(this);

  [NotPublished]
  public override Period DefaultRange
  {
    get
    {
      if (this.Period.Ticks < 600000000L)
        return Period.DAY1;
      if (this.Period.Ticks == 600000000L)
        return new Period(BasePeriod.Day, 3);
      return this.Period.Ticks <= 864000000000L ? Period.MONTH1 : new Period(BasePeriod.Year, 10);
    }
  }

  [NotPublished]
  public override string FormatTime(DateTime dt) => this.Period.Format(dt);

  public override HistoryAggregation GetAggregationToDirectDownload(HistoryMetadata metadata)
  {
    if (((IEnumerable<string>) metadata.AllowedAggregations).Contains<string>(this.Name) && ((IEnumerable<HistoryType>) metadata.AllowedHistoryTypesHistoryAggregationTime).Contains<HistoryType>(this.HistoryType))
    {
      if (((IEnumerable<Period>) metadata.AllowedPeriodsHistoryAggregationTime).Contains<Period>(this.Period))
        return (HistoryAggregation) this;
      BasePeriod[] historyAggregationTime = metadata.AllowedBasePeriodsHistoryAggregationTime;
      Period period1 = this.Period;
      int basePeriod = (int) period1.BasePeriod;
      if (((IEnumerable<BasePeriod>) historyAggregationTime).Contains<BasePeriod>((BasePeriod) basePeriod))
        return (HistoryAggregation) new HistoryAggregationTime(this.Period, this.HistoryType);
      Period period2 = ((IEnumerable<Period>) metadata.AllowedPeriodsHistoryAggregationTime).FirstOrDefault<Period>((Func<Period, bool>) (([In] obj0) => this.Period.Ticks % obj0.Ticks == 0L));
      Period period3 = period2;
      period1 = new Period();
      Period period4 = period1;
      if (period3 != period4)
        return (HistoryAggregation) new HistoryAggregationTime(period2, this.HistoryType);
    }
    if (!((IEnumerable<string>) metadata.AllowedAggregations).Contains<string>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓑()))
      return (HistoryAggregation) null;
    HistoryType historyType = this.HistoryType == HistoryType.Ask || this.HistoryType == HistoryType.Bid ? HistoryType.BidAsk : this.HistoryType;
    return !((IEnumerable<HistoryType>) metadata.AllowedHistoryTypesHistoryAggregationTick).Contains<HistoryType>(historyType) ? (HistoryAggregation) null : (HistoryAggregation) new HistoryAggregationTick(historyType);
  }
}
