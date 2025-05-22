// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.OAuthResult
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using IdentityModel.Client;
using IdentityModel.OidcClient;
using IdentityModel.OidcClient.Results;
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
public class OAuthResult : IXElementSerialization, ICloneable
{
  public string AccessToken { get; [param: In] private set; }

  internal string RefreshToken { get; [param: In] private set; }

  internal string IdentityToken { get; [param: In] private set; }

  internal LoginResult RequestTokenResult
  {
    [param: In] set
    {
      this.AccessToken = value.AccessToken;
      this.RefreshToken = value.RefreshToken;
      this.IdentityToken = value.IdentityToken;
    }
  }

  internal RefreshTokenResult RequestRefreshResult
  {
    [param: In] set
    {
      this.AccessToken = value.AccessToken;
      this.RefreshToken = value.RefreshToken;
      this.IdentityToken = value.IdentityToken;
    }
  }

  internal TokenResponse TokenResponce
  {
    [param: In] set
    {
      this.AccessToken = value.AccessToken;
      this.RefreshToken = value.RefreshToken;
      this.IdentityToken = value.IdentityToken;
    }
  }

  public bool UseSavedTokens { get; set; }

  [DataMember(Name = "EncryptedRefreshToken")]
  private string EncryptedRefreshToken
  {
    get => !this.UseSavedTokens ? string.Empty : Encryptor.퓏(this.RefreshToken);
    [param: In] set => this.RefreshToken = Encryptor.퓬(value);
  }

  public OAuthResult()
  {
    this.AccessToken = string.Empty;
    this.UseSavedTokens = true;
  }

  public OAuthResult(string accessToken)
  {
    this.AccessToken = accessToken;
    this.UseSavedTokens = true;
  }

  internal OAuthResult([In] string obj0, [In] string obj1)
  {
    this.AccessToken = obj0;
    this.RefreshToken = obj1;
    this.UseSavedTokens = true;
  }

  public XElement ToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픚());
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓵(), (object) this.EncryptedRefreshToken));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞플(), (object) this.UseSavedTokens));
    return xelement;
  }

  public void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    this.EncryptedRefreshToken = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓵()).Value;
    this.UseSavedTokens = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞플()).ToBool();
  }

  public object Clone()
  {
    return (object) new OAuthResult()
    {
      UseSavedTokens = this.UseSavedTokens,
      AccessToken = this.AccessToken,
      RefreshToken = this.RefreshToken,
      IdentityToken = this.IdentityToken
    };
  }
}
