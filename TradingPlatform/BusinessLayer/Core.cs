// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Core
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using TradingPlatform.BusinessLayer.Integration;
using TradingPlatform.BusinessLayer.Licence;
using TradingPlatform.BusinessLayer.LocalOrders;
using TradingPlatform.BusinessLayer.Media.Messengers;
using TradingPlatform.BusinessLayer.Settings.OTP;
using TradingPlatform.BusinessLayer.Utils;
using TradingPlatform.BusinessLayer.Utils.TradingProtection;
using 퓏;

#nullable enable
namespace TradingPlatform.BusinessLayer;

/// <summary>
/// The main entry point in the API. Core keeps access to all business logic entities and their properties:
/// connections, accounts, symbols, positions, orders, etc. Some of them can be reached through using managers or directly via specified collections.
/// You can always access the Core object via static Core.Instance property.
/// </summary>
[Published]
public class Core : IDisposable, IBusinessObjectsProvider
{
  private static 
  #nullable disable
  Core 픾픍;
  private TradingStatus 픾픭;
  private readonly List<HistoricalSymbol> 픾퓚;
  private Timer 퓍핇;

  /// <summary>
  /// Gets a singleton instance of <see cref="T:TradingPlatform.BusinessLayer.Core" />. API entry point
  /// </summary>
  public static Core Instance
  {
    get
    {
      lock (typeof (Core))
      {
        if (Core.픾픍 == null)
          Core.픾픍 = new Core();
      }
      return Core.픾픍;
    }
  }

  /// <summary>
  /// Gets an access to all created connections and manages them
  /// </summary>
  public ConnectionsManager Connections { get; }

  /// <summary>Gets an access to the system logging mechanism</summary>
  public LoggerManager Loggers { get; }

  /// <summary>Obtains licence rules for the current user</summary>
  [NotPublished]
  public LicencesManager Licences { get; }

  /// <summary>
  /// Gets an access to all available trading data vendors and creates them
  /// </summary>
  [NotPublished]
  public VendorManager Vendors { get; }

  /// <summary>Gets an access to the all available aggregation types</summary>
  [NotPublished]
  public HistoryAggregationManager HistoryAggregations { get; }

  /// <summary>Access to Volume Analysis calculations</summary>
  public VolumeAnalysisManager VolumeAnalysis { get; }

  /// <summary>
  /// Gets an access to the all available indicators and creates them
  /// </summary>
  public IndicatorManager Indicators { get; }

  /// <summary>
  /// Gets an access to the all available trading strategies and manages them
  /// </summary>
  public StrategyManager Strategies { get; }

  public OrderPlacingStrategiesManager OrderPlacingStrategies { get; }

  public MessengersManager Messengers { get; }

  public LocalOrdersManager LocalOrders { get; }

  /// <summary>
  /// Gets a <see cref="T:TradingPlatform.BusinessLayer.Rule" /> permissions checking mechanism
  /// </summary>
  [NotPublished]
  public RulesManager RulesManager { get; }

  public SymbolsMappingManager SymbolsMapping { get; }

  public CustomSessionsManager CustomSessions { get; }

  /// <summary>
  /// Gets a time based conversion and synchronization mechanism
  /// </summary>
  public TimeUtils TimeUtils { get; }

  /// <summary>Gets SMTP mail service for sending emails</summary>
  public MailUtils MailUtils { get; }

  public TradingProtector TradingProtection { get; }

  public IBrandingInformation BrandingInformation { get; [param: In] private set; }

  public Version CurrentVersion
  {
    get => new Version(this.GetType().Assembly.GetName().Version.ToString(3));
  }

  /// <summary>Represents current trading status</summary>
  public TradingStatus TradingStatus
  {
    get => this.픾픭;
    set
    {
      this.픾픭 = value;
      Action<TradingStatus> 픾픔 = this.픾픔;
      if (픾픔 == null)
        return;
      픾픔(value);
    }
  }

  /// <summary>
  /// Will be triggered when <see cref="P:TradingPlatform.BusinessLayer.Core.TradingStatus" /> changed
  /// </summary>
  public event Action<TradingStatus> OnTradingStatusChanged;

  internal 퓞<int, CustomMessage> CustomMessageProcessor { get; [param: In] private set; }

  private bool AlreadyInitialized { get; [param: In] set; }

  public CustomAccountPropertiesProvider CustomAccountPropertiesProvider { get; [param: In] private set; }

  /// <summary>
  /// Gets all available <see cref="T:TradingPlatform.BusinessLayer.Symbol" />s from open connections
  /// </summary>
  public Symbol[] Symbols
  {
    get
    {
      return ((IEnumerable<Connection>) this.Connections.Connected).SelectMany<Connection, Symbol>((Func<Connection, IEnumerable<Symbol>>) (([In] obj0) => (IEnumerable<Symbol>) obj0.BusinessObjects.Symbols)).ToArray<Symbol>();
    }
  }

  /// <summary>
  /// Gets all available <see cref="T:TradingPlatform.BusinessLayer.SymbolType" />s from open connections
  /// </summary>
  public SymbolType[] SymbolTypes
  {
    get
    {
      return ((IEnumerable<Connection>) this.Connections.Connected).SelectMany<Connection, SymbolType>((Func<Connection, IEnumerable<SymbolType>>) (([In] obj0) => (IEnumerable<SymbolType>) obj0.BusinessObjects.SymbolTypes)).Distinct<SymbolType>().ToArray<SymbolType>();
    }
  }

  /// <summary>
  /// Gets all available <see cref="T:TradingPlatform.BusinessLayer.Account" />s from open connections
  /// </summary>
  public Account[] Accounts
  {
    get
    {
      return ((IEnumerable<Connection>) this.Connections.Connected).SelectMany<Connection, Account>((Func<Connection, IEnumerable<Account>>) (([In] obj0) => (IEnumerable<Account>) obj0.BusinessObjects.Accounts)).ToArray<Account>();
    }
  }

  /// <summary>
  /// Gets all available <see cref="T:TradingPlatform.BusinessLayer.Asset" />s from open connections
  /// </summary>
  public Asset[] Assets
  {
    get
    {
      return ((IEnumerable<Connection>) this.Connections.Connected).SelectMany<Connection, Asset>((Func<Connection, IEnumerable<Asset>>) (([In] obj0) => (IEnumerable<Asset>) obj0.BusinessObjects.Assets)).ToArray<Asset>();
    }
  }

  /// <summary>
  /// Gets all available <see cref="T:TradingPlatform.BusinessLayer.Exchange" />s from open connections
  /// </summary>
  public Exchange[] Exchanges
  {
    get
    {
      return ((IEnumerable<Connection>) this.Connections.Connected).SelectMany<Connection, Exchange>((Func<Connection, IEnumerable<Exchange>>) (([In] obj0) => (IEnumerable<Exchange>) obj0.BusinessObjects.Exchanges)).ToArray<Exchange>();
    }
  }

  /// <summary>
  /// Gets all available <see cref="T:TradingPlatform.BusinessLayer.Order" />s from open connections
  /// </summary>
  public Order[] Orders
  {
    get
    {
      return ((IEnumerable<Connection>) this.Connections.Connected).SelectMany<Connection, Order>((Func<Connection, IEnumerable<Order>>) (([In] obj0) => (IEnumerable<Order>) obj0.BusinessObjects.Orders)).ToArray<Order>();
    }
  }

  /// <summary>
  /// Gets all available <see cref="T:TradingPlatform.BusinessLayer.OrderType" />s from open connections
  /// </summary>
  public OrderType[] OrderTypes
  {
    get
    {
      return ((IEnumerable<Connection>) this.Connections.Connected).SelectMany<Connection, OrderType>((Func<Connection, IEnumerable<OrderType>>) (([In] obj0) => (IEnumerable<OrderType>) obj0.BusinessObjects.OrderTypes)).ToArray<OrderType>();
    }
  }

