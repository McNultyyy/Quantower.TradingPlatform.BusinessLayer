// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.IBrandingInformation
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.IO;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public interface IBrandingInformation
{
  string ApplicationName { get; }

  string ApplicationID { get; }

  string CopyrightDetails { get; }

  string PrivacePolicyUrl { get; }

  string TermsOfUseUrl { get; }

  string OfficialWebSite { get; }

  string LiveChatUrl { get; }

  string UpdateUrl { get; }

  string PricingPageUrl { get; }

  string AccountDashboardUrl { get; }

  string WelcomeScreenText { get; }

  string HelpCustomURL { get; }

  string GitCustomURL { get; }

  string ReleaseNotesURL { get; }

  BrandingInformationHelpLink[] HelpLinks { get; }

  bool IsGrayLabel { get; }

  /// <summary>Get all available custom resources</summary>
  string[] GetResourceNames();

  /// <summary>Get custom resource stream by name</summary>
  Stream GetResource(string resourceName);

  /// <summary>
  /// Check whether specified items was hidden by branding specification
  /// </summary>
  /// <returns></returns>
  bool IsItemHidden(string itemType, string itemName);
}
