// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.HistoryAggregationPointsAndFigures
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[Published]
public sealed class HistoryAggregationPointsAndFigures : HistoryAggregationTime
{
  public override string Name => \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓗();

  public int BoxSize { get; [param: In] private set; }

  public int Reversal { get; [param: In] private set; }

  public PointsAndFiguresStyle Style { get; [param: In] private set; }

  public override IList<SettingItem> Settings
  {
    get
    {
      List<SelectItem> items = new List<SelectItem>();
      SelectItem selectItem1 = (SelectItem) null;
      foreach (PointsAndFiguresStyle pointsAndFiguresStyle in Enum.GetValues(typeof (PointsAndFiguresStyle)))
      {
        SelectItem selectItem2 = new SelectItem(loc._(pointsAndFiguresStyle.GetDescription(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픎()), (int) pointsAndFiguresStyle);
        items.Add(selectItem2);
        if (this.Style == pointsAndFiguresStyle)
          selectItem1 = selectItem2;
      }
      IList<SettingItem> settings = base.Settings;
      if (settings.GetItemByName(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓾()) is SettingItemPeriod itemByName)
        itemByName.ExcludedPeriods = (BasePeriod[]) null;
      SettingItemInteger settingItemInteger1 = new SettingItemInteger(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓠(), this.BoxSize, 10);
      settingItemInteger1.Text = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓥(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픎());
      settingItemInteger1.Minimum = 1;
      settingItemInteger1.Maximum = int.MaxValue;
      settings.Add((SettingItem) settingItemInteger1);
      SettingItemInteger settingItemInteger2 = new SettingItemInteger(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픋(), this.Reversal, 20);
      settingItemInteger2.Text = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픋(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픎());
      settingItemInteger2.Minimum = 1;
      settingItemInteger2.Maximum = int.MaxValue;
      settings.Add((SettingItem) settingItemInteger2);
      SettingItemSelectorLocalized selectorLocalized = new SettingItemSelectorLocalized(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픝(), selectItem1, items, 30);
      selectorLocalized.Text = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픝(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픎());
      settings.Add((SettingItem) selectorLocalized);
      return settings;
    }
    set
    {
      base.Settings = value;
      SettingItem itemByName1 = value.GetItemByName(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓠());
      if (itemByName1 != null)
        this.BoxSize = (int) itemByName1.Value;
      SettingItem itemByName2 = value.GetItemByName(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픋());
      if (itemByName2 != null)
        this.Reversal = (int) itemByName2.Value;
      if (!(value.GetItemByName(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픝())?.Value is SelectItem selectItem))
        return;
      this.Style = (PointsAndFiguresStyle) selectItem.Value;
    }
  }

  [NotPublished]
  public override TimeScaleType TimeScaleType => TimeScaleType.NonLinear;

  [NotPublished]
  public override BarCreationBehavior BarCreationBehavior => BarCreationBehavior.Deferred;

  public HistoryAggregationPointsAndFigures(
    Period period,
    HistoryType historyType,
    int boxSize,
    int reversal,
    PointsAndFiguresStyle style)
    : base(period, historyType)
  {
    this.BoxSize = boxSize;
    this.Reversal = reversal;
    this.Style = style;
  }

  [NotPublished]
  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 4);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓯());
    interpolatedStringHandler.AppendFormatted<int>(this.Reversal);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픜());
    interpolatedStringHandler.AppendFormatted<int>(this.BoxSize);
    interpolatedStringHandler.AppendFormatted(this.Style == PointsAndFiguresStyle.Classic ? \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎핋() : \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓑());
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픆());
    interpolatedStringHandler.AppendFormatted(this.Period.Format());
    return interpolatedStringHandler.ToStringAndClear();
  }

  protected HistoryAggregationPointsAndFigures(HistoryAggregationPointsAndFigures aggregation)
    : base((HistoryAggregationTime) aggregation)
  {
    this.BoxSize = aggregation.BoxSize;
    this.Reversal = aggregation.Reversal;
    this.Style = aggregation.Style;
  }

  [NotPublished]
  public override object Clone() => (object) new HistoryAggregationPointsAndFigures(this);
}