  /// <summary>
  /// Gets all available <see cref="T:TradingPlatform.BusinessLayer.Position" />s from open connections
  /// </summary>
  public Position[] Positions
  {
    get
    {
      return ((IEnumerable<Connection>) this.Connections.Connected).SelectMany<Connection, Position>((Func<Connection, IEnumerable<Position>>) (([In] obj0) => (IEnumerable<Position>) obj0.BusinessObjects.Positions)).ToArray<Position>();
    }
  }

  /// <summary>
  /// Gets all available <see cref="T:TradingPlatform.BusinessLayer.ClosedPosition" />s from open connections
  /// </summary>
  public ClosedPosition[] ClosedPositions
  {
    get
    {
      return ((IEnumerable<Connection>) this.Connections.Connected).SelectMany<Connection, ClosedPosition>((Func<Connection, IEnumerable<ClosedPosition>>) (([In] obj0) => (IEnumerable<ClosedPosition>) obj0.BusinessObjects.ClosedPositions)).ToArray<ClosedPosition>();
    }
  }

  /// <summary>
  /// Gets all available <see cref="T:TradingPlatform.BusinessLayer.CorporateAction" />s from open connections
  /// </summary>
  public CorporateAction[] CorporateActions
  {
    get
    {
      return ((IEnumerable<Connection>) this.Connections.Connected).SelectMany<Connection, CorporateAction>((Func<Connection, IEnumerable<CorporateAction>>) (([In] obj0) => (IEnumerable<CorporateAction>) obj0.BusinessObjects.CorporateActions)).ToArray<CorporateAction>();
    }
  }

  /// <summary>
  /// Gets all available <see cref="T:TradingPlatform.BusinessLayer.ReportType" />s from open connections. Otherwise returns empty list
  /// </summary>
  /// &gt;
  public ReportType[] ReportTypes
  {
    get
    {
      return ((IEnumerable<Connection>) this.Connections.Connected).SelectMany<Connection, ReportType>((Func<Connection, IEnumerable<ReportType>>) (([In] obj0) => (IEnumerable<ReportType>) obj0.BusinessObjects.ReportTypes)).ToArray<ReportType>();
    }
  }

  public AccountOperation[] AccountOperations
  {
    get
    {
      return ((IEnumerable<Connection>) this.Connections.Connected).SelectMany<Connection, AccountOperation>((Func<Connection, IEnumerable<AccountOperation>>) (([In] obj0) => (IEnumerable<AccountOperation>) obj0.BusinessObjects.AccountOperations)).ToArray<AccountOperation>();
    }
  }

  /// <summary>
  /// Gets all available <see cref="T:TradingPlatform.BusinessLayer.TradingSignal" />s from open connections. Otherwise returns empty list
  /// </summary>
  /// &gt;
  public TradingSignal[] TradingSignals
  {
    get
    {
      return ((IEnumerable<Connection>) this.Connections.Connected).SelectMany<Connection, TradingSignal>((Func<Connection, IEnumerable<TradingSignal>>) (([In] obj0) => (IEnumerable<TradingSignal>) obj0.BusinessObjects.TradingSignals)).ToArray<TradingSignal>();
    }
  }

  private Core()
  {
    퓏.핇.퓏(this.GetType().Assembly.Location);
    this.Connections = new ConnectionsManager();
    this.Loggers = new LoggerManager();
    this.Licences = new LicencesManager();
    this.Vendors = new VendorManager();
    this.HistoryAggregations = new HistoryAggregationManager();
    this.VolumeAnalysis = new VolumeAnalysisManager();
    this.Indicators = new IndicatorManager();
    this.Strategies = new StrategyManager();
    this.OrderPlacingStrategies = new OrderPlacingStrategiesManager();
    this.SymbolListManager = new SymbolsListManager();
    this.RulesManager = new RulesManager();
    this.SymbolsMapping = new SymbolsMappingManager();
    this.CustomSessions = new CustomSessionsManager();
    this.Messengers = new MessengersManager();
    this.LocalOrders = new LocalOrdersManager();
    this.TimeUtils = new TimeUtils();
    this.MailUtils = new MailUtils();
    this.TradingProtection = new TradingProtector();
    this.픾퓚 = new List<HistoricalSymbol>();
    this.CustomAccountPropertiesProvider = new CustomAccountPropertiesProvider();
  }

