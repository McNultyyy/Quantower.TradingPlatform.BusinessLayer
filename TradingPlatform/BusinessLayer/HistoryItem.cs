// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.HistoryItem
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[ProtoContract]
[ProtoInclude(2, typeof (HistoryItemLast))]
[ProtoInclude(3, typeof (HistoryItemTick))]
[ProtoInclude(4, typeof (HistoryItemMark))]
[ProtoInclude(5, typeof (HistoryItemBar))]
[ProtoInclude(6, typeof (HistoryItemLevel2))]
[ProtoInclude(7, typeof (HistoryItemDom))]
[ProtoInclude(8, typeof (HistoryItemTimeStatistics))]
[DataContract]
public abstract class HistoryItem : IHistoryItem, ICloneable
{
  private Dictionary<string, object> 퓍퓾;

  public DateTime TimeLeft => new DateTime(this.TicksLeft, DateTimeKind.Utc);

  [ProtoMember(1)]
  [DataMember(Order = 1)]
  public long TicksLeft { get; set; }

  public virtual long TicksRight
  {
    get => this.TicksLeft;
    set
    {
    }
  }

  public virtual double this[PriceType priceType] => double.NaN;

  protected HistoryItem() => this.TicksLeft = 0L;

  public void SetData(string key, object value)
  {
    if (string.IsNullOrEmpty(key))
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픿());
    if (value == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇핌());
    if (this.퓍퓾 == null)
      this.퓍퓾 = new Dictionary<string, object>();
    this.퓍퓾[key] = value;
  }

  public bool TryGetData<TData>(string key, out TData data)
  {
    data = default (TData);
    object obj;
    if (this.퓍퓾 == null || !this.퓍퓾.TryGetValue(key, out obj) || !(obj is TData data1))
      return false;
    data = data1;
    return true;
  }

  protected HistoryItem(MessageQuote message) => this.TicksLeft = message.Time.Ticks;

  protected HistoryItem(HistoryItem original)
  {
    this.TicksLeft = original.TicksLeft;
    if (original.VolumeAnalysisData != null)
      this.VolumeAnalysisData = new VolumeAnalysisData(original.VolumeAnalysisData);
    if (original.퓍퓾 == null)
      return;
    foreach (KeyValuePair<string, object> keyValuePair in original.퓍퓾)
      this.SetData(keyValuePair.Key, keyValuePair.Value);
  }

  public abstract object Clone();

  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
    interpolatedStringHandler.AppendFormatted<long>(this.TicksLeft);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프());
    interpolatedStringHandler.AppendFormatted<DateTime>(this.TimeLeft);
    return interpolatedStringHandler.ToStringAndClear();
  }

  public VolumeAnalysisData VolumeAnalysisData { get; set; }

  public static class CustomFields
  {
    public const string IS_TEMPORARY_BAR = "isTemporaryBar";
    public const string TREND = "trend";
    public const string ONE_STEP_BACK = "OneStepBack";

    public static class Trend
    {
      public const string UP = "up";
      public const string DOWN = "down";
    }
  }
}
