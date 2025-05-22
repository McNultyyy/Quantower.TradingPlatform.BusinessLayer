// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.TradingOperations
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public static class TradingOperations
{
  public static AllowedResult IsAllowed(
    TradingOperation operation,
    TradingOperationParameters parameters)
  {
    if (parameters == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픾());
    if (Core.Instance.TradingStatus == TradingStatus.Locked)
      return AllowedResult.GetNotAllowedResult(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓍());
    Symbol symbol = parameters.Symbol;
    if ((symbol != null ? (symbol.State == BusinessObjectState.Fake ? 1 : 0) : 0) != 0)
      return AllowedResult.GetNotAllowedResult(string.Empty);
    if (parameters.Account.IsLocked())
      return AllowedResult.GetNotAllowedResult(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픁());
    switch (operation)
    {
      case TradingOperation.PlaceOrder:
        return TradingOperations.퓏(parameters);
      case TradingOperation.ModifyOrder:
        return TradingOperations.퓬(parameters);
      case TradingOperation.CancelOrder:
        return TradingOperations.핇(parameters);
      case TradingOperation.ClosePosition:
        return TradingOperations.퓲(parameters);
      default:
        throw new InvalidOperationException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픞());
    }
  }

  public static AllowedResult IsAllowed(
    TradingOperation operation,
    IList<TradingOperationParameters> parametersList)
  {
    if (parametersList == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇핁());
    foreach (TradingOperationParameters parameters in (IEnumerable<TradingOperationParameters>) parametersList)
    {
      AllowedResult allowedResult = TradingOperations.IsAllowed(operation, parameters);
      if (allowedResult.Status == TradingOperationStatus.NotAllowed)
        return allowedResult;
    }
    return AllowedResult.GetAllowedResult();
  }

  public static AllowedResult IsOrderTpAllowed(TradingOperationParameters parameters)
  {
    if (!(parameters.Order is TradingObject tradingObject1))
      tradingObject1 = (TradingObject) parameters.Position;
    TradingObject tradingObject2 = tradingObject1;
    if (tradingObject2 == null)
      return AllowedResult.GetNotAllowedResult(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픇());
    AllowedResult.GetAllowedResult();
    OrderType orderType = parameters.Order?.OrderType;
    AllowedResult allowedResult1;
    if (orderType != null)
    {
      AllowedResult allowedResult2 = Core.Instance.RulesManager.IsAllowed(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁(), tradingObject2.Account, tradingObject2.Symbol, orderType);
      if (allowedResult2.Status == TradingOperationStatus.NotAllowed)
        return allowedResult2;
      allowedResult1 = Core.Instance.RulesManager.IsAllowed(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픾(), tradingObject2.Account, tradingObject2.Symbol, orderType);
    }
    else
      allowedResult1 = Core.Instance.RulesManager.IsAllowed(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픾(), tradingObject2.Account, tradingObject2.Symbol);
    if (allowedResult1.Status == TradingOperationStatus.NotAllowed)
      return allowedResult1;
    OrderType[] orderTypes = Core.Instance.Connections[tradingObject2.ConnectionId]?.BusinessObjects?.OrderTypes;
    return (orderTypes != null ? ((IEnumerable<OrderType>) orderTypes).FirstOrDefault<OrderType>((Func<OrderType, bool>) (([In] obj0) => obj0.Behavior == OrderTypeBehavior.Limit && (obj0.Usage & OrderTypeUsage.CloseOrder) == OrderTypeUsage.CloseOrder)) : (OrderType) null) == null ? AllowedResult.GetNotAllowedResult(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픣()) : AllowedResult.GetAllowedResult();
  }

  public static AllowedResult IsOrderSlAllowed(TradingOperationParameters parameters)
  {
    if (!(parameters.Order is TradingObject tradingObject1))
      tradingObject1 = (TradingObject) parameters.Position;
    TradingObject tradingObject2 = tradingObject1;
    if (tradingObject2 == null)
      return AllowedResult.GetNotAllowedResult(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픇());
    AllowedResult.GetAllowedResult();
    OrderType orderType = parameters.Order?.OrderType;
    AllowedResult allowedResult1;
    if (orderType != null)
    {
      AllowedResult allowedResult2 = Core.Instance.RulesManager.IsAllowed(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁(), tradingObject2.Account, tradingObject2.Symbol, orderType);
      if (allowedResult2.Status == TradingOperationStatus.NotAllowed)
        return allowedResult2;
      allowedResult1 = Core.Instance.RulesManager.IsAllowed(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픂(), tradingObject2.Account, tradingObject2.Symbol, orderType);
    }
    else
      allowedResult1 = Core.Instance.RulesManager.IsAllowed(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픂(), tradingObject2.Account, tradingObject2.Symbol);
    if (allowedResult1.Status == TradingOperationStatus.NotAllowed)
      return allowedResult1;
    OrderType[] orderTypes = Core.Instance.Connections[tradingObject2.ConnectionId]?.BusinessObjects?.OrderTypes;
    return (orderTypes != null ? ((IEnumerable<OrderType>) orderTypes).FirstOrDefault<OrderType>((Func<OrderType, bool>) (([In] obj0) => obj0.Behavior == OrderTypeBehavior.Stop && (obj0.Usage & OrderTypeUsage.CloseOrder) == OrderTypeUsage.CloseOrder)) : (OrderType) null) == null ? AllowedResult.GetNotAllowedResult(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픣()) : AllowedResult.GetAllowedResult();
  }

  public static AllowedResult IsOrderSLTrailAllowed(TradingOperationParameters parameters)
  {
    if (!(parameters.Order is TradingObject tradingObject1))
      tradingObject1 = (TradingObject) parameters.Position;
    TradingObject tradingObject2 = tradingObject1;
    if (tradingObject2 == null)
      return AllowedResult.GetNotAllowedResult(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픇());
    AllowedResult.GetAllowedResult();
    OrderType orderType = parameters.Order?.OrderType;
    AllowedResult allowedResult = orderType == null ? Core.Instance.RulesManager.IsAllowed(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍(), tradingObject2.Account, tradingObject2.Symbol) : Core.Instance.RulesManager.IsAllowed(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍(), tradingObject2.Account, tradingObject2.Symbol, orderType);
    if (allowedResult.Status == TradingOperationStatus.NotAllowed)
      return allowedResult;
    OrderType[] orderTypes = Core.Instance.Connections[tradingObject2.ConnectionId]?.BusinessObjects?.OrderTypes;
    return (orderTypes != null ? ((IEnumerable<OrderType>) orderTypes).FirstOrDefault<OrderType>((Func<OrderType, bool>) (([In] obj0) => obj0.Behavior == OrderTypeBehavior.TrailingStop && (obj0.Usage & OrderTypeUsage.CloseOrder) == OrderTypeUsage.CloseOrder)) : (OrderType) null) == null ? AllowedResult.GetNotAllowedResult(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픣()) : AllowedResult.GetAllowedResult();
  }

  private static AllowedResult 퓏([In] TradingOperationParameters obj0)
  {
    if (obj0.Account != null && obj0.Symbol != null)
      return Core.Instance.RulesManager.IsAllowed(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핂(), obj0.Account, obj0.Symbol);
    return obj0.Symbol != null ? Core.Instance.RulesManager.IsAllowed(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핂(), obj0.Symbol) : AllowedResult.GetNotAllowedResult(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓙());
  }

  private static AllowedResult 퓬([In] TradingOperationParameters obj0)
  {
    return AllowedResult.GetAllowedResult();
  }

  private static AllowedResult 핇([In] TradingOperationParameters obj0)
  {
    return obj0.Order == null || obj0.Order.State == BusinessObjectState.Fake ? AllowedResult.GetNotAllowedResult(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓗()) : AllowedResult.GetAllowedResult();
  }

  private static AllowedResult 퓲([In] TradingOperationParameters obj0)
  {
    return obj0.Position == null || obj0.Position.State == BusinessObjectState.Fake ? AllowedResult.GetNotAllowedResult(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픎()) : AllowedResult.GetAllowedResult();
  }
}
