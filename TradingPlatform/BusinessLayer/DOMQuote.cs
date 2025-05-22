// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.DOMQuote
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using TradingPlatform.BusinessLayer.Integration;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>
/// Represent access to DOM2 quote, which contains Bids and Asks.
/// </summary>
[DataContract(Name = "DOMQuote", Namespace = "TradingPlatform")]
[ProtoContract]
[Published]
public class DOMQuote : MessageQuote
{
  [NotPublished]
  public override MessageType Type => MessageType.DOM;

  /// <summary>Collection of Asks quotes</summary>
  [DataMember(Name = "Asks")]
  [ProtoMember(1)]
  public List<Level2Quote> Asks { get; set; }

  /// <summary>Collection of Bids quotes</summary>
  [DataMember(Name = "Bids")]
  [ProtoMember(2)]
  public List<Level2Quote> Bids { get; set; }

  private DOMQuote()
  {
  }

  [NotPublished]
  public DOMQuote(string symbolId, DateTime time)
    : base(symbolId, time)
  {
    this.Asks = new List<Level2Quote>();
    this.Bids = new List<Level2Quote>();
  }

  [NotPublished]
  public override string ToString()
  {
    StringBuilder stringBuilder1 = new StringBuilder();
    StringBuilder stringBuilder2 = stringBuilder1;
    StringBuilder stringBuilder3 = stringBuilder2;
    StringBuilder.AppendInterpolatedStringHandler interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(2, 1, stringBuilder2);
    interpolatedStringHandler.AppendFormatted(base.ToString());
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픆());
    ref StringBuilder.AppendInterpolatedStringHandler local = ref interpolatedStringHandler;
    stringBuilder3.Append(ref local);
    foreach (Level2Quote ask in this.Asks)
    {
      stringBuilder1.Append(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픘());
      stringBuilder1.Append(ask.ToString());
    }
    foreach (Level2Quote bid in this.Bids)
    {
      stringBuilder1.Append(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픨());
      stringBuilder1.Append(bid.ToString());
    }
    return stringBuilder1.ToString();
  }
}
