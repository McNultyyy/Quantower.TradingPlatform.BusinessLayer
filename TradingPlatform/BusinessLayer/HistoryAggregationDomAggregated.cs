// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.HistoryAggregationDomAggregated
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

public sealed class HistoryAggregationDomAggregated : HistoryAggregation
{
  private const string 퓥픸 = "Price levels limit";

  public override string Name => \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픤();

  public Period Period { get; [param: In] private set; }

  public int PriceLevelsLimit { get; [param: In] private set; }

  public override IList<SettingItem> Settings
  {
    get
    {
      List<SettingItem> settings = new List<SettingItem>();
      SettingItemPeriod settingItemPeriod = new SettingItemPeriod(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓾(), this.Period);
      settingItemPeriod.SortIndex = 10;
      settingItemPeriod.Description = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓟();
      settings.Add((SettingItem) settingItemPeriod);
      SettingItemInteger settingItemInteger = new SettingItemInteger(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣핉(), this.PriceLevelsLimit);
      settingItemInteger.SortIndex = 11;
      settingItemInteger.Minimum = 0;
      settingItemInteger.Maximum = 1000;
      settings.Add((SettingItem) settingItemInteger);
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
          if (name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣핉())
            this.PriceLevelsLimit = (int) settingItem.Value;
        }
        else
          this.Period = (Period) settingItem.Value;
      }
    }
  }

  public HistoryAggregationDomAggregated(Period period) => this.Period = period;

  protected HistoryAggregationDomAggregated(HistoryAggregationDomAggregated aggregation)
    : base((HistoryAggregation) aggregation)
  {
    this.Period = aggregation.Period;
    this.PriceLevelsLimit = aggregation.PriceLevelsLimit;
  }

  [NotPublished]
  public override object Clone() => (object) new HistoryAggregationDomAggregated(this);

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
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 3);
    interpolatedStringHandler.AppendFormatted(this.Name);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓛());
    interpolatedStringHandler.AppendFormatted(this.Period.Format());
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓛());
    interpolatedStringHandler.AppendFormatted<int>(this.PriceLevelsLimit);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픛());
    return interpolatedStringHandler.ToStringAndClear();
  }

  public override HistoryAggregation GetAggregationToDirectDownload(HistoryMetadata metadata)
  {
    return !((IEnumerable<string>) metadata.AllowedAggregations).Contains<string>(this.Name) ? (HistoryAggregation) null : (HistoryAggregation) this;
  }
}
