// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.HistoryAggregationTick
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
public sealed class HistoryAggregationTick : 
  HistoryAggregation,
  IHistoryAggregationHistoryTypeSupport
{
  public override string Name => \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓑();

  public HistoryType HistoryType { get; set; }

  public override IList<SettingItem> Settings
  {
    get
    {
      List<SelectItem> selectItemList = new List<SelectItem>()
      {
        new SelectItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣핌(), 3),
        new SelectItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픽(), 4),
        new SelectItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓩(), 5)
      };
      List<SettingItem> settings = new List<SettingItem>();
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
        if (settingItem.Name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓒())
          this.HistoryType = (HistoryType) ((SelectItem) settingItem.Value).Value;
      }
    }
  }

  [NotPublished]
  public override Period DefaultRange => Period.HOUR1;

  public HistoryAggregationTick(HistoryType historyType) => this.HistoryType = historyType;

  public HistoryAggregationTick(HistoryAggregationTick aggregation)
    : base((HistoryAggregation) aggregation)
  {
    this.HistoryType = aggregation.HistoryType;
  }

  [NotPublished]
  public override Period GetPeriod => Period.TICK1;

  [NotPublished]
  public override HistoryType GetHistoryType => this.HistoryType;

  [NotPublished]
  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 2);
    interpolatedStringHandler.AppendFormatted(this.Name);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓛());
    interpolatedStringHandler.AppendFormatted<HistoryType>(this.HistoryType);
    return interpolatedStringHandler.ToStringAndClear();
  }

  [NotPublished]
  public override string FormatTime(DateTime dt)
  {
    return dt.ToString(DateTimeFormatInfo.CurrentInfo.ShortDatePattern + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓶());
  }

  [NotPublished]
  public override object Clone() => (object) new HistoryAggregationTick(this);

  public override HistoryAggregation GetAggregationToDirectDownload(HistoryMetadata metadata)
  {
    if (!((IEnumerable<string>) metadata.AllowedAggregations).Contains<string>(this.Name))
      return (HistoryAggregation) null;
    return !((IEnumerable<HistoryType>) metadata.AllowedHistoryTypesHistoryAggregationTick).Contains<HistoryType>(this.HistoryType) ? (HistoryAggregation) null : (HistoryAggregation) this;
  }
}
