// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Quote
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

/// <summary>Represent access to quote information.</summary>
[DataContract(Name = "Quote", Namespace = "TradingPlatform")]
[ProtoContract]
[Published]
public class Quote : MessageQuote, IVolumeTickData
{
  [NotPublished]
  public override MessageType Type => MessageType.Quote;

  /// <summary>Bid price</summary>
  [DataMember(Name = "Bid")]
  [ProtoMember(1)]
  public double Bid { get; set; }

  /// <summary>Bid size</summary>
  [DataMember(Name = "BidSize")]
  [ProtoMember(2)]
  public double BidSize { get; set; }

  /// <summary>Ask price</summary>
  [DataMember(Name = "Ask")]
  [ProtoMember(3)]
  public double Ask { get; set; }

  /// <summary>Ask size</summary>
  [DataMember(Name = "AskSize")]
  [ProtoMember(4)]
  public double AskSize { get; set; }

  /// <summary>
  /// Shows the direction of bid price movement, comparing to previous value.
  /// </summary>
  [DataMember(Name = "BidTickDirection")]
  [ProtoMember(5)]
  public TickDirection BidTickDirection { get; [param: In] internal set; }

  /// <summary>
  /// Shows the direction of ask price movement, comparing to previous value.
  /// </summary>
  [DataMember(Name = "AskTickDirection")]
  [ProtoMember(6)]
  public TickDirection AskTickDirection { get; [param: In] internal set; }

  private Quote()
  {
  }

  [NotPublished]
  public Quote(
    string symbol,
    double bid,
    double bidSize,
    double ask,
    double askSize,
    DateTime time)
    : base(symbol, time)
  {
    this.Bid = bid;
    this.BidSize = bidSize;
    this.Ask = ask;
    this.AskSize = askSize;
    this.BidTickDirection = TickDirection.NotSet;
    this.AskTickDirection = TickDirection.NotSet;
  }

  [NotPublished]
  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(36, 5);
    interpolatedStringHandler.AppendFormatted(base.ToString());
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓓());
    interpolatedStringHandler.AppendFormatted<double>(this.Bid);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픗());
    interpolatedStringHandler.AppendFormatted<double>(this.Ask);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓰());
    interpolatedStringHandler.AppendFormatted<double>(this.BidSize);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픧());
    interpolatedStringHandler.AppendFormatted<double>(this.AskSize);
    return interpolatedStringHandler.ToStringAndClear();
  }

  VolumeTickDataType IVolumeTickData.VolumeTickDataType => VolumeTickDataType.Ticks;

  long IVolumeTickData.Time => this.Time.Ticks;

  double IVolumeTickData.Price => this.Bid;

  double IVolumeTickData.Volume => 1.0;

  TickDirection IVolumeTickData.TickDirection => this.BidTickDirection;

  AggressorFlag IVolumeTickData.AggressorFlag => Symbol.ConvertTickDirection(this.BidTickDirection);
}