  /// <summary>
  /// Starts a <see cref="T:TradingPlatform.BusinessLayer.Core" /> initialization process which initializes given Managers, <see cref="T:TradingPlatform.BusinessLayer.Connection" /> and Utils. And provides a subscribing on events.
  /// </summary>
  [NotPublished]
  public void Initialize()
  {
    lock (Core.픾픍)
    {
      if (this.AlreadyInitialized)
        return;
      this.AlreadyInitialized = true;
    }
    this.CustomMessageProcessor = new 퓞<int, CustomMessage>();
    ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
    this.Loggers.퓏();
    this.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픕(), LoggingLevel.Verbose);
    this.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픱(), LoggingLevel.Verbose);
    this.TimeUtils.퓏();
    this.Licences.퓏();
    this.Vendors.퓏();
    this.HistoryAggregations.퓏();
    this.VolumeAnalysis.퓏();
    this.Indicators.퓏();
    this.Strategies.퓏();
    this.OrderPlacingStrategies.퓏();
    this.Connections.Initialize();
    this.SymbolsMapping.퓏();
    this.Messengers.퓏();
    this.SymbolListManager.퓏();
    this.LocalOrders.Initialize();
    this.AdvancedTradingOperations = new AdvancedTradingOperations();
    this.퓏();
    this.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픶(), LoggingLevel.Verbose);
  }

  /// <summary>
  /// Disposes all previously initialized modules and unsubscribe from events
  /// </summary>
  [NotPublished]
  public void Dispose()
  {
    lock (Core.픾픍)
    {
      if (!this.AlreadyInitialized)
        return;
      this.Licences.Dispose();
      this.Vendors.퓬();
      this.HistoryAggregations.퓬();
      this.VolumeAnalysis.퓬();
      this.Indicators.Dispose();
      this.Strategies.Dispose();
      this.OrderPlacingStrategies.Dispose();
      this.Messengers.Dispose();
      this.Connections.Dispose();
      this.TimeUtils.퓬();
      this.MailUtils.퓏();
      this.Loggers.Dispose();
      if (this.퓍핇 != null)
      {
        this.퓍핇.Dispose();
        this.퓍핇 = (Timer) null;
      }
      this.AlreadyInitialized = false;
      lock (typeof (Core))
        Core.픾픍 = (Core) null;
    }
  }

  /// <summary>
  /// Will be triggered when new <see cref="T:TradingPlatform.BusinessLayer.Account" /> added to the core
  /// </summary>
  public event Action<Account> AccountAdded;

  /// <summary>
  /// Gets an instance of exist Account or creates a new one with given info parameter
  /// </summary>
  /// <param name="accountInfo"></param>
  /// <returns></returns>
  public Account GetAccount(BusinessObjectInfo accountInfo)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Core.퓬 퓬 = new Core.퓬();
    // ISSUE: reference to a compiler-generated field
    퓬.퓥핇 = accountInfo;
    // ISSUE: reference to a compiler-generated field
    if (퓬.퓥핇 == (BusinessObjectInfo) null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픀());
    // ISSUE: reference to a compiler-generated field
    Connection connection = this.Connections[퓬.퓥핇.ConnectionId];
    Account account1;
    if (connection == null)
    {
      account1 = (Account) null;
    }
    else
    {
      IBusinessObjectsProvider businessObjects = connection.BusinessObjects;
      if (businessObjects == null)
      {
        account1 = (Account) null;
      }
      else
      {
        Account[] accounts = businessObjects.Accounts;
        // ISSUE: reference to a compiler-generated method
        account1 = accounts != null ? ((IEnumerable<Account>) accounts).FirstOrDefault<Account>(new Func<Account, bool>(퓬.퓏)) : (Account) null;
      }
    }
    Account account2 = account1;
    if (account2 != null)
      return account2;
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    return 퓬.퓥핇 is 픟 퓥핇 && 퓥핇.IsCrypto ? (Account) new CryptoAccount(퓬.퓥핇) : new Account(퓬.퓥핇);
  }

  internal void 퓏([In] Account obj0) => this.픾핉.InvokeSafely((object) obj0);

  /// <summary>
  /// Will be triggered when new <see cref="T:TradingPlatform.BusinessLayer.Symbol" /> added to the core
  /// </summary>
  public event Action<Symbol> SymbolAdded;

  internal void 퓏([In] Symbol obj0) => this.픾핊.InvokeSafely((object) obj0);

  /// <summary>
  /// Returns all <see cref="T:TradingPlatform.BusinessLayer.Symbol" />s from open connections which satisfy given request parameters, otherwise returns empty list
  /// </summary>
  /// <param name="requestParameters"></param>
  /// <returns></returns>
  [NotPublished]
  public IList<Symbol> SearchSymbols(SearchSymbolsRequestParameters requestParameters)
  {
    List<Symbol> symbolList = new List<Symbol>();
    if (string.IsNullOrEmpty(requestParameters.ConnectionId))
    {
      foreach (Connection connection in this.Connections.Connected)
      {
        IList<Symbol> collection = connection.퓏(requestParameters);
        if (collection != null)
          symbolList.AddRange((IEnumerable<Symbol>) collection);
      }
    }
    else
    {
      IList<Symbol> collection = this.Connections[requestParameters.ConnectionId]?.퓏(requestParameters);
      if (collection != null)
        symbolList.AddRange((IEnumerable<Symbol>) collection);
    }
    return (IList<Symbol>) symbolList;
  }

  /// <summary>
  /// Retrieves any <see cref="T:TradingPlatform.BusinessLayer.Symbol" /> by given request parameters. Otherwise returns null
  /// </summary>
  /// <param name="requestParameters"></param>
  /// <param name="connectionId"> Must be specified if open connections total is more than one. Will search only in Synthetic symbols list if id is equal to <see cref="F:TradingPlatform.BusinessLayer.Synthetic.SYNTHETIC_CONNECTION_ID" /> </param>
  /// <param name="downloadSymbol"></param>
  /// <returns></returns>
  public Symbol GetSymbol(
    GetSymbolRequestParameters requestParameters,
    string connectionId = null,
    NonFixedListDownload downloadSymbol = NonFixedListDownload.Download)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Core.핇 핇 = new Core.핇();
    // ISSUE: reference to a compiler-generated field
    핇.퓥퓲 = requestParameters;
    if (connectionId == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픖())
    {
      // ISSUE: reference to a compiler-generated method
      return (Symbol) this.Synthetics.Find(new Predicate<Synthetic>(핇.퓏));
    }
    if (connectionId == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓘())
    {
      // ISSUE: reference to a compiler-generated method
      return (Symbol) this.HistoricalSymbols.Find(new Predicate<HistoricalSymbol>(핇.퓏));
    }
    if (!string.IsNullOrEmpty(connectionId))
    {
      // ISSUE: reference to a compiler-generated field
      return this.Connections[connectionId]?.퓏(핇.퓥퓲, downloadSymbol);
    }
    if (((IEnumerable<Connection>) this.Connections.All).Count<Connection>((Func<Connection, bool>) (([In] obj0) => obj0.Connected)) > 1)
      throw new ArgumentException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픓());
    // ISSUE: reference to a compiler-generated field
    return ((IEnumerable<Connection>) this.Connections.All).FirstOrDefault<Connection>((Func<Connection, bool>) (([In] obj0) => obj0.Connected))?.퓏(핇.퓥퓲, downloadSymbol);
  }

  /// <summary>
  /// Gets an instance of exist symbol or creates a new one with given info parameter
  /// </summary>
  /// <param name="symbolInfo"></param>
  /// <returns></returns>
  public Symbol GetSymbol(BusinessObjectInfo symbolInfo)
  {
    if (symbolInfo == (BusinessObjectInfo) null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픩());
    return this.GetSymbol(new GetSymbolRequestParameters()
    {
      SymbolId = symbolInfo.Id
    }, symbolInfo.ConnectionId) ?? new Symbol(symbolInfo);
  }

  [NotPublished]
  public IList<Symbol> GetFutureContracts(Symbol underlier)
  {
    return this.GetFutureContracts(new GetFutureContractsRequestParameters()
    {
      ConnectionId = underlier.ConnectionId,
      ExchangeId = underlier.Exchange.Id,
      UnderlierId = underlier.Id
    });
  }

  [NotPublished]
  public IList<Symbol> GetFutureContracts(string root, string exchangeId, string connectionId = null)
  {
    return this.GetFutureContracts(new GetFutureContractsRequestParameters()
    {
      ConnectionId = connectionId,
      Root = root,
      ExchangeId = exchangeId
    });
  }

  [NotPublished]
  public IList<Symbol> GetFutureContracts(
    GetFutureContractsRequestParameters requestParameters)
  {
    if (requestParameters == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁필());
    if (string.IsNullOrEmpty(requestParameters.Root) && string.IsNullOrEmpty(requestParameters.UnderlierId))
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓖());
    if (!string.IsNullOrEmpty(requestParameters.ConnectionId))
      return this.Connections[requestParameters.ConnectionId]?.퓏(requestParameters);
    if (((IEnumerable<Connection>) this.Connections.All).Count<Connection>((Func<Connection, bool>) (([In] obj0) => obj0.Connected)) > 1)
      throw new ArgumentException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픵());
    return ((IEnumerable<Connection>) this.Connections.All).FirstOrDefault<Connection>()?.퓏(requestParameters);
  }

  [NotPublished]
  public virtual IList<OptionSerie> GetOptionSeries(Symbol underlier)
  {
    return this.GetOptionSeries(new GetOptionSeriesRequestParameters(underlier));
  }

  [NotPublished]
  public virtual IList<OptionSerie> GetOptionSeries(
    GetOptionSeriesRequestParameters requestParameters)
  {
    if (requestParameters == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁필());
    if (string.IsNullOrEmpty(requestParameters.ConnectionId))
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픐());
    if (string.IsNullOrEmpty(requestParameters.UnderlierId))
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픬());
    return this.Connections[requestParameters.ConnectionId]?.퓏(requestParameters);
  }

  [NotPublished]
  public virtual IList<Symbol> GetStrikes(OptionSerie serie)
  {
    return this.GetStrikes(new GetStrikesRequestParameters(serie));
  }

  [NotPublished]
  public virtual IList<Symbol> GetStrikes(GetStrikesRequestParameters requestParameters)
  {
    if (requestParameters == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁필());
    if (string.IsNullOrEmpty(requestParameters.ConnectionId))
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픐());
    if (string.IsNullOrEmpty(requestParameters.UnderlierId))
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픬());
    if (string.IsNullOrEmpty(requestParameters.SerieId))
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓕());
    return this.Connections[requestParameters.ConnectionId]?.퓏(requestParameters);
  }

  /// <summary>
  /// Will be triggered when new <see cref="T:TradingPlatform.BusinessLayer.Order" /> placed
  /// </summary>
  public event Action<Order> OrderAdded;

  /// <summary>
  /// Will be triggered when <see cref="T:TradingPlatform.BusinessLayer.Order" /> canceled
  /// </summary>
  public event Action<Order> OrderRemoved;

  internal void 퓏([In] Order obj0)
  {
    LoggerManager loggers = this.Loggers;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 1);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픐());
    interpolatedStringHandler.AppendFormatted<Order>(obj0);
    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
    loggers.Log(stringAndClear);
    // ISSUE: reference to a compiler-generated field
    this.픾픛.InvokeSafely((object) obj0);
  }

  internal void 퓬([In] Order obj0)
  {
    LoggerManager loggers = this.Loggers;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 1);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픭());
    interpolatedStringHandler.AppendFormatted<Order>(obj0);
    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
    loggers.Log(stringAndClear);
    // ISSUE: reference to a compiler-generated field
    this.픾퓜.InvokeSafely((object) obj0);
  }

  /// <summary>
  /// Gets <see cref="T:TradingPlatform.BusinessLayer.OrderType" /> instance by given Id string. Otherwise returns null
  /// </summary>
  /// <param name="orderTypeId"></param>
  /// <param name="connectionId">Must be specified if open connections total is more than one</param>
  /// <returns></returns>
  public OrderType GetOrderType(string orderTypeId, string connectionId = null)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Core.퓲 퓲 = new Core.퓲();
    // ISSUE: reference to a compiler-generated field
    퓲.퓥핂 = orderTypeId;
    // ISSUE: reference to a compiler-generated field
    if (string.IsNullOrEmpty(퓲.퓥핂))
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픔());
    if (!string.IsNullOrEmpty(connectionId))
    {
      Connection connection = this.Connections[connectionId];
      if (connection == null)
        return (OrderType) null;
      IBusinessObjectsProvider businessObjects = connection.BusinessObjects;
      if (businessObjects == null)
        return (OrderType) null;
      OrderType[] orderTypes = businessObjects.OrderTypes;
      // ISSUE: reference to a compiler-generated method
      return orderTypes == null ? (OrderType) null : ((IEnumerable<OrderType>) orderTypes).FirstOrDefault<OrderType>(new Func<OrderType, bool>(퓲.퓏));
    }
    Connection[] array = ((IEnumerable<Connection>) this.Connections.All).Where<Connection>((Func<Connection, bool>) (([In] obj0) => obj0.Connected)).ToArray<Connection>();
    if (array.Length > 1)
      throw new ArgumentException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁핈());
    // ISSUE: reference to a compiler-generated method
    return ((IEnumerable<OrderType>) ((IEnumerable<Connection>) array).First<Connection>().BusinessObjects.OrderTypes).SingleOrDefault<OrderType>(new Func<OrderType, bool>(퓲.퓬));
  }

  /// <summary>
  /// Gets <see cref="T:TradingPlatform.BusinessLayer.Order" /> instance by given Id string. Otherwise returns null
  /// </summary>
  /// <param name="orderId"></param>
  /// <param name="connectionId">Must be specified if open connections total is more than one</param>
  /// <returns></returns>
  public Order GetOrderById(string orderId, string connectionId = null)
  {
    Connection connection1 = this.Connections[connectionId];
    if (connection1 != null)
      return connection1.퓏(orderId);
    foreach (Connection connection2 in this.Connections.All)
    {
      Order orderById = connection2.퓏(orderId);
      if (orderById != null)
        return orderById;
    }
    return (Order) null;
  }

  /// <summary>
  /// Will be triggered when new <see cref="T:TradingPlatform.BusinessLayer.Position" /> opened
  /// </summary>
  public event Action<Position> PositionAdded;

  /// <summary>
  /// Will be triggered when <see cref="T:TradingPlatform.BusinessLayer.Position" /> closed
  /// </summary>
  public event Action<Position> PositionRemoved;

  internal void 퓏([In] Position obj0) => this.픾픺.InvokeSafely((object) obj0);

  internal void 퓬([In] Position obj0) => this.픾핃.InvokeSafely((object) obj0);

  /// <summary>
  /// Gets <see cref="T:TradingPlatform.BusinessLayer.Position" /> instance by given Id string. Otherwise returns null
  /// </summary>
  /// <param name="positionId"></param>
  /// <param name="connectionId">Must be specified if open connections total is more than one</param>
  /// <returns></returns>
  public Position GetPositionById(string positionId, string connectionId = null)
  {
    Connection connection1 = this.Connections[connectionId];
    if (connection1 != null)
      return connection1.퓬(positionId);
    foreach (Connection connection2 in this.Connections.All)
    {
      Position positionById = connection2.퓬(positionId);
      if (positionById != null)
        return positionById;
    }
    return (Position) null;
  }

  /// <summary>
  /// Gets Profit'n'Loss <see cref="T:TradingPlatform.BusinessLayer.PnL" /> with given request parameters from open connection. Otherwise returns null
  /// </summary>
  /// <param name="parameters"></param>
  /// <returns></returns>
  public PnL CalculatePnL(PnLRequestParameters parameters)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: reference to a compiler-generated method
    Connection connection = ((IEnumerable<Connection>) this.Connections.All).FirstOrDefault<Connection>(new Func<Connection, bool>(new Core.핂()
    {
      퓥픂 = parameters.Account?.ConnectionId ?? parameters.Symbol.ConnectionId
    }.퓏));
    if (connection == null)
    {
      this.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픤(), LoggingLevel.Error);
      return (PnL) null;
    }
    if (connection.Connected)
      return connection.퓏(parameters);
    this.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픢(), LoggingLevel.Error);
    return (PnL) null;
  }

  /// <summary>
  /// Will be triggered when new <see cref="T:TradingPlatform.BusinessLayer.ClosedPosition" /> added
  /// </summary>
  public event Action<ClosedPosition> ClosedPositionAdded;

  /// <summary>
  /// Will be triggered when <see cref="T:TradingPlatform.BusinessLayer.ClosedPosition" /> removed
  /// </summary>
  public event Action<ClosedPosition> ClosedPositionRemoved;

  internal void 퓏([In] ClosedPosition obj0) => this.픾퓫.InvokeSafely((object) obj0);

  internal void 퓬([In] ClosedPosition obj0) => this.픾핌.InvokeSafely((object) obj0);

  /// <summary>
  /// Will be triggered when new <see cref="T:TradingPlatform.BusinessLayer.Trade" /> occured
  /// </summary>
  public event Action<Trade> TradeAdded;

  internal void 퓏([In] Trade obj0)
  {
    Order orderById = this.GetOrderById(obj0.OrderId, obj0.ConnectionId);
    LoggerManager loggers = this.Loggers;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 2);
    interpolatedStringHandler.AppendFormatted<Trade>(obj0);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓟());
    ref DefaultInterpolatedStringHandler local = ref interpolatedStringHandler;
    string str;
    if (orderById != null)
      str = $"{orderById}";
    else
      str = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁핉();
    local.AppendFormatted(str);
    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
    loggers.Log(stringAndClear);
    // ISSUE: reference to a compiler-generated field
    this.픾퓩.InvokeSafely((object) obj0);
  }

  /// <summary>
  /// Gets collection of <see cref="T:TradingPlatform.BusinessLayer.Trade" /> by given parameters
  /// </summary>
  /// <param name="parameters"></param>
  /// <param name="connectionId"></param>
  /// <returns></returns>
  public IList<Trade> GetTrades(TradesHistoryRequestParameters parameters, string connectionId = null)
  {
    if (parameters == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픾());
    if (!string.IsNullOrEmpty(connectionId))
      return this.Connections[connectionId]?.GetTrades(parameters) ?? (IList<Trade>) new List<Trade>();
    List<Trade> trades1 = new List<Trade>();
    foreach (Connection connection in this.Connections.All)
    {
      IList<Trade> trades2 = connection.GetTrades(new TradesHistoryRequestParameters(parameters));
      if (trades2 != null)
        trades1.AddRange((IEnumerable<Trade>) trades2);
    }
    return (IList<Trade>) trades1;
  }

  /// <summary>
  /// Gets collection of <see cref="T:TradingPlatform.BusinessLayer.Trade" /> by given parameters and callback
  /// </summary>
  /// <param name="parameters"></param>
  /// <param name="callback"></param>
  /// <param name="connectionId"></param>
  /// <exception cref="T:System.ArgumentNullException"></exception>
  public void GetTrades(
    TradesHistoryRequestParameters parameters,
    AccountTradesLoadingCallback callback,
    string connectionId = null)
  {
    if (parameters == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픾());
    if (callback == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓓());
    if (string.IsNullOrEmpty(connectionId))
    {
      foreach (Connection connection in this.Connections.All)
        connection.퓏(new TradesHistoryRequestParameters(parameters), callback);
    }
    this.Connections[connectionId]?.퓏(parameters, callback);
  }

  /// <summary>
  /// Will be triggered when new <see cref="T:TradingPlatform.BusinessLayer.CorporateAction" /> occured
  /// </summary>
  public event Action<CorporateAction> CorporateActionAdded;

  internal void 퓏([In] CorporateAction obj0) => this.픾퓨.InvokeSafely((object) obj0);

  /// <summary>
  /// Will be triggered when new <see cref="T:TradingPlatform.BusinessLayer.OrderHistory" /> added
  /// </summary>
  public event Action<OrderHistory> OrdersHistoryAdded;

  internal void 퓏([In] OrderHistory obj0)
  {
    LoggerManager loggers = this.Loggers;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 1);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁핊());
    interpolatedStringHandler.AppendFormatted<OrderHistory>(obj0);
    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
    loggers.Log(stringAndClear);
    // ISSUE: reference to a compiler-generated field
    this.픾퓱.InvokeSafely((object) obj0);
  }

  /// <summary>
  /// Gets collection of <see cref="T:TradingPlatform.BusinessLayer.OrderHistory" /> by given parameters
  /// </summary>
  /// <param name="parameters"></param>
  /// <param name="connectionId"></param>
  /// <returns></returns>
  public IList<OrderHistory> GetOrdersHistory(
    OrdersHistoryRequestParameters parameters,
    string connectionId = null)
  {
    if (parameters == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픾());
    if (!string.IsNullOrEmpty(connectionId))
      return this.Connections[connectionId]?.GetOrdersHistory(parameters) ?? (IList<OrderHistory>) new List<OrderHistory>();
    List<OrderHistory> ordersHistory1 = new List<OrderHistory>();
    foreach (Connection connection in this.Connections.All)
    {
      IList<OrderHistory> ordersHistory2 = connection.GetOrdersHistory(parameters);
      if (ordersHistory2 != null)
        ordersHistory1.AddRange((IEnumerable<OrderHistory>) ordersHistory2);
    }
    return (IList<OrderHistory>) ordersHistory1;
  }

  public TradingOperationResult PlaceOrder(
    Symbol symbol,
    Account account,
    Side side,
    TimeInForce timeInForce = TimeInForce.Day,
    double quantity = 1.0,
    double price = -1.0,
    double triggerPrice = -1.0,
    double trailOffset = -1.0)
  {
    if (symbol == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핋());
    if (account == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓑());
    PlaceOrderRequestParameters requestParameters = new PlaceOrderRequestParameters();
    requestParameters.Symbol = symbol;
    requestParameters.Account = account;
    requestParameters.Side = side;
    requestParameters.Quantity = quantity;
    requestParameters.TimeInForce = timeInForce;
    PlaceOrderRequestParameters request = requestParameters;
    if (price > 0.0 && triggerPrice <= 0.0 && trailOffset <= 0.0)
    {
      request.OrderTypeId = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픜();
      request.Price = price;
    }
    else if (triggerPrice > 0.0 && price <= 0.0 && trailOffset <= 0.0)
    {
      request.OrderTypeId = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픛();
      request.TriggerPrice = triggerPrice;
    }
    else if (price > 0.0 && triggerPrice > 0.0 && trailOffset <= 0.0)
    {
      request.OrderTypeId = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓜();
      request.Price = price;
      request.TriggerPrice = triggerPrice;
    }
    else if (trailOffset > 0.0 && price <= 0.0 && triggerPrice <= 0.0)
    {
      request.OrderTypeId = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픺();
      request.TrailOffset = trailOffset;
    }
    else
      request.OrderTypeId = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁핃();
    return this.PlaceOrder(request);
  }

  /// <summary>
  /// Places <see cref="T:TradingPlatform.BusinessLayer.Order" /> with given request parameters
  /// </summary>
  /// <param name="request"></param>
  /// <returns></returns>
  public TradingOperationResult PlaceOrder(PlaceOrderRequestParameters request)
  {
    if (request == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓫());
    TradingOperationResult tradingOperationResult;
    if (!this.퓏(request.Symbol?.Connection, request.RequestId, out tradingOperationResult) || !this.퓬(request.Symbol?.Connection, request.RequestId, out tradingOperationResult))
      return tradingOperationResult;
    return request.Symbol?.퓏(request);
  }

  /// <summary>
  /// Places multiple <see cref="T:TradingPlatform.BusinessLayer.Order" />s with given request parameters
  /// </summary>
  /// <param name="requests"></param>
  /// <param name="groupOrderType"></param>
  /// <returns></returns>
  public void PlaceOrders(
    ICollection<PlaceOrderRequestParameters> requests,
    GroupOrderType groupOrderType = GroupOrderType.None)
  {
    if (requests == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁핌());
    if (requests.Count == 1)
    {
      this.PlaceOrder(requests.Single<PlaceOrderRequestParameters>());
    }
    else
    {
      foreach (IGrouping<string, PlaceOrderRequestParameters> source in requests.GroupBy<PlaceOrderRequestParameters, string>((Func<PlaceOrderRequestParameters, string>) (([In] obj0) => obj0.ConnectionId)))
      {
        Connection connection = this.Connections[source.Key];
        if (this.RulesManager.IsAllowed(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓩(), connection.Id).Status == TradingOperationStatus.Allowed)
        {
          PlaceMultiOrderOrderRequestParameters requestParameters = new PlaceMultiOrderOrderRequestParameters()
          {
            GroupOrderType = groupOrderType,
            OrderParameters = source.ToArray<PlaceOrderRequestParameters>()
          };
          TradingOperationResult tradingOperationResult;
          if (this.퓏(connection, requestParameters.RequestId, out tradingOperationResult) && this.퓬(connection, requestParameters.RequestId, out tradingOperationResult))
            connection.퓏(requestParameters);
        }
        else if (groupOrderType == GroupOrderType.None)
        {
          foreach (PlaceOrderRequestParameters request in source.ToArray<PlaceOrderRequestParameters>())
            this.PlaceOrder(request);
        }
      }
    }
  }

  public TradingOperationResult ModifyOrder(
    Order order,
    TimeInForce timeInForce = TimeInForce.Default,
    double quantity = 1.0,
    double price = -1.0,
    double triggerPrice = -1.0,
    double trailOffset = -1.0)
  {
    ModifyOrderRequestParameters request = order != null ? new ModifyOrderRequestParameters((IOrder) order) : throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓨());
    if (timeInForce != TimeInForce.Default)
      request.TimeInForce = timeInForce;
    if (quantity > 0.0)
      request.Quantity = quantity;
    if (price > 0.0)
      request.Price = price;
    if (triggerPrice > 0.0)
      request.TriggerPrice = triggerPrice;
    if (trailOffset > 0.0)
      request.TrailOffset = trailOffset;
    return this.ModifyOrder(request);
  }

  /// <summary>
  /// Modifies <see cref="T:TradingPlatform.BusinessLayer.Order" /> by given request parameters
  /// </summary>
  /// <param name="request"></param>
  /// <returns></returns>
  public TradingOperationResult ModifyOrder(ModifyOrderRequestParameters request)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Core.픂 픂 = new Core.픂();
    // ISSUE: reference to a compiler-generated field
    픂.퓥픾 = request;
    // ISSUE: reference to a compiler-generated field
    if (픂.퓥픾 == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓫());
    TradingOperationResult result;
    // ISSUE: reference to a compiler-generated field
    if (this.LocalOrders.TryHandleTradingOperationRequest((TradingRequestParameters) 픂.퓥픾, out result))
      return result;
    // ISSUE: reference to a compiler-generated method
    Connection connection = ((IEnumerable<Connection>) this.Connections.All).FirstOrDefault<Connection>(new Func<Connection, bool>(픂.퓏));
    if (connection == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픤());
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    return !this.퓬(connection, 픂.퓥픾.RequestId, out result) ? result : connection.퓏(픂.퓥픾);
  }

  public TradingOperationResult ClosePosition(Position position, double closeQuantity = -1.0)
  {
    if (position == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓨());
    return this.ClosePosition(new ClosePositionRequestParameters()
    {
      Position = position,
      CloseQuantity = closeQuantity > 0.0 ? closeQuantity : position.Quantity
    });
  }

  /// <summary>
  /// Closes <see cref="T:TradingPlatform.BusinessLayer.Position" /> with given request parameters
  /// </summary>
  /// <param name="request"></param>
  /// <returns></returns>
  public TradingOperationResult ClosePosition(ClosePositionRequestParameters request)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Core.픾 픾 = new Core.픾();
    // ISSUE: reference to a compiler-generated field
    픾.퓥퓍 = request;
    // ISSUE: reference to a compiler-generated field
    if (픾.퓥퓍 == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓫());
    // ISSUE: reference to a compiler-generated method
    Connection connection = ((IEnumerable<Connection>) this.Connections.All).FirstOrDefault<Connection>(new Func<Connection, bool>(픾.퓏));
    if (connection == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픤());
    TradingOperationResult tradingOperationResult;
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    return !this.퓬(this.Connections[픾.퓥퓍.ConnectionId], 픾.퓥퓍.RequestId, out tradingOperationResult) ? tradingOperationResult : connection.퓏(픾.퓥퓍);
  }

  [Obsolete("Use CancelOrder(IOrder order) instead")]
  public TradingOperationResult CancelOrder(Order order, string sendingSource = null)
  {
    if (order == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓨());
    CancelOrderRequestParameters request = new CancelOrderRequestParameters();
    request.Order = (IOrder) order;
    request.SendingSource = sendingSource;
    return this.CancelOrder(request);
  }

  public TradingOperationResult CancelOrder(IOrder order, string sendingSource = null)
  {
    if (order == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓨());
    CancelOrderRequestParameters request = new CancelOrderRequestParameters();
    request.Order = order;
    request.SendingSource = sendingSource;
    return this.CancelOrder(request);
  }

  /// <summary>
  /// Cancels <see cref="T:TradingPlatform.BusinessLayer.Order" /> with given request parameters
  /// </summary>
  /// <param name="request"></param>
  /// <returns></returns>
  public TradingOperationResult CancelOrder(CancelOrderRequestParameters request)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Core.퓍 퓍 = new Core.퓍();
    // ISSUE: reference to a compiler-generated field
    퓍.퓥픁 = request;
    // ISSUE: reference to a compiler-generated field
    if (퓍.퓥픁 == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓫());
    TradingOperationResult result;
    // ISSUE: reference to a compiler-generated field
    if (this.LocalOrders.TryHandleTradingOperationRequest((TradingRequestParameters) 퓍.퓥픁, out result))
      return result;
    // ISSUE: reference to a compiler-generated method
    Connection connection = ((IEnumerable<Connection>) this.Connections.All).FirstOrDefault<Connection>(new Func<Connection, bool>(퓍.퓏));
    if (connection == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픤());
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    return !this.퓬(connection, 퓍.퓥픁.RequestId, out result) ? result : connection.퓏(퓍.퓥픁);
  }

  public AdvancedTradingOperations AdvancedTradingOperations { get; [param: In] private set; }

  /// <summary>
  /// Returns <see cref="T:TradingPlatform.BusinessLayer.Report" /> with given request parameters from open connection
  /// </summary>
  /// <param name="requestParameters"></param>
  /// <returns></returns>
  public Report GetReport(ReportRequestParameters requestParameters)
  {
    Connection connection = requestParameters.ReportType.Connection;
    if (connection == null)
    {
      this.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픤(), LoggingLevel.Error);
      return (Report) null;
    }
    if (connection.Connected)
      return connection.퓏(requestParameters);
    this.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픢(), LoggingLevel.Error);
    return (Report) null;
  }

  public DeliveredAsset[] DeliveredAssets
  {
    get
    {
      return ((IEnumerable<Connection>) this.Connections.Connected).SelectMany<Connection, DeliveredAsset>((Func<Connection, IEnumerable<DeliveredAsset>>) (([In] obj0) => (IEnumerable<DeliveredAsset>) obj0.BusinessObjects.DeliveredAssets)).ToArray<DeliveredAsset>();
    }
  }

  public event Action<DeliveredAsset> DeliveredAssetAdded;

  public event Action<DeliveredAsset> DeliveredAssetRemoved;

  internal void 퓏([In] DeliveredAsset obj0) => this.픾퓺.InvokeSafely((object) obj0);

  internal void 퓬([In] DeliveredAsset obj0) => this.픾픊.InvokeSafely((object) obj0);

  /// <summary>
  /// Will be triggered when new <see cref="T:TradingPlatform.BusinessLayer.DealTicket" /> received
  /// </summary>
  public event Action<DealTicket> DealTicketReceived;

  internal void 퓏([In] DealTicket obj0) => this.픾픈.InvokeSafely((object) obj0);

  [NotPublished]
  public void PushDealTicket(string header, string description, DealTicketType type)
  {
    // ISSUE: reference to a compiler-generated field
    this.픾픈.InvokeSafely((object) new DealTicket(header, description, type));
  }

  [NotPublished]
  public void PushDealTicket(DealTicket dealTicket) => this.픾픈.InvokeSafely((object) dealTicket);

  /// <summary>
  /// Sends custom request if connection with given Id is open
  /// </summary>
  /// <param name="connectionId"></param>
  /// <param name="parameters"></param>
  public void SendCustomRequest(string connectionId, RequestParameters parameters)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: reference to a compiler-generated method
    ((IEnumerable<Connection>) this.Connections.Connected).FirstOrDefault<Connection>(new Func<Connection, bool>(new Core.픁()
    {
      퓥픞 = connectionId
    }.퓏))?.SendCustomRequest(parameters);
  }

  /// <summary>Subscribe on custom messages</summary>
  /// <param name="handler">custom  message handler</param>
  /// <param name="messagesTypes">custom messages Id</param>
  public void SubscribeToCustomMessages(Action<CustomMessage> handler, params int[] messagesTypes)
  {
    this.CustomMessageProcessor.퓏(handler, messagesTypes);
  }

  /// <summary>Unsubscribe from custom messages</summary>
  /// <param name="handler">custom  message handler</param>
  /// <param name="messagesTypes">custom messages Id</param>
  public void UnsubscribeFromCustomMessages(
    Action<CustomMessage> handler,
    params int[] messagesTypes)
  {
    this.CustomMessageProcessor.퓬(handler, messagesTypes);
  }

  /// <summary>
  /// Gets all previously configured <see cref="T:TradingPlatform.BusinessLayer.SymbolList" />s
  /// </summary>
  [NotPublished]
  public TradingPlatform.BusinessLayer.SymbolList[] SymbolList => this.SymbolListManager.Items;

  /// <summary>
  /// Gets an access to <see cref="T:TradingPlatform.BusinessLayer.SymbolList" />s and manages them
  /// </summary>
  [NotPublished]
  public SymbolsListManager SymbolListManager { get; }

  /// <summary>
  /// Adds <see cref="T:TradingPlatform.BusinessLayer.SymbolList" /> if given parameters are valid
  /// </summary>
  /// <param name="symbolsListName"></param>
  /// <param name="symbols"></param>
  [NotPublished]
  public void AddSymbolList(string symbolsListName, IEnumerable<Symbol> symbols)
  {
    if (string.IsNullOrEmpty(symbolsListName))
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓱());
    if (symbols == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픹());
    this.SymbolListManager.퓏(symbolsListName, symbols);
  }

  /// <summary>
  /// Replaces exist list by new list in <see cref="T:TradingPlatform.BusinessLayer.SymbolList" /> if given parameters are valid
  /// </summary>
  /// <param name="symbolsListName"></param>
  /// <param name="symbols"></param>
  [NotPublished]
  public void ReplaceSymbolList(string symbolsListName, IList<Symbol> symbols)
  {
    if (string.IsNullOrEmpty(symbolsListName))
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓱());
    if (symbols == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픹());
    this.SymbolListManager.퓏(symbolsListName, symbols);
  }

  /// <summary>
  /// Removes <see cref="T:TradingPlatform.BusinessLayer.SymbolList" /> with a given name
  /// </summary>
  /// <param name="symbolsListName"></param>
  [NotPublished]
  public void RemoveSymbolList(string symbolsListName)
  {
    if (string.IsNullOrEmpty(symbolsListName))
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓱());
    this.SymbolListManager.퓏(symbolsListName);
  }

  /// <summary>
  /// Replaces list name by new given name in <see cref="T:TradingPlatform.BusinessLayer.SymbolList" /> if given parameters are valid
  /// </summary>
  /// <param name="symbolsListName"></param>
  /// <param name="newSymbolsListName"></param>
  [NotPublished]
  public void RenameSymbolList(string symbolsListName, string newSymbolsListName)
  {
    if (string.IsNullOrEmpty(symbolsListName))
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓱());
    if (string.IsNullOrEmpty(newSymbolsListName))
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓺());
    this.SymbolListManager.퓏(symbolsListName, newSymbolsListName);
  }

  /// <summary>Represent all available Historical Symbols</summary>
  [NotPublished]
  public List<HistoricalSymbol> HistoricalSymbols
  {
    get => new List<HistoricalSymbol>((IEnumerable<HistoricalSymbol>) this.픾퓚);
  }

  [NotPublished]
  public event Action<HistoricalSymbol> HistoricalSymbolAdded;

  [NotPublished]
  public event Action<HistoricalSymbol> HistoricalSymbolRemoved;

  [NotPublished]
  public event Action<HistoricalSymbol> HistoricalSymbolUpdated;

  [NotPublished]
  public void AddHistoricalSymbol(HistoricalSymbol historicalSymbol)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Core.픞 픞 = new Core.픞();
    // ISSUE: reference to a compiler-generated field
    픞.퓥핁 = historicalSymbol;
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated method
    if (this.픾퓚.Contains(픞.퓥핁) || this.픾퓚.Any<HistoricalSymbol>(new Func<HistoricalSymbol, bool>(픞.퓏)))
      return;
    // ISSUE: reference to a compiler-generated field
    this.픾퓚.Add(픞.퓥핁);
    // ISSUE: reference to a compiler-generated field
    픞.퓥핁.Updated += new SymbolUpdateHandler(this.퓬);
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    this.픾픃.InvokeSafely((object) 픞.퓥핁);
  }

  [NotPublished]
  public void RemoveHistoricalSymbol(HistoricalSymbol historicalSymbol)
  {
    if (!this.픾퓚.Contains(historicalSymbol))
      return;
    this.픾퓚.Remove(historicalSymbol);
    historicalSymbol.Updated -= new SymbolUpdateHandler(this.퓬);
    // ISSUE: reference to a compiler-generated field
    this.픾퓎.InvokeSafely((object) historicalSymbol);
    historicalSymbol.Dispose();
  }

  private void 퓬([In] Symbol obj0)
  {
    if (!(obj0 is HistoricalSymbol historicalSymbol))
      return;
    // ISSUE: reference to a compiler-generated field
    this.픾피.InvokeSafely((object) historicalSymbol);
  }

  /// <summary>
  /// Will be triggered when custom symbol <see cref="T:TradingPlatform.BusinessLayer.Synthetic" /> added
  /// </summary>
  [NotPublished]
  public event Action<Synthetic> SyntheticAdded;

  /// <summary>
  /// Will be triggered when custom symbol <see cref="T:TradingPlatform.BusinessLayer.Synthetic" /> removed
  /// </summary>
  [NotPublished]
  public event Action<Synthetic> SyntheticRemoved;

  /// <summary>
  /// Will be triggered when custom symbol <see cref="T:TradingPlatform.BusinessLayer.Synthetic" /> updated
  /// </summary>
  [NotPublished]
  public event Action<Synthetic> SyntheticUpdated;

  /// <summary>Represent all available Synthetic items</summary>
  [NotPublished]
  public List<Synthetic> Synthetics { get; } = new List<Synthetic>();

  /// <summary>
  /// Adds given Synthetic to the list <see cref="P:TradingPlatform.BusinessLayer.Core.Synthetics" /> if it does not contain
  /// </summary>
  /// <param name="synthetic"></param>
  [NotPublished]
  public void AddSynthetic(Synthetic synthetic)
  {
    if (this.Synthetics.Contains(synthetic))
      return;
    this.Synthetics.Add(synthetic);
    synthetic.Reinitialized += new Action<Synthetic>(this.퓏);
    // ISSUE: reference to a compiler-generated field
    this.픾퓸.InvokeSafely((object) synthetic);
  }

  private void 퓏([In] Synthetic obj0) => this.픾픋.InvokeSafely((object) obj0);

  /// <summary>
  /// Removes given Synthetic from the list <see cref="P:TradingPlatform.BusinessLayer.Core.Synthetics" /> if it exists
  /// </summary>
  /// <param name="synthetic"></param>
  [NotPublished]
  public void RemoveSynthetic(Synthetic synthetic)
  {
    if (!this.Synthetics.Contains(synthetic))
      return;
    this.Synthetics.Remove(synthetic);
    synthetic.Reinitialized -= new Action<Synthetic>(this.퓏);
    // ISSUE: reference to a compiler-generated field
    this.픾퓦.InvokeSafely((object) synthetic);
    synthetic.Dispose();
  }

  /// <summary>
  /// Will be triggered when <see cref="T:TradingPlatform.BusinessLayer.TradingSignal" /> created/chenged/removed
  /// </summary>
  public event EventHandler<TradingSignalEventArgs> TradingSignalUpdate;

  internal void 퓏([In] TradingSignal obj0, [In] EntityLifecycle obj1)
  {
    // ISSUE: reference to a compiler-generated field
    EventHandler<TradingSignalEventArgs> 픾픲 = this.픾픲;
    object[] objArray = new object[2]{ (object) this, null };
    TradingSignalEventArgs tradingSignalEventArgs = new TradingSignalEventArgs();
    tradingSignalEventArgs.TradingSignal = obj0;
    tradingSignalEventArgs.Lifecycle = obj1;
    objArray[1] = (object) tradingSignalEventArgs;
    픾픲.InvokeSafely(objArray);
  }

  public void Alert(
    string text,
    string symbolName,
    string connectionName,
    Action onConfirm,
    string alertName)
  {
    this.Alert(new TradingPlatform.BusinessLayer.Utils.Alert()
    {
      Text = text,
      SymbolName = symbolName,
      ConnectionName = connectionName,
      ActionOnConfirm = onConfirm,
      Name = alertName
    });
  }

  public void Alert(string text, string symbolName = "", string connectionName = "", Action onConfirm = null)
  {
    this.Alert(text, symbolName, connectionName, onConfirm, (string) null);
  }

  public void Alert(TradingPlatform.BusinessLayer.Utils.Alert alert)
  {
    // ISSUE: reference to a compiler-generated field
    this.픾픽.InvokeSafely((object) alert);
  }

  public event Action<TradingPlatform.BusinessLayer.Utils.Alert> OnAlert;

  public event Action<OTPHolder, string, string> OnRequestOTP;

  public void RequestOTP(OTPHolder otpHolder, string title, string text)
  {
    // ISSUE: reference to a compiler-generated field
    this.퓍퓏.InvokeSafely((object) otpHolder, (object) title, (object) text);
  }

  [CompilerGenerated]
  [SpecialName]
  internal void 퓏([In] Action obj0)
  {
    // ISSUE: reference to a compiler-generated field
    Action action = this.퓍퓬;
    Action comparand;
    do
    {
      comparand = action;
      // ISSUE: reference to a compiler-generated field
      action = Interlocked.CompareExchange<Action>(ref this.퓍퓬, comparand + obj0, comparand);
    }
    while (action != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  internal void 퓬([In] Action obj0)
  {
    // ISSUE: reference to a compiler-generated field
    Action action = this.퓍퓬;
    Action comparand;
    do
    {
      comparand = action;
      // ISSUE: reference to a compiler-generated field
      action = Interlocked.CompareExchange<Action>(ref this.퓍퓬, comparand - obj0, comparand);
    }
    while (action != comparand);
  }

  private void 퓏()
  {
    if (this.퓍핇 != null)
      return;
    this.퓍핇 = new Timer(new TimerCallback(this.퓏));
    this.퓍핇.Change(100, 100);
  }

  private void 퓏([In] object obj0)
  {
    try
    {
      this.퓬();
      // ISSUE: reference to a compiler-generated field
      this.퓍퓬.InvokeSafely();
      this.TradingProtection.퓏();
    }
    catch (Exception ex)
    {
      this.Loggers.Log(ex);
    }
  }

  private void 퓬()
  {
    foreach (Position position in this.Positions)
    {
      try
      {
        PnL pnL = this.CalculatePnL(new PnLRequestParameters()
        {
          Symbol = position.Symbol,
          Account = position.Account,
          OpenPrice = position.OpenPrice,
          ClosePrice = position.CurrentPrice,
          Side = position.Side,
          Quantity = position.Quantity,
          PositionId = position.Id
        });
        if (pnL != null)
          position.퓏(pnL);
      }
      catch (Exception ex)
      {
        Core.Instance.Loggers.Log(ex);
      }
    }
    foreach (ClosedPosition closedPosition1 in this.ClosedPositions)
    {
      try
      {
        if (closedPosition1.GrossPnL == null)
        {
          PnL pnL = this.CalculatePnL(new PnLRequestParameters()
          {
            Symbol = closedPosition1.Symbol,
            Account = closedPosition1.Account,
            OpenPrice = closedPosition1.OpenPrice,
            ClosePrice = closedPosition1.CurrentPrice,
            Side = closedPosition1.Side,
            Quantity = 0.0,
            PositionId = closedPosition1.Id
          });
          if (pnL != null)
          {
            closedPosition1.퓏(pnL);
            ClosedPosition closedPosition2 = closedPosition1;
            if (closedPosition2.GrossPnL == null)
            {
              PnLItem pnLitem;
              closedPosition2.GrossPnL = pnLitem = new PnLItem();
            }
          }
        }
      }
      catch (Exception ex)
      {
        Core.Instance.Loggers.Log(ex);
      }
    }
  }

  [NotPublished]
  public IBrowserFactory BrowserFactory { get; set; }

  [NotPublished]
  public IOAuthBrowserCreator OAuthBrowserCreator { get; set; }

  public void InitializeBrandingInformation()
  {
    IBrandingInformation brandingInformation = (IBrandingInformation) new 퓡();
    try
    {
      TypeWrapper typeWrapper = AssemblyLoader.LoadTypes(string.Empty, typeof (IBrandingInformation), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픊()).FirstOrDefault<TypeWrapper>();
      if (typeWrapper != null)
      {
        IBrandingInformation instance = (IBrandingInformation) Activator.CreateInstance((Type) typeWrapper);
        if (instance != null)
          brandingInformation = instance;
      }
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
    this.BrandingInformation = brandingInformation;
  }

  public void ForceTimeSync() => this.TimeUtils.TimeSynchronizer.퓬();

  private bool 퓏([In] Connection obj0, [In] long obj1, out TradingOperationResult _param3)
  {
    _param3 = (TradingOperationResult) null;
    bool flag;
    if (obj0 != null)
    {
      string vendorName = obj0.VendorName;
      if (vendorName == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픈() || vendorName == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓒() || vendorName == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓚())
      {
        flag = true;
        goto label_4;
      }
    }
    flag = false;
label_4:
    if (flag || this.TradingProtection.IsOperationAllowed())
      return true;
    string str = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픃(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓎());
    this.PushDealTicket(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓒(), str, DealTicketType.Refuse);
    this.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓒(), str, LoggingLevel.Error);
    _param3 = TradingOperationResult.CreateError(obj1, str);
    return false;
  }

  private bool 퓬([In] Connection obj0_1, [In] long obj1, out TradingOperationResult _param3)
  {
    _param3 = (TradingOperationResult) null;
    bool flag1;
    if (obj0_1 != null)
    {
      string vendorName = obj0_1.VendorName;
      if (vendorName == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픈() || vendorName == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓒() || vendorName == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓚())
      {
        flag1 = true;
        goto label_4;
      }
    }
    flag1 = false;
label_4:
    if (flag1 || !((IEnumerable<Connection>) Core.Instance.Connections.Connected).Any<Connection>((Func<Connection, bool>) (([In] obj0_2) =>
    {
      bool flag2;
      if (obj0_2 != null)
      {
        string vendorName = obj0_2.VendorName;
        if (vendorName == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픈() || vendorName == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓒() || vendorName == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓚())
        {
          flag2 = true;
          goto label_4;
        }
      }
      flag2 = false;
label_4:
      return flag2;
    })))
      return true;
    bool flag3 = false;
    // ISSUE: reference to a compiler-generated field
    if (this.퓍픂 != null)
    {
      // ISSUE: reference to a compiler-generated field
      flag3 = this.퓍픂(((IEnumerable<Connection>) Core.Instance.Connections.Connected).FirstOrDefault<Connection>((Func<Connection, bool>) (([In] obj0_3) =>
      {
        bool flag4;
        if (obj0_3 != null)
        {
          string vendorName = obj0_3.VendorName;
          if (vendorName == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픈() || vendorName == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓒() || vendorName == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓚())
          {
            flag4 = true;
            goto label_4;
          }
        }
        flag4 = false;
label_4:
        return flag4;
      })).Name, obj0_1.Name);
    }
    if (flag3)
      return true;
    string str = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁피(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓎());
    this.PushDealTicket(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓒(), str, DealTicketType.Refuse);
    this.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓒(), str, LoggingLevel.Error);
    _param3 = TradingOperationResult.CreateError(obj1, str);
    return false;
  }

  public event Func<string, string, bool> OnAskUserConfirmationForTradingWithRunningEmulator;

  public event EventHandler<RequestEventArgs> NewRequest;

  public event EventHandler<PerformedRequestEventArgs> NewPerformedRequest;

  internal void 퓏([In] RequestParameters obj0, [In] object obj1)
  {
    // ISSUE: reference to a compiler-generated field
    EventHandler<PerformedRequestEventArgs> 퓍퓍 = this.퓍퓍;
    if (퓍퓍 == null)
      return;
    퓍퓍.InvokeSafely((object) this, (object) new PerformedRequestEventArgs(obj0, obj1));
  }

  internal void 퓏([In] Connection obj0, [In] RequestEventArgs obj1)
  {
    // ISSUE: reference to a compiler-generated field
    EventHandler<RequestEventArgs> 퓍픾 = this.퓍픾;
    if (퓍픾 == null)
      return;
    퓍픾.InvokeSafely((object) obj0, (object) obj1);
  }
}
