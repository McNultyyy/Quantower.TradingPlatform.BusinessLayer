// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.MessageTradingSignal
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

public class MessageTradingSignal : Message
{
  public override MessageType Type => MessageType.TradingSignal;

  public string Id { get; }

  public string Ticker { get; set; }

  public string Root { get; set; }

  public string VendorName { get; set; }

  public Side Side { get; set; }

  public OrderTypeBehavior OrderTypeBehavior { get; set; }

  public double EntryPrice { get; set; }

  public double TargetPrice { get; set; }

  public double StopPrice { get; set; }

  public double Confidence { get; set; }

  public DateTime Published { get; set; }

  public DateTime Updated { get; set; }

  public DateTime ExpiresAt { get; set; }

  public string Duration { get; set; }

  public string Status { get; set; }

  public string Description { get; set; }

  public string Details { get; set; }

  public string Source { get; set; }

  public MessageTradingSignal(string id) => this.Id = id;

  public override string ToString()
  {
    return \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣핁() + this.Side.ToString().ToUpperInvariant() + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓛() + (this.Ticker ?? this.Root);
  }
}
