// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.MessageRule
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

[DataContract(Name = "Rule", Namespace = "TradingPlatform")]
public class MessageRule : Message
{
  public override MessageType Type => MessageType.Rule;

  [DataMember(Name = "Name")]
  public string Name { get; init; }

  [DataMember(Name = "AccountId")]
  public string AccountId { get; init; }

  [DataMember(Name = "InstrumentId")]
  public string SymbolId { get; init; }

  [DataMember(Name = "OrderTypeId")]
  public string OrderTypeId { get; init; }

  [DataMember(Name = "Value")]
  public object Value { get; init; }

  public MessageRule()
  {
    this.Name = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓯();
    this.AccountId = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓯();
    this.SymbolId = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓯();
    this.OrderTypeId = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓯();
  }

  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 2);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓼());
    interpolatedStringHandler.AppendFormatted(this.Name);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓎());
    interpolatedStringHandler.AppendFormatted<object>(this.Value);
    return interpolatedStringHandler.ToStringAndClear();
  }
}
