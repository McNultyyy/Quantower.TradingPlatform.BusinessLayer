// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.DefaultSessionsContainer
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Integration;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public sealed class DefaultSessionsContainer : 
  ISessionsContainer,
  IMessageBuilder<MessageSessionsContainer>
{
  private static DefaultSessionsContainer 핂퓜;
  private readonly CustomSession[] 핂픺;

  public static DefaultSessionsContainer Instance
  {
    get
    {
      lock (typeof (DefaultSessionsContainer))
      {
        if (DefaultSessionsContainer.핂퓜 == null)
          DefaultSessionsContainer.핂퓜 = new DefaultSessionsContainer();
      }
      return DefaultSessionsContainer.핂퓜;
    }
  }

  private DefaultSessionsContainer()
  {
    this.핂픺 = new CustomSession[1]
    {
      new CustomSession()
      {
        Name = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓔(),
        OpenOffset = TimeSpan.Zero,
        CloseOffset = TimeSpan.FromTicks(863999999999L),
        Days = Enum.GetValues(typeof (DayOfWeek)).Cast<DayOfWeek>().ToArray<DayOfWeek>(),
        Type = SessionType.Main
      }
    };
  }

  public ISession[] ActiveSessions => (ISession[]) this.핂픺;

  public TimeZoneInfo TimeZone => (TimeZoneInfo) null;

  public ISession[] GetSessionsForDate(DateTime dateTime) => (ISession[]) this.핂픺;

  public MessageSessionsContainer BuildMessage()
  {
    MessageSessionsContainer sessionsContainer = new MessageSessionsContainer();
    sessionsContainer.Id = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픢();
    sessionsContainer.Name = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픢();
    sessionsContainer.Description = string.Empty;
    sessionsContainer.Holidays = new HolidayInfo[0];
    CustomSession[] 핂픺 = this.핂픺;
    sessionsContainer.SessionsSets = 핂픺 != null ? ((IEnumerable<CustomSession>) 핂픺).Select<CustomSession, SessionsSet>((Func<CustomSession, SessionsSet>) (([In] obj0) => new SessionsSet()
    {
      Days = obj0.Days,
      CertainDates = new DateTime[0],
      Sessions = new Session[1]
      {
        new Session(obj0.Name, obj0.OpenTime, obj0.CloseTime)
      }
    })).ToArray<SessionsSet>() : (SessionsSet[]) null;
    return sessionsContainer;
  }
}
