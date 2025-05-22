// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.IOrder
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public interface IOrder : ITradingObject, IUniqueID
{
  /// <summary>
  /// The ID of the order group. This group created when trades done by the MAM account.
  /// </summary>
  string GroupId { get; }

  /// <summary>Total quantity of the order</summary>
  double TotalQuantity { get; }

  /// <summary>Gets OrderType</summary>
  OrderType OrderType { get; }

  /// <summary>Gets order price value</summary>
  double Price { get; }

  /// <summary>Gets order trigger price value</summary>
  double TriggerPrice { get; }

  /// <summary>Gets order trailing offset value</summary>
  double TrailOffset { get; }

  /// <summary>Gets orders current status</summary>
  OrderStatus Status { get; }

  /// <summary>Gets orders last update time</summary>
  DateTime LastUpdateTime { get; }

  /// <summary>Gets Position Id.</summary>
  string PositionId { get; }

  /// <summary>Gets StopLoss holder for given order</summary>
  SlTpHolder StopLoss { get; }

  /// <summary>Gets TakeProfit holder for given order</summary>
  SlTpHolder TakeProfit { get; }

  SlTpHolder[] StopLossItems { get; }

  SlTpHolder[] TakeProfitItems { get; }

  string ConnectionId { get; }

  /// <summary>
  /// Orders Type Id. It is used for the orders type comparing.
  /// </summary>
  string OrderTypeId { get; }

  /// <summary>Gets order TIF(Time-In-Force) type</summary>
  TimeInForce TimeInForce { get; }

  /// <summary>Gets orders expiration time</summary>
  DateTime ExpirationTime { get; }

  BusinessObjectState State { get; }

  /// <summary>Remaining quantity of the order</summary>
  double RemainingQuantity { get; }

  /// <summary>Filled quantity of the order</summary>
  double FilledQuantity { get; }

  /// <summary>Gets open order original status</summary>
  string OriginalStatus { get; }

  double AverageFillPrice { get; }

  /// <summary>
  /// Will be triggered on each <see cref="M:TradingPlatform.BusinessLayer.Order.UpdateByMessage(TradingPlatform.BusinessLayer.Integration.MessageOpenOrder)" /> invocation
  /// </summary>
  event Action<IOrder> Updated;
}
