// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.Vendor
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using TradingPlatform.BusinessLayer.Integration.Limitation;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

public abstract class Vendor : 
  ITradingVendor,
  IVendor,
  ISymbolVendor,
  IQuoteVendor,
  IHistoryVendor,
  IVolumeAnalysisVendor
{
  public static readonly string LOGIN_PARAMETER_USER = loc.key(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픔());
  public static readonly string LOGIN_PARAMETER_PASSWORD = loc.key(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓴());
  public const string LOGIN_PARAMETER_GROUP = "ConnectionGroup";
  public const string ADDITIONAL_PARAMETER_GROUP = "AdditionalParametersGroup";
  public const string REPORT_TYPE_PARAMETER_ACCOUNT = "Account";
  public const string REPORT_TYPE_PARAMETER_SYMBOL = "Symbol";
  public const string REPORT_TYPE_PARAMETER_DATETIME_FROM = "From";
  public const string REPORT_TYPE_PARAMETER_DATETIME_TO = "To";
  public static readonly string CONNECTION = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓓();
  public static readonly string CONNECTION_DEMO = loc.key(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗핈());
  public static readonly string CONNECTION_REAL = loc.key(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픤());
  public const string EMULATOR = "Emulator";
  public const string MARKET_REPLAY = "Market Replay";
  public const string TRADING_SIMULATOR = "Trading Simulator";
  private string 퓑퓦;

  [SpecialName]
  void IVendor.퓏([In] EventHandler<VendorEventArgs> obj0) => this.NewMessage += obj0;

  [SpecialName]
  void IVendor.퓬([In] EventHandler<VendorEventArgs> obj0) => this.NewMessage -= obj0;

  public event EventHandler<VendorEventArgs> NewMessage;

  /// <summary>Performs a binding with broker or data provider</summary>
  public virtual ConnectionResult Connect(ConnectRequestParameters connectRequestParameters)
  {
    return new ConnectionResult()
    {
      State = ConnectionState.Fail
    };
  }

  /// <summary>
  /// Specifies any operation before breaking a connection with broker or data provider
  /// </summary>
  public virtual void Disconnect()
  {
  }

  /// <summary>
  /// Called when platform finished retreiving all required informations from vendor during connecting
  /// </summary>
  public virtual void OnConnected(CancellationToken token)
  {
  }

  /// <summary>
  /// Ping processing before its visualization in the terminal
  /// </summary>
  public virtual PingResult Ping() => new PingResult();

  public virtual LimitationMetadata GetLimitationMetadata() => new LimitationMetadata();

  /// <summary>
  /// Retrieves an information about available accounts. Yon need to specify at least one account
  /// </summary>
  public virtual IList<MessageAccount> GetAccounts(CancellationToken token)
  {
    return (IList<MessageAccount>) new List<MessageAccount>();
  }

  public virtual IList<MessageRule> GetRules(CancellationToken token)
  {
    return (IList<MessageRule>) new List<MessageRule>();
  }

  public virtual IList<MessageCryptoAssetBalances> GetCryptoAssetBalances(CancellationToken token)
  {
    return (IList<MessageCryptoAssetBalances>) new List<MessageCryptoAssetBalances>();
  }

  public virtual IList<MessageAccountOperation> GetAccountOperations(CancellationToken token)
  {
    return (IList<MessageAccountOperation>) new List<MessageAccountOperation>();
  }

  public virtual IList<MessageSessionsContainer> GetSessions(CancellationToken token)
  {
    return (IList<MessageSessionsContainer>) new List<MessageSessionsContainer>();
  }

  /// <summary>
  /// Retrieves a collection of available exchange markets from vendor
  /// </summary>
  public virtual IList<MessageExchange> GetExchanges(CancellationToken token)
  {
    return (IList<MessageExchange>) new List<MessageExchange>()
    {
      new MessageExchange()
      {
        Id = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픿(),
        ExchangeName = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓕(),
        SortIndex = -1
      }
    };
  }

  /// <summary>Retrieves information about available assets.</summary>
  public virtual IList<MessageAsset> GetAssets(CancellationToken token)
  {
    return (IList<MessageAsset>) new List<MessageAsset>();
  }

  public virtual IList<MessageSymbol> GetSymbols(CancellationToken token)
  {
    return (IList<MessageSymbol>) new List<MessageSymbol>();
  }

  /// <summary>Retrieves information about available symbols.</summary>
  public virtual IList<MessageOptionSerie> GetAllOptionSeries(CancellationToken token)
  {
    return (IList<MessageOptionSerie>) new List<MessageOptionSerie>();
  }

  /// <summary>Gets an available symbols types from vendor</summary>
  public virtual MessageSymbolTypes GetSymbolTypes(CancellationToken token)
  {
    return new MessageSymbolTypes()
    {
      SymbolTypes = (IList<SymbolType>) new List<SymbolType>((IEnumerable<SymbolType>) Enum.GetValues(typeof (SymbolType)))
    };
  }

  public virtual IList<MessageSymbolGroup> GetSymbolGroups(CancellationToken token)
  {
    return (IList<MessageSymbolGroup>) new List<MessageSymbolGroup>();
  }

  /// <summary>Derives a non fixed symbol from vendor</summary>
  public virtual MessageSymbol GetNonFixedSymbol(GetSymbolRequestParameters requestParameters)
  {
    return (MessageSymbol) null;
  }

  /// <summary>Derives a non-fixed list of symbols from vendor</summary>
  public virtual IList<MessageSymbolInfo> SearchSymbols(
    SearchSymbolsRequestParameters requestParameters)
  {
    return (IList<MessageSymbolInfo>) new List<MessageSymbolInfo>();
  }

  public virtual IList<MessageSymbolInfo> GetFutureContracts(
    GetFutureContractsRequestParameters requestParameters)
  {
    return (IList<MessageSymbolInfo>) new List<MessageSymbolInfo>();
  }

  public virtual IList<MessageOptionSerie> GetOptionSeries(
    GetOptionSeriesRequestParameters requestParameters)
  {
    return (IList<MessageOptionSerie>) new List<MessageOptionSerie>();
  }

  public virtual IList<MessageSymbolInfo> GetStrikes(GetStrikesRequestParameters requestParameters)
  {
    return (IList<MessageSymbolInfo>) new List<MessageSymbolInfo>();
  }

  /// <summary>
  /// Retrieves an information about opened orders at the time of connection.
  /// </summary>
  public virtual IList<MessageOpenOrder> GetPendingOrders(CancellationToken token)
  {
    return (IList<MessageOpenOrder>) new List<MessageOpenOrder>();
  }

  /// <summary>
  /// Retrieves an information about positions at the time of connection
  /// </summary>
  public virtual IList<MessageOpenPosition> GetPositions(CancellationToken token)
  {
    return (IList<MessageOpenPosition>) new List<MessageOpenPosition>();
  }

  /// <summary>
  /// Retrieves an information about closed positions at the time of connection
  /// </summary>
  public virtual IList<MessageClosedPosition> GetClosedPositions(CancellationToken token)
  {
    return (IList<MessageClosedPosition>) new List<MessageClosedPosition>();
  }

  /// <summary>Subscribing to quote data: Level1/Level2/Trade</summary>
  public virtual void SubscribeSymbol(SubscribeQuotesParameters parameters)
  {
  }

  /// <summary>Unsubscribing from quote data: Level1/Level2/Trade</summary>
  public virtual void UnSubscribeSymbol(SubscribeQuotesParameters parameters)
  {
  }

  public virtual IList<IHistoryItem> LoadHistory(HistoryRequestParameters requestParameters)
  {
    return (IList<IHistoryItem>) new List<IHistoryItem>();
  }

  /// <summary>
  /// Gets a list of supported historical intervals and data types by vendor
  /// </summary>
  public virtual HistoryMetadata GetHistoryMetadata(CancellationToken cancellationToken)
  {
    return new HistoryMetadata();
  }

  public virtual VendorVolumeAnalysisByPeriodResponse LoadVolumeAnalysis(
    VolumeAnalysisByPeriodRequestParameters requestParameters)
  {
    return VendorVolumeAnalysisByPeriodResponse.CreateDefault();
  }

  public virtual VolumeAnalysisMetadata GetVolumeAnalysisMetadata() => new VolumeAnalysisMetadata();

  /// <summary>Prepare and sending order placing request to broker</summary>
  public virtual TradingOperationResult PlaceOrder(PlaceOrderRequestParameters parameters)
  {
    return TradingOperationResult.CreateError(parameters.RequestId, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픐());
  }

  public virtual TradingOperationResult PlaceMultiOrder(
    PlaceMultiOrderOrderRequestParameters parameters)
  {
    return TradingOperationResult.CreateError(parameters.RequestId, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픐());
  }

  /// <summary>Sending order modification request to broker</summary>
  public virtual TradingOperationResult ModifyOrder(ModifyOrderRequestParameters parameters)
  {
    return TradingOperationResult.CreateError(parameters.RequestId, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픐());
  }

  /// <summary>Sending order cancellation request to broker</summary>
  public virtual TradingOperationResult CancelOrder(CancelOrderRequestParameters parameters)
  {
    return TradingOperationResult.CreateError(parameters.RequestId, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픐());
  }

  /// <summary>Sending position closing request to broker</summary>
  public virtual TradingOperationResult ClosePosition(ClosePositionRequestParameters parameters)
  {
    return TradingOperationResult.CreateError(parameters.RequestId, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픐());
  }

  public virtual MarginInfo GetMarginInfo(OrderRequestParameters orderRequestParameters)
  {
    return (MarginInfo) null;
  }

  /// <summary>Gets information about available reports from vendor</summary>
  public virtual IList<MessageReportType> GetReportsMetaData(CancellationToken token)
  {
    return (IList<MessageReportType>) new List<MessageReportType>();
  }

  /// <summary>
  /// Called when platform need to generate particular report
  /// </summary>
  public virtual Report GenerateReport(ReportRequestParameters reportRequestParameters)
  {
    return new Report();
  }

  public virtual IEnumerable<SettingItem> GetNewsProviderSettings(
    CancellationToken cancellationToken)
  {
    return (IEnumerable<SettingItem>) Array.Empty<SettingItem>();
  }

  public virtual IEnumerable<MessageNewsHeadline> GetNews(GetNewsRequestParameters requestParameters)
  {
    return (IEnumerable<MessageNewsHeadline>) Array.Empty<MessageNewsHeadline>();
  }

  public virtual void SubscribeNewsUpdates(
    SubscribeNewsRequestParameters subscribeNewsRequestParameters)
  {
  }

  public virtual void UnsubscribeNewsUpdates(
    SubscribeNewsRequestParameters subscribeNewsRequestParameters)
  {
  }

  public virtual string GetNewsArticleContent(
    GetNewsArticleContentRequestParameters requestParameters)
  {
    return string.Empty;
  }

  public virtual IEnumerable<MessageTradingSignal> GetTradingSignals(
    CancellationToken cancellationToken)
  {
    return (IEnumerable<MessageTradingSignal>) Array.Empty<MessageTradingSignal>();
  }

  public virtual TradesHistoryMetadata GetTradesMetadata() => new TradesHistoryMetadata();

  public virtual IList<MessageTrade> GetTrades(TradesHistoryRequestParameters parameters)
  {
    return (IList<MessageTrade>) Array.Empty<MessageTrade>();
  }

  public virtual void GetTrades(
    TradesHistoryRequestParameters parameters,
    AccountTradesLoadingCallback callback)
  {
    if (callback == null)
      return;
    callback(this.GetTrades(parameters), true);
  }

  public virtual IList<MessageOrderHistory> GetOrdersHistory(
    OrdersHistoryRequestParameters parameters)
  {
    return (IList<MessageOrderHistory>) Array.Empty<MessageOrderHistory>();
  }

  /// <summary>Retrieves allowed/supported order types</summary>
  public virtual IList<OrderType> GetAllowedOrderTypes(CancellationToken token)
  {
    return (IList<OrderType>) new List<OrderType>();
  }

  /// <summary>Confirms allowed non fixed list by vendor</summary>
  public virtual bool AllowNonFixedList => false;

  public void PushMessage(Message msg)
  {
    // ISSUE: reference to a compiler-generated field
    EventHandler<VendorEventArgs> 퓑퓸 = this.퓑퓸;
    if (퓑퓸 == null)
      return;
    퓑퓸((object) this, new VendorEventArgs(this.퓑퓦, msg));
  }

  public virtual PnL CalculatePnL(PnLRequestParameters parameters) => (PnL) null;

  public virtual void SendCustomRequest(RequestParameters parameters)
  {
  }

  protected static ConnectionInfo CreateDefaultConnectionInfo(
    string name,
    string vendorName,
    string logoPath = null,
    string group = null,
    bool allowCreateCustomConnections = true,
    ConnectionState connectionState = ConnectionState.Disconnected,
    IList<SettingItem> settings = null,
    List<ConnectionInfoLink> links = null,
    string copyrights = null)
  {
    return new ConnectionInfo(name, group, vendorName)
    {
      ConnectionLogoPath = logoPath,
      AllowCreateCustomConnections = allowCreateCustomConnections,
      ConnectionState = connectionState,
      ConnectionSettings = settings,
      Links = links,
      Copyrights = copyrights
    };
  }

  [Conditional("quantower_licences")]
  [Conditional("quantower_in_licences")]
  [Conditional("quantower_br_licences")]
  [Conditional("capfinex_licences")]
  [Conditional("roemaker_licences")]
  [Conditional("coincidence_licences")]
  [Conditional("alpha_trader_licenses")]
  [Conditional("vt_terminal_licences")]
  [Conditional("quantower_de_licences")]
  [Conditional("flowtrade_licences")]
  [Conditional("spy_money_licences")]
  [Conditional("total_trading_terminal_licences")]
  protected void CheckLicenceMultiAssetVendor()
  {
    if ((Core.Instance.Licences.GetLicenceRuleItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓓()) ?? Core.Instance.Licences.GetLicenceRuleItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓮()) ?? Core.Instance.Licences.GetLicenceRuleItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓠())) == null && Core.Instance.Licences.GetLicenceRuleItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픕()) != null)
      throw new Exception(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픭());
  }

  public virtual DateTime? ServerTime => new DateTime?();

  string IVendor.Key
  {
    get => this.퓑퓦;
    [param: In] set => this.퓑퓦 = value;
  }

  public static bool TryCorrectPeriodForDirectDownload(
    Period[] allowedPeriods,
    Period currentPeriod,
    out Period allowedPeriod)
  {
    allowedPeriod = currentPeriod;
    if (allowedPeriods == null)
      allowedPeriods = Array.Empty<Period>();
    if (((IEnumerable<Period>) allowedPeriods).Contains<Period>(currentPeriod))
      return true;
    if (currentPeriod.BasePeriod == BasePeriod.Tick)
    {
      foreach (Period period in ((IEnumerable<Period>) allowedPeriods).Where<Period>((Func<Period, bool>) (([In] obj0) => obj0.BasePeriod == BasePeriod.Tick)).OrderByDescending<Period, int>((Func<Period, int>) (([In] obj0) => obj0.PeriodMultiplier)).ToArray<Period>())
      {
        if (currentPeriod.PeriodMultiplier % period.PeriodMultiplier == 0)
        {
          allowedPeriod = period;
          return true;
        }
      }
    }
    else
    {
      foreach (Period allowedPeriod1 in allowedPeriods)
      {
        if (currentPeriod.Ticks % allowedPeriod1.Ticks == 0L)
        {
          allowedPeriod = allowedPeriod1;
          return true;
        }
      }
    }
    return false;
  }
}
