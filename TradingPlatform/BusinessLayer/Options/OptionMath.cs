// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Options.OptionMath
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;

#nullable disable
namespace TradingPlatform.BusinessLayer.Options;

public class OptionMath
{
  public static double GetOptionLastPrice(Symbol optSymbol, OptionPriceType optionPriceType)
  {
    double optionLastPrice = double.NaN;
    if (optionPriceType == OptionPriceType.Ask)
      optionLastPrice = optSymbol.Ask;
    else if (optionPriceType == OptionPriceType.BidAsk && (!optSymbol.Ask.IsNanOrDefault() || optSymbol.Bid.IsNanOrDefault()))
    {
      optionLastPrice = (optSymbol.Ask + optSymbol.Bid) / 2.0;
    }
    else
    {
      switch (optionPriceType)
      {
        case OptionPriceType.Bid:
          optionLastPrice = optSymbol.Bid;
          break;
        case OptionPriceType.Last:
          optionLastPrice = optSymbol.Last;
          break;
      }
    }
    return optionLastPrice;
  }

  public static int CalculateDaysToExpire(DateTime expDate)
  {
    return (int) (expDate - Core.Instance.TimeUtils.DateTimeUtcNow).TotalDays + 1;
  }
}
