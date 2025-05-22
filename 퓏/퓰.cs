// Decompiled with JetBrains decompiler
// Type: 퓏.퓰
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

internal sealed class 퓰([In] Period obj0) : HistoryItemBarCreator(obj0)
{
  public override void FindBarBorders(
    DateTime dateTime,
    long sessionOffset,
    out long leftBorder,
    out long rightBorder)
  {
    DateTime dateTime1 = dateTime;
    if (this.HistoryPeriod.BasePeriod == BasePeriod.Day)
    {
      if (this.targetPeriod.PeriodMultiplier > 1)
      {
        long num = dateTime.TimeOfDay.Ticks - 864000000000L;
        dateTime1 = this.FindNearestDateTimeFromUnixStartTime(dateTime.AddTicks(-num), sessionOffset);
        dateTime1 = dateTime1.AddTicks(num);
      }
    }
    else if (this.targetPeriod.PeriodMultiplier > 1)
      dateTime1 = this.FindNearestDateTimeFromUnixStartTime(dateTime, sessionOffset);
    DateTime dateTime2 = dateTime1.AddDays((double) this.targetPeriod.PeriodMultiplier);
    leftBorder = dateTime1.Ticks;
    rightBorder = dateTime2.Ticks - 1L;
  }
}
