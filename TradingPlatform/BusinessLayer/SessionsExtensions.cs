// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SessionsExtensions
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public static class SessionsExtensions
{
  public static bool ContainsDate(this ISession session, DateTime dateTime)
  {
    return session.ContainsTime(dateTime.TimeOfDay);
  }

  public static bool ContainsDate(this ISession session, long dateTimeTicks)
  {
    return session.ContainsTime(dateTimeTicks % 864000000000L);
  }

  public static bool ContainsTime(this ISession session, TimeSpan time)
  {
    return session.ContainsTime(time.Ticks);
  }

  public static bool ContainsTime(this ISession session, long timeTicks)
  {
    if (session.OpenTime < session.CloseTime)
    {
      if (timeTicks < session.OpenTime.Ticks || timeTicks >= session.CloseTime.Ticks)
        return false;
    }
    else if (timeTicks >= session.CloseTime.Ticks && timeTicks < session.OpenTime.Ticks)
      return false;
    return true;
  }

  public static bool ContainsDate(this ISession session, DateTime dateTime, TimeZoneInfo timeZone)
  {
    TimeSpan time = dateTime.TimeOfDay + SessionsExtensions.퓏(dateTime, timeZone);
    return session.ContainsTime(time);
  }

  internal static TimeSpan 퓏([In] DateTime obj0, [In] TimeZoneInfo obj1)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    SessionsExtensions.퓬 퓬 = new SessionsExtensions.퓬();
    // ISSUE: reference to a compiler-generated field
    퓬.픞픍 = obj0;
    TimeSpan timeSpan = TimeSpan.Zero;
    if (obj1 == null)
      return timeSpan;
    DateTime date = DateTime.UtcNow.Date;
    // ISSUE: reference to a compiler-generated field
    if (!obj1.IsDaylightSavingTime(퓬.픞픍) && obj1.IsDaylightSavingTime(date))
    {
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      TimeZoneInfo.AdjustmentRule adjustmentRule = ((IEnumerable<TimeZoneInfo.AdjustmentRule>) obj1.GetAdjustmentRules()).Where<TimeZoneInfo.AdjustmentRule>(new Func<TimeZoneInfo.AdjustmentRule, bool>(퓬.퓏)).Where<TimeZoneInfo.AdjustmentRule>(new Func<TimeZoneInfo.AdjustmentRule, bool>(퓬.퓬)).FirstOrDefault<TimeZoneInfo.AdjustmentRule>();
      if (adjustmentRule != null)
        timeSpan = -adjustmentRule.DaylightDelta;
    }
    // ISSUE: reference to a compiler-generated field
    if (obj1.IsDaylightSavingTime(퓬.픞픍) && !obj1.IsDaylightSavingTime(date))
    {
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      TimeZoneInfo.AdjustmentRule adjustmentRule = ((IEnumerable<TimeZoneInfo.AdjustmentRule>) obj1.GetAdjustmentRules()).Where<TimeZoneInfo.AdjustmentRule>(new Func<TimeZoneInfo.AdjustmentRule, bool>(퓬.핇)).Where<TimeZoneInfo.AdjustmentRule>(new Func<TimeZoneInfo.AdjustmentRule, bool>(퓬.퓲)).FirstOrDefault<TimeZoneInfo.AdjustmentRule>();
      if (adjustmentRule != null)
        timeSpan = adjustmentRule.DaylightDelta;
    }
    return timeSpan;
  }

  public static ISession GetSessionForDate(
    this ISessionsContainer sessionsContainer,
    DateTime dateTime)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    SessionsExtensions.핇 핇 = new SessionsExtensions.핇();
    // ISSUE: reference to a compiler-generated field
    핇.픞픆 = dateTime;
    // ISSUE: reference to a compiler-generated field
    ISession[] sessionsForDate = sessionsContainer.GetSessionsForDate(핇.픞픆);
    // ISSUE: reference to a compiler-generated method
    return !((IEnumerable<ISession>) sessionsForDate).Any<ISession>() ? (ISession) null : ((IEnumerable<ISession>) sessionsForDate).FirstOrDefault<ISession>(new Func<ISession, bool>(핇.퓏));
  }

  public static bool ContainsDate(this ISessionsContainer sessionsContainer, DateTime dateTime)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    SessionsExtensions.퓲 퓲 = new SessionsExtensions.퓲();
    // ISSUE: reference to a compiler-generated field
    퓲.픞픅 = dateTime;
    // ISSUE: reference to a compiler-generated field
    퓲.픞픠 = sessionsContainer;
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    ISession[] sessionsForDate = 퓲.픞픠.GetSessionsForDate(퓲.픞픅);
    if (!((IEnumerable<ISession>) sessionsForDate).Any<ISession>())
      return false;
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated method
    // ISSUE: reference to a compiler-generated method
    return 퓲.픞픠.TimeZone != null && 퓲.픞픠.TimeZone.SupportsDaylightSavingTime ? ((IEnumerable<ISession>) sessionsForDate).Any<ISession>(new Func<ISession, bool>(퓲.퓏)) : ((IEnumerable<ISession>) sessionsForDate).Any<ISession>(new Func<ISession, bool>(퓲.퓬));
  }

  public static bool ContainsDate(this ISessionsContainer sessionsContainer, long dateTimeTicks)
  {
    return sessionsContainer.ContainsDate(new DateTime(dateTimeTicks, DateTimeKind.Utc));
  }

  public static long GetSessionOffset(
    this ISessionsContainer sessionsContainer,
    TimeZone timezone,
    bool isWeek,
    bool applyNegativeSignForInDaySession = true)
  {
    ISession session = sessionsContainer.퓏();
    long sessionOffset = session == null ? -timezone.TimeZoneInfo.BaseUtcOffset.Ticks : (!(session.CloseTime >= session.OpenTime) ? -(TimeSpan.FromHours(24.0).Ticks - session.OpenTime.Ticks) : (applyNegativeSignForInDaySession ? -1L : 1L) * session.OpenTime.Ticks);
    if (isWeek)
    {
      DateTime dateTime = new DateTime(1, 1, 1, 0, 0, 0, DateTimeKind.Utc);
      sessionOffset += (long) (dateTime.DayOfWeek - 1) * 864000000000L;
    }
    return sessionOffset;
  }

  public static long GetSessionOpenTime(
    this ISessionsContainer sessionsContainer,
    TimeZone timezone)
  {
    ISession session = sessionsContainer.퓏();
    return session == null ? timezone.TimeZoneInfo.BaseUtcOffset.Ticks : session.OpenTime.Ticks;
  }

  private static ISession 퓏([In] this ISessionsContainer obj0_1)
  {
    if (obj0_1 == null)
      return (ISession) null;
    ISession[] activeSessions1 = obj0_1.ActiveSessions;
    List<ISession> list = activeSessions1 != null ? ((IEnumerable<ISession>) activeSessions1).Where<ISession>((Func<ISession, bool>) (([In] obj0_2) => obj0_2.IsPrimary)).ToList<ISession>() : (List<ISession>) null;
    if (list == null || list.Count == 0)
    {
      ISession[] activeSessions2 = obj0_1.ActiveSessions;
      list = activeSessions2 != null ? ((IEnumerable<ISession>) activeSessions2).Where<ISession>((Func<ISession, bool>) (([In] obj0_3) => obj0_3.ContainsTime(TimeSpan.Zero))).ToList<ISession>() : (List<ISession>) null;
    }
    if (list == null || list.Count == 0)
    {
      ISession[] activeSessions3 = obj0_1.ActiveSessions;
      list = activeSessions3 != null ? ((IEnumerable<ISession>) activeSessions3).Where<ISession>((Func<ISession, bool>) (([In] obj0_4) => obj0_4.CloseTime > obj0_4.OpenTime)).ToList<ISession>() : (List<ISession>) null;
    }
    if (list == null || list.Count == 0)
    {
      ISession[] activeSessions4 = obj0_1.ActiveSessions;
      list = activeSessions4 != null ? ((IEnumerable<ISession>) activeSessions4).ToList<ISession>() : (List<ISession>) null;
    }
    list?.Sort((Comparison<ISession>) (([In] obj0_5, [In] obj1) => obj0_5.OpenTime.CompareTo(obj1.OpenTime)));
    return list == null ? (ISession) null : list.FirstOrDefault<ISession>();
  }
}
