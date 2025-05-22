// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.OrderType
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
using TradingPlatform.BusinessLayer.LocalOrders;
using TradingPlatform.BusinessLayer.Utils;
using TradingPlatform.BusinessLayer.Utils.Comparers;
using 퓏;

#nullable enable
namespace TradingPlatform.BusinessLayer;

public abstract class OrderType : BusinessObject, IComparable, 퓏.픾, IEquatable<
#nullable disable
OrderType>
{
  public const string Market = "Market";
  public const string Limit = "Limit";
  public const string Stop = "Stop";
  public const string TrailingStop = "Tr.stop";
  public const string StopLimit = "StopLimit";
  public const string MarketIfTouched = "MarketIfTouched";
  public const string LimitIfTouched = "LimitIfTouched";
  public const string Custom = "Custom";
  public const string TIME_IF_FORCE = "Time in force";
  public const string EXPIRATION = "Expiration";
  public const string SIDE = "Side";
  public const string QUANTITY = "Quantity";
  public const string PRICE = "Price";
  public const string TRIGGER_PRICE = "TriggerPrice";
  public const string TRAIL_OFFSET = "TrailOffset";
  public const string COMMENT = "Comment";
  public const string TOTAL = "Total";
  public const string BALANCE_PERCENT = "Balance percent";
  public const string RISK = "Risk";
  public const string RISK_PERCENT = "Risk percent";
  public const string REDUCE_ONLY = "Reduce-Only";
  public const string POST_ONLY = "Post-Only";
  public const string PARENT_ORDER_ID = "Parent Order ID";
  public const int BALANCE_PERCENT_STEPS_COUNT_MULTIPLIER = 100;
  private readonly 핅<string, Rule> 픎핋;

  public abstract string Id { get; }

  public virtual string Name => this.Id;

  public abstract string Abbreviation { get; }

  public virtual OrderTypeBehavior Behavior => OrderTypeBehavior.Unspecified;

  public OrderTypeUsage Usage { get; init; }

  public TimeInForce[] AllowedTifs { get; init; }

  public PriceMeasurement SLTPPriceMeasurement { get; init; }

  public BalanceCalculatorFactory BalanceCalculatorFactory { get; init; }

  public virtual string PriceItemId => (string) null;

  int 퓏.픾.TradingPlatform\u002EBusinessLayer\u002EIRulesContainer\u002EPriorityIndex => 30;

  핅<string, Rule> 퓏.픾.TradingPlatform\u002EBusinessLayer\u002EIRulesContainer\u002ERules => this.픎핋;

  protected OrderType(params TimeInForce[] allowedTimeInForce)
    : base(string.Empty)
  {
    if (allowedTimeInForce.Length == 0)
      allowedTimeInForce = Enum.GetValues(typeof (TimeInForce)).Cast<TimeInForce>().ToArray<TimeInForce>();
    this.AllowedTifs = allowedTimeInForce;
    this.Usage = OrderTypeUsage.Order;
    this.SLTPPriceMeasurement = PriceMeasurement.Absolute;
    this.픎핋 = new 핅<string, Rule>();
    Core.Instance.RulesManager.Defaults.ForEach((Action<Rule>) (([In] obj0) => this.픎핋.퓏(obj0.Name, obj0)));
  }

  public virtual IList<SettingItem> GetOrderSettings(
    OrderRequestParameters parameters,
    FormatSettings formatSettings)
  {
    List<SettingItem> orderSettings = new List<SettingItem>();
    this.퓏((ICollection<SettingItem>) orderSettings, parameters, -100, parameters.Type == RequestType.ModifyOrder ? new TimeInForce?(parameters.TimeInForce) : new TimeInForce?());
    this.퓏((ICollection<SettingItem>) orderSettings, parameters, -90, new DateTime?());
    this.퓏((ICollection<SettingItem>) orderSettings, parameters, -80, parameters.Type == RequestType.ModifyOrder ? VisibilityMode.Hidden : VisibilityMode.Visible);
    this.퓏((ICollection<SettingItem>) orderSettings, parameters, formatSettings.DisplayQuantityInLots, -70, parameters.Type == RequestType.ModifyOrder ? new double?(parameters.Quantity) : new double?());
    if (this.BalanceCalculatorFactory != null)
    {
      if (this.BalanceCalculatorFactory(parameters.Symbol, parameters.Account) is CryptoBalanceCalculator)
      {
        this.퓏((ICollection<SettingItem>) orderSettings, -60);
        this.퓬((ICollection<SettingItem>) orderSettings, -50);
      }
      this.퓏((ICollection<SettingItem>) orderSettings, parameters.Symbol?.QuotingCurrency, -40);
      this.핇((ICollection<SettingItem>) orderSettings, -30);
    }
    return (IList<SettingItem>) orderSettings;
  }

  public abstract double GetFillPrice(OrderRequestParameters parameters);

  public virtual void SetDefaultPrices(SettingItem[] settings, OrderRequestParameters parameters)
  {
  }

  public virtual string GetConfirmMessage(
    OrderRequestParameters parameters,
    FormatSettings formatSettings)
  {
    string str = string.Empty;
    switch (parameters)
    {
      case PlaceOrderRequestParameters placeRequest:
        str = this.GetPlaceConfirmMessage(placeRequest, formatSettings);
        break;
      case ModifyOrderRequestParameters modifyRequest:
        str = this.GetModifyConfirmMessage(modifyRequest, formatSettings);
        break;
    }
    string partConfirmMessage = this.GetAdditionalPartConfirmMessage(parameters, formatSettings);
    return string.IsNullOrEmpty(partConfirmMessage) ? str + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓝() : str + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓓() + partConfirmMessage + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓶();
  }

  protected abstract string GetPlaceConfirmMessage(
    PlaceOrderRequestParameters placeRequest,
    FormatSettings formatSettings);

  protected abstract string GetModifyConfirmMessage(
    ModifyOrderRequestParameters modifyRequest,
    FormatSettings formatSettings);

  protected virtual string GetAdditionalPartConfirmMessage(
    OrderRequestParameters parameters,
    FormatSettings formatSettings)
  {
    return (string) null;
  }

  public abstract string GetCancelConfirmMessage(
    CancelOrderRequestParameters cancelRequest,
    FormatSettings formatSettings);

  public virtual ValidateResult ValidateOrderRequestParameters(OrderRequestParameters parameters)
  {
    if (!((IEnumerable<TimeInForce>) this.AllowedTifs).Contains<TimeInForce>(parameters.TimeInForce))
      return ValidateResult.NotValid(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓽() + this.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픘());
    if (parameters.StopLossItems != null)
    {
      foreach (SlTpHolder stopLossItem in parameters.StopLossItems)
      {
        if (stopLossItem.PriceMeasurement != PriceMeasurement.Absolute && stopLossItem.PriceMeasurement != this.SLTPPriceMeasurement)
        {
          DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(120, 2);
          interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픨());
          interpolatedStringHandler.AppendFormatted<PriceMeasurement>(this.SLTPPriceMeasurement);
          interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓪());
          interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픪());
          interpolatedStringHandler.AppendFormatted<PriceMeasurement>(stopLossItem.PriceMeasurement);
          interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓡());
          return ValidateResult.NotValid(interpolatedStringHandler.ToStringAndClear());
        }
      }
    }
    if (parameters.TakeProfitItems != null)
    {
      foreach (SlTpHolder takeProfitItem in parameters.TakeProfitItems)
      {
        if (takeProfitItem.PriceMeasurement != PriceMeasurement.Absolute && takeProfitItem.PriceMeasurement != this.SLTPPriceMeasurement)
        {
          DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(120, 2);
          interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픨());
          interpolatedStringHandler.AppendFormatted<PriceMeasurement>(this.SLTPPriceMeasurement);
          interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓪());
          interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픪());
          interpolatedStringHandler.AppendFormatted<PriceMeasurement>(takeProfitItem.PriceMeasurement);
          interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓡());
          return ValidateResult.NotValid(interpolatedStringHandler.ToStringAndClear());
        }
      }
    }
    return ValidateResult.Valid;
  }

  public virtual IList<DealTicketItem> GetDealTicketItems(OrderRequestParameters request)
  {
    List<DealTicketItem> dealTicketItems = new List<DealTicketItem>();
    dealTicketItems.Add(new DealTicketItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓓(), (object) request.Symbol.Connection?.Name));
    dealTicketItems.Add(new DealTicketItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픟(), (object) request.Symbol.Name, 1000));
    string property = Core.Instance.CustomAccountPropertiesProvider.GetProperty(request.Account, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픡()) as string;
    dealTicketItems.Add(new DealTicketItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픆(), string.IsNullOrEmpty(property) ? (object) request.Account.Name : (object) (request.Account.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓓() + property + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픗()), 2000));
    dealTicketItems.Add(new DealTicketItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓢(), (object) request.Symbol.FormatQuantity(request.Quantity), 3000));
    if (request.Type == RequestType.ModifyOrder && request is ModifyOrderRequestParameters requestParameters)
      dealTicketItems.Add(new DealTicketItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픗(), (object) requestParameters.OrderId, 3500));
    dealTicketItems.Add(new DealTicketItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇핈(), (object) request.Side.ToString(), 4000));
    dealTicketItems.Add(new DealTicketItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓰(), (object) this.Format(request.PositionId, request.GroupId), 5000));
    dealTicketItems.Add(new DealTicketItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픧(), (object) request.TimeInForce.Format(request.ExpirationTime), 6000));
    DefaultInterpolatedStringHandler interpolatedStringHandler;
    if (request.StopLossItems != null && request.StopLossItems.Count > 1)
    {
      for (int index = 0; index < request.StopLossItems.Count; ++index)
      {
        List<DealTicketItem> dealTicketItemList = dealTicketItems;
        string stringAndClear;
        if (!request.StopLoss.IsTrailing)
        {
          interpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 1);
          interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓹());
          interpolatedStringHandler.AppendFormatted<int>(index + 1);
          interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픷());
          stringAndClear = interpolatedStringHandler.ToStringAndClear();
        }
        else
        {
          interpolatedStringHandler = new DefaultInterpolatedStringHandler(16 /*0x10*/, 1);
          interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓛());
          interpolatedStringHandler.AppendFormatted<int>(index + 1);
          interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픷());
          stringAndClear = interpolatedStringHandler.ToStringAndClear();
        }
        string str = request.StopLossItems[index].Format(request.Symbol);
        int sortIndex = 6500 + index;
        DealTicketItem dealTicketItem = new DealTicketItem(stringAndClear, (object) str, sortIndex);
        dealTicketItemList.Add(dealTicketItem);
      }
    }
    else if (request.StopLoss != null)
      dealTicketItems.Add(new DealTicketItem(request.StopLoss.IsTrailing ? \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픻() : \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픝(), (object) request.StopLoss.Format(request.Symbol), 6500));
    if (request.TakeProfitItems != null && request.TakeProfitItems.Count > 1)
    {
      for (int index = 0; index < request.TakeProfitItems.Count; ++index)
      {
        List<DealTicketItem> dealTicketItemList = dealTicketItems;
        interpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 1);
        interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓤());
        interpolatedStringHandler.AppendFormatted<int>(index + 1);
        interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픷());
        DealTicketItem dealTicketItem = new DealTicketItem(interpolatedStringHandler.ToStringAndClear(), (object) request.TakeProfitItems[index].Format(request.Symbol), 6510 + index);
        dealTicketItemList.Add(dealTicketItem);
      }
    }
    else if (request.TakeProfit != null)
      dealTicketItems.Add(new DealTicketItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픮(), (object) request.TakeProfit.Format(request.Symbol), 6510));
    dealTicketItems.Add(new DealTicketItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픉(), (object) Core.Instance.TimeUtils.DateTimeUtcNow.ToString(), 7000));
    if (!string.IsNullOrEmpty(request.Comment))
      dealTicketItems.Add(new DealTicketItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픤(), (object) request.Comment, 8000));
    if (!string.IsNullOrEmpty(request.SendingSource))
      dealTicketItems.Add(new DealTicketItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픒(), (object) request.SendingSource, 9000));
    return (IList<DealTicketItem>) dealTicketItems;
  }

  private void 퓏(
    [In] ICollection<SettingItem> obj0_1,
    [In] OrderRequestParameters obj1,
    [In] int obj2,
    TimeInForce? _param4 = null)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    OrderType.핇 핇 = new OrderType.핇();
    // ISSUE: reference to a compiler-generated field
    핇.핋퓶 = _param4;
    List<TimeInForce> source;
    if (obj1 == null)
    {
      source = (List<TimeInForce>) null;
    }
    else
    {
      OrderType orderType = obj1.OrderType;
      if (orderType == null)
      {
        source = (List<TimeInForce>) null;
      }
      else
      {
        TimeInForce[] allowedTifs = orderType.AllowedTifs;
        source = allowedTifs != null ? ((IEnumerable<TimeInForce>) allowedTifs).ToList<TimeInForce>() : (List<TimeInForce>) null;
      }
    }
    if (source == null)
    {
      if (obj1 == null)
      {
        source = (List<TimeInForce>) null;
      }
      else
      {
        Symbol symbol = obj1.Symbol;
        if (symbol == null)
        {
          source = (List<TimeInForce>) null;
        }
        else
        {
          List<OrderType> alowedOrderTypes = symbol.GetAlowedOrderTypes(new OrderTypeUsage?(OrderTypeUsage.Order));
          source = alowedOrderTypes != null ? alowedOrderTypes.SelectMany<OrderType, TimeInForce>((Func<OrderType, IEnumerable<TimeInForce>>) (([In] obj0_2) => (IEnumerable<TimeInForce>) obj0_2.AllowedTifs)).Distinct<TimeInForce>().ToList<TimeInForce>() : (List<TimeInForce>) null;
        }
      }
    }
    source?.Sort((IComparer<TimeInForce>) new TimeInForceComparer());
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    List<SelectItem> list = source != null ? source.Select<TimeInForce, SelectItem>(OrderType.퓏.핋퓔 ?? (OrderType.퓏.핋퓔 = new Func<TimeInForce, SelectItem>(OrderType.퓏))).ToList<SelectItem>() : (List<SelectItem>) null;
    if (list == null || !list.Any<SelectItem>())
      return;
    // ISSUE: reference to a compiler-generated method
    SelectItem selectItem = list.FirstOrDefault<SelectItem>(new Func<SelectItem, bool>(핇.퓏));
    ICollection<SettingItem> settingItems = obj0_1;
    SettingItemSelectorLocalized selectorLocalized = new SettingItemSelectorLocalized(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓷(), selectItem, list, obj2);
    selectorLocalized.Text = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓷(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓿());
    settingItems.Add((SettingItem) selectorLocalized);
  }

  private void 퓏(
    [In] ICollection<SettingItem> obj0,
    [In] OrderRequestParameters obj1,
    [In] int obj2,
    DateTime? _param4 = null)
  {
    TimeInForce[] allowedTifs = obj1?.OrderType?.AllowedTifs;
    if (allowedTifs == null || !((IEnumerable<TimeInForce>) allowedTifs).Contains<TimeInForce>(TimeInForce.GTD) && !((IEnumerable<TimeInForce>) allowedTifs).Contains<TimeInForce>(TimeInForce.GTT))
      return;
    DateTime selectedTimeZone = Core.Instance.TimeUtils.DateTimeUtcNow.ToSelectedTimeZone();
    DateTime dateTime1 = _param4 ?? selectedTimeZone.AddDays(1.0);
    ICollection<SettingItem> settingItems = obj0;
    SettingItemDateTime settingItemDateTime1 = new SettingItemDateTime(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픟(), dateTime1, obj2);
    settingItemDateTime1.Text = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픟(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓿());
    settingItemDateTime1.MinDate = selectedTimeZone;
    SettingItemDateTime settingItemDateTime2 = settingItemDateTime1;
    Symbol symbol = obj1.Symbol;
    DateTime dateTime2 = symbol != null ? symbol.ExpirationDate : DateTime.MaxValue;
    settingItemDateTime2.MaxDate = dateTime2;
    settingItemDateTime1.Relation = (SettingItemRelation) new 퓏.픘(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓷(), new object[2]
    {
      (object) OrderType.퓏(TimeInForce.GTD),
      (object) OrderType.퓏(TimeInForce.GTT)
    });
    SettingItemDateTime settingItemDateTime3 = settingItemDateTime1;
    settingItems.Add((SettingItem) settingItemDateTime3);
  }

  private void 퓏(
    [In] ICollection<SettingItem> obj0,
    [In] OrderRequestParameters obj1,
    [In] int obj2,
    VisibilityMode _param4 = VisibilityMode.Visible)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    OrderType.퓲 퓲 = new OrderType.퓲();
    // ISSUE: reference to a compiler-generated field
    퓲.핋퓽 = obj1;
    List<SelectItem> selectItemList = new List<SelectItem>()
    {
      new SelectItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓧(), 0),
      new SelectItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픰(), 1)
    };
    SelectItem selectItem = selectItemList.First<SelectItem>();
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    if (퓲.핋퓽 != null && 퓲.핋퓽.Type == RequestType.ModifyOrder)
    {
      // ISSUE: reference to a compiler-generated method
      selectItem = selectItemList.FirstOrDefault<SelectItem>(new Func<SelectItem, bool>(퓲.퓏));
    }
    ICollection<SettingItem> settingItems = obj0;
    SettingItemRadioLocalized itemRadioLocalized = new SettingItemRadioLocalized(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇핈(), selectItem, selectItemList, obj2);
    itemRadioLocalized.Text = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇핈(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓿());
    itemRadioLocalized.VisibilityMode = _param4;
    settingItems.Add((SettingItem) itemRadioLocalized);
  }

  private void 퓏(
    [In] ICollection<SettingItem> obj0,
    [In] OrderRequestParameters obj1,
    [In] bool obj2,
    [In] int obj3,
    double? _param5 = null)
  {
    double num1 = 0.0;
    double num2 = 0.0;
    double num3 = 1.0;
    int num4 = 1;
    double num5 = 1.0;
    string str = (string) null;
    if (obj1 != null)
    {
      BusinessObjectState? state = obj1.Symbol?.State;
      BusinessObjectState businessObjectState = BusinessObjectState.Normal;
      if (state.GetValueOrDefault() == businessObjectState & state.HasValue)
      {
        double num6 = obj2 ? 1.0 : obj1.Symbol.LotSize;
        num1 = obj1.Symbol.MinLot * num6;
        num2 = obj1.Symbol.MaxLot * num6;
        num3 = obj2 ? obj1.Symbol.LotStep : obj1.Symbol.NotionalValueStep;
        num4 = CoreMath.GetValuePrecision((Decimal) num3);
        double? nullable = _param5;
        double num7 = num6;
        num5 = (nullable.HasValue ? new double?(nullable.GetValueOrDefault() * num7) : new double?()) ?? num1;
        str = obj1.Symbol.Product?.Name;
      }
    }
    if (obj2)
      str = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓢(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓿());
    ICollection<SettingItem> settingItems = obj0;
    SettingItemDouble settingItemDouble = new SettingItemDouble(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓢(), num5, obj3);
    settingItemDouble.Text = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓢(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓿());
    settingItemDouble.Minimum = num1;
    settingItemDouble.Maximum = num2;
    settingItemDouble.Increment = num3;
    settingItemDouble.DecimalPlaces = num4;
    settingItemDouble.UseTradingNumeric = true;
    settingItemDouble.Dimension = str;
    settingItems.Add((SettingItem) settingItemDouble);
  }

  private void 퓏([In] ICollection<SettingItem> obj0, [In] int obj1)
  {
    double num1 = 1.0;
    int num2 = 0;
    double maxValue = double.MaxValue;
    string empty = string.Empty;
    ICollection<SettingItem> settingItems = obj0;
    SettingItemDoubleWithLink itemDoubleWithLink = new SettingItemDoubleWithLink(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓔(), num1, (Action<object>) null, obj1);
    itemDoubleWithLink.Text = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓔(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓿());
    itemDoubleWithLink.Minimum = num1;
    itemDoubleWithLink.Maximum = maxValue;
    itemDoubleWithLink.Increment = num1;
    itemDoubleWithLink.DecimalPlaces = num2;
    itemDoubleWithLink.UseTradingNumeric = true;
    itemDoubleWithLink.Dimension = empty;
    settingItems.Add((SettingItem) itemDoubleWithLink);
  }

  private void 퓬([In] ICollection<SettingItem> obj0, [In] int obj1)
  {
    obj0.Add((SettingItem) new SettingItemSlider(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픢(), 0UL, obj1)
    {
      StepsCount = 10000UL
    });
  }

  private void 퓏([In] ICollection<SettingItem> obj0, [In] Asset obj1, [In] int obj2)
  {
    ICollection<SettingItem> settingItems = obj0;
    SettingItemDouble settingItemDouble = new SettingItemDouble(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픫(), 0.01, obj2);
    settingItemDouble.Text = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픫(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓿());
    settingItemDouble.Minimum = 0.01;
    settingItemDouble.Maximum = double.MaxValue;
    settingItemDouble.Increment = 0.01;
    settingItemDouble.DecimalPlaces = 2;
    settingItemDouble.UseTradingNumeric = true;
    settingItemDouble.Dimension = obj1?.Name;
    settingItems.Add((SettingItem) settingItemDouble);
  }

  private void 핇([In] ICollection<SettingItem> obj0, [In] int obj1)
  {
    ICollection<SettingItem> settingItems = obj0;
    SettingItemDouble settingItemDouble = new SettingItemDouble(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픯(), 0.1, obj1);
    settingItemDouble.Text = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픯(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓿());
    settingItemDouble.Minimum = 0.1;
    settingItemDouble.Maximum = double.MaxValue;
    settingItemDouble.Increment = 0.1;
    settingItemDouble.DecimalPlaces = 1;
    settingItemDouble.UseTradingNumeric = true;
    settingItemDouble.Dimension = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓾();
    settingItems.Add((SettingItem) settingItemDouble);
  }

  private static SelectItem 퓏([In] TimeInForce obj0)
  {
    return new SelectItem(obj0.GetDescription(), (int) obj0);
  }

  public int CompareTo(object obj) => this.Id.CompareTo((obj as OrderType).Id);

  public static string GetSLTPComfirmMessage(OrderRequestParameters requestParameters)
  {
    string sltpComfirmMessage = string.Empty;
    try
    {
      bool flag = requestParameters.StopLossItems.Count > 1 || requestParameters.TakeProfitItems.Count > 1;
      int num;
      DefaultInterpolatedStringHandler interpolatedStringHandler;
      if (requestParameters.StopLoss != null)
      {
        for (int index = 0; index < requestParameters.StopLossItems.Count; ++index)
        {
          SlTpHolder stopLossItem = requestParameters.StopLossItems[index];
          string str1 = stopLossItem.Format(requestParameters.Symbol);
          string empty;
          if (!flag)
          {
            empty = string.Empty;
          }
          else
          {
            num = index + 1;
            empty = num.ToString();
          }
          string str2 = empty;
          string str3 = flag ? \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓐() + requestParameters.Symbol.FormatQuantity(stopLossItem.Quantity) : string.Empty;
          if (stopLossItem.IsTrailing)
          {
            sltpComfirmMessage = sltpComfirmMessage + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픚() + str1;
          }
          else
          {
            string str4 = sltpComfirmMessage;
            string stringAndClear;
            if (stopLossItem.PriceMeasurement != PriceMeasurement.Absolute)
            {
              interpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 3);
              interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓵());
              interpolatedStringHandler.AppendFormatted(str2);
              interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣플());
              interpolatedStringHandler.AppendFormatted(str1);
              interpolatedStringHandler.AppendFormatted(str3);
              stringAndClear = interpolatedStringHandler.ToStringAndClear();
            }
            else
            {
              interpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 3);
              interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓵());
              interpolatedStringHandler.AppendFormatted(str2);
              interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픥());
              interpolatedStringHandler.AppendFormatted(str1);
              interpolatedStringHandler.AppendFormatted(str3);
              stringAndClear = interpolatedStringHandler.ToStringAndClear();
            }
            sltpComfirmMessage = str4 + stringAndClear;
          }
          if (index != requestParameters.StopLossItems.Count - 1)
            sltpComfirmMessage += \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픆();
        }
      }
      if (requestParameters.TakeProfit != null)
      {
        if (!string.IsNullOrEmpty(sltpComfirmMessage))
          sltpComfirmMessage += \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픆();
        for (int index = 0; index < requestParameters.TakeProfitItems.Count; ++index)
        {
          SlTpHolder takeProfitItem = requestParameters.TakeProfitItems[index];
          string str5 = takeProfitItem.Format(requestParameters.Symbol);
          string empty;
          if (!flag)
          {
            empty = string.Empty;
          }
          else
          {
            num = index + 1;
            empty = num.ToString();
          }
          string str6 = empty;
          string str7 = flag ? \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓐() + requestParameters.Symbol.FormatQuantity(takeProfitItem.Quantity) : string.Empty;
          string str8 = sltpComfirmMessage;
          string str9 = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프();
          string stringAndClear;
          if (takeProfitItem.PriceMeasurement != PriceMeasurement.Absolute)
          {
            interpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 3);
            interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍필());
            interpolatedStringHandler.AppendFormatted(str6);
            interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓼());
            interpolatedStringHandler.AppendFormatted(str5);
            interpolatedStringHandler.AppendFormatted(str7);
            stringAndClear = interpolatedStringHandler.ToStringAndClear();
          }
          else
          {
            interpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 3);
            interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓴());
            interpolatedStringHandler.AppendFormatted(str6);
            interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픳());
            interpolatedStringHandler.AppendFormatted(str5);
            interpolatedStringHandler.AppendFormatted(str7);
            stringAndClear = interpolatedStringHandler.ToStringAndClear();
          }
          sltpComfirmMessage = str8 + str9 + stringAndClear;
          if (index != requestParameters.TakeProfitItems.Count - 1)
            sltpComfirmMessage += \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픆();
        }
      }
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
    return sltpComfirmMessage;
  }

  public string Format(string positionId = null, string groupId = null)
  {
    if (!string.IsNullOrEmpty(positionId))
    {
      string str1;
      switch (this.Behavior)
      {
        case OrderTypeBehavior.Limit:
          str1 = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍필();
          break;
        case OrderTypeBehavior.Stop:
          str1 = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픩();
          break;
        case OrderTypeBehavior.TrailingStop:
          str1 = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픺();
          break;
        default:
          str1 = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓥();
          break;
      }
      string str2 = str1;
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 3);
      interpolatedStringHandler.AppendFormatted(this.Name);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픙());
      interpolatedStringHandler.AppendFormatted(str2);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓭());
      interpolatedStringHandler.AppendFormatted(positionId);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픗());
      return interpolatedStringHandler.ToStringAndClear();
    }
    return !string.IsNullOrEmpty(groupId) ? this.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓣() : this.Name;
  }

  public static string Format(IOrder order)
  {
    return order is LocalOrder ? order.OrderType.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픦() : OrderType.Format(order.OrderTypeId, order.ConnectionId, order.PositionId, order.GroupId);
  }

  public static string Format(
    string orderTypeId,
    string connectionId = null,
    string positionId = null,
    string groupId = null)
  {
    return Core.Instance.GetOrderType(orderTypeId, connectionId)?.Format(positionId, groupId) ?? orderTypeId;
  }

  public bool Equals(OrderType other)
  {
    if (other == null)
      return false;
    if (this == other)
      return true;
    return this.Id == other.Id && this.ConnectionId == other.ConnectionId;
  }

  public override bool Equals(object obj)
  {
    if (obj == null)
      return false;
    if (this == obj)
      return true;
    return !(obj.GetType() != this.GetType()) && this.Equals((OrderType) obj);
  }

  public override int GetHashCode() => HashCode.Combine<string, string>(this.Id, this.ConnectionId);
}
