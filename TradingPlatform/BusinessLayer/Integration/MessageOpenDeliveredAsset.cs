// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.MessageOpenDeliveredAsset
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

[DataContract(Name = "MessageOpenDeliveredAsset", Namespace = "TradingPlatform")]
[ProtoContract]
public class MessageOpenDeliveredAsset : Message, INeedSymbolToPocess, IXElementSerialization
{
  public override MessageType Type => MessageType.OpenDeliveredAsset;

  [DataMember(Name = "Id")]
  [ProtoMember(1)]
  public string Id { get; set; }

  [DataMember(Name = "AccountId")]
  [ProtoMember(2)]
  public string AccountId { get; set; }

  [DataMember(Name = "SymbolId")]
  [ProtoMember(3)]
  public string SymbolId { get; set; }

  [DataMember(Name = "Quantity")]
  [ProtoMember(4)]
  public double Quantity { get; set; }

  [DataMember(Name = "Status")]
  [ProtoMember(5)]
  public string Status { get; set; }

  [DataMember(Name = "CreationTime")]
  [ProtoMember(6)]
  public DateTime CreationTime { get; set; }

  public XElement ToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픶());
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓶(), (object) this.Id));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓼(), (object) this.AccountId));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픀(), (object) this.SymbolId));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓢(), (object) this.Quantity));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픖(), (object) this.Status));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓘(), (object) this.CreationTime));
    return xelement;
  }

  public void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    XElement xelement1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓶());
    if (xelement1 != null)
      this.Id = xelement1.Value;
    XElement xelement2 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓼());
    if (xelement2 != null)
      this.AccountId = xelement2.Value;
    XElement xelement3 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픀());
    if (xelement3 != null)
      this.SymbolId = xelement3.Value;
    XElement element1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓢());
    if (element1 != null)
      this.Quantity = element1.ToDouble();
    XElement xelement4 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픖());
    if (xelement4 != null)
      this.Status = xelement4.Value;
    XElement element2 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓘());
    if (element2 == null)
      return;
    this.CreationTime = element2.ToDateTime(true);
  }

  [ProtoMember(7)]
  public List<AdditionalInfoItem> AdditionalInfoItems { get; set; }
}
