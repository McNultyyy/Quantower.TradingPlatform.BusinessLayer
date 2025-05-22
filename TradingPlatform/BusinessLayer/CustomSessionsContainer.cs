// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.CustomSessionsContainer
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Integration;
using TradingPlatform.BusinessLayer.Utils.Extensions;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public class CustomSessionsContainer : 
  ISessionsContainer,
  ICustomizable,
  IComparable<CustomSessionsContainer>,
  IComparable,
  IMessageBuilder<MessageSessionsContainer>
{
  public string Id { get; [param: In] private set; }

  public string Name { get; [param: In] private set; }

  public TimeZone TimeZone { get; [param: In] private set; }

  public CustomSession[] Sessions { get; [param: In] private set; }

  public ISession[] ActiveSessions
  {
    get
    {
      return ((IEnumerable<CustomSession>) this.Sessions).Where<CustomSession>((Func<CustomSession, bool>) (([In] obj0) => obj0.IsActive)).Cast<ISession>().ToArray<ISession>();
    }
  }

  public CustomHoliday[] Holidays { get; [param: In] private set; }

  TimeZoneInfo ISessionsContainer.TimeZone
  {
    get => !this.TimeZone.IsEmpty ? this.TimeZone.TimeZoneInfo : (TimeZoneInfo) null;
  }

  public IList<SettingItem> Settings
  {
    get
    {
      List<SettingItem> settings = new List<SettingItem>();
      settings.AddRange((IEnumerable<SettingItem>) new SettingItem[4]
      {
        (SettingItem) new SettingItemString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓬(), this.Id),
        (SettingItem) new SettingItemString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓫(), this.Name),
        (SettingItem) new SettingItemGroup(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픾(), (IList<SettingItem>) new List<SettingItem>()
        {
          (SettingItem) new SettingItemString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓍(), this.TimeZone.TimeZoneInfo.Id),
          (SettingItem) new SettingItemInteger(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픓(), (int) this.TimeZone.Type)
        }),
        (SettingItem) new SettingItemGroup(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픁(), (IList<SettingItem>) ((IEnumerable<CustomSession>) this.Sessions).Select<CustomSession, SettingItemGroup>((Func<CustomSession, SettingItemGroup>) (([In] obj0) => new SettingItemGroup(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픬(), obj0.Settings))).Cast<SettingItem>().ToList<SettingItem>())
      });
      if (this.Holidays != null)
      {
        List<SettingItem> settingItemList = settings;
        string name = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픞();
        CustomHoliday[] holidays = this.Holidays;
        List<SettingItem> list = holidays != null ? ((IEnumerable<CustomHoliday>) holidays).Select<CustomHoliday, SettingItemGroup>((Func<CustomHoliday, SettingItemGroup>) (([In] obj0) => new SettingItemGroup(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓕(), obj0.Settings))).Cast<SettingItem>().ToList<SettingItem>() : (List<SettingItem>) null;
        SettingItemGroup settingItemGroup = new SettingItemGroup(name, (IList<SettingItem>) list);
        settingItemList.Add((SettingItem) settingItemGroup);
      }
      return (IList<SettingItem>) settings;
    }
    set
    {
      this.Id = value.GetValueOrDefault<string>(this.Id, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓬());
      this.Name = value.GetValueOrDefault<string>(this.Name, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓫());
      IList<SettingItem> settings;
      if (value.TryGetValue<IList<SettingItem>>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픾(), out settings))
      {
        TimeZoneType type = settings.GetValue<TimeZoneType>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픓());
        TimeZoneInfo timeZoneInfo = (TimeZoneInfo) null;
        if (type != TimeZoneType.Local)
          timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(settings.GetValue<string>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓍()));
        this.TimeZone = new TimeZone(type, timeZoneInfo);
      }
      IList<SettingItem> settingItemList1;
      if (value.TryGetValue<IList<SettingItem>>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픁(), out settingItemList1))
      {
        List<CustomSession> customSessionList = new List<CustomSession>();
        foreach (SettingItem settingItem in (IEnumerable<SettingItem>) settingItemList1)
        {
          if (settingItem.Value is IList<SettingItem> settingItemList2)
          {
            CustomSession customSession = new CustomSession()
            {
              Settings = settingItemList2
            };
            customSession.RecalculateOpenCloseTime(this.TimeZone.TimeZoneInfo);
            customSessionList.Add(customSession);
          }
        }
        this.Sessions = customSessionList.ToArray();
      }
      IList<SettingItem> settingItemList3;
      if (!value.TryGetValue<IList<SettingItem>>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픞(), out settingItemList3))
        return;
      List<CustomHoliday> customHolidayList = new List<CustomHoliday>();
      foreach (SettingItem settingItem in (IEnumerable<SettingItem>) settingItemList3)
      {
        if (settingItem.Value is IList<SettingItem> settingItemList4)
        {
          CustomHoliday customHoliday = new CustomHoliday()
          {
            Settings = settingItemList4
          };
          customHolidayList.Add(customHoliday);
        }
      }
      this.Holidays = customHolidayList.ToArray();
    }
  }

  internal CustomSessionsContainer()
  {
  }

  public CustomSessionsContainer(
    string name,
    TimeZone? timeZone = null,
    CustomSession[] sessions = null,
    CustomHoliday[] holidays = null)
  {
    this.Id = Guid.NewGuid().ToShortString();
    this.Name = name;
    this.TimeZone = timeZone ?? Core.Instance.TimeUtils.SelectedTimeZone;
    this.Sessions = sessions ?? Array.Empty<CustomSession>();
    this.Holidays = holidays ?? Array.Empty<CustomHoliday>();
  }

  internal void 퓏([In] CustomSessionsContainer obj0)
  {
    this.Name = obj0.Name;
    this.TimeZone = obj0.TimeZone;
    this.Sessions = obj0.Sessions ?? Array.Empty<CustomSession>();
    this.Holidays = obj0.Holidays ?? Array.Empty<CustomHoliday>();
  }

  public ISession[] GetSessionsForDate(DateTime dateTime)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    CustomSessionsContainer.퓬 퓬 = new CustomSessionsContainer.퓬();
    // ISSUE: reference to a compiler-generated field
    퓬.퓥픏 = TimeZoneInfo.ConvertTimeFromUtc(dateTime, this.TimeZone.TimeZoneInfo);
    CustomHoliday[] holidays = this.Holidays;
    // ISSUE: reference to a compiler-generated method
    if ((holidays != null ? ((IEnumerable<CustomHoliday>) holidays).FirstOrDefault<CustomHoliday>(new Func<CustomHoliday, bool>(퓬.퓏)) : (CustomHoliday) null) != null)
      return Array.Empty<ISession>();
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    퓬.퓥퓳 = 퓬.퓥픏.DayOfWeek;
    // ISSUE: reference to a compiler-generated method
    return ((IEnumerable<CustomSession>) this.Sessions).Where<CustomSession>(new Func<CustomSession, bool>(퓬.퓏)).Cast<ISession>().ToArray<ISession>();
  }

  public int CompareTo(CustomSessionsContainer other)
  {
    return string.Compare(this.Name, other.Name, StringComparison.Ordinal);
  }

  public int CompareTo(object obj)
  {
    return !(obj is CustomSessionsContainer other) ? 0 : this.CompareTo(other);
  }

  public override string ToString() => this.Name;

  public MessageSessionsContainer BuildMessage()
  {
    MessageSessionsContainer sessionsContainer = new MessageSessionsContainer();
    sessionsContainer.Id = this.Id;
    sessionsContainer.Name = this.Name;
    sessionsContainer.Description = string.Empty;
    CustomHoliday[] holidays = this.Holidays;
    sessionsContainer.Holidays = holidays != null ? ((IEnumerable<CustomHoliday>) holidays).Select<CustomHoliday, HolidayInfo>((Func<CustomHoliday, HolidayInfo>) (([In] obj0) => new HolidayInfo()
    {
      Name = obj0.Name,
      Date = obj0.Date
    })).ToArray<HolidayInfo>() : (HolidayInfo[]) null;
    CustomSession[] sessions = this.Sessions;
    sessionsContainer.SessionsSets = sessions != null ? ((IEnumerable<CustomSession>) sessions).GroupBy<CustomSession, int>((Func<CustomSession, int>) (([In] obj0) => ((IStructuralEquatable) ((IEnumerable<DayOfWeek>) obj0.Days).Select<DayOfWeek, int>((Func<DayOfWeek, int>) (([In] obj0) => (int) obj0)).ToArray<int>()).GetHashCode((IEqualityComparer) EqualityComparer<int>.Default))).Select<IGrouping<int, CustomSession>, SessionsSet>((Func<IGrouping<int, CustomSession>, SessionsSet>) (([In] obj0) => new SessionsSet()
    {
      Days = obj0.FirstOrDefault<CustomSession>().Days,
      Sessions = obj0.Select<CustomSession, Session>((Func<CustomSession, Session>) (([In] obj0) => new Session(obj0.Name, obj0.OpenTime, obj0.CloseTime, obj0.Type))).ToArray<Session>()
    })).ToArray<SessionsSet>() : (SessionsSet[]) null;
    return sessionsContainer;
  }
}
