// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.MessageOrderHistory
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using ProtoBuf;
using System.Runtime.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

[DataContract(Name = "OrderHistory", Namespace = "TradingPlatform")]
[ProtoContract]
public sealed class MessageOrderHistory : MessageOpenOrder
{
  public override MessageType Type => MessageType.OrderHistory;

  private MessageOrderHistory() => this.AverageFillPrice = double.NaN;

  public MessageOrderHistory(string symbolId)
    : base(symbolId)
  {
    this.AverageFillPrice = double.NaN;
  }

  public MessageOrderHistory(MessageOpenOrder order)
    : base(order.SymbolId)
  {
    this.OrderId = order.OrderId;
    this.AccountId = order.AccountId;
    this.OrderTypeId = order.OrderTypeId;
    this.Price = order.Price;
    this.TriggerPrice = order.TriggerPrice;
    this.TrailOffset = order.TrailOffset;
    this.FilledQuantity = order.FilledQuantity;
    this.TotalQuantity = order.TotalQuantity;
    this.Side = order.Side;
    this.TimeInForce = order.TimeInForce;
    this.ExpirationTime = order.ExpirationTime;
    this.PositionId = order.PositionId;
    this.GroupId = order.GroupId;
    this.Comment = order.Comment;
    this.LastUpdateTime = order.LastUpdateTime;
    this.StopLoss = order.StopLoss;
    this.TakeProfit = order.TakeProfit;
    this.Status = order.Status;
    this.OriginalStatus = order.OriginalStatus;
    this.AverageFillPrice = order.AverageFillPrice;
  }
}
