// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Level2Quote
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

/// <summary>Represent access to Level2 quote.</summary>
[DataContract(Name = "Level2Quote", Namespace = "TradingPlatform")]
[ProtoContract]
[Published]
public class Level2Quote : MessageQuote
{
  [NotPublished]
  public override MessageType Type => MessageType.Level2;

  /// <summary>Price type of Level2 quote: Bid or Ask</summary>
  [DataMember(Name = "PriceType")]
  [ProtoMember(1)]
  public QuotePriceType PriceType { get; [param: In] private set; }

  /// <summary>Price of Level2 quote</summary>
  [DataMember(Name = "Price")]
  [ProtoMember(2)]
  public double Price { get; [param: In] private set; }

  /// <summary>Size of Level2 quote</summary>
  [DataMember(Name = "Size")]
  [ProtoMember(3)]
  public double Size { get; [param: In] private set; }

  /// <summary>Unique ID of Level2 quote</summary>
  [DataMember(Name = "Id")]
  [ProtoMember(4)]
  public string Id { get; [param: In] private set; }

  /// <summary>
  /// Shows, whether Level2 quote is using only for removing from depth
  /// </summary>
  [DataMember(Name = "Closed")]
  [ProtoMember(5)]
  public bool Closed { get; set; }

  /// <summary>Broker identifier that send level2 quote</summary>
  [DataMember(Name = "Broker")]
  [ProtoMember(6)]
  public string Broker { get; set; }

  /// <summary>
  /// specifies the implied quantity associated with the price for the quote. Subtracting this amount from the Size yields the outright quantity for the price level. A value of zero indicates that the implied size is not available/defined or that it is actually zero.
  /// </summary>
  [DataMember(Name = "ImpliedSize")]
  [ProtoMember(7)]
  public double ImpliedSize { get; set; }

  [DataMember(Name = "Priority")]
  [ProtoMember(8)]
  public long Priority { get; set; }

  private Level2Quote()
  {
  }

  [NotPublished]
  public Level2Quote(
    QuotePriceType priceType,
    string symbolId,
    string id,
    double price,
    double size,
    DateTime time)
    : base(symbolId, time)
  {
    this.PriceType = priceType;
    this.Price = price;
    this.Size = size;
    this.Id = id;
  }

  [NotPublished]
  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(33, 5);
    interpolatedStringHandler.AppendFormatted(base.ToString());
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓧());
    interpolatedStringHandler.AppendFormatted(this.Id);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픩());
    interpolatedStringHandler.AppendFormatted<double>(this.Price);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓪());
    interpolatedStringHandler.AppendFormatted<double>(this.Size);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓡());
    interpolatedStringHandler.AppendFormatted<bool>(this.Closed);
    return interpolatedStringHandler.ToStringAndClear();
  }
}
