// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.TimeUtils
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public sealed class TimeUtils
{
  public const long UNIX_START_TIME_TICKS = 621355968000000000;

  public DateTime DateTimeUtcNow
  {
    get => DateTime.UtcNow.AddMilliseconds((double) this.TimeSynchronizer.ServerTimeOffset);
  }

  public int ServerTimeOffset
  {
    get
    {
      퓏.퓯 timeSynchronizer = this.TimeSynchronizer;
      return timeSynchronizer == null ? 0 : timeSynchronizer.ServerTimeOffset;
    }
  }

  public TimeZone SelectedTimeZone { get; set; }

  public DateTime StartTerminalDateTimeUtc { get; [param: In] private set; }

  internal 퓏.퓯 TimeSynchronizer { get; [param: In] private set; }

  public bool IsSyncFailed => this.TimeSynchronizer.State == 퓏.픜.핇픙;

  public string SyncErrorMessage => this.TimeSynchronizer.LastSyncErrorMessage;

  public TimeUtils()
  {
    this.TimeSynchronizer = new 퓏.퓯();
    this.SelectedTimeZone = new TimeZone(TimeZoneType.Local);
  }

  internal void 퓏()
  {
    Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓴(), LoggingLevel.Verbose);
    this.TimeSynchronizer.퓏();
    this.StartTerminalDateTimeUtc = this.DateTimeUtcNow;
    Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픳(), LoggingLevel.Verbose);
  }

  internal void 퓬() => this.TimeSynchronizer.Dispose();

  public DateTime ConvertFromUTCToSelectedTimeZone(DateTime dateTime)
  {
    return this.ConvertFromUTCToTimeZone(dateTime, this.SelectedTimeZone);
  }

  public TimeSpan ConvertFromUTCToSelectedTimeZone(TimeSpan time)
  {
    return this.ConvertFromUTCToTimeZone(time, this.SelectedTimeZone);
  }

  public DateTime ConvertFromSelectedTimeZoneToUTC(DateTime dateTime)
  {
    return this.ConvertFromTimeZoneToUTC(dateTime, this.SelectedTimeZone);
  }

  public DateTime ConvertFromUTCToTimeZone(DateTime dateTime, TimeZone timeZone)
  {
    return timeZone.TimeZoneInfo != null && dateTime.Kind != DateTimeKind.Local ? TimeZoneInfo.ConvertTimeFromUtc(dateTime, timeZone.TimeZoneInfo) : dateTime;
  }

  public TimeSpan ConvertFromUTCToTimeZone(TimeSpan time, TimeZone timeZone)
  {
    DateTime dateTime = this.DateTimeUtcNow.Date + time;
    return timeZone.TimeZoneInfo != null && dateTime.Kind != DateTimeKind.Local ? TimeZoneInfo.ConvertTimeFromUtc(dateTime, timeZone.TimeZoneInfo).TimeOfDay : time;
  }

  public DateTime ConvertFromTimeZoneToUTC(DateTime dateTime, TimeZone timeZone)
  {
    if (dateTime.Kind == DateTimeKind.Utc)
      return dateTime;
    if (dateTime.Kind == DateTimeKind.Local)
      dateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified);
    return timeZone.TimeZoneInfo != null ? TimeZoneInfo.ConvertTimeToUtc(dateTime, timeZone.TimeZoneInfo) : dateTime;
  }
}
