// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.AggressorFlagCalculatorItem
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils;

public class AggressorFlagCalculatorItem : IDisposable
{
  private readonly int 핇픀;
  private AggressorFlagCalculatorItem.퓏[] 핇픖;
  private volatile int 핇퓘;
  private volatile int 핇픓;

  public AggressorFlagCalculatorItem(int cacheCapacity)
  {
    this.핇픀 = cacheCapacity;
    this.핇픖 = new AggressorFlagCalculatorItem.퓏[cacheCapacity];
    for (int index = 0; index < cacheCapacity; ++index)
      this.핇픖[index] = new AggressorFlagCalculatorItem.퓏();
    this.핇퓘 = -1;
    this.핇픓 = -1;
  }

  public void CollectBidAsk(long timeTicks, double bid, double ask)
  {
    AggressorFlagCalculatorItem.퓏 퓏 = this.핇픖?[Math.Abs(Interlocked.Increment(ref this.핇퓘) % this.핇픀)];
    if (퓏 == null)
      return;
    퓏.TimeTicks = timeTicks;
    퓏.Bid = bid;
    퓏.Ask = ask;
    Interlocked.Increment(ref this.핇픓);
  }

  public AggressorFlag CalculateAggressorFlag(long timeTicks, double last)
  {
    int num = Math.Abs(this.핇픓 % this.핇픀);
    int index = num;
    do
    {
      AggressorFlagCalculatorItem.퓏 퓏 = this.핇픖?[index];
      if (퓏 != null && 퓏.TimeTicks != 0L)
      {
        if (퓏.TimeTicks <= timeTicks)
          return AggressorFlagCalculator.CalculateAggressorFlag(퓏.Bid, 퓏.Ask, last);
        --index;
        if (index < 0)
          index = this.핇픀 - 1;
      }
      else
        break;
    }
    while (index != num);
    return AggressorFlag.NotSet;
  }

  public void Dispose() => this.핇픖 = (AggressorFlagCalculatorItem.퓏[]) null;

  private class 퓏
  {
    public long TimeTicks { get; [param: In] set; }

    public double Bid { get; [param: In] set; }

    public double Ask { get; [param: In] set; }

    public override string ToString()
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 3);
      interpolatedStringHandler.AppendFormatted<long>(this.TimeTicks);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픆());
      interpolatedStringHandler.AppendFormatted<double>(this.Bid);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픆());
      interpolatedStringHandler.AppendFormatted<double>(this.Ask);
      return interpolatedStringHandler.ToStringAndClear();
    }
  }
}
