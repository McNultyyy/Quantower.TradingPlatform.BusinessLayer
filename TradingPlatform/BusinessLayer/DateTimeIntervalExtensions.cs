// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.DateTimeIntervalExtensions
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Threading;
using TradingPlatform.BusinessLayer.Utils;

#nullable enable
namespace TradingPlatform.BusinessLayer;

public static class DateTimeIntervalExtensions
{
  public static TimeSpan GetLength(this Interval<DateTime> interval)
  {
    DateTime dateTime = interval.From;
    long ticks1 = dateTime.Ticks;
    dateTime = interval.To;
    long ticks2 = dateTime.Ticks;
    return TimeSpan.FromTicks(Math.Abs(ticks1 - ticks2));
  }

  public static 
  #nullable disable
  IEnumerable<Interval<DateTime>> Split(
    this Interval<DateTime> interval,
    TimeSpan step,
    bool roundToStep = false)
  {
    DateTime from;
    DateTime to;
    if (step == TimeSpan.Zero || step == Timeout.InfiniteTimeSpan)
      yield return interval;
    else if (interval.IsReversal)
    {
      to = interval.From;
      do
      {
        from = to.Add(-step);
        if (roundToStep)
          from = from.CeilingTo(step);
        if (from < interval.To)
          from = interval.To;
        yield return new Interval<DateTime>(from, to);
        to = from;
      }
      while (from > interval.To);
    }
    else
    {
      from = interval.From;
      do
      {
        to = from.Add(step);
        if (roundToStep)
          to = to.FloorTo(step);
        if (to > interval.To)
          to = interval.To;
        yield return new Interval<DateTime>(from, to);
        from = to;
      }
      while (to.Ticks < interval.To.Ticks);
    }
  }

  public static bool Contains(this Interval<DateTime> interval, Period period)
  {
    DateTime dateTime1 = interval.From;
    DateTime dateTime2 = interval.To;
    if (interval.IsReversal)
    {
      dateTime1 = interval.To;
      dateTime2 = interval.From;
    }
    DateTime dateTime3 = dateTime2.AddTicks(1L);
    long ticks1 = dateTime1.CeilingTo(period).Ticks;
    long ticks2 = dateTime3.FloorTo(period).Ticks;
    return period.Ticks <= ticks2 - ticks1;
  }
}
