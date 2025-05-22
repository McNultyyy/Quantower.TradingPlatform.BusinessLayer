// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.OrderRequestParametersExtensions
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
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public static class OrderRequestParametersExtensions
{
  public static double GetExecutionPrice(this OrderRequestParameters parameters)
  {
    int num;
    if (parameters == null)
    {
      num = 1;
    }
    else
    {
      OrderType orderType = parameters.OrderType;
      if (orderType == null)
      {
        num = 1;
      }
      else
      {
        int behavior = (int) orderType.Behavior;
        num = 0;
      }
    }
    if (num != 0)
      return double.NaN;
    switch (parameters.OrderType.Behavior)
    {
      case OrderTypeBehavior.Unspecified:
        return double.NaN;
      case OrderTypeBehavior.Market:
        return double.NaN;
      case OrderTypeBehavior.Limit:
        return parameters.Price;
      case OrderTypeBehavior.Stop:
        return parameters.TriggerPrice;
      case OrderTypeBehavior.TrailingStop:
        return parameters.TriggerPrice;
      case OrderTypeBehavior.StopLimit:
        return parameters.Price;
      default:
        throw new ArgumentOutOfRangeException();
    }
  }

  public static void SetExecutionPrice(this OrderRequestParameters parameters, double price)
  {
    int num;
    if (parameters == null)
    {
      num = 1;
    }
    else
    {
      OrderType orderType = parameters.OrderType;
      if (orderType == null)
      {
        num = 1;
      }
      else
      {
        int behavior = (int) orderType.Behavior;
        num = 0;
      }
    }
    if (num != 0)
      return;
    switch (parameters.OrderType.Behavior)
    {
      case OrderTypeBehavior.Limit:
        parameters.Price = price;
        break;
      case OrderTypeBehavior.Stop:
      case OrderTypeBehavior.StopLimit:
        parameters.TriggerPrice = price;
        break;
    }
  }

  public static bool IsCorrespondingOrder(this OrderRequestParameters parameters, IOrder order)
  {
    return parameters.Symbol.IsSameAs(order.Symbol) && parameters.Account.Equals(order.Account) && parameters.OrderTypeId == order.OrderTypeId && parameters.Side == order.Side && Math.Abs(parameters.Quantity - order.TotalQuantity) < double.Epsilon && Math.Abs(parameters.OrderType.GetFillPrice(parameters) - order.GetExecutionPrice()) < double.Epsilon;
  }

  public static bool TryCorrectBracketsQuantity(
    this OrderRequestParameters requestParameters,
    out string error)
  {
    error = (string) null;
    return OrderRequestParametersExtensions.퓏(requestParameters.Quantity, requestParameters.Symbol.LotStep, requestParameters.StopLossItems, out error) && OrderRequestParametersExtensions.퓏(requestParameters.Quantity, requestParameters.Symbol.LotStep, requestParameters.TakeProfitItems, out error);
  }

  private static bool 퓏([In] double obj0_1, [In] double obj1, [In] List<SlTpHolder> obj2, out string _param3)
  {
    _param3 = (string) null;
    if (obj2 == null || obj2.Count == 0 || obj2.All<SlTpHolder>((Func<SlTpHolder, bool>) (([In] obj0_2) => double.IsNaN(obj0_2.QuantityPercentage) && double.IsNaN(obj0_2.Quantity))))
      return true;
    double num = 0.0;
    foreach (SlTpHolder slTpHolder in obj2)
    {
      if (double.IsNaN(slTpHolder.QuantityPercentage))
      {
        num += slTpHolder.Quantity;
      }
      else
      {
        double increment = CoreMath.RoundToIncrement(slTpHolder.QuantityPercentage / 100.0 * obj0_1, obj1);
        slTpHolder.Quantity = increment;
        num += increment;
      }
    }
    if (num != obj0_1)
    {
      if (num < obj0_1)
        obj2.Last<SlTpHolder>().Quantity += obj0_1 - num;
      else if (obj2.Last<SlTpHolder>().Quantity > num - obj0_1)
      {
        obj2.Last<SlTpHolder>().Quantity -= num - obj0_1;
      }
      else
      {
        ref string local = ref _param3;
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(93, 2);
        interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓶());
        interpolatedStringHandler.AppendFormatted<double>(num);
        interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓽());
        interpolatedStringHandler.AppendFormatted<double>(obj0_1);
        interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픘());
        string stringAndClear = interpolatedStringHandler.ToStringAndClear();
        local = stringAndClear;
        return false;
      }
    }
    if (!obj2.Any<SlTpHolder>((Func<SlTpHolder, bool>) (([In] obj0_3) => obj0_3.Quantity == 0.0)))
      return true;
    _param3 = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픨();
    return false;
  }
}
