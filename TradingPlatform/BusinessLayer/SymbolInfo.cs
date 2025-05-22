// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SymbolInfo
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[DataContract]
[Serializable]
public class SymbolInfo : BusinessObjectInfo, IEquatable<SymbolInfo>
{
  [DataMember(Name = "exchangeId")]
  public string ExchangeId { get; [param: In] internal set; }

  [DataMember(Name = "symbolType")]
  public SymbolType SymbolType { get; [param: In] internal set; }

  [DataMember(Name = "futuresContractType")]
  public TradingPlatform.BusinessLayer.FutureContractType? FutureContractType { get; [param: In] internal set; }

  [DataMember(Name = "underlierId")]
  public string UnderlierId { get; [param: In] internal set; }

  [DataMember(Name = "root")]
  public string Root { get; [param: In] internal set; }

  [DataMember(Name = "expirationTime")]
  public DateTime ExpirationDate { get; [param: In] internal set; }

  public static SymbolInfo Empty
  {
    get
    {
      SymbolInfo empty = new SymbolInfo();
      empty.Id = string.Empty;
      empty.ConnectionId = string.Empty;
      empty.Name = string.Empty;
      empty.ExchangeId = string.Empty;
      empty.SymbolType = SymbolType.Unknown;
      empty.FutureContractType = new TradingPlatform.BusinessLayer.FutureContractType?();
      empty.UnderlierId = string.Empty;
      empty.Root = string.Empty;
      empty.ExpirationDate = new DateTime();
      return empty;
    }
  }

  public override XElement ToXElement()
  {
    XElement xelement = base.ToXElement();
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓮(), (object) this.ExchangeId));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓘(), (object) this.SymbolType.ToString()));
    if (this.FutureContractType.HasValue)
      xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픓(), (object) this.FutureContractType.ToString()));
    if (!string.IsNullOrEmpty(this.UnderlierId))
      xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픬(), (object) this.UnderlierId));
    if (!string.IsNullOrEmpty(this.Root))
      xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픩(), (object) this.Root));
    if (this.ExpirationDate != new DateTime())
      xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픛(), (object) this.ExpirationDate));
    return xelement;
  }

  public override void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    base.FromXElement(element, deserializationInfo);
    XElement xelement1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓮());
    if (xelement1 != null)
      this.ExchangeId = xelement1.Value;
    XElement xelement2 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픓());
    TradingPlatform.BusinessLayer.FutureContractType result1;
    if (xelement2 != null && Enum.TryParse<TradingPlatform.BusinessLayer.FutureContractType>(xelement2.Value, out result1))
      this.FutureContractType = new TradingPlatform.BusinessLayer.FutureContractType?(result1);
    XElement xelement3 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓘());
    SymbolType result2;
    if (xelement3 != null && Enum.TryParse<SymbolType>(xelement3.Value, out result2))
      this.SymbolType = result2;
    XElement xelement4 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픬());
    if (xelement4 != null)
      this.UnderlierId = xelement4.Value;
    XElement xelement5 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픩());
    if (xelement5 != null)
      this.Root = xelement5.Value;
    XElement element1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픛());
    if (element1 == null)
      return;
    this.ExpirationDate = element1.ToDateTime();
  }

  public bool Equals(SymbolInfo other)
  {
    if ((object) other == null)
      return false;
    if ((object) this == (object) other)
      return true;
    if (this.Equals((BusinessObjectInfo) other) && this.ExchangeId == other.ExchangeId && this.SymbolType == other.SymbolType)
    {
      TradingPlatform.BusinessLayer.FutureContractType? futureContractType1 = this.FutureContractType;
      TradingPlatform.BusinessLayer.FutureContractType? futureContractType2 = other.FutureContractType;
      if (futureContractType1.GetValueOrDefault() == futureContractType2.GetValueOrDefault() & futureContractType1.HasValue == futureContractType2.HasValue && this.UnderlierId == other.UnderlierId && this.Root == other.Root)
        return this.ExpirationDate.Equals(other.ExpirationDate);
    }
    return false;
  }

  public override bool Equals(object obj)
  {
    if (obj == null)
      return false;
    if ((object) this == obj)
      return true;
    return !(obj.GetType() != this.GetType()) && this.Equals((SymbolInfo) obj);
  }

  public override int GetHashCode()
  {
    return HashCode.Combine<int, string, int, TradingPlatform.BusinessLayer.FutureContractType?, string, string, DateTime>(base.GetHashCode(), this.ExchangeId, (int) this.SymbolType, this.FutureContractType, this.UnderlierId, this.Root, this.ExpirationDate);
  }

  public static bool operator ==(SymbolInfo left, SymbolInfo right)
  {
    return object.Equals((object) left, (object) right);
  }

  public static bool operator !=(SymbolInfo left, SymbolInfo right)
  {
    return !object.Equals((object) left, (object) right);
  }
}
