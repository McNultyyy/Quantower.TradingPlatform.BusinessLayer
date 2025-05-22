// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Connection
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using IdentityModel.Client;
using IdentityModel.OidcClient;
using IdentityModel.OidcClient.Browser;
using IdentityModel.OidcClient.Results;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using TradingPlatform.BusinessLayer.Integration;
using TradingPlatform.BusinessLayer.Licence;
using TradingPlatform.BusinessLayer.Utils;
using TradingPlatform.BusinessLayer.Utils.Limitation;
using TradingPlatform.BusinessLayer.Utils.Storage;
using TradingPlatform.BusinessLayer.Utils.UserTradesLocalStorage;
using TradingPlatform.BusinessLayer.VolumeAnalysis.Storage;
using 퓏;

#nullable enable
namespace TradingPlatform.BusinessLayer;

/// <summary>
/// Represents information about connection and provides an access to the current trading information(Symbols, Orders, Position, Accounts etc.).
/// </summary>
[Published]
public sealed class Connection : ICustomizable, IComparable
{
  internal const 
  #nullable disable
  string 픂퓱 = "Test";
  internal 퓪 픂픹;
  private string 픂퓺;
  private DateTime 픂퓎;
  private UsersTradesStorage 픂픋;
  private Vendor 픂핀;
  private CancellationTokenSource 픂픲;
  private readonly ActionBufferedProcessor 픾퓲;

  /// <summary>
  /// Provides access to all business objects which are belong to this connection
  /// </summary>
  public IBusinessObjectsProvider BusinessObjects => (IBusinessObjectsProvider) this.픂픹;

  /// <summary>Gets connection Id</summary>
  public string Id
  {
    get => this.Info.ConnectionId;
    [param: In] private set => this.Info.ConnectionId = value;
  }

  /// <summary>Gets connection Name</summary>
  public string Name
  {
    get => this.Info.Name;
    set => this.Info.Name = value;
  }

  /// <summary>Gets connection's vendor name</summary>
  public string VendorName => this.Info.VendorName;

  /// <summary>
  /// Contains list of connection settings. Will be reused on each population time.
  /// </summary>
  public IList<SettingItem> Settings
  {
    get => this.Info.Settings;
    set => this.Info.Settings = value;
  }

  /// <summary>
  /// Gets connection's state (Connected/Connecting/Fail etc.)
  /// </summary>
  public ConnectionState State
  {
    get => this.Info.ConnectionState;
    [param: In] private set
    {
      if (this.Info.ConnectionState == value)
        return;
      ConnectionState connectionState = this.Info.ConnectionState;
      this.Info.ConnectionState = value;
      this.픂퓎 = value == ConnectionState.Connected ? Core.Instance.TimeUtils.DateTimeUtcNow : new DateTime();
      this.퓏(connectionState);
    }
  }

  public string ConnectingProgress
  {
    get => this.픂퓺;
    [param: In] private set
    {
      if (this.픂퓺 == value)
        return;
      this.픂퓺 = value;
      EventHandler<ConnectionConnectingProgressChangedEventArgs> 픂퓒 = this.픂퓒;
      if (픂퓒 == null)
        return;
      픂퓒((object) this, new ConnectionConnectingProgressChangedEventArgs(this.ConnectingProgress));
    }
  }

  /// <summary>Defines connection type</summary>
  public ConnectionType Type { get; set; }

  /// <summary>
  /// Will be triggered when <see cref="P:TradingPlatform.BusinessLayer.Connection.State" /> changed.
  /// </summary>
  public event EventHandler<ConnectionStateChangedEventArgs> StateChanged;

  /// <summary>
  /// Will be triggered when <see cref="P:TradingPlatform.BusinessLayer.Connection.ConnectingProgress" /> changed.
  /// </summary>
  public event EventHandler<ConnectionConnectingProgressChangedEventArgs> ConnectingProgressChanged;

  /// <summary>Represents connection ping time</summary>
  public TimeSpan? PingTime { get; [param: In] private set; }

  public TimeSpan? RoundTripTime { get; [param: In] private set; }

  /// <summary>Messages count that one is waited to process</summary>
  public int MessagesQueueDepth
  {
    get
    {
      퓪 픂픹 = this.픂픹;
      return 픂픹 == null ? 0 : 픂픹.QueueDepth;
    }
  }

  public TimeSpan Uptime
  {
    get
    {
      return !(this.픂퓎 == new DateTime()) ? Core.Instance.TimeUtils.DateTimeUtcNow - this.픂퓎 : TimeSpan.Zero;
    }
  }

  /// <summary>
  /// Gets a matched available metadata info with the vendor's side
  /// </summary>
  public HistoryMetadata HistoryMetaData => this.픂픹.HistoryMetadata?.Copy;

  public TradesHistoryMetadata TradesHistoryMetadata
  {
    get
    {
      return this.픂픹.UsersTradesCacheMetadata != null ? new TradesHistoryMetadata(this.픂픹.UsersTradesCacheMetadata) : (TradesHistoryMetadata) null;
    }
  }

  public VolumeAnalysisMetadata VolumeAnalysisMetadata => this.픂픹.VolumeAnalysisMetadata?.Copy;

  public IEnumerable<SettingItem> NewsFeedSettings
  {
    get
    {
      퓪 픂픹 = this.픂픹;
      if (픂픹 == null)
        return (IEnumerable<SettingItem>) null;
      IEnumerable<SettingItem> newsFeedSettings = 픂픹.NewsFeedSettings;
      return newsFeedSettings == null ? (IEnumerable<SettingItem>) null : newsFeedSettings.Select<SettingItem, SettingItem>((Func<SettingItem, SettingItem>) (([In] obj0) => obj0.GetCopy()));
    }
  }

  public ConnectionResult LastConnectionResult { get; [param: In] private set; }

  internal 퓏.퓔 HistoryLoadingManager { get; [param: In] private set; }

  internal VolumeAnalysisStorage VolumeAnalysisStorage { get; [param: In] private set; }

  internal bool Connected => this.State == ConnectionState.Connected;

  public ConnectionInfo Info { get; }

  public event EventHandler<RequestEventArgs> NewRequest;

  public event EventHandler<PerformedRequestEventArgs> NewPerformedRequest;

  public int TotalSubscriptionsCount
  {
    get
    {
      return ((IEnumerable<Symbol>) this.BusinessObjects.Symbols).Sum<Symbol>((Func<Symbol, int>) (([In] obj0) => obj0.TotalSubscriptionsCount));
    }
  }

  public DateTime ServerTime
  {
    get => (DateTime?) this.픂핀?.ServerTime ?? Core.Instance.TimeUtils.DateTimeUtcNow;
  }

  [NotPublished]
  public Limiter Limitation { get; [param: In] private set; }

  internal Connection([In] ConnectionInfo obj0)
  {
    this.Info = obj0;
    this.Type = ConnectionType.General;
    if (string.IsNullOrEmpty(obj0.ConnectionId))
      this.Id = Guid.NewGuid().ToString();
    this.State = ConnectionState.Disconnected;
    this.픾퓲 = new ActionBufferedProcessor();
  }

