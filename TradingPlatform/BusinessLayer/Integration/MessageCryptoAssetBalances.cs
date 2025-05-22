// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.MessageCryptoAssetBalances
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using ProtoBuf;
using System;
using System.Runtime.Serialization;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

[DataContract(Name = "CryptoAssetBalances", Namespace = "TradingPlatform")]
[ProtoContract]
public sealed class MessageCryptoAssetBalances : 
  Message,
  IXElementSerialization,
  IEquatable<MessageCryptoAssetBalances>
{
  public override MessageType Type => MessageType.CryptoAssetBalances;

  [DataMember(Name = "AccountId")]
  [ProtoMember(1)]
  public string AccountId { get; set; }

  /// <summary>Asset id bearer</summary>
  [DataMember(Name = "AssetId")]
  [ProtoMember(2)]
  public string AssetId { get; set; }

  [DataMember(Name = "TotalBalance")]
  [ProtoMember(3)]
  public double TotalBalance { get; set; }

  [DataMember(Name = "AvailableBalance")]
  [ProtoMember(4)]
  public double AvailableBalance { get; set; }

  [DataMember(Name = "ReservedBalance")]
  [ProtoMember(5)]
  public double ReservedBalance { get; set; }

  [DataMember(Name = "TotalInUSD")]
  [ProtoMember(6)]
  public double TotalInUSD { get; set; }

  [DataMember(Name = "TotalInBTC")]
  [ProtoMember(7)]
  public double TotalInBTC { get; set; }

  [DataMember(Name = "Debt")]
  [ProtoMember(8)]
  public double Debt { get; set; }

  [DataMember(Name = "Equity")]
  [ProtoMember(9)]
  public double Equity { get; set; }

  [DataMember(Name = "EquityInBTC")]
  [ProtoMember(10)]
  public double EquityInBTC { get; set; }

  public GetAvailableBalanceHandler AvailableBalanceHandler { get; set; }

  public XElement ToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픫());
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓼(), (object) this.AccountId));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픯(), (object) this.AssetId));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓴(), (object) this.TotalBalance));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픳(), (object) this.AvailableBalance));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픙(), (object) this.ReservedBalance));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓭(), (object) this.TotalInUSD));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓣(), (object) this.TotalInBTC));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픦(), (object) this.Debt));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픍(), (object) this.Equity));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픆(), (object) this.EquityInBTC));
    return xelement;
  }

  public void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    XElement xelement1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓼());
    if (xelement1 != null)
      this.AccountId = xelement1.Value;
    XElement xelement2 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픯());
    if (xelement2 != null)
      this.AssetId = xelement2.Value;
    XElement element1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓴());
    if (element1 != null)
      this.TotalBalance = element1.ToDouble();
    XElement element2 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픳());
    if (element2 != null)
      this.AvailableBalance = element2.ToDouble();
    XElement element3 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픙());
    if (element3 != null)
      this.ReservedBalance = element3.ToDouble();
    XElement element4 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓭());
    if (element4 != null)
      this.TotalInUSD = element4.ToDouble();
    XElement element5 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓣());
    if (element5 != null)
      this.TotalInBTC = element5.ToDouble();
    XElement element6 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픦());
    if (element6 != null)
      this.Debt = element6.ToDouble();
    XElement element7 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픍());
    if (element7 != null)
      this.Equity = element7.ToDouble();
    XElement element8 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픆());
    if (element8 == null)
      return;
    this.EquityInBTC = element8.ToDouble();
  }

  public bool Equals(MessageCryptoAssetBalances other)
  {
    if (other == null)
      return false;
    if (this == other)
      return true;
    if (this.AccountId == other.AccountId && this.AssetId == other.AssetId)
    {
      double num = this.TotalBalance;
      if (num.Equals(other.TotalBalance))
      {
        num = this.AvailableBalance;
        if (num.Equals(other.AvailableBalance))
        {
          num = this.ReservedBalance;
          if (num.Equals(other.ReservedBalance))
          {
            num = this.TotalInUSD;
            if (num.Equals(other.TotalInUSD))
            {
              num = this.TotalInBTC;
              if (num.Equals(other.TotalInBTC))
              {
                num = this.Debt;
                if (num.Equals(other.Debt))
                {
                  num = this.Equity;
                  if (num.Equals(other.Equity))
                  {
                    num = this.EquityInBTC;
                    if (num.Equals(other.EquityInBTC))
                      return object.Equals((object) this.AvailableBalanceHandler, (object) other.AvailableBalanceHandler);
                  }
                }
              }
            }
          }
        }
      }
    }
    return false;
  }

  public override bool Equals(object obj)
  {
    if (this == obj)
      return true;
    return obj is MessageCryptoAssetBalances other && this.Equals(other);
  }

  public override int GetHashCode()
  {
    HashCode hashCode = new HashCode();
    hashCode.Add<string>(this.AccountId);
    hashCode.Add<string>(this.AssetId);
    hashCode.Add<double>(this.TotalBalance);
    hashCode.Add<double>(this.AvailableBalance);
    hashCode.Add<double>(this.ReservedBalance);
    hashCode.Add<double>(this.TotalInUSD);
    hashCode.Add<double>(this.TotalInBTC);
    hashCode.Add<double>(this.Debt);
    hashCode.Add<double>(this.Equity);
    hashCode.Add<double>(this.EquityInBTC);
    hashCode.Add<GetAvailableBalanceHandler>(this.AvailableBalanceHandler);
    return hashCode.ToHashCode();
  }
}
