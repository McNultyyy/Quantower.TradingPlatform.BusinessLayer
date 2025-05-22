// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.HistoryAggregation
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Integration;
using TradingPlatform.BusinessLayer.Utils.EqualityComparers;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[Published]
public abstract class HistoryAggregation : 
  ICustomizable,
  ICloneable,
  IComparable,
  IEquatable<HistoryAggregation>
{
  public const string TICK = "Tick";
  public const string TICK_BARS = "Tick bars";
  public const string TIME = "Time";
  public const string RENKO = "Renko";
  public const string HEIKIN_ASHI = "Heikin Ashi";
  public const string RANGE_BARS = "Range bars";
  public const string POINTS_AND_FIGURES = "Points & Figures";
  public const string KAGI = "Kagi";
  public const string LINE_BREAK = "Line Break";
  public const string VOLUME = "Volume";
  public const string REVERSAL = "Reversal";
  public const string POWER_TRADES = "Power Trades";
  public const string VWAP = "VWAP";
  public const string LEVEL2 = "Level2";
  public const string DOM_BY_TICKS_COUNT = "DOM by ticks count";
  public const string DOM_BY_TIME = "DOM by time";
  public const string DOM_AGGREGATED = "Aggregated DOM";
  public const string DELTA_BARS = "Delta bars";
  public const string TICK_LAST_AGGREGATED = "Aggregated ticks (Last)";
  public const string PRICE_CHANGES_COUNT_BARS = "Price changes count bars";
  public const string TIME_STATISTICS = "Time statistics";
  public const string VOLUME_PROFILE = "Volume profile";
  public const string SETTINGS_AGGREGATION_PERIOD = "Period";
  public const string SETTINGS_AGGREGATION_HISTORY_TYPE = "History type";
  private static readonly ListEqualityComparer<SettingItem> 퓍픨 = new ListEqualityComparer<SettingItem>((IEqualityComparer<SettingItem>) EqualityComparer<SettingItem>.Default);

  public abstract string Name { get; }

  public virtual string Title => this.Name;

  [NotPublished]
  public virtual TimeScaleType TimeScaleType => TimeScaleType.NonLinear;

  [NotPublished]
  public virtual BarCreationBehavior BarCreationBehavior => BarCreationBehavior.Realtime;

  public virtual IList<SettingItem> Settings
  {
    get => (IList<SettingItem>) new List<SettingItem>();
    set
    {
    }
  }

  internal Type HistoryProcessorType { get; [param: In] set; }

  protected HistoryAggregation()
  {
  }

  protected HistoryAggregation(HistoryAggregation _)
  {
  }

  [NotPublished]
  public abstract object Clone();

  [NotPublished]
  public int CompareTo(object obj) => (obj as HistoryAggregation).Name.CompareTo(this.Name);

  /// <summary>
  /// Override to change string representation of aggregation
  /// </summary>
  [NotPublished]
  public override string ToString() => this.Name;

  public virtual Period DefaultRange => Period.DAY1;

  [NotPublished]
  public virtual string FormatTime(DateTime dt) => dt.ToString();

  [NotPublished]
  [Obsolete("This property is retained for compatibility - will be removed in the future. Use casting to a specific type of aggregation and refer to the properties of the aggregation directly")]
  public abstract Period GetPeriod { get; }

  [NotPublished]
  [Obsolete("This property is retained for compatibility - will be removed in the future. Use casting to a specific type of aggregation and refer to the properties of the aggregation directly")]
  public abstract HistoryType GetHistoryType { get; }

  public abstract HistoryAggregation GetAggregationToDirectDownload(HistoryMetadata metadata);

  public bool Equals(HistoryAggregation other)
  {
    if (other == null)
      return false;
    if (this == other)
      return true;
    return this.Name == other.Name && HistoryAggregation.퓍픨.Equals(this.Settings, other.Settings);
  }

  public override bool Equals(object obj)
  {
    if (obj == null)
      return false;
    if (this == obj)
      return true;
    return !(obj.GetType() != this.GetType()) && this.Equals((HistoryAggregation) obj);
  }

  public override int GetHashCode()
  {
    return HashCode.Combine<string, int>(this.Name, HistoryAggregation.퓍픨.GetHashCode(this.Settings));
  }
}
