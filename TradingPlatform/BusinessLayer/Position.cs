// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Position
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
using TradingPlatform.BusinessLayer.Integration;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>Represents trading information about related position</summary>
[DataContract(Name = "Position", Namespace = "TradingPlatform")]
[Published]
public class Position : TradingObject, IMessageBuilder<MessageOpenPosition>
{
  private PnLItem 핋퓡;
  private PnLItem 핋퓓;
  private PnLItem 핋픗;
  private PnLItem 핋퓰;

  /// <summary>
  /// Will be triggered on each <see cref="M:TradingPlatform.BusinessLayer.Position.UpdateByMessage(TradingPlatform.BusinessLayer.Integration.MessageOpenPosition)" /> and <see cref="M:TradingPlatform.BusinessLayer.Position.UpdatePnl(TradingPlatform.BusinessLayer.PnL)" /> invocation
  /// </summary>
  public event Action<Position> Updated;

  /// <summary>Gets position quantity value</summary>
  [DataMember(Name = "Quantity")]
  public double Quantity { get; [param: In] private set; }

  /// <summary>Gets position open order price</summary>
  [DataMember(Name = "OpenPrice")]
  public double OpenPrice { get; [param: In] private set; }

  /// <summary>Gets position openning time</summary>
  [DataMember(Name = "OpenTime")]
  public DateTime OpenTime { get; [param: In] private set; }

  /// <summary>
  /// Gets Profit/loss (without swaps or commissions) all calculated based on the current broker's price. For open position it shows the profit/loss you would make if you close the position at the current price. If position closed, this parameter show profit/loss what trader have after closing this position.
  /// </summary>
  public PnLItem GrossPnL
  {
    get => this.핋퓡;
    [param: In] internal set => this.핋퓡 = value;
  }

  /// <summary>
  /// Gets Profit/loss calculated based on the current broker's price. For open position it shows the profit/loss you would make if you close the position at the current price. If position closed, this parameter show profit/loss what trader have after closing this position.
  /// </summary>
  public PnLItem NetPnL
  {
    get => this.핋퓓;
    [param: In] internal set => this.핋퓓 = value;
  }

  /// <summary>Gets fee amount for the position.</summary>
  public PnLItem Fee
  {
    get => this.핋픗;
    [param: In] internal set => this.핋픗 = value;
  }

  /// <summary>Gets PnL swaps</summary>
  public PnLItem Swaps
  {
    get => this.핋퓰;
    [param: In] internal set => this.핋퓰 = value;
  }

  /// <summary>The market price obtainable from your broker.</summary>
  public double CurrentPrice
  {
    get => (this.Side == Side.Buy ? this.Symbol?.Bid : this.Symbol?.Ask) ?? double.NaN;
  }

  public double LiquidationPrice { get; [param: In] private set; }

  internal Position([In] string obj0)
    : base(obj0)
  {
    this.LiquidationPrice = double.NaN;
  }

  /// <summary>
  /// Closes position if quantity is not specified else - uses partial closing operation.
  /// </summary>
  /// <param name="closeQuantity"></param>
  /// <returns></returns>
  public virtual TradingOperationResult Close(double closeQuantity = -1.0)
  {
    return Core.Instance.ClosePosition(new ClosePositionRequestParameters()
    {
      Position = this,
      CloseQuantity = closeQuantity != -1.0 ? closeQuantity : this.Quantity
    });
  }

