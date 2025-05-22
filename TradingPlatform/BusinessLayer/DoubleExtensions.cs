// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.DoubleExtensions
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public static class DoubleExtensions
{
  private const string 퓬픲 = "#,0.##########";

  public static string Format(this double value, int precision = 2, bool abbreviate = false)
  {
    if (double.IsNaN(value))
      return \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓯();
    if (abbreviate)
      return value.퓏(precision);
    double num = value == -0.0 ? Math.Abs(value) : value;
    ref double local = ref num;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓳());
    interpolatedStringHandler.AppendFormatted<int>(precision);
    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
    return local.ToString(stringAndClear);
  }

  private static string 퓏([In] this double obj0, [In] int obj1)
  {
    string str = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓥();
    if (Math.Abs(obj0) >= 1000000000000.0)
    {
      obj0 /= 1000000000000.0;
      str = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇핆();
    }
    else if (Math.Abs(obj0) >= 1000000000.0)
    {
      obj0 /= 1000000000.0;
      str = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픷();
    }
    else if (Math.Abs(obj0) >= 1000000.0)
    {
      obj0 /= 1000000.0;
      str = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓻();
    }
    else if (Math.Abs(obj0) >= 1000.0)
    {
      obj0 /= 1000.0;
      str = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픸();
    }
    if (!string.IsNullOrEmpty(str))
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
      interpolatedStringHandler.AppendFormatted<double>(obj0.퓬(1));
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프());
      interpolatedStringHandler.AppendFormatted(str);
      return interpolatedStringHandler.ToStringAndClear();
    }
    ref double local = ref obj0;
    DefaultInterpolatedStringHandler interpolatedStringHandler1 = new DefaultInterpolatedStringHandler(1, 1);
    interpolatedStringHandler1.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓳());
    interpolatedStringHandler1.AppendFormatted<int>(obj1);
    string stringAndClear = interpolatedStringHandler1.ToStringAndClear();
    return local.ToString(stringAndClear);
  }

  private static double 퓬([In] this double obj0, [In] int obj1)
  {
    double num = Math.Pow(10.0, (double) obj1);
    return Math.Truncate(obj0 * num) / num;
  }

  public static bool IsNanOrDefault(this double value) => value == 0.0 || double.IsNaN(value);

  public static string FormatPriceWithMaxPrecision(
    this double price,
    IFormatProvider formatProvider = null)
  {
    if (double.IsInfinity(price) || double.IsNaN(price))
      price = 0.0;
    return formatProvider != null ? price.ToString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픴(), formatProvider) : price.ToString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픴());
  }

  public static string FormatPriceWithMaxPrecision(this double price, int precision)
  {
    if (double.IsInfinity(price) || double.IsNaN(price))
      price = 0.0;
    string format = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픑();
    int num = precision;
    for (int index = 0; index < num; ++index)
      format += \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픿();
    for (int index = num; index < 10; ++index)
      format += \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓔();
    return price.ToString(format);
  }

  public static double RoundTo(this double value, int degree)
  {
    Decimal num = (Decimal) value;
    return (double) (num - num % (Decimal) Math.Pow(10.0, (double) degree));
  }
}
