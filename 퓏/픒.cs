// Decompiled with JetBrains decompiler
// Type: 퓏.픒
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using TradingPlatform.BusinessLayer;
using TradingPlatform.BusinessLayer.Integration;

#nullable disable
namespace 퓏;

internal class 픒 : IDayBarUpdate
{
  public DateTime LastDayBarCreationTime { get; [param: In] private set; }

  public HistoryType UpdateHistoryType { get; [param: In] set; }

  internal string SymbolId => this.LastDayBar?.SymbolId;

  internal DayBar LastDayBar { get; [param: In] private set; }

  internal 픒([In] string obj0)
  {
    this.LastDayBar = new DayBar(obj0, Core.Instance.TimeUtils.DateTimeUtcNow);
  }

  internal void 퓏([In] CancellationToken obj0, [In] string obj1, [In] IList<IHistoryItem> obj2)
  {
    DayBar dayBar = (DayBar) null;
    try
    {
      if (obj0.IsCancellationRequested || obj2 == null || !obj2.Any<IHistoryItem>())
        return;
      IHistoryItem historyItem = obj2[obj2.Count - 1];
      if (historyItem == null)
        return;
      TimeSpan timeSpan = Core.Instance.TimeUtils.DateTimeUtcNow - historyItem.TimeLeft;
      this.LastDayBarCreationTime = historyItem.TimeLeft.AddDays((double) (int) timeSpan.TotalDays);
      dayBar = new DayBar(obj1, Core.Instance.TimeUtils.DateTimeUtcNow)
      {
        Open = historyItem[PriceType.Open],
        High = historyItem[PriceType.High],
        Low = historyItem[PriceType.Low],
        Volume = historyItem[PriceType.Volume],
        QuoteAssetVolume = historyItem[PriceType.QuoteAssetVolume]
      };
      if (this.UpdateHistoryType == HistoryType.Last)
        dayBar.Trades = (long) historyItem[PriceType.Ticks];
      else
        dayBar.Ticks = (long) historyItem[PriceType.Ticks];
      if (obj2.Count > 1)
        dayBar.PreviousClose = obj2[obj2.Count - 2][PriceType.Close];
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
    this.LastDayBar = dayBar;
  }

  public DayBar ProcessQuote(Quote quote1)
  {
    DayBar lastDayBar = this.LastDayBar;
    if (lastDayBar == null)
      return (DayBar) null;
    bool flag;
    switch (this.UpdateHistoryType)
    {
      case HistoryType.Bid:
        flag = 픒.퓏(lastDayBar, quote1.Bid);
        break;
      case HistoryType.Ask:
        flag = 픒.퓏(lastDayBar, quote1.Ask);
        break;
      case HistoryType.Midpoint:
        flag = 픒.퓏(lastDayBar, (quote1.Ask + quote1.Bid) / 2.0);
        break;
      default:
        flag = false;
        break;
    }
    return !flag ? (DayBar) null : lastDayBar;
  }

  public DayBar ProcessLast(Last last)
  {
    bool flag = false;
    DayBar lastDayBar = this.LastDayBar;
    if (lastDayBar == null)
      return (DayBar) null;
    if (this.UpdateHistoryType == HistoryType.Last)
      flag = 픒.퓏(lastDayBar, last.Price);
    return !flag ? (DayBar) null : lastDayBar;
  }

  public DayBar ProcessMark(Mark mark)
  {
    bool flag = false;
    DayBar lastDayBar = this.LastDayBar;
    if (lastDayBar == null)
      return (DayBar) null;
    if (this.UpdateHistoryType == HistoryType.Mark)
      flag = 픒.퓏(lastDayBar, mark.Price);
    return !flag ? (DayBar) null : lastDayBar;
  }

  private static bool 퓏([In] DayBar obj0, [In] double obj1)
  {
    bool flag = false;
    if (double.IsNaN(obj0.High) || obj0.High < obj1)
    {
      obj0.High = obj1;
      flag = true;
    }
    if (double.IsNaN(obj0.Low) || obj0.Low > obj1)
    {
      obj0.Low = obj1;
      flag = true;
    }
    return flag;
  }
}
