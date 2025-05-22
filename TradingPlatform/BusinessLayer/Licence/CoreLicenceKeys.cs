// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Licence.CoreLicenceKeys
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;

#nullable disable
namespace TradingPlatform.BusinessLayer.Licence;

/// <summary>Constants for licence keys</summary>
public static class CoreLicenceKeys
{
  public const string BASIC_PACKAGE = "BASIC_PACKAGE";
  public const string PREMIUM_PACKAGE = "PREMIUM_PACKAGE";
  public const string PREMIUM_PLUS_PACKAGE = "PREMIUM_PLUS_PACKAGE";
  public const string ALL_IN_ONE_PACKAGE = "ALLINONE_PACKAGE";
  public const string CRYPTO_PACKAGE = "CRYPTO_PACKAGE";
  public const string CRYPTO_INDIA_PACKAGE = "CRYPTO_INDIA_PACKAGE";
  public const string VOLUMEANALYSIS_PACKAGE = "VOLUMEANALYSIS_PACKAGE";
  public const string POWERTRADES_PACKAGE = "POWERTRADES_PACKAGE";
  public const string DOMSURFACE_PACKAGE = "DOMSURFACE_PACKAGE";
  public const string ORDERFLOW_PACKAGE = "ORDERFLOW_PACKAGE";
  public const string TPOCHART_PACKAGE = "TPOCHART_PACKAGE";
  public const string MULTI_ASSET_PACKAGE = "MULTI_ASSET_PACKAGE";
  public const string OPTIONS_PACKAGE = "OPTIONS_PACKAGE";
  public const string CUSTOMER = "CUSTOMER";
  public const string PROP_LICENSE = "PROP_LICENSE";
  public const string MIRROR_TRADING = "MIRROR_TRADING";
  public const string TRADING_SIGNAL_PACKAGE = "TRADING_SIGNAL_PACKAGE";
  public const string EXTENDED_HISTORУ_PACKAGE = "EXTENDED_HISTORУ_PACKAGE ";
  public const string QUANTOWER_LITE = "QUANTOWER_LITE";
  public const string QUANTOWER_ADVANCED_EQUITY = "QUANTOWER_ADVANCED_EQUITY";
  public const string QUANTOWER_ADVANCED_INDICES = "QUANTOWER_ADVANCED_INDICES";
  public const string QUANTOWER_ADVANCED_COMMODITY = "QUANTOWER_ADVANCED_COMMODITY";
  public const string QUANTOWER_ADVANCED_EQUITY_COMMODITIES = "QUANTOWER_ADVANCED_EQUITY_COMMODITIES";
  public const string TRUEDATA_NSECD_PACKAGE = "TRUEDATA_NSECD_PACKAGE";
  public const string TRUEDATA_NSECM_PACKAGE = "TRUEDATA_NSECM_PACKAGE";
  public const string TRUEDATA_NSEFO_PACKAGE = "TRUEDATA_NSEFO_PACKAGE";
  public const string TRUEDATA_MCX_PACKAGE = "TRUEDATA_MCX_PACKAGE";
  public const string TRUEDATA_VELOCITY = "TRUEDATA_VELOCITY";
  public const string CEDROMARKETDATA_PACKAGE = "CEDROMARKETDATA_PACKAGE";

  public static string GetRuleDescription(string ruleId)
  {
    if (ruleId != null)
    {
      switch (ruleId.Length)
      {
        case 8:
          if (ruleId == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픻())
            return \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓼();
          goto label_56;
        case 12:
          if (ruleId == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓤())
            return \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓴();
          goto label_56;
        case 13:
          if (ruleId == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓽())
            return \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픟();
          goto label_56;
        case 14:
          switch (ruleId[0])
          {
            case 'C':
              if (ruleId == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픕())
                break;
              goto label_56;
            case 'M':
              if (ruleId == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픘())
                return \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픳();
              goto label_56;
            case 'Q':
              if (ruleId == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픨())
                return \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓭();
              goto label_56;
            default:
              goto label_56;
          }
          break;
        case 15:
          switch (ruleId[0])
          {
            case 'O':
              if (ruleId == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픗())
                return \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픥();
              goto label_56;
            case 'P':
              if (ruleId == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓓())
                return \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓢();
              goto label_56;
            default:
              goto label_56;
          }
        case 16 /*0x10*/:
          switch (ruleId[0])
          {
            case 'A':
              if (ruleId == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓠())
                return \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픯();
              goto label_56;
            case 'T':
              if (ruleId == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓰())
                return \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲플();
              goto label_56;
            default:
              goto label_56;
          }
        case 17:
          switch (ruleId[0])
          {
            case 'O':
              if (ruleId == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓛())
                return \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓵();
              goto label_56;
            case 'T':
              if (ruleId == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픝())
                return \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픦();
              goto label_56;
            default:
              goto label_56;
          }
        case 18:
          if (ruleId == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓹())
            return \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픚();
          goto label_56;
        case 19:
          switch (ruleId[0])
          {
            case 'M':
              if (ruleId == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓮())
                return \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픰();
              goto label_56;
            case 'P':
              if (ruleId == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓡())
                return \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓐();
              goto label_56;
            default:
              goto label_56;
          }
        case 20:
          switch (ruleId[0])
          {
            case 'C':
              if (ruleId == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓪())
                break;
              goto label_56;
            case 'P':
              if (ruleId == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픪())
                return \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픫();
              goto label_56;
            default:
              goto label_56;
          }
          break;
        case 22:
          switch (ruleId[0])
          {
            case 'T':
              if (ruleId == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픧())
                return \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픙();
              goto label_56;
            case 'V':
              if (ruleId == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픠())
                return \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓾();
              goto label_56;
            default:
              goto label_56;
          }
        case 23:
          if (ruleId == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓿())
            return \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픠();
          goto label_56;
        case 25:
          if (ruleId == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픮())
            return \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓣();
          goto label_56;
        case 26:
          if (ruleId == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픉())
            return \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픍();
          goto label_56;
        case 28:
          if (ruleId == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픒())
            return \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픆();
          goto label_56;
        case 37:
          if (ruleId == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓷())
            return \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픅();
          goto label_56;
        default:
          goto label_56;
      }
      return \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓧();
    }
label_56:
    return ruleId;
  }
}
