// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SessionsContainer
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Integration;

#nullable enable
namespace TradingPlatform.BusinessLayer;

public class SessionsContainer : 
  BusinessObject,
  ISessionsContainer,
  IMessageBuilder<
  #nullable disable
  MessageSessionsContainer>
{
  public string Id { get; [param: In] private set; }

  public string Name { get; [param: In] private set; }

  public string Description { get; [param: In] private set; }

  public HolidayInfo[] Holidays { get; [param: In] private set; }

  public SessionsSet[] SessionsSets { get; [param: In] private set; }

  public ISession[] ActiveSessions
  {
    get
    {
      SessionsSet[] sessionsSets = this.SessionsSets;
      return sessionsSets == null ? (ISession[]) null : ((IEnumerable<SessionsSet>) sessionsSets).SelectMany<SessionsSet, Session>((Func<SessionsSet, IEnumerable<Session>>) (([In] obj0) => (IEnumerable<Session>) obj0.Sessions)).Cast<ISession>().ToArray<ISession>();
    }
  }

  public TimeZoneInfo TimeZone => (TimeZoneInfo) null;

  internal SessionsContainer([In] string obj0)
    : base(obj0)
  {
  }

  public void UpdateByMessage(MessageSessionsContainer message)
  {
    this.Id = message.Id;
    this.Name = message.Name;
    this.Description = message.Description;
    HolidayInfo[] holidays = message.Holidays;
    this.Holidays = holidays != null ? ((IEnumerable<HolidayInfo>) holidays).Select<HolidayInfo, HolidayInfo>((Func<HolidayInfo, HolidayInfo>) (([In] obj0) => new HolidayInfo(obj0))).ToArray<HolidayInfo>() : (HolidayInfo[]) null;
    SessionsSet[] sessionsSets = message.SessionsSets;
    this.SessionsSets = sessionsSets != null ? ((IEnumerable<SessionsSet>) sessionsSets).Select<SessionsSet, SessionsSet>((Func<SessionsSet, SessionsSet>) (([In] obj0) => new SessionsSet(obj0))).ToArray<SessionsSet>() : (SessionsSet[]) null;
  }

  public ISession[] GetSessionsForDate(DateTime dateTime)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    SessionsContainer.퓬 퓬 = new SessionsContainer.퓬();
    // ISSUE: reference to a compiler-generated field
    퓬.핋픉 = dateTime;
    HolidayInfo[] holidays = this.Holidays;
    // ISSUE: reference to a compiler-generated method
    if ((holidays != null ? ((IEnumerable<HolidayInfo>) holidays).FirstOrDefault<HolidayInfo>(new Func<HolidayInfo, bool>(퓬.퓏)) : (HolidayInfo) null) != null)
      return Array.Empty<ISession>();
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    퓬.핋픒 = 퓬.핋픉.DayOfWeek;
    // ISSUE: reference to a compiler-generated method
    // ISSUE: reference to a compiler-generated method
    SessionsSet sessionsSet = ((IEnumerable<SessionsSet>) this.SessionsSets).FirstOrDefault<SessionsSet>(new Func<SessionsSet, bool>(퓬.퓏)) ?? ((IEnumerable<SessionsSet>) this.SessionsSets).FirstOrDefault<SessionsSet>(new Func<SessionsSet, bool>(퓬.퓬));
    return (sessionsSet != null ? sessionsSet.Sessions.Cast<ISession>().ToArray<ISession>() : (ISession[]) null) ?? Array.Empty<ISession>();
  }

  public MessageSessionsContainer BuildMessage()
  {
    MessageSessionsContainer sessionsContainer = new MessageSessionsContainer();
    sessionsContainer.Id = this.Id;
    sessionsContainer.Name = this.Name;
    sessionsContainer.Description = this.Description;
    HolidayInfo[] holidays = this.Holidays;
    sessionsContainer.Holidays = holidays != null ? ((IEnumerable<HolidayInfo>) holidays).Select<HolidayInfo, HolidayInfo>((Func<HolidayInfo, HolidayInfo>) (([In] obj0) => new HolidayInfo(obj0))).ToArray<HolidayInfo>() : (HolidayInfo[]) null;
    SessionsSet[] sessionsSets = this.SessionsSets;
    sessionsContainer.SessionsSets = sessionsSets != null ? ((IEnumerable<SessionsSet>) sessionsSets).Select<SessionsSet, SessionsSet>((Func<SessionsSet, SessionsSet>) (([In] obj0) => new SessionsSet(obj0))).ToArray<SessionsSet>() : (SessionsSet[]) null;
    return sessionsContainer;
  }
}
