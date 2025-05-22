// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.BusinessObjectInfo
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using Platform.Utils;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[DataContract]
[Serializable]
public class BusinessObjectInfo : IXElementSerialization, IEquatable<BusinessObjectInfo>
{
  [DataMember(Name = "Id")]
  public string Id { get; [param: In] internal set; }

  [DataMember(Name = "ConnectionId")]
  public string ConnectionId { get; [param: In] internal set; }

  [DataMember(Name = "Name")]
  public string Name { get; [param: In] internal set; }

  protected virtual bool NeedToEncryptInfo => false;

  public static BusinessObjectInfo Empty
  {
    get
    {
      return new BusinessObjectInfo()
      {
        Id = string.Empty,
        ConnectionId = string.Empty,
        Name = string.Empty
      };
    }
  }

  public virtual XElement ToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픍());
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓶(), this.NeedToEncryptInfo ? (object) Encryptor.퓏(this.Id) : (object) this.Id));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픐(), (object) this.ConnectionId));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픜(), this.NeedToEncryptInfo ? (object) Encryptor.퓏(this.Name) : (object) this.Name));
    return xelement;
  }

  public virtual void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    string str1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓶()).Value;
    if (this.NeedToEncryptInfo)
    {
      string str2 = Encryptor.퓬(str1);
      if (str2 != null)
      {
        this.Id = str2;
        goto label_4;
      }
    }
    this.Id = str1;
label_4:
    this.ConnectionId = ConnectionsManager.픾픦.퓏(element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픐()).Value);
    string str3 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픜()).Value;
    if (this.NeedToEncryptInfo)
    {
      string str4 = Encryptor.퓬(str3);
      if (str4 != null)
      {
        this.Name = str4;
        return;
      }
    }
    this.Name = str3;
  }

  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 3);
    interpolatedStringHandler.AppendFormatted(this.ConnectionId);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲핃());
    interpolatedStringHandler.AppendFormatted(this.Id);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲핃());
    interpolatedStringHandler.AppendFormatted(this.Name);
    return interpolatedStringHandler.ToStringAndClear();
  }

  public bool Equals(BusinessObjectInfo other)
  {
    if ((object) other == null)
      return false;
    if ((object) this == (object) other)
      return true;
    return this.Id == other.Id && this.ConnectionId == other.ConnectionId && this.Name == other.Name;
  }

  public override bool Equals(object obj)
  {
    if (obj == null)
      return false;
    if ((object) this == obj)
      return true;
    return !(obj.GetType() != this.GetType()) && this.Equals((BusinessObjectInfo) obj);
  }

  public override int GetHashCode()
  {
    return HashCode.Combine<string, string, string>(this.Id, this.ConnectionId, this.Name);
  }

  public static bool operator ==(BusinessObjectInfo left, BusinessObjectInfo right)
  {
    return object.Equals((object) left, (object) right);
  }

  public static bool operator !=(BusinessObjectInfo left, BusinessObjectInfo right)
  {
    return !object.Equals((object) left, (object) right);
  }
}
