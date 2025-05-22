// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Options.BlackScholesPriceModel
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;

#nullable disable
namespace TradingPlatform.BusinessLayer.Options;

public sealed class BlackScholesPriceModel : PriceModel
{
  public const double START_IV = 1E-05;

  public override PriceModels Type => PriceModels.BlackScholes;

  protected override double NormDist(double x)
  {
    double num1 = 0.049867347;
    double num2 = 0.0211410061;
    double num3 = 0.0032776263;
    double num4 = 3.80036E-05;
    double num5 = 4.88906E-05;
    double num6 = 5.383E-06;
    double num7 = Math.Abs(x);
    double num8 = 1.0 + num7 * (num1 + num7 * (num2 + num7 * (num3 + num7 * (num4 + num7 * (num5 + num7 * num6)))));
    double num9 = num8 * num8;
    double num10 = num9 * num9;
    double num11 = num10 * num10;
    double num12 = 1.0 / (2.0 * (num11 * num11));
    if (x >= 0.0)
      num12 = 1.0 - num12;
    return num12;
  }

  public override double Delta(Symbol option, double IV, double Int_Rate, double shift)
  {
    if (option == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픜());
    if (option.Underlier == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓑());
    return this.Delta(option.ExpirationDate, option.StrikePrice, option.OptionType, option.Underlier.Last, IV, Int_Rate, shift);
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
    double d = ((double) OptionMath.CalculateDaysToExpire(ExpirationDate) - shift) / 365.0;
    if (d <= 0.0)
      d = (double) OptionMath.CalculateDaysToExpire(ExpirationDate) / 365.0;
    double x = (Math.Log(price / StrikePrice) + (Int_Rate + IV * IV / 2.0) * d) / (IV * Math.Sqrt(d));
    Math.Sqrt(d);
    return OptionType == OptionType.Call ? this.NormDist(x) : this.NormDist(x) - 1.0;
  }

  public override double Gamma(Symbol option, double IV, double int_Rate, double shift)
  {
    if (option == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픜());
    if (option.Underlier == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓑());
    return this.Gamma(option.ExpirationDate, option.StrikePrice, option.OptionType, option.Underlier.Last, IV, int_Rate, shift);
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
    double num1 = price;
    double d = ((double) OptionMath.CalculateDaysToExpire(ExpirationDate) - shift) / 365.0;
    if (d <= 0.0)
      d = (double) OptionMath.CalculateDaysToExpire(ExpirationDate) / 365.0;
    double num2 = (Math.Log(num1 / StrikePrice) + (Int_Rate + IV * IV / 2.0) * d) / (IV * Math.Sqrt(d));
    Math.Sqrt(d);
    return Math.Exp(-1.0 * num2 * num2 / 2.0) / Math.Sqrt(2.0 * Math.PI) / (num1 * IV * Math.Sqrt(d));
  }

  public override double TheorPrice(Symbol option, double IV, double Int_Rate, double shift)
  {
    if (option == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픜());
    if (option.Underlier == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓑());
    return this.TheorPrice(option.ExpirationDate, option.StrikePrice, option.OptionType, option.Underlier.Last, IV, Int_Rate, shift);
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
    double num = price;
    double d = ((double) OptionMath.CalculateDaysToExpire(ExpirationDate) - shift) / 365.0;
    if (d <= 0.0)
      d = (double) OptionMath.CalculateDaysToExpire(ExpirationDate) / 365.0;
    double x1 = (Math.Log(num / StrikePrice) + (Int_Rate + IV * IV / 2.0) * d) / (IV * Math.Sqrt(d));
    double x2 = x1 - IV * Math.Sqrt(d);
    return OptionType == OptionType.Call ? num * this.NormDist(x1) - StrikePrice * Math.Exp(-1.0 * (Int_Rate * d)) * this.NormDist(x2) : StrikePrice * Math.Exp(-1.0 * (Int_Rate * d)) * this.NormDist(-x2) - num * this.NormDist(-x1);
  }

