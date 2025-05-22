// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.Extensions.TimeSpanExtensions
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Runtime.CompilerServices;
using System.Text;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils.Extensions;

public static class TimeSpanExtensions
{
  public static string ToReadable(this TimeSpan timespan)
  {
    if (timespan.Ticks <= 0L)
      return (string) null;
    if (timespan.Days > 365)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 2);
      interpolatedStringHandler.AppendFormatted<int>(timespan.Days / 365);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픏());
      interpolatedStringHandler.AppendFormatted<int>(timespan.Days % 365);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓳());
      return interpolatedStringHandler.ToStringAndClear();
    }
    if (timespan.Days > 0)
      return timespan.ToString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲핆());
    if (timespan.Hours > 0)
      return timespan.ToString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픷());
    return timespan.Minutes > 0 ? timespan.ToString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓻()) : timespan.ToString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픸());
  }

  public static string ToReadableLong(this TimeSpan timespan)
  {
    if (timespan.Ticks <= 0L)
      return (string) null;
    StringBuilder stringBuilder1 = new StringBuilder();
    StringBuilder.AppendInterpolatedStringHandler interpolatedStringHandler;
    if (timespan.Days > 365)
    {
      StringBuilder stringBuilder2 = stringBuilder1;
      StringBuilder stringBuilder3 = stringBuilder2;
      interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(4, 2, stringBuilder2);
      interpolatedStringHandler.AppendFormatted<int>(timespan.Days / 365);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픏());
      interpolatedStringHandler.AppendFormatted<int>(timespan.Days % 365);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲프());
      ref StringBuilder.AppendInterpolatedStringHandler local = ref interpolatedStringHandler;
      stringBuilder3.Append(ref local);
    }
    if (timespan.Days > 0 && timespan.Days < 365)
    {
      StringBuilder stringBuilder4 = stringBuilder1;
      StringBuilder stringBuilder5 = stringBuilder4;
      interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(2, 1, stringBuilder4);
      interpolatedStringHandler.AppendFormatted<int>(timespan.Days);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲프());
      ref StringBuilder.AppendInterpolatedStringHandler local = ref interpolatedStringHandler;
      stringBuilder5.Append(ref local);
    }
    if (timespan.Hours > 0)
    {
      StringBuilder stringBuilder6 = stringBuilder1;
      StringBuilder stringBuilder7 = stringBuilder6;
      interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(2, 1, stringBuilder6);
      interpolatedStringHandler.AppendFormatted<int>(timespan.Hours);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픴());
      ref StringBuilder.AppendInterpolatedStringHandler local = ref interpolatedStringHandler;
      stringBuilder7.Append(ref local);
    }
    if (timespan.Minutes > 0)
    {
      StringBuilder stringBuilder8 = stringBuilder1;
      StringBuilder stringBuilder9 = stringBuilder8;
      interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(2, 1, stringBuilder8);
      interpolatedStringHandler.AppendFormatted<int>(timespan.Minutes);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픑());
      ref StringBuilder.AppendInterpolatedStringHandler local = ref interpolatedStringHandler;
      stringBuilder9.Append(ref local);
    }
    if (timespan.Seconds > 0)
    {
      StringBuilder stringBuilder10 = stringBuilder1;
      StringBuilder stringBuilder11 = stringBuilder10;
      interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(1, 1, stringBuilder10);
      interpolatedStringHandler.AppendFormatted<int>(timespan.Seconds);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픿());
      ref StringBuilder.AppendInterpolatedStringHandler local = ref interpolatedStringHandler;
      stringBuilder11.Append(ref local);
    }
    return stringBuilder1.ToString();
  }

  public static TimeSpan ConvertTimeZone(
    this TimeSpan timeSpan,
    TimeZoneInfo sourceTimeZone,
    TimeZoneInfo destinationTimeZone)
  {
    DateTime dateTime = DateTime.UtcNow;
    dateTime = dateTime.Date;
    dateTime = TimeZoneInfo.ConvertTime(new DateTime(dateTime.Ticks + timeSpan.Ticks, DateTimeKind.Unspecified), sourceTimeZone, destinationTimeZone);
    return dateTime.TimeOfDay;
  }
}
