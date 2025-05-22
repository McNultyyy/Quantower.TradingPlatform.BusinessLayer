// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.TrailingStopOrderType
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public class TrailingStopOrderType : OrderType
{
  public override string Id => \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픺();

  public override string Name
  {
    get => loc.key(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓲());
  }

  public override string Abbreviation
  {
    get => \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎핂();
  }

  public override OrderTypeBehavior Behavior => OrderTypeBehavior.TrailingStop;

  public TrailingStopOrderType(params TimeInForce[] allowedTimeInForce)
    : base(allowedTimeInForce)
  {
    this.Usage = OrderTypeUsage.All;
    this.SLTPPriceMeasurement = PriceMeasurement.Offset;
  }

  public override IList<SettingItem> GetOrderSettings(
    OrderRequestParameters parameters,
    FormatSettings formatSettings)
  {
    IList<SettingItem> orderSettings = base.GetOrderSettings(parameters, formatSettings);
    int num = 1;
    if (parameters.Type == RequestType.ModifyOrder)
      num = (int) parameters.TrailOffset;
    SettingItemInteger settingItemInteger = new SettingItemInteger(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픺(), num);
    settingItemInteger.Text = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픂(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픾());
    settingItemInteger.Minimum = 1;
    orderSettings.Add((SettingItem) settingItemInteger);
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
    interpolatedStringHandler.AppendFormatted(placeRequest.Symbol.FormatOffset(placeRequest.TrailOffset, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픹()));
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
    interpolatedStringHandler.AppendFormatted(modifyRequest.Symbol.FormatOffset(modifyRequest.TrailOffset, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픹()));
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
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(33, 9);
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
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픙());
    interpolatedStringHandler.AppendFormatted(order.Symbol.FormatOffset(order.TrailOffset, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픹()));
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓍());
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓭());
    interpolatedStringHandler.AppendFormatted(order.Account.GetCurrentName());
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓝());
    return interpolatedStringHandler.ToStringAndClear();
  }

  public override IList<DealTicketItem> GetDealTicketItems(OrderRequestParameters request)
  {
    IList<DealTicketItem> dealTicketItems = base.GetDealTicketItems(request);
    dealTicketItems.Add(new DealTicketItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픂(), (object) request.Symbol.FormatOffset(request.TrailOffset, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픹()), 5500));
    return dealTicketItems;
  }

  public override double GetFillPrice(OrderRequestParameters parameters)
  {
    double fillPrice = double.NaN;
    SettingItem itemByPath = parameters.AdditionalParameters.GetItemByPath(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픺());
    int ticks = itemByPath == null ? (int) parameters.TrailOffset : (int) itemByPath.Value;
    if (parameters.Symbol != null)
      fillPrice = parameters.Side != Side.Buy ? parameters.Symbol.CalculatePrice(parameters.Symbol.Bid, (double) -ticks) : parameters.Symbol.CalculatePrice(parameters.Symbol.Ask, (double) ticks);
    return fillPrice;
  }
}
