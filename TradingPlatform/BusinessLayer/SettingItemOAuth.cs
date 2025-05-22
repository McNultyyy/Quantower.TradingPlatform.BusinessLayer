// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemOAuth
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using IdentityModel.Client;
using IdentityModel.OidcClient;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[DataContract]
public class SettingItemOAuth : SettingItem
{
  public override SettingItemType Type => SettingItemType.OAuth;

  [DataMember(Name = "Value")]
  private OAuthResult OAuthResultHolder
  {
    get => (OAuthResult) this.Value;
    [param: In] set => this.Value = (object) value;
  }

  public OidcClientOptions OidcOptions { get; }

  internal UpdateAuthorityUrlDelegate UpdateIdentityAuthorityUrl { get; }

  internal bool AllowOpenNewWindow { get; }

  internal Parameters BackChannelExtraParameters { get; }

  public SettingItemOAuth()
  {
  }

  public SettingItemOAuth(
    string name,
    OAuthResult passwordHolder,
    OidcClientOptions oidcClientOptions,
    int sortIndex = 0,
    UpdateAuthorityUrlDelegate updateIdentityAuthorityUrl = null,
    bool allowOpenNewWindow = false,
    Parameters backChannelExtraParameters = null)
    : base(name, (object) passwordHolder, sortIndex)
  {
    this.OidcOptions = oidcClientOptions;
    this.UpdateIdentityAuthorityUrl = updateIdentityAuthorityUrl;
    this.AllowOpenNewWindow = allowOpenNewWindow;
    this.BackChannelExtraParameters = backChannelExtraParameters;
  }

  protected SettingItemOAuth(SettingItemOAuth settingItem)
    : base((SettingItem) settingItem)
  {
    this.OidcOptions = settingItem.OidcOptions;
    this.UpdateIdentityAuthorityUrl = settingItem.UpdateIdentityAuthorityUrl;
    this.AllowOpenNewWindow = settingItem.AllowOpenNewWindow;
    this.BackChannelExtraParameters = settingItem.BackChannelExtraParameters;
  }

  public override SettingItem GetCopy() => (SettingItem) new SettingItemOAuth(this);

  protected override bool IsValueTypeValid(object value) => value is OAuthResult;

  protected override void ValueFromXElement(
    XElement element,
    DeserializationInfo deserializationInfo)
  {
    OAuthResult oauthResult = new OAuthResult();
    XElement element1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픚());
    if (element1 == null)
      return;
    oauthResult.FromXElement(element1, deserializationInfo);
    this.OAuthResultHolder = oauthResult;
  }
}
