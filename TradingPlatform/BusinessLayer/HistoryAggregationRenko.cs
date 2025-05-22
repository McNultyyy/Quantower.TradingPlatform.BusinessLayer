// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.HistoryAggregationRenko
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

[Published]
public sealed class HistoryAggregationRenko : HistoryAggregationTime
{
  public const string SETTINGS_AGGREGATION_RENKO_BRICK_SIZE = "Brick size";
  public const string SETTINGS_AGGREGATION_RENKO_STYLE = "Style";
  public const string SETTINGS_AGGREGATION_RENKO_BUILD_CURRENT_BAR = "Build current bar";
  public const string SETTINGS_AGGREGATION_RENKO_EXTENSION = "Extension, %";
  public const string SETTINGS_AGGREGATION_RENKO_INVERSION = "Inversion, %";
  public const string SETTINGS_AGGREGATION_RENKO_SHOW_WICKS = "Show wicks";
  private const string 핋픶 = "W";
  private static readonly Dictionary<RenkoStyle, string> 핋픀 = new Dictionary<RenkoStyle, string>()
  {
    {
      RenkoStyle.Classic,
      \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎핋()
    },
    {
      RenkoStyle.HighLow,
      \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓑()
    },
    {
      RenkoStyle.AdvancedClassic,
      \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픴()
    },
    {
      RenkoStyle.AdvancedHighLow,
      \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픑()
    }
  };

  public override string Name => \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓞();

  public int BrickSize { get; [param: In] private set; }

  public RenkoStyle RenkoStyle { get; [param: In] private set; }

  public int Extension { get; [param: In] private set; }

  public int Inversion { get; [param: In] private set; }

  public bool ShowWicks { get; [param: In] private set; }

  public bool BuildCurrentBar { get; [param: In] private set; }

  private protected override IList<HistoryType> SupportedHistoryTypes
  {
    get
    {
      IList<HistoryType> supportedHistoryTypes = base.SupportedHistoryTypes;
      supportedHistoryTypes.Add(HistoryType.BidAsk);
      return supportedHistoryTypes;
    }
  }

