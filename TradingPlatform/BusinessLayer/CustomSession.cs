// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.CustomSession
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Utils.Extensions;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public class CustomSession : ISession, ICustomizable
{
  private bool 퓍퓯;

  public bool IsActive { get; set; }

  public string Name { get; set; }

  public SessionType Type { get; set; }

  public TimeSpan OpenTime { get; [param: In] private set; }

  public TimeSpan CloseTime { get; [param: In] private set; }

  public TimeSpan OpenOffset { get; set; }

  public TimeSpan CloseOffset { get; set; }

  public void RecalculateOpenCloseTime(TimeZoneInfo timeZoneInfo)
  {
    if (this.퓍퓯)
    {
      this.OpenOffset = this.OpenTime.ConvertTimeZone(TimeZoneInfo.Utc, timeZoneInfo);
      this.CloseOffset = this.CloseTime.ConvertTimeZone(TimeZoneInfo.Utc, timeZoneInfo);
    }
    else
    {
      this.OpenTime = this.OpenOffset.ConvertTimeZone(timeZoneInfo, TimeZoneInfo.Utc);
      this.CloseTime = this.CloseOffset.ConvertTimeZone(timeZoneInfo, TimeZoneInfo.Utc);
    }
  }

  public DayOfWeek[] Days { get; set; }

  public bool IsPrimary { get; set; }

  public IList<SettingItem> Settings
  {
    get
    {
      return (IList<SettingItem>) new List<SettingItem>()
      {
        (SettingItem) new SettingItemBoolean(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓸(), this.IsActive),
        (SettingItem) new SettingItemString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓫(), this.Name),
        (SettingItem) new SettingItemInteger(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픓(), (int) this.Type),
        (SettingItem) new SettingItemLong(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픋(), this.OpenOffset.Ticks),
        (SettingItem) new SettingItemLong(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁핀(), this.CloseOffset.Ticks),
        (SettingItem) new SettingItemString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픲(), string.Join(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픧(), ((IEnumerable<DayOfWeek>) this.Days).Select<DayOfWeek, string>((Func<DayOfWeek, string>) (([In] obj0) => obj0.ToString()))))
      };
    }
    set
    {
      this.IsActive = value.GetValueOrDefault<bool>((this.IsActive ? 1 : 0) != 0, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓸());
      this.Name = value.GetValueOrDefault<string>(this.Name, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓫());
      this.Type = (SessionType) value.GetValueOrDefault<int>((int) this.Type, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픓());
      long num1;
      if (value.TryGetValue<long>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픋(), out num1))
      {
        this.OpenOffset = TimeSpan.FromTicks(num1);
        long num2;
        if (value.TryGetValue<long>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁핀(), out num2))
          this.CloseOffset = TimeSpan.FromTicks(num2);
      }
      else
      {
        this.퓍퓯 = true;
        long num3;
        if (value.TryGetValue<long>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픽(), out num3))
          this.OpenTime = TimeSpan.FromTicks(num3);
        long num4;
        if (value.TryGetValue<long>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓏(), out num4))
          this.CloseTime = TimeSpan.FromTicks(num4);
      }
      string str1;
      if (!value.TryGetValue<string>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픲(), out str1))
        return;
      string[] strArray = str1.Split(new string[1]
      {
        \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픧()
      }, StringSplitOptions.RemoveEmptyEntries);
      List<DayOfWeek> dayOfWeekList = new List<DayOfWeek>();
      foreach (string str2 in strArray)
      {
        DayOfWeek result;
        if (Enum.TryParse<DayOfWeek>(str2, true, out result))
          dayOfWeekList.Add(result);
      }
      this.Days = dayOfWeekList.ToArray();
    }
  }
}
