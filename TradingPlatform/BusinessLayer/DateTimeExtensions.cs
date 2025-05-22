// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.DateTimeExtensions
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Globalization;

#nullable enable
namespace TradingPlatform.BusinessLayer;

public static class DateTimeExtensions
{
  public static DateTime ToSelectedTimeZone(this DateTime dt)
  {
    return Core.Instance.TimeUtils.ConvertFromUTCToSelectedTimeZone(dt);
  }

  public static DateTime FromSelectedTimeZoneToUtc(this DateTime dt)
  {
    return Core.Instance.TimeUtils.ConvertFromSelectedTimeZoneToUTC(dt);
  }

  public static DateTime TrimSeconds(this DateTime value)
  {
    return new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, 0, value.Kind);
  }

  public static DateTime CeilingTo(this DateTime value, TimeSpan timeSpan)
  {
    long num = value.Ticks % timeSpan.Ticks;
    return num == 0L ? value : new DateTime(value.Ticks - num + timeSpan.Ticks, value.Kind);
  }

  public static DateTime CeilingTo(this DateTime value, Period period)
  {
    return value.CeilingTo(TimeSpan.FromTicks(period.Ticks));
  }

  public static DateTime FloorTo(this DateTime value, TimeSpan timeSpan)
  {
    return new DateTime(value.Ticks - value.Ticks % timeSpan.Ticks, value.Kind);
  }

  public static DateTime FloorTo(this DateTime value, Period period)
  {
    return value.FloorTo(TimeSpan.FromTicks(period.Ticks));
  }

  public static long ToUnixSeconds(this DateTime dateTime)
  {
    return new DateTimeOffset(dateTime).ToUnixTimeSeconds();
  }

  public static long ToUnixMilliseconds(this DateTime dateTime)
  {
    return new DateTimeOffset(dateTime).ToUnixTimeMilliseconds();
  }

  public static DateTime SetKind(this DateTime dateTime, DateTimeKind kind)
  {
    return new DateTime(dateTime.Ticks, kind);
  }

  public static int GetWeekOfYear(this DateTime dateTime, DayOfWeek firstWeekDay = DayOfWeek.Monday)
  {
    return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(dateTime, CalendarWeekRule.FirstFullWeek, firstWeekDay);
  }

  public static 
  #nullable disable
  IEnumerable<DateTime> GetDaysOfWeekForCurrMonth(this DateTime date, DayOfWeek dayOfWeek)
  {
    DateTime dateTime1 = new DateTime(date.Year, date.Month, 1);
    DateTime dateTime2 = dateTime1.AddMonths(1);
    while (dateTime1 < dateTime2 && dateTime1.DayOfWeek != dayOfWeek)
      dateTime1 = dateTime1.AddDays(1.0);
    for (; dateTime1 < dateTime2; dateTime1 = dateTime1.AddDays(7.0))
      yield return dateTime1;
  }
}
