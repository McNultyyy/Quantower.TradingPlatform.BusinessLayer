// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.HistoryAggregationLineBreak
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[Published]
public sealed class HistoryAggregationLineBreak : HistoryAggregationTime
{
  public const string SETTINGS_AGGREGATION_LINE_BREAK = "Line break";

  public override string Name => \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픇();

  public int LineBreak { get; set; }

  [NotPublished]
  public override TimeScaleType TimeScaleType => TimeScaleType.NonLinear;

  public HistoryAggregationLineBreak(Period period, HistoryType historyType, int lineBreak)
    : base(period, historyType)
  {
    this.LineBreak = lineBreak;
  }

  public override IList<SettingItem> Settings
  {
    get
    {
      IList<SettingItem> settings = base.Settings;
      if (settings.GetItemByName(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓾()) is SettingItemPeriod itemByName)
      {
        BasePeriod[] basePeriodArray = new BasePeriod[2]
        {
          BasePeriod.Month,
          BasePeriod.Year
        };
        itemByName.ExcludedPeriods = basePeriodArray;
      }
      SettingItemInteger settingItemInteger1 = new SettingItemInteger(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픣(), this.LineBreak);
      settingItemInteger1.Minimum = 1;
      settingItemInteger1.Maximum = 100;
      settingItemInteger1.SortIndex = 20;
      SettingItemInteger settingItemInteger2 = settingItemInteger1;
      settings.Add((SettingItem) settingItemInteger2);
      return settings;
    }
    set
    {
      if (value == null)
        return;
      base.Settings = value;
      foreach (SettingItem settingItem in (IEnumerable<SettingItem>) value)
      {
        if (settingItem.Name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픣())
          this.LineBreak = (int) settingItem.Value;
      }
    }
  }

  public override Period GetPeriod => this.Period;

  private HistoryAggregationLineBreak([In] HistoryAggregationLineBreak obj0)
    : base((HistoryAggregationTime) obj0)
  {
    this.LineBreak = obj0.LineBreak;
  }

  public override object Clone() => (object) new HistoryAggregationLineBreak(this);

  [NotPublished]
  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 3);
    interpolatedStringHandler.AppendFormatted(this.Name);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓛());
    interpolatedStringHandler.AppendFormatted<int>(this.LineBreak);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓙());
    interpolatedStringHandler.AppendFormatted(this.Period.Format());
    return interpolatedStringHandler.ToStringAndClear();
  }
}
