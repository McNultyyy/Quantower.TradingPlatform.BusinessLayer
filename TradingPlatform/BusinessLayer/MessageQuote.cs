// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.MessageQuote
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using ProtoBuf;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using TradingPlatform.BusinessLayer.Integration;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[KnownType(typeof (Level2Quote))]
[KnownType(typeof (Last))]
[KnownType(typeof (Quote))]
[KnownType(typeof (DOMQuote))]
[KnownType(typeof (DayBar))]
[KnownType(typeof (Mark))]
[DataContract(Name = "MessageQuote", Namespace = "TradingPlatform")]
[ProtoContract]
[ProtoInclude(3, typeof (Quote))]
[ProtoInclude(4, typeof (Last))]
[ProtoInclude(5, typeof (Level2Quote))]
[ProtoInclude(6, typeof (DOMQuote))]
[ProtoInclude(7, typeof (DayBar))]
[ProtoInclude(8, typeof (Mark))]
[Serializable]
public abstract class MessageQuote : Message
{
  [DataMember(Name = "Symbol")]
  [ProtoMember(1)]
  public string SymbolId { get; protected internal set; }

  /// <summary>Time of the quote</summary>
  [DataMember(Name = "Time")]
  [ProtoMember(2)]
  public DateTime Time { get; set; }

  private protected MessageQuote()
  {
  }

  protected MessageQuote(string symbolId, DateTime time)
  {
    this.SymbolId = symbolId;
    this.Time = time;
  }

  [NotPublished]
  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(5, 4);
    interpolatedStringHandler.AppendFormatted<long>(this.Time.Ticks);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프());
    interpolatedStringHandler.AppendFormatted<MessageType>(this.Type);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픆());
    interpolatedStringHandler.AppendFormatted<DateTime>(this.Time);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픆());
    interpolatedStringHandler.AppendFormatted(this.SymbolId);
    return interpolatedStringHandler.ToStringAndClear();
  }
}
