// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.HistoryItemExtensions
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Collections.Generic;
using System.Linq;
using System.Threading;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public static class HistoryItemExtensions
{
  public static void ProcessTickDirection(
    this IList<IHistoryItem> historyItems,
    CancellationToken cancellationToken)
  {
    if (historyItems == null || historyItems.Count == 0 || (object) (historyItems[0] as HistoryItemBar) != null)
      return;
    if ((object) (historyItems[0] as HistoryItemTick) != null)
    {
      double previousPrice1 = double.NaN;
      double previousPrice2 = double.NaN;
      TickDirection prevItemTickDirection1 = TickDirection.NotSet;
      TickDirection prevItemTickDirection2 = TickDirection.NotSet;
      foreach (HistoryItemTick historyItemTick in historyItems.OfType<HistoryItemTick>())
      {
        if (cancellationToken.IsCancellationRequested)
          break;
        historyItemTick.BidTickDirection = Symbol.DetermineTickDirection(previousPrice1, historyItemTick.Bid, prevItemTickDirection1);
        historyItemTick.AskTickDirection = Symbol.DetermineTickDirection(previousPrice2, historyItemTick.Ask, prevItemTickDirection2);
        previousPrice1 = historyItemTick.Bid;
        previousPrice2 = historyItemTick.Ask;
        prevItemTickDirection1 = historyItemTick.BidTickDirection;
        prevItemTickDirection2 = historyItemTick.AskTickDirection;
      }
    }
    else
    {
      double previousPrice = double.NaN;
      TickDirection prevItemTickDirection = TickDirection.NotSet;
      foreach (HistoryItemLast historyItemLast in historyItems.OfType<HistoryItemLast>())
      {
        if (cancellationToken.IsCancellationRequested)
          break;
        historyItemLast.TickDirection = Symbol.DetermineTickDirection(previousPrice, historyItemLast.Price, prevItemTickDirection);
        previousPrice = historyItemLast.Price;
        prevItemTickDirection = historyItemLast.TickDirection;
      }
    }
  }
}
