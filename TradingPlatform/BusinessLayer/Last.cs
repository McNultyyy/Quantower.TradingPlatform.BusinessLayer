// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Last
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using ProtoBuf;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using TradingPlatform.BusinessLayer.Integration;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>Represent access to trade information.</summary>
[DataContract(Name = "Last", Namespace = "TradingPlatform")]
[ProtoContract]
[Published]
public class Last : MessageQuote, IVolumeTickData, IBuyerSellerData
{
  [NotPublished]
  public override MessageType Type => MessageType.Last;

  /// <summary>Price at which trade occured</summary>
  [DataMember(Name = "Price")]
  [ProtoMember(1)]
  public double Price { get; [param: In] private set; }

  /// <summary>Size of the trade</summary>
  [DataMember(Name = "Size")]
  [ProtoMember(2)]
  public double Size { get; set; }

  /// <summary>Information about operation side of the trade</summary>
  [DataMember(Name = "AggressorFlag")]
  [ProtoMember(3)]
  public AggressorFlag AggressorFlag { get; set; }

  /// <summary>
  /// Shows the direction of price movement, comparing to previous value.
  /// </summary>
  [DataMember(Name = "TickDirection")]
  [ProtoMember(4)]
  public TickDirection TickDirection { get; set; }

  [DataMember(Name = "OpenInterest")]
  [ProtoMember(5)]
  public double OpenInterest { get; set; }

  [DataMember(Name = "Buyer")]
  [ProtoMember(6)]
  public string Buyer { get; set; }

  [DataMember(Name = "Seller")]
  [ProtoMember(7)]
  public string Seller { get; set; }

  [DataMember(Name = "TradeId")]
  [ProtoMember(8)]
  public string TradeId { get; set; }

  [DataMember(Name = "QuoteAssetVolume")]
  [ProtoMember(9)]
  public double QuoteAssetVolume { get; set; }

  private Last()
  {
  }

  [NotPublished]
  public Last(string symbol, double price, double size, DateTime time)
    : base(symbol, time)
  {
    this.OpenInterest = double.NaN;
    this.Price = price;
    this.Size = size;
    this.QuoteAssetVolume = double.NaN;
    this.AggressorFlag = AggressorFlag.NotSet;
    this.TickDirection = TickDirection.NotSet;
  }

  [NotPublished]
  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 4);
    interpolatedStringHandler.AppendFormatted(base.ToString());
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픩());
    interpolatedStringHandler.AppendFormatted<double>(this.Price);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓪());
    interpolatedStringHandler.AppendFormatted<double>(this.Size);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픪());
    interpolatedStringHandler.AppendFormatted(this.TradeId);
    return interpolatedStringHandler.ToStringAndClear();
  }

  VolumeTickDataType IVolumeTickData.VolumeTickDataType => VolumeTickDataType.Lasts;

  long IVolumeTickData.Time => this.Time.Ticks;

  double IVolumeTickData.Volume => this.Size;
}
