// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.PeriodExtensions
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public static class PeriodExtensions
{
  public static Interval<DateTime> FindInterval(this Period period, DateTime dateTime)
  {
    return period.FindInterval(dateTime.Ticks);
  }

  public static Interval<DateTime> FindInterval(this Period period, long dateTimeTicks)
  {
    long ticks = period.Ticks;
    DateTime from = new DateTime(dateTimeTicks - dateTimeTicks % ticks, DateTimeKind.Utc);
    DateTime to = from.AddTicks(ticks - 1L);
    return new Interval<DateTime>(from, to);
  }
}
