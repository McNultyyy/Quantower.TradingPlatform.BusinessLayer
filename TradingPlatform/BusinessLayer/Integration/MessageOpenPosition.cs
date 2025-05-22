// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.MessageOpenPosition
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

[DataContract(Name = "OpenPosition", Namespace = "TradingPlatform")]
[ProtoContract]
public class MessageOpenPosition : Message, INeedSymbolToPocess, IXElementSerialization
{
  public override MessageType Type => MessageType.OpenPosition;

  [DataMember(Name = "PositionId")]
  [ProtoMember(1)]
  public string PositionId { get; set; }

  [DataMember(Name = "OpenPrice")]
  [ProtoMember(2)]
  public double OpenPrice { get; set; }

  [DataMember(Name = "OpenTime")]
  [ProtoMember(3)]
  public DateTime OpenTime { get; set; }

  [DataMember(Name = "Quantity")]
  [ProtoMember(4)]
  public double Quantity { get; set; }

  [DataMember(Name = "Side")]
  [ProtoMember(5)]
  public Side Side { get; set; }

  [DataMember(Name = "Comment")]
  [ProtoMember(6)]
  public string Comment { get; set; }

  [DataMember(Name = "AccountId")]
  [ProtoMember(7)]
  public string AccountId { get; set; }

  [DataMember(Name = "InstrumentSymbol")]
  [ProtoMember(8)]
  public string SymbolId { get; [param: In] private set; }

  [DataMember(Name = "OpenOrderId")]
  [ProtoMember(9)]
  public string OpenOrderId { get; set; }

  [DataMember(Name = "LiquidationPrice")]
  [ProtoMember(10)]
  public double LiquidationPrice { get; set; }

  public List<AdditionalInfoItem> AdditionalInfoItems { get; set; }

  internal MessageOpenPosition() => this.LiquidationPrice = double.NaN;

  public MessageOpenPosition(string symbolId)
    : this()
  {
    this.SymbolId = symbolId;
  }

  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 4);
    interpolatedStringHandler.AppendFormatted<MessageType>(this.Type);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓧());
    interpolatedStringHandler.AppendFormatted(this.PositionId);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇핌());
    interpolatedStringHandler.AppendFormatted<double>(this.OpenPrice);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픓());
    interpolatedStringHandler.AppendFormatted(this.SymbolId);
    return interpolatedStringHandler.ToStringAndClear();
  }

  public XElement ToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓩());
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픐(), (object) this.PositionId));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓨(), (object) this.OpenPrice));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픥(), (object) this.OpenTime));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓢(), (object) this.Quantity));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇핈(), (object) this.Side));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픤(), (object) this.Comment));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓼(), (object) this.AccountId));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픀(), (object) this.SymbolId));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓱(), (object) this.OpenOrderId));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픹(), (object) this.LiquidationPrice));
    return xelement;
  }

  public void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    XElement xelement1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픐());
    if (xelement1 != null)
      this.PositionId = xelement1.Value;
    XElement element1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓨());
    if (element1 != null)
      this.OpenPrice = element1.ToDouble();
    XElement element2 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픥());
    if (element2 != null)
      this.OpenTime = element2.ToDateTime(true);
    XElement element3 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓢());
    if (element3 != null)
      this.Quantity = element3.ToDouble();
    XElement element4 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇핈());
    if (element4 != null)
      this.Side = (Side) element4.ToInt();
    XElement xelement2 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픤());
    if (xelement2 != null)
      this.Comment = xelement2.Value;
    XElement xelement3 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓼());
    if (xelement3 != null)
      this.AccountId = xelement3.Value;
    XElement xelement4 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픀());
    if (xelement4 != null)
      this.SymbolId = xelement4.Value;
    XElement xelement5 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓱());
    if (xelement5 != null)
      this.OpenOrderId = xelement5.Value;
    XElement element5 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픹());
    if (element5 == null)
      return;
    this.LiquidationPrice = element5.ToDouble();
  }
}
