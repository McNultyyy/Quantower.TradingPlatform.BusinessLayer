// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.PasswordHolder
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using Platform.Utils;
using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[DataContract]
[Serializable]
public class PasswordHolder : IXElementSerialization, ICloneable
{
  public PasswordHolder(string Password = "", bool SavePassword = true, string recoverUrl = "")
  {
    this.Password = Password;
    this.SavePassword = SavePassword;
    this.RecoverUrl = recoverUrl;
  }

  public string Password { get; set; }

  [DataMember(Name = "Password")]
  private string EncryptedPassword
  {
    get => !this.SavePassword ? string.Empty : Encryptor.퓏(this.Password);
    [param: In] set => this.Password = Encryptor.퓬(value);
  }

  [DataMember(Name = "SavePassword")]
  public bool SavePassword { get; set; } = true;

  public string RecoverUrl { get; [param: In] internal set; }

  public object Clone()
  {
    return (object) new PasswordHolder(this.Password, this.SavePassword, this.RecoverUrl);
  }

  public XElement ToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓼());
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓴(), (object) this.EncryptedPassword));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픳(), (object) this.SavePassword));
    return xelement;
  }

  public void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    this.EncryptedPassword = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓴()).Value;
    this.SavePassword = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픳()).ToBool();
    if (string.IsNullOrEmpty(element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓴()).Value) || !string.IsNullOrEmpty(this.EncryptedPassword))
      return;
    this.FailedToRestorePassword = true;
  }

  public bool FailedToRestorePassword { get; [param: In] private set; }
}