  public void ForceRecalculatePnl()
  {
    PnL pnL = this.Connection.퓏(new PnLRequestParameters()
    {
      Symbol = this.Symbol,
      Account = this.Account,
      OpenPrice = this.OpenPrice,
      ClosePrice = this.CurrentPrice,
      Side = this.Side,
      Quantity = this.Quantity,
      PositionId = this.Id
    });
    if (pnL == null)
      return;
    this.퓏(pnL);
  }

  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 6);
    interpolatedStringHandler.AppendFormatted<Side>(this.Side);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프());
    interpolatedStringHandler.AppendFormatted<double>(this.Quantity);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프());
    interpolatedStringHandler.AppendFormatted<Symbol>(this.Symbol);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓴());
    interpolatedStringHandler.AppendFormatted(this.Symbol.FormatPrice(this.OpenPrice));
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓭());
    interpolatedStringHandler.AppendFormatted<Account>(this.Account);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픁());
    interpolatedStringHandler.AppendFormatted(this.Id);
    return interpolatedStringHandler.ToStringAndClear();
  }

  internal virtual void 퓏([In] MessageOpenPosition obj0)
  {
    this.Id = obj0.PositionId;
    Symbol symbol;
    if (this.ConnectionCache != null && this.ConnectionCache.SymbolsCache.퓏(obj0.SymbolId, out symbol))
      this.Symbol = symbol;
    Account account;
    if (this.ConnectionCache != null && this.ConnectionCache.AccountsCache.퓏(obj0.AccountId, out account))
      this.Account = account;
    this.OpenPrice = obj0.OpenPrice;
    this.OpenTime = obj0.OpenTime;
    this.Quantity = obj0.Quantity;
    this.Side = obj0.Side;
    this.Comment = obj0.Comment;
    this.LiquidationPrice = obj0.LiquidationPrice;
    this.ProcessAdditionalItems(obj0.AdditionalInfoItems);
    // ISSUE: reference to a compiler-generated field
    Action<Position> 핋픘 = this.핋픘;
    if (핋픘 == null)
      return;
    핋픘(this);
  }

  public MessageOpenPosition BuildMessage()
  {
    MessageOpenPosition messageOpenPosition = new MessageOpenPosition(this.Symbol?.Id);
    messageOpenPosition.PositionId = this.Id;
    messageOpenPosition.AccountId = this.Account?.Id;
    messageOpenPosition.OpenPrice = this.OpenPrice;
    messageOpenPosition.OpenTime = this.OpenTime;
    messageOpenPosition.Quantity = this.Quantity;
    messageOpenPosition.Side = this.Side;
    messageOpenPosition.Comment = this.Comment;
    messageOpenPosition.LiquidationPrice = this.LiquidationPrice;
    AdditionalInfoCollection additionalInfo = this.AdditionalInfo;
    messageOpenPosition.AdditionalInfoItems = additionalInfo != null ? additionalInfo.ToList<AdditionalInfoItem>() : (List<AdditionalInfoItem>) null;
    return messageOpenPosition;
  }

  internal void 퓏([In] PnL obj0)
  {
    if ((0 | (this.퓏(ref this.핋퓡, obj0.GrossPnL) ? 1 : 0) | (this.퓏(ref this.핋퓓, obj0.NetPnL) ? 1 : 0) | (this.퓏(ref this.핋픗, obj0.Fee) ? 1 : 0) | (this.퓏(ref this.핋퓰, obj0.Swaps) ? 1 : 0)) == 0)
      return;
    // ISSUE: reference to a compiler-generated field
    Action<Position> 핋픘 = this.핋픘;
    if (핋픘 == null)
      return;
    핋픘(this);
  }

  private bool 퓏([In] ref PnLItem obj0, [In] PnLItem obj1)
  {
    if (obj1 != null)
    {
      PnLItem pnLitem = obj0;
      if ((pnLitem != null ? (pnLitem.Equals((object) obj1) ? 1 : 0) : 0) == 0)
      {
        obj0 = obj1;
        obj0.ConnectionId = this.ConnectionId;
        return true;
      }
    }
    return false;
  }

  /// <summary>Gets StopLoss order which belongs to the position</summary>
  public Order StopLoss
  {
    get
    {
      return ((IEnumerable<Order>) this.ConnectionCache.Orders).FirstOrDefault<Order>((Func<Order, bool>) (([In] obj0) => obj0.PositionId == this.Id && (obj0.OrderType.Behavior == OrderTypeBehavior.Stop || obj0.OrderType.Behavior == OrderTypeBehavior.TrailingStop) && obj0.OrderType.Usage.HasFlag((Enum) OrderTypeUsage.CloseOrder)));
    }
  }

  /// <summary>Gets TakeProfit order which belongs to the position</summary>
  public Order TakeProfit
  {
    get
    {
      return ((IEnumerable<Order>) this.ConnectionCache.Orders).FirstOrDefault<Order>((Func<Order, bool>) (([In] obj0) => obj0.PositionId == this.Id && obj0.OrderType.Behavior == OrderTypeBehavior.Limit && obj0.OrderType.Usage.HasFlag((Enum) OrderTypeUsage.CloseOrder)));
    }
  }

  /// <summary>Returns ticks amount between open and current price.</summary>
  public double GrossPnLTicks
  {
    get
    {
      if (this.Symbol == null || this.OpenPrice.IsNanOrDefault() || this.CurrentPrice.IsNanOrDefault())
        return 0.0;
      return this.Side == Side.Buy ? this.Symbol.CalculateTicks(this.OpenPrice, this.CurrentPrice) : this.Symbol.CalculateTicks(this.CurrentPrice, this.OpenPrice);
    }
  }
}
