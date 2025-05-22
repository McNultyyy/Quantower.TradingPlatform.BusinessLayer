// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.OidcClientOptionsExtensions
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using IdentityModel.OidcClient;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public static class OidcClientOptionsExtensions
{
  public static OidcClientOptions GetCopy(this OidcClientOptions oidc)
  {
    OidcClientOptions copy = new OidcClientOptions();
    copy.Authority = oidc.Authority;
    copy.ClientId = oidc.ClientId;
    copy.ClientSecret = oidc.ClientSecret;
    copy.RedirectUri = oidc.RedirectUri;
    copy.PostLogoutRedirectUri = oidc.PostLogoutRedirectUri;
    copy.Scope = oidc.Scope;
    copy.ClockSkew = oidc.ClockSkew;
    copy.LoadProfile = oidc.LoadProfile;
    ProviderInformation providerInformation = oidc.ProviderInformation;
    copy.ProviderInformation = providerInformation != null ? providerInformation.GetCopy() : (ProviderInformation) null;
    return copy;
  }

  public static ProviderInformation GetCopy(this ProviderInformation providerInformation)
  {
    return new ProviderInformation()
    {
      IssuerName = providerInformation.IssuerName,
      AuthorizeEndpoint = providerInformation.AuthorizeEndpoint,
      TokenEndpoint = providerInformation.TokenEndpoint,
      EndSessionEndpoint = providerInformation.EndSessionEndpoint,
      KeySet = providerInformation.KeySet
    };
  }
}
