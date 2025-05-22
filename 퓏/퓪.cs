// Decompiled with JetBrains decompiler
// Type: 퓏.퓪
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using TradingPlatform.BusinessLayer;
using TradingPlatform.BusinessLayer.Integration;
using TradingPlatform.BusinessLayer.Integration.Limitation;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace 퓏;

internal class 퓪 : BufferedProcessor<Message>, 픾, IBusinessObjectsProvider
{
  private readonly string 픾핂;
  internal readonly Dictionary<string, Asset> 픾핁;
  internal bool 픾픸;

  internal HistoryMetadata HistoryMetadata { get; [param: In] set; }

  internal VolumeAnalysisMetadata VolumeAnalysisMetadata { get; [param: In] set; }

  internal IEnumerable<SettingItem> NewsFeedSettings { get; [param: In] set; }

  internal TradesHistoryMetadata UsersTradesCacheMetadata { get; [param: In] set; }

  internal LimitationMetadata LimitationMetadata { get; [param: In] set; }

  internal Dictionary<string, SymbolGroup> SymbolGroupsCache { get; }

  internal 핅<string, Account> AccountsCache { get; }

  internal 핅<string, Symbol> SymbolsCache { get; }

  internal 핅<string, Symbol> SymbolsInfoCache { get; }

  internal 핅<string, Order> OrdersCache { get; }

  internal 핅<string, Position> PositionsCache { get; }

  internal 핅<string, ClosedPosition> ClosedPositionsCache { get; }

  internal 핅<string, CorporateAction> CorporateActionCache { get; }

  internal 핅<int, ReportType> ReportTypeCache { get; }

  internal 핅<string, OrderType> OrderTypesCache { get; [param: In] set; }

  internal 핅<string, Exchange> ExchangesCache { get; }

  internal 핅<string, Rule> RulesCache { get; }

  internal 핅<string, List<OptionSerie>> OptionSeriesCache { get; }

  internal Dictionary<string, SessionsContainer> TradingSessions { get; }

  internal 핅<string, DeliveredAsset> DeliveredAssetsCache { get; }

  internal 핅<string, AccountOperation> AccountOperationsCache { get; }

  internal ConcurrentDictionary<int, HashSet<Action<NewsArticle>>> NewsSubscribersCache { get; }

  internal 핅<string, TradingSignal> TradingSignalsCache { get; }

  public Symbol[] Symbols => this.SymbolsCache.퓏();

  public SymbolType[] SymbolTypes { get; [param: In] private set; }

  public Account[] Accounts => this.AccountsCache.퓏();

  public Asset[] Assets => this.픾핁.Values.ToArray<Asset>();

  public Exchange[] Exchanges => this.ExchangesCache.Values.ToArray<Exchange>();

  public Order[] Orders => this.OrdersCache.퓏();

  public OrderType[] OrderTypes => this.OrderTypesCache.퓏();

  public Position[] Positions => this.PositionsCache.퓏();

  public ClosedPosition[] ClosedPositions => this.ClosedPositionsCache.퓏();

  public CorporateAction[] CorporateActions => this.CorporateActionCache.퓏();

  public ReportType[] ReportTypes => this.ReportTypeCache.퓏();

  public DeliveredAsset[] DeliveredAssets => this.DeliveredAssetsCache.퓏();

  public AccountOperation[] AccountOperations => this.AccountOperationsCache.퓏();

  public TradingSignal[] TradingSignals => this.TradingSignalsCache.퓏();

  int 픾.TradingPlatform\u002EBusinessLayer\u002EIRulesContainer\u002EPriorityIndex => 0;

  핅<string, Rule> 픾.TradingPlatform\u002EBusinessLayer\u002EIRulesContainer\u002ERules
  {
    get => this.RulesCache;
  }

