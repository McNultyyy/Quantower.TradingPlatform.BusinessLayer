// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.TimeInForceExtensions
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public static class TimeInForceExtensions
{
  public static string Format(this TimeInForce value, DateTime expiration = default (DateTime))
  {
    if (expiration == new DateTime())
      return value.ToString();
    string str;
    switch (value)
    {
      case TimeInForce.GTD:
        str = value.ToString() + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓓() + Core.Instance.TimeUtils.ConvertFromUTCToSelectedTimeZone(expiration).ToShortDateString() + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픗();
        break;
      case TimeInForce.GTT:
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 2);
        interpolatedStringHandler.AppendFormatted(value.ToString());
        interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓓());
        interpolatedStringHandler.AppendFormatted<DateTime>(Core.Instance.TimeUtils.ConvertFromUTCToSelectedTimeZone(expiration), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓰());
        interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픗());
        str = interpolatedStringHandler.ToStringAndClear();
        break;
      default:
        str = value.ToString();
        break;
    }
    return str;
  }
}
