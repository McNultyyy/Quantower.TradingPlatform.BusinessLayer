// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.HistoryAggregationDomByUpdatesCount
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

public sealed class HistoryAggregationDomByUpdatesCount : HistoryAggregation
{
  private const string 퓥픿 = "Ticks count";

  public override string Name => \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픺();

  public int TicksCount { get; [param: In] private set; }

  public override IList<SettingItem> Settings
  {
    get
    {
      List<SettingItem> settings = new List<SettingItem>();
      SettingItemInteger settingItemInteger = new SettingItemInteger(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣핃(), this.TicksCount);
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
        if (settingItem.Name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣핃())
          this.TicksCount = (int) settingItem.Value;
      }
    }
  }

  public HistoryAggregationDomByUpdatesCount(int ticksCount) => this.TicksCount = ticksCount;

  private HistoryAggregationDomByUpdatesCount([In] HistoryAggregationDomByUpdatesCount obj0)
    : base((HistoryAggregation) obj0)
  {
    this.TicksCount = obj0.TicksCount;
  }

  [NotPublished]
  public override object Clone() => (object) new HistoryAggregationDomByUpdatesCount(this);

  [NotPublished]
  public override Period GetPeriod => new Period(BasePeriod.Tick, this.TicksCount);

  [NotPublished]
  public override HistoryType GetHistoryType
  {
    get => throw new Exception(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣핊());
  }

  [NotPublished]
  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 3);
    interpolatedStringHandler.AppendFormatted(this.Name);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓛());
    interpolatedStringHandler.AppendFormatted<int>(this.TicksCount);
    interpolatedStringHandler.AppendFormatted(Period.BasePeriodToShortString(BasePeriod.Tick));
    return interpolatedStringHandler.ToStringAndClear();
  }

  public override HistoryAggregation GetAggregationToDirectDownload(HistoryMetadata metadata)
  {
    return !((IEnumerable<string>) metadata.AllowedAggregations).Contains<string>(this.Name) ? (HistoryAggregation) null : (HistoryAggregation) this;
  }
}
