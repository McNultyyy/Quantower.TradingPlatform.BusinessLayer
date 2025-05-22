// Decompiled with JetBrains decompiler
// Type: 퓏.퓤
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

internal sealed class 퓤([In] Period obj0) : HistoryItemBarCreator(obj0)
{
  public override void FindBarBorders(
    DateTime dateTime,
    long sessionOffset,
    out long leftBorder,
    out long rightBorder)
  {
    DateTime dateTime1 = dateTime.AddHours(12.0);
    while (dateTime1.Month > 1)
      dateTime1 = dateTime1.AddMonths(-1);
    while (dateTime1.Day > 1)
      dateTime1 = dateTime1.AddDays(-1.0);
    DateTime dateTime2 = dateTime1.AddHours(-12.0);
    DateTime dateTime3 = dateTime2;
    for (int index = 0; index < this.targetPeriod.PeriodMultiplier; ++index)
      dateTime3 = dateTime3.AddDays(DateTime.IsLeapYear(dateTime1.Year) ? 366.0 : 365.0);
    leftBorder = dateTime2.Ticks;
    rightBorder = dateTime3.Ticks - 1L;
  }
}
