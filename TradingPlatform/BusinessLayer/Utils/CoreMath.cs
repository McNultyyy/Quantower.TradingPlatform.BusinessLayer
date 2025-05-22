// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.CoreMath
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils;

public static class CoreMath
{
  public static int GetValuePrecision(Decimal value)
  {
    value = Math.Abs(value);
    Decimal num1 = value - (Decimal) (long) value;
    int y = 0;
    if (num1 != 0M)
    {
      y = 1;
      while (true)
      {
        Decimal num2 = num1 * (Decimal) Math.Pow(10.0, (double) y);
        if (num2 - (Decimal) (long) num2 > 0M)
          ++y;
        else
          break;
      }
    }
    return y;
  }

  public static double RoundToIncrement(double value, double increment)
  {
    return increment <= 0.0 || double.IsNaN(value) ? value : (double) ((Decimal) (long) Math.Round((Decimal) value / (Decimal) increment, MidpointRounding.AwayFromZero) * (Decimal) increment);
  }

  public static double FloorToIncrement(double value, double increment)
  {
    return increment <= 0.0 || double.IsNaN(value) ? value : (double) ((Decimal) (long) Math.Floor((Decimal) value / (Decimal) increment) * (Decimal) increment);
  }

  public static double ProcessNaN(double value, double defaultValue = 0.0)
  {
    return !double.IsNaN(value) ? value : defaultValue;
  }

  public static double GetWeightedAverage(IEnumerable<(double, double)> array, Symbol symbol = null)
  {
    double num1 = 0.0;
    double num2 = 0.0;
    foreach ((double num3, double num4) in array)
    {
      num1 += num3 * num4;
      num2 += num4;
    }
    if (num2 == 0.0)
      return double.NaN;
    double price = num1 / num2;
    return symbol == null ? price : symbol.RoundPriceToTickSize(price);
  }
}
