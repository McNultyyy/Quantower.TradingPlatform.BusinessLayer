// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.AggressorFlagCalculator
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils;

/// <summary>The aggressor flag calculator.</summary>
public class AggressorFlagCalculator : IAggressorFlagCalculator, IDisposable
{
  private const int 핁핃 = 1000;
  private ConcurrentDictionary<string, AggressorFlagCalculatorItem> 핁퓫;

  /// <summary>
  /// Initializes a new instance of the <see cref="T:TradingPlatform.BusinessLayer.Utils.AggressorFlagCalculator" /> class.
  /// </summary>
  public AggressorFlagCalculator()
  {
    this.핁퓫 = new ConcurrentDictionary<string, AggressorFlagCalculatorItem>();
  }

  /// <summary>Collect bid ask.</summary>
  /// <param name="symbol">The symbol.</param>
  /// <param name="timeTicks">The time ticks.</param>
  /// <param name="bid">The bid.</param>
  /// <param name="ask">The ask.</param>
  public void CollectBidAsk(string symbol, long timeTicks, double bid, double ask)
  {
    try
    {
      AggressorFlagCalculatorItem flagCalculatorItem;
      if (this.핁퓫 == null || !this.핁퓫.TryGetValue(symbol, out flagCalculatorItem) && !this.핁퓫.TryAdd(symbol, flagCalculatorItem = new AggressorFlagCalculatorItem(1000)))
        return;
      flagCalculatorItem.CollectBidAsk(timeTicks, bid, ask);
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁핅() + ex.GetMessageRecursive());
    }
  }

  /// <summary>Calculate aggressor flag.</summary>
  /// <param name="symbol">The symbol.</param>
  /// <param name="timeTicks">The time ticks.</param>
  /// <param name="last">The last.</param>
  /// <returns>An AggressorFlag.</returns>
  public AggressorFlag CalculateAggressorFlag(string symbol, long timeTicks, double last)
  {
    try
    {
      AggressorFlagCalculatorItem flagCalculatorItem;
      return this.핁퓫 == null || !this.핁퓫.TryGetValue(symbol, out flagCalculatorItem) ? AggressorFlag.NotSet : flagCalculatorItem.CalculateAggressorFlag(timeTicks, last);
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁핅() + ex.GetMessageRecursive());
    }
    return AggressorFlag.NotSet;
  }

  /// <summary>
  /// 
  /// </summary>
  public void Dispose()
  {
    ICollection<AggressorFlagCalculatorItem> values = this.핁퓫.Values;
    this.핁퓫 = (ConcurrentDictionary<string, AggressorFlagCalculatorItem>) null;
    foreach (AggressorFlagCalculatorItem flagCalculatorItem in (IEnumerable<AggressorFlagCalculatorItem>) values)
      flagCalculatorItem.Dispose();
  }

  /// <summary>Calculate aggressor flag.</summary>
  /// <param name="previousBid">The previous bid.</param>
  /// <param name="previousAsk">The previous ask.</param>
  /// <param name="last">The last.</param>
  /// <returns>An AggressorFlag.</returns>
  public static AggressorFlag CalculateAggressorFlag(
    double previousBid,
    double previousAsk,
    double last)
  {
    if (last >= previousAsk)
      return AggressorFlag.Buy;
    return last <= previousBid ? AggressorFlag.Sell : AggressorFlag.None;
  }
}
