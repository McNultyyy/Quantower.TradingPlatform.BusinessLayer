// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.AggressorFlagCalculatorExtensions
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>The aggressor flag calculator extensions.</summary>
public static class AggressorFlagCalculatorExtensions
{
  /// <summary>Collect bid ask.</summary>
  /// <param name="calculator">The calculator.</param>
  /// <param name="quote">The quote.</param>
  public static void CollectBidAsk(this IAggressorFlagCalculator calculator, Quote quote)
  {
    calculator.CollectBidAsk(quote.SymbolId, quote.Time.Ticks, quote.Bid, quote.Ask);
  }

  /// <summary>Calculate aggressor flag.</summary>
  /// <param name="calculator">The calculator.</param>
  /// <param name="last">The last.</param>
  /// <returns>An AggressorFlag.</returns>
  public static AggressorFlag CalculateAggressorFlag(
    this IAggressorFlagCalculator calculator,
    Last last)
  {
    return calculator.CalculateAggressorFlag(last.SymbolId, last.Time.Ticks, last.Price);
  }
}
