// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Options.PriceModel
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;

#nullable disable
namespace TradingPlatform.BusinessLayer.Options;

public abstract class PriceModel
{
  public abstract PriceModels Type { get; }

  public static PriceModel CreateModel(PriceModels type)
  {
    PriceModel model;
    switch (type)
    {
      case PriceModels.BlackScholes:
        model = (PriceModel) new BlackScholesPriceModel();
        break;
      case PriceModels.Native:
        model = (PriceModel) new NativePriceModel();
        break;
      default:
        model = (PriceModel) null;
        break;
    }
    return model;
  }

  public virtual bool IsCalculationAllowed(Symbol symbol, OptionPriceType priceType)
  {
    if (symbol?.Underlier == null)
      return false;
    bool flag;
    switch (priceType)
    {
      case OptionPriceType.Ask:
        flag = !symbol.Ask.IsNanOrDefault();
        break;
      case OptionPriceType.Bid:
        flag = !symbol.Bid.IsNanOrDefault();
        break;
      case OptionPriceType.Last:
        flag = !symbol.Last.IsNanOrDefault();
        break;
      default:
        flag = true;
        break;
    }
    return flag;
  }

  protected abstract double NormDist(double x);

  public abstract double IV(
    Symbol option,
    OptionPriceType priceType,
    double Int_Rate,
    double shift);

  public abstract double IV(
    DateTime ExpirationDate,
    double StrikePrice,
    OptionType OptionType,
    double optionPrice,
    double underlierPrice,
    OptionPriceType priceType,
    double Int_Rate,
    double shift);

  public abstract double TheorPrice(Symbol option, double IV, double Int_Rate, double shift);

  public abstract double TheorPrice(
    DateTime ExpirationDate,
    double StrikePrice,
    OptionType OptionType,
    double price,
    double IV,
    double Int_Rate,
    double shift);

  public abstract double Delta(Symbol option, double IV, double Int_Rate, double shift);

  public abstract double Delta(
    DateTime ExpirationDate,
    double StrikePrice,
    OptionType OptionType,
    double price,
    double IV,
    double Int_Rate,
    double shift);

  public abstract double Vega(Symbol option, double IV, double int_Rate, double shift);

  public abstract double Vega(
    DateTime ExpirationDate,
    double StrikePrice,
    OptionType OptionType,
    double price,
    double IV,
    double Int_Rate,
    double shift);

  public abstract double Gamma(Symbol option, double IV, double int_Rate, double shift);

  public abstract double Gamma(
    DateTime ExpirationDate,
    double StrikePrice,
    OptionType OptionType,
    double price,
    double IV,
    double Int_Rate,
    double shift);

  public abstract double Theta(Symbol option, double IV, double int_Rate, double shift);

  public abstract double Theta(
    DateTime ExpirationDate,
    double StrikePrice,
    OptionType OptionType,
    double price,
    double IV,
    double Int_Rate,
    double shift);

  public abstract double Rho(Symbol option, double IV, double int_Rate, double shift);

  public abstract double Rho(
    DateTime ExpirationDate,
    double StrikePrice,
    OptionType OptionType,
    double price,
    double IV,
    double Int_Rate,
    double shift);
}
