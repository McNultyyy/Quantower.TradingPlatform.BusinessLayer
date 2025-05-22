// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.MessageTrade
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using ProtoBuf;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

[DataContract(Name = "Trade", Namespace = "TradingPlatform")]
[ProtoContract]
public sealed class MessageTrade : Message, INeedSymbolToPocess
{
  public override MessageType Type => MessageType.Trade;

  [DataMember(Name = "TradeId")]
  [ProtoMember(1)]
  public string TradeId { get; set; }

  [DataMember(Name = "OrderId")]
  [ProtoMember(2)]
  public string OrderId { get; set; }

  [DataMember(Name = "PositionId")]
  [ProtoMember(3)]
  public string PositionId { get; set; }

  [DataMember(Name = "Price")]
  [ProtoMember(4)]
  public double Price { get; set; }

  [DataMember(Name = "Quantity")]
  [ProtoMember(5)]
  public double Quantity { get; set; }

  [DataMember(Name = "Side")]
  [ProtoMember(6)]
  public Side Side { get; set; }

  [DataMember(Name = "AccountId")]
  [ProtoMember(7)]
  public string AccountId { get; set; }

  [DataMember(Name = "InstrumentSymbol")]
  [ProtoMember(8)]
  public string SymbolId { get; set; }

  [DataMember(Name = "DateTime")]
  [ProtoMember(9)]
  public DateTime DateTime { get; set; }

  [DataMember(Name = "Comment")]
  [ProtoMember(10)]
  public string Comment { get; set; }

  [DataMember(Name = "OrderType")]
  [ProtoMember(11)]
  public string OrderTypeId { get; set; }

  [DataMember(Name = "GrossPnl")]
  [ProtoMember(12)]
  public PnLItem GrossPnl { get; set; }

  [DataMember(Name = "NetPnl")]
  [ProtoMember(13)]
  public PnLItem NetPnl { get; set; }

  [DataMember(Name = "Fee")]
  [ProtoMember(14)]
  public PnLItem Fee { get; set; }

  [ProtoMember(15)]
  public PositionImpactType PositionImpactType { get; set; }

  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(28, 4);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓍());
    interpolatedStringHandler.AppendFormatted(this.SymbolId);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픆());
    interpolatedStringHandler.AppendFormatted<Side>(this.Side);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픁());
    interpolatedStringHandler.AppendFormatted<double>(this.Quantity);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픞());
    interpolatedStringHandler.AppendFormatted(this.OrderId);
    return interpolatedStringHandler.ToStringAndClear();
  }
}
