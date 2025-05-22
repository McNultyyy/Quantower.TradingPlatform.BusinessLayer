// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.AccountExtensions
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>The account extensions.</summary>
public static class AccountExtensions
{
  /// <summary>
  /// Returns a custom name if available otherwise, returns the name.
  /// </summary>
  /// <param name="account">The account.</param>
  public static string GetCurrentName(this Account account)
  {
    string property = Core.Instance.CustomAccountPropertiesProvider.GetProperty(account, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픡()) as string;
    return !string.IsNullOrEmpty(property) ? property : account.Name;
  }

  /// <summary>
  /// Returns information about whether the account supports trading operations
  /// </summary>
  /// <param name="account">The account.</param>
  public static bool IsLocked(this Account account)
  {
    return (Core.Instance.CustomAccountPropertiesProvider.GetProperty(account, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픏()) as bool?).GetValueOrDefault();
  }
}
