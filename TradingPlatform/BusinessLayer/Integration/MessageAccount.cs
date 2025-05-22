// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.MessageAccount
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using ProtoBuf;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

[DataContract(Name = "Account", Namespace = "TradingPlatform")]
[ProtoContract]
[ProtoInclude(1000, typeof (MessageCryptoAccount))]
public class MessageAccount : Message, IXElementSerialization
{
  public override MessageType Type => MessageType.Account;

  [DataMember(Name = "ID")]
  [ProtoMember(1)]
  public string AccountId { get; set; }

  [DataMember(Name = "Name")]
  [ProtoMember(2)]
  public string AccountName { get; set; }

  [DataMember(Name = "AssetId")]
  [ProtoMember(3)]
  public string AssetId { get; set; }

  [DataMember(Name = "Balance")]
  [ProtoMember(4)]
  public double Balance { get; set; }

  [ProtoMember(5)]
  public NettingType NettingType { get; set; }

  public MessageAccount() => this.NettingType = NettingType.Undefined;

  [ProtoMember(6)]
  public List<AdditionalInfoItem> AccountAdditionalInfo { get; set; }

  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 4);
    interpolatedStringHandler.AppendFormatted<MessageType>(this.Type);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓧());
    interpolatedStringHandler.AppendFormatted(this.AccountId);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픰());
    interpolatedStringHandler.AppendFormatted(this.AccountName);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓢());
    interpolatedStringHandler.AppendFormatted<double>(this.Balance);
    return interpolatedStringHandler.ToStringAndClear();
  }

  public XElement ToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픫());
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픸(), (object) this.AccountId));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픜(), (object) this.AccountName));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픯(), (object) this.AssetId));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓾(), (object) this.Balance));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓐(), (object) (int) this.NettingType));
    XElement content = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픚());
    if (this.AccountAdditionalInfo != null)
    {
      foreach (AdditionalInfoItem additionalInfoItem in this.AccountAdditionalInfo)
        content.Add((object) additionalInfoItem.ToXElement());
    }
    xelement.Add((object) content);
    return xelement;
  }

  public void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    XElement xelement1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픸());
    if (xelement1 != null)
      this.AccountId = xelement1.Value;
    XElement xelement2 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픜());
    if (xelement2 != null)
      this.AccountName = xelement2.Value;
    XElement xelement3 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픯());
    if (xelement3 != null)
      this.AssetId = xelement3.Value;
    XElement element1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓾());
    if (element1 != null)
      this.Balance = element1.ToDouble();
    XElement element2 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓐());
    if (element2 != null)
      this.NettingType = (NettingType) element2.ToInt();
    XElement xelement4 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픚());
    if (xelement4 == null)
      return;
    this.AccountAdditionalInfo = new List<AdditionalInfoItem>();
    foreach (XElement element3 in xelement4.Elements())
    {
      AdditionalInfoItem additionalInfoItem = new AdditionalInfoItem();
      additionalInfoItem.FromXElement(element3, deserializationInfo);
      this.AccountAdditionalInfo.Add(additionalInfoItem);
    }
  }
}