  public override double IV(
    Symbol option,
    OptionPriceType priceType,
    double Int_Rate,
    double shift)
  {
    if (option == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픜());
    if (option.Underlier == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓑());
    return this.IV(option.ExpirationDate, option.StrikePrice, option.OptionType, OptionMath.GetOptionLastPrice(option, priceType), option.Underlier.Last, priceType, Int_Rate, shift);
  }

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
    double num1 = optionPrice;
    double num2 = underlierPrice;
    if (double.IsNaN(optionPrice))
      return double.NaN;
    double d = ((double) OptionMath.CalculateDaysToExpire(ExpirationDate) - shift) / 365.0;
    if (d <= 0.0)
      d = (double) OptionMath.CalculateDaysToExpire(ExpirationDate) / 365.0;
    double num3 = 0.0;
    double num4 = 0.0;
    double num5 = 1E-05;
    if (num1 == 0.0 || num2 == 0.0 || StrikePrice == 0.0 || d <= 0.0 || num2 <= num1)
      return 0.0;
    double num6 = 0.1;
    if (OptionType == OptionType.Call)
    {
      while (num3 <= num1)
      {
        while (true)
        {
          double x1 = (Math.Log(num2 / StrikePrice) + (Int_Rate + num5 * num5 / 2.0) * d) / (num5 * Math.Sqrt(d));
          double x2 = x1 - num5 * Math.Sqrt(d);
          num3 = num2 * this.NormDist(x1) - StrikePrice * Math.Exp(-1.0 * (Int_Rate * d)) * this.NormDist(x2);
          if (num3 > num1 && num6 > 1E-05 && num5 > 0.0001)
          {
            double num7 = num5 - num6;
            num6 *= 0.1;
            num5 = num7 + num6;
          }
          else
            break;
        }
        if (num3 > num1)
          return num5;
        num5 += num6;
        if (num5 > 10000.0)
          return double.NaN;
      }
      return num5;
    }
    while (num4 <= num1)
    {
      while (true)
      {
        double num8 = (Math.Log(num2 / StrikePrice) + (Int_Rate + num5 * num5 / 2.0) * d) / (num5 * Math.Sqrt(d));
        double num9 = num8 - num5 * Math.Sqrt(d);
        num4 = StrikePrice * Math.Exp(-1.0 * (Int_Rate * d)) * this.NormDist(-num9) - num2 * this.NormDist(-num8);
        if (num4 > num1 && num6 > 1E-05 && num5 > 0.0001)
        {
          double num10 = num5 - num6;
          num6 *= 0.1;
          num5 = num10 + num6;
        }
        else
          break;
      }
      if (num4 > num1)
        return num5;
      num5 += num6;
      if (num5 > 10000.0)
        return double.NaN;
    }
    return num5;
  }

  public override double Theta(Symbol option, double IV, double int_Rate, double shift)
  {
    if (option == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픜());
    if (option.Underlier == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓑());
    return this.Theta(option.ExpirationDate, option.StrikePrice, option.OptionType, option.Underlier.Last, IV, int_Rate, shift);
  }

  public override double Theta(
    DateTime ExpirationDate,
    double StrikePrice,
    OptionType OptionType,
    double price,
    double IV,
    double int_Rate,
    double shift)
  {
    double num1 = price;
    double d = ((double) OptionMath.CalculateDaysToExpire(ExpirationDate) - shift) / 365.0;
    if (d <= 0.0)
      d = (double) OptionMath.CalculateDaysToExpire(ExpirationDate) / 365.0;
    double num2 = (Math.Log(num1 / StrikePrice) + (int_Rate + IV * IV / 2.0) * d) / (IV * Math.Sqrt(d));
    double x = num2 - IV * Math.Sqrt(d);
    return OptionType == OptionType.Call ? (-1.0 * (num1 * (Math.Exp(-1.0 * num2 * num2 / 2.0) / Math.Sqrt(2.0 * Math.PI)) * IV) / (2.0 * Math.Sqrt(d)) - int_Rate * StrikePrice * Math.Exp(-1.0 * (int_Rate * d)) * this.NormDist(x)) / 365.0 : (-1.0 * (num1 * (Math.Exp(-1.0 * num2 * num2 / 2.0) / Math.Sqrt(2.0 * Math.PI)) * IV) / (2.0 * Math.Sqrt(d)) + int_Rate * StrikePrice * Math.Exp(-1.0 * (int_Rate * d)) * this.NormDist(-x)) / 365.0;
  }

  public override double Vega(Symbol option, double IV, double int_Rate, double shift)
  {
    if (option == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픜());
    if (option.Underlier == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓑());
    return this.Vega(option.ExpirationDate, option.StrikePrice, option.OptionType, option.Underlier.Last, IV, int_Rate, shift);
  }

  public override double Vega(
    DateTime ExpirationDate,
    double StrikePrice,
    OptionType OptionType,
    double price,
    double IV,
    double int_Rate,
    double shift)
  {
    double d = ((double) OptionMath.CalculateDaysToExpire(ExpirationDate) - shift) / 365.0;
    if (d <= 0.0)
      d = (double) OptionMath.CalculateDaysToExpire(ExpirationDate) / 365.0;
    double num1 = price;
    double num2 = (Math.Log(num1 / StrikePrice) + (int_Rate + IV * IV / 2.0) * d) / (IV * Math.Sqrt(d));
    Math.Sqrt(d);
    return num1 * Math.Sqrt(d) * (Math.Exp(-1.0 * num2 * num2 / 2.0) / Math.Sqrt(2.0 * Math.PI)) / 100.0;
  }

  public override double Rho(Symbol option, double IV, double int_Rate, double shift)
  {
    if (option == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픜());
    if (option.Underlier == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓑());
    return this.Rho(option.ExpirationDate, option.StrikePrice, option.OptionType, option.Underlier.Last, IV, int_Rate, shift);
  }

  public override double Rho(
    DateTime ExpirationDate,
    double StrikePrice,
    OptionType OptionType,
    double price,
    double IV,
    double int_Rate,
    double shift)
  {
    double num1 = price;
    double num2 = int_Rate;
    double num3 = StrikePrice;
    double d = ((double) OptionMath.CalculateDaysToExpire(ExpirationDate) - shift) / 365.0;
    if (d <= 0.0)
      d = (double) OptionMath.CalculateDaysToExpire(ExpirationDate) / 365.0;
    double num4 = IV;
    double num5 = num3;
    double x = (Math.Log(num1 / num5) + (num2 + num4 * num4 / 2.0) * d) / (num4 * Math.Sqrt(d)) - num4 * Math.Sqrt(d);
    if (OptionType != OptionType.Call)
    {
      num3 *= -1.0;
      x *= -1.0;
    }
    return num3 * d * Math.Exp(-1.0 * num2 * d) * this.NormDist(x) / 100.0;
  }
}
