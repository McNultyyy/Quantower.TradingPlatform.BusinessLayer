// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Options.NativePriceModel
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;

#nullable disable
namespace TradingPlatform.BusinessLayer.Options;

public class NativePriceModel : PriceModel
{
  public override PriceModels Type => PriceModels.Native;

  public override bool IsCalculationAllowed(Symbol symbol, OptionPriceType priceType) => true;

  public override double IV(
    Symbol option,
    OptionPriceType priceType,
    double Int_Rate,
    double shift)
  {
    return option.IV;
  }

  public override double Delta(Symbol option, double IV, double Int_Rate, double shift)
  {
    return option.Delta;
  }

  public override double Gamma(Symbol option, double IV, double int_Rate, double shift)
  {
    return option.Gamma;
  }

  public override double Vega(Symbol option, double IV, double int_Rate, double shift)
  {
    return option.Vega;
  }

  public override double Theta(Symbol option, double IV, double int_Rate, double shift)
  {
    return option.Theta;
  }

  public override double Rho(Symbol option, double IV, double int_Rate, double shift) => option.Rho;

  protected override double NormDist(double x) => double.NaN;

  public override double IV(
    DateTime ExpirationDate,
    double StrikePrice,
    OptionType OptionType,
    double optionPrice,
    double underlierPrice,
    OptionPriceType priceType,
    double Int_Rate,
    double shift)
  {
    return double.NaN;
  }

  public override double TheorPrice(Symbol option, double IV, double Int_Rate, double shift)
  {
    return double.NaN;
  }

  public override double TheorPrice(
    DateTime ExpirationDate,
    double StrikePrice,
    OptionType OptionType,
    double price,
    double IV,
    double Int_Rate,
    double shift)
  {
    return double.NaN;
  }

  public override double Delta(
    DateTime ExpirationDate,
    double StrikePrice,
    OptionType OptionType,
    double price,
    double IV,
    double Int_Rate,
    double shift)
  {
    return double.NaN;
  }

  public override double Vega(
    DateTime ExpirationDate,
    double StrikePrice,
    OptionType OptionType,
    double price,
    double IV,
    double Int_Rate,
    double shift)
  {
    return double.NaN;
  }

  public override double Gamma(
    DateTime ExpirationDate,
    double StrikePrice,
    OptionType OptionType,
    double price,
    double IV,
    double Int_Rate,
    double shift)
  {
    return double.NaN;
  }

  public override double Theta(
    DateTime ExpirationDate,
    double StrikePrice,
    OptionType OptionType,
    double price,
    double IV,
    double Int_Rate,
    double shift)
  {
    return double.NaN;
  }

  public override double Rho(
    DateTime ExpirationDate,
    double StrikePrice,
    OptionType OptionType,
    double price,
    double IV,
    double Int_Rate,
    double shift)
  {
    return double.NaN;
  }
}
