// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Trade
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Integration;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>Represents information about trade.</summary>
[Published]
public class Trade(string connectionId) : TradingObject(connectionId), IMessageBuilder<MessageTrade>
{
  /// <summary>
  /// Gets the unique identifier of the order initiating the trade.
  /// </summary>
  public string OrderId { get; [param: In] private set; }

  /// <summary>
  /// Gets a unique identifier of the position, which is related to this trade.
  /// </summary>
  public string PositionId { get; [param: In] private set; }

  /// <summary>Get the price where trade was executed</summary>
  public double Price { get; [param: In] private set; }

  /// <summary>Get the trade quantity</summary>
  public double Quantity { get; [param: In] private set; }

  /// <summary>Get the date and time when trade was executed</summary>
  public DateTime DateTime { get; [param: In] private set; }

  /// <summary>Get the trade Gross P&amp;L</summary>
  public PnLItem GrossPnl { get; [param: In] internal set; }

  /// <summary>Get the trade Net P&amp;L</summary>
  public PnLItem NetPnl { get; [param: In] internal set; }

  /// <summary>Get the fee value that was charged for this trade</summary>
  public PnLItem Fee { get; [param: In] internal set; }

  /// <summary>Get the trade order type</summary>
  public string OrderTypeId { get; [param: In] internal set; }

  public PositionImpactType PositionImpactType { get; [param: In] private set; }

  /// <summary>Will be triggered on trade updating</summary>
  public event Action Updated;

  internal void 퓏([In] MessageTrade obj0)
  {
    this.Id = obj0.TradeId;
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
    if (this.ConnectionCache != null && this.ConnectionCache.AccountsCache.퓏(obj0.AccountId, out account))
      this.Account = account;
    else if (!string.IsNullOrEmpty(obj0.AccountId))
      this.Account = new Account(new BusinessObjectInfo()
      {
        Id = obj0.AccountId,
        Name = obj0.AccountId
      });
    this.OrderId = obj0.OrderId;
    this.PositionId = obj0.PositionId;
    this.Price = obj0.Price;
    this.Quantity = obj0.Quantity;
    this.Side = obj0.Side;
    this.Comment = obj0.Comment;
    this.DateTime = obj0.DateTime;
    this.OrderTypeId = obj0.OrderTypeId;
    this.PositionImpactType = obj0.PositionImpactType;
    this.GrossPnl = obj0.GrossPnl;
    if (this.GrossPnl != null)
      this.GrossPnl.ConnectionId = this.ConnectionId;
    this.NetPnl = obj0.NetPnl;
    if (this.NetPnl != null)
      this.NetPnl.ConnectionId = this.ConnectionId;
    this.Fee = obj0.Fee;
    if (this.Fee != null)
      this.Fee.ConnectionId = this.ConnectionId;
    // ISSUE: reference to a compiler-generated field
    Action 핋픦 = this.핋픦;
    if (핋픦 == null)
      return;
    핋픦();
  }

  public MessageTrade BuildMessage()
  {
    return new MessageTrade()
    {
      TradeId = this.Id,
      SymbolId = this.Symbol?.Id,
      AccountId = this.Account?.Id,
      OrderId = this.OrderId,
      PositionId = this.PositionId,
      Price = this.Price,
      Quantity = this.Quantity,
      Side = this.Side,
      Comment = this.Comment,
      DateTime = this.DateTime,
      OrderTypeId = this.OrderTypeId,
      PositionImpactType = this.PositionImpactType,
      GrossPnl = this.GrossPnl,
      NetPnl = this.NetPnl,
      Fee = this.Fee
    };
  }

  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(50, 7);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓍());
    interpolatedStringHandler.AppendFormatted<Symbol>(this.Symbol);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픆());
    interpolatedStringHandler.AppendFormatted<Account>(this.Account);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픆());
    interpolatedStringHandler.AppendFormatted<Side>(this.Side);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픁());
    interpolatedStringHandler.AppendFormatted<double>(this.Quantity);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픩());
    interpolatedStringHandler.AppendFormatted<double>(this.Price);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픞());
    interpolatedStringHandler.AppendFormatted(this.OrderId);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픛());
    interpolatedStringHandler.AppendFormatted(this.Comment);
    return interpolatedStringHandler.ToStringAndClear();
  }
}
