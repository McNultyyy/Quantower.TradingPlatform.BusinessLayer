// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.CustomOrderType
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public class CustomOrderType : OrderType
{
  private readonly string 핋픴;
  private readonly OrderTypeBehavior 핋픑;
  private readonly OrderType 핋픿;

  public override string Id
  {
    get
    {
      return !string.IsNullOrEmpty(this.핋픴) ? this.핋픴 : \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓫();
    }
  }

  public override string Name
  {
    get
    {
      return !string.IsNullOrEmpty(this.핋픴) ? this.핋픴 : this.핋픿?.Name ?? \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓫();
    }
  }

  public override string Abbreviation
  {
    get
    {
      return this.핋픿?.Abbreviation ?? \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗핌();
    }
  }

  public override OrderTypeBehavior Behavior
  {
    get
    {
      OrderType 핋픿 = this.핋픿;
      return 핋픿 == null ? this.핋픑 : 핋픿.Behavior;
    }
  }

  public override string PriceItemId => this.핋픿?.PriceItemId ?? base.PriceItemId;

  public CustomOrderType(string name, OrderTypeBehavior behavior, params TimeInForce[] allowedTifs)
    : this(name, new OrderTypeBehavior?(behavior), (OrderType) null, allowedTifs)
  {
  }

  public CustomOrderType(string name, OrderType baseOrderType)
    : this(name, baseOrderType?.Behavior, baseOrderType, baseOrderType?.AllowedTifs ?? new TimeInForce[1])
  {
  }

  public CustomOrderType(OrderType baseOrderType)
    : this(baseOrderType?.Name, baseOrderType?.Behavior, baseOrderType, baseOrderType?.AllowedTifs ?? new TimeInForce[1])
  {
  }

  private CustomOrderType(
    [In] string obj0,
    [In] OrderTypeBehavior? obj1,
    [In] OrderType obj2,
    params TimeInForce[] allowedTifs)
    : base(allowedTifs)
  {
    this.핋픴 = obj0;
    this.핋픑 = obj1.GetValueOrDefault();
    this.핋픿 = obj2;
  }

  public override IList<SettingItem> GetOrderSettings(
    OrderRequestParameters parameters,
    FormatSettings formatSettings)
  {
    return this.핋픿?.GetOrderSettings(parameters, formatSettings) ?? base.GetOrderSettings(parameters, formatSettings);
  }

  public override IList<DealTicketItem> GetDealTicketItems(OrderRequestParameters request)
  {
    return this.핋픿?.GetDealTicketItems(request) ?? base.GetDealTicketItems(request);
  }

  public override void SetDefaultPrices(SettingItem[] settings, OrderRequestParameters parameters)
  {
    if (this.핋픿 != null)
      this.핋픿.SetDefaultPrices(settings, parameters);
    else
      base.SetDefaultPrices(settings, parameters);
  }

  public override double GetFillPrice(OrderRequestParameters parameters)
  {
    OrderType 핋픿 = this.핋픿;
    return 핋픿 == null ? double.NaN : 핋픿.GetFillPrice(parameters);
  }

  protected override string GetPlaceConfirmMessage(
    PlaceOrderRequestParameters placeRequest,
    FormatSettings formatSettings)
  {
    return this.핋픿?.GetConfirmMessage((OrderRequestParameters) placeRequest, formatSettings);
  }

  protected override string GetModifyConfirmMessage(
    ModifyOrderRequestParameters modifyRequest,
    FormatSettings formatSettings)
  {
    return this.핋픿?.GetConfirmMessage((OrderRequestParameters) modifyRequest, formatSettings);
  }

  public override string GetCancelConfirmMessage(
    CancelOrderRequestParameters cancelRequest,
    FormatSettings formatSettings)
  {
    return this.핋픿?.GetCancelConfirmMessage(cancelRequest, formatSettings);
  }

  public override ValidateResult ValidateOrderRequestParameters(OrderRequestParameters parameters)
  {
    OrderType 핋픿 = this.핋픿;
    return 핋픿 == null ? base.ValidateOrderRequestParameters(parameters) : 핋픿.ValidateOrderRequestParameters(parameters);
  }
}
