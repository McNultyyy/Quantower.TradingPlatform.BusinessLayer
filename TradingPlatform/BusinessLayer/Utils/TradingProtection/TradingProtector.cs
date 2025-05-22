// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.TradingProtection.TradingProtector
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils.TradingProtection;

public class TradingProtector : ICustomizable
{
  private Period 픇핉;
  private int 픇핊;
  private readonly ConcurrentQueue<DateTime> 픇픛;
  private TimeSpan 픇퓜;

  public bool Enabled { get; set; }

  public Period Period
  {
    get => this.픇핉;
    set
    {
      this.픇핉 = value;
      this.픇퓜 = this.픇핉.Duration;
    }
  }

  public int Limit
  {
    get => this.픇핊;
    set => this.픇핊 = Math.Max(0, value);
  }

  public IList<SettingItem> Settings
  {
    get
    {
      SettingItemRelationVisibility relationVisibility = new SettingItemRelationVisibility(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁필(), new object[1]
      {
        (object) true
      });
      List<SettingItem> settings = new List<SettingItem>();
      List<SettingItem> settingItemList1 = settings;
      SettingItemBooleanSwitcher itemBooleanSwitcher = new SettingItemBooleanSwitcher(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁필(), this.Enabled);
      itemBooleanSwitcher.Text = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픏(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓖());
      itemBooleanSwitcher.SortIndex = 5;
      settingItemList1.Add((SettingItem) itemBooleanSwitcher);
      List<SettingItem> settingItemList2 = settings;
      SettingItemPeriod settingItemPeriod1 = new SettingItemPeriod(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픵(), this.Period);
      settingItemPeriod1.Text = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓾(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓖());
      settingItemPeriod1.SortIndex = 10;
      settingItemPeriod1.ExcludedPeriods = new BasePeriod[1];
      settingItemPeriod1.Relation = (SettingItemRelation) relationVisibility;
      SettingItemPeriod settingItemPeriod2 = settingItemPeriod1;
      settingItemList2.Add((SettingItem) settingItemPeriod2);
      List<SettingItem> settingItemList3 = settings;
      SettingItemInteger settingItemInteger = new SettingItemInteger(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픬(), this.Limit);
      settingItemInteger.Text = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓕(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓖());
      settingItemInteger.Minimum = 0;
      settingItemInteger.SortIndex = 20;
      settingItemInteger.Relation = (SettingItemRelation) relationVisibility;
      settingItemList3.Add((SettingItem) settingItemInteger);
      return (IList<SettingItem>) settings;
    }
    set
    {
      this.Period = value.GetValueOrDefault<Period>(this.Period, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픐());
      this.Limit = value.GetValueOrDefault<int>(this.Limit, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픭());
      this.Enabled = value.GetValueOrDefault<bool>((this.Enabled ? 1 : 0) != 0, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁필());
      this.Period = value.GetValueOrDefault<Period>(this.Period, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픵());
      this.Limit = value.GetValueOrDefault<int>(this.Limit, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픬());
    }
  }

  internal TradingProtector()
  {
    this.Enabled = true;
    this.Period = Period.SECOND1;
    this.Limit = 10;
    this.픇픛 = new ConcurrentQueue<DateTime>();
  }

  public bool IsOperationAllowed()
  {
    if (!this.Enabled)
      return true;
    int num = this.픇픛.Count < this.Limit ? 1 : 0;
    if (num == 0)
      return num != 0;
    this.픇픛.Enqueue(Core.Instance.TimeUtils.DateTimeUtcNow);
    return num != 0;
  }

  internal void 퓏()
  {
    if (!this.Enabled || this.픇퓜.Ticks <= 0L)
      return;
    DateTime dateTimeUtcNow = Core.Instance.TimeUtils.DateTimeUtcNow;
    DateTime result;
    while (this.픇픛.TryPeek(out result) && dateTimeUtcNow - result > this.픇퓜)
      this.픇픛.TryDequeue(out DateTime _);
  }
}
