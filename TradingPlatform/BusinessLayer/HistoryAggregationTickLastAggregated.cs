// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.HistoryAggregationTickLastAggregated
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Globalization;
using TradingPlatform.BusinessLayer.Integration;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public sealed class HistoryAggregationTickLastAggregated : HistoryAggregation
{
  public override string Name => \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓬();

  public override Period GetPeriod => Period.TICK1;

  public override HistoryType GetHistoryType => HistoryType.Last;

  public TimeSpan TimeDelay { get; set; }

  public override IList<SettingItem> Settings
  {
    get
    {
      List<SettingItem> settings = new List<SettingItem>();
      SettingItemInteger settingItemInteger = new SettingItemInteger(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙핇(), (int) this.TimeDelay.TotalMilliseconds);
      settingItemInteger.SortIndex = 10;
      settingItemInteger.Text = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓲(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙핂());
      settingItemInteger.Minimum = 1;
      settings.Add((SettingItem) settingItemInteger);
      return (IList<SettingItem>) settings;
    }
    set
    {
      if (value == null)
        return;
      foreach (SettingItem settingItem in (IEnumerable<SettingItem>) value)
      {
        if (settingItem.Name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙핇())
          this.TimeDelay = TimeSpan.FromMilliseconds((double) (int) settingItem.Value);
      }
    }
  }

  [NotPublished]
  public override Period DefaultRange => Period.HOUR1;

  public HistoryAggregationTickLastAggregated()
  {
    this.TimeDelay = TimeSpan.FromMilliseconds(500.0);
  }

  public HistoryAggregationTickLastAggregated(HistoryAggregationTickLastAggregated original)
  {
    this.TimeDelay = original.TimeDelay;
  }

  public override object Clone() => (object) new HistoryAggregationTickLastAggregated(this);

  [NotPublished]
  public override string FormatTime(DateTime dt)
  {
    return dt.ToString(DateTimeFormatInfo.CurrentInfo.ShortDatePattern + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓶());
  }

  public override HistoryAggregation GetAggregationToDirectDownload(HistoryMetadata metadata)
  {
    return (HistoryAggregation) new HistoryAggregationTick(HistoryType.Last);
  }
}
