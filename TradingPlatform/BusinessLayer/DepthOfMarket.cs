// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.DepthOfMarket
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Integration;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>Represent access to level2 data.</summary>
[Published]
public class DepthOfMarket : IMessageBuilder<DOMQuote>
{
  private Dictionary<int, DepthOfMarketAggregatedCollections> 퓔;
  private readonly Symbol 픢;
  private readonly object 퓝;

  /// <summary>Gets Level2 Asks list</summary>
  internal 퓏.퓍 Asks { get; [param: In] private set; }

  /// <summary>Gets Level2 Bids list</summary>
  internal 퓏.퓍 Bids { get; [param: In] private set; }

  internal DepthOfMarket([In] Symbol obj0)
  {
    this.픢 = obj0;
    bool flag = Core.Instance.RulesManager.IsAllowed(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣(), this.픢.ConnectionId).Status == TradingOperationStatus.Allowed;
    this.Asks = new 퓏.퓍(QuotePriceType.Ask, flag);
    this.Bids = new 퓏.퓍(QuotePriceType.Bid, flag);
    this.퓝 = new object();
    this.퓔 = new Dictionary<int, DepthOfMarketAggregatedCollections>();
  }

  internal void 퓏([In] Level2Quote obj0)
  {
    lock (this.퓝)
    {
      if (obj0.PriceType == QuotePriceType.Ask)
        this.Asks.퓏(obj0);
      else
        this.Bids.퓏(obj0);
      this.퓔 = new Dictionary<int, DepthOfMarketAggregatedCollections>();
    }
  }

  internal void 퓏([In] DOMQuote obj0)
  {
    lock (this.퓝)
    {
      this.Asks.퓏((IEnumerable<Level2Quote>) obj0.Asks);
      this.Bids.퓏((IEnumerable<Level2Quote>) obj0.Bids);
      this.퓔 = new Dictionary<int, DepthOfMarketAggregatedCollections>();
    }
  }

  internal void 퓏()
  {
    lock (this.퓝)
    {
      this.Asks.퓏();
      this.Bids.퓏();
      this.퓔.Clear();
    }
  }

  /// <summary>Gets current Level2 data</summary>
  /// <param name="parameters">Parameters of DepthOfMarket</param>
  /// <returns></returns>
  public DepthOfMarketAggregatedCollections GetDepthOfMarketAggregatedCollections(
    GetDepthOfMarketParameters parameters = null)
  {
    if (parameters == (GetDepthOfMarketParameters) null)
      parameters = new GetDepthOfMarketParameters();
    lock (this.퓝)
    {
      int hashCode = parameters.GetHashCode();
      DepthOfMarketAggregatedCollections aggregatedCollections;
      if (!this.퓔.TryGetValue(hashCode, out aggregatedCollections))
      {
        aggregatedCollections = new DepthOfMarketAggregatedCollections()
        {
          Asks = this.Asks.퓏(parameters.GetLevel2ItemsParameters),
          Bids = this.Bids.퓏(parameters.GetLevel2ItemsParameters)
        };
        if (parameters.CalculateImbalancePercent)
          DepthOfMarket.퓏(aggregatedCollections.Asks, aggregatedCollections.Bids);
        this.퓔[hashCode] = aggregatedCollections;
      }
      return aggregatedCollections;
    }
  }

  /// <summary>Gets current Level2 data</summary>
  /// <param name="parameters">Parameters of request for Leve2Item collection</param>
  /// <returns></returns>
  public DepthOfMarketAggregatedCollections GetDepthOfMarketAggregatedCollections(
    GetLevel2ItemsParameters parameters)
  {
    return this.GetDepthOfMarketAggregatedCollections(new GetDepthOfMarketParameters()
    {
      GetLevel2ItemsParameters = parameters
    });
  }

  private static void 퓏([In] Level2Item[] obj0, [In] Level2Item[] obj1)
  {
    int num = Math.Min(obj1.Length, obj0.Length);
    for (int index = 0; index < num; ++index)
    {
      Level2Item level2Item1 = obj0[index];
      Level2Item level2Item2 = obj1[index];
      double cumulative1 = level2Item1.Cumulative;
      double cumulative2 = level2Item2.Cumulative;
      if (cumulative1 >= 0.0 && cumulative2 >= 0.0)
      {
        level2Item1.ImbalancePercent = Math.Round(level2Item1.Cumulative / (level2Item1.Cumulative + level2Item2.Cumulative) * 100.0, 2);
        level2Item2.ImbalancePercent = 100.0 - level2Item1.ImbalancePercent;
      }
    }
  }

  DOMQuote IMessageBuilder<DOMQuote>.퓬()
  {
    return new DOMQuote(this.픢.Id, Core.Instance.TimeUtils.DateTimeUtcNow)
    {
      Asks = this.Asks.Items.Values.ToList<Level2Quote>(),
      Bids = this.Bids.Items.Values.ToList<Level2Quote>()
    };
  }
}
