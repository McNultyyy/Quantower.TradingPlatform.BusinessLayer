// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Order
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
using System.Runtime.Serialization;
using System.Text;
using TradingPlatform.BusinessLayer.Integration;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>Represents trading information about pending order</summary>
[DataContract(Name = "Order", Namespace = "TradingPlatform")]
[Published]
public class Order : 
  TradingObject,
  IMessageBuilder<MessageOpenOrder>,
  IOrder,
  ITradingObject,
  IUniqueID,
  IEquatable<Order>
{
  /// <summary>
  /// The ID of the order group. This group created when trades done by the MAM account.
  /// </summary>
  [DataMember(Name = "GroupId")]
  public string GroupId { get; [param: In] private set; }

  /// <summary>Gets Position Id.</summary>
  [DataMember(Name = "PositionId")]
  public string PositionId { get; [param: In] private set; }

  /// <summary>Total quantity of the order</summary>
  [DataMember(Name = "TotalQuantity")]
  public double TotalQuantity { get; [param: In] private set; }

  /// <summary>Filled quantity of the order</summary>
  [DataMember(Name = "FilledQuantity")]
  public double FilledQuantity { get; [param: In] private set; }

  /// <summary>Remaining quantity of the order</summary>
  public double RemainingQuantity => this.TotalQuantity - this.FilledQuantity;

  /// <summary>
  /// Orders Type Id. It is used for the orders type comparing.
  /// </summary>
  [DataMember(Name = "OrderTypeId")]
  public string OrderTypeId { get; [param: In] private set; }

  /// <summary>Gets OrderType</summary>
  public OrderType OrderType
  {
    get
    {
      return ((IEnumerable<OrderType>) this.ConnectionCache.OrderTypes).FirstOrDefault<OrderType>((Func<OrderType, bool>) (([In] obj0) => obj0.Id == this.OrderTypeId));
    }
  }

  /// <summary>Gets order price value</summary>
  [DataMember(Name = "Price")]
  public double Price { get; [param: In] private set; }

  /// <summary>Gets order trigger price value</summary>
  [DataMember(Name = "TriggerPrice")]
  public double TriggerPrice { get; [param: In] private set; }

  /// <summary>Gets order trailing offset value</summary>
  [DataMember(Name = "TrailOffset")]
  public double TrailOffset { get; [param: In] private set; }

  /// <summary>Gets orders current status</summary>
  [DataMember(Name = "Status")]
  public OrderStatus Status { get; [param: In] internal set; }

  /// <summary>Gets open order original status</summary>
  [DataMember(Name = "OriginalStatus")]
  public string OriginalStatus { get; [param: In] private set; }

  /// <summary>Gets order TIF(Time-In-Force) type</summary>
  [DataMember(Name = "Tif")]
  public TimeInForce TimeInForce { get; [param: In] private set; }

  /// <summary>Gets orders expiration time</summary>
  [DataMember(Name = "ExpirationTime")]
  public DateTime ExpirationTime { get; [param: In] private set; }

  /// <summary>Gets orders last update time</summary>
  public DateTime LastUpdateTime { get; [param: In] private set; }

  public double AverageFillPrice { get; [param: In] private set; }

  /// <summary>Gets StopLoss holder for given order</summary>
  public SlTpHolder StopLoss
  {
    get => ((IEnumerable<SlTpHolder>) this.StopLossItems).FirstOrDefault<SlTpHolder>();
  }

  /// <summary>Gets TakeProfit holder for given order</summary>
  public SlTpHolder TakeProfit
  {
    get => ((IEnumerable<SlTpHolder>) this.TakeProfitItems).FirstOrDefault<SlTpHolder>();
  }

  public SlTpHolder[] StopLossItems { get; [param: In] private set; }

  public SlTpHolder[] TakeProfitItems { get; [param: In] private set; }

  /// <summary>
  /// Will be triggered on each <see cref="M:TradingPlatform.BusinessLayer.Order.UpdateByMessage(TradingPlatform.BusinessLayer.Integration.MessageOpenOrder)" /> invocation
  /// </summary>
  public event Action<IOrder> Updated;

  /// <summary>Creates Order instance</summary>
  /// <param name="connectionId"></param>
  internal Order([In] string obj0)
    : base(obj0)
  {
    this.StopLossItems = new SlTpHolder[0];
    this.TakeProfitItems = new SlTpHolder[0];
  }

  internal void 퓏([In] MessageOpenOrder obj0)
  {
    this.Id = obj0.OrderId;
    this.GroupId = obj0.GroupId;
    this.PositionId = obj0.PositionId;
    this.LastUpdateTime = obj0.LastUpdateTime;
    Symbol symbol;
    if (this.ConnectionCache != null && this.ConnectionCache.SymbolsCache.퓏(obj0.SymbolId, out symbol))
      this.Symbol = symbol;
    else if (!string.IsNullOrEmpty(obj0.SymbolId))
      this.Symbol = new Symbol(new BusinessObjectInfo()
      {
        Id = obj0.SymbolId,
        Name = obj0.SymbolId
      });
    Account account;
    if (!string.IsNullOrEmpty(obj0.AccountId) && this.ConnectionCache != null && this.ConnectionCache.AccountsCache.퓏(obj0.AccountId, out account))
      this.Account = account;
    this.TotalQuantity = obj0.TotalQuantity;
    this.FilledQuantity = obj0.FilledQuantity;
    this.Side = obj0.Side;
    this.OrderTypeId = obj0.OrderTypeId;
    this.Price = obj0.Price;
    this.TriggerPrice = obj0.TriggerPrice;
    this.TrailOffset = obj0.TrailOffset;
    this.TimeInForce = obj0.TimeInForce;
    this.ExpirationTime = obj0.ExpirationTime;
    this.Status = obj0.Status;
    this.OriginalStatus = obj0.OriginalStatus;
    this.AverageFillPrice = obj0.AverageFillPrice;
    this.StopLossItems = obj0.StopLossItems.ToArray();
    this.TakeProfitItems = obj0.TakeProfitItems.ToArray();
    this.Comment = obj0.Comment;
    this.ProcessAdditionalItems(obj0.AdditionalInfoItems);
    // ISSUE: reference to a compiler-generated field
    Action<IOrder> 핋퓳 = this.핋퓳;
    if (핋퓳 == null)
      return;
    핋퓳((IOrder) this);
  }

  public MessageOpenOrder BuildMessage()
  {
    MessageOpenOrder messageOpenOrder = new MessageOpenOrder(this.Symbol?.Id);
    messageOpenOrder.OrderId = this.Id;
    messageOpenOrder.GroupId = this.GroupId;
    messageOpenOrder.PositionId = this.PositionId;
    messageOpenOrder.LastUpdateTime = this.LastUpdateTime;
    messageOpenOrder.AccountId = this.Account?.Id;
    messageOpenOrder.TotalQuantity = this.TotalQuantity;
    messageOpenOrder.FilledQuantity = this.FilledQuantity;
    messageOpenOrder.Side = this.Side;
    messageOpenOrder.OrderTypeId = this.OrderTypeId;
    messageOpenOrder.Price = this.Price;
    messageOpenOrder.TriggerPrice = this.TriggerPrice;
    messageOpenOrder.TrailOffset = this.TrailOffset;
    messageOpenOrder.TimeInForce = this.TimeInForce;
    messageOpenOrder.ExpirationTime = this.ExpirationTime;
    messageOpenOrder.Status = this.Status;
    messageOpenOrder.OriginalStatus = this.OriginalStatus;
    messageOpenOrder.Comment = this.Comment;
    AdditionalInfoCollection additionalInfo = this.AdditionalInfo;
    messageOpenOrder.AdditionalInfoItems = additionalInfo != null ? additionalInfo.ToList<AdditionalInfoItem>() : (List<AdditionalInfoItem>) null;
    messageOpenOrder.StopLossItems.AddRange((IEnumerable<SlTpHolder>) this.StopLossItems);
    messageOpenOrder.TakeProfitItems.AddRange((IEnumerable<SlTpHolder>) this.TakeProfitItems);
    return messageOpenOrder;
  }

  /// <summary>Cancels pending order</summary>
  /// <returns></returns>
  public TradingOperationResult Cancel(string sendingSource = null)
  {
    Core instance = Core.Instance;
    CancelOrderRequestParameters request = new CancelOrderRequestParameters();
    request.Order = (IOrder) this;
    request.SendingSource = sendingSource;
    return instance.CancelOrder(request);
  }

  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(46, 12);
    interpolatedStringHandler.AppendFormatted(this.Id);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픆());
    interpolatedStringHandler.AppendFormatted<Symbol>(this.Symbol);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픆());
    interpolatedStringHandler.AppendFormatted<Account>(this.Account);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픆());
    interpolatedStringHandler.AppendFormatted<Side>(this.Side);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픆());
    interpolatedStringHandler.AppendFormatted(this.OrderType?.Name);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픆());
    interpolatedStringHandler.AppendFormatted<double>(this.FilledQuantity);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픉());
    interpolatedStringHandler.AppendFormatted<double>(this.TotalQuantity);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픆());
    interpolatedStringHandler.AppendFormatted(this.퓏());
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픆());
    interpolatedStringHandler.AppendFormatted<OrderStatus>(this.Status);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픆());
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗핉());
    interpolatedStringHandler.AppendFormatted(this.PositionId);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗핊());
    interpolatedStringHandler.AppendFormatted(this.GroupId);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픛());
    interpolatedStringHandler.AppendFormatted(this.Comment);
    return interpolatedStringHandler.ToStringAndClear();
  }

  private string 퓏()
  {
    StringBuilder stringBuilder1 = new StringBuilder();
    StringBuilder.AppendInterpolatedStringHandler interpolatedStringHandler;
    if (!double.IsNaN(this.Price))
    {
      StringBuilder stringBuilder2 = stringBuilder1;
      StringBuilder stringBuilder3 = stringBuilder2;
      interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(5, 1, stringBuilder2);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓜());
      interpolatedStringHandler.AppendFormatted(this.Symbol?.FormatPrice(this.Price) ?? this.Price.FormatPriceWithMaxPrecision());
      ref StringBuilder.AppendInterpolatedStringHandler local = ref interpolatedStringHandler;
      stringBuilder3.Append(ref local);
    }
    if (!double.IsNaN(this.TriggerPrice))
    {
      StringBuilder stringBuilder4 = stringBuilder1;
      StringBuilder stringBuilder5 = stringBuilder4;
      interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(8, 1, stringBuilder4);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픺());
      interpolatedStringHandler.AppendFormatted(this.Symbol?.FormatPrice(this.TriggerPrice) ?? this.TriggerPrice.FormatPriceWithMaxPrecision());
      ref StringBuilder.AppendInterpolatedStringHandler local = ref interpolatedStringHandler;
      stringBuilder5.Append(ref local);
    }
    if (!double.IsNaN(this.TrailOffset))
    {
      StringBuilder stringBuilder6 = stringBuilder1;
      StringBuilder stringBuilder7 = stringBuilder6;
      interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(12, 1, stringBuilder6);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗핃());
      interpolatedStringHandler.AppendFormatted(this.Symbol?.FormatOffset(this.TrailOffset, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픹()) ?? this.TrailOffset.FormatPriceWithMaxPrecision());
      ref StringBuilder.AppendInterpolatedStringHandler local = ref interpolatedStringHandler;
      stringBuilder7.Append(ref local);
    }
    return stringBuilder1.ToString();
  }

  public bool Equals(Order other)
  {
    if (other == null)
      return false;
    if (this == other)
      return true;
    return this.ConnectionId == other.ConnectionId && this.Id == other.Id;
  }

  public override bool Equals(object obj)
  {
    if (obj == null)
      return false;
    if (this == obj)
      return true;
    return !(obj.GetType() != this.GetType()) && this.Equals((Order) obj);
  }

  public override int GetHashCode() => HashCode.Combine<string, string>(this.ConnectionId, this.Id);
}
