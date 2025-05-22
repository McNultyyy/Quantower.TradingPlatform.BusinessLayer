// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.HistoryAggregationRangeBars
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Integration;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[Published]
public sealed class HistoryAggregationRangeBars : 
  HistoryAggregation,
  IHistoryAggregationHistoryTypeSupport
{
  public const string SETTINGS_AGGREGATION_RANGE_BARS = "Range bars";

  public override string Name => \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓸();

  public int RangeBars { get; [param: In] private set; }

  public HistoryType HistoryType { get; set; }

  public override IList<SettingItem> Settings
  {
    get
    {
      List<SelectItem> selectItemList = new List<SelectItem>()
      {
        new SelectItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣핌(), 3),
        new SelectItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓩(), 5),
        new SelectItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓨(), 0),
        new SelectItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓱(), 1),
        new SelectItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픹(), 2)
      };
      List<SettingItem> settings = new List<SettingItem>();
      SettingItemInteger settingItemInteger = new SettingItemInteger(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓸(), this.RangeBars);
      settingItemInteger.Minimum = 1;
      settingItemInteger.Increment = 1;
      settingItemInteger.SortIndex = 10;
      settingItemInteger.Text = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓦();
      settings.Add((SettingItem) settingItemInteger);
      SettingItemSelectorLocalized selectorLocalized = new SettingItemSelectorLocalized(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓒(), selectItemList.FirstOrDefault<SelectItem>((Func<SelectItem, bool>) (([In] obj0) => (HistoryType) obj0.Value == this.HistoryType)) ?? selectItemList.FirstOrDefault<SelectItem>(), selectItemList);
      selectorLocalized.SortIndex = 11;
      settings.Add((SettingItem) selectorLocalized);
      return (IList<SettingItem>) settings;
    }
    set
    {
      if (value == null)
        return;
      foreach (SettingItem settingItem in (IEnumerable<SettingItem>) value)
      {
        string name = settingItem.Name;
        if (!(name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓸()))
        {
          if (name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓒())
            this.HistoryType = (HistoryType) ((SelectItem) settingItem.Value).Value;
        }
        else
          this.RangeBars = (int) settingItem.Value;
      }
    }
  }

  public HistoryAggregationRangeBars(int rangeBars, HistoryType historyType)
  {
    this.RangeBars = rangeBars;
    this.HistoryType = historyType;
  }

  public override Period GetPeriod => Period.TICK1;

  [NotPublished]
  public override HistoryType GetHistoryType => this.HistoryType;

  [NotPublished]
  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 3);
    interpolatedStringHandler.AppendFormatted(this.Name);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓛());
    interpolatedStringHandler.AppendFormatted<int>(this.RangeBars);
    interpolatedStringHandler.AppendFormatted(Period.BasePeriodToShortString(BasePeriod.Tick));
    return interpolatedStringHandler.ToStringAndClear();
  }

  private HistoryAggregationRangeBars([In] HistoryAggregationRangeBars obj0)
    : base((HistoryAggregation) obj0)
  {
    this.RangeBars = obj0.RangeBars;
    this.HistoryType = obj0.HistoryType;
  }

  [NotPublished]
  public override object Clone() => (object) new HistoryAggregationRangeBars(this);

  [NotPublished]
  public override string FormatTime(DateTime dt)
  {
    return dt.ToString(DateTimeFormatInfo.CurrentInfo.ShortDatePattern + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓝());
  }

  public override HistoryAggregation GetAggregationToDirectDownload(HistoryMetadata metadata)
  {
    HistoryType historyType = this.HistoryType == HistoryType.Ask || this.HistoryType == HistoryType.Bid ? HistoryType.BidAsk : this.HistoryType;
    return !((IEnumerable<HistoryType>) metadata.AllowedHistoryTypesHistoryAggregationTick).Contains<HistoryType>(historyType) ? (HistoryAggregation) null : (HistoryAggregation) new HistoryAggregationTick(historyType);
  }
}
