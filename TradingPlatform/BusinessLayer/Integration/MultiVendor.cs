// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.MultiVendor
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using TradingPlatform.BusinessLayer.Integration.Limitation;
using TradingPlatform.BusinessLayer.Utils;

#nullable enable
namespace TradingPlatform.BusinessLayer.Integration;

public abstract class MultiVendor : Vendor
{
  private readonly 
  #nullable disable
  Dictionary<string, ISymbolVendor> 퓞퓕;
  private readonly Dictionary<string, IQuoteVendor> 퓞픐;
  private readonly Dictionary<string, IHistoryVendor> 퓞픭;
  private readonly Dictionary<string, IVolumeAnalysisVendor> 퓞픔;
  protected readonly List<IVendor> AllVendors;
  private readonly Dictionary<string, string> 퓞핈;
  private readonly Dictionary<string, string> 퓞픤;
  private readonly Dictionary<string, string> 퓞퓟;
  private readonly Dictionary<string, string> 퓞핉;
  private readonly Dictionary<string, Map<string, string>> 퓞핊;
  private readonly Dictionary<string, Map<string, string>> 퓞픛;
  private readonly Dictionary<string, Map<string, string>> 퓞퓜;
  private readonly Dictionary<string, Map<string, string>> 퓞픺;
  private readonly Dictionary<string, VolumeAnalysisMetadata> 퓞핃;
  private readonly Dictionary<string, Map<string, string>> 퓞퓫;
  private readonly Dictionary<string, MessageExchange> 퓞핌;
  private readonly Dictionary<string, Map<string, string>> 퓞퓩;
  private readonly Dictionary<string, MessageSymbolGroup> 퓞퓨;
  private readonly Dictionary<string, HashSet<string>> 퓞퓱;

  protected ITradingVendor TradingVendor { get; [param: In] private set; }

  protected MultiVendor()
  {
    this.퓞퓕 = new Dictionary<string, ISymbolVendor>();
    this.퓞픐 = new Dictionary<string, IQuoteVendor>();
    this.퓞픭 = new Dictionary<string, IHistoryVendor>();
    this.퓞픔 = new Dictionary<string, IVolumeAnalysisVendor>();
    this.AllVendors = new List<IVendor>();
    this.퓞핈 = new Dictionary<string, string>();
    this.퓞픤 = new Dictionary<string, string>();
    this.퓞퓟 = new Dictionary<string, string>();
    this.퓞핉 = new Dictionary<string, string>();
    this.퓞핊 = new Dictionary<string, Map<string, string>>();
    this.퓞픛 = new Dictionary<string, Map<string, string>>();
    this.퓞퓜 = new Dictionary<string, Map<string, string>>();
    this.퓞픺 = new Dictionary<string, Map<string, string>>();
    this.퓞핃 = new Dictionary<string, VolumeAnalysisMetadata>();
    this.퓞퓫 = new Dictionary<string, Map<string, string>>();
    this.퓞핌 = new Dictionary<string, MessageExchange>();
    this.퓞퓩 = new Dictionary<string, Map<string, string>>();
    this.퓞퓨 = new Dictionary<string, MessageSymbolGroup>();
    this.퓞퓱 = new Dictionary<string, HashSet<string>>();
  }

  /// <summary>Performs a binding with broker or data provider</summary>
  public override ConnectionResult Connect(ConnectRequestParameters connectRequestParameters)
  {
    if (this.AllVendors.Count == 0)
      return ConnectionResult.CreateFail(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픶());
    foreach (IVendor allVendor in this.AllVendors)
    {
      try
      {
        ConnectionResult connectionResult = allVendor.Connect(connectRequestParameters);
        if (connectionResult.State == ConnectionState.Fail)
          return connectionResult;
      }
      catch (Exception ex)
      {
        Core.Instance.Loggers.Log(ex.InnerException ?? ex);
        return ConnectionResult.CreateFail(ex.GetMessageRecursive());
      }
    }
    return ConnectionResult.CreateSuccess(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓥());
  }

  /// <summary>
  /// Specifies any operation before breaking a connection with broker or data provider
  /// </summary>
  public override void Disconnect()
  {
    foreach (IVendor allVendor in this.AllVendors)
    {
      try
      {
        allVendor.Disconnect();
      }
      catch (Exception ex)
      {
        Core.Instance.Loggers.Log(ex);
      }
    }
  }

  /// <summary>
  /// Called when platform finished retreiving all required informations from vendor during connecting
  /// </summary>
  public override void OnConnected(CancellationToken token)
  {
    foreach (IVendor allVendor in this.AllVendors)
    {
      try
      {
        allVendor.OnConnected(token);
      }
      catch (Exception ex)
      {
        Core.Instance.Loggers.Log(ex);
      }
    }
  }

