// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.OrderExtensions
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public static class OrderExtensions
{
  public static double GetExecutionPrice(this IOrder order)
  {
    int num;
    if (order == null)
    {
      num = 1;
    }
    else
    {
      OrderType orderType = order.OrderType;
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
    switch (order.OrderType.Behavior)
    {
      case OrderTypeBehavior.Unspecified:
        return double.NaN;
      case OrderTypeBehavior.Market:
        return double.NaN;
      case OrderTypeBehavior.Limit:
        return order.Price;
      case OrderTypeBehavior.Stop:
        return order.TriggerPrice;
      case OrderTypeBehavior.TrailingStop:
        return order.TriggerPrice;
      case OrderTypeBehavior.StopLimit:
        return order.Price;
      default:
        throw new ArgumentOutOfRangeException();
    }
  }
}
