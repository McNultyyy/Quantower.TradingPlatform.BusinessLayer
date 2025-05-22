// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.MarketOrderType
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System.Runtime.CompilerServices;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public class MarketOrderType(params TimeInForce[] allowedTimeInForce) : OrderType(allowedTimeInForce)
{
  public override string Id => \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁핃();

  public override string Name
  {
    get => loc.key(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁핃());
  }

  public override string Abbreviation
  {
    get => \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓚();
  }

  public override OrderTypeBehavior Behavior => OrderTypeBehavior.Market;

  protected override string GetPlaceConfirmMessage(
    PlaceOrderRequestParameters placeRequest,
    FormatSettings formatSettings)
  {
    string str = placeRequest.TimeInForce.Format(placeRequest.ExpirationTime);
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 6);
    interpolatedStringHandler.AppendFormatted<Side>(placeRequest.Side);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프());
    interpolatedStringHandler.AppendFormatted(this.Name);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픙());
    interpolatedStringHandler.AppendFormatted(str);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓼());
    interpolatedStringHandler.AppendFormatted(placeRequest.Symbol.FormatQuantity(placeRequest.Quantity, formatSettings.DisplayQuantityInLots));
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프());
    interpolatedStringHandler.AppendFormatted<Symbol>(placeRequest.Symbol);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프());
    interpolatedStringHandler.AppendFormatted(OrderType.GetSLTPComfirmMessage((OrderRequestParameters) placeRequest));
    return interpolatedStringHandler.ToStringAndClear() + (placeRequest.Account != null ? \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓭() + placeRequest.Account.GetCurrentName() : string.Empty);
  }

  protected override string GetModifyConfirmMessage(
    ModifyOrderRequestParameters modifyRequest,
    FormatSettings formatSettings)
  {
    string str = modifyRequest.TimeInForce.Format(modifyRequest.ExpirationTime);
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(27, 8);
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
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(27, 7);
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
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픗());
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓭());
    interpolatedStringHandler.AppendFormatted(order.Account.GetCurrentName());
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓝());
    return interpolatedStringHandler.ToStringAndClear();
  }

  public override ValidateResult ValidateOrderRequestParameters(OrderRequestParameters parameters)
  {
    ValidateResult validateResult = base.ValidateOrderRequestParameters(parameters);
    if (validateResult.State == ValidateState.NotValid)
      return validateResult;
    if (parameters.Side == Side.Buy)
    {
      double ask = parameters.Symbol.Ask;
      SlTpHolder stopLoss = parameters.StopLoss;
      if (stopLoss != null && stopLoss.PriceMeasurement == PriceMeasurement.Absolute && stopLoss.Price >= ask)
        return ValidateResult.NotValid(loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픃(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓎()));
      SlTpHolder takeProfit = parameters.TakeProfit;
      if (takeProfit != null && takeProfit.PriceMeasurement == PriceMeasurement.Absolute && takeProfit.Price <= ask)
        return ValidateResult.NotValid(loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗피(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓎()));
    }
    if (parameters.Side == Side.Sell)
    {
      double bid = parameters.Symbol.Bid;
      SlTpHolder stopLoss = parameters.StopLoss;
      if (stopLoss != null && stopLoss.PriceMeasurement == PriceMeasurement.Absolute && stopLoss.Price <= bid)
        return ValidateResult.NotValid(loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓸(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓎()));
      SlTpHolder takeProfit = parameters.TakeProfit;
      if (takeProfit != null && takeProfit.PriceMeasurement == PriceMeasurement.Absolute && takeProfit.Price >= bid)
        return ValidateResult.NotValid(loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓦(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓎()));
    }
    return ValidateResult.Valid;
  }

  public override double GetFillPrice(OrderRequestParameters parameters)
  {
    double fillPrice = double.NaN;
    if (parameters.Symbol != null)
      fillPrice = parameters.Side != Side.Buy ? parameters.Symbol.Bid : parameters.Symbol.Ask;
    return fillPrice;
  }
}
