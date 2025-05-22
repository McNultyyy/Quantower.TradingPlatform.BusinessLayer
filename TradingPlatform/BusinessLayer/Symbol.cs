// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Symbol
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
using TradingPlatform.BusinessLayer.Integration;
using TradingPlatform.BusinessLayer.Utils;
using 퓏;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>
/// Represent access to symbol information and properties.
/// </summary>
[Published]
public class Symbol : 
  BusinessObject,
  IComparable<Symbol>,
  퓏.픾,
  IMessageBuilder<MessageSymbol>,
  IMessageBuilder<DayBar>,
  IEquatable<Symbol>,
  IConnectionStateDependent
{
  public const string SPOT_SYMBOL_ID = "spotSymbolId";
  public const string TRADING_SYMBOL_ID = "TradingSymbol";
  private Exchange 픎픨;
  private string 픎퓪;
  private List<VariableTick> 픎픝;
  private double? 픎픻;
  private Symbol 픎픫;
  private string 픎픯;
  private List<Exchange> 픎픚;
  private double 픎픓;
  private double 픎픩;
  private readonly object 픎픛;
  private TickDirection 픎퓜;
  private TickDirection 픎픺;
  private TickDirection 픎핃;
  protected HistoryMetadata historyMetadata;
  protected VolumeAnalysisMetadata volumeAnalysisMetadata;
  private QuoteHandler 픎퓩;
  private Level2Handler 픎퓨;
  private LastHandler 픎퓱;
  private MarkHandler 픎픹;
  private readonly 핅<string, Rule> 픎픈;
  private string 픎픋;
  private const double 픎핀 = 0.03125;
  private const double 픎픲 = 0.015625;
  private const double 픎픽 = 0.0078125;
  private const double 퓠퓏 = 0.00390625;

  /// <summary>Gets symbol Id</summary>
  public string Id { get; protected set; }

  public SymbolComplexIdentifier ComplexId
  {
    get => new SymbolComplexIdentifier(this.ConnectionId, this.ExchangeId, this.Id);
  }

  /// <summary>Gets symbol name</summary>
  public string Name { get; protected set; }

  /// <summary>Gets symbol description</summary>
  public string Description { get; [param: In] private set; }

  /// <summary>Gets symbol type</summary>
  public SymbolType SymbolType { get; [param: In] private set; }

  /// <summary>Gets symbol base Asset</summary>
  public Asset Product { get; protected set; }

  /// <summary>Gets symbol counter Asset</summary>
  public Asset QuotingCurrency { get; protected set; }

  /// <summary>Gets Exchange of current symbol</summary>
  public Exchange Exchange
  {
    get => this.픎픨;
    protected set
    {
      this.픎픨 = value;
      this.ExchangeId = this.Exchange?.Id;
    }
  }

  /// <summary>Gets Exchange id of current symbol</summary>
  public string ExchangeId
  {
    get => this.Exchange?.Id ?? this.픎퓪;
    [param: In] private set => this.픎퓪 = value;
  }

  /// <summary>Returns delay with which quote come in platform.</summary>
  public TimeSpan QuoteDelay { get; [param: In] private set; }

  /// <summary>Gets symbol additional info</summary>
  [NotPublished]
  public AdditionalInfoCollection AdditionalInfo { get; [param: In] private set; }

  /// <summary>The highest trade allowed</summary>
  public double MaxLot { get; [param: In] private set; }

  /// <summary>The lowest trade allowed</summary>
  public double MinLot { get; [param: In] private set; }

  /// <summary>Gets symbol NettingType</summary>
  public NettingType NettingType { get; [param: In] private set; }

  /// <summary>Gets SymbolGroup</summary>
  public SymbolGroup Group { get; protected set; }

  /// <summary>Gets current SymbolQuotingType</summary>
  public SymbolQuotingType QuotingType { get; [param: In] private set; }

  /// <summary>
  /// Amount of base asset <see cref="P:TradingPlatform.BusinessLayer.Symbol.Product" /> for one lot.
  /// </summary>
  public double LotSize { get; [param: In] private set; }

  /// <summary>Stores list of symbol ticksizes</summary>
  public List<VariableTick> VariableTickList
  {
    get => this.픎픝;
    [param: In] private set
    {
      this.픎픝 = value;
      List<VariableTick> 픎픝 = this.픎픝;
      if ((픎픝 != null ? (__nonvirtual (픎픝.Count) == 1 ? 1 : 0) : 0) != 0)
        this.픎픻 = new double?(this.픎픝[0].TickSize);
      else
        this.픎픻 = new double?();
    }
  }

  /// <summary>Step of the lot changes</summary>
  public double LotStep { get; [param: In] private set; }

  /// <summary>Step of the notional value changes</summary>
  public double NotionalValueStep { get; [param: In] private set; }

  /// <summary>Gets derivative expiration date</summary>
  public DateTime ExpirationDate { get; [param: In] private set; }

  /// <summary>Gets derivative last trading date</summary>
  public DateTime LastTradingDate { get; [param: In] private set; }

  /// <summary>Gets derivative maturity date</summary>
  public DateTime MaturityDate { get; [param: In] private set; }

  /// <summary>Gets derivative strike price</summary>
  [NotPublished]
  public double StrikePrice { get; [param: In] private set; }

  /// <summary>Gets derivative option style</summary>
  [NotPublished]
  public OptionCodingStyle OptionStyle { get; [param: In] private set; }

  /// <summary>Gets derivative option type</summary>
  [NotPublished]
  public OptionType OptionType { get; [param: In] private set; }

  /// <summary>Gets derivative option serie</summary>
  [NotPublished]
  public OptionSerie OptionSerie { get; [param: In] private set; }

  /// <summary>Gets derivative underlier name</summary>
  public string Root { get; [param: In] private set; }

  /// <summary>Gets derivative underlier symbol</summary>
  public Symbol Underlier
  {
    get => this.픎픫;
    [param: In] private set
    {
      this.픎픫 = value;
      this.UnderlierId = this.Underlier?.Id;
    }
  }

  /// <summary>Gets derivative underlier symbol id</summary>
  public string UnderlierId
  {
    get => this.Underlier?.Id ?? this.픎픯;
    [param: In] private set => this.픎픯 = value;
  }

  public AvailableDerivatives AvailableFutures { get; [param: In] private set; }

  public AvailableDerivatives AvailableOptions { get; [param: In] private set; }

  public Exchange[] AvailableOptionsExchanges => this.픎픚.ToArray();

  public TradingPlatform.BusinessLayer.FutureContractType? FutureContractType { get; [param: In] private set; }

  /// <summary>Gets Ask price</summary>
  public double Ask { get; [param: In] private set; }

  /// <summary>Gets Ask size</summary>
  public double AskSize { get; [param: In] private set; }

  /// <summary>Gets Bid price</summary>
  public double Bid { get; [param: In] private set; }

  /// <summary>Gets Bid size</summary>
  public double BidSize { get; [param: In] private set; }

  /// <summary>Gets quote time</summary>
  public DateTime QuoteDateTime { get; [param: In] private set; }

  /// <summary>Gets last price</summary>
  public double Last { get; [param: In] private set; }

  /// <summary>Gets last size</summary>
  public double LastSize { get; [param: In] private set; }

  /// <summary>Gets last time</summary>
  public DateTime LastDateTime { get; [param: In] private set; }

  /// <summary>Gets mark price</summary>
  public double Mark { get; [param: In] private set; }

  /// <summary>Gets mark size</summary>
  public double MarkSize { get; [param: In] private set; }

  /// <summary>Gets open price</summary>
  public double Open { get; [param: In] private set; }

  /// <summary>Gets previous close price</summary>
  public double PrevClose { get; [param: In] private set; }

  /// <summary>Gets high price</summary>
  public double High { get; [param: In] private set; }

  /// <summary>Gets low price</summary>
  public double Low { get; [param: In] private set; }

  /// <summary>Gets volume value</summary>
  public double Volume { get; [param: In] private set; }

  /// <summary>Gets quote asset volume value</summary>
  public double QuoteAssetVolume { get; [param: In] private set; }

  /// <summary>Gets PrevSettlement value</summary>
  [NotPublished]
  public double PrevSettlement { get; [param: In] private set; }

  /// <summary>Gets ticks amount</summary>
  public long Ticks { get; [param: In] private set; }

  /// <summary>Gets trades amount</summary>
  public long Trades { get; [param: In] private set; }

  /// <summary>Gets Level2 data</summary>
  public DepthOfMarket DepthOfMarket { get; [param: In] private set; }

  /// <summary>Gets spread value between Bid and Ask</summary>
  public double Spread
  {
    get
    {
      return double.IsNaN(this.Bid) || double.IsNaN(this.Ask) ? double.NaN : this.CalculateTicks(this.Bid, this.Ask);
    }
  }

  /// <summary>
  /// Gets <see cref="P:TradingPlatform.BusinessLayer.Symbol.Spread" /> percentage value
  /// </summary>
  public double SpreadPercentage
  {
    get
    {
      if (double.IsNaN(this.Bid) || double.IsNaN(this.Ask))
        return double.NaN;
      Decimal ask = (Decimal) this.Ask;
      Decimal bid = (Decimal) this.Bid;
      Decimal num = (ask + bid) / 2M;
      return num == 0M ? double.NaN : (double) ((ask - bid) / num * 100M);
    }
  }

  /// <summary>Gets change value between Bid/Last and Close price</summary>
  public double Change
  {
    get => this.AllowCalculateRealtimeChange ? this.CurrentPrice - this.ClosePrice : this.픎픓;
  }

  /// <summary>
  /// Gets <see cref="P:TradingPlatform.BusinessLayer.Symbol.Change" /> percentage value
  /// </summary>
  public double ChangePercentage
  {
    get
    {
      if (!this.AllowCalculateRealtimeChange)
        return this.픎픩;
      double change = this.Change;
      double closePrice = this.ClosePrice;
      return double.IsNaN(change) || double.IsNaN(closePrice) || closePrice == 0.0 ? double.NaN : (double) ((Decimal) change / Math.Abs((Decimal) closePrice) * 100M);
    }
  }

  private double CurrentPrice
  {
    get
    {
      double currentPrice;
      switch (this.HistoryType)
      {
        case HistoryType.Ask:
          currentPrice = this.Ask;
          break;
        case HistoryType.Midpoint:
          currentPrice = (this.Bid + this.Ask) / 2.0;
          break;
        case HistoryType.Last:
          currentPrice = this.Last;
          break;
        case HistoryType.Mark:
          currentPrice = this.Mark;
          break;
        default:
          currentPrice = this.Bid;
          break;
      }
      return currentPrice;
    }
  }

  private double ClosePrice
  {
    get
    {
      return !double.IsNaN(this.PrevSettlement) && this.PrevSettlement != 0.0 ? this.PrevSettlement : this.PrevClose;
    }
  }

  public double OpenInterest { get; [param: In] private set; }

  public double FundingRate { get; [param: In] private set; }

  public double TopPriceLimit { get; [param: In] private set; }

  public double BottomPriceLimit { get; [param: In] private set; }

  public double AverageTradedPrice { get; [param: In] private set; }

  public double TotalBuyQuantity { get; [param: In] private set; }

  public double TotalSellQuantity { get; [param: In] private set; }

  public double IV { get; [param: In] private set; }

  public double Delta { get; [param: In] private set; }

  public double Vega { get; [param: In] private set; }

  public double Gamma { get; [param: In] private set; }

  public double Theta { get; [param: In] private set; }

  public double Rho { get; [param: In] private set; }

  internal bool HasAnySubscription
  {
    get
    {
      return this.QuotesSubscribed | this.Level2Subscribed | this.LastsSubscribed | this.MarkSubscribed;
    }
  }

  /// <summary>Default history type</summary>
  public HistoryType HistoryType { get; [param: In] private set; }

  /// <summary>List of all available history types</summary>
  [NotPublished]
  public virtual HistoryMetadata HistoryMetadata
  {
    get
    {
      HistoryMetadata historyMetadata = this.historyMetadata;
      if (historyMetadata != null)
        return historyMetadata;
      return this.Connection?.HistoryMetaData;
    }
  }

  /// <summary>Gets SymbolVolumeType</summary>
  public SymbolVolumeType VolumeType { get; [param: In] private set; }

  /// <summary>List of all available history types</summary>
  [NotPublished]
  public virtual VolumeAnalysisMetadata VolumeAnalysisMetadata
  {
    get
    {
      VolumeAnalysisMetadata analysisMetadata = this.volumeAnalysisMetadata;
      if (analysisMetadata != null)
        return analysisMetadata;
      return this.Connection?.VolumeAnalysisMetadata;
    }
  }

  /// <summary>Will be triggered when new Level1 quote is comming</summary>
  public event QuoteHandler NewQuote
  {
    add => this.퓏<QuoteHandler>(ref this.픎퓩, value, SubscribeQuoteType.Quote);
    remove => this.퓬<QuoteHandler>(ref this.픎퓩, value, SubscribeQuoteType.Quote);
  }

  internal bool QuotesSubscribed => this.픎퓩 != null;

  /// <summary>Will be triggered when new Level2 quote is comming</summary>
  public event Level2Handler NewLevel2
  {
    add => this.퓏<Level2Handler>(ref this.픎퓨, value, SubscribeQuoteType.Level2);
    remove => this.퓬<Level2Handler>(ref this.픎퓨, value, SubscribeQuoteType.Level2);
  }

  internal bool Level2Subscribed => this.픎퓨 != null;

  /// <summary>Will be triggered when new trade quote is comming</summary>
  public event LastHandler NewLast
  {
    add => this.퓏<LastHandler>(ref this.픎퓱, value, SubscribeQuoteType.Last);
    remove => this.퓬<LastHandler>(ref this.픎퓱, value, SubscribeQuoteType.Last);
  }

  internal bool LastsSubscribed => this.픎퓱 != null;

  public event MarkHandler NewMark
  {
    add => this.퓏<MarkHandler>(ref this.픎픹, value, SubscribeQuoteType.Mark);
    remove => this.퓬<MarkHandler>(ref this.픎픹, value, SubscribeQuoteType.Mark);
  }

  internal bool MarkSubscribed => this.픎픹 != null;

  /// <summary>
  /// Will be triggered when new correctional quote is comming from the vendor.
  /// </summary>
  public event DayBarHandler NewDayBar;

  /// <summary>Will be triggered when symbol updated.</summary>
  public event SymbolUpdateHandler Updated;

  private void 퓏<퓏>([In] ref 퓏 obj0, [In] 퓏 obj1, [In] SubscribeQuoteType obj2) where 퓏 : Delegate
  {
    lock (this.픎픛)
    {
      if ((Delegate) obj0 == (Delegate) null)
        this.SubscribeAction(obj2);
      obj0 = (퓏) Delegate.Combine((Delegate) obj0, (Delegate) obj1);
    }
  }

  private void 퓬<퓏>([In] ref 퓏 obj0, [In] 퓏 obj1, [In] SubscribeQuoteType obj2) where 퓏 : Delegate
  {
    lock (this.픎픛)
    {
      bool flag = (Delegate) obj0 != (Delegate) null;
      obj0 = (퓏) Delegate.Remove((Delegate) obj0, (Delegate) obj1);
      if (!((Delegate) obj0 == (Delegate) null & flag))
        return;
      this.UnSubscribeAction(obj2);
    }
  }

  int 퓏.픾.TradingPlatform\u002EBusinessLayer\u002EIRulesContainer\u002EPriorityIndex => 20;

  핅<string, Rule> 퓏.픾.TradingPlatform\u002EBusinessLayer\u002EIRulesContainer\u002ERules => this.픎픈;

  /// <summary>
  /// Gets real time <see cref="P:TradingPlatform.BusinessLayer.Symbol.Ticks" /> calculation setting
  /// </summary>
  [NotPublished]
  public bool AllowCalculateRealtimeTicks { get; [param: In] private set; }

  /// <summary>
  /// Gets real time <see cref="P:TradingPlatform.BusinessLayer.Symbol.Trades" /> calculation setting
  /// </summary>
  [NotPublished]
  public bool AllowCalculateRealtimeTrades { get; [param: In] private set; }

  /// <summary>
  /// Gets real time <see cref="P:TradingPlatform.BusinessLayer.Symbol.Volume" /> calculation setting
  /// </summary>
  [NotPublished]
  public bool AllowCalculateRealtimeVolume { get; [param: In] private set; }

  /// <summary>
  /// Gets real time <see cref="P:TradingPlatform.BusinessLayer.Symbol.Change" /> calculation setting
  /// </summary>
  [NotPublished]
  public bool AllowCalculateRealtimeChange { get; [param: In] private set; }

  [NotPublished]
  public bool AllowAbbreviatePriceByTickSize { get; set; }

  public DeltaCalculationType DeltaCalculationType { get; [param: In] private set; }

  public double MinVolumeAnalysisTickSize { get; [param: In] private set; }

  public SessionsContainer CurrentSessionsInfo
  {
    get
    {
      if (string.IsNullOrEmpty(this.픎픋))
        return this.Exchange?.CurrentSessionsInfo;
      if (this.ConnectionCache?.TradingSessions == null)
        return (SessionsContainer) null;
      SessionsContainer currentSessionsInfo;
      this.ConnectionCache.TradingSessions.TryGetValue(this.픎픋, out currentSessionsInfo);
      return currentSessionsInfo;
    }
  }

  internal int TotalSubscriptionsCount
  {
    get
    {
      return (this.LastsSubscribed ? 1 : 0) + (this.MarkSubscribed ? 1 : 0) + (this.QuotesSubscribed ? 1 : 0) + (this.Level2Subscribed ? 1 : 0);
    }
  }

  protected internal Symbol()
  {
  }

  [NotPublished]
  protected internal Symbol(string connectionId)
    : base(connectionId)
  {
    this.픎픛 = new object();
    this.퓏();
    this.픎픈 = new 핅<string, Rule>();
    Core.Instance.RulesManager.Defaults.ForEach((Action<Rule>) (([In] obj0) => this.픎픈.퓏(obj0.Name, obj0)));
  }

  private protected void 퓏()
  {
    this.NettingType = NettingType.Undefined;
    this.Ask = double.NaN;
    this.AskSize = double.NaN;
    this.Bid = double.NaN;
    this.BidSize = double.NaN;
    this.Last = double.NaN;
    this.LastSize = double.NaN;
    this.Mark = double.NaN;
    this.MarkSize = double.NaN;
    this.Open = double.NaN;
    this.PrevClose = double.NaN;
    this.High = double.NaN;
    this.Low = double.NaN;
    this.Volume = double.NaN;
    this.QuoteAssetVolume = double.NaN;
    this.PrevSettlement = double.NaN;
    this.픎픓 = double.NaN;
    this.픎픩 = double.NaN;
    this.OpenInterest = double.NaN;
    this.FundingRate = double.NaN;
    this.TopPriceLimit = double.NaN;
    this.BottomPriceLimit = double.NaN;
    this.TotalBuyQuantity = double.NaN;
    this.TotalSellQuantity = double.NaN;
    this.IV = double.NaN;
    this.Delta = double.NaN;
    this.Vega = double.NaN;
    this.Gamma = double.NaN;
    this.Theta = double.NaN;
    this.Rho = double.NaN;
    this.Ticks = 0L;
    this.Trades = 0L;
    this.DepthOfMarket = new DepthOfMarket(this);
    this.AllowCalculateRealtimeTicks = true;
    this.AllowCalculateRealtimeTrades = true;
    this.AllowCalculateRealtimeVolume = true;
    this.AllowCalculateRealtimeChange = true;
    this.DeltaCalculationType = DeltaCalculationType.AggressorFlag;
    this.MinVolumeAnalysisTickSize = double.NaN;
    this.AvailableFutures = AvailableDerivatives.None;
    this.AvailableOptions = AvailableDerivatives.None;
    this.MinLot = 1.0;
    this.MaxLot = (double) int.MaxValue;
    this.LotStep = 1.0;
    this.LotSize = 1.0;
    this.NotionalValueStep = 1.0;
    this.픎픚 = new List<Exchange>();
  }

  [NotPublished]
  protected internal Symbol(BusinessObjectInfo objectInfo)
    : this(objectInfo.ConnectionId)
  {
    this.Id = objectInfo.Id;
    this.Name = objectInfo.Name;
    this.State = BusinessObjectState.Fake;
    SymbolInfo symbolInfo = objectInfo as SymbolInfo;
    if ((object) symbolInfo == null)
      return;
    this.ExchangeId = symbolInfo.ExchangeId;
    this.SymbolType = symbolInfo.SymbolType;
    this.FutureContractType = symbolInfo.FutureContractType;
    this.UnderlierId = symbolInfo.UnderlierId;
    this.Root = symbolInfo.Root;
    this.ExpirationDate = symbolInfo.ExpirationDate;
  }

  internal void 퓏([In] MessageSymbolInfo obj0)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Symbol.핇 핇 = new Symbol.핇();
    // ISSUE: reference to a compiler-generated field
    핇.핋퓾 = obj0;
    if (string.IsNullOrEmpty(this.Id))
    {
      // ISSUE: reference to a compiler-generated field
      this.Id = 핇.핋퓾.Id;
    }
    // ISSUE: reference to a compiler-generated field
    this.Name = 핇.핋퓾.Name;
    // ISSUE: reference to a compiler-generated field
    this.Description = 핇.핋퓾.Description;
    // ISSUE: reference to a compiler-generated field
    this.SymbolType = 핇.핋퓾.SymbolType;
    // ISSUE: reference to a compiler-generated field
    this.AvailableFutures = 핇.핋퓾.AvailableFutures;
    // ISSUE: reference to a compiler-generated field
    this.AvailableOptions = 핇.핋퓾.AvailableOptions;
    // ISSUE: reference to a compiler-generated field
    this.Root = 핇.핋퓾.Root;
    // ISSUE: reference to a compiler-generated field
    this.LotStep = 핇.핋퓾.LotStep;
    // ISSUE: reference to a compiler-generated field
    this.MinLot = 핇.핋퓾.MinLot;
    // ISSUE: reference to a compiler-generated field
    this.MaxLot = 핇.핋퓾.MaxLot;
    // ISSUE: reference to a compiler-generated field
    this.HistoryType = 핇.핋퓾.HistoryType;
    // ISSUE: reference to a compiler-generated field
    this.VariableTickList = 핇.핋퓾.VariableTickList;
    // ISSUE: reference to a compiler-generated field
    this.StrikePrice = 핇.핋퓾.StrikePrice;
    // ISSUE: reference to a compiler-generated field
    this.OptionType = 핇.핋퓾.OptionType;
    // ISSUE: reference to a compiler-generated field
    this.ExpirationDate = 핇.핋퓾.ExpirationDate;
    // ISSUE: reference to a compiler-generated field
    this.LastTradingDate = 핇.핋퓾.LastTradingDate;
    // ISSUE: reference to a compiler-generated field
    this.FutureContractType = 핇.핋퓾.FutureContractType;
    // ISSUE: reference to a compiler-generated field
    if (this.ConnectionCache != null && !string.IsNullOrEmpty(핇.핋퓾.ExchangeId))
    {
      Exchange exchange1;
      // ISSUE: reference to a compiler-generated field
      if (this.ConnectionCache.ExchangesCache.퓏(핇.핋퓾.ExchangeId, out exchange1))
      {
        this.Exchange = exchange1;
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        this.ExchangeId = 핇.핋퓾.ExchangeId;
      }
      // ISSUE: reference to a compiler-generated field
      if (핇.핋퓾.AvailableOptionsExchanges != null)
      {
        // ISSUE: reference to a compiler-generated field
        foreach (string availableOptionsExchange in 핇.핋퓾.AvailableOptionsExchanges)
        {
          Exchange exchange2;
          if (this.ConnectionCache.ExchangesCache.퓏(availableOptionsExchange, out exchange2))
            this.픎픚.Add(exchange2);
        }
      }
    }
    // ISSUE: reference to a compiler-generated field
    if (string.IsNullOrEmpty(핇.핋퓾.UnderlierId))
      return;
    Symbol symbol;
    // ISSUE: reference to a compiler-generated field
    if (this.ConnectionCache != null && this.ConnectionCache.SymbolsCache.퓏(핇.핋퓾.UnderlierId, out symbol))
    {
      this.Underlier = symbol;
    }
    else
    {
      // ISSUE: reference to a compiler-generated field
      this.UnderlierId = 핇.핋퓾.UnderlierId;
    }
    // ISSUE: reference to a compiler-generated field
    if (핇.핋퓾.OptionSerieId == null || this.Underlier == null)
      return;
    IList<OptionSerie> source = this.Connection.퓏(new GetOptionSeriesRequestParameters(this.Underlier));
    // ISSUE: reference to a compiler-generated method
    this.OptionSerie = source != null ? source.FirstOrDefault<OptionSerie>(new Func<OptionSerie, bool>(핇.퓏)) : (OptionSerie) null;
  }

  internal void 퓏([In] MessageSymbol obj0)
  {
    this.퓏((MessageSymbolInfo) obj0);
    if (this.ConnectionCache != null)
    {
      Asset asset1;
      if (obj0.ProductAssetId != null && this.ConnectionCache.픾핁.TryGetValue(obj0.ProductAssetId, out asset1))
        this.Product = asset1;
      Asset asset2;
      if (obj0.QuotingCurrencyAssetID != null && this.ConnectionCache.픾핁.TryGetValue(obj0.QuotingCurrencyAssetID, out asset2))
        this.QuotingCurrency = asset2;
      SymbolGroup symbolGroup;
      if (!string.IsNullOrEmpty(obj0.GroupId) && this.ConnectionCache.SymbolGroupsCache.TryGetValue(obj0.GroupId, out symbolGroup))
        this.Group = symbolGroup;
    }
    this.QuoteDelay = obj0.QuoteDelay;
    this.MaturityDate = obj0.MaturityDate;
    this.QuotingType = obj0.QuotingType;
    this.LotSize = obj0.LotSize;
    this.NotionalValueStep = obj0.NotionalValueStep;
    this.NettingType = obj0.NettingType;
    if (obj0.SymbolAdditionalInfo != null)
    {
      if (this.AdditionalInfo == null)
      {
        AdditionalInfoCollection additionalInfoCollection;
        this.AdditionalInfo = additionalInfoCollection = new AdditionalInfoCollection();
      }
      foreach (AdditionalInfoItem additionalInfoItem in obj0.SymbolAdditionalInfo)
        this.AdditionalInfo.퓏(additionalInfoItem);
    }
    this.historyMetadata = obj0.HistoryMetadata;
    this.volumeAnalysisMetadata = obj0.VolumeAnalysisMetadata;
    this.VolumeType = obj0.VolumeType;
    this.AllowCalculateRealtimeTicks = obj0.AllowCalculateRealtimeTicks;
    this.AllowCalculateRealtimeTrades = obj0.AllowCalculateRealtimeTrades;
    this.AllowCalculateRealtimeVolume = obj0.AllowCalculateRealtimeVolume;
    this.AllowCalculateRealtimeChange = obj0.AllowCalculateRealtimeChange;
    this.AllowAbbreviatePriceByTickSize = obj0.AllowAbbreviatePriceByTickSize;
    this.DeltaCalculationType = obj0.DeltaCalculationType;
    this.MinVolumeAnalysisTickSize = obj0.MinVolumeAnalysisTickSize;
    this.픎픋 = obj0.SessionsContainerId;
    this.퓬();
  }

  protected internal virtual void SubscribeAction(SubscribeQuoteType type)
  {
    if (this.State == BusinessObjectState.Fake)
      return;
    Symbol quotesSymbol;
    if (Core.Instance.SymbolsMapping.TryGetQuotesSymbol(this, out quotesSymbol) && quotesSymbol != this)
    {
      switch (type)
      {
        case SubscribeQuoteType.Quote:
          quotesSymbol.NewQuote += new QuoteHandler(this.퓏);
          break;
        case SubscribeQuoteType.Level2:
          DOMQuote domQuote = ((IMessageBuilder<DOMQuote>) quotesSymbol.DepthOfMarket).BuildMessage();
          domQuote.SymbolId = this.Id;
          this.퓏((MessageQuote) domQuote);
          quotesSymbol.NewLevel2 += new Level2Handler(this.퓏);
          break;
        case SubscribeQuoteType.Last:
          quotesSymbol.NewLast += new LastHandler(this.퓏);
          break;
        case SubscribeQuoteType.Mark:
          quotesSymbol.NewMark += new MarkHandler(this.퓏);
          break;
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      if (type != SubscribeQuoteType.Quote && (uint) (type - 2) > 1U || quotesSymbol.픎퓺 != null && ((IEnumerable<Delegate>) quotesSymbol.픎퓺.GetInvocationList()).Contains<Delegate>((Delegate) new DayBarHandler(this.퓏)))
        return;
      quotesSymbol.NewDayBar += new DayBarHandler(this.퓏);
      DayBar dayBar = ((IMessageBuilder<DayBar>) quotesSymbol).BuildMessage();
      dayBar.SymbolId = this.Id;
      this.퓏((MessageQuote) dayBar);
    }
    else
      Core.Instance.Connections[this.ConnectionId]?.퓏(this, type);
  }

  protected internal virtual void UnSubscribeAction(SubscribeQuoteType type)
  {
    if (this.State == BusinessObjectState.Fake)
      return;
    Symbol quotesSymbol;
    if (Core.Instance.SymbolsMapping.TryGetQuotesSymbol(this, out quotesSymbol) && quotesSymbol != this)
    {
      switch (type)
      {
        case SubscribeQuoteType.Quote:
          quotesSymbol.NewQuote -= new QuoteHandler(this.퓏);
          break;
        case SubscribeQuoteType.Level2:
          quotesSymbol.NewLevel2 -= new Level2Handler(this.퓏);
          break;
        case SubscribeQuoteType.Last:
          quotesSymbol.NewLast -= new LastHandler(this.퓏);
          break;
        case SubscribeQuoteType.Mark:
          quotesSymbol.NewMark -= new MarkHandler(this.퓏);
          break;
      }
      QuoteHandler 픎퓩 = quotesSymbol.픎퓩;
      if ((픎퓩 != null ? (!((IEnumerable<Delegate>) 픎퓩.GetInvocationList()).Contains<Delegate>((Delegate) new QuoteHandler(this.퓏)) ? 1 : 0) : 1) != 0)
      {
        LastHandler 픎퓱 = quotesSymbol.픎퓱;
        if ((픎퓱 != null ? (!((IEnumerable<Delegate>) 픎퓱.GetInvocationList()).Contains<Delegate>((Delegate) new LastHandler(this.퓏)) ? 1 : 0) : 1) != 0)
        {
          MarkHandler 픎픹 = quotesSymbol.픎픹;
          if ((픎픹 != null ? (!((IEnumerable<Delegate>) 픎픹.GetInvocationList()).Contains<Delegate>((Delegate) new MarkHandler(this.퓏)) ? 1 : 0) : 1) != 0)
          {
            quotesSymbol.NewDayBar -= new DayBarHandler(this.퓏);
            this.퓏((MessageQuote) new DayBar(this.Id, Core.Instance.TimeUtils.DateTimeUtcNow));
          }
        }
      }
    }
    else
      Core.Instance.Connections[this.ConnectionId]?.퓬(this, type);
    if (type != SubscribeQuoteType.Level2)
      return;
    this.DepthOfMarket.퓏();
  }

  private void 퓏([In] Symbol obj0, [In] Quote obj1) => this.퓏((MessageQuote) obj1);

  private void 퓏([In] Symbol obj0, [In] Level2Quote obj1, [In] DOMQuote obj2)
  {
    this.퓏((MessageQuote) obj2);
    this.퓏((MessageQuote) obj1);
  }

  private void 퓏([In] Symbol obj0, [In] TradingPlatform.BusinessLayer.Last obj1)
  {
    this.퓏((MessageQuote) obj1);
  }

  private void 퓏([In] Symbol obj0, [In] TradingPlatform.BusinessLayer.Mark obj1)
  {
    this.퓏((MessageQuote) obj1);
  }

  private void 퓏([In] Symbol obj0, [In] DayBar obj1) => this.퓏((MessageQuote) obj1);

  internal void 퓏([In] Action obj0)
  {
    lock (this.픎픛)
      obj0();
  }

  internal void 퓏([In] MessageQuote obj0_1)
  {
    switch (obj0_1)
    {
      case Quote quote:
        quote.BidTickDirection = Symbol.DetermineTickDirection(this.Bid, quote.Bid, this.픎픺);
        quote.AskTickDirection = Symbol.DetermineTickDirection(this.Ask, quote.Ask, this.픎핃);
        this.픎픺 = quote.BidTickDirection;
        this.픎핃 = quote.AskTickDirection;
        if (!double.IsNaN(quote.Bid))
          this.Bid = quote.Bid;
        if (!double.IsNaN(quote.BidSize))
          this.BidSize = quote.BidSize;
        if (!double.IsNaN(quote.Ask))
          this.Ask = quote.Ask;
        if (!double.IsNaN(quote.AskSize))
          this.AskSize = quote.AskSize;
        this.QuoteDateTime = quote.Time;
        if (this.AllowCalculateRealtimeTicks)
          ++this.Ticks;
        this.퓏(quote);
        break;
      case Level2Quote level2Quote:
        this.DepthOfMarket.퓏(level2Quote);
        this.퓏(level2Quote, (DOMQuote) null);
        break;
      case DOMQuote domQuote:
        this.DepthOfMarket.퓏(domQuote);
        this.퓏((Level2Quote) null, domQuote);
        break;
      case TradingPlatform.BusinessLayer.Last last:
        if (this.HistoryMetadata != null && !this.HistoryMetadata.ServerSideTickDirectionAvailable)
          last.TickDirection = Symbol.DetermineTickDirection(this.Last, last.Price, this.픎퓜);
        this.픎퓜 = last.TickDirection;
        this.Last = last.Price;
        this.LastSize = last.Size;
        this.LastDateTime = last.Time;
        if (this.AllowCalculateRealtimeVolume)
        {
          this.Volume += last.Size;
          if (!double.IsNaN(last.QuoteAssetVolume))
            this.QuoteAssetVolume += last.QuoteAssetVolume;
        }
        if (this.AllowCalculateRealtimeTrades)
          ++this.Trades;
        if (!double.IsNaN(last.OpenInterest))
          this.OpenInterest = last.OpenInterest;
        this.퓏(last);
        break;
      case TradingPlatform.BusinessLayer.Mark mark:
        this.Mark = mark.Price;
        this.MarkSize = CoreMath.ProcessNaN(mark.Size, this.MarkSize);
        this.퓏(mark);
        break;
      case DayBar dayBar:
        Func<double, double, double> func1;
        Func<long, long, long> func2;
        if (dayBar.FullRefresh)
        {
          func1 = (Func<double, double, double>) (([In] obj0_2, [In] obj1) => obj0_2);
          func2 = (Func<long, long, long>) (([In] obj0_3, [In] obj1) => obj0_3);
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          func1 = Symbol.퓏.핋픟 ?? (Symbol.퓏.핋픟 = new Func<double, double, double>(CoreMath.ProcessNaN));
          func2 = (Func<long, long, long>) (([In] obj0_4, [In] obj1) => obj0_4 < 0L ? obj1 : obj0_4);
        }
        this.Open = func1(dayBar.Open, this.Open);
        this.High = func1(dayBar.High, this.High);
        this.Low = func1(dayBar.Low, this.Low);
        this.PrevClose = func1(dayBar.PreviousClose, this.PrevClose);
        this.Volume = func1(dayBar.Volume, this.Volume);
        this.QuoteAssetVolume = func1(dayBar.QuoteAssetVolume, this.QuoteAssetVolume);
        this.PrevSettlement = func1(dayBar.PrevSettlementPrice, this.PrevSettlement);
        this.Ticks = func2(dayBar.Ticks, this.Ticks);
        this.Trades = func2(dayBar.Trades, this.Trades);
        this.Bid = func1(dayBar.Bid, this.Bid);
        this.BidSize = func1(dayBar.BidSize, this.BidSize);
        this.Ask = func1(dayBar.Ask, this.Ask);
        this.AskSize = func1(dayBar.AskSize, this.AskSize);
        this.Last = func1(dayBar.Last, this.Last);
        this.LastSize = func1(dayBar.LastSize, this.LastSize);
        this.Mark = func1(dayBar.Mark, this.Mark);
        this.MarkSize = func1(dayBar.MarkSize, this.MarkSize);
        if (!this.AllowCalculateRealtimeChange)
        {
          this.픎픓 = func1(dayBar.Change, this.픎픓);
          this.픎픩 = func1(dayBar.ChangePercentage, this.픎픩);
        }
        this.OpenInterest = func1(dayBar.OpenInterest, this.OpenInterest);
        this.FundingRate = func1(dayBar.FundingRate, this.FundingRate);
        this.TopPriceLimit = func1(dayBar.TopPriceLimit, this.TopPriceLimit);
        this.BottomPriceLimit = func1(dayBar.BottomPriceLimit, this.BottomPriceLimit);
        this.AverageTradedPrice = func1(dayBar.AverageTradedPrice, this.AverageTradedPrice);
        this.TotalBuyQuantity = dayBar.TotalBuyQuantity;
        this.TotalSellQuantity = dayBar.TotalSellQuantity;
        this.IV = dayBar.IV;
        this.Delta = dayBar.Delta;
        this.Vega = dayBar.Vega;
        this.Gamma = dayBar.Gamma;
        this.Theta = dayBar.Theta;
        this.Rho = dayBar.Rho;
        this.퓏(dayBar);
        break;
    }
  }

  private void 퓏([In] Quote obj0)
  {
    QuoteHandler 픎퓩 = this.픎퓩;
    if (픎퓩 == null)
      return;
    픎퓩(this, obj0);
  }

  private void 퓏([In] Level2Quote obj0, [In] DOMQuote obj1)
  {
    Level2Handler 픎퓨 = this.픎퓨;
    if (픎퓨 == null)
      return;
    픎퓨(this, obj0, obj1);
  }

  private void 퓏([In] TradingPlatform.BusinessLayer.Last obj0)
  {
    LastHandler 픎퓱 = this.픎퓱;
    if (픎퓱 == null)
      return;
    픎퓱(this, obj0);
  }

  private void 퓏([In] TradingPlatform.BusinessLayer.Mark obj0)
  {
    MarkHandler 픎픹 = this.픎픹;
    if (픎픹 == null)
      return;
    픎픹(this, obj0);
  }

  private void 퓏([In] DayBar obj0)
  {
    // ISSUE: reference to a compiler-generated field
    DayBarHandler 픎퓺 = this.픎퓺;
    if (픎퓺 == null)
      return;
    픎퓺(this, obj0);
  }

  /// <summary>
  /// Gets historical data according to period and other parameters
  /// </summary>
  /// <param name="period"></param>
  /// <param name="fromTime"></param>
  /// <param name="toTime"></param>
  /// <returns></returns>
  public HistoricalData GetHistory(Period period, DateTime fromTime, DateTime toTime = default (DateTime))
  {
    return this.GetHistory(period, this.HistoryType, fromTime, toTime);
  }

  /// <summary>
  /// Gets historical data according to period and other parameters
  /// </summary>
  /// <param name="period"></param>
  /// <param name="historyType"></param>
  /// <param name="fromTime"></param>
  /// <param name="toTime"></param>
  /// <returns></returns>
  public HistoricalData GetHistory(
    Period period,
    HistoryType historyType,
    DateTime fromTime,
    DateTime toTime = default (DateTime))
  {
    HistoryAggregation historyAggregation = period.BasePeriod != BasePeriod.Tick ? (HistoryAggregation) new HistoryAggregationTime(period, historyType) : (period.PeriodMultiplier != 1 ? (HistoryAggregation) new HistoryAggregationTickBars(period.PeriodMultiplier, historyType) : (HistoryAggregation) new HistoryAggregationTick(historyType));
    return this.GetHistory(new HistoryRequestParameters()
    {
      Symbol = this,
      Aggregation = historyAggregation,
      FromTime = fromTime,
      ToTime = toTime
    });
  }

  /// <summary>
  /// Gets historical data according to aggregation and other parameters
  /// </summary>
  /// <param name="aggregation"></param>
  /// <param name="historyType"></param>
  /// <param name="fromTime"></param>
  /// <param name="toTime"></param>
  /// <returns></returns>
  public HistoricalData GetHistory(
    HistoryAggregation aggregation,
    DateTime fromTime,
    DateTime toTime = default (DateTime))
  {
    return this.GetHistory(new HistoryRequestParameters()
    {
      Symbol = this,
      Aggregation = aggregation,
      FromTime = fromTime,
      ToTime = toTime
    });
  }

  /// <summary>
  /// Gets historical data according to given history request
  /// </summary>
  /// <param name="historyRequestParameters"></param>
  /// <returns></returns>
  public HistoricalData GetHistory(HistoryRequestParameters historyRequestParameters)
  {
    if (historyRequestParameters == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픍());
    historyRequestParameters.Symbol = this;
    HistoricalData history = this.퓏(historyRequestParameters);
    history.Reload();
    return history;
  }

  private protected virtual HistoricalData 퓏([In] HistoryRequestParameters obj0)
  {
    return new HistoricalData(obj0);
  }

  /// <summary>
  /// Gets historical ticks data according to given parameters
  /// </summary>
  /// <param name="historyType"></param>
  /// <param name="fromTime"></param>
  /// <param name="toTime"></param>
  /// <returns></returns>
  public HistoricalData GetTickHistory(HistoryType historyType, DateTime fromTime, DateTime toTime = default (DateTime))
  {
    return this.GetHistory(new HistoryRequestParameters()
    {
      Symbol = this,
      Aggregation = (HistoryAggregation) new HistoryAggregationTick(historyType),
      FromTime = fromTime,
      ToTime = toTime
    });
  }

  /// <summary>
  /// Returns rounded to <see cref="P:TradingPlatform.BusinessLayer.Symbol.TickSize" /> price
  /// </summary>
  public double RoundPriceToTickSize(double price, double tickSize = double.NaN)
  {
    if (double.IsNaN(price) || this.VariableTickList == null && tickSize.IsNanOrDefault())
      return 0.0;
    if (tickSize.IsNanOrDefault())
    {
      VariableTick variableTick = this.FindVariableTick(price);
      if (variableTick == null)
        return price;
      tickSize = variableTick.TickSize;
    }
    return CoreMath.RoundToIncrement(price, tickSize);
  }

  /// <summary>
  /// Calculates new price which equal to given price shifted by a number of given ticks
  /// </summary>
  /// <param name="price"></param>
  /// <param name="ticks"></param>
  /// <returns></returns>
  public double CalculatePrice(double price, double ticks)
  {
    return (double) ((Decimal) price + (Decimal) ticks * (Decimal) this.GetTickSize(price));
  }

  /// <summary>Calculates ticks between two prices</summary>
  /// <param name="price1"></param>
  /// <param name="price2"></param>
  /// <returns></returns>
  public double CalculateTicks(double price1, double price2)
  {
    if (double.IsNaN(price1) || double.IsNaN(price2))
      return double.NaN;
    Decimal num1 = (Decimal) price1;
    Decimal num2 = (Decimal) price2;
    Decimal tickSize = (Decimal) this.GetTickSize(price1);
    Decimal ticks = 0M;
    if (tickSize != 0M)
      ticks = (num2 - num1) / tickSize;
    return (double) ticks;
  }

  /// <summary>
  /// Gets cached symbol tick size or retrives it from the <see cref="T:TradingPlatform.BusinessLayer.VariableTick" /> list
  /// </summary>
  /// <param name="price"></param>
  /// <returns></returns>
  public double GetTickSize(double price)
  {
    if (this.픎픻.HasValue)
      return this.픎픻.Value;
    VariableTick variableTick = this.FindVariableTick(price);
    return variableTick == null ? double.NaN : variableTick.TickSize;
  }

  /// <summary>
  /// Gets symbol tick cost retrived from the <see cref="T:TradingPlatform.BusinessLayer.VariableTick" /> list by price
  /// </summary>
  /// <param name="price"></param>
  /// <returns></returns>
  public double GetTickCost(double price)
  {
    VariableTick variableTick = this.FindVariableTick(price);
    return variableTick == null ? double.NaN : variableTick.TickCost;
  }

  /// <summary>
  /// Returns VariableTick if it can be retrived from <see cref="T:TradingPlatform.BusinessLayer.VariableTick" /> list by price or null
  /// </summary>
  /// <param name="price"></param>
  /// <returns></returns>
  public VariableTick FindVariableTick(double price)
  {
    List<VariableTick> variableTickList = this.VariableTickList;
    if (variableTickList == null)
    {
      if (this.Underlier != null)
        variableTickList = this.Underlier.VariableTickList;
      if (variableTickList == null)
        return (VariableTick) null;
    }
    for (int index = variableTickList.Count - 1; index >= 0; --index)
    {
      VariableTick variableTick = variableTickList[index];
      if (variableTick.CheckPrice(price))
        return variableTick;
    }
    return (VariableTick) null;
  }

  /// <summary>
  /// Gets cached tick size if it available, else tries to obtain <see cref="M:TradingPlatform.BusinessLayer.Symbol.GetTickSize(System.Double)" /> with Last, Bid, Ask, first element of <see cref="T:TradingPlatform.BusinessLayer.VariableTick" /> list otherwise - <see cref="F:TradingPlatform.BusinessLayer.Utils.Const.DOUBLE_UNDEFINED" />
  /// </summary>
  public double TickSize
  {
    get
    {
      if (this.픎픻.HasValue)
        return this.픎픻.Value;
      if (!double.IsNaN(this.Last))
        return this.GetTickSize(this.Last);
      if (!double.IsNaN(this.Bid))
        return this.GetTickSize(this.Bid);
      if (!double.IsNaN(this.Ask))
        return this.GetTickSize(this.Ask);
      List<VariableTick> variableTickList = this.VariableTickList;
      return (variableTickList != null ? variableTickList.FirstOrDefault<VariableTick>()?.TickSize : new double?()) ?? double.NaN;
    }
  }

  private protected void 퓬()
  {
    // ISSUE: reference to a compiler-generated field
    SymbolUpdateHandler 픎픊 = this.픎픊;
    if (픎픊 == null)
      return;
    픎픊(this);
  }

  [NotPublished]
  public override string ToString() => this.Name;

  [NotPublished]
  public override BusinessObjectInfo CreateInfo()
  {
    SymbolInfo info = new SymbolInfo();
    info.ConnectionId = this.ConnectionId;
    info.Id = this.Id;
    info.Name = this.Name;
    info.ExchangeId = this.ExchangeId;
    info.SymbolType = this.SymbolType;
    info.FutureContractType = this.FutureContractType;
    info.UnderlierId = this.UnderlierId;
    info.Root = this.Root;
    info.ExpirationDate = this.ExpirationDate;
    return (BusinessObjectInfo) info;
  }

  public override bool Equals(object obj) => this.Equals(obj as Symbol);

  public bool Equals(Symbol other)
  {
    return other != null && this.ConnectionId == other.ConnectionId && this.Id == other.Id;
  }

  public override int GetHashCode()
  {
    return (-1919740922 * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.ConnectionId)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.Id);
  }

  /// <summary>
  /// Formats price value to the appropriative string with a counting on tick precision.
  /// </summary>
  /// <param name="price"></param>
  /// <returns></returns>
  public string FormatPrice(double price)
  {
    VariableTick variableTick = this.FindVariableTick(price);
    if (this.AllowAbbreviatePriceByTickSize && GlobalSettings.AbbreviateCryptoPrices && price > 0.0 && price < 1.0 && variableTick != null)
      return \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픆() + (price / variableTick.TickSize).Format(0);
    if (variableTick != null && (variableTick.TickSize == 1.0 / 32.0 || variableTick.TickSize == 1.0 / 64.0 || variableTick.TickSize == 1.0 / 128.0 || variableTick.TickSize == 1.0 / 256.0))
      return Symbol.퓏(price, variableTick);
    return variableTick != null ? price.Format(variableTick.Precision) : price.Format();
  }

  /// <summary>
  /// Formats price value to the appropriative string with a counting on max tick precision.
  /// </summary>
  /// <param name="price"></param>
  /// <returns></returns>
  public string FormatPriceWithMaxPrecision(double price)
  {
    VariableTick variableTick = this.FindVariableTick(price);
    if (variableTick != null && (variableTick.TickSize == 1.0 / 32.0 || variableTick.TickSize == 1.0 / 64.0 || variableTick.TickSize == 1.0 / 128.0 || variableTick.TickSize == 1.0 / 256.0))
      return Symbol.퓏(price, variableTick);
    return variableTick != null ? price.FormatPriceWithMaxPrecision(variableTick.Precision) : price.FormatPriceWithMaxPrecision();
  }

  private static string 퓏([In] double obj0, [In] VariableTick obj1)
  {
    double num = Math.Abs(obj0 - (double) (long) obj0);
    string str = obj1.TickSize != 1.0 / 32.0 ? (obj1.TickSize != 1.0 / 64.0 ? (obj1.TickSize != 1.0 / 128.0 ? ((double) (Decimal) (long) (num / obj1.TickSize / 8.0 * 10.0)).ToString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픠()) : ((double) (Decimal) (long) (num / obj1.TickSize / 4.0 * 10.0)).ToString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픠())) : ((double) (Decimal) (num / obj1.TickSize / 2.0 * 10.0)).ToString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픠())) : ((double) (Decimal) (num / obj1.TickSize)).ToString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픅());
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 3);
    interpolatedStringHandler.AppendFormatted(obj0 < 0.0 ? \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픔() : \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓥());
    interpolatedStringHandler.AppendFormatted<long>((long) Math.Abs(obj0));
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓿());
    interpolatedStringHandler.AppendFormatted(str);
    return interpolatedStringHandler.ToStringAndClear();
  }

  public virtual string FormatQuantity(double quantity, bool inLots = true, bool abbreviate = false)
  {
    if (!inLots)
      return (quantity * this.LotSize).Format(CoreMath.GetValuePrecision((Decimal) this.NotionalValueStep), abbreviate);
    int valuePrecision = CoreMath.GetValuePrecision((Decimal) this.LotStep);
    return quantity.Format(valuePrecision, abbreviate);
  }

  /// <summary>Returns string with formatted ticks value</summary>
  /// <param name="offset"></param>
  /// <param name="dimension"></param>
  /// <returns></returns>
  public string FormatOffset(double offset, string dimension = "ticks")
  {
    return offset.FormatPriceWithMaxPrecision(0) + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프() + dimension;
  }

  [NotPublished]
  public string FormatQuoteAssetVolume(double volume) => volume.Format();

  /// <summary>
  /// Comparing by <see cref="P:TradingPlatform.BusinessLayer.Symbol.Name" /> value
  /// </summary>
  [NotPublished]
  public int CompareTo(Symbol symbol) => this.Name.CompareTo(symbol.Name);

  MessageSymbol IMessageBuilder<MessageSymbol>.핇()
  {
    MessageSymbol messageSymbol = new MessageSymbol(this.Id);
    messageSymbol.GroupId = this.Group?.Id;
    messageSymbol.Name = this.Name;
    messageSymbol.Description = this.Description;
    messageSymbol.SymbolType = this.SymbolType;
    messageSymbol.ProductAssetId = this.Product?.Id;
    messageSymbol.QuotingCurrencyAssetID = this.QuotingCurrency?.Id;
    messageSymbol.ExchangeId = this.ExchangeId;
    messageSymbol.QuoteDelay = this.QuoteDelay;
    messageSymbol.QuotingType = this.QuotingType;
    messageSymbol.LotSize = this.LotSize;
    messageSymbol.VariableTickList = this.VariableTickList;
    messageSymbol.LotStep = this.LotStep;
    messageSymbol.NotionalValueStep = this.NotionalValueStep;
    messageSymbol.MaxLot = this.MaxLot;
    messageSymbol.MinLot = this.MinLot;
    AdditionalInfoCollection additionalInfo = this.AdditionalInfo;
    messageSymbol.SymbolAdditionalInfo = additionalInfo != null ? additionalInfo.Items.ToList<AdditionalInfoItem>() : (List<AdditionalInfoItem>) null;
    messageSymbol.NettingType = this.NettingType;
    messageSymbol.Root = this.Root;
    messageSymbol.OptionType = this.OptionType;
    messageSymbol.StrikePrice = this.StrikePrice;
    messageSymbol.ExpirationDate = this.ExpirationDate;
    messageSymbol.HistoryType = this.HistoryType;
    messageSymbol.VolumeType = this.VolumeType;
    messageSymbol.LastTradingDate = this.LastTradingDate;
    messageSymbol.AllowCalculateRealtimeTicks = this.AllowCalculateRealtimeTicks;
    messageSymbol.AllowCalculateRealtimeTrades = this.AllowCalculateRealtimeTrades;
    messageSymbol.AllowCalculateRealtimeVolume = this.AllowCalculateRealtimeVolume;
    messageSymbol.AllowCalculateRealtimeChange = this.AllowCalculateRealtimeChange;
    messageSymbol.AllowAbbreviatePriceByTickSize = this.AllowAbbreviatePriceByTickSize;
    messageSymbol.DeltaCalculationType = this.DeltaCalculationType;
    messageSymbol.MinVolumeAnalysisTickSize = this.MinVolumeAnalysisTickSize;
    messageSymbol.AvailableFutures = this.AvailableFutures;
    messageSymbol.AvailableOptions = this.AvailableOptions;
    messageSymbol.AvailableOptionsExchanges = ((IEnumerable<Exchange>) this.AvailableOptionsExchanges).Any<Exchange>() ? ((IEnumerable<Exchange>) this.AvailableOptionsExchanges).Select<Exchange, string>((Func<Exchange, string>) (([In] obj0) => obj0.Id)).ToArray<string>() : (string[]) null;
    messageSymbol.UnderlierId = this.Underlier?.Id;
    messageSymbol.MaturityDate = this.MaturityDate;
    messageSymbol.OptionSerieId = this.OptionSerie?.Id;
    messageSymbol.SessionsContainerId = this.픎픋;
    messageSymbol.HistoryMetadata = this.historyMetadata == null ? (HistoryMetadata) null : new HistoryMetadata(this.historyMetadata);
    messageSymbol.FutureContractType = this.FutureContractType;
    return messageSymbol;
  }

  DayBar IMessageBuilder<DayBar>.퓲()
  {
    return new DayBar(this.Id, Core.Instance.TimeUtils.DateTimeUtcNow)
    {
      Ask = this.Ask,
      AskSize = this.AskSize,
      AverageTradedPrice = this.AverageTradedPrice,
      TotalBuyQuantity = this.TotalBuyQuantity,
      TotalSellQuantity = this.TotalSellQuantity,
      Bid = this.Bid,
      BidSize = this.BidSize,
      BottomPriceLimit = this.BottomPriceLimit,
      Change = this.Change,
      ChangePercentage = this.ChangePercentage,
      High = this.High,
      Last = this.Last,
      LastSize = this.LastSize,
      Mark = this.Mark,
      Low = this.Low,
      Open = this.Open,
      OpenInterest = this.OpenInterest,
      FundingRate = this.FundingRate,
      PreviousClose = this.PrevClose,
      PrevSettlementPrice = this.PrevSettlement,
      Ticks = this.Ticks,
      TopPriceLimit = this.TopPriceLimit,
      Trades = this.Trades,
      Volume = this.Volume,
      QuoteAssetVolume = this.QuoteAssetVolume,
      IV = this.IV,
      Delta = this.Delta,
      Vega = this.Vega,
      Gamma = this.Gamma,
      Theta = this.Theta,
      Rho = this.Rho
    };
  }

  /// <summary>Gets symbol orders types list which are allowed.</summary>
  /// <param name="usage"></param>
  /// <returns></returns>
  [NotPublished]
  public virtual List<OrderType> GetAlowedOrderTypes(OrderTypeUsage? usage)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Symbol.퓲 퓲 = new Symbol.퓲();
    // ISSUE: reference to a compiler-generated field
    퓲.핋퓐 = usage;
    if (this.State == BusinessObjectState.Fake)
      return new List<OrderType>();
    Connection connection = Core.Instance.Connections[this.ConnectionId];
    if (connection == null || connection.BusinessObjects.OrderTypes == null)
      return (List<OrderType>) null;
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated method
    return !퓲.핋퓐.HasValue ? ((IEnumerable<OrderType>) connection.BusinessObjects.OrderTypes).ToList<OrderType>() : ((IEnumerable<OrderType>) connection.BusinessObjects.OrderTypes).Where<OrderType>(new Func<OrderType, bool>(퓲.퓏)).ToList<OrderType>();
  }

  public virtual bool IsTradingAllowed(Account account)
  {
    return TradingOperations.IsAllowed(TradingOperation.PlaceOrder, new TradingOperationParameters()
    {
      Symbol = this,
      Account = account
    }).Status != TradingOperationStatus.NotAllowed;
  }

  internal virtual TradingOperationResult 퓏([In] PlaceOrderRequestParameters obj0)
  {
    return obj0 != null ? this.Connection.퓏(obj0) : throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓫());
  }

  /// <summary>
  /// An symbol has possibility to obtain the default account
  /// </summary>
  [NotPublished]
  public virtual Account GetDefaultAccount(Account currentValue = null)
  {
    if (currentValue?.ConnectionId == this.ConnectionId)
      return currentValue;
    Connection connection = this.Connection;
    if (connection == null)
      return (Account) null;
    IBusinessObjectsProvider businessObjects = connection.BusinessObjects;
    if (businessObjects == null)
      return (Account) null;
    Account[] accounts = businessObjects.Accounts;
    return accounts == null ? (Account) null : ((IEnumerable<Account>) accounts).FirstOrDefault<Account>();
  }

  public MarginInfo GetMarginInfo(OrderRequestParameters orderRequestParameters)
  {
    return this.Connection?.퓏(orderRequestParameters);
  }

  public virtual ConnectionDependency GetConnectionStateDependency()
  {
    return new ConnectionDependency()
    {
      Behavior = ConnectionDependencyBehavior.PartialDependency,
      DependentConnectionsIds = new string[1]
      {
        this.ConnectionId
      }
    };
  }

  public virtual void OnConnectionStateChanged(
    Connection connection,
    ConnectionStateChangedEventArgs e)
  {
  }

  public static TickDirection DetermineTickDirection(
    double previousPrice,
    double currentPrice,
    TickDirection prevItemTickDirection)
  {
    if (double.IsNaN(previousPrice) || double.IsNaN(currentPrice))
      return TickDirection.NotSet;
    if (currentPrice > previousPrice)
      return TickDirection.Up;
    return currentPrice < previousPrice ? TickDirection.Down : prevItemTickDirection;
  }

  [NotPublished]
  public static AggressorFlag ConvertTickDirection(TickDirection tickDirection)
  {
    AggressorFlag aggressorFlag;
    switch (tickDirection)
    {
      case TickDirection.None:
        aggressorFlag = AggressorFlag.None;
        break;
      case TickDirection.Up:
        aggressorFlag = AggressorFlag.Buy;
        break;
      case TickDirection.Down:
        aggressorFlag = AggressorFlag.Sell;
        break;
      default:
        aggressorFlag = AggressorFlag.NotSet;
        break;
    }
    return aggressorFlag;
  }
}