  /// <summary>Establishes a connection to a specified vendor</summary>
  /// <returns></returns>
  public ConnectionResult Connect()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Connection.퓍 퓍 = new Connection.퓍();
    // ISSUE: reference to a compiler-generated field
    퓍.퓠픅 = this;
    this.LastConnectionResult = new ConnectionResult();
    // ISSUE: reference to a compiler-generated method
    IProgress<string> progress = (IProgress<string>) new Progress<string>(new Action<string>(퓍.퓏));
    if (this.State == ConnectionState.Connected)
      return this.LastConnectionResult;
    if (this.State == ConnectionState.Connecting)
    {
      this.LastConnectionResult.State = ConnectionState.Connecting;
      this.LastConnectionResult.Message = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓱();
      return this.LastConnectionResult;
    }
    if (this.State == ConnectionState.Disconnecting)
    {
      this.LastConnectionResult.State = ConnectionState.Connecting;
      this.LastConnectionResult.Message = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픹();
      return this.LastConnectionResult;
    }
    this.픂픲 = new CancellationTokenSource();
    // ISSUE: reference to a compiler-generated field
    퓍.퓠픠 = this.픂픲.Token;
    this.픂픹 = this.Info.SyncMsgProcessing ? (퓪) new 퓧(this.Id) : new 퓪(this.Id);
    progress.Report((string) null);
    this.State = ConnectionState.Connecting;
    this.픂픹.퓏();
    VendorInfo vendor = Core.Instance.Vendors[this.VendorName];
    this.픂핀 = vendor.퓏();
    this.픂핀.NewMessage += new EventHandler<VendorEventArgs>(this.퓏);
    try
    {
      // ISSUE: reference to a compiler-generated field
      퓍.퓠픠.ThrowIfCancellationRequested();
      vendor.퓬();
      Core.Instance.Loggers.Log(this.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓺());
      // ISSUE: reference to a compiler-generated field
      this.퓏(퓍.퓠픠);
      Vendor 픂핀 = this.픂핀;
      ConnectRequestParameters connectRequestParameters = new ConnectRequestParameters();
      connectRequestParameters.ConnectionSettings = this.Settings;
      connectRequestParameters.BrowserFactory = Core.Instance.BrowserFactory;
      connectRequestParameters.ConnectionId = this.Id;
      // ISSUE: reference to a compiler-generated field
      connectRequestParameters.CancellationToken = 퓍.퓠픠;
      connectRequestParameters.ConnectingProgress = progress;
      this.LastConnectionResult = 픂핀.Connect(connectRequestParameters);
      if (this.LastConnectionResult.UpdatedSettings != null)
        this.Settings = this.LastConnectionResult.UpdatedSettings;
      // ISSUE: reference to a compiler-generated field
      퓍.퓠픠.ThrowIfCancellationRequested();
      if (this.LastConnectionResult.State == ConnectionState.Fail)
      {
        this.State = ConnectionState.Disconnecting;
        this.퓏();
        this.State = ConnectionState.Disconnected;
        Core.Instance.Loggers.Log(this.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픊() + this.LastConnectionResult.Message);
        return this.LastConnectionResult;
      }
      // ISSUE: reference to a compiler-generated field
      퓍.퓠픠.ThrowIfCancellationRequested();
      progress.Report(loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픈(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓒()));
      // ISSUE: reference to a compiler-generated field
      IList<MessageSessionsContainer> sessions = this.픂핀.GetSessions(퓍.퓠픠);
      if (sessions != null)
      {
        foreach (Message message in (IEnumerable<MessageSessionsContainer>) sessions)
          this.퓏(message);
      }
      // ISSUE: reference to a compiler-generated field
      퓍.퓠픠.ThrowIfCancellationRequested();
      progress.Report(loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓚(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓒()));
      // ISSUE: reference to a compiler-generated field
      IList<MessageExchange> exchanges = this.픂핀.GetExchanges(퓍.퓠픠);
      if (exchanges != null)
      {
        foreach (Message message in (IEnumerable<MessageExchange>) exchanges)
          this.퓏(message);
      }
      // ISSUE: reference to a compiler-generated field
      퓍.퓠픠.ThrowIfCancellationRequested();
      progress.Report(loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픃(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓒()));
      // ISSUE: reference to a compiler-generated field
      IList<MessageSymbolGroup> symbolGroups = this.픂핀.GetSymbolGroups(퓍.퓠픠);
      if (symbolGroups != null)
      {
        foreach (Message message in (IEnumerable<MessageSymbolGroup>) symbolGroups)
          this.퓏(message);
      }
      // ISSUE: reference to a compiler-generated field
      퓍.퓠픠.ThrowIfCancellationRequested();
      // ISSUE: reference to a compiler-generated field
      this.픂픹.HistoryMetadata = this.픂핀.GetHistoryMetadata(퓍.퓠픠);
      this.픂픹.HistoryMetadata.AllowedPeriodsHistoryAggregationTime = ((IEnumerable<Period>) this.픂픹.HistoryMetadata.AllowedPeriodsHistoryAggregationTime).OrderByDescending<Period, long>((Func<Period, long>) (([In] obj0) => obj0.Ticks)).ToArray<Period>();
      this.픂픹.VolumeAnalysisMetadata = this.픂핀.GetVolumeAnalysisMetadata();
      // ISSUE: reference to a compiler-generated field
      this.픂픹.NewsFeedSettings = this.픂핀.GetNewsProviderSettings(퓍.퓠픠);
      this.픂픹.UsersTradesCacheMetadata = this.픂핀.GetTradesMetadata();
      this.픂픹.LimitationMetadata = this.픂핀.GetLimitationMetadata();
      if (this.픂픹.LimitationMetadata?.Limits != null)
        this.Limitation = new Limiter(this.픂픹.LimitationMetadata);
      // ISSUE: reference to a compiler-generated field
      퓍.퓠픠.ThrowIfCancellationRequested();
      progress.Report(loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓎(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓒()));
      // ISSUE: reference to a compiler-generated field
      foreach (OrderType allowedOrderType in (IEnumerable<OrderType>) this.픂핀.GetAllowedOrderTypes(퓍.퓠픠))
      {
        allowedOrderType.ConnectionId = this.Id;
        this.픂픹.OrderTypesCache.퓏(allowedOrderType.Id, allowedOrderType);
      }
      // ISSUE: reference to a compiler-generated field
      퓍.퓠픠.ThrowIfCancellationRequested();
      progress.Report(loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍피(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓒()));
      // ISSUE: reference to a compiler-generated field
      foreach (Message asset in (IEnumerable<MessageAsset>) this.픂핀.GetAssets(퓍.퓠픠))
        this.퓏(asset);
      progress.Report(loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픃(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓒()));
      // ISSUE: reference to a compiler-generated field
      this.퓏((Message) this.픂핀.GetSymbolTypes(퓍.퓠픠));
      // ISSUE: reference to a compiler-generated field
      퓍.퓠픠.ThrowIfCancellationRequested();
      progress.Report(loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓸(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓒()));
      // ISSUE: reference to a compiler-generated field
      foreach (Message account in (IEnumerable<MessageAccount>) this.픂핀.GetAccounts(퓍.퓠픠))
        this.퓏(account);
      // ISSUE: reference to a compiler-generated field
      퓍.퓠픠.ThrowIfCancellationRequested();
      // ISSUE: reference to a compiler-generated field
      foreach (Message cryptoAssetBalance in (IEnumerable<MessageCryptoAssetBalances>) this.픂핀.GetCryptoAssetBalances(퓍.퓠픠))
        this.퓏(cryptoAssetBalance);
      // ISSUE: reference to a compiler-generated field
      퓍.퓠픠.ThrowIfCancellationRequested();
      progress.Report(loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓦(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓒()));
      // ISSUE: reference to a compiler-generated field
      foreach (Message message in (IEnumerable<MessageOptionSerie>) this.픂핀.GetAllOptionSeries(퓍.퓠픠))
        this.퓏(message);
      // ISSUE: reference to a compiler-generated field
      퓍.퓠픠.ThrowIfCancellationRequested();
      progress.Report(loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픋(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓒()));
      // ISSUE: reference to a compiler-generated field
      foreach (Message symbol in (IEnumerable<MessageSymbol>) this.픂핀.GetSymbols(퓍.퓠픠))
        this.퓏(symbol);
      // ISSUE: reference to a compiler-generated field
      퓍.퓠픠.ThrowIfCancellationRequested();
      progress.Report(loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍핀(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓒()));
      // ISSUE: reference to a compiler-generated field
      foreach (Message rule in (IEnumerable<MessageRule>) this.픂핀.GetRules(퓍.퓠픠))
        this.퓏(rule);
      // ISSUE: reference to a compiler-generated field
      퓍.퓠픠.ThrowIfCancellationRequested();
      progress.Report(loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픲(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓒()));
      // ISSUE: reference to a compiler-generated field
      foreach (Message position in (IEnumerable<MessageOpenPosition>) this.픂핀.GetPositions(퓍.퓠픠))
        this.퓏(position);
      // ISSUE: reference to a compiler-generated field
      퓍.퓠픠.ThrowIfCancellationRequested();
      progress.Report(loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픽(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓒()));
      // ISSUE: reference to a compiler-generated field
      foreach (Message closedPosition in (IEnumerable<MessageClosedPosition>) this.픂핀.GetClosedPositions(퓍.퓠픠))
        this.퓏(closedPosition);
      // ISSUE: reference to a compiler-generated field
      퓍.퓠픠.ThrowIfCancellationRequested();
      progress.Report(loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓏(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓒()));
      // ISSUE: reference to a compiler-generated field
      foreach (Message message in (IEnumerable<MessageReportType>) this.픂핀.GetReportsMetaData(퓍.퓠픠))
        this.퓏(message);
      // ISSUE: reference to a compiler-generated field
      퓍.퓠픠.ThrowIfCancellationRequested();
      progress.Report(loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓬(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓒()));
      // ISSUE: reference to a compiler-generated field
      foreach (Message pendingOrder in (IEnumerable<MessageOpenOrder>) this.픂핀.GetPendingOrders(퓍.퓠픠))
        this.퓏(pendingOrder);
      // ISSUE: reference to a compiler-generated field
      퓍.퓠픠.ThrowIfCancellationRequested();
      progress.Report(loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁핇(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓒()));
      // ISSUE: reference to a compiler-generated field
      foreach (Message accountOperation in (IEnumerable<MessageAccountOperation>) this.픂핀.GetAccountOperations(퓍.퓠픠))
        this.퓏(accountOperation);
      // ISSUE: reference to a compiler-generated field
      퓍.퓠픠.ThrowIfCancellationRequested();
      progress.Report(loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓲(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓒()));
      // ISSUE: reference to a compiler-generated field
      foreach (Message tradingSignal in this.픂핀.GetTradingSignals(퓍.퓠픠))
        this.퓏(tradingSignal);
      // ISSUE: reference to a compiler-generated field
      퓍.퓠픠.ThrowIfCancellationRequested();
      progress.Report(loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁핂(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓒()));
      // ISSUE: reference to a compiler-generated field
      this.픂픹.WaitAllMessagesProcess(new CancellationToken?(퓍.퓠픠));
      progress.Report((string) null);
      // ISSUE: reference to a compiler-generated field
      퓍.퓠픠.ThrowIfCancellationRequested();
      // ISSUE: reference to a compiler-generated field
      this.픂핀.OnConnected(퓍.퓠픠);
      // ISSUE: reference to a compiler-generated field
      퓍.퓠픠.ThrowIfCancellationRequested();
      퓏.퓝 퓝 = new 퓏.퓝()
      {
        AllowLocalStorage = this.픂픹.HistoryMetadata.UseHistoryLocalCache,
        DegreeOfParallelism = this.픂픹.HistoryMetadata.DegreeOfParallelism,
        LoadHistoryDelegate = new 퓏.픢(this.퓏)
      };
      if (퓝.AllowLocalStorage)
        퓝.LocalStorageConnectionString = Path.Combine(Const.HISTORY_PATH, (this.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓓() + this.Id + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픗()).EncodeFilePathPart(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픂());
      this.HistoryLoadingManager = 퓏.퓔.퓏(퓝);
      if (퓝.AllowLocalStorage)
        this.VolumeAnalysisStorage = VolumeAnalysisStorage.Create(Path.Combine(Const.VOLUME_ANALYSIS_PATH, (this.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓓() + this.Id + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픗()).EncodeFilePathPart(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픾()));
      if (this.픂픹.UsersTradesCacheMetadata.AllowLocalStorage)
      {
        this.픂픋 = UsersTradesStorage.Create(Path.Combine(Const.USER_TRADES_CACHE_PATH, (this.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓓() + this.Id + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픗()).EncodeFilePathPart(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓍()), this.Id);
        if (this.픂픹.UsersTradesCacheMetadata.LoadTradesFromCurrentTradingDate)
        {
          // ISSUE: object of a compiler-generated type is created
          // ISSUE: variable of a compiler-generated type
          Connection.픁 픁 = new Connection.픁();
          // ISSUE: reference to a compiler-generated field
          픁.퓠픕 = 퓍;
          // ISSUE: reference to a compiler-generated field
          픁.퓠퓮 = Core.Instance.TimeUtils.DateTimeUtcNow;
          // ISSUE: reference to a compiler-generated method
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          Task.Factory.StartNew(new Action(픁.퓏), 픁.퓠픕.퓠픠);
        }
      }
      this.픂픹.픾픸 = true;
      this.픾퓲?.Start();
      this.State = ConnectionState.Connected;
    }
    catch (OperationCanceledException ex)
    {
      this.LastConnectionResult.State = ConnectionState.Fail;
      this.LastConnectionResult.Message = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픁();
      this.LastConnectionResult.Cancelled = true;
      this.State = ConnectionState.Disconnecting;
      this.퓏();
      this.State = ConnectionState.Disconnected;
    }
    catch (Exception ex)
    {
      this.LastConnectionResult.State = ConnectionState.Fail;
      this.LastConnectionResult.Message = ex.GetFullMessageRecursive();
      this.State = ConnectionState.Fail;
      Core.Instance.Loggers.Log(this.LastConnectionResult.Message, LoggingLevel.Verbose);
      this.퓏();
      this.State = ConnectionState.Disconnected;
    }
    finally
    {
      vendor.핇();
    }
    ConnectionResult connectionResult = this.LastConnectionResult;
    if ((connectionResult != null ? (connectionResult.State == ConnectionState.Connected ? 1 : 0) : 0) != 0)
    {
      Core.Instance.Loggers.Log(this.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픞());
      this.핇(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁핁());
    }
    else
      Core.Instance.Loggers.Log(this.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픊() + this.LastConnectionResult?.Message);
    if (this.Type == ConnectionType.General && this.State == ConnectionState.Connected)
    {
      if (Core.Instance.RulesManager.IsAllowed(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓠(), this.Id).Status != TradingOperationStatus.Allowed)
      {
        try
        {
          if ((Core.Instance.Licences.GetLicenceRuleItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓓()) ?? Core.Instance.Licences.GetLicenceRuleItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픕()) ?? Core.Instance.Licences.GetLicenceRuleItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓮()) ?? Core.Instance.Licences.GetLicenceRuleItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓽()) ?? Core.Instance.Licences.GetLicenceRuleItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓠())) == null)
          {
            // ISSUE: reference to a compiler-generated method
            Connection[] array = ((IEnumerable<Connection>) Core.Instance.Connections.All).Where<Connection>(new Func<Connection, bool>(퓍.퓏)).Where<Connection>((Func<Connection, bool>) (([In] obj0) => obj0.State == ConnectionState.Connected || obj0.State == ConnectionState.Connecting)).Where<Connection>((Func<Connection, bool>) (([In] obj0) => obj0.Type == ConnectionType.General)).Where<Connection>((Func<Connection, bool>) (([In] obj0) => Core.Instance.RulesManager.IsAllowed(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓠(), obj0.Id).Status != 0)).ToArray<Connection>();
            if (((IEnumerable<Connection>) array).Any<Connection>())
            {
              foreach (Connection connection in array)
              {
                if (connection.LastConnectionResult != null)
                {
                  connection.LastConnectionResult.State = ConnectionState.Fail;
                  connection.LastConnectionResult.Message = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픇();
                }
                connection.Disconnect();
              }
              this.퓏((Message) new MessageDealTicket(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픣(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓙()));
            }
          }
        }
        catch (Exception ex)
        {
          Core.Instance.Loggers.Log(ex);
        }
      }
    }
    return this.LastConnectionResult;
  }

  private void 퓏([In] CancellationToken obj0_1)
  {
    IList<SettingItem> settings = this.Settings;
    if (!(settings.GetItemByPath(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓗()) is SettingItemGroup itemByPath) || !(itemByPath.Value is IList<SettingItem> source) || !(source.FirstOrDefault<SettingItem>((Func<SettingItem, bool>) (([In] obj0_2) => obj0_2 is SettingItemOAuth)) is SettingItemOAuth settingItemOauth))
      return;
    OidcClientOptions copy = settingItemOauth.OidcOptions.GetCopy();
    if (copy == null)
      throw new Exception(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픎());
    if (settingItemOauth.UpdateIdentityAuthorityUrl != null)
      copy.Authority = settingItemOauth.UpdateIdentityAuthorityUrl((IEnumerable<SettingItem>) settings, obj0_1);
    if (string.IsNullOrEmpty(copy.Authority) && copy.ProviderInformation == null)
      return;
    int num = 55650;
    try
    {
      num = TcpIpHelper.GetRandomUnusedPort;
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓠());
    }
    copy.Browser = (IdentityModel.OidcClient.Browser.IBrowser) new 퓏.퓻(settingItemOauth.AllowOpenNewWindow, new int?(num))
    {
      퓲픶 = Core.Instance.OAuthBrowserCreator
    };
    if (string.IsNullOrEmpty(copy.RedirectUri))
    {
      OidcClientOptions oidcClientOptions1 = copy;
      OidcClientOptions oidcClientOptions2 = copy;
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 1);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓥());
      interpolatedStringHandler.AppendFormatted<int>(num);
      string stringAndClear;
      string str1 = stringAndClear = interpolatedStringHandler.ToStringAndClear();
      oidcClientOptions2.RedirectUri = stringAndClear;
      string str2 = str1;
      oidcClientOptions1.PostLogoutRedirectUri = str2;
    }
    IdentityModel.OidcClient.OidcClient oidcClient = new IdentityModel.OidcClient.OidcClient(copy);
    LoginRequest request1 = new LoginRequest()
    {
      BrowserDisplayMode = DisplayMode.Visible,
      BrowserTimeout = 300,
      BackChannelExtraParameters = settingItemOauth.BackChannelExtraParameters
    };
    OAuthResult oauthResult = settingItemOauth.Value as OAuthResult;
    Result result1;
    if (oauthResult != null && !string.IsNullOrEmpty(oauthResult.RefreshToken) && oauthResult.UseSavedTokens)
    {
      RefreshTokenResult refreshTokenResult = (RefreshTokenResult) null;
      if (this.VendorName.Contains(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓯()))
      {
        UriBuilder uriBuilder = new UriBuilder(copy.ProviderInformation.TokenEndpoint);
        NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
        queryString.Add(new NameValueCollection()
        {
          {
            \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픜(),
            copy.ClientId
          },
          {
            \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓑(),
            copy.ClientSecret
          },
          {
            \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁핋(),
            oauthResult.RefreshToken
          },
          {
            \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓞(),
            \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁핋()
          }
        });
        uriBuilder.Query = queryString.ToString();
        using (HttpClient httpClient = new HttpClient())
        {
          TokenResponse result2 = ProtocolResponse.FromHttpResponseAsync<TokenResponse>(httpClient.Send(new HttpRequestMessage(HttpMethod.Get, uriBuilder.Uri), obj0_1)).Result;
          if (result2 != null)
          {
            if (!result2.IsError)
            {
              refreshTokenResult = new RefreshTokenResult();
              try
              {
                System.Type type = typeof (RefreshTokenResult);
                type.GetProperty(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁핅())?.SetValue((object) refreshTokenResult, (object) result2.AccessToken);
                type.GetProperty(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픡())?.SetValue((object) refreshTokenResult, (object) result2.RefreshToken);
                type.GetProperty(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픏())?.SetValue((object) refreshTokenResult, (object) result2.ExpiresIn);
              }
              catch (Exception ex)
              {
                Core.Instance.Loggers.Log(ex, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓳());
              }
            }
          }
        }
      }
      else
        refreshTokenResult = oidcClient.RefreshTokenAsync(oauthResult.RefreshToken, cancellationToken: obj0_1).Result;
      result1 = (Result) refreshTokenResult;
      oauthResult.RequestRefreshResult = refreshTokenResult;
    }
    else if (this.VendorName.Contains(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓯()))
    {
      result1 = (Result) new LoginResult();
      RequestUrl request2 = new RequestUrl(copy.ProviderInformation.AuthorizeEndpoint);
      string clientId = copy.ClientId;
      string responseType = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁핆();
      string redirectUri1 = copy.RedirectUri;
      string scope = copy.Scope;
      string redirectUri2 = redirectUri1;
      int? maxAge = new int?();
      BrowserOptions options1 = new BrowserOptions(request2.CreateAuthorizeUrl(clientId, responseType, scope, redirectUri2, maxAge: maxAge), copy.RedirectUri)
      {
        Timeout = TimeSpan.FromSeconds((double) request1.BrowserTimeout),
        DisplayMode = request1.BrowserDisplayMode
      };
      BrowserResult result3 = copy.Browser.InvokeAsync(options1, obj0_1).Result;
      NameValueCollection nameValueCollection = !result3.IsError ? HttpUtility.ParseQueryString(result3.Response) : throw new Exception(result3.Error);
      if (!((IEnumerable<string>) nameValueCollection.AllKeys).Contains<string>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁핆()))
        throw new Exception(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픷());
      using (HttpClient httpClient = new HttpClient())
      {
        HttpClient client = httpClient;
        TokenClientOptions options2 = new TokenClientOptions();
        options2.Address = copy.ProviderInformation.TokenEndpoint;
        options2.ClientId = copy.ClientId;
        options2.ClientSecret = copy.ClientSecret;
        TokenClient tokenClient = new TokenClient((HttpMessageInvoker) client, options2);
        string str = nameValueCollection[\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁핆()];
        UriBuilder uriBuilder = new UriBuilder(copy.ProviderInformation.TokenEndpoint);
        NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
        queryString.Add(new NameValueCollection()
        {
          {
            \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픜(),
            copy.ClientId
          },
          {
            \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓑(),
            copy.ClientSecret
          },
          {
            \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓻(),
            copy.RedirectUri
          },
          {
            \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓞(),
            \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픸()
          },
          {
            \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁핆(),
            str
          }
        });
        uriBuilder.Query = queryString.ToString();
        TokenResponse result4 = ProtocolResponse.FromHttpResponseAsync<TokenResponse>(httpClient.Send(new HttpRequestMessage(HttpMethod.Get, uriBuilder.Uri), obj0_1)).Result;
        if (result4.IsError)
          result1.Error = result4.Error;
        oauthResult.TokenResponce = result4;
      }
    }
    else
    {
      if (oauthResult != null && !string.IsNullOrEmpty(oauthResult.IdentityToken))
      {
        LogoutRequest request3 = new LogoutRequest()
        {
          IdTokenHint = oauthResult.IdentityToken
        };
        oidcClient.LogoutAsync(request3, obj0_1).Wait(obj0_1);
        Task.Delay(700, obj0_1).Wait(obj0_1);
      }
      LoginResult result5 = oidcClient.LoginAsync(request1, obj0_1).Result;
      result1 = (Result) result5;
      oauthResult.RequestTokenResult = result5;
    }
    this.Settings = (IList<SettingItem>) new List<SettingItem>()
    {
      (SettingItem) new SettingItemGroup(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓗(), (IList<SettingItem>) new List<SettingItem>()
      {
        (SettingItem) settingItemOauth
      })
    };
    if (!result1.IsError)
      return;
    if (result1.Error == BrowserResultType.UserCancel.ToString())
      throw new OperationCanceledException();
    throw new Exception(result1.Error);
  }

  /// <summary>Closes a connection.</summary>
  public void Disconnect()
  {
    if (this.State == ConnectionState.Connecting)
    {
      this.픂픲.Cancel();
    }
    else
    {
      if (this.State != ConnectionState.Connected)
        return;
      this.핇(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁프());
      this.State = ConnectionState.Disconnecting;
      Core.Instance.Loggers.Log(this.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픴());
      this.퓏();
      this.State = ConnectionState.Disconnected;
      Core.Instance.Loggers.Log(this.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픑());
    }
  }

  private void 퓏()
  {
    this.픂픹?.Stop();
    if (this.픂핀 != null)
    {
      try
      {
        this.픂핀.Disconnect();
      }
      catch (Exception ex)
      {
        Core.Instance.Loggers.Log(ex, loggingLevel: LoggingLevel.Verbose);
      }
      this.픂핀.NewMessage -= new EventHandler<VendorEventArgs>(this.퓏);
      this.픂핀 = (Vendor) null;
    }
    this.픾퓲?.Stop();
    if (this.HistoryLoadingManager != null)
    {
      this.HistoryLoadingManager.Dispose();
      this.HistoryLoadingManager = (퓏.퓔) null;
    }
    if (this.VolumeAnalysisStorage != null)
    {
      this.VolumeAnalysisStorage.Dispose();
      this.VolumeAnalysisStorage = (VolumeAnalysisStorage) null;
    }
    if (this.픂픋 != null)
    {
      this.픂픋.Dispose();
      this.픂픋 = (UsersTradesStorage) null;
    }
    if (this.Limitation == null)
      return;
    this.Limitation.Dispose();
    this.Limitation = (Limiter) null;
  }

  internal void 퓬()
  {
    if (this.픂핀 == null)
      return;
    if (this.State != ConnectionState.Connected)
      return;
    PingResult pingResult;
    try
    {
      pingResult = this.픂핀.Ping();
      if (this.State != ConnectionState.Connected)
        return;
    }
    catch (Exception ex)
    {
      pingResult = new PingResult()
      {
        State = PingEnum.Disconnected
      };
      Core.Instance.Loggers.Log(ex, loggingLevel: LoggingLevel.Verbose);
    }
    if (pingResult != null && pingResult.State == PingEnum.Connected)
    {
      this.PingTime = pingResult.PingTime;
      this.RoundTripTime = pingResult.RoundTripTime;
    }
    else
    {
      this.퓏();
      this.State = pingResult.StopReconnecting ? ConnectionState.Disconnected : ConnectionState.ConnectionLost;
      Core.Instance.Loggers.Log(this.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픿() + (pingResult.StopReconnecting ? \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓔() : string.Empty));
    }
  }

  public void SendCustomRequest(RequestParameters parameters)
  {
    try
    {
      if (!this.Connected)
      {
        Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픢(), LoggingLevel.Verbose);
      }
      else
      {
        using (CancellationTokenSource linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(parameters.CancellationToken, this.픂픲.Token))
        {
          parameters.CancellationToken = linkedTokenSource.Token;
          this.퓏(parameters);
          this.픂핀.SendCustomRequest(parameters);
        }
      }
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex, loggingLevel: LoggingLevel.Verbose);
    }
    finally
    {
      this.퓏(parameters, (object) null);
    }
  }

  internal void 퓏([In] Symbol obj0, [In] SubscribeQuoteType obj1)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Connection.픞 픞 = new Connection.픞();
    // ISSUE: reference to a compiler-generated field
    픞.퓠픱 = this;
    if (this.픂핀 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    픞.퓠픶 = new SubscribeQuotesParameters(obj0.Id, obj1);
    // ISSUE: reference to a compiler-generated method
    this.픾퓲.Push(new Action(픞.퓏));
  }

  internal void 퓬([In] Symbol obj0, [In] SubscribeQuoteType obj1)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Connection.핁 핁 = new Connection.핁();
    // ISSUE: reference to a compiler-generated field
    핁.퓠픀 = this;
    if (this.픂핀 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    핁.퓠픖 = new SubscribeQuotesParameters(obj0.Id, obj1);
    // ISSUE: reference to a compiler-generated method
    this.픾퓲.Push(new Action(핁.퓏));
  }

  internal TradingOperationResult 퓏([In] PlaceOrderRequestParameters obj0)
  {
    TradingOperationResult tradingOperationResult = (TradingOperationResult) null;
    using (CancellationTokenSource linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(obj0.CancellationToken, this.픂픲.Token))
    {
      PlaceOrderRequestParameters requestParameters = new PlaceOrderRequestParameters((OrderRequestParameters) obj0);
      requestParameters.CancellationToken = linkedTokenSource.Token;
      PlaceOrderRequestParameters parameters = requestParameters;
      try
      {
        if (!this.Connected)
        {
          long requestId = parameters.RequestId;
          DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 1);
          interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓝());
          interpolatedStringHandler.AppendFormatted<ConnectionState>(this.State);
          string stringAndClear = interpolatedStringHandler.ToStringAndClear();
          tradingOperationResult = TradingOperationResult.CreateError(requestId, stringAndClear);
          return tradingOperationResult;
        }
        AllowedResult allowedResult = TradingOperations.IsAllowed(TradingOperation.PlaceOrder, new TradingOperationParameters()
        {
          Account = parameters.Account,
          Symbol = parameters.Symbol
        });
        if (allowedResult.Status == TradingOperationStatus.NotAllowed)
        {
          tradingOperationResult = TradingOperationResult.CreateError(parameters.RequestId, allowedResult.Reason);
          return tradingOperationResult;
        }
        if (parameters.OrderType == null)
        {
          tradingOperationResult = TradingOperationResult.CreateError(parameters.RequestId, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓶());
          return tradingOperationResult;
        }
        if (parameters.TimeInForce == TimeInForce.Default)
          parameters.TimeInForce = ((IEnumerable<TimeInForce>) parameters.OrderType.AllowedTifs).FirstOrDefault<TimeInForce>();
        this.퓏((RequestParameters) parameters);
        Core.Instance.Loggers.Log((ILoggable) parameters, LoggingLevel.Trading, this.Name);
        tradingOperationResult = this.픂핀.PlaceOrder(parameters);
      }
      catch (Exception ex)
      {
        tradingOperationResult = TradingOperationResult.CreateError(parameters.RequestId, ex.Message);
      }
      finally
      {
        Core.Instance.Loggers.Log((ILoggable) tradingOperationResult, LoggingLevel.Trading, this.Name);
        this.퓏((RequestParameters) parameters, (object) tradingOperationResult);
      }
      return tradingOperationResult;
    }
  }

  internal TradingOperationResult 퓏([In] PlaceMultiOrderOrderRequestParameters obj0_1)
  {
    TradingOperationResult tradingOperationResult = (TradingOperationResult) null;
    using (CancellationTokenSource linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(obj0_1.CancellationToken, this.픂픲.Token))
    {
      PlaceMultiOrderOrderRequestParameters requestParameters = new PlaceMultiOrderOrderRequestParameters(obj0_1);
      requestParameters.CancellationToken = linkedTokenSource.Token;
      PlaceMultiOrderOrderRequestParameters parameters = requestParameters;
      try
      {
        if (!this.Connected)
        {
          long requestId = parameters.RequestId;
          DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 1);
          interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓝());
          interpolatedStringHandler.AppendFormatted<ConnectionState>(this.State);
          string stringAndClear = interpolatedStringHandler.ToStringAndClear();
          tradingOperationResult = TradingOperationResult.CreateError(requestId, stringAndClear);
          return tradingOperationResult;
        }
        if (parameters.OrderParameters == null || !((IEnumerable<PlaceOrderRequestParameters>) parameters.OrderParameters).Any<PlaceOrderRequestParameters>())
        {
          tradingOperationResult = TradingOperationResult.CreateError(parameters.RequestId, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓽());
          return tradingOperationResult;
        }
        if (((IEnumerable<PlaceOrderRequestParameters>) parameters.OrderParameters).Select<PlaceOrderRequestParameters, string>((Func<PlaceOrderRequestParameters, string>) (([In] obj0_2) => obj0_2.Symbol.ConnectionId)).Distinct<string>().Count<string>() > 1)
        {
          tradingOperationResult = TradingOperationResult.CreateError(parameters.RequestId, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픘());
          return tradingOperationResult;
        }
        if (parameters.GroupOrderType == GroupOrderType.OCO && Core.Instance.RulesManager.IsAllowed(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픨(), this.Id).Status != TradingOperationStatus.Allowed)
        {
          tradingOperationResult = TradingOperationResult.CreateError(parameters.RequestId, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓪());
          return tradingOperationResult;
        }
        foreach (PlaceOrderRequestParameters orderParameter in parameters.OrderParameters)
        {
          AllowedResult allowedResult = TradingOperations.IsAllowed(TradingOperation.PlaceOrder, new TradingOperationParameters()
          {
            Account = orderParameter.Account,
            Symbol = orderParameter.Symbol
          });
          if (allowedResult.Status == TradingOperationStatus.NotAllowed)
          {
            tradingOperationResult = TradingOperationResult.CreateError(parameters.RequestId, allowedResult.Reason);
            return tradingOperationResult;
          }
        }
        this.퓏((RequestParameters) parameters);
        Core.Instance.Loggers.Log((ILoggable) parameters, LoggingLevel.Trading, this.Name);
        tradingOperationResult = this.픂핀.PlaceMultiOrder(parameters);
      }
      catch (Exception ex)
      {
        tradingOperationResult = TradingOperationResult.CreateError(parameters.RequestId, ex.Message);
      }
      finally
      {
        Core.Instance.Loggers.Log((ILoggable) tradingOperationResult, LoggingLevel.Trading, this.Name);
        this.퓏((RequestParameters) parameters, (object) tradingOperationResult);
      }
      return tradingOperationResult;
    }
  }

  internal TradingOperationResult 퓏([In] ModifyOrderRequestParameters obj0)
  {
    TradingOperationResult tradingOperationResult = (TradingOperationResult) null;
    using (CancellationTokenSource linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(obj0.CancellationToken, this.픂픲.Token))
    {
      ModifyOrderRequestParameters requestParameters = new ModifyOrderRequestParameters(obj0);
      requestParameters.CancellationToken = linkedTokenSource.Token;
      ModifyOrderRequestParameters parameters = requestParameters;
      try
      {
        if (!this.Connected)
        {
          long requestId = parameters.RequestId;
          DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 1);
          interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓝());
          interpolatedStringHandler.AppendFormatted<ConnectionState>(this.State);
          string stringAndClear = interpolatedStringHandler.ToStringAndClear();
          tradingOperationResult = TradingOperationResult.CreateError(requestId, stringAndClear);
          return tradingOperationResult;
        }
        AllowedResult allowedResult = TradingOperations.IsAllowed(TradingOperation.ModifyOrder, new TradingOperationParameters()
        {
          Account = parameters.Account,
          Symbol = parameters.Symbol
        });
        if (allowedResult.Status == TradingOperationStatus.NotAllowed)
        {
          tradingOperationResult = TradingOperationResult.CreateError(parameters.RequestId, allowedResult.Reason);
          return tradingOperationResult;
        }
        if (parameters.TimeInForce == TimeInForce.Default)
          parameters.TimeInForce = ((IEnumerable<TimeInForce>) parameters.OrderType.AllowedTifs).FirstOrDefault<TimeInForce>();
        this.퓏((RequestParameters) parameters);
        Core.Instance.Loggers.Log((ILoggable) parameters, LoggingLevel.Trading, this.Name);
        tradingOperationResult = this.픂핀.ModifyOrder(parameters);
      }
      catch (Exception ex)
      {
        tradingOperationResult = TradingOperationResult.CreateError(parameters.RequestId, ex.Message);
      }
      finally
      {
        Core.Instance.Loggers.Log((ILoggable) tradingOperationResult, LoggingLevel.Trading, this.Name);
        this.퓏((RequestParameters) parameters, (object) tradingOperationResult);
      }
      return tradingOperationResult;
    }
  }

  internal TradingOperationResult 퓏([In] ClosePositionRequestParameters obj0)
  {
    TradingOperationResult tradingOperationResult = (TradingOperationResult) null;
    using (CancellationTokenSource linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(obj0.CancellationToken, this.픂픲.Token))
    {
      ClosePositionRequestParameters requestParameters = new ClosePositionRequestParameters(obj0);
      requestParameters.CancellationToken = linkedTokenSource.Token;
      ClosePositionRequestParameters parameters = requestParameters;
      try
      {
        if (!this.Connected)
        {
          long requestId = parameters.RequestId;
          DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 1);
          interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓝());
          interpolatedStringHandler.AppendFormatted<ConnectionState>(this.State);
          string stringAndClear = interpolatedStringHandler.ToStringAndClear();
          tradingOperationResult = TradingOperationResult.CreateError(requestId, stringAndClear);
          return tradingOperationResult;
        }
        AllowedResult allowedResult = TradingOperations.IsAllowed(TradingOperation.ClosePosition, new TradingOperationParameters()
        {
          Position = parameters.Position
        });
        if (allowedResult.Status == TradingOperationStatus.NotAllowed)
        {
          tradingOperationResult = TradingOperationResult.CreateError(parameters.RequestId, allowedResult.Reason);
          return tradingOperationResult;
        }
        this.퓏((RequestParameters) parameters);
        Core.Instance.Loggers.Log((ILoggable) parameters, LoggingLevel.Trading, this.Name);
        tradingOperationResult = this.픂핀.ClosePosition(parameters);
      }
      catch (Exception ex)
      {
        tradingOperationResult = TradingOperationResult.CreateError(parameters.RequestId, ex.Message);
      }
      finally
      {
        Core.Instance.Loggers.Log((ILoggable) tradingOperationResult, LoggingLevel.Trading, this.Name);
        this.퓏((RequestParameters) parameters, (object) tradingOperationResult);
      }
      return tradingOperationResult;
    }
  }

  internal TradingOperationResult 퓏([In] CancelOrderRequestParameters obj0)
  {
    TradingOperationResult tradingOperationResult = (TradingOperationResult) null;
    using (CancellationTokenSource linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(obj0.CancellationToken, this.픂픲.Token))
    {
      CancelOrderRequestParameters requestParameters = new CancelOrderRequestParameters(obj0);
      requestParameters.CancellationToken = linkedTokenSource.Token;
      CancelOrderRequestParameters parameters = requestParameters;
      try
      {
        if (!this.Connected)
        {
          long requestId = parameters.RequestId;
          DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 1);
          interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓝());
          interpolatedStringHandler.AppendFormatted<ConnectionState>(this.State);
          string stringAndClear = interpolatedStringHandler.ToStringAndClear();
          tradingOperationResult = TradingOperationResult.CreateError(requestId, stringAndClear);
          return tradingOperationResult;
        }
        AllowedResult allowedResult = TradingOperations.IsAllowed(TradingOperation.CancelOrder, new TradingOperationParameters()
        {
          Order = parameters.Order
        });
        if (allowedResult.Status == TradingOperationStatus.NotAllowed)
        {
          tradingOperationResult = TradingOperationResult.CreateError(parameters.RequestId, allowedResult.Reason);
          return tradingOperationResult;
        }
        this.퓏((RequestParameters) parameters);
        Core.Instance.Loggers.Log((ILoggable) parameters, LoggingLevel.Trading, this.Name);
        tradingOperationResult = this.픂핀.CancelOrder(parameters);
        return tradingOperationResult;
      }
      catch (Exception ex)
      {
        tradingOperationResult = TradingOperationResult.CreateError(obj0.RequestId, ex.Message);
        return tradingOperationResult;
      }
      finally
      {
        Core.Instance.Loggers.Log((ILoggable) tradingOperationResult, LoggingLevel.Trading, this.Name);
        this.퓏((RequestParameters) parameters, (object) tradingOperationResult);
      }
    }
  }

  internal MarginInfo 퓏([In] OrderRequestParameters obj0)
  {
    MarginInfo marginInfo = (MarginInfo) null;
    if (!this.Connected)
    {
      Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픢(), LoggingLevel.Verbose);
      return marginInfo;
    }
    try
    {
      using (CancellationTokenSource linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(obj0.CancellationToken, this.픂픲.Token))
      {
        obj0.CancellationToken = linkedTokenSource.Token;
        marginInfo = this.픂핀.GetMarginInfo(obj0);
      }
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex, loggingLevel: LoggingLevel.Verbose);
    }
    return marginInfo;
  }

  internal Symbol 퓏([In] GetSymbolRequestParameters obj0, NonFixedListDownload _param2 = NonFixedListDownload.Download)
  {
    if (this.Connected)
      return this.퓬(obj0, _param2);
    Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픢(), LoggingLevel.Verbose);
    return (Symbol) null;
  }

  internal Symbol 퓬([In] GetSymbolRequestParameters obj0, NonFixedListDownload _param2 = NonFixedListDownload.Download)
  {
    Symbol symbol = (Symbol) null;
    if (string.IsNullOrEmpty(obj0.SymbolId) || this.픂픹.SymbolsCache.퓏(obj0.SymbolId, out symbol) || !this.픂핀.AllowNonFixedList || _param2 == NonFixedListDownload.IgnoreDownload)
      return symbol;
    픇<Symbol> 픇 = this.픂픹.GetSymbolRequestCache.퓏(obj0);
    if (픇 != null && 픇.Finished)
      return 픇.Result;
    try
    {
      using (CancellationTokenSource linkedTokenSource1 = CancellationTokenSource.CreateLinkedTokenSource(obj0.CancellationToken, this.픂픲.Token))
      {
        GetSymbolRequestParameters requestParameters1 = new GetSymbolRequestParameters(obj0);
        requestParameters1.CancellationToken = linkedTokenSource1.Token;
        GetSymbolRequestParameters requestParameters2 = requestParameters1;
        MessageSymbol nonFixedSymbol = this.픂핀.GetNonFixedSymbol(requestParameters2);
        if (nonFixedSymbol == null)
          return symbol;
        this.픂픹.Push((Message) nonFixedSymbol);
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(15.0));
        using (CancellationTokenSource linkedTokenSource2 = CancellationTokenSource.CreateLinkedTokenSource(requestParameters2.CancellationToken, cancellationTokenSource.Token))
        {
          while (!linkedTokenSource2.IsCancellationRequested)
          {
            if (this.픂픹.SymbolsCache.퓏(nonFixedSymbol.Id, out symbol))
              return symbol;
            Thread.Sleep(100);
          }
          Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픪() + obj0.SymbolId, LoggingLevel.Verbose);
        }
      }
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex, loggingLevel: LoggingLevel.Verbose);
    }
    finally
    {
      if (!obj0.CancellationToken.IsCancellationRequested)
        this.픂픹.GetSymbolRequestCache.퓏(obj0, symbol);
    }
    return symbol;
  }

  internal IList<Symbol> 퓏([In] SearchSymbolsRequestParameters obj0)
  {
    List<Symbol> collection = new List<Symbol>();
    if (!this.Connected)
    {
      Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픢(), LoggingLevel.Verbose);
      return (IList<Symbol>) null;
    }
    using (CancellationTokenSource linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(obj0.CancellationToken, this.픂픲.Token))
    {
      SearchSymbolsRequestParameters requestParameters = new SearchSymbolsRequestParameters(obj0);
      requestParameters.CancellationToken = linkedTokenSource.Token;
      SearchSymbolsRequestParameters origin = requestParameters;
      origin.SymbolTypes = (IList<SymbolType>) origin.SymbolTypes.Intersect<SymbolType>((IEnumerable<SymbolType>) this.BusinessObjects.SymbolTypes).ToList<SymbolType>();
      if (string.IsNullOrEmpty(origin.FilterName) || !this.픂핀.AllowNonFixedList)
        return this.퓬(origin);
      픇<List<Symbol>> 픇 = this.픂픹.SearchSymbolsRequestCache.퓏(origin);
      if (픇 != null && 픇.Finished)
        return (IList<Symbol>) new List<Symbol>((IEnumerable<Symbol>) 픇.Result);
      try
      {
        IList<MessageSymbolInfo> messageSymbolInfoList = this.픂핀.SearchSymbols(new SearchSymbolsRequestParameters(origin));
        if (messageSymbolInfoList == null || messageSymbolInfoList.Count == 0)
          return (IList<Symbol>) collection;
        foreach (MessageSymbolInfo messageSymbolInfo in (IEnumerable<MessageSymbolInfo>) messageSymbolInfoList)
        {
          if (messageSymbolInfo != null)
            collection.Add(this.픂픹.퓏(messageSymbolInfo));
        }
      }
      catch (Exception ex)
      {
        Core.Instance.Loggers.Log(ex, loggingLevel: LoggingLevel.Verbose);
      }
      finally
      {
        if (!origin.CancellationToken.IsCancellationRequested)
          this.픂픹.SearchSymbolsRequestCache.퓏(origin, new List<Symbol>((IEnumerable<Symbol>) collection));
      }
      return (IList<Symbol>) collection;
    }
  }

  internal IList<Symbol> 퓏([In] GetFutureContractsRequestParameters obj0)
  {
    IList<Symbol> collection = (IList<Symbol>) new List<Symbol>();
    if (!this.Connected)
    {
      Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픢(), LoggingLevel.Verbose);
      return (IList<Symbol>) null;
    }
    using (CancellationTokenSource linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(obj0.CancellationToken, this.픂픲.Token))
    {
      GetFutureContractsRequestParameters requestParameters1 = new GetFutureContractsRequestParameters(obj0);
      requestParameters1.CancellationToken = linkedTokenSource.Token;
      GetFutureContractsRequestParameters requestParameters2 = requestParameters1;
      if (!this.픂핀.AllowNonFixedList)
        return this.퓏(requestParameters2, false);
      픇<List<Symbol>> 픇 = this.픂픹.GetFutureContractsRequestCache.퓏(requestParameters2);
      if (픇 != null && 픇.Finished)
        return (IList<Symbol>) new List<Symbol>((IEnumerable<Symbol>) 픇.Result);
      try
      {
        IList<MessageSymbolInfo> futureContracts = this.픂핀.GetFutureContracts(requestParameters2);
        if (futureContracts == null || futureContracts.Count == 0)
          return collection;
        foreach (MessageSymbolInfo messageSymbolInfo in (IEnumerable<MessageSymbolInfo>) futureContracts)
        {
          if (messageSymbolInfo != null)
            collection.Add(this.픂픹.퓏(messageSymbolInfo));
        }
      }
      catch (Exception ex)
      {
        Core.Instance.Loggers.Log(ex, loggingLevel: LoggingLevel.Verbose);
      }
      finally
      {
        if (!requestParameters2.CancellationToken.IsCancellationRequested)
          this.픂픹.GetFutureContractsRequestCache.퓏(requestParameters2, new List<Symbol>((IEnumerable<Symbol>) collection));
      }
      return collection;
    }
  }

  internal IList<OptionSerie> 퓏([In] GetOptionSeriesRequestParameters obj0_1)
  {
    List<OptionSerie> optionSerieList = new List<OptionSerie>();
    if (!this.Connected)
    {
      Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픢(), LoggingLevel.Verbose);
      return (IList<OptionSerie>) optionSerieList;
    }
    using (CancellationTokenSource linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(obj0_1.CancellationToken, this.픂픲.Token))
    {
      GetOptionSeriesRequestParameters requestParameters1 = new GetOptionSeriesRequestParameters(obj0_1);
      requestParameters1.CancellationToken = linkedTokenSource.Token;
      GetOptionSeriesRequestParameters requestParameters2 = requestParameters1;
      if (!this.픂핀.AllowNonFixedList)
        return this.퓬(requestParameters2);
      픇<List<OptionSerie>> 픇 = this.픂픹.GetOptionSeriesRequestCache.퓏(requestParameters2);
      if (픇 != null && 픇.Finished)
        return (IList<OptionSerie>) new List<OptionSerie>((IEnumerable<OptionSerie>) 픇.Result);
      try
      {
        IList<MessageOptionSerie> optionSeries = this.픂핀.GetOptionSeries(requestParameters2);
        if (optionSeries == null)
          return (IList<OptionSerie>) optionSerieList;
        foreach (MessageOptionSerie messageOptionSerie in (IEnumerable<MessageOptionSerie>) optionSeries)
        {
          if (messageOptionSerie != null)
            optionSerieList.Add(this.픂픹.퓏(messageOptionSerie));
        }
        optionSerieList = optionSerieList.OrderBy<OptionSerie, DateTime>((Func<OptionSerie, DateTime>) (([In] obj0_2) => obj0_2.ExpirationDate)).ToList<OptionSerie>();
      }
      catch (Exception ex)
      {
        Core.Instance.Loggers.Log(ex, loggingLevel: LoggingLevel.Verbose);
      }
      finally
      {
        if (!requestParameters2.CancellationToken.IsCancellationRequested)
          this.픂픹.GetOptionSeriesRequestCache.퓏(requestParameters2, new List<OptionSerie>((IEnumerable<OptionSerie>) optionSerieList));
      }
      return (IList<OptionSerie>) optionSerieList;
    }
  }

  internal IList<Symbol> 퓏([In] GetStrikesRequestParameters obj0)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Connection.퓬 퓬 = new Connection.퓬();
    // ISSUE: reference to a compiler-generated field
    퓬.퓠픯 = obj0;
    List<Symbol> collection = new List<Symbol>();
    if (!this.Connected)
    {
      Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픢(), LoggingLevel.Verbose);
      return (IList<Symbol>) null;
    }
    // ISSUE: reference to a compiler-generated field
    using (CancellationTokenSource linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(퓬.퓠픯.CancellationToken, this.픂픲.Token))
    {
      // ISSUE: reference to a compiler-generated field
      GetStrikesRequestParameters requestParameters = new GetStrikesRequestParameters(퓬.퓠픯);
      requestParameters.CancellationToken = linkedTokenSource.Token;
      GetStrikesRequestParameters origin = requestParameters;
      if (!this.픂핀.AllowNonFixedList)
      {
        // ISSUE: reference to a compiler-generated method
        return (IList<Symbol>) ((IEnumerable<Symbol>) this.픂픹.Symbols).Where<Symbol>(new Func<Symbol, bool>(퓬.퓏)).ToList<Symbol>();
      }
      픇<List<Symbol>> 픇 = this.픂픹.GetStrikesRequestCache.퓏(origin);
      if (픇 != null && 픇.Finished)
        return (IList<Symbol>) new List<Symbol>((IEnumerable<Symbol>) 픇.Result);
      try
      {
        IList<MessageSymbolInfo> strikes = this.픂핀.GetStrikes(new GetStrikesRequestParameters(origin));
        if (strikes == null)
          return (IList<Symbol>) collection;
        foreach (MessageSymbolInfo messageSymbolInfo in (IEnumerable<MessageSymbolInfo>) strikes)
        {
          if (messageSymbolInfo != null)
            collection.Add(this.픂픹.퓏(messageSymbolInfo));
        }
      }
      catch (Exception ex)
      {
        Core.Instance.Loggers.Log(ex, loggingLevel: LoggingLevel.Verbose);
      }
      finally
      {
        if (!origin.CancellationToken.IsCancellationRequested)
          this.픂픹.GetStrikesRequestCache.퓏(origin, new List<Symbol>((IEnumerable<Symbol>) collection));
      }
      return (IList<Symbol>) collection;
    }
  }

  private IList<Symbol> 퓬([In] SearchSymbolsRequestParameters obj0)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Connection.핇 핇 = new Connection.핇();
    // ISSUE: reference to a compiler-generated field
    핇.퓠퓵 = obj0;
    IEnumerable<Symbol> source = (IEnumerable<Symbol>) this.픂픹.Symbols;
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    핇.퓠퓾 = 핇.퓠퓵.ExchangeIds;
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    if (핇.퓠퓾 != null && 핇.퓠퓾.Any<string>())
    {
      // ISSUE: reference to a compiler-generated method
      source = source.Where<Symbol>(new Func<Symbol, bool>(핇.퓏));
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    핇.퓠퓐 = 핇.퓠퓵.SymbolTypes;
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    if (핇.퓠퓐 != null && 핇.퓠퓐.Any<SymbolType>())
    {
      // ISSUE: reference to a compiler-generated method
      source = source.Where<Symbol>(new Func<Symbol, bool>(핇.퓬));
    }
    // ISSUE: reference to a compiler-generated field
    string filterName = 핇.퓠퓵.FilterName;
    if (string.IsNullOrEmpty(filterName))
      return (IList<Symbol>) source.ToList<Symbol>();
    // ISSUE: reference to a compiler-generated field
    핇.퓠픚 = filterName.Split(new char[1]{ ' ' }, StringSplitOptions.RemoveEmptyEntries);
    // ISSUE: reference to a compiler-generated method
    return (IList<Symbol>) source.Where<Symbol>(new Func<Symbol, bool>(핇.핇)).ToList<Symbol>();
  }

  private IList<Symbol> 퓏([In] GetFutureContractsRequestParameters obj0, bool _param2 = false)
  {
    List<Symbol> symbolList = new List<Symbol>();
    foreach (Symbol symbol in _param2 ? (IEnumerable<Symbol>) this.픂픹.SymbolsInfoCache.Values : (IEnumerable<Symbol>) this.픂픹.Symbols)
    {
      if (symbol.SymbolType == SymbolType.Futures || symbol.SymbolType == SymbolType.Forward)
      {
        if (!string.IsNullOrEmpty(obj0.UnderlierId))
        {
          if (symbol.Underlier != null && symbol.Underlier.Id == obj0.UnderlierId)
            symbolList.Add(symbol);
        }
        else if (symbol.Root == obj0.Root)
          symbolList.Add(symbol);
      }
    }
    return (IList<Symbol>) symbolList;
  }

  private IList<OptionSerie> 퓬([In] GetOptionSeriesRequestParameters obj0)
  {
    List<OptionSerie> optionSerieList;
    return this.픂픹.OptionSeriesCache.퓏(obj0.UnderlierId, out optionSerieList) ? (IList<OptionSerie>) optionSerieList : (IList<OptionSerie>) new List<OptionSerie>();
  }

  private static bool 퓏([In] string[] obj0, [In] Symbol obj1, [In] Func<string, string> obj2)
  {
    bool flag1 = true;
    foreach (string str1 in obj0)
    {
      int num = obj1.Name.Contains(str1, StringComparison.InvariantCultureIgnoreCase) ? 1 : 0;
      bool flag2 = !string.IsNullOrEmpty(obj1.Description) && obj1.Description.Contains(str1, StringComparison.InvariantCultureIgnoreCase);
      bool flag3 = str1.Length > 2 && obj1.Name.Contains(str1.Insert(3, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픉()), StringComparison.InvariantCultureIgnoreCase);
      bool flag4 = str1.Length > 3 && str1[3] == '/' && obj1.Name.Contains(str1.Remove(3, 1), StringComparison.InvariantCultureIgnoreCase);
      bool flag5 = false;
      bool flag6 = false;
      bool flag7 = false;
      if (obj2 != null)
      {
        string str2 = obj2(str1);
        if (!string.IsNullOrEmpty(str2))
        {
          flag5 = obj1.Name.Contains(str2, StringComparison.InvariantCultureIgnoreCase);
          flag6 = str2.Length > 2 && obj1.Name.Contains(str2.Insert(3, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픉()), StringComparison.InvariantCultureIgnoreCase);
          flag7 = str2.Length > 3 && str2[3] == '/' && obj1.Name.Contains(str2.Remove(3, 1), StringComparison.InvariantCultureIgnoreCase);
        }
      }
      if (num == 0 && !flag2 && !flag3 && !flag4 && !flag5 && !flag6 && !flag7)
      {
        flag1 = false;
        break;
      }
    }
    return flag1;
  }

  internal Order 퓏([In] string obj0)
  {
    if (this.State != ConnectionState.Connected)
      return (Order) null;
    if (this.픂픹 == null)
      return (Order) null;
    Order order;
    return this.픂픹.OrdersCache.퓏(obj0, out order) ? order : (Order) null;
  }

  internal PnL 퓏([In] PnLRequestParameters obj0)
  {
    if (!this.Connected)
    {
      Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픢(), LoggingLevel.Verbose);
      return (PnL) null;
    }
    try
    {
      using (CancellationTokenSource linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(obj0.CancellationToken, this.픂픲.Token))
      {
        Vendor 픂핀 = this.픂핀;
        PnLRequestParameters parameters = new PnLRequestParameters(obj0);
        parameters.CancellationToken = linkedTokenSource.Token;
        PnL pnL = 픂핀.CalculatePnL(parameters);
        if (pnL == null)
          return pnL;
        if (pnL.GrossPnL != null)
          pnL.GrossPnL.ConnectionId = this.Id;
        if (pnL.NetPnL != null)
          pnL.NetPnL.ConnectionId = this.Id;
        if (pnL.Fee != null)
          pnL.Fee.ConnectionId = this.Id;
        return pnL;
      }
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex, loggingLevel: LoggingLevel.Verbose);
    }
    return (PnL) null;
  }

  internal Position 퓬([In] string obj0)
  {
    if (this.State != ConnectionState.Connected)
      return (Position) null;
    if (this.픂픹 == null)
      return (Position) null;
    Position position;
    return this.픂픹.PositionsCache.퓏(obj0, out position) ? position : (Position) null;
  }

  private IList<IHistoryItem> 퓏([In] HistoryRequestParameters obj0)
  {
    IList<IHistoryItem> historyItemList = (IList<IHistoryItem>) new List<IHistoryItem>();
    if (!this.Connected)
    {
      Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픢(), LoggingLevel.Verbose);
      return historyItemList;
    }
    try
    {
      using (CancellationTokenSource linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(obj0.CancellationToken, this.픂픲.Token))
      {
        Vendor 픂핀 = this.픂핀;
        HistoryRequestParameters requestParameters = new HistoryRequestParameters(obj0);
        requestParameters.CancellationToken = linkedTokenSource.Token;
        historyItemList = 픂핀.LoadHistory(requestParameters);
      }
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex, loggingLevel: LoggingLevel.Verbose);
    }
    return historyItemList;
  }

  [Obfuscation(Exclude = true)]
  internal VolumeAnalysisInterval LoadVolumeAnalysis(
    VolumeAnalysisByPeriodRequestParameters requestParameters)
  {
    if (!this.Connected)
    {
      Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픢(), LoggingLevel.Verbose);
      return (VolumeAnalysisInterval) null;
    }
    try
    {
      using (CancellationTokenSource linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(requestParameters.CancellationToken, this.픂픲.Token))
      {
        VolumeAnalysisByPeriodRequestParameters requestParameters1 = new VolumeAnalysisByPeriodRequestParameters(requestParameters);
        requestParameters1.CancellationToken = linkedTokenSource.Token;
        VolumeAnalysisByPeriodRequestParameters requestParameters2 = requestParameters1;
        VendorVolumeAnalysisByPeriodResponse byPeriodResponse = this.픂핀.LoadVolumeAnalysis(requestParameters2);
        if (byPeriodResponse == null)
          return (VolumeAnalysisInterval) null;
        return new VolumeAnalysisInterval()
        {
          Interval = byPeriodResponse.ActualDataInterval,
          Description = requestParameters2.ToDescription(),
          VolumeAnalysis = byPeriodResponse.Data
        };
      }
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex, loggingLevel: LoggingLevel.Verbose);
    }
    return (VolumeAnalysisInterval) null;
  }

  public IEnumerable<NewsArticle> GetNews(GetNewsRequestParameters requestParameters)
  {
    using (CancellationTokenSource linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(requestParameters.CancellationToken, this.픂픲.Token))
    {
      Vendor 픂핀 = this.픂핀;
      GetNewsRequestParameters requestParameters1 = new GetNewsRequestParameters(requestParameters);
      requestParameters1.CancellationToken = linkedTokenSource.Token;
      IEnumerable<MessageNewsHeadline> news = 픂핀.GetNews(requestParameters1);
      if (news == null)
        return (IEnumerable<NewsArticle>) Array.Empty<NewsArticle>();
      if (!news.Any<MessageNewsHeadline>())
        return (IEnumerable<NewsArticle>) Array.Empty<NewsArticle>();
      List<NewsArticle> newsArticleList = new List<NewsArticle>();
      foreach (MessageNewsHeadline messageNewsHeadline in news)
      {
        if (messageNewsHeadline != null)
        {
          if (!requestParameters.CancellationToken.IsCancellationRequested)
          {
            NewsArticle newsArticle = new NewsArticle(this.Id);
            newsArticle.퓏(messageNewsHeadline);
            newsArticleList.Add(newsArticle);
          }
          else
            break;
        }
      }
      return (IEnumerable<NewsArticle>) newsArticleList.ToArray();
    }
  }

  public string GetNewsArticleContent(
    GetNewsArticleContentRequestParameters requestParameters)
  {
    using (CancellationTokenSource linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(requestParameters.CancellationToken, this.픂픲.Token))
    {
      Vendor 픂핀 = this.픂핀;
      GetNewsArticleContentRequestParameters requestParameters1 = new GetNewsArticleContentRequestParameters(requestParameters);
      requestParameters1.CancellationToken = linkedTokenSource.Token;
      return 픂핀.GetNewsArticleContent(requestParameters1);
    }
  }

  public void SubscribeNewsUpdates(
    SubscribeNewsRequestParameters subscribeNewsRequestParameters,
    Action<NewsArticle> updateAction)
  {
    int key = updateAction != null ? updateAction.GetHashCode() : throw new ArgumentException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓡());
    HashSet<Action<NewsArticle>> actionSet;
    if (!this.픂픹.NewsSubscribersCache.TryGetValue(key, out actionSet))
    {
      actionSet = new HashSet<Action<NewsArticle>>();
      this.픂픹.NewsSubscribersCache[key] = actionSet;
    }
    int count = actionSet.Count;
    actionSet.Add(updateAction);
    if (actionSet.Count <= count)
      return;
    using (CancellationTokenSource linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(subscribeNewsRequestParameters.CancellationToken, this.픂픲.Token))
    {
      subscribeNewsRequestParameters.SubscribeId = key.ToString();
      subscribeNewsRequestParameters.CancellationToken = linkedTokenSource.Token;
      this.픂핀.SubscribeNewsUpdates(subscribeNewsRequestParameters);
    }
  }

  public void UnsubscribeNewsUpdates(
    SubscribeNewsRequestParameters subscribeNewsRequestParameters,
    Action<NewsArticle> updateAction)
  {
    int key = updateAction != null ? updateAction.GetHashCode() : throw new ArgumentException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓡());
    HashSet<Action<NewsArticle>> actionSet;
    if (!this.픂픹.NewsSubscribersCache.TryGetValue(key, out actionSet))
      return;
    int count = actionSet.Count;
    actionSet.Remove(updateAction);
    if (actionSet.Count <= count)
      return;
    using (CancellationTokenSource linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(subscribeNewsRequestParameters.CancellationToken, this.픂픲.Token))
    {
      subscribeNewsRequestParameters.SubscribeId = key.ToString();
      subscribeNewsRequestParameters.CancellationToken = linkedTokenSource.Token;
      this.픂핀.UnsubscribeNewsUpdates(subscribeNewsRequestParameters);
    }
  }

  [Obsolete("Use Core.Instance.GetTrades() instead")]
  public IList<Trade> GetTrades(TradesHistoryRequestParameters parameters)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Connection.퓲 퓲 = new Connection.퓲();
    // ISSUE: reference to a compiler-generated field
    퓲.퓠플 = parameters;
    // ISSUE: reference to a compiler-generated field
    퓲.퓠플.Progress?.Report(0.0f);
    // ISSUE: reference to a compiler-generated field
    if (퓲.퓠플.To > Core.Instance.TimeUtils.DateTimeUtcNow)
    {
      // ISSUE: reference to a compiler-generated field
      퓲.퓠플.To = Core.Instance.TimeUtils.DateTimeUtcNow;
    }
    // ISSUE: reference to a compiler-generated field
    if (퓲.퓠플.ForceReload && !this.TradesHistoryMetadata.AllowReloadFromServer)
    {
      // ISSUE: reference to a compiler-generated field
      퓲.퓠플.ForceReload = false;
    }
    // ISSUE: reference to a compiler-generated field
    using (CancellationTokenSource linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(퓲.퓠플.CancellationToken, this.픂픲.Token))
    {
      CancellationToken token = linkedTokenSource.Token;
      List<Interval<DateTime>> intervalList;
      // ISSUE: reference to a compiler-generated field
      IList<UserTradesInterval> source = this.퓏(퓲.퓠플, out intervalList);
      foreach (Interval<DateTime> interval in intervalList)
      {
        if (!token.IsCancellationRequested)
        {
          TradesHistoryRequestParameters requestParameters = new TradesHistoryRequestParameters();
          requestParameters.From = interval.From;
          requestParameters.To = interval.To;
          // ISSUE: reference to a compiler-generated field
          requestParameters.SymbolId = 퓲.퓠플.SymbolId;
          // ISSUE: reference to a compiler-generated field
          requestParameters.ForceReload = 퓲.퓠플.ForceReload;
          requestParameters.CancellationToken = token;
          // ISSUE: reference to a compiler-generated field
          requestParameters.Progress = 퓲.퓠플.Progress;
          TradesHistoryRequestParameters parameters1 = requestParameters;
          IList<MessageTrade> messageTradeList = (IList<MessageTrade>) null;
          try
          {
            messageTradeList = this.픂핀.GetTrades(parameters1);
          }
          catch (Exception ex)
          {
            Core.Instance.Loggers.Log(ex);
          }
          if (!token.IsCancellationRequested)
          {
            if (messageTradeList != null)
            {
              UserTradesInterval historyInterval = this.퓏(parameters1, messageTradeList);
              source.Add(historyInterval);
              // ISSUE: reference to a compiler-generated field
              if (string.IsNullOrEmpty(퓲.퓠플.SymbolId) || !this.픂픹.UsersTradesCacheMetadata.AllowSingleSymbolLoading)
                this.픂픋?.Save(historyInterval);
            }
          }
          else
            break;
        }
        else
          break;
      }
      if (token.IsCancellationRequested)
        return (IList<Trade>) Array.Empty<Trade>();
      // ISSUE: reference to a compiler-generated method
      MessageTrade[] array = source.OrderBy<UserTradesInterval, DateTime>((Func<UserTradesInterval, DateTime>) (([In] obj0) => obj0.Interval.From)).SelectMany<UserTradesInterval, MessageTrade>((Func<UserTradesInterval, IEnumerable<MessageTrade>>) (([In] obj0) => obj0.Trades)).Where<MessageTrade>(new Func<MessageTrade, bool>(퓲.퓏)).ToArray<MessageTrade>();
      return !((IEnumerable<MessageTrade>) array).Any<MessageTrade>() ? (IList<Trade>) Array.Empty<Trade>() : (IList<Trade>) this.퓏((IList<MessageTrade>) array, token);
    }
  }

  internal void 퓏([In] TradesHistoryRequestParameters obj0_1, [In] AccountTradesLoadingCallback obj1)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Connection.핂 핂 = new Connection.핂();
    // ISSUE: reference to a compiler-generated field
    핂.퓠퓼 = obj1;
    // ISSUE: reference to a compiler-generated field
    핂.퓠퓴 = this;
    // ISSUE: reference to a compiler-generated field
    핂.퓠픳 = obj0_1;
    // ISSUE: reference to a compiler-generated field
    if (핂.퓠픳 == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픾());
    // ISSUE: reference to a compiler-generated field
    if (핂.퓠퓼 == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓓());
    // ISSUE: reference to a compiler-generated field
    핂.퓠픳.Progress?.Report(0.0f);
    // ISSUE: reference to a compiler-generated field
    if (핂.퓠픳.To > Core.Instance.TimeUtils.DateTimeUtcNow)
    {
      // ISSUE: reference to a compiler-generated field
      핂.퓠픳.To = Core.Instance.TimeUtils.DateTimeUtcNow;
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    핂.퓠픙 = CancellationTokenSource.CreateLinkedTokenSource(핂.퓠픳.CancellationToken, this.픂픲.Token);
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    핂.퓠픥 = 핂.퓠픙.Token;
    List<Interval<DateTime>> source1;
    // ISSUE: reference to a compiler-generated field
    IList<UserTradesInterval> source2 = this.퓏(핂.퓠픳, out source1);
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    핂.퓠퓼.InvokeSafely((object) this.퓏((IList<MessageTrade>) source2.SelectMany<UserTradesInterval, MessageTrade>((Func<UserTradesInterval, IEnumerable<MessageTrade>>) (([In] obj0_2) => obj0_2.Trades)).ToList<MessageTrade>(), 핂.퓠픥), (object) !source1.Any<Interval<DateTime>>());
    foreach (Interval<DateTime> interval in source1)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Connection.픂 픂1 = new Connection.픂();
      // ISSUE: reference to a compiler-generated field
      픂1.퓠픍 = 핂;
      // ISSUE: reference to a compiler-generated field
      픂1.퓠퓭 = interval;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      if (픂1.퓠픍.퓠픥.IsCancellationRequested)
        break;
      // ISSUE: variable of a compiler-generated type
      Connection.픂 픂2 = 픂1;
      TradesHistoryRequestParameters requestParameters = new TradesHistoryRequestParameters();
      // ISSUE: reference to a compiler-generated field
      requestParameters.From = 픂1.퓠퓭.From;
      // ISSUE: reference to a compiler-generated field
      requestParameters.To = 픂1.퓠퓭.To;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      requestParameters.SymbolId = 픂1.퓠픍.퓠픳.SymbolId;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      requestParameters.ForceReload = 픂1.퓠픍.퓠픳.ForceReload;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      requestParameters.CancellationToken = 픂1.퓠픍.퓠픥;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      requestParameters.Progress = 픂1.퓠픍.퓠픳.Progress;
      // ISSUE: reference to a compiler-generated field
      픂2.퓠퓣 = requestParameters;
      // ISSUE: reference to a compiler-generated field
      픂1.퓠픦 = new List<MessageTrade>();
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      this.픂핀.GetTrades(픂1.퓠퓣, new TradingPlatform.BusinessLayer.Integration.AccountTradesLoadingCallback(픂1.퓏));
    }
  }

  private IList<UserTradesInterval> 퓏(
    [In] TradesHistoryRequestParameters obj0,
    out List<Interval<DateTime>> _param2)
  {
    List<UserTradesInterval> userTradesIntervalList = new List<UserTradesInterval>();
    _param2 = new List<Interval<DateTime>>();
    if (!obj0.ForceReload && this.픂픋 != null)
    {
      IList<UserTradesInterval> collection = this.픂픋.Load(obj0.Interval, out _param2);
      userTradesIntervalList.AddRange((IEnumerable<UserTradesInterval>) collection);
    }
    else
      _param2.Add(obj0.Interval);
    if (!(this.픂퓎 == new DateTime()) && !obj0.ForceReload)
    {
      UsersTradesStorage 픂픋 = this.픂픋;
      if (픂픋 != null && 픂픋.IsRealtimeCollectingAllowed)
      {
        for (int index = 0; index < _param2.Count; ++index)
        {
          Interval<DateTime> interval = _param2[index];
          if (!(interval.To <= this.픂퓎))
          {
            if (interval.From >= this.픂퓎)
              _param2.RemoveAt(index--);
            else
              _param2[index] = new Interval<DateTime>(interval.From, this.픂퓎);
          }
        }
        return (IList<UserTradesInterval>) userTradesIntervalList;
      }
    }
    return (IList<UserTradesInterval>) userTradesIntervalList;
  }

  private UserTradesInterval 퓏([In] TradesHistoryRequestParameters obj0, [In] IList<MessageTrade> obj1)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Connection.픾 픾 = new Connection.픾();
    // ISSUE: reference to a compiler-generated field
    픾.퓠픆 = obj0;
    // ISSUE: reference to a compiler-generated method
    List<MessageTrade> list = obj1.Where<MessageTrade>(new Func<MessageTrade, bool>(픾.퓏)).ToList<MessageTrade>();
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    return new UserTradesInterval()
    {
      Trades = (IEnumerable<MessageTrade>) list,
      Interval = new Interval<DateTime>(픾.퓠픆.From, 픾.퓠픆.To)
    };
  }

  private Trade[] 퓏([In] IList<MessageTrade> obj0, [In] CancellationToken obj1)
  {
    List<Trade> tradeList = new List<Trade>();
    foreach (MessageTrade messageTrade in (IEnumerable<MessageTrade>) obj0)
    {
      if (messageTrade != null)
      {
        if (!obj1.IsCancellationRequested)
        {
          GetSymbolRequestParameters requestParameters = new GetSymbolRequestParameters();
          requestParameters.SymbolId = messageTrade.SymbolId;
          requestParameters.CancellationToken = obj1;
          this.퓏(requestParameters);
          Trade trade = new Trade(this.Id);
          trade.퓏(messageTrade);
          tradeList.Add(trade);
        }
        else
          break;
      }
    }
    return tradeList.ToArray();
  }

  public IList<OrderHistory> GetOrdersHistory(OrdersHistoryRequestParameters parameters)
  {
    parameters.Progress?.Report(0.0f);
    if (parameters.To > Core.Instance.TimeUtils.DateTimeUtcNow)
      parameters.To = Core.Instance.TimeUtils.DateTimeUtcNow;
    using (CancellationTokenSource linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(parameters.CancellationToken, this.픂픲.Token))
    {
      parameters.CancellationToken = linkedTokenSource.Token;
      IList<MessageOrderHistory> source = (IList<MessageOrderHistory>) null;
      try
      {
        source = this.픂핀.GetOrdersHistory(parameters);
      }
      catch (Exception ex)
      {
        Core.Instance.Loggers.Log(ex);
      }
      if (parameters.CancellationToken.IsCancellationRequested)
        return (IList<OrderHistory>) Array.Empty<OrderHistory>();
      if (source == null)
        return (IList<OrderHistory>) Array.Empty<OrderHistory>();
      if (!source.Any<MessageOrderHistory>())
        return (IList<OrderHistory>) Array.Empty<OrderHistory>();
      List<OrderHistory> orderHistoryList = new List<OrderHistory>();
      foreach (MessageOrderHistory messageOrderHistory in (IEnumerable<MessageOrderHistory>) source)
      {
        if (messageOrderHistory != null)
        {
          if (!parameters.CancellationToken.IsCancellationRequested)
          {
            GetSymbolRequestParameters requestParameters = new GetSymbolRequestParameters();
            requestParameters.SymbolId = messageOrderHistory.SymbolId;
            requestParameters.CancellationToken = parameters.CancellationToken;
            this.퓏(requestParameters);
            OrderHistory orderHistory = new OrderHistory(this.Id);
            orderHistory.퓏((MessageOpenOrder) messageOrderHistory);
            orderHistoryList.Add(orderHistory);
          }
          else
            break;
        }
      }
      return (IList<OrderHistory>) orderHistoryList.ToArray();
    }
  }

  internal Report 퓏([In] ReportRequestParameters obj0)
  {
    using (CancellationTokenSource linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(obj0.CancellationToken, this.픂픲.Token))
    {
      ReportRequestParameters reportRequestParameters = new ReportRequestParameters(obj0);
      reportRequestParameters.CancellationToken = linkedTokenSource.Token;
      Report report = this.픂핀.GenerateReport(reportRequestParameters);
      foreach (ReportRow row in report.Rows)
      {
        foreach (ReportCell cell in row.Cells)
        {
          if (cell.formattingDescription != null)
            cell.formattingDescription.ConnectionId = this.Id;
        }
      }
      return report;
    }
  }

  private void 퓏([In] object obj0, [In] VendorEventArgs obj1) => this.퓏(obj1.Message);

  private void 퓏([In] Message obj0)
  {
    if (obj0 == null)
      return;
    this.픂픹.Push(obj0);
  }

  private void 퓏([In] ConnectionState obj0)
  {
    try
    {
      // ISSUE: reference to a compiler-generated field
      EventHandler<ConnectionStateChangedEventArgs> 픂픈 = this.픂픈;
      if (픂픈 == null)
        return;
      픂픈((object) this, new ConnectionStateChangedEventArgs(obj0, this.State, this.LastConnectionResult.Clone() as ConnectionResult));
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
  }

  private void 퓏([In] RequestParameters obj0)
  {
    RequestEventArgs requestEventArgs = new RequestEventArgs(obj0);
    // ISSUE: reference to a compiler-generated field
    EventHandler<RequestEventArgs> 픾퓏 = this.픾퓏;
    if (픾퓏 != null)
      픾퓏.InvokeSafely((object) this, (object) requestEventArgs);
    Core.Instance.퓏(this, requestEventArgs);
  }

  private void 퓏([In] RequestParameters obj0, [In] object obj1)
  {
    // ISSUE: reference to a compiler-generated field
    EventHandler<PerformedRequestEventArgs> 픾퓬 = this.픾퓬;
    if (픾퓬 != null)
      픾퓬.InvokeSafely((object) this, (object) new PerformedRequestEventArgs(obj0, obj1));
    Core.Instance.퓏(obj0, obj1);
  }

  private void 핇([In] string obj0_1)
  {
    try
    {
      int length1 = this.픂픹.Orders.Length;
      int length2 = this.픂픹.Positions.Length;
      if (length1 <= 0 && length2 <= 0)
        return;
      string str1 = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픗();
      DefaultInterpolatedStringHandler interpolatedStringHandler;
      if (length1 > 0)
      {
        interpolatedStringHandler = new DefaultInterpolatedStringHandler(19, 2);
        interpolatedStringHandler.AppendFormatted<int>(length1);
        interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓰());
        interpolatedStringHandler.AppendFormatted(string.Join<Symbol>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픆(), (IEnumerable<Symbol>) ((IEnumerable<Order>) this.픂픹.Orders).GroupBy<Order, Symbol>((Func<Order, Symbol>) (([In] obj0_2) => obj0_2.Symbol)).Select<IGrouping<Symbol, Order>, Symbol>((Func<IGrouping<Symbol, Order>, Symbol>) (([In] obj0_3) => obj0_3.Key)).ToList<Symbol>()));
        interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픗());
        str1 = interpolatedStringHandler.ToStringAndClear();
      }
      string str2 = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픧();
      if (length2 > 0)
      {
        interpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 2);
        interpolatedStringHandler.AppendFormatted<int>(length2);
        interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓹());
        interpolatedStringHandler.AppendFormatted(string.Join<Symbol>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픆(), (IEnumerable<Symbol>) ((IEnumerable<Position>) this.픂픹.Positions).GroupBy<Position, Symbol>((Func<Position, Symbol>) (([In] obj0_4) => obj0_4.Symbol)).Select<IGrouping<Symbol, Position>, Symbol>((Func<IGrouping<Symbol, Position>, Symbol>) (([In] obj0_5) => obj0_5.Key)).ToList<Symbol>()));
        interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픗());
        str2 = interpolatedStringHandler.ToStringAndClear();
      }
      LoggerManager loggers = Core.Instance.Loggers;
      interpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 4);
      interpolatedStringHandler.AppendFormatted(this.Name);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프());
      interpolatedStringHandler.AppendFormatted(obj0_1);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓛());
      interpolatedStringHandler.AppendFormatted(str1);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픝());
      interpolatedStringHandler.AppendFormatted(str2);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픻());
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      loggers.Log(stringAndClear, LoggingLevel.Trading);
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
  }

  [EditorBrowsable(EditorBrowsableState.Never)]
  [Obfuscation(Exclude = true)]
  private void SubscribeOnMessage(Action<Message> handler)
  {
    if (this.픂픹 == null)
      return;
    this.픂픹.퓏(handler);
  }

  public int CompareTo(object obj)
  {
    return obj is Connection connection ? string.Compare(this.Name, connection.Name, StringComparison.Ordinal) : 0;
  }

  public override string ToString() => this.Name;
}
