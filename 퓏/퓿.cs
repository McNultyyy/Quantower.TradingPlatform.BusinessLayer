// Decompiled with JetBrains decompiler
// Type: 퓏.퓿
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Collections.Generic;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer;

#nullable disable
namespace 퓏;

internal sealed class 퓿 : HistoricalData
{
  private readonly Synthetic 퓗픊;

  public 퓿([In] HistoryRequestParameters obj0)
    : base(obj0)
  {
    this.퓗픊 = (Synthetic) obj0.Symbol;
  }

  private protected override IList<IHistoryItem> 퓏([In] HistoryRequestParameters obj0)
  {
    if (this.퓗픊.SyntheticState != SyntheticState.Initialized)
      return (IList<IHistoryItem>) new List<IHistoryItem>();
    HistoryAggregation toDirectDownload = obj0.Aggregation.GetAggregationToDirectDownload(obj0.Symbol.HistoryMetadata);
    HistoryRequestParameters requestParameters1 = new HistoryRequestParameters(obj0)
    {
      Aggregation = toDirectDownload
    };
    if (this.퓗픊.ForceUseTicksForHistory)
    {
      switch (requestParameters1.Aggregation)
      {
        case HistoryAggregationTickBars aggregationTickBars1:
          HistoryRequestParameters requestParameters2 = requestParameters1;
          HistoryType historyType1;
          switch (aggregationTickBars1.HistoryType)
          {
            case HistoryType.Bid:
              historyType1 = HistoryType.BidAsk;
              break;
            case HistoryType.Ask:
              historyType1 = HistoryType.BidAsk;
              break;
            default:
              historyType1 = aggregationTickBars1.HistoryType;
              break;
          }
          requestParameters2.Aggregation = (HistoryAggregation) new HistoryAggregationTick(historyType1);
          break;
        case HistoryAggregationTime historyAggregationTime1:
          HistoryRequestParameters requestParameters3 = requestParameters1;
          HistoryType historyType2;
          switch (historyAggregationTime1.HistoryType)
          {
            case HistoryType.Bid:
              historyType2 = HistoryType.BidAsk;
              break;
            case HistoryType.Ask:
              historyType2 = HistoryType.BidAsk;
              break;
            default:
              historyType2 = historyAggregationTime1.HistoryType;
              break;
          }
          requestParameters3.Aggregation = (HistoryAggregation) new HistoryAggregationTick(historyType2);
          break;
      }
    }
    List<ISyntheticSynhroniserItem> syntheticSynhroniserItemList = new List<ISyntheticSynhroniserItem>();
    double[] numArray = new double[this.퓗픊.Items.Count];
    for (int index = 0; index < this.퓗픊.Items.Count; ++index)
    {
      numArray[index] = this.퓗픊.Items[index].Coefficient;
      HistoryRequestParameters historyRequestParameters = new HistoryRequestParameters(requestParameters1)
      {
        Symbol = this.퓗픊.Items[index].Symbol
      };
      if (this.퓗픊.Items[index].Coefficient < 0.0)
      {
        switch (historyRequestParameters.Aggregation)
        {
          case HistoryAggregationTickBars aggregationTickBars2:
            HistoryType historyType3;
            switch (aggregationTickBars2.HistoryType)
            {
              case HistoryType.Bid:
                historyType3 = HistoryType.Ask;
                break;
              case HistoryType.Ask:
                historyType3 = HistoryType.Bid;
                break;
              default:
                historyType3 = aggregationTickBars2.HistoryType;
                break;
            }
            HistoryType historyType4 = historyType3;
            requestParameters1.Aggregation = (HistoryAggregation) new HistoryAggregationTickBars(aggregationTickBars2.TicksCount, historyType4);
            break;
          case HistoryAggregationTime historyAggregationTime2:
            HistoryType historyType5;
            switch (historyAggregationTime2.HistoryType)
            {
              case HistoryType.Bid:
                historyType5 = HistoryType.Ask;
                break;
              case HistoryType.Ask:
                historyType5 = HistoryType.Bid;
                break;
              default:
                historyType5 = historyAggregationTime2.HistoryType;
                break;
            }
            HistoryType historyType6 = historyType5;
            requestParameters1.Aggregation = (HistoryAggregation) new HistoryAggregationTime(historyAggregationTime2.Period, historyType6);
            break;
        }
      }
      HistoricalData historicalData = new HistoricalData(historyRequestParameters);
      historicalData.Reload();
      if (historicalData.Count == 0)
        return (IList<IHistoryItem>) new List<IHistoryItem>();
      syntheticSynhroniserItemList.Add((ISyntheticSynhroniserItem) new 퓽()
      {
        HistoricalData = historicalData,
        SyntheticItem = this.퓗픊.Items[index]
      });
    }
    List<IHistoryItem> historyItemList = new List<IHistoryItem>();
    퓏.픂 픂 = new 퓏.픂(syntheticSynhroniserItemList, obj0.CancellationToken);
    do
    {
      IHistoryItem[] historyItemArray = new IHistoryItem[this.퓗픊.Items.Count];
      for (int index = 0; index < 픂.픁.Count; ++index)
        historyItemArray[index] = 픂.픁[index].HistoricalData[픂.픁[index].Position, SeekOriginHistory.Begin];
      IHistoryItem historyItem = 핂.퓏(numArray, historyItemArray, this.퓗픊.PriceModifier);
      HistoryItemBar historyItemBar = historyItem as HistoryItemBar;
      if ((object) historyItemBar == null)
      {
        HistoryItemTick historyItemTick = historyItem as HistoryItemTick;
        if ((object) historyItemTick == null)
        {
          HistoryItemLast historyItemLast = historyItem as HistoryItemLast;
          if ((object) historyItemLast == null)
          {
            if (historyItem is HistoryItemMark historyItemMark)
              historyItemMark.Price = this.Symbol.RoundPriceToTickSize(historyItemMark.Price);
          }
          else
            historyItemLast.Price = this.Symbol.RoundPriceToTickSize(historyItemLast.Price);
        }
        else
        {
          historyItemTick.Bid = this.Symbol.RoundPriceToTickSize(historyItemTick.Bid);
          historyItemTick.Ask = this.Symbol.RoundPriceToTickSize(historyItemTick.Ask);
        }
      }
      else
      {
        historyItemBar.Open = this.Symbol.RoundPriceToTickSize(historyItemBar.Open);
        historyItemBar.High = this.Symbol.RoundPriceToTickSize(historyItemBar.High);
        historyItemBar.Low = this.Symbol.RoundPriceToTickSize(historyItemBar.Low);
        historyItemBar.Close = this.Symbol.RoundPriceToTickSize(historyItemBar.Close);
      }
      historyItemList.Add(historyItem);
    }
    while (픂.퓏(obj0.CancellationToken));
    historyItemList.ProcessTickDirection(obj0.CancellationToken);
    return this.퓍퓹.AggregateHistory(new HistoryHolder((IList<IHistoryItem>) historyItemList, requestParameters1));
  }
}
