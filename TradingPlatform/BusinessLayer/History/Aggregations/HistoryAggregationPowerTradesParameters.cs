// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.History.Aggregations.HistoryAggregationPowerTradesParameters
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using TradingPlatform.BusinessLayer.PowerTrades;

#nullable disable
namespace TradingPlatform.BusinessLayer.History.Aggregations;

public sealed class HistoryAggregationPowerTradesParameters : 
  ICustomizable,
  ICloneable,
  IPowerTradesBaseSettings
{
  public double MinTradeVolume { get; set; }

  public double MaxTradeVolume { get; set; }

  public double TotalVolume { get; set; }

  public double TimeInterval { get; set; }

  public double BasisVolumeInterval { get; set; }

  public int MaxZoneHeight { get; set; }

  public int MinZoneHeight { get; set; }

  public double DeltaFilter { get; set; }

  public double BasisRatioFilter { get; set; }

  public double? CustomTickSize { get; set; }

  public IList<SettingItem> Settings
  {
    get
    {
      List<SettingItem> settingItemList1 = new List<SettingItem>();
      SettingItemDouble settingItemDouble1 = new SettingItemDouble(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픇(), this.MinTradeVolume);
      settingItemDouble1.Text = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픣(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓙());
      settingItemList1.Add((SettingItem) settingItemDouble1);
      SettingItemDouble settingItemDouble2 = new SettingItemDouble(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓗(), this.MaxTradeVolume);
      settingItemDouble2.Text = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픎(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓙());
      settingItemList1.Add((SettingItem) settingItemDouble2);
      SettingItemDouble settingItemDouble3 = new SettingItemDouble(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓠(), this.TotalVolume);
      settingItemDouble3.Text = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓥(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓙());
      settingItemList1.Add((SettingItem) settingItemDouble3);
      SettingItemDouble settingItemDouble4 = new SettingItemDouble(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓯(), this.TimeInterval);
      settingItemDouble4.Minimum = 0.1;
      settingItemDouble4.DecimalPlaces = 1;
      settingItemDouble4.Increment = 0.1;
      settingItemDouble4.Text = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픜(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓙());
      settingItemList1.Add((SettingItem) settingItemDouble4);
      SettingItemDouble settingItemDouble5 = new SettingItemDouble(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓑(), this.BasisVolumeInterval);
      settingItemDouble5.Minimum = 0.1;
      settingItemDouble5.Increment = 0.1;
      settingItemDouble5.DecimalPlaces = 1;
      settingItemDouble5.Text = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣핋(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓙());
      settingItemList1.Add((SettingItem) settingItemDouble5);
      SettingItemDouble settingItemDouble6 = new SettingItemDouble(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓞(), this.DeltaFilter);
      settingItemDouble6.Minimum = 0.0;
      settingItemDouble6.Maximum = 100.0;
      settingItemDouble6.DecimalPlaces = 0;
      settingItemDouble6.Increment = 1.0;
      settingItemDouble6.Text = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣핅(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓙());
      settingItemList1.Add((SettingItem) settingItemDouble6);
      SettingItemDouble settingItemDouble7 = new SettingItemDouble(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픡(), this.BasisRatioFilter);
      settingItemDouble7.Minimum = 0.0;
      settingItemDouble7.Maximum = 100.0;
      settingItemDouble7.DecimalPlaces = 2;
      settingItemDouble7.Increment = 0.01;
      settingItemDouble7.Text = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픏(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓙());
      settingItemList1.Add((SettingItem) settingItemDouble7);
      SettingItemInteger settingItemInteger1 = new SettingItemInteger(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓳(), this.MaxZoneHeight);
      settingItemInteger1.Minimum = 1;
      settingItemInteger1.Text = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣핆(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓙());
      settingItemList1.Add((SettingItem) settingItemInteger1);
      SettingItemInteger settingItemInteger2 = new SettingItemInteger(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픷(), this.MinZoneHeight);
      settingItemInteger2.Minimum = 0;
      settingItemInteger2.Text = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓻(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓙());
      settingItemList1.Add((SettingItem) settingItemInteger2);
      List<SettingItem> settings = settingItemList1;
      if (this.CustomTickSize.HasValue)
      {
        List<SettingItem> settingItemList2 = settings;
        SettingItemDouble settingItemDouble8 = new SettingItemDouble(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픸(), this.CustomTickSize.Value);
        settingItemDouble8.Text = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣프(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓙());
        settingItemList2.Add((SettingItem) settingItemDouble8);
      }
      return (IList<SettingItem>) settings;
    }
    set
    {
      SettingsHolder settingsHolder = new SettingsHolder(value);
      SettingItem settingItem;
      if (settingsHolder.TryGetValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픇(), out settingItem) && settingItem.Value is double num1)
        this.MinTradeVolume = num1;
      if (settingsHolder.TryGetValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓗(), out settingItem) && settingItem.Value is double num2)
        this.MaxTradeVolume = num2;
      if (settingsHolder.TryGetValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓠(), out settingItem) && settingItem.Value is double num3)
        this.TotalVolume = num3;
      if (settingsHolder.TryGetValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓯(), out settingItem) && settingItem.Value is double num4)
        this.TimeInterval = num4;
      if (settingsHolder.TryGetValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓑(), out settingItem) && settingItem.Value is double num5)
        this.BasisVolumeInterval = num5;
      if (settingsHolder.TryGetValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓳(), out settingItem) && settingItem.Value is int num6)
        this.MaxZoneHeight = num6;
      if (settingsHolder.TryGetValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픷(), out settingItem) && settingItem.Value is int num7)
        this.MinZoneHeight = num7;
      if (settingsHolder.TryGetValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓞(), out settingItem) && settingItem.Value is double num8)
        this.DeltaFilter = num8;
      if (settingsHolder.TryGetValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픡(), out settingItem) && settingItem.Value is double num9)
        this.BasisRatioFilter = num9;
      if (!settingsHolder.TryGetValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픸(), out settingItem) || !(settingItem.Value is double num10) || num10.IsNanOrDefault())
        return;
      this.CustomTickSize = new double?(num10);
    }
  }

  public object Clone()
  {
    return (object) new HistoryAggregationPowerTradesParameters()
    {
      TotalVolume = this.TotalVolume,
      BasisRatioFilter = this.BasisRatioFilter,
      BasisVolumeInterval = this.BasisVolumeInterval,
      DeltaFilter = this.DeltaFilter,
      CustomTickSize = this.CustomTickSize,
      MaxTradeVolume = this.MaxTradeVolume,
      MaxZoneHeight = this.MaxZoneHeight,
      MinZoneHeight = this.MinZoneHeight,
      MinTradeVolume = this.MinTradeVolume,
      TimeInterval = this.TimeInterval
    };
  }
}
