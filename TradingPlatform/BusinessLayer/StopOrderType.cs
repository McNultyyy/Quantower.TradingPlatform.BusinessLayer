// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.StopOrderType
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public class StopOrderType : OrderType
{
  public override string Id => \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픛();

  public override string Name
  {
    get => loc.key(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픛());
  }

  public override string Abbreviation
  {
    get => \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픋();
  }

  public override OrderTypeBehavior Behavior => OrderTypeBehavior.Stop;

  public override string PriceItemId
  {
    get => \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓜();
  }

  public StopOrderType(params TimeInForce[] allowedTimeInForce)
    : base(allowedTimeInForce)
  {
    this.Usage = OrderTypeUsage.All;
  }

  public override IList<SettingItem> GetOrderSettings(
    OrderRequestParameters parameters,
    FormatSettings formatSettings)
  {
    IList<SettingItem> orderSettings = base.GetOrderSettings(parameters, formatSettings);
    double num1 = 0.0;
    double num2 = 1E-05;
    int num3 = 5;
    Symbol symbol = parameters.Symbol;
    bool flag = true;
    if (symbol != null)
    {
      if (parameters.Type == RequestType.PlaceOrder)
        num1 = CoreMath.ProcessNaN(parameters.Side == Side.Buy ? symbol.Bid : symbol.Ask);
      else if (parameters.Type == RequestType.ModifyOrder)
      {
        num1 = parameters.TriggerPrice;
        if (double.IsNaN(num1))
          num1 = parameters.Price;
        flag = Core.Instance.RulesManager.IsAllowed(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁(), parameters.Account, parameters.Symbol, (OrderType) this).Status == TradingOperationStatus.Allowed;
      }
      VariableTick variableTick = symbol.FindVariableTick(num1) ?? symbol.VariableTickList.FirstOrDefault<VariableTick>();
      num2 = variableTick.TickSize;
      num3 = variableTick.Precision;
    }
    SettingItemDouble settingItemDouble = new SettingItemDouble(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓜(), num1);
    settingItemDouble.Text = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗핀(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픲());
    settingItemDouble.SortIndex = 0;
    settingItemDouble.Minimum = num2;
    settingItemDouble.Maximum = (double) int.MaxValue;
    settingItemDouble.Increment = num2;
    settingItemDouble.DecimalPlaces = num3;
    settingItemDouble.Enabled = flag;
    orderSettings.Add((SettingItem) settingItemDouble);
    return orderSettings;
  }

  protected override string GetPlaceConfirmMessage(
    PlaceOrderRequestParameters placeRequest,
    FormatSettings formatSettings)
  {
    string str = placeRequest.TimeInForce.Format(placeRequest.ExpirationTime);
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 8);
    interpolatedStringHandler.AppendFormatted<Side>(placeRequest.Side);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프());
    interpolatedStringHandler.AppendFormatted(this.Name);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픙());
    interpolatedStringHandler.AppendFormatted(str);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓼());
    interpolatedStringHandler.AppendFormatted(placeRequest.Symbol.FormatQuantity(placeRequest.Quantity, formatSettings.DisplayQuantityInLots));
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프());
    interpolatedStringHandler.AppendFormatted<Symbol>(placeRequest.Symbol);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓴());
    interpolatedStringHandler.AppendFormatted(placeRequest.Symbol.FormatPrice(placeRequest.TriggerPrice));
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프());
    interpolatedStringHandler.AppendFormatted(OrderType.GetSLTPComfirmMessage((OrderRequestParameters) placeRequest));
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓭());
    interpolatedStringHandler.AppendFormatted(placeRequest.Account.GetCurrentName());
    return interpolatedStringHandler.ToStringAndClear();
  }

  protected override string GetModifyConfirmMessage(
    ModifyOrderRequestParameters modifyRequest,
    FormatSettings formatSettings)
  {
    string str = modifyRequest.TimeInForce.Format(modifyRequest.ExpirationTime);
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(31 /*0x1F*/, 9);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픹());
    interpolatedStringHandler.AppendFormatted(modifyRequest.OrderId);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픆());
    interpolatedStringHandler.AppendFormatted<Side>(modifyRequest.Side);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프());
    interpolatedStringHandler.AppendFormatted(this.Name);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픙());
    interpolatedStringHandler.AppendFormatted(str);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓼());
    interpolatedStringHandler.AppendFormatted(modifyRequest.Symbol.FormatQuantity(modifyRequest.Quantity, formatSettings.DisplayQuantityInLots));
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프());
    interpolatedStringHandler.AppendFormatted<Symbol>(modifyRequest.Symbol);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓴());
    interpolatedStringHandler.AppendFormatted(modifyRequest.Symbol.FormatPrice(modifyRequest.TriggerPrice));
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프());
    interpolatedStringHandler.AppendFormatted(OrderType.GetSLTPComfirmMessage((OrderRequestParameters) modifyRequest));
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓭());
    interpolatedStringHandler.AppendFormatted(modifyRequest.Account.GetCurrentName());
    return interpolatedStringHandler.ToStringAndClear();
  }

  public override string GetCancelConfirmMessage(
    CancelOrderRequestParameters cancelRequest,
    FormatSettings formatSettings)
  {
    IOrder order = cancelRequest?.Order;
    if (order == null)
      return string.Empty;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(31 /*0x1F*/, 8);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙핊());
    interpolatedStringHandler.AppendFormatted(order.Id);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓓());
    interpolatedStringHandler.AppendFormatted<Side>(order.Side);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프());
    interpolatedStringHandler.AppendFormatted(this.Format(order.PositionId, order.GroupId));
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픙());
    interpolatedStringHandler.AppendFormatted<TimeInForce>(order.TimeInForce);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓼());
    interpolatedStringHandler.AppendFormatted(order.Symbol.FormatQuantity(order.TotalQuantity, formatSettings.DisplayQuantityInLots));
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프());
    interpolatedStringHandler.AppendFormatted(order.Symbol.Name);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓴());
    interpolatedStringHandler.AppendFormatted(order.Symbol.FormatPrice(order.TriggerPrice));
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픗());
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓭());
    interpolatedStringHandler.AppendFormatted(cancelRequest.Order.Account.GetCurrentName());
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓝());
    return interpolatedStringHandler.ToStringAndClear();
  }

  public override ValidateResult ValidateOrderRequestParameters(OrderRequestParameters parameters)
  {
    ValidateResult validateResult = base.ValidateOrderRequestParameters(parameters);
    if (validateResult.State == ValidateState.NotValid)
      return validateResult;
    double triggerPrice = parameters.TriggerPrice;
    if (parameters.Side == Side.Buy)
    {
      SlTpHolder stopLoss = parameters.StopLoss;
      if (stopLoss != null && stopLoss.PriceMeasurement == PriceMeasurement.Absolute && stopLoss.Price >= triggerPrice)
        return ValidateResult.NotValid(loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픽(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픲()));
      SlTpHolder takeProfit = parameters.TakeProfit;
      if (takeProfit != null && takeProfit.PriceMeasurement == PriceMeasurement.Absolute && takeProfit.Price <= triggerPrice)
        return ValidateResult.NotValid(loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓏(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픲()));
    }
    if (parameters.Side == Side.Sell)
    {
      SlTpHolder stopLoss = parameters.StopLoss;
      if (stopLoss != null && stopLoss.PriceMeasurement == PriceMeasurement.Absolute && stopLoss.Price <= triggerPrice)
        return ValidateResult.NotValid(loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓬(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픲()));
      SlTpHolder takeProfit = parameters.TakeProfit;
      if (takeProfit != null && takeProfit.PriceMeasurement == PriceMeasurement.Absolute && takeProfit.Price >= triggerPrice)
        return ValidateResult.NotValid(loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎핇(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픲()));
    }
    return ValidateResult.Valid;
  }

  public override IList<DealTicketItem> GetDealTicketItems(OrderRequestParameters request)
  {
    IList<DealTicketItem> dealTicketItems = base.GetDealTicketItems(request);
    dealTicketItems.Add(new DealTicketItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗핀(), (object) request.Symbol.FormatPrice(request.TriggerPrice), 5500));
    return dealTicketItems;
  }

  public override double GetFillPrice(OrderRequestParameters parameters)
  {
    SettingItem itemByPath = parameters.AdditionalParameters.GetItemByPath(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓜());
    return itemByPath == null ? parameters.TriggerPrice : (double) itemByPath.Value;
  }

  public override void SetDefaultPrices(SettingItem[] settings, OrderRequestParameters parameters)
  {
    if (parameters.Symbol == null)
      return;
    double num = parameters.Side == Side.Buy ? parameters.Symbol.Bid : parameters.Symbol.Ask;
    if (double.IsNaN(num))
      return;
    ((IEnumerable<SettingItem>) settings).UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓜(), (object) num);
  }
}
