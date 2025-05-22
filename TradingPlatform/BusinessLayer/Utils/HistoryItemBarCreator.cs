// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.HistoryItemBarCreator
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using 퓏;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils;

public abstract class HistoryItemBarCreator
{
  protected Period targetPeriod;

  public Period HistoryPeriod { get; set; }

  protected HistoryItemBarCreator(Period targetPeriod) => this.targetPeriod = targetPeriod;

  protected virtual DateTime FindNearestDateTimeFromUnixStartTime(
    DateTime targetDateTime,
    long sessionOffset)
  {
    long num1 = 621355968000000000;
    long num2 = (targetDateTime.Ticks - (num1 + sessionOffset)) / this.targetPeriod.Ticks;
    return new DateTime(num1 + sessionOffset + num2 * this.targetPeriod.Ticks, targetDateTime.Kind);
  }

  public static HistoryItemBarCreator CreateHistoryAggregator(Period targetPeriod)
  {
    HistoryItemBarCreator historyAggregator;
    switch (targetPeriod.BasePeriod)
    {
      case BasePeriod.Second:
        historyAggregator = (HistoryItemBarCreator) new 픝(targetPeriod);
        break;
      case BasePeriod.Minute:
        historyAggregator = (HistoryItemBarCreator) new 퓹(targetPeriod);
        break;
      case BasePeriod.Hour:
        historyAggregator = (HistoryItemBarCreator) new 픧(targetPeriod);
        break;
      case BasePeriod.Day:
        historyAggregator = (HistoryItemBarCreator) new 퓰(targetPeriod);
        break;
      case BasePeriod.Week:
        historyAggregator = (HistoryItemBarCreator) new 픻(targetPeriod);
        break;
      case BasePeriod.Month:
        historyAggregator = (HistoryItemBarCreator) new 퓛(targetPeriod);
        break;
      case BasePeriod.Year:
        historyAggregator = (HistoryItemBarCreator) new 퓤(targetPeriod);
        break;
      default:
        historyAggregator = (HistoryItemBarCreator) null;
        break;
    }
    return historyAggregator;
  }

  public abstract void FindBarBorders(
    DateTime dateTime,
    long sessionOffset,
    out long leftBorder,
    out long rightBorder);
}