  internal 퓪([In] string obj0)
  {
    this.픾핂 = obj0;
    this.AccountsCache = new 핅<string, Account>();
    this.SymbolsCache = new 핅<string, Symbol>();
    this.SymbolsInfoCache = new 핅<string, Symbol>();
    this.픾핁 = new Dictionary<string, Asset>();
    this.OrdersCache = new 핅<string, Order>();
    this.PositionsCache = new 핅<string, Position>();
    this.ClosedPositionsCache = new 핅<string, ClosedPosition>();
    this.CorporateActionCache = new 핅<string, CorporateAction>();
    this.ReportTypeCache = new 핅<int, ReportType>();
    this.OrderTypesCache = new 핅<string, OrderType>();
    this.RulesCache = new 핅<string, Rule>();
    this.OptionSeriesCache = new 핅<string, List<OptionSerie>>();
    this.SymbolGroupsCache = new Dictionary<string, SymbolGroup>();
    this.SymbolTypes = new SymbolType[0];
    this.ExchangesCache = new 핅<string, Exchange>();
    this.TradingSessions = new Dictionary<string, SessionsContainer>();
    this.DeliveredAssetsCache = new 핅<string, DeliveredAsset>();
    this.AccountOperationsCache = new 핅<string, AccountOperation>();
    this.NewsSubscribersCache = new ConcurrentDictionary<int, HashSet<Action<NewsArticle>>>();
    this.TradingSignalsCache = new 핅<string, TradingSignal>();
    this.GetSymbolRequestCache = new 핁<GetSymbolRequestParameters, Symbol>();
    this.SearchSymbolsRequestCache = new 핁<SearchSymbolsRequestParameters, List<Symbol>>();
    this.GetFutureContractsRequestCache = new 핁<GetFutureContractsRequestParameters, List<Symbol>>();
    this.GetOptionSeriesRequestCache = new 핁<GetOptionSeriesRequestParameters, List<OptionSerie>>();
    this.GetStrikesRequestCache = new 핁<GetStrikesRequestParameters, List<Symbol>>();
  }

  internal void 퓏()
  {
    Core.Instance.RulesManager.Defaults.ForEach((Action<Rule>) (([In] obj0) => this.RulesCache.퓏(obj0.Name, obj0)));
    this.Start();
  }

  protected internal override void Clear()
  {
    List<BusinessObject> businessObjectList = new List<BusinessObject>();
    businessObjectList.AddRange((IEnumerable<BusinessObject>) this.AccountsCache);
    this.AccountsCache.퓬();
    businessObjectList.AddRange((IEnumerable<BusinessObject>) this.SymbolsCache);
    this.SymbolsCache.퓬();
    this.SymbolsInfoCache.퓬();
    this.SymbolTypes = new SymbolType[0];
    this.OrdersCache.퓬();
    this.PositionsCache.퓬();
    this.ClosedPositionsCache.퓬();
    this.CorporateActionCache.퓬();
    this.ReportTypeCache.퓬();
    this.픾핁.Clear();
    this.OrderTypesCache.퓬();
    this.ExchangesCache.퓬();
    this.RulesCache.퓬();
    this.AccountOperationsCache.퓬();
    this.TradingSignalsCache.퓬();
    this.GetSymbolRequestCache.Dispose();
    this.SearchSymbolsRequestCache.Dispose();
    this.GetFutureContractsRequestCache.Dispose();
    this.GetOptionSeriesRequestCache.Dispose();
    this.GetStrikesRequestCache.Dispose();
    foreach (BusinessObject businessObject in businessObjectList)
      businessObject.State = BusinessObjectState.Fake;
    base.Clear();
  }

