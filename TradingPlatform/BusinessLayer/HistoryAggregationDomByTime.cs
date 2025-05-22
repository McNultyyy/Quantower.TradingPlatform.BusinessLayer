// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.HistoryAggregationDomByTime
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

public sealed class HistoryAggregationDomByTime : HistoryAggregation
{
  public override string Name => \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓜();

  public Period Period { get; [param: In] private set; }

  public override IList<SettingItem> Settings
  {
    get
    {
      List<SettingItem> settings = new List<SettingItem>();
      List<SettingItem> settingItemList = settings;
      SettingItemPeriod settingItemPeriod1 = new SettingItemPeriod(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓾(), this.Period);
      settingItemPeriod1.SortIndex = 10;
      settingItemPeriod1.ExcludedPeriods = new BasePeriod[1];
      settingItemPeriod1.Description = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓟();
      SettingItemPeriod settingItemPeriod2 = settingItemPeriod1;
      settingItemList.Add((SettingItem) settingItemPeriod2);
      return (IList<SettingItem>) settings;
    }
    set
    {
      if (value == null)
        return;
      foreach (SettingItem settingItem in (IEnumerable<SettingItem>) value)
      {
        if (settingItem.Name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓾())
          this.Period = (Period) settingItem.Value;
      }
    }
  }

  public HistoryAggregationDomByTime(Period period) => this.Period = period;

  protected HistoryAggregationDomByTime(HistoryAggregationDomByTime aggregation)
    : base((HistoryAggregation) aggregation)
  {
    this.Period = aggregation.Period;
  }

  [NotPublished]
  public override object Clone() => (object) new HistoryAggregationDomByTime(this);

  [NotPublished]
  public override Period GetPeriod => this.Period;

  [NotPublished]
  public override HistoryType GetHistoryType
  {
    get => throw new Exception(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣핊());
  }

  [NotPublished]
  public override string ToString()
  {
    return this.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓛() + this.Period.Format();
  }

  public override HistoryAggregation GetAggregationToDirectDownload(HistoryMetadata metadata)
  {
    return !((IEnumerable<string>) metadata.AllowedAggregations).Contains<string>(this.Name) ? (HistoryAggregation) null : (HistoryAggregation) this;
  }
}
