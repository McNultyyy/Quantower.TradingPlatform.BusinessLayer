// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.HistoricalSymbol
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.History.Storage;
using TradingPlatform.BusinessLayer.Integration;
using TradingPlatform.BusinessLayer.Serialization;
using TradingPlatform.BusinessLayer.Utils;
using 퓏;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public sealed class HistoricalSymbol : 
  CustomSymbol,
  IHistoryDataReceiver,
  IXElementSerialization,
  IHistoryStorage
{
  public const string HISTORICAL_SYMBOL_CONNECTION_ID = "HISTORICAL_SYMBOL_CONNECTION_ID";
  private string 퓞픽;
  private HistoryStorage 핅퓏;

  public HistoricalSymbol()
    : base(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓘())
  {
    this.Id = (string) null;
    this.퓏();
    this.Exchange = new Exchange(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓘());
    this.Exchange.퓏(new MessageExchange()
    {
      Id = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픿(),
      ExchangeName = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓖(),
      SortIndex = -1
    });
  }

  public void SetLocalStoragePath(string path)
  {
    if (this.퓞픽 == path)
      return;
    this.핅퓏?.Dispose();
    this.퓞픽 = path;
    this.핅퓏 = HistoryStorage.Create(this.퓞픽);
    this.퓏();
  }

  private new void 퓏()
  {
    if (string.IsNullOrEmpty(this.퓞픽))
    {
      this.historyMetadata = new HistoryMetadata();
    }
    else
    {
      HashSet<string> source1 = new HashSet<string>();
      HashSet<Period> source2 = new HashSet<Period>();
      HashSet<Period> source3 = new HashSet<Period>();
      HashSet<HistoryType> source4 = new HashSet<HistoryType>();
      HashSet<HistoryType> source5 = new HashSet<HistoryType>();
      foreach (HistoryDescription historyDescription in this.핅퓏.GetAllAvailableHistoryDescriptions())
      {
        HistoryStorageInfo info = this.핅퓏.GetInfo(historyDescription, HistoryStorageInfoScope.StoredIntervals);
        if (info.StoredIntervals != null && info.StoredIntervals.Any<Interval<DateTime>>())
        {
          source1.Add(historyDescription.Aggregation.Name);
          switch (historyDescription.Aggregation)
          {
            case HistoryAggregationTime historyAggregationTime:
              source2.Add(historyAggregationTime.Period);
              source4.Add(historyAggregationTime.HistoryType);
              continue;
            case HistoryAggregationTick historyAggregationTick:
              source5.Add(historyAggregationTick.HistoryType);
              continue;
            case HistoryAggregationTimeStatistics aggregationTimeStatistics:
              source3.Add(aggregationTimeStatistics.Period);
              continue;
            case HistoryAggregationVolumeProfile aggregationVolumeProfile:
              source3.Add(aggregationVolumeProfile.Period);
              continue;
            default:
              continue;
          }
        }
      }
      this.historyMetadata = new HistoryMetadata()
      {
        AllowedAggregations = source1.ToArray<string>(),
        AllowedPeriodsHistoryAggregationTime = source2.ToArray<Period>(),
        AllowedHistoryTypesHistoryAggregationTime = source4.ToArray<HistoryType>(),
        AllowedHistoryTypesHistoryAggregationTick = source5.ToArray<HistoryType>(),
        AllowedPeriodsHistoryAggregationTimeStatistics = source3.ToArray<Period>(),
        DownloadingStep_Tick = TimeSpan.FromDays(1.0)
      };
    }
  }

  private protected override HistoricalData 퓏([In] HistoryRequestParameters obj0)
  {
    return (HistoricalData) new 퓷(obj0, this.핅퓏);
  }

  public override List<OrderType> GetAlowedOrderTypes(OrderTypeUsage? usage)
  {
    return new List<OrderType>();
  }

  public IList<HistoryInterval> Load(
    HistoryRequestParameters requestParameters,
    out List<HistoryRequestParameters> historyParametersForServerRequest)
  {
    historyParametersForServerRequest = new List<HistoryRequestParameters>()
    {
      requestParameters
    };
    return this.핅퓏?.Load(requestParameters, out historyParametersForServerRequest);
  }

  public void Save(HistoryInterval historyInterval, bool wait = false)
  {
    if (this.핅퓏 == null)
      return;
    this.핅퓏.Save(historyInterval, wait);
    this.퓏();
  }

  public void Delete(HistoryDescription description, Interval<DateTime> interval, bool wait = false)
  {
    if (this.핅퓏 == null)
      return;
    this.핅퓏.Delete(description, interval, wait);
    this.핅퓏.퓏();
    this.퓏();
  }

  public HistoryStorageInfo GetInfo(HistoryDescription description, HistoryStorageInfoScope scope)
  {
    return this.핅퓏?.GetInfo(description, scope);
  }

  public List<HistoryDescription> GetAllAvailableHistoryDescriptions()
  {
    return this.핅퓏.GetAllAvailableHistoryDescriptions();
  }

  public XElement ToXElement()
  {
    XElement xelement = new XElement((XName) this.GetType().Name);
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓼(), (object) this.GetType().Name));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픵(), (object) this.퓞픽));
    MessageSymbol messageSymbol = ((IMessageBuilder<MessageSymbol>) this).BuildMessage();
    xelement.Add((object) messageSymbol.ToXElement());
    if (this.Product != null)
      xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픬(), (object) ((IMessageBuilder<MessageAsset>) this.Product).BuildMessage().ToXElement()));
    if (this.QuotingCurrency != null)
      xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓕(), (object) ((IMessageBuilder<MessageAsset>) this.QuotingCurrency).BuildMessage().ToXElement()));
    return xelement;
  }

  public void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    XElement xelement1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픵());
    if (xelement1 != null)
      this.SetLocalStoragePath(xelement1.Value);
    string name = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픐();
    XElement element1 = !(element.Name == (XName) name) ? element.Element((XName) name) : element;
    if (element1 != null)
    {
      MessageSymbol messageSymbol = new MessageSymbol(this.Id);
      messageSymbol.FromXElement(element1, deserializationInfo);
      this.퓏(messageSymbol);
    }
    XElement xelement2 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픬());
    if (xelement2 != null)
    {
      XElement element2 = xelement2.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓝());
      if (element2 != null)
      {
        Asset asset = new Asset(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓘());
        MessageAsset messageAsset = new MessageAsset();
        messageAsset.FromXElement(element2, deserializationInfo);
        asset.퓏(messageAsset);
        this.Product = asset;
      }
    }
    XElement xelement3 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓕());
    if (xelement3 != null)
    {
      XElement element3 = xelement3.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓝());
      if (element3 != null)
      {
        Asset asset = new Asset(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓘());
        MessageAsset messageAsset = new MessageAsset();
        messageAsset.FromXElement(element3, deserializationInfo);
        asset.퓏(messageAsset);
        this.QuotingCurrency = asset;
      }
    }
    this.퓏();
  }

  public void SaveHistory(HistoryHolder historyHolderFromProvider)
  {
    try
    {
      this.Save(new HistoryInterval()
      {
        Description = new HistoryDescription(this.Id, historyHolderFromProvider.RequestParameters.Aggregation),
        Interval = historyHolderFromProvider.RequestParameters.Interval,
        History = historyHolderFromProvider.History
      }, true);
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
  }
}
