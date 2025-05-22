// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.HistoryItemLast
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using ProtoBuf;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>Represents historical data trade item</summary>
[Published]
[ProtoContract]
[DataContract]
public sealed class HistoryItemLast : HistoryItem, IVolumeTickData, IBuyerSellerData
{
  /// <summary>Defines price value</summary>
  [ProtoMember(1)]
  [DataMember(Order = 2)]
  public double Price { get; set; }

  /// <summary>Defines volume value</summary>
  [ProtoMember(2)]
  [DataMember(Order = 3)]
  public double Volume { get; set; }

  /// <summary>Defines trade operation side as aggressor flag</summary>
  [ProtoMember(3)]
  [DataMember(Order = 4)]
  public AggressorFlag AggressorFlag { get; set; }

  [ProtoMember(4)]
  [DataMember(Order = 5)]
  public TickDirection TickDirection { get; set; }

  [ProtoMember(5)]
  [DataMember(Order = 6)]
  public double OpenInterest { get; set; }

  [ProtoMember(6)]
  [DataMember(Order = 7)]
  public string Buyer { get; set; }

  [ProtoMember(7)]
  [DataMember(Order = 8)]
  public string Seller { get; set; }

  [ProtoMember(8)]
  [DataMember(Order = 9)]
  public double FundingRate { get; set; }

  [ProtoMember(9)]
  [DataMember(Order = 10)]
  public double QuoteAssetVolume { get; set; }

  /// <summary>
  /// Gets price by indexing <see cref="T:TradingPlatform.BusinessLayer.PriceType" />
  /// </summary>
  /// <param name="priceType"></param>
  /// <returns></returns>
  public override double this[PriceType priceType]
  {
    get
    {
      double num;
      switch (priceType)
      {
        case PriceType.Open:
          num = this.Price;
          break;
        case PriceType.High:
          num = this.Price;
          break;
        case PriceType.Low:
          num = this.Price;
          break;
        case PriceType.Close:
          num = this.Price;
          break;
        case PriceType.Median:
          num = this.Price;
          break;
        case PriceType.Typical:
          num = this.Price;
          break;
        case PriceType.Weighted:
          num = this.Price;
          break;
        case PriceType.Bid:
          num = this.Price;
          break;
        case PriceType.Ask:
          num = this.Price;
          break;
        case PriceType.Last:
          num = this.Price;
          break;
        case PriceType.Volume:
          num = this.Volume;
          break;
        case PriceType.AggressorFlag:
          num = (double) this.AggressorFlag;
          break;
        case PriceType.TickDirection:
          num = (double) this.TickDirection;
          break;
        case PriceType.BidTickDirection:
          num = (double) this.TickDirection;
          break;
        case PriceType.AskTickDirection:
          num = (double) this.TickDirection;
          break;
        case PriceType.OpenInterest:
          num = this.OpenInterest;
          break;
        case PriceType.Mark:
          num = this.Price;
          break;
        case PriceType.FundingRate:
          num = this.FundingRate;
          break;
        case PriceType.QuoteAssetVolume:
          num = this.QuoteAssetVolume;
          break;
        default:
          num = base[priceType];
          break;
      }
      return num;
    }
  }

  /// <summary>Creates HistoryItemLast instance</summary>
  public HistoryItemLast()
  {
    this.Price = double.NaN;
    this.Volume = double.NaN;
    this.QuoteAssetVolume = double.NaN;
    this.AggressorFlag = AggressorFlag.NotSet;
    this.TickDirection = TickDirection.NotSet;
  }

  public HistoryItemLast(Last last)
    : base((MessageQuote) last)
  {
    this.Price = last.Price;
    this.Volume = last.Size;
    this.AggressorFlag = last.AggressorFlag;
    this.TickDirection = last.TickDirection;
    this.OpenInterest = last.OpenInterest;
    this.Buyer = last.Buyer;
    this.Seller = last.Seller;
    this.QuoteAssetVolume = last.QuoteAssetVolume;
  }

  private HistoryItemLast([In] HistoryItemLast obj0)
    : base((HistoryItem) obj0)
  {
    this.Price = obj0.Price;
    this.Volume = obj0.Volume;
    this.AggressorFlag = obj0.AggressorFlag;
    this.TickDirection = obj0.TickDirection;
    this.OpenInterest = obj0.OpenInterest;
    this.FundingRate = obj0.FundingRate;
    this.Buyer = obj0.Buyer;
    this.Seller = obj0.Seller;
    this.QuoteAssetVolume = obj0.QuoteAssetVolume;
  }

  [NotPublished]
  public override object Clone() => (object) new HistoryItemLast(this);

  /// <summary>
  /// Comparing by <see cref="P:TradingPlatform.BusinessLayer.HistoryItem.TicksLeft" />, OHLC, <see cref="P:TradingPlatform.BusinessLayer.HistoryItemLast.Volume" />
  /// </summary>
  /// <param name="obj"></param>
  /// <returns></returns>
  [NotPublished]
  public override bool Equals(object obj)
  {
    HistoryItemLast historyItemLast = obj as HistoryItemLast;
    return !(historyItemLast == (HistoryItemLast) null) && this.TicksLeft == historyItemLast.TicksLeft && this.Price == historyItemLast.Price && this.Volume == historyItemLast.Volume && this.QuoteAssetVolume == historyItemLast.QuoteAssetVolume && this.AggressorFlag == historyItemLast.AggressorFlag;
  }

  [NotPublished]
  public override int GetHashCode()
  {
    return this.TicksLeft.GetHashCode() ^ this.Price.GetHashCode() ^ this.Volume.GetHashCode() ^ this.QuoteAssetVolume.GetHashCode() ^ this.AggressorFlag.GetHashCode();
  }

  [NotPublished]
  public static bool operator ==(HistoryItemLast a, HistoryItemLast b)
  {
    if ((object) a == (object) b)
      return true;
    return (object) a != null && (object) b != null && a.Equals((object) b);
  }

  [NotPublished]
  public static bool operator !=(HistoryItemLast a, HistoryItemLast b) => !(a == b);

  [NotPublished]
  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 3);
    interpolatedStringHandler.AppendFormatted(base.ToString());
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픷());
    interpolatedStringHandler.AppendFormatted<double>(this.Price);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓻());
    interpolatedStringHandler.AppendFormatted<double>(this.Volume);
    return interpolatedStringHandler.ToStringAndClear();
  }

  VolumeTickDataType IVolumeTickData.VolumeTickDataType => VolumeTickDataType.Lasts;

  long IVolumeTickData.Time => this.TicksLeft;
}
