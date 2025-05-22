// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.History.Aggregations.HistoryAggregationVwapParameters
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;

#nullable disable
namespace TradingPlatform.BusinessLayer.History.Aggregations;

public sealed class HistoryAggregationVwapParameters : ICustomizable, ICloneable
{
  public TradingPlatform.BusinessLayer.Period? Period { get; set; }

  public HistoryAggregation Aggregation { get; set; }

  public VwapDataType DataType { get; set; }

  public VwapPriceType PriceType { get; set; }

  public VwapStdCalculationType StdCalculationType { get; set; }

  public TradingPlatform.BusinessLayer.TimeZone? TimeZone { get; set; }

  public HistoryAggregationVwapParameters()
  {
  }

  public HistoryAggregationVwapParameters(HistoryAggregationVwapParameters original)
  {
    this.Period = original.Period;
    this.Aggregation = original.Aggregation?.Clone() as HistoryAggregation;
    this.DataType = original.DataType;
    this.PriceType = original.PriceType;
    this.StdCalculationType = original.StdCalculationType;
    this.TimeZone = original.TimeZone;
  }

  public object Clone() => (object) new HistoryAggregationVwapParameters(this);

  public IList<SettingItem> Settings
  {
    get
    {
      List<SettingItem> settings = new List<SettingItem>();
      if (this.Period.HasValue)
        settings.Add((SettingItem) new SettingItemPeriod(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓾(), this.Period.Value));
      settings.Add((SettingItem) new SettingItemInteger(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픪(), (int) this.DataType));
      settings.Add((SettingItem) new SettingItemInteger(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픴(), (int) this.PriceType));
      settings.Add((SettingItem) new SettingItemInteger(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픑(), (int) this.StdCalculationType));
      if (this.Aggregation != null)
        settings.Add((SettingItem) new SettingItemGroup(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓝(), (IList<SettingItem>) new List<SettingItem>()
        {
          (SettingItem) new SettingItemString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픜(), this.Aggregation.Name),
          (SettingItem) new SettingItemGroup(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓸(), this.Aggregation.Settings)
        }));
      return (IList<SettingItem>) settings;
    }
    set
    {
      SettingsHolder settingsHolder = new SettingsHolder(value);
      SettingItem settingItem;
      if (settingsHolder.TryGetValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓾(), out settingItem) && settingItem.Value is TradingPlatform.BusinessLayer.Period period)
        this.Period = new TradingPlatform.BusinessLayer.Period?(period);
      if (settingsHolder.TryGetValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픪(), out settingItem) && settingItem?.Value is int num1)
        this.DataType = (VwapDataType) num1;
      if (settingsHolder.TryGetValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픴(), out settingItem) && settingItem?.Value is int num2)
        this.PriceType = (VwapPriceType) num2;
      if (settingsHolder.TryGetValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픑(), out settingItem) && settingItem?.Value is int num3)
        this.StdCalculationType = (VwapStdCalculationType) num3;
      string aggregatorName;
      IList<SettingItem> settingItemList;
      if (!settingsHolder.TryGetValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓝(), out settingItem) || !(settingItem?.Value is IList<SettingItem> settings) || !settings.TryGetValue<string>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픜(), out aggregatorName) || !settings.TryGetValue<IList<SettingItem>>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓸(), out settingItemList))
        return;
      this.Aggregation = Core.Instance.HistoryAggregations[aggregatorName];
      if (this.Aggregation == null)
        return;
      this.Aggregation.Settings = settingItemList;
    }
  }
}
