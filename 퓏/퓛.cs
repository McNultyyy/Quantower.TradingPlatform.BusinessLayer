// Decompiled with JetBrains decompiler
// Type: 퓏.퓛
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace 퓏;

internal sealed class 퓛([In] Period obj0) : HistoryItemBarCreator(obj0)
{
  public override void FindBarBorders(
    DateTime dateTime,
    long sessionOffset,
    out long leftBorder,
    out long rightBorder)
  {
    DateTime dateTime1;
    if (this.HistoryPeriod.BasePeriod != BasePeriod.Month)
    {
      DateTime dateTime2 = dateTime.AddHours(12.0);
      while (dateTime2.Day > 1)
        dateTime2 = dateTime2.AddDays(-1.0);
      dateTime1 = dateTime2.AddHours(-12.0);
    }
    else
    {
      long num = (long) (dateTime.Day - 1) * 864000000000L + dateTime.TimeOfDay.Ticks;
      dateTime1 = this.FindNearestDateTimeFromUnixStartTime(dateTime.AddTicks(-num), sessionOffset).AddTicks(num);
    }
    DateTime dateTime3 = dateTime1;
    dateTime3 = dateTime3.AddMonths(this.targetPeriod.PeriodMultiplier);
    leftBorder = dateTime1.Ticks;
    rightBorder = dateTime3.Ticks - 1L;
  }

  protected override DateTime FindNearestDateTimeFromUnixStartTime(
    DateTime targetDateTime,
    long sessionOffset)
  {
    DateTime dateTime = new DateTime(621355968000000000L, DateTimeKind.Utc);
    while (dateTime <= targetDateTime)
      dateTime = dateTime.AddMonths(this.targetPeriod.PeriodMultiplier);
    return dateTime.AddMonths(-this.targetPeriod.PeriodMultiplier);
  }
}
