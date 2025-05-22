// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.HistoryStepsCalculator
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils;

public static class HistoryStepsCalculator
{
  public static List<Interval<DateTime>> GetSteps(
    DateTime from,
    DateTime to,
    BasePeriod basePeriod,
    int multiplier,
    ISessionsContainer sessionsContainer,
    TradingPlatform.BusinessLayer.TimeZone timezone)
  {
    List<Interval<DateTime>> steps = new List<Interval<DateTime>>();
    try
    {
      long sessionOffset = sessionsContainer.GetSessionOffset(timezone, basePeriod == BasePeriod.Week, false);
      long num1 = Period.TicksInBasePeriod(basePeriod) * (long) multiplier;
      long ticks = from.Ticks / num1 * num1 + sessionOffset;
      long num2 = (to.Ticks / num1 + 1L) * num1 + sessionOffset;
      while (num2 < to.Ticks)
        num2 += num1;
      if (num2 > to.Ticks)
      {
        while (num2 - num1 > to.Ticks)
          num2 -= num1;
      }
      while (ticks > from.Ticks)
        ticks -= num1;
      if (ticks < from.Ticks)
      {
        while (ticks + num1 < from.Ticks)
          ticks += num1;
      }
      switch (basePeriod)
      {
        case BasePeriod.Month:
          DateTime dateTime1 = new DateTime(from.Year, from.Month, 1, 0, 0, 0, DateTimeKind.Utc);
          dateTime1 = dateTime1.AddTicks(sessionOffset);
          ticks = dateTime1.Ticks;
          dateTime1 = new DateTime(to.Year, to.Month, 1, 0, 0, 0, DateTimeKind.Utc);
          dateTime1 = dateTime1.AddMonths(1);
          dateTime1 = dateTime1.AddTicks(sessionOffset);
          num2 = dateTime1.Ticks;
          break;
        case BasePeriod.Year:
          DateTime dateTime2 = new DateTime(from.Year, 1, 1, 0, 0, 0, DateTimeKind.Utc);
          dateTime2 = dateTime2.AddTicks(sessionOffset);
          ticks = dateTime2.Ticks;
          DateTime dateTime3 = new DateTime(to.Year, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddYears(1);
          dateTime3 = dateTime3.AddTicks(sessionOffset);
          num2 = dateTime3.Ticks;
          break;
      }
      DateTime date = new DateTime(ticks, DateTimeKind.Utc);
      while (date.Ticks < num2)
      {
        Interval<DateTime> interval = HistoryStepsCalculator.GetNextStep(date, basePeriod, multiplier);
        date = interval.To;
        if (sessionsContainer != null)
        {
          TimeSpan timeSpan = SessionsExtensions.퓏(interval.From, sessionsContainer.TimeZone);
          if (timeSpan != TimeSpan.Zero)
            interval = new Interval<DateTime>(interval.From - timeSpan, interval.To - timeSpan);
        }
        steps.Add(interval);
      }
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
    return steps;
  }

  public static Interval<DateTime> GetNextStep(
    DateTime date,
    BasePeriod basePeriod,
    int multiplier)
  {
    long num = Period.TicksInBasePeriod(basePeriod) * (long) multiplier;
    DateTime dateTime1 = date;
    DateTime dateTime2;
    switch (basePeriod)
    {
      case BasePeriod.Month:
        dateTime2 = HistoryStepsCalculator.AddMonths(dateTime1, multiplier);
        break;
      case BasePeriod.Year:
        dateTime2 = dateTime1.AddYears(multiplier);
        break;
      default:
        dateTime2 = date.AddTicks(num);
        break;
    }
    DateTime to = dateTime2;
    return new Interval<DateTime>(dateTime1, to);
  }

  /// <summary>
  /// https://stackoverflow.com/questions/3060381/datetime-addmonths-adding-only-month-not-days
  /// Проблема:
  /// (29 Feb).AddMonth(1) = 29 March
  /// </summary>
  public static DateTime AddMonths(DateTime date, int monthsCount)
  {
    return date.Day != DateTime.DaysInMonth(date.Year, date.Month) ? date.AddMonths(monthsCount) : date.AddDays(1.0).AddMonths(monthsCount).AddDays(-1.0);
  }
}
