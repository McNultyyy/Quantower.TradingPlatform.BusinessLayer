// Decompiled with JetBrains decompiler
// Type: 퓏.퓷
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer;
using TradingPlatform.BusinessLayer.History.Storage;
using TradingPlatform.BusinessLayer.Utils;

#nullable enable
namespace 퓏;

internal sealed class 퓷 : HistoricalData
{
  private readonly 
  #nullable disable
  HistoryStorage 퓗퓱;

  public 퓷([In] HistoryRequestParameters obj0, [In] HistoryStorage obj1)
    : base(obj0)
  {
    this.퓗퓱 = obj1;
  }

  private protected override IList<IHistoryItem> 퓏([In] HistoryRequestParameters obj0_1)
  {
    List<IHistoryItem> historyItemList = new List<IHistoryItem>();
    if (this.퓗퓱 == null)
      return (IList<IHistoryItem>) historyItemList;
    if (!(obj0_1.Symbol is HistoricalSymbol symbol))
      return (IList<IHistoryItem>) historyItemList;
    if (obj0_1.FromTime > obj0_1.ToTime)
      return (IList<IHistoryItem>) historyItemList;
    HistoryAggregation toDirectDownload = obj0_1.Aggregation.GetAggregationToDirectDownload(obj0_1.Symbol.HistoryMetadata);
    if (toDirectDownload == null)
      return (IList<IHistoryItem>) historyItemList;
    HistoryRequestParameters requestParameters = new HistoryRequestParameters(obj0_1)
    {
      ForceReload = false,
      Aggregation = toDirectDownload
    };
    HistoryStorageInfo info = symbol.GetInfo(requestParameters.ToDescription(), HistoryStorageInfoScope.StoredIntervals);
    if (info == null || !info.StoredIntervals.Any<Interval<DateTime>>())
      return (IList<IHistoryItem>) historyItemList;
    DateTime from = info.StoredIntervals.First<Interval<DateTime>>().From;
    if (requestParameters.FromTime < from)
      requestParameters.FromTime = from;
    Interval<DateTime>[] array = requestParameters.Interval.Split(this.Symbol.GetHistoryDownloadingStep(requestParameters.Aggregation)).ToArray<Interval<DateTime>>();
    for (int index = 0; index < array.Length; ++index)
    {
      try
      {
        if (!obj0_1.CancellationToken.IsCancellationRequested)
        {
          HistoryRequestParameters copy = requestParameters.Copy;
          copy.FromTime = array[index].From;
          copy.ToTime = array[index].To;
          List<IHistoryItem> list = this.퓗퓱.Load(copy, out List<HistoryRequestParameters> _).SelectMany<HistoryInterval, IHistoryItem>((Func<HistoryInterval, IEnumerable<IHistoryItem>>) (([In] obj0_2) => (IEnumerable<IHistoryItem>) obj0_2.History)).ToList<IHistoryItem>();
          float num = (float) index / (float) array.Length;
          IList<IHistoryItem> collection = this.퓍퓹.AggregateHistory(new HistoryHolder((IList<IHistoryItem>) list, copy, (int) ((double) num * 100.0)));
          historyItemList.AddRange((IEnumerable<IHistoryItem>) collection);
          obj0_1.ProgressInfo?.Report(num);
        }
        else
          break;
      }
      catch (Exception ex)
      {
        Core.Instance.Loggers.Log(ex);
        return (IList<IHistoryItem>) historyItemList;
      }
    }
    return (IList<IHistoryItem>) historyItemList;
  }
}
