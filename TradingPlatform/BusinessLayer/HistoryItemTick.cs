// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.HistoryItemTick
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using ProtoBuf;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>Represents historical data tick item</summary>
[Published]
[ProtoContract]
public class HistoryItemTick : HistoryItem, IVolumeTickData
{
  /// <summary>Defines Bid price</summary>
  [ProtoMember(1)]
  public double Bid { get; set; }

  /// <summary>Defines Bid size</summary>
  [ProtoMember(2)]
  public double BidSize { get; set; }

  /// <summary>Defines Ask price</summary>
  [ProtoMember(3)]
  public double Ask { get; set; }

  /// <summary>Defines Ask size</summary>
  [ProtoMember(4)]
  public double AskSize { get; set; }

  [ProtoMember(5)]
  public TickDirection BidTickDirection { get; set; }

  [ProtoMember(6)]
  public TickDirection AskTickDirection { get; set; }

  /// <summary>
  /// Gets price by indexing <see cref="T:TradingPlatform.BusinessLayer.PriceType" />
  /// </summary>
  /// <param name="priceType"></param>
  /// <returns></returns>
  public override double this[PriceType priceType]
  {
    get
    {
      switch (priceType)
      {
        case PriceType.Open:
        case PriceType.High:
        case PriceType.Low:
        case PriceType.Close:
        case PriceType.Median:
        case PriceType.Typical:
        case PriceType.Weighted:
        case PriceType.Bid:
        case PriceType.Last:
        case PriceType.Mark:
          return this.Bid;
        case PriceType.BidSize:
          return this.BidSize;
        case PriceType.Ask:
          return this.Ask;
        case PriceType.AskSize:
          return this.AskSize;
        case PriceType.Volume:
          return 0.0;
        case PriceType.TickDirection:
        case PriceType.BidTickDirection:
          return (double) this.BidTickDirection;
        case PriceType.AskTickDirection:
          return (double) this.AskTickDirection;
        default:
          return base[priceType];
      }
    }
  }

  /// <summary>
  /// Creates HistoryItemBar instance with default Ask/AskSize/Bid/BidSize = <see cref="F:TradingPlatform.BusinessLayer.Utils.Const.DOUBLE_UNDEFINED" />
  /// </summary>
  public HistoryItemTick()
  {
    this.Bid = double.NaN;
    this.BidSize = double.NaN;
    this.Ask = double.NaN;
    this.AskSize = double.NaN;
    this.BidTickDirection = TickDirection.NotSet;
    this.AskTickDirection = TickDirection.NotSet;
  }

  private HistoryItemTick([In] HistoryItemTick obj0)
    : base((HistoryItem) obj0)
  {
    this.Bid = obj0.Bid;
    this.BidSize = obj0.BidSize;
    this.Ask = obj0.Ask;
    this.AskSize = obj0.AskSize;
  }

  [NotPublished]
  public override object Clone() => (object) new HistoryItemTick(this);

  /// <summary>
  /// Comparing by <see cref="P:TradingPlatform.BusinessLayer.HistoryItem.TicksLeft" />, OHLC, <see cref="P:TradingPlatform.BusinessLayer.HistoryItemTick.Ask" />, <see cref="P:TradingPlatform.BusinessLayer.HistoryItemTick.AskSize" />, <see cref="P:TradingPlatform.BusinessLayer.HistoryItemTick.Bid" />, <see cref="P:TradingPlatform.BusinessLayer.HistoryItemTick.BidSize" />
  /// </summary>
  /// <param name="obj"></param>
  /// <returns></returns>
  [NotPublished]
  public override bool Equals(object obj)
  {
    HistoryItemTick historyItemTick = obj as HistoryItemTick;
    return !(historyItemTick == (HistoryItemTick) null) && this.TicksLeft == historyItemTick.TicksLeft && this.Ask == historyItemTick.Ask && this.AskSize == historyItemTick.AskSize && this.Bid == historyItemTick.Bid && this.BidSize == historyItemTick.BidSize;
  }

  [NotPublished]
  public override int GetHashCode()
  {
    return this.TicksLeft.GetHashCode() ^ this.Ask.GetHashCode() ^ this.AskSize.GetHashCode() ^ this.Bid.GetHashCode() ^ this.BidSize.GetHashCode();
  }

  [NotPublished]
  public static bool operator ==(HistoryItemTick a, HistoryItemTick b)
  {
    if ((object) a == (object) b)
      return true;
    return (object) a != null && (object) b != null && a.Equals((object) b);
  }

  [NotPublished]
  public static bool operator !=(HistoryItemTick a, HistoryItemTick b) => !(a == b);

  VolumeTickDataType IVolumeTickData.VolumeTickDataType => VolumeTickDataType.Ticks;

  long IVolumeTickData.Time => this.TicksLeft;

  double IVolumeTickData.Price => this.Bid;

  double IVolumeTickData.Volume => 1.0;

  TickDirection IVolumeTickData.TickDirection => this.BidTickDirection;

  AggressorFlag IVolumeTickData.AggressorFlag => Symbol.ConvertTickDirection(this.BidTickDirection);
}