  [Obfuscation(Exclude = true)]
  protected override void Process(Message message)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    퓪.퓬 퓬 = new 퓪.퓬();
    // ISSUE: reference to a compiler-generated field
    퓬.퓠픵 = this;
    // ISSUE: reference to a compiler-generated field
    퓬.퓠픬 = message;
    // ISSUE: reference to a compiler-generated field
    if (퓬.퓠픬 == null)
      return;
    try
    {
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      퓬.퓠퓕 = 퓬.퓠픬 as INeedSymbolToPocess;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      if (퓬.퓠퓕 != null && !string.IsNullOrEmpty(퓬.퓠퓕.SymbolId) && !this.SymbolsCache.퓬(퓬.퓠퓕.SymbolId))
      {
        // ISSUE: reference to a compiler-generated method
        Task.Factory.StartNew(new Action(퓬.퓏));
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        switch (퓬.퓠픬.Type)
        {
          case MessageType.Account:
          case MessageType.CryptoAccount:
            // ISSUE: reference to a compiler-generated field
            this.퓏(퓬.퓠픬 as MessageAccount);
            break;
          case MessageType.Symbol:
            // ISSUE: reference to a compiler-generated field
            this.퓏(퓬.퓠픬 as MessageSymbol);
            break;
          case MessageType.OpenOrder:
            // ISSUE: reference to a compiler-generated field
            this.퓏(퓬.퓠픬 as MessageOpenOrder);
            break;
          case MessageType.CloseOrder:
            // ISSUE: reference to a compiler-generated field
            this.퓏(퓬.퓠픬 as MessageCloseOrder);
            break;
          case MessageType.OpenPosition:
            // ISSUE: reference to a compiler-generated field
            this.퓏(퓬.퓠픬 as MessageOpenPosition);
            break;
          case MessageType.ClosePosition:
            // ISSUE: reference to a compiler-generated field
            this.퓏(퓬.퓠픬 as MessageClosePosition);
            break;
          case MessageType.Trade:
            // ISSUE: reference to a compiler-generated field
            this.퓏(퓬.퓠픬 as MessageTrade);
            break;
          case MessageType.Quote:
          case MessageType.Level2:
          case MessageType.Last:
          case MessageType.DayBar:
          case MessageType.DOM:
          case MessageType.Mark:
            // ISSUE: reference to a compiler-generated field
            this.퓏(퓬.퓠픬 as MessageQuote);
            break;
          case MessageType.Asset:
            // ISSUE: reference to a compiler-generated field
            this.퓏(퓬.퓠픬 as MessageAsset);
            break;
          case MessageType.Custom:
            // ISSUE: reference to a compiler-generated field
            this.퓏(퓬.퓠픬 as CustomMessage);
            break;
          case MessageType.Exchange:
            // ISSUE: reference to a compiler-generated field
            this.퓏(퓬.퓠픬 as MessageExchange);
            break;
          case MessageType.ReportMetadata:
            // ISSUE: reference to a compiler-generated field
            this.퓏(퓬.퓠픬 as MessageReportType);
            break;
          case MessageType.SymbolTypes:
            // ISSUE: reference to a compiler-generated field
            this.퓏(퓬.퓠픬 as MessageSymbolTypes);
            break;
          case MessageType.OrderHistory:
            // ISSUE: reference to a compiler-generated field
            this.퓏(퓬.퓠픬 as MessageOrderHistory);
            break;
          case MessageType.Rule:
            // ISSUE: reference to a compiler-generated field
            this.퓏(퓬.퓠픬 as MessageRule);
            break;
          case MessageType.DealTicket:
            // ISSUE: reference to a compiler-generated field
            this.퓏(퓬.퓠픬 as MessageDealTicket);
            break;
          case MessageType.SymbolGroup:
            // ISSUE: reference to a compiler-generated field
            this.퓏(퓬.퓠픬 as MessageSymbolGroup);
            break;
          case MessageType.CryptoAssetBalances:
            // ISSUE: reference to a compiler-generated field
            this.퓏(퓬.퓠픬 as MessageCryptoAssetBalances);
            break;
          case MessageType.OptionSerie:
            // ISSUE: reference to a compiler-generated field
            this.퓏(퓬.퓠픬 as MessageOptionSerie);
            break;
          case MessageType.SymbolInfo:
            // ISSUE: reference to a compiler-generated field
            this.퓏(퓬.퓠픬 as MessageSymbolInfo);
            break;
          case MessageType.Session:
            // ISSUE: reference to a compiler-generated field
            this.퓏(퓬.퓠픬 as MessageSessionsContainer);
            break;
          case MessageType.OpenDeliveredAsset:
            // ISSUE: reference to a compiler-generated field
            this.퓏(퓬.퓠픬 as MessageOpenDeliveredAsset);
            break;
          case MessageType.CloseDeliveredAsset:
            // ISSUE: reference to a compiler-generated field
            this.퓏(퓬.퓠픬 as MessageCloseDeliveredAsset);
            break;
          case MessageType.CorporateAction:
            // ISSUE: reference to a compiler-generated field
            this.퓏(퓬.퓠픬 as MessageCorporateAction);
            break;
          case MessageType.AccountOperation:
            // ISSUE: reference to a compiler-generated field
            this.퓏(퓬.퓠픬 as MessageAccountOperation);
            break;
          case MessageType.ClosedPosition:
            // ISSUE: reference to a compiler-generated field
            this.퓏(퓬.퓠픬 as MessageClosedPosition);
            break;
          case MessageType.NewsHeadline:
            // ISSUE: reference to a compiler-generated field
            this.퓏(퓬.퓠픬 as MessageNewsHeadline);
            break;
          case MessageType.TradingSignal:
            // ISSUE: reference to a compiler-generated field
            this.퓏(퓬.퓠픬 as MessageTradingSignal);
            break;
          case MessageType.RemoveTradingSignal:
            // ISSUE: reference to a compiler-generated field
            this.퓏(퓬.퓠픬 as MessageRemoveTradingSignal);
            break;
        }
      }
    }
    finally
    {
      // ISSUE: reference to a compiler-generated field
      Action<Message> 픾프 = this.픾프;
      if (픾프 != null)
      {
        // ISSUE: reference to a compiler-generated field
        픾프(퓬.퓠픬);
      }
    }
  }

  private void 퓏([In] MessageSymbolGroup obj0)
  {
    if (obj0 == null)
      return;
    SymbolGroup symbolGroup;
    if (!this.SymbolGroupsCache.TryGetValue(obj0.Id, out symbolGroup))
    {
      symbolGroup = new SymbolGroup(this.픾핂);
      symbolGroup.퓏(obj0);
      this.SymbolGroupsCache.Add(symbolGroup.Id, symbolGroup);
    }
    else
      symbolGroup.퓏(obj0);
  }

  private void 퓏([In] MessageSymbolTypes obj0)
  {
    if (obj0 == null)
      return;
    IList<SymbolType> symbolTypes = obj0.SymbolTypes;
    this.SymbolTypes = (symbolTypes != null ? symbolTypes.ToArray<SymbolType>() : (SymbolType[]) null) ?? new SymbolType[0];
  }

  private void 퓏([In] MessageExchange obj0)
  {
    if (obj0 == null)
      return;
    Exchange exchange;
    if (!this.ExchangesCache.퓏(obj0.Id, out exchange))
    {
      exchange = new Exchange(this.픾핂);
      exchange.퓏(obj0);
      this.ExchangesCache[exchange.Id] = exchange;
    }
    else
      exchange.퓏(obj0);
  }

  private void 퓏([In] MessageAsset obj0)
  {
    if (obj0 == null)
      return;
    Asset asset;
    if (!this.픾핁.TryGetValue(obj0.Id, out asset))
    {
      asset = new Asset(this.픾핂);
      asset.퓏(obj0);
      this.픾핁[asset.Id] = asset;
    }
    else
      asset.퓏(obj0);
  }

  private void 퓏([In] MessageAccount obj0_1)
  {
    if (obj0_1 == null)
      return;
    List<AdditionalInfoItem> accountAdditionalInfo = obj0_1.AccountAdditionalInfo;
    IEnumerable<IFormattingDescription> formattingDescriptions = accountAdditionalInfo != null ? accountAdditionalInfo.Where<AdditionalInfoItem>((Func<AdditionalInfoItem, bool>) (([In] obj0_2) => obj0_2.FormattingDescription != null)).Select<AdditionalInfoItem, IFormattingDescription>((Func<AdditionalInfoItem, IFormattingDescription>) (([In] obj0_3) => obj0_3.FormattingDescription)) : (IEnumerable<IFormattingDescription>) null;
    if (formattingDescriptions != null)
    {
      foreach (IFormattingDescription formattingDescription in formattingDescriptions)
        formattingDescription.ConnectionId = this.픾핂;
    }
    Account account;
    if (!this.AccountsCache.퓏(obj0_1.AccountId, out account))
    {
      account = !(obj0_1 is MessageCryptoAccount) ? new Account(this.픾핂) : (Account) new CryptoAccount(this.픾핂);
      account.퓏(obj0_1);
      this.AccountsCache.퓏(account.Id, account);
      Core.Instance.퓏(account);
    }
    else
      account.퓏(obj0_1);
  }

  private void 퓏([In] MessageSymbol obj0_1)
  {
    if (obj0_1 == null)
      return;
    List<AdditionalInfoItem> symbolAdditionalInfo = obj0_1.SymbolAdditionalInfo;
    IEnumerable<IFormattingDescription> formattingDescriptions = symbolAdditionalInfo != null ? symbolAdditionalInfo.Where<AdditionalInfoItem>((Func<AdditionalInfoItem, bool>) (([In] obj0_2) => obj0_2.FormattingDescription != null)).Select<AdditionalInfoItem, IFormattingDescription>((Func<AdditionalInfoItem, IFormattingDescription>) (([In] obj0_3) => obj0_3.FormattingDescription)) : (IEnumerable<IFormattingDescription>) null;
    if (formattingDescriptions != null)
    {
      foreach (IFormattingDescription formattingDescription in formattingDescriptions)
        formattingDescription.ConnectionId = this.픾핂;
    }
    Symbol symbol = this.SymbolsCache[obj0_1.Id];
    if (symbol == null)
    {
      lock (this.SymbolsInfoCache)
      {
        if (this.SymbolsInfoCache.퓏(obj0_1.Id, out symbol))
          this.SymbolsInfoCache.퓏(obj0_1.Id);
        else
          symbol = new Symbol(this.픾핂);
      }
      symbol.퓏(obj0_1);
      this.SymbolsCache.퓏(symbol.Id, symbol);
      Core.Instance.퓏(symbol);
    }
    else
      symbol.퓏(obj0_1);
  }

  internal Symbol 퓏([In] MessageSymbolInfo obj0)
  {
    if (obj0 == null)
      return (Symbol) null;
    Symbol symbol;
    if (this.SymbolsCache.퓏(obj0.Id, out symbol))
      return symbol;
    lock (this.SymbolsInfoCache)
      symbol = this.SymbolsInfoCache[obj0.Id];
    if (symbol == null)
    {
      symbol = new Symbol(this.픾핂);
      symbol.퓏(obj0);
      try
      {
        lock (this.SymbolsInfoCache)
          this.SymbolsInfoCache.퓏(symbol.Id, symbol);
      }
      catch (ArgumentException ex)
      {
        Core.Instance.Loggers.Log((Exception) ex);
      }
    }
    else
      symbol.퓏(obj0);
    return symbol;
  }

  private void 퓏([In] MessageQuote obj0)
  {
    if (obj0 == null)
      return;
    this.SymbolsCache[obj0.SymbolId]?.퓏(obj0);
    this.SymbolsInfoCache[obj0.SymbolId]?.퓏(obj0);
  }

  private void 퓏([In] MessageOpenOrder obj0)
  {
    if (obj0 == null)
      return;
    if (string.IsNullOrEmpty(obj0.AccountId))
      Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓤() + obj0.PositionId, LoggingLevel.Error);
    else if (string.IsNullOrEmpty(obj0.SymbolId))
    {
      Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픮() + obj0.PositionId, LoggingLevel.Error);
    }
    else
    {
      Order order;
      if (!this.OrdersCache.퓏(obj0.OrderId, out order))
      {
        order = new Order(this.픾핂);
        order.퓏(obj0);
        this.OrdersCache.퓏(order.Id, order);
      }
      else
        order.퓏(obj0);
      Core.Instance.퓏(order);
    }
  }

  private void 퓏([In] MessageCloseOrder obj0)
  {
    Order order;
    if (obj0 == null || !this.OrdersCache.퓏(obj0.OrderId, out order))
      return;
    this.OrdersCache.퓏(order.Id);
    order.State = BusinessObjectState.Fake;
    Core.Instance.퓬(order);
  }

  private void 퓏([In] MessageOpenPosition obj0)
  {
    if (obj0 == null)
      return;
    if (string.IsNullOrEmpty(obj0.AccountId))
      Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픉() + obj0.PositionId, LoggingLevel.Error);
    else if (string.IsNullOrEmpty(obj0.SymbolId))
    {
      Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픒() + obj0.PositionId, LoggingLevel.Error);
    }
    else
    {
      Position position;
      if (!this.PositionsCache.퓏(obj0.PositionId, out position))
      {
        position = new Position(this.픾핂);
        position.퓏(obj0);
        this.PositionsCache.퓏(position.Id, position);
      }
      else
        position.퓏(obj0);
      Core.Instance.퓏(position);
    }
  }

  private void 퓏([In] MessageClosedPosition obj0)
  {
    if (obj0 == null)
      return;
    if (string.IsNullOrEmpty(obj0.AccountId))
      Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓷() + obj0.PositionId, LoggingLevel.Error);
    else if (string.IsNullOrEmpty(obj0.SymbolId))
    {
      Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓿() + obj0.PositionId, LoggingLevel.Error);
    }
    else
    {
      ClosedPosition closedPosition;
      if (!this.ClosedPositionsCache.퓏(obj0.PositionId, out closedPosition))
      {
        closedPosition = new ClosedPosition(this.픾핂);
        closedPosition.퓏((MessageOpenPosition) obj0);
        this.ClosedPositionsCache.퓏(closedPosition.Id, closedPosition);
      }
      else
        closedPosition.퓏((MessageOpenPosition) obj0);
      Core.Instance.퓏(closedPosition);
    }
  }

  private void 퓏([In] MessageClosePosition obj0)
  {
    if (obj0 == null)
      return;
    Position position;
    if (this.PositionsCache.퓏(obj0.PositionId, out position))
    {
      this.PositionsCache.퓏(position.Id);
      position.State = BusinessObjectState.Fake;
      Core.Instance.퓬(position);
    }
    else
    {
      ClosedPosition closedPosition;
      if (!this.ClosedPositionsCache.퓏(obj0.PositionId, out closedPosition))
        return;
      this.ClosedPositionsCache.퓏(closedPosition.Id);
      closedPosition.State = BusinessObjectState.Fake;
      Core.Instance.퓬(closedPosition);
    }
  }

  private void 퓏([In] MessageTrade obj0)
  {
    if (obj0 == null)
      return;
    Trade trade = new Trade(this.픾핂);
    trade.퓏(obj0);
    Core.Instance.퓏(trade);
  }

  private void 퓏([In] MessageCorporateAction obj0)
  {
    if (obj0 == null)
      return;
    CorporateAction corporateAction;
    if (!this.CorporateActionCache.퓏(obj0.CorporateActionId, out corporateAction))
    {
      corporateAction = new CorporateAction(this.픾핂);
      corporateAction.퓏(obj0);
      this.CorporateActionCache.퓏(corporateAction.Id, corporateAction);
      Core.Instance.퓏(corporateAction);
    }
    else
      corporateAction.퓏(obj0);
  }

  private void 퓏([In] MessageReportType obj0)
  {
    if (obj0 == null)
      return;
    ReportType reportType = new ReportType(this.픾핂);
    reportType.퓏(obj0);
    this.ReportTypeCache.퓏(obj0.Id, reportType);
  }

  private void 퓏([In] MessageOrderHistory obj0)
  {
    if (obj0 == null)
      return;
    OrderHistory orderHistory = new OrderHistory(this.픾핂);
    orderHistory.퓏((MessageOpenOrder) obj0);
    Core.Instance.퓏(orderHistory);
  }

  private void 퓏([In] MessageRule obj0)
  {
    if (obj0 == null)
      return;
    픾 픾 = (픾) null;
    if (obj0.OrderTypeId != \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓯())
    {
      OrderType orderType;
      if (this.OrderTypesCache.퓏(obj0.OrderTypeId, out orderType))
        픾 = (픾) orderType;
    }
    else if (obj0.SymbolId != \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓯())
    {
      Symbol symbol;
      if (this.SymbolsCache.퓏(obj0.SymbolId, out symbol))
        픾 = (픾) symbol;
      else if (this.SymbolsInfoCache.퓏(obj0.SymbolId, out symbol))
        픾 = (픾) symbol;
    }
    else if (obj0.AccountId != \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓯())
    {
      Account account;
      if (this.AccountsCache.퓏(obj0.AccountId, out account))
        픾 = (픾) account;
    }
    else
      픾 = (픾) this;
    if (픾 == null)
      return;
    Rule rule;
    if (픾.Rules.퓏(obj0.Name, out rule))
    {
      rule.퓏(obj0);
    }
    else
    {
      if (!(obj0 is LicenceMessageRule) && RulesManager.퓗.Contains(obj0.Name))
        return;
      rule = Rule.퓬(obj0);
      픾.Rules.퓏(rule.Name, rule);
    }
  }

  private void 퓏([In] MessageDealTicket obj0)
  {
    if (obj0 == null)
      return;
    DealticketConnection dealticketConnection = new DealticketConnection(this.픾핂, obj0);
    Core.Instance.Loggers.Log((ILoggable) dealticketConnection, LoggingLevel.Trading, Core.Instance.Connections[((IConnectionBindedObject) dealticketConnection)?.ConnectionId]?.Name);
    Core.Instance.퓏((DealTicket) dealticketConnection);
  }

  private void 퓏([In] MessageCryptoAssetBalances obj0)
  {
    if (obj0 == null)
      return;
    if (string.IsNullOrEmpty(obj0.AccountId))
      Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픟(), LoggingLevel.Error);
    else if (string.IsNullOrEmpty(obj0.AssetId))
    {
      Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓧(), LoggingLevel.Error);
    }
    else
    {
      Account account;
      if (this.AccountsCache.퓏(obj0.AccountId, out account))
      {
        if (account is CryptoAccount cryptoAccount)
        {
          cryptoAccount.퓏(obj0);
        }
        else
        {
          LoggerManager loggers = Core.Instance.Loggers;
          DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(32 /*0x20*/, 3);
          interpolatedStringHandler.AppendFormatted(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픰());
          interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓢());
          interpolatedStringHandler.AppendFormatted(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픫());
          interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픯());
          interpolatedStringHandler.AppendFormatted(obj0.AccountId);
          string stringAndClear = interpolatedStringHandler.ToStringAndClear();
          loggers.Log(stringAndClear, LoggingLevel.Error);
        }
      }
      else
        Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓾() + obj0.AccountId, LoggingLevel.Error);
    }
  }

  internal OptionSerie 퓏([In] MessageOptionSerie obj0)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    퓪.핇 핇 = new 퓪.핇();
    // ISSUE: reference to a compiler-generated field
    핇.퓠픐 = obj0;
    // ISSUE: reference to a compiler-generated field
    if (핇.퓠픐 == null)
      return (OptionSerie) null;
    List<OptionSerie> source;
    // ISSUE: reference to a compiler-generated field
    if (!this.OptionSeriesCache.퓏(핇.퓠픐.UnderlierId, out source))
    {
      // ISSUE: reference to a compiler-generated field
      this.OptionSeriesCache.퓏(핇.퓠픐.UnderlierId, source = new List<OptionSerie>());
    }
    // ISSUE: reference to a compiler-generated method
    OptionSerie optionSerie = source.FirstOrDefault<OptionSerie>(new Func<OptionSerie, bool>(핇.퓏));
    if (optionSerie == null)
    {
      optionSerie = new OptionSerie(this.픾핂);
      source.Add(optionSerie);
    }
    // ISSUE: reference to a compiler-generated field
    optionSerie.퓏(핇.퓠픐);
    return optionSerie;
  }

  private void 퓏([In] MessageSessionsContainer obj0)
  {
    if (obj0 == null)
      return;
    SessionsContainer sessionsContainer;
    if (!this.TradingSessions.TryGetValue(obj0.Id, out sessionsContainer))
    {
      sessionsContainer = new SessionsContainer(this.픾핂);
      sessionsContainer.UpdateByMessage(obj0);
      this.TradingSessions.Add(sessionsContainer.Id, sessionsContainer);
    }
    else
      sessionsContainer.UpdateByMessage(obj0);
  }

  private void 퓏([In] MessageOpenDeliveredAsset obj0)
  {
    if (obj0 == null)
      return;
    if (string.IsNullOrEmpty(obj0.AccountId))
      Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픉() + obj0.Id, LoggingLevel.Error);
    else if (string.IsNullOrEmpty(obj0.SymbolId))
    {
      Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픒() + obj0.Id, LoggingLevel.Error);
    }
    else
    {
      DeliveredAsset deliveredAsset;
      if (!this.DeliveredAssetsCache.퓏(obj0.Id, out deliveredAsset))
      {
        deliveredAsset = new DeliveredAsset(this.픾핂);
        deliveredAsset.퓏(obj0);
        this.DeliveredAssetsCache.퓏(deliveredAsset.Id, deliveredAsset);
      }
      else
        deliveredAsset.퓏(obj0);
      Core.Instance.퓏(deliveredAsset);
    }
  }

  private void 퓏([In] MessageCloseDeliveredAsset obj0)
  {
    DeliveredAsset deliveredAsset;
    if (obj0 == null || !this.DeliveredAssetsCache.퓏(obj0.Id, out deliveredAsset))
      return;
    this.DeliveredAssetsCache.퓏(deliveredAsset.Id);
    Core.Instance.퓬(deliveredAsset);
  }

  private void 퓏([In] MessageAccountOperation obj0)
  {
    if (obj0 == null)
      return;
    AccountOperation accountOperation;
    if (!this.AccountOperationsCache.퓏(obj0.Name, out accountOperation))
      this.AccountOperationsCache.퓏(obj0.Name, accountOperation = new AccountOperation(this.픾핂));
    accountOperation.퓏(obj0);
  }

  private void 퓏([In] MessageNewsHeadline obj0)
  {
    int result;
    HashSet<Action<NewsArticle>> actionSet;
    if (obj0 == null || string.IsNullOrEmpty(obj0.SubscribeId) || !int.TryParse(obj0.SubscribeId, out result) || !this.NewsSubscribersCache.TryGetValue(result, out actionSet))
      return;
    foreach (Action<NewsArticle> action in actionSet)
    {
      NewsArticle newsArticle1 = new NewsArticle(this.픾핂);
      newsArticle1.퓏(obj0);
      NewsArticle newsArticle2 = newsArticle1;
      action(newsArticle2);
    }
  }

  private void 퓏([In] MessageTradingSignal obj0)
  {
    if (obj0 == null)
      return;
    TradingSignal tradingSignal;
    if (!this.TradingSignalsCache.퓏(obj0.Id, out tradingSignal))
    {
      tradingSignal = new TradingSignal(this.픾핂);
      tradingSignal.퓏(obj0);
      this.TradingSignalsCache.퓏(tradingSignal.Id, tradingSignal);
      Core.Instance.퓏(tradingSignal, EntityLifecycle.Created);
    }
    else
    {
      tradingSignal.퓏(obj0);
      Core.Instance.퓏(tradingSignal, EntityLifecycle.Changed);
    }
  }

  private void 퓏([In] MessageRemoveTradingSignal obj0)
  {
    TradingSignal tradingSignal;
    if (obj0 == null || !this.TradingSignalsCache.퓏(obj0.TradingSignalId, out tradingSignal))
      return;
    Core.Instance.퓏(tradingSignal, EntityLifecycle.Removed);
  }

  private void 퓏([In] CustomMessage obj0)
  {
    if (obj0 == null)
      return;
    obj0.ConnectionId = this.픾핂;
    Core.Instance.CustomMessageProcessor.퓏(obj0);
  }

  [CompilerGenerated]
  [SpecialName]
  internal void 퓏([In] Action<Message> obj0)
  {
    // ISSUE: reference to a compiler-generated field
    Action<Message> action = this.픾프;
    Action<Message> comparand;
    do
    {
      comparand = action;
      // ISSUE: reference to a compiler-generated field
      action = Interlocked.CompareExchange<Action<Message>>(ref this.픾프, comparand + obj0, comparand);
    }
    while (action != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  internal void 퓬([In] Action<Message> obj0)
  {
    // ISSUE: reference to a compiler-generated field
    Action<Message> action = this.픾프;
    Action<Message> comparand;
    do
    {
      comparand = action;
      // ISSUE: reference to a compiler-generated field
      action = Interlocked.CompareExchange<Action<Message>>(ref this.픾프, comparand - obj0, comparand);
    }
    while (action != comparand);
  }

  internal 핁<GetSymbolRequestParameters, Symbol> GetSymbolRequestCache { get; }

  internal 핁<SearchSymbolsRequestParameters, List<Symbol>> SearchSymbolsRequestCache { get; }

  internal 핁<GetFutureContractsRequestParameters, List<Symbol>> GetFutureContractsRequestCache { get; }

  internal 핁<GetOptionSeriesRequestParameters, List<OptionSerie>> GetOptionSeriesRequestCache { get; }

  internal 핁<GetStrikesRequestParameters, List<Symbol>> GetStrikesRequestCache { get; }
}