  /// <summary>
  /// Ping processing before its visualization in the terminal
  /// </summary>
  public override PingResult Ping()
  {
    PingResult pingResult1 = new PingResult()
    {
      State = PingEnum.Disconnected
    };
    double num1 = 0.0;
    double num2 = 0.0;
    foreach (IVendor allVendor in this.AllVendors)
    {
      PingResult pingResult2 = allVendor.Ping();
      if (pingResult2.State != PingEnum.Connected)
      {
        Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픀() + allVendor.Key + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픖());
        return pingResult2;
      }
      TimeSpan? nullable = pingResult2.PingTime;
      if (nullable.HasValue)
      {
        double val1 = num1;
        nullable = pingResult2.PingTime;
        double totalMilliseconds = nullable.Value.TotalMilliseconds;
        num1 = Math.Max(val1, totalMilliseconds);
      }
      nullable = pingResult2.RoundTripTime;
      if (nullable.HasValue)
      {
        double val1 = num2;
        nullable = pingResult2.RoundTripTime;
        double totalMilliseconds = nullable.Value.TotalMilliseconds;
        num2 = Math.Max(val1, totalMilliseconds);
      }
    }
    pingResult1.State = PingEnum.Connected;
    pingResult1.PingTime = new TimeSpan?(TimeSpan.FromMilliseconds(num1));
    pingResult1.RoundTripTime = new TimeSpan?(TimeSpan.FromMilliseconds(num2));
    return pingResult1;
  }

  public override LimitationMetadata GetLimitationMetadata()
  {
    return this.TradingVendor == null ? base.GetLimitationMetadata() : this.TradingVendor.GetLimitationMetadata();
  }

  /// <summary>
  /// Retrieves an information about available accounts. Yon need to specify at least one account
  /// </summary>
  public override IList<MessageAccount> GetAccounts(CancellationToken token)
  {
    return this.TradingVendor?.GetAccounts(token) ?? base.GetAccounts(token);
  }

  public override IList<MessageRule> GetRules(CancellationToken token)
  {
    if (this.TradingVendor != null)
      return this.TradingVendor.GetRules(token);
    return this.AllVendors.Where<IVendor>((Func<IVendor, bool>) (([In] obj0) => obj0 is Vendor)).FirstOrDefault<IVendor>() is Vendor vendor ? vendor.GetRules(token) : base.GetRules(token);
  }

  public override IList<MessageCryptoAssetBalances> GetCryptoAssetBalances(CancellationToken token)
  {
    return this.TradingVendor?.GetCryptoAssetBalances(token) ?? base.GetCryptoAssetBalances(token);
  }

  public override IList<MessageAccountOperation> GetAccountOperations(CancellationToken token)
  {
    return this.TradingVendor?.GetAccountOperations(token) ?? base.GetAccountOperations(token);
  }

  /// <summary>Confirms allowed nonfixed list by vendor</summary>
  public override bool AllowNonFixedList
  {
    get
    {
      return this.퓞퓕.Count == 0 ? base.AllowNonFixedList : this.퓞퓕.Values.Any<ISymbolVendor>((Func<ISymbolVendor, bool>) (([In] obj0) => obj0.AllowNonFixedList));
    }
  }

  public override IList<MessageSessionsContainer> GetSessions(CancellationToken token)
  {
    List<MessageSessionsContainer> sessions = new List<MessageSessionsContainer>();
    foreach (KeyValuePair<string, ISymbolVendor> keyValuePair in this.퓞퓕)
    {
      ISymbolVendor symbolVendor = keyValuePair.Value;
      foreach (MessageSessionsContainer session in (IEnumerable<MessageSessionsContainer>) symbolVendor.GetSessions(token))
      {
        MessageSessionsContainer sessionsContainer = this.퓏(symbolVendor.Key, session);
        sessions.Add(sessionsContainer);
      }
    }
    return (IList<MessageSessionsContainer>) sessions;
  }

  /// <summary>
  /// Retrieves a collection of available exchange markets from vendor
  /// </summary>
  public override IList<MessageExchange> GetExchanges(CancellationToken token)
  {
    List<MessageExchange> exchanges = new List<MessageExchange>();
    foreach (KeyValuePair<string, ISymbolVendor> keyValuePair in this.퓞퓕)
    {
      ISymbolVendor symbolVendor = keyValuePair.Value;
      foreach (MessageExchange exchange in (IEnumerable<MessageExchange>) symbolVendor.GetExchanges(token))
      {
        MessageExchange messageExchange = this.퓏(symbolVendor.Key, exchange);
        exchanges.Add(messageExchange);
      }
    }
    return (IList<MessageExchange>) exchanges;
  }

  /// <summary>Retrieves information about available assets.</summary>
  public override IList<MessageAsset> GetAssets(CancellationToken token)
  {
    if (this.퓞퓕.Count == 0)
      return base.GetAssets(token);
    List<MessageAsset> assets = new List<MessageAsset>();
    foreach (KeyValuePair<string, ISymbolVendor> keyValuePair in this.퓞퓕)
    {
      ISymbolVendor symbolVendor = keyValuePair.Value;
      foreach (MessageAsset asset in (IEnumerable<MessageAsset>) symbolVendor.GetAssets(token))
      {
        MessageAsset messageAsset = this.퓏(symbolVendor.Key, asset);
        assets.Add(messageAsset);
      }
    }
    return (IList<MessageAsset>) assets;
  }

  /// <summary>Retrieves information about available symbols.</summary>
  public override IList<MessageSymbol> GetSymbols(CancellationToken token)
  {
    if (this.퓞퓕.Count == 0)
      return base.GetSymbols(token);
    List<MessageSymbol> symbols = new List<MessageSymbol>();
    foreach (KeyValuePair<string, ISymbolVendor> keyValuePair in this.퓞퓕)
    {
      ISymbolVendor symbolVendor = keyValuePair.Value;
      foreach (MessageSymbol symbol in (IEnumerable<MessageSymbol>) symbolVendor.GetSymbols(token))
      {
        MessageSymbol messageSymbol = this.퓏(symbolVendor.Key, symbol);
        symbols.Add(messageSymbol);
      }
    }
    return (IList<MessageSymbol>) symbols;
  }

  /// <summary>Gets an available symbols types from vendor</summary>
  public override MessageSymbolTypes GetSymbolTypes(CancellationToken token)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    MultiVendor.퓬 퓬 = new MultiVendor.퓬();
    // ISSUE: reference to a compiler-generated field
    퓬.핅픢 = token;
    if (this.퓞퓕.Count == 0)
    {
      // ISSUE: reference to a compiler-generated field
      return base.GetSymbolTypes(퓬.핅픢);
    }
    // ISSUE: reference to a compiler-generated method
    List<SymbolType> list = this.퓞퓕.Values.Select<ISymbolVendor, MessageSymbolTypes>(new Func<ISymbolVendor, MessageSymbolTypes>(퓬.퓏)).SelectMany<MessageSymbolTypes, SymbolType>((Func<MessageSymbolTypes, IEnumerable<SymbolType>>) (([In] obj0) => (IEnumerable<SymbolType>) obj0.SymbolTypes)).Distinct<SymbolType>().ToList<SymbolType>();
    return new MessageSymbolTypes()
    {
      SymbolTypes = (IList<SymbolType>) list
    };
  }

  public override IList<MessageSymbolGroup> GetSymbolGroups(CancellationToken token)
  {
    List<MessageSymbolGroup> symbolGroups = new List<MessageSymbolGroup>();
    foreach (KeyValuePair<string, ISymbolVendor> keyValuePair in this.퓞퓕)
    {
      ISymbolVendor symbolVendor = keyValuePair.Value;
      foreach (MessageSymbolGroup symbolGroup in (IEnumerable<MessageSymbolGroup>) symbolVendor.GetSymbolGroups(token))
      {
        MessageSymbolGroup messageSymbolGroup = this.퓏(symbolVendor.Key, symbolGroup);
        symbolGroups.Add(messageSymbolGroup);
      }
    }
    return (IList<MessageSymbolGroup>) symbolGroups;
  }

  /// <summary>Derives a non fixed symbol from vendor</summary>
  public override MessageSymbol GetNonFixedSymbol(GetSymbolRequestParameters requestParameters)
  {
    string str1;
    ISymbolVendor symbolVendor;
    if (!this.퓏(requestParameters.SymbolId, out str1, out symbolVendor))
      return base.GetNonFixedSymbol(requestParameters);
    string str2;
    if (!this.퓏(str1, requestParameters.SymbolId, out str2))
      return base.GetNonFixedSymbol(requestParameters);
    requestParameters.SymbolId = str2;
    MessageSymbol nonFixedSymbol = symbolVendor.GetNonFixedSymbol(requestParameters);
    return this.퓏(str1, nonFixedSymbol);
  }

  /// <summary>Derives a non-fixed list of symbols from vendor</summary>
  public override IList<MessageSymbolInfo> SearchSymbols(
    SearchSymbolsRequestParameters requestParameters)
  {
    if (this.퓞퓕.Count == 0)
      return base.SearchSymbols(requestParameters);
    List<MessageSymbolInfo> messageSymbolInfoList = new List<MessageSymbolInfo>();
    foreach (KeyValuePair<string, ISymbolVendor> keyValuePair in this.퓞퓕)
    {
      string key = keyValuePair.Key;
      ISymbolVendor symbolVendor = keyValuePair.Value;
      SearchSymbolsRequestParameters requestParameters1 = requestParameters;
      IList<string> exchangeIds = requestParameters.ExchangeIds;
      if ((exchangeIds != null ? (exchangeIds.Count > 0 ? 1 : 0) : 0) != 0)
      {
        List<string> stringList = new List<string>();
        Map<string, string> map = this.퓞퓫[key];
        foreach (string exchangeId in (IEnumerable<string>) requestParameters.ExchangeIds)
        {
          string str;
          if (map.TryGetDirect(exchangeId, out str))
            stringList.Add(str);
          else
            stringList.Add(exchangeId);
        }
        requestParameters1 = new SearchSymbolsRequestParameters(requestParameters)
        {
          ExchangeIds = (IList<string>) stringList
        };
      }
      foreach (MessageSymbolInfo searchSymbol in (IEnumerable<MessageSymbolInfo>) symbolVendor.SearchSymbols(requestParameters1))
      {
        MessageSymbolInfo messageSymbolInfo = this.퓏(key, searchSymbol);
        messageSymbolInfoList.Add(messageSymbolInfo);
      }
    }
    return (IList<MessageSymbolInfo>) messageSymbolInfoList;
  }

  public override IList<MessageSymbolInfo> GetFutureContracts(
    GetFutureContractsRequestParameters requestParameters)
  {
    List<MessageSymbolInfo> futureContracts = new List<MessageSymbolInfo>();
    string exchangeId = requestParameters.ExchangeId;
    if (!string.IsNullOrEmpty(requestParameters.UnderlierId))
    {
      string underlierId = requestParameters.UnderlierId;
      string key;
      ISymbolVendor symbolVendor;
      string str1;
      string str2;
      if (this.퓏(underlierId, out key, out symbolVendor) && this.퓏(key, underlierId, out str1) && this.퓞퓫[key].TryGetDirect(exchangeId, out str2))
      {
        requestParameters.ExchangeId = str2;
        requestParameters.UnderlierId = str1;
        foreach (MessageSymbolInfo futureContract in (IEnumerable<MessageSymbolInfo>) symbolVendor.GetFutureContracts(requestParameters))
        {
          MessageSymbolInfo messageSymbolInfo = this.퓏(key, futureContract);
          futureContracts.Add(messageSymbolInfo);
        }
      }
    }
    else
    {
      HashSet<string> stringSet;
      if (!string.IsNullOrEmpty(requestParameters.Root) && this.퓞퓱.TryGetValue(requestParameters.Root, out stringSet))
      {
        foreach (string key in stringSet)
        {
          string str;
          if (this.퓞퓫[key].TryGetDirect(exchangeId, out str))
          {
            requestParameters.ExchangeId = str;
            foreach (MessageSymbolInfo futureContract in (IEnumerable<MessageSymbolInfo>) this.퓞퓕[key].GetFutureContracts(requestParameters))
            {
              MessageSymbolInfo messageSymbolInfo = this.퓏(key, futureContract);
              futureContracts.Add(messageSymbolInfo);
            }
          }
        }
      }
    }
    return (IList<MessageSymbolInfo>) futureContracts;
  }

  public override IList<MessageOptionSerie> GetOptionSeries(
    GetOptionSeriesRequestParameters requestParameters)
  {
    string key;
    ISymbolVendor symbolVendor;
    if (!this.퓏(requestParameters.UnderlierId, out key, out symbolVendor))
      return base.GetOptionSeries(requestParameters);
    string str1;
    if (!this.퓏(key, requestParameters.UnderlierId, out str1))
      return base.GetOptionSeries(requestParameters);
    requestParameters.UnderlierId = str1;
    string str2;
    if (this.퓞퓫[key].TryGetDirect(requestParameters.ExchangeId, out str2))
      requestParameters.ExchangeId = str2;
    IList<MessageOptionSerie> optionSeries1 = symbolVendor.GetOptionSeries(requestParameters);
    List<MessageOptionSerie> optionSeries2 = new List<MessageOptionSerie>();
    foreach (MessageOptionSerie messageOptionSerie1 in (IEnumerable<MessageOptionSerie>) optionSeries1)
    {
      MessageOptionSerie messageOptionSerie2 = this.퓏(key, messageOptionSerie1);
      optionSeries2.Add(messageOptionSerie2);
    }
    return (IList<MessageOptionSerie>) optionSeries2;
  }

  public override IList<MessageSymbolInfo> GetStrikes(GetStrikesRequestParameters requestParameters)
  {
    string vendorKey;
    ISymbolVendor symbolVendor;
    if (!this.퓏(requestParameters.UnderlierId, out vendorKey, out symbolVendor))
      return base.GetStrikes(requestParameters);
    string str;
    if (!this.퓏(vendorKey, requestParameters.UnderlierId, out str))
      return base.GetStrikes(requestParameters);
    requestParameters.UnderlierId = str;
    requestParameters.SerieId = MultiVendor.ParseLocalId(vendorKey, requestParameters.SerieId);
    IList<MessageSymbolInfo> strikes1 = symbolVendor.GetStrikes(requestParameters);
    List<MessageSymbolInfo> strikes2 = new List<MessageSymbolInfo>();
    foreach (MessageSymbolInfo messageSymbolInfo1 in (IEnumerable<MessageSymbolInfo>) strikes1)
    {
      MessageSymbolInfo messageSymbolInfo2 = this.퓏(vendorKey, messageSymbolInfo1);
      strikes2.Add(messageSymbolInfo2);
    }
    return (IList<MessageSymbolInfo>) strikes2;
  }

  /// <summary>Retrieves allowed/supported order types</summary>
  public override IList<OrderType> GetAllowedOrderTypes(CancellationToken token)
  {
    return this.TradingVendor?.GetAllowedOrderTypes(token) ?? base.GetAllowedOrderTypes(token);
  }

  /// <summary>
  /// Retrieves an information about opened orders at the time of connection.
  /// </summary>
  public override IList<MessageOpenOrder> GetPendingOrders(CancellationToken token)
  {
    return this.TradingVendor?.GetPendingOrders(token) ?? base.GetPendingOrders(token);
  }

  /// <summary>
  /// Retrieves an information about positions at the time of connection
  /// </summary>
  public override IList<MessageOpenPosition> GetPositions(CancellationToken token)
  {
    return this.TradingVendor?.GetPositions(token) ?? base.GetPositions(token);
  }

  public override TradesHistoryMetadata GetTradesMetadata()
  {
    return this.TradingVendor?.GetTradesMetadata() ?? base.GetTradesMetadata();
  }

  /// <summary>
  /// Gets trades history from server for requested time range
  /// </summary>
  public override IList<MessageTrade> GetTrades(TradesHistoryRequestParameters parameters)
  {
    return this.TradingVendor?.GetTrades(parameters) ?? base.GetTrades(parameters);
  }

  public override void GetTrades(
    TradesHistoryRequestParameters parameters,
    AccountTradesLoadingCallback callback)
  {
    if (this.TradingVendor != null)
      this.TradingVendor.GetTrades(parameters, callback);
    else
      base.GetTrades(parameters, callback);
  }

  public override IList<MessageOrderHistory> GetOrdersHistory(
    OrdersHistoryRequestParameters parameters)
  {
    return this.TradingVendor?.GetOrdersHistory(parameters) ?? base.GetOrdersHistory(parameters);
  }

  public override PnL CalculatePnL(PnLRequestParameters parameters)
  {
    return this.TradingVendor?.CalculatePnL(parameters) ?? base.CalculatePnL(parameters);
  }

  /// <summary>Subscribing to quote data: Level1/Level2/Trade</summary>
  public override void SubscribeSymbol(SubscribeQuotesParameters parameters)
  {
    string str;
    IQuoteVendor quoteVendor1;
    string symbolId;
    if (!this.퓏(parameters.SymbolId, out str, out quoteVendor1) || !this.퓬(str, parameters.SymbolId, out symbolId))
      return;
    IQuoteVendor quoteVendor2 = quoteVendor1;
    SubscribeQuotesParameters parameters1 = new SubscribeQuotesParameters(symbolId, parameters.SubscribeType);
    parameters1.CancellationToken = parameters.CancellationToken;
    quoteVendor2.SubscribeSymbol(parameters1);
  }

  /// <summary>Unsubscribing from quote data: Level1/Level2/Trade</summary>
  public override void UnSubscribeSymbol(SubscribeQuotesParameters parameters)
  {
    string str;
    IQuoteVendor quoteVendor1;
    string symbolId;
    if (!this.퓏(parameters.SymbolId, out str, out quoteVendor1) || !this.퓬(str, parameters.SymbolId, out symbolId))
      return;
    IQuoteVendor quoteVendor2 = quoteVendor1;
    SubscribeQuotesParameters parameters1 = new SubscribeQuotesParameters(symbolId, parameters.SubscribeType);
    parameters1.CancellationToken = parameters.CancellationToken;
    quoteVendor2.UnSubscribeSymbol(parameters1);
  }

  /// <summary>
  /// Gets a list of supported historical intervals and data types by vendor
  /// </summary>
  public override HistoryMetadata GetHistoryMetadata(CancellationToken cancelationToken)
  {
    Dictionary<string, HistoryMetadata> source = new Dictionary<string, HistoryMetadata>();
    foreach (KeyValuePair<string, IHistoryVendor> keyValuePair in this.퓞픭)
    {
      try
      {
        HistoryMetadata historyMetadata = keyValuePair.Value.GetHistoryMetadata(cancelationToken);
        source.Add(keyValuePair.Key, historyMetadata);
      }
      catch (Exception ex)
      {
        Core.Instance.Loggers.Log(ex.InnerException ?? ex);
      }
    }
    return new HistoryMetadata()
    {
      AllowedAggregations = source.SelectMany<KeyValuePair<string, HistoryMetadata>, string>((Func<KeyValuePair<string, HistoryMetadata>, IEnumerable<string>>) (([In] obj0) => (IEnumerable<string>) obj0.Value.AllowedAggregations)).Distinct<string>().ToArray<string>(),
      AllowedPeriodsHistoryAggregationTime = source.SelectMany<KeyValuePair<string, HistoryMetadata>, Period>((Func<KeyValuePair<string, HistoryMetadata>, IEnumerable<Period>>) (([In] obj0) => (IEnumerable<Period>) obj0.Value.AllowedPeriodsHistoryAggregationTime)).Distinct<Period>().ToArray<Period>(),
      AllowedHistoryTypesHistoryAggregationTime = source.SelectMany<KeyValuePair<string, HistoryMetadata>, HistoryType>((Func<KeyValuePair<string, HistoryMetadata>, IEnumerable<HistoryType>>) (([In] obj0) => (IEnumerable<HistoryType>) obj0.Value.AllowedHistoryTypesHistoryAggregationTime)).Distinct<HistoryType>().ToArray<HistoryType>(),
      AllowedHistoryTypesHistoryAggregationTick = source.SelectMany<KeyValuePair<string, HistoryMetadata>, HistoryType>((Func<KeyValuePair<string, HistoryMetadata>, IEnumerable<HistoryType>>) (([In] obj0) => (IEnumerable<HistoryType>) obj0.Value.AllowedHistoryTypesHistoryAggregationTick)).Distinct<HistoryType>().ToArray<HistoryType>(),
      DownloadingStep_Day = source.Min<KeyValuePair<string, HistoryMetadata>, TimeSpan>((Func<KeyValuePair<string, HistoryMetadata>, TimeSpan>) (([In] obj0) => obj0.Value.DownloadingStep_Day)),
      DownloadingStep_Minute = source.Min<KeyValuePair<string, HistoryMetadata>, TimeSpan>((Func<KeyValuePair<string, HistoryMetadata>, TimeSpan>) (([In] obj0) => obj0.Value.DownloadingStep_Minute)),
      DownloadingStep_Tick = source.Min<KeyValuePair<string, HistoryMetadata>, TimeSpan>((Func<KeyValuePair<string, HistoryMetadata>, TimeSpan>) (([In] obj0) => obj0.Value.DownloadingStep_Tick)),
      BuildUncompletedBars = source.Any<KeyValuePair<string, HistoryMetadata>>((Func<KeyValuePair<string, HistoryMetadata>, bool>) (([In] obj0) => obj0.Value.BuildUncompletedBars))
    };
  }

  public override IList<IHistoryItem> LoadHistory(HistoryRequestParameters requestParameters)
  {
    List<IHistoryItem> historyItemList = new List<IHistoryItem>();
    string str1;
    IHistoryVendor historyVendor;
    if (!this.퓏(requestParameters.SymbolId, out str1, out historyVendor))
      return (IList<IHistoryItem>) historyItemList;
    string str2;
    if (!this.핇(str1, requestParameters.SymbolId, out str2))
      return (IList<IHistoryItem>) historyItemList;
    return historyVendor.LoadHistory(new HistoryRequestParameters(requestParameters)
    {
      SymbolId = str2
    });
  }

  public override VolumeAnalysisMetadata GetVolumeAnalysisMetadata()
  {
    if (this.퓞픔.Count == 0)
      return base.GetVolumeAnalysisMetadata();
    foreach (KeyValuePair<string, IVolumeAnalysisVendor> keyValuePair in this.퓞픔)
    {
      try
      {
        VolumeAnalysisMetadata analysisMetadata = keyValuePair.Value.GetVolumeAnalysisMetadata();
        this.퓞핃.Add(keyValuePair.Key, analysisMetadata);
      }
      catch (Exception ex)
      {
        Core.Instance.Loggers.Log(ex.GetMessageRecursive());
      }
    }
    VolumeAnalysisAvailability analysisAvailability = this.퓞핃.Any<KeyValuePair<string, VolumeAnalysisMetadata>>((Func<KeyValuePair<string, VolumeAnalysisMetadata>, bool>) (([In] obj0) => obj0.Value.IsVolumeAnalysisAvailable)) ? VolumeAnalysisAvailability.Available : VolumeAnalysisAvailability.NotAvailable;
    bool flag = this.퓞핃.Values.Any<VolumeAnalysisMetadata>((Func<VolumeAnalysisMetadata, bool>) (([In] obj0) => obj0.BuildUncompletedBars));
    TimeSpan timeSpan = this.퓞핃.Values.Max<VolumeAnalysisMetadata, TimeSpan>((Func<VolumeAnalysisMetadata, TimeSpan>) (([In] obj0) => obj0.MaxTicksLoadingPeriod));
    Dictionary<Period, TimeSpan> dictionary1 = new Dictionary<Period, TimeSpan>();
    Dictionary<Period, TimeSpan> dictionary2 = new Dictionary<Period, TimeSpan>();
    if (analysisAvailability == VolumeAnalysisAvailability.Available)
    {
      foreach (VolumeAnalysisMetadata analysisMetadata in this.퓞핃.Values)
      {
        MultiVendor.퓏(analysisMetadata.GetDownloadingStepByPeriod(false), (IDictionary<Period, TimeSpan>) dictionary1);
        MultiVendor.퓏(analysisMetadata.GetDownloadingStepByPeriod(true), (IDictionary<Period, TimeSpan>) dictionary2);
      }
    }
    return new VolumeAnalysisMetadata()
    {
      VolumeAnalysisAvailability = analysisAvailability,
      BuildUncompletedBars = flag,
      MaxTicksLoadingPeriod = timeSpan,
      DownloadingStepByPeriod = dictionary1,
      DownloadingLevelsStepByPeriod = dictionary2
    };
  }

  public override VendorVolumeAnalysisByPeriodResponse LoadVolumeAnalysis(
    VolumeAnalysisByPeriodRequestParameters requestParameters)
  {
    string key;
    IVolumeAnalysisVendor volumeAnalysisVendor;
    if (!this.퓏(requestParameters.SymbolId, out key, out volumeAnalysisVendor))
      return (VendorVolumeAnalysisByPeriodResponse) null;
    VolumeAnalysisMetadata analysisMetadata;
    if (!this.퓞핃.TryGetValue(key, out analysisMetadata))
      return (VendorVolumeAnalysisByPeriodResponse) null;
    if (!((IEnumerable<Period>) analysisMetadata.GetAllowedPeriods(requestParameters.CalculatePriceLevels)).Contains<Period>(requestParameters.Period))
      return (VendorVolumeAnalysisByPeriodResponse) null;
    string str;
    if (!this.퓲(key, requestParameters.SymbolId, out str))
      return (VendorVolumeAnalysisByPeriodResponse) null;
    VolumeAnalysisByPeriodRequestParameters copy = requestParameters.Copy;
    copy.SymbolId = str;
    return volumeAnalysisVendor.LoadVolumeAnalysis(copy);
  }

  /// <summary>Prepare and sending order placing request to broker</summary>
  public override TradingOperationResult PlaceOrder(PlaceOrderRequestParameters parameters)
  {
    return this.TradingVendor?.PlaceOrder(parameters) ?? base.PlaceOrder(parameters);
  }

  public override TradingOperationResult PlaceMultiOrder(
    PlaceMultiOrderOrderRequestParameters parameters)
  {
    return this.TradingVendor?.PlaceMultiOrder(parameters) ?? base.PlaceMultiOrder(parameters);
  }

  /// <summary>Sending order modification request to broker</summary>
  public override TradingOperationResult ModifyOrder(ModifyOrderRequestParameters parameters)
  {
    return this.TradingVendor?.ModifyOrder(parameters) ?? base.ModifyOrder(parameters);
  }

  /// <summary>Sending order cancellation request to broker</summary>
  public override TradingOperationResult CancelOrder(CancelOrderRequestParameters parameters)
  {
    return this.TradingVendor?.CancelOrder(parameters) ?? base.CancelOrder(parameters);
  }

  /// <summary>Sending position closing request to broker</summary>
  public override TradingOperationResult ClosePosition(ClosePositionRequestParameters parameters)
  {
    return this.TradingVendor?.ClosePosition(parameters) ?? base.ClosePosition(parameters);
  }

  public override MarginInfo GetMarginInfo(OrderRequestParameters orderRequestParameters)
  {
    return this.TradingVendor?.GetMarginInfo(orderRequestParameters) ?? base.GetMarginInfo(orderRequestParameters);
  }

  /// <summary>Gets information about available reports from vendor</summary>
  public override IList<MessageReportType> GetReportsMetaData(CancellationToken token)
  {
    return this.TradingVendor?.GetReportsMetaData(token) ?? base.GetReportsMetaData(token);
  }

  /// <summary>
  /// Called when platform need to generate particular report
  /// </summary>
  public override Report GenerateReport(ReportRequestParameters reportRequestParameters)
  {
    return this.TradingVendor?.GenerateReport(reportRequestParameters) ?? base.GenerateReport(reportRequestParameters);
  }

  private MessageSessionsContainer 퓏([In] string obj0, [In] MessageSessionsContainer obj1)
  {
    obj1.Id = this.CreateGlobalId(obj0, obj1.Id);
    return obj1;
  }

  private MessageExchange 퓏([In] string obj0, [In] MessageExchange obj1)
  {
    MessageExchange messageExchange;
    if (!this.퓞핌.TryGetValue(obj1.ExchangeName, out messageExchange))
    {
      messageExchange = new MessageExchange()
      {
        Id = this.퓞핌.Count.ToString(),
        ExchangeName = obj1.ExchangeName
      };
      this.퓞핌.Add(messageExchange.ExchangeName, messageExchange);
    }
    if (!string.IsNullOrEmpty(obj1.SessionsContainerId))
      messageExchange.SessionsContainerId = this.CreateGlobalId(obj0, obj1.SessionsContainerId);
    Map<string, string> map;
    if (!this.퓞퓫.TryGetValue(obj0, out map))
      this.퓞퓫.Add(obj0, map = new Map<string, string>());
    if (!map.ContainsDirect(messageExchange.Id))
      map.Add(messageExchange.Id, obj1.Id);
    return messageExchange;
  }

  private MessageSymbolGroup 퓏([In] string obj0, [In] MessageSymbolGroup obj1)
  {
    MessageSymbolGroup messageSymbolGroup;
    if (!this.퓞퓨.TryGetValue(obj1.GroupName, out messageSymbolGroup))
      this.퓞퓨.Add(obj1.GroupName, messageSymbolGroup = obj1);
    Map<string, string> map;
    if (!this.퓞퓩.TryGetValue(obj0, out map))
      this.퓞퓩.Add(obj0, map = new Map<string, string>());
    if (!map.ContainsDirect(messageSymbolGroup.Id))
      map.Add(messageSymbolGroup.Id, obj1.Id);
    return messageSymbolGroup;
  }

  private MessageSymbolInfo 퓏([In] string obj0, [In] MessageSymbolInfo obj1)
  {
    Map<string, string> map;
    if (!this.퓞퓫.TryGetValue(obj0, out map))
      return (MessageSymbolInfo) null;
    string str;
    if (!map.TryGetReverse(obj1.ExchangeId, out str))
      return (MessageSymbolInfo) null;
    MessageSymbolInfo messageSymbolInfo = new MessageSymbolInfo(obj1)
    {
      Id = this.CreateGlobalId(obj0, obj1.Id),
      ExchangeId = str
    };
    if (!string.IsNullOrEmpty(messageSymbolInfo.Root))
    {
      HashSet<string> stringSet;
      if (!this.퓞퓱.TryGetValue(messageSymbolInfo.Root, out stringSet))
        this.퓞퓱.Add(messageSymbolInfo.Root, stringSet = new HashSet<string>());
      stringSet.Add(obj0);
    }
    if (!string.IsNullOrEmpty(messageSymbolInfo.UnderlierId))
      messageSymbolInfo.UnderlierId = this.CreateGlobalId(obj0, obj1.UnderlierId);
    return messageSymbolInfo;
  }

  private MessageSymbol 퓏([In] string obj0_1, [In] MessageSymbol obj1)
  {
    MessageSymbolInfo messageSymbolInfo = this.퓏(obj0_1, (MessageSymbolInfo) obj1);
    MessageSymbol messageSymbol = new MessageSymbol(obj1);
    messageSymbol.Fill(messageSymbolInfo);
    if (!string.IsNullOrEmpty(messageSymbol.ProductAssetId))
      messageSymbol.ProductAssetId = this.CreateGlobalId(obj0_1, messageSymbol.ProductAssetId);
    if (!string.IsNullOrEmpty(messageSymbol.QuotingCurrencyAssetID))
      messageSymbol.QuotingCurrencyAssetID = this.CreateGlobalId(obj0_1, messageSymbol.QuotingCurrencyAssetID);
    if (!string.IsNullOrEmpty(messageSymbol.SessionsContainerId))
      messageSymbol.SessionsContainerId = this.CreateGlobalId(obj0_1, messageSymbol.SessionsContainerId);
    if (!string.IsNullOrEmpty(messageSymbol.GroupId))
    {
      Map<string, string> map;
      if (!this.퓞퓩.TryGetValue(obj0_1, out map))
        return (MessageSymbol) null;
      string str;
      if (!map.TryGetReverse(messageSymbol.GroupId, out str))
        return (MessageSymbol) null;
      messageSymbol.GroupId = str;
    }
    if (messageSymbol.SymbolAdditionalInfo != null)
    {
      AdditionalInfoItem additionalInfoItem = messageSymbol.SymbolAdditionalInfo.FirstOrDefault<AdditionalInfoItem>((Func<AdditionalInfoItem, bool>) (([In] obj0_2) => obj0_2.Id == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픈()));
      if (additionalInfoItem != null && additionalInfoItem.Value != null)
        additionalInfoItem.Value = (object) this.CreateGlobalId(obj0_1, additionalInfoItem.Value.ToString());
    }
    return messageSymbol;
  }

  private MessageAsset 퓏([In] string obj0, [In] MessageAsset obj1)
  {
    obj1.Id = this.CreateGlobalId(obj0, obj1.Id);
    return obj1;
  }

  private MessageOptionSerie 퓏([In] string obj0, [In] MessageOptionSerie obj1)
  {
    Map<string, string> map;
    if (!this.퓞퓫.TryGetValue(obj0, out map))
      return (MessageOptionSerie) null;
    string str;
    if (!map.TryGetReverse(obj1.ExchangeId, out str))
      return (MessageOptionSerie) null;
    obj1.Id = this.CreateGlobalId(obj0, obj1.Id);
    obj1.UnderlierId = this.CreateGlobalId(obj0, obj1.UnderlierId);
    obj1.ExchangeId = str;
    return obj1;
  }

  private MessageQuote 퓏([In] string obj0, [In] MessageQuote obj1)
  {
    Map<string, string> map;
    if (!this.퓞픛.TryGetValue(obj0, out map))
      return (MessageQuote) null;
    string str;
    if (!map.TryGetReverse(obj1.SymbolId, out str))
      return (MessageQuote) null;
    obj1.SymbolId = str;
    return obj1;
  }

  public override void SendCustomRequest(RequestParameters parameters)
  {
    foreach (IVendor allVendor in this.AllVendors)
    {
      try
      {
        allVendor.SendCustomRequest(parameters);
      }
      catch (Exception ex)
      {
        Core.Instance.Loggers.Log(ex);
      }
    }
  }

  protected void RegisterTradingVendor(ITradingVendor tradingVendor)
  {
    if (this.TradingVendor != null)
      throw new InvalidOperationException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓘());
    this.TradingVendor = tradingVendor ?? throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픓());
    this.퓏<ITradingVendor>(tradingVendor);
  }

  protected void RegisterSymbolVendor(ISymbolVendor symbolVendor)
  {
    this.퓏<ISymbolVendor>(symbolVendor.Key, symbolVendor, this.퓞퓕, this.퓞핊);
  }

  protected void RegisterQuoteVendor(IQuoteVendor quoteVendor)
  {
    this.퓏<IQuoteVendor>(quoteVendor.Key, quoteVendor, this.퓞픐, this.퓞픛);
  }

  protected void RegisterHistoryVendor(IHistoryVendor historyVendor)
  {
    this.퓏<IHistoryVendor>(historyVendor.Key, historyVendor, this.퓞픭, this.퓞퓜);
  }

  protected void RegisterVolumeAnalysisVendor(IVolumeAnalysisVendor volumeAnalysisVendor)
  {
    this.퓏<IVolumeAnalysisVendor>(volumeAnalysisVendor.Key, volumeAnalysisVendor, this.퓞픔, this.퓞픺);
  }

  private void 퓏<퓏>(
    [In] string obj0,
    [In] 퓏 obj1,
    [In] Dictionary<string, 퓏> obj2,
    [In] Dictionary<string, Map<string, string>> obj3)
    where 퓏 : IVendor
  {
    if ((object) obj1 == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픩());
    obj2.Add(obj0, obj1);
    obj3.Add(obj0, new Map<string, string>());
    this.퓏<퓏>(obj1);
  }

  private void 퓏<퓏>([In] 퓏 obj0) where 퓏 : IVendor
  {
    if ((object) obj0 == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픩());
    if (this.AllVendors.Contains((IVendor) obj0))
      return;
    ref 퓏 local = ref obj0;
    if ((object) default (퓏) == null)
    {
      퓏 퓏 = local;
      local = ref 퓏;
    }
    EventHandler<VendorEventArgs> eventHandler = new EventHandler<VendorEventArgs>(this.퓏);
    local.NewMessage += eventHandler;
    this.AllVendors.Add((IVendor) obj0);
  }

  private void 퓏([In] object obj0, [In] VendorEventArgs obj1)
  {
    if (obj1.Message == null)
      return;
    Message msg = (Message) null;
    switch (obj1.Message)
    {
      case MessageExchange messageExchange:
        msg = (Message) this.퓏(obj1.VendorKey, messageExchange);
        break;
      case MessageSymbolGroup messageSymbolGroup:
        msg = (Message) this.퓏(obj1.VendorKey, messageSymbolGroup);
        break;
      case MessageSymbol messageSymbol:
        msg = (Message) this.퓏(obj1.VendorKey, messageSymbol);
        break;
      case MessageSymbolInfo messageSymbolInfo:
        msg = (Message) this.퓏(obj1.VendorKey, messageSymbolInfo);
        break;
      case MessageAsset messageAsset:
        msg = (Message) this.퓏(obj1.VendorKey, messageAsset);
        break;
      case MessageOptionSerie messageOptionSerie:
        msg = (Message) this.퓏(obj1.VendorKey, messageOptionSerie);
        break;
      case MessageQuote messageQuote:
        msg = (Message) this.퓏(obj1.VendorKey, messageQuote);
        break;
      default:
        this.PushMessage(obj1.Message);
        break;
    }
    if (msg == null)
      return;
    this.PushMessage(msg);
  }

  protected virtual string GetSymbolVendorKey(string globalSymbolId)
  {
    return MultiVendor.ParseVendorKey(globalSymbolId);
  }

  protected virtual string GetQuoteVendorKey(string globalSymbolId)
  {
    return MultiVendor.ParseVendorKey(globalSymbolId);
  }

  protected virtual string GetHistoryVendorKey(string globalSymbolId)
  {
    return MultiVendor.ParseVendorKey(globalSymbolId);
  }

  protected virtual string GetVolumeAnalysisVendorKey(string globalSymbolId)
  {
    return MultiVendor.ParseVendorKey(globalSymbolId);
  }

  protected virtual string GetSymbolVendorSymbolId(string vendorKey, string globalSymbolId)
  {
    return MultiVendor.ParseLocalId(vendorKey, globalSymbolId);
  }

  protected virtual string GetQuoteVendorSymbolId(string vendorKey, string globalSymbolId)
  {
    return MultiVendor.ParseLocalId(vendorKey, globalSymbolId);
  }

  protected virtual string GetHistoryVendorSymbolId(string vendorKey, string globalSymbolId)
  {
    return MultiVendor.ParseLocalId(vendorKey, globalSymbolId);
  }

  protected virtual string GetVolumeAnalysisVendorSymbolId(string vendorKey, string globalSymbolId)
  {
    return MultiVendor.ParseLocalId(vendorKey, globalSymbolId);
  }

  private bool 퓏([In] string obj0, out string _param2, out ISymbolVendor _param3)
  {
    return MultiVendor.퓏<ISymbolVendor>(obj0, this.퓞퓕, this.퓞핈, new Func<string, string>(this.GetSymbolVendorKey), out _param2, out _param3);
  }

  private bool 퓏([In] string obj0, out string _param2, out IQuoteVendor _param3)
  {
    return MultiVendor.퓏<IQuoteVendor>(obj0, this.퓞픐, this.퓞픤, new Func<string, string>(this.GetQuoteVendorKey), out _param2, out _param3);
  }

  private bool 퓏([In] string obj0, out string _param2, out IHistoryVendor _param3)
  {
    return MultiVendor.퓏<IHistoryVendor>(obj0, this.퓞픭, this.퓞퓟, new Func<string, string>(this.GetHistoryVendorKey), out _param2, out _param3);
  }

  private bool 퓏([In] string obj0, out string _param2, out IVolumeAnalysisVendor _param3)
  {
    return MultiVendor.퓏<IVolumeAnalysisVendor>(obj0, this.퓞픔, this.퓞핉, new Func<string, string>(this.GetVolumeAnalysisVendorKey), out _param2, out _param3);
  }

  private static bool 퓏<퓏>(
    [In] string obj0,
    [In] Dictionary<string, 퓏> obj1,
    [In] Dictionary<string, string> obj2,
    [In] Func<string, string> obj3,
    out string _param4,
    out 퓏 _param5)
    where 퓏 : IVendor
  {
    _param4 = (string) null;
    _param5 = default (퓏);
    if (obj1.Count == 0)
      return false;
    if (obj1.Count == 1)
    {
      ref string local1 = ref _param4;
      KeyValuePair<string, 퓏> keyValuePair = obj1.First<KeyValuePair<string, 퓏>>();
      string key = keyValuePair.Key;
      local1 = key;
      ref 퓏 local2 = ref _param5;
      keyValuePair = obj1.First<KeyValuePair<string, 퓏>>();
      퓏 퓏 = keyValuePair.Value;
      local2 = 퓏;
      return true;
    }
    if (!obj2.TryGetValue(obj0, out _param4))
    {
      _param4 = obj3(obj0);
      if (string.IsNullOrEmpty(_param4))
        return false;
      obj2.Add(obj0, _param4);
    }
    return obj1.TryGetValue(_param4, out _param5);
  }

  private bool 퓏([In] string obj0, [In] string obj1, out string _param3)
  {
    return MultiVendor.퓏(obj0, obj1, this.퓞핊[obj0], new Func<string, string, string>(this.GetSymbolVendorSymbolId), out _param3);
  }

  private bool 퓬([In] string obj0, [In] string obj1, out string _param3)
  {
    return MultiVendor.퓏(obj0, obj1, this.퓞픛[obj0], new Func<string, string, string>(this.GetQuoteVendorSymbolId), out _param3);
  }

  private bool 핇([In] string obj0, [In] string obj1, out string _param3)
  {
    return MultiVendor.퓏(obj0, obj1, this.퓞퓜[obj0], new Func<string, string, string>(this.GetHistoryVendorSymbolId), out _param3);
  }

  private bool 퓲([In] string obj0, [In] string obj1, out string _param3)
  {
    return MultiVendor.퓏(obj0, obj1, this.퓞픺[obj0], new Func<string, string, string>(this.GetVolumeAnalysisVendorSymbolId), out _param3);
  }

  private static bool 퓏(
    [In] string obj0,
    [In] string obj1,
    [In] Map<string, string> obj2,
    [In] Func<string, string, string> obj3,
    out string _param4)
  {
    if (obj2.TryGetDirect(obj1, out _param4))
      return true;
    _param4 = obj3(obj0, obj1);
    if (string.IsNullOrEmpty(_param4))
      return false;
    obj2.Add(obj1, _param4);
    return true;
  }

  protected virtual string CreateGlobalId(string vendorKey, string localId)
  {
    return localId + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲핃() + vendorKey;
  }

  public static string ParseLocalId(string vendorKey, string globalId)
  {
    string empty = string.Empty;
    int length = globalId.IndexOf(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲핃() + vendorKey);
    return length != -1 ? globalId.Substring(0, length) : globalId;
  }

  public static string ParseVendorKey(string globalId)
  {
    string[] strArray = globalId.Split(new string[1]
    {
      \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲핃()
    }, StringSplitOptions.RemoveEmptyEntries);
    return strArray.Length != 2 ? string.Empty : strArray[1];
  }

  [CompilerGenerated]
  internal static void 퓏([In] IDictionary<Period, TimeSpan> obj0, [In] IDictionary<Period, TimeSpan> obj1)
  {
    foreach (KeyValuePair<Period, TimeSpan> keyValuePair in (IEnumerable<KeyValuePair<Period, TimeSpan>>) obj0)
    {
      if (obj1.ContainsKey(keyValuePair.Key))
      {
        if (keyValuePair.Value < obj1[keyValuePair.Key])
          obj1[keyValuePair.Key] = keyValuePair.Value;
      }
      else
        obj1[keyValuePair.Key] = keyValuePair.Value;
    }
  }
}
