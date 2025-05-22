// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.HistoryAggregationDeltaBars
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Integration;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public sealed class HistoryAggregationDeltaBars : HistoryAggregation
{
  public const string SETTINGS_AGGREGATION_VOLUME_VALUE = "Delta value";

  public override string Name => \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픭();

  public int DeltaValue { get; [param: In] private set; }

  public override IList<SettingItem> Settings
  {
    get
    {
      List<SettingItem> settings = new List<SettingItem>();
      SettingItemInteger settingItemInteger = new SettingItemInteger(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픔(), this.DeltaValue);
      settingItemInteger.Minimum = 1;
      settingItemInteger.Increment = 1;
      settingItemInteger.SortIndex = 10;
      settings.Add((SettingItem) settingItemInteger);
      return (IList<SettingItem>) settings;
    }
    set
    {
      if (value == null)
        return;
      foreach (SettingItem settingItem in (IEnumerable<SettingItem>) value)
      {
        if (settingItem.Name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픔())
          this.DeltaValue = (int) settingItem.Value;
      }
    }
  }

  public HistoryAggregationDeltaBars(int deltaValue) => this.DeltaValue = deltaValue;

  private HistoryAggregationDeltaBars([In] HistoryAggregationDeltaBars obj0)
    : base((HistoryAggregation) obj0)
  {
    this.DeltaValue = obj0.DeltaValue;
  }

  public override Period GetPeriod => Period.TICK1;

  public override HistoryType GetHistoryType => HistoryType.Last;

  [NotPublished]
  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 2);
    interpolatedStringHandler.AppendFormatted(this.Name);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓛());
    interpolatedStringHandler.AppendFormatted<int>(this.DeltaValue);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣핈());
    return interpolatedStringHandler.ToStringAndClear();
  }

  [NotPublished]
  public override object Clone() => (object) new HistoryAggregationDeltaBars(this);

  [NotPublished]
  public override string FormatTime(DateTime dt)
  {
    return dt.ToString(DateTimeFormatInfo.CurrentInfo.ShortDatePattern + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓶());
  }

  [NotPublished]
  public override Period DefaultRange => Period.HOUR1;

  public override HistoryAggregation GetAggregationToDirectDownload(HistoryMetadata metadata)
  {
    return (HistoryAggregation) new HistoryAggregationTick(HistoryType.Last);
  }
}
