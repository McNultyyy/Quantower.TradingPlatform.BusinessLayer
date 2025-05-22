// Decompiled with JetBrains decompiler
// Type: 퓏.픻
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

internal sealed class 픻([In] Period obj0) : HistoryItemBarCreator(obj0)
{
  public override void FindBarBorders(
    DateTime dateTime,
    long sessionOffset,
    out long leftBorder,
    out long rightBorder)
  {
    DateTime dateTime1;
    if (this.HistoryPeriod.BasePeriod != BasePeriod.Week)
    {
      DateTime dateTime2 = dateTime.AddHours(12.0);
      while (dateTime2.DayOfWeek != DayOfWeek.Monday)
        dateTime2 = dateTime2.AddDays(-1.0);
      dateTime1 = dateTime2.AddHours(-12.0);
    }
    else
      dateTime1 = this.FindNearestDateTimeFromUnixStartTime(dateTime, sessionOffset).AddTicks(dateTime.TimeOfDay.Ticks);
    DateTime dateTime3 = dateTime1.AddDays((double) (this.targetPeriod.PeriodMultiplier * 7));
    leftBorder = dateTime1.Ticks;
    rightBorder = dateTime3.Ticks - 1L;
  }

  protected override DateTime FindNearestDateTimeFromUnixStartTime(
    DateTime targetDateTime,
    long sessionOffset)
  {
    DateTime dateTime = new DateTime(621355968000000000L, DateTimeKind.Utc);
    dateTime = dateTime.AddDays((double) -((int) (dateTime.DayOfWeek + 6) % 7));
    long num = (targetDateTime.Ticks - (dateTime.Ticks + sessionOffset)) / this.targetPeriod.Ticks;
    return new DateTime(dateTime.Ticks + sessionOffset + num * this.targetPeriod.Ticks, targetDateTime.Kind);
  }
}