  public override IList<SettingItem> Settings
  {
    get
    {
      List<SelectItem> selectItemList = new List<SelectItem>()
      {
        new SelectItem(RenkoStyle.Classic.ToString(), 0),
        new SelectItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎핅(), 1),
        new SelectItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픡(), 2),
        new SelectItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픏(), 3)
      };
      SettingItemRelationVisibility relationVisibility = new SettingItemRelationVisibility(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픝(), new object[2]
      {
        (object) selectItemList.FirstOrDefault<SelectItem>((Func<SelectItem, bool>) (([In] obj0) => (int) obj0.Value == 2)),
        (object) selectItemList.FirstOrDefault<SelectItem>((Func<SelectItem, bool>) (([In] obj0) => (int) obj0.Value == 3))
      });
      IList<SettingItem> settings = base.Settings;
      if (settings.GetItemByName(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓾()) is SettingItemPeriod itemByName)
        itemByName.ExcludedPeriods = (BasePeriod[]) null;
      SettingItemInteger settingItemInteger1 = new SettingItemInteger(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓳(), this.BrickSize);
      settingItemInteger1.SortIndex = 20;
      settingItemInteger1.Minimum = 1;
      settingItemInteger1.Maximum = int.MaxValue;
      settingItemInteger1.Increment = 1;
      settings.Add((SettingItem) settingItemInteger1);
      SettingItemSelectorLocalized selectorLocalized = new SettingItemSelectorLocalized(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픝(), selectItemList.GetItemByValue<int>((int) this.RenkoStyle), selectItemList);
      selectorLocalized.SortIndex = 30;
      selectorLocalized.Description = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎핆();
      settings.Add((SettingItem) selectorLocalized);
      SettingItemInteger settingItemInteger2 = new SettingItemInteger(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픷(), this.Extension);
      settingItemInteger2.Minimum = 1;
      settingItemInteger2.Maximum = 1000;
      settingItemInteger2.SortIndex = 40;
      settingItemInteger2.Relation = (SettingItemRelation) relationVisibility;
      settings.Add((SettingItem) settingItemInteger2);
      SettingItemInteger settingItemInteger3 = new SettingItemInteger(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓻(), this.Inversion);
      settingItemInteger3.Minimum = 1;
      settingItemInteger3.Maximum = 1000;
      settingItemInteger3.SortIndex = 50;
      settingItemInteger3.Relation = (SettingItemRelation) relationVisibility;
      settings.Add((SettingItem) settingItemInteger3);
      SettingItemBoolean settingItemBoolean1 = new SettingItemBoolean(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픸(), this.ShowWicks);
      settingItemBoolean1.SortIndex = 60;
      settings.Add((SettingItem) settingItemBoolean1);
      SettingItemBoolean settingItemBoolean2 = new SettingItemBoolean(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎프(), this.BuildCurrentBar);
      settingItemBoolean2.SortIndex = 70;
      settings.Add((SettingItem) settingItemBoolean2);
      return settings;
    }
    set
    {
      if (value == null)
        return;
      foreach (SettingItem settingItem in (IEnumerable<SettingItem>) value)
      {
        if (settingItem != null)
        {
          string name = settingItem.Name;
          if (!(name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓳()))
          {
            if (!(name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픝()))
            {
              if (!(name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픷()))
              {
                if (!(name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓻()))
                {
                  if (!(name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎프()))
                  {
                    if (name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픸())
                      this.ShowWicks = (bool) settingItem.Value;
                  }
                  else
                    this.BuildCurrentBar = (bool) settingItem.Value;
                }
                else
                  this.Inversion = (int) settingItem.Value;
              }
              else
                this.Extension = (int) settingItem.Value;
            }
            else
              this.RenkoStyle = (RenkoStyle) ((SelectItem) settingItem.Value).Value;
          }
          else
            this.BrickSize = (int) settingItem.Value;
        }
      }
      base.Settings = value;
    }
  }

  [NotPublished]
  public override TimeScaleType TimeScaleType => TimeScaleType.NonLinear;

  [NotPublished]
  public override BarCreationBehavior BarCreationBehavior => BarCreationBehavior.Deferred;

  public HistoryAggregationRenko(
    Period period,
    HistoryType historyType,
    int brickSize,
    RenkoStyle renkoStyle,
    int extension = 100,
    int inversion = 100,
    bool showWicks = false,
    bool buildCurrentBar = true)
    : base(period, historyType)
  {
    this.BrickSize = brickSize;
    this.RenkoStyle = renkoStyle;
    this.Extension = extension;
    this.Inversion = inversion;
    this.ShowWicks = showWicks;
    this.BuildCurrentBar = buildCurrentBar;
  }

  public HistoryAggregation GetBaseAggregation()
  {
    HistoryAggregation baseAggregation;
    if (this.Period.BasePeriod == BasePeriod.Tick)
    {
      if (this.Period.PeriodMultiplier == 1)
      {
        baseAggregation = (HistoryAggregation) new HistoryAggregationTick(this.HistoryType);
        goto label_6;
      }
      if (this.Period.PeriodMultiplier > 1)
      {
        baseAggregation = (HistoryAggregation) new HistoryAggregationTickBars(this.Period.PeriodMultiplier, this.HistoryType);
        goto label_6;
      }
    }
    baseAggregation = (HistoryAggregation) new HistoryAggregationTime(this.Period, this.HistoryType);
label_6:
    return baseAggregation;
  }

  public override HistoryAggregation GetAggregationToDirectDownload(HistoryMetadata metadata)
  {
    HistoryAggregation baseAggregation = this.GetBaseAggregation();
    return baseAggregation is HistoryAggregationTime && !((IEnumerable<HistoryType>) metadata.AllowedHistoryTypesHistoryAggregationTime).Contains<HistoryType>(this.HistoryType) ? (HistoryAggregation) null : baseAggregation.GetAggregationToDirectDownload(metadata);
  }

  private HistoryAggregationRenko([In] HistoryAggregationRenko obj0)
    : base((HistoryAggregationTime) obj0)
  {
    this.BrickSize = obj0.BrickSize;
    this.RenkoStyle = obj0.RenkoStyle;
    this.ShowWicks = obj0.ShowWicks;
    this.BuildCurrentBar = obj0.BuildCurrentBar;
    this.Extension = obj0.Extension;
    this.Inversion = obj0.Inversion;
  }

  [NotPublished]
  public override object Clone() => (object) new HistoryAggregationRenko(this);

  [NotPublished]
  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(5, 5);
    interpolatedStringHandler.AppendFormatted(this.Name);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓛());
    interpolatedStringHandler.AppendFormatted<int>(this.BrickSize);
    interpolatedStringHandler.AppendFormatted(HistoryAggregationRenko.핋픀[this.RenkoStyle]);
    interpolatedStringHandler.AppendFormatted(this.ShowWicks ? \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픿() : string.Empty);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픆());
    interpolatedStringHandler.AppendFormatted(this.Period.Format());
    return interpolatedStringHandler.ToStringAndClear();
  }
}
