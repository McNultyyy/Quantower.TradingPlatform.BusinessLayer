// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.AdvancedTradingOperations
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using CancelAllOpenOrdersRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TradingPlatform.BusinessLayer.Utils;

#nullable enable
namespace TradingPlatform.BusinessLayer;

public class AdvancedTradingOperations
{
  internal AdvancedTradingOperations()
  {
  }

  /// <summary>
  /// Cancel all pending <see cref="T:TradingPlatform.BusinessLayer.Order" />s
  /// </summary>
  /// <param name="sendingSource">the name of the initiator of the call (optional)</param>
  public 
  #nullable disable
  AdvancedTradingOperationResult CancelOrders([CallerMemberName] string sendingSource = null)
  {
    Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픦() + sendingSource);
    GroupTradingOperation tradingOperation = new GroupTradingOperation(GroupTradingOperationType.CancelOrders, GroupTradingOperationFilters.None);
    return AdvancedTradingOperations.퓏(sendingSource, tradingOperation);
  }

  /// <summary>
  /// Cancel all pending <see cref="T:TradingPlatform.BusinessLayer.Order" />s
  /// </summary>
  /// <param name="orders"><see cref="T:TradingPlatform.BusinessLayer.Order" />s to cancel</param>
  /// <param name="sendingSource">the name of the initiator of the call (optional)</param>
  /// <returns></returns>
  public AdvancedTradingOperationResult CancelOrders(IOrder[] orders, [CallerMemberName] string sendingSource = null)
  {
    LoggerManager loggers = Core.Instance.Loggers;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(67, 2);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픍());
    interpolatedStringHandler.AppendFormatted<int>(orders.Length);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픆());
    interpolatedStringHandler.AppendFormatted(sendingSource);
    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
    loggers.Log(stringAndClear);
    AdvancedTradingOperationResult tradingOperationResult = new AdvancedTradingOperationResult();
    GroupTradingOperation tradingOperation = new GroupTradingOperation(GroupTradingOperationType.CancelOrders, GroupTradingOperationFilters.None);
    foreach (IGrouping<Symbol, IOrder> source in ((IEnumerable<IOrder>) orders).GroupBy<IOrder, Symbol, IOrder>((Func<IOrder, Symbol>) (([In] obj0) => obj0.Symbol), (Func<IOrder, IOrder>) (([In] obj0) => obj0)))
    {
      Symbol key = source.Key;
      IOrder[] array = source.ToArray<IOrder>();
      tradingOperationResult.퓏(AdvancedTradingOperations.퓏(key, array, sendingSource, tradingOperation));
    }
    return tradingOperationResult;
  }

  /// <summary>
  /// Cancel all pending <see cref="T:TradingPlatform.BusinessLayer.Order" />s by <see cref="T:TradingPlatform.BusinessLayer.Symbol" />
  /// </summary>
  /// <param name="symbol"><see cref="T:TradingPlatform.BusinessLayer.Symbol" /></param>
  /// <param name="sendingSource">the name of the initiator of the call (optional)</param>
  public AdvancedTradingOperationResult CancelOrders(Symbol symbol, [CallerMemberName] string sendingSource = null)
  {
    LoggerManager loggers = Core.Instance.Loggers;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(62, 2);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픅());
    interpolatedStringHandler.AppendFormatted<Symbol>(symbol);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픠());
    interpolatedStringHandler.AppendFormatted(sendingSource);
    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
    loggers.Log(stringAndClear);
    GroupTradingOperation tradingOperation = new GroupTradingOperation(GroupTradingOperationType.CancelOrders, GroupTradingOperationFilters.Symbol);
    return AdvancedTradingOperations.퓏(symbol, Array.Empty<IOrder>(), sendingSource, tradingOperation);
  }

  /// <summary>
  /// Cancel all pending <see cref="T:TradingPlatform.BusinessLayer.Order" />s by <see cref="T:TradingPlatform.BusinessLayer.Account" />
  /// </summary>
  /// <param name="account"><see cref="T:TradingPlatform.BusinessLayer.Account" /></param>
  /// <param name="sendingSource">the name of the initiator of the call (optional)</param>
  public AdvancedTradingOperationResult CancelOrders(Account account, [CallerMemberName] string sendingSource = null)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    AdvancedTradingOperations.핆 핆 = new AdvancedTradingOperations.핆();
    // ISSUE: reference to a compiler-generated field
    핆.픁퓎 = account;
    LoggerManager loggers = Core.Instance.Loggers;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(63 /*0x3F*/, 2);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓮());
    // ISSUE: reference to a compiler-generated field
    interpolatedStringHandler.AppendFormatted<Account>(핆.픁퓎);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픠());
    interpolatedStringHandler.AppendFormatted(sendingSource);
    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
    loggers.Log(stringAndClear);
    GroupTradingOperation tradingOperation = new GroupTradingOperation(GroupTradingOperationType.CancelOrders, GroupTradingOperationFilters.Account);
    // ISSUE: reference to a compiler-generated method
    return AdvancedTradingOperations.퓏(new Func<IOrder, bool>(핆.퓏), sendingSource, tradingOperation);
  }

  /// <summary>
  /// Cancel all pending <see cref="T:TradingPlatform.BusinessLayer.Order" />s by <see cref="T:TradingPlatform.BusinessLayer.Symbol" /> and <see cref="T:TradingPlatform.BusinessLayer.Account" />
  /// </summary>
  /// <param name="symbol"><see cref="T:TradingPlatform.BusinessLayer.Symbol" /></param>
  /// <param name="account"><see cref="T:TradingPlatform.BusinessLayer.Account" /></param>
  /// <param name="sendingSource">the name of the initiator of the call (optional)</param>
  public AdvancedTradingOperationResult CancelOrders(
    Symbol symbol,
    Account account,
    [CallerMemberName] string sendingSource = null)
  {
    LoggerManager loggers = Core.Instance.Loggers;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(74, 3);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픅());
    interpolatedStringHandler.AppendFormatted<Symbol>(symbol);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픕());
    interpolatedStringHandler.AppendFormatted<Account>(account);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픠());
    interpolatedStringHandler.AppendFormatted(sendingSource);
    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
    loggers.Log(stringAndClear);
    GroupTradingOperation tradingOperation = new GroupTradingOperation(GroupTradingOperationType.CancelOrders, GroupTradingOperationFilters.Symbol | GroupTradingOperationFilters.Account);
    return AdvancedTradingOperations.퓏(symbol, account, sendingSource, tradingOperation);
  }

  /// <summary>
  /// Cancel all pending <see cref="T:TradingPlatform.BusinessLayer.Order" />s by <see cref="T:TradingPlatform.BusinessLayer.Symbol" /> and <see cref="T:TradingPlatform.BusinessLayer.Side" />
  /// </summary>
  /// <param name="symbol"><see cref="T:TradingPlatform.BusinessLayer.Symbol" /></param>
  /// <param name="side"><see cref="T:TradingPlatform.BusinessLayer.Side" /></param>
  /// <param name="sendingSource">the name of the initiator of the call (optional)</param>
  public AdvancedTradingOperationResult CancelOrders(
    Symbol symbol,
    Side side,
    [CallerMemberName] string sendingSource = null)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    AdvancedTradingOperations.퓝 퓝 = new AdvancedTradingOperations.퓝();
    // ISSUE: reference to a compiler-generated field
    퓝.픞픞 = symbol;
    // ISSUE: reference to a compiler-generated field
    퓝.픞핁 = side;
    LoggerManager loggers = Core.Instance.Loggers;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(71, 3);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픅());
    // ISSUE: reference to a compiler-generated field
    interpolatedStringHandler.AppendFormatted<Symbol>(퓝.픞픞);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픱());
    // ISSUE: reference to a compiler-generated field
    interpolatedStringHandler.AppendFormatted<Side>(퓝.픞핁);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픠());
    interpolatedStringHandler.AppendFormatted(sendingSource);
    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
    loggers.Log(stringAndClear);
    GroupTradingOperation tradingOperation = new GroupTradingOperation(GroupTradingOperationType.CancelOrders, GroupTradingOperationFilters.Symbol | GroupTradingOperationFilters.Side);
    // ISSUE: reference to a compiler-generated method
    return AdvancedTradingOperations.퓏(new Func<IOrder, bool>(퓝.퓏), sendingSource, tradingOperation);
  }

  /// <summary>
  /// Cancel all pending <see cref="T:TradingPlatform.BusinessLayer.Order" />s by <see cref="T:TradingPlatform.BusinessLayer.Symbol" />, <see cref="T:TradingPlatform.BusinessLayer.Account" /> and <see cref="T:TradingPlatform.BusinessLayer.Side" />
  /// </summary>
  /// <param name="symbol"><see cref="T:TradingPlatform.BusinessLayer.Symbol" /></param>
  /// <param name="account"><see cref="T:TradingPlatform.BusinessLayer.Account" /></param>
  /// <param name="side"><see cref="T:TradingPlatform.BusinessLayer.Side" /></param>
  /// <param name="sendingSource">the name of the initiator of the call (optional)</param>
  public AdvancedTradingOperationResult CancelOrders(
    Symbol symbol,
    Account account,
    Side side,
    [CallerMemberName] string sendingSource = null)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    AdvancedTradingOperations.퓶 퓶 = new AdvancedTradingOperations.퓶();
    // ISSUE: reference to a compiler-generated field
    퓶.픞픇 = symbol;
    // ISSUE: reference to a compiler-generated field
    퓶.픞픣 = account;
    // ISSUE: reference to a compiler-generated field
    퓶.픞퓙 = side;
    LoggerManager loggers = Core.Instance.Loggers;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(83, 4);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픅());
    // ISSUE: reference to a compiler-generated field
    interpolatedStringHandler.AppendFormatted<Symbol>(퓶.픞픇);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픕());
    // ISSUE: reference to a compiler-generated field
    interpolatedStringHandler.AppendFormatted<Account>(퓶.픞픣);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픱());
    // ISSUE: reference to a compiler-generated field
    interpolatedStringHandler.AppendFormatted<Side>(퓶.픞퓙);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픠());
    interpolatedStringHandler.AppendFormatted(sendingSource);
    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
    loggers.Log(stringAndClear);
    GroupTradingOperation tradingOperation = new GroupTradingOperation(GroupTradingOperationType.CancelOrders, GroupTradingOperationFilters.Symbol | GroupTradingOperationFilters.Account | GroupTradingOperationFilters.Side);
    // ISSUE: reference to a compiler-generated method
    return AdvancedTradingOperations.퓏(new Func<IOrder, bool>(퓶.퓏), sendingSource, tradingOperation);
  }

  /// <summary>
  /// Cancel all pending <see cref="T:TradingPlatform.BusinessLayer.Order" />s by <see cref="T:TradingPlatform.BusinessLayer.Side" />
  /// </summary>
  /// <param name="side"><see cref="T:TradingPlatform.BusinessLayer.Side" /></param>
  /// <param name="sendingSource">the name of the initiator of the call (optional)</param>
  public AdvancedTradingOperationResult CancelOrders(Side side, [CallerMemberName] string sendingSource = null)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    AdvancedTradingOperations.퓽 퓽 = new AdvancedTradingOperations.퓽();
    // ISSUE: reference to a compiler-generated field
    퓽.픞퓗 = side;
    LoggerManager loggers = Core.Instance.Loggers;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(60, 2);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픶());
    // ISSUE: reference to a compiler-generated field
    interpolatedStringHandler.AppendFormatted<Side>(퓽.픞퓗);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픠());
    interpolatedStringHandler.AppendFormatted(sendingSource);
    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
    loggers.Log(stringAndClear);
    GroupTradingOperation tradingOperation = new GroupTradingOperation(GroupTradingOperationType.CancelOrders, GroupTradingOperationFilters.Side);
    // ISSUE: reference to a compiler-generated method
    return AdvancedTradingOperations.퓏(new Func<IOrder, bool>(퓽.퓏), sendingSource, tradingOperation);
  }

  /// <summary>
  /// Cancel all pending <see cref="T:TradingPlatform.BusinessLayer.Order" />s by <see cref="T:TradingPlatform.BusinessLayer.Symbol" /> and <see cref="T:TradingPlatform.BusinessLayer.TimeInForce" />
  /// </summary>
  /// <param name="symbol"><see cref="T:TradingPlatform.BusinessLayer.Symbol" /></param>
  /// <param name="timeInForce"><see cref="T:TradingPlatform.BusinessLayer.TimeInForce" /></param>
  /// <param name="sendingSource">the name of the initiator of the call (optional)</param>
  public AdvancedTradingOperationResult CancelOrders(
    Symbol symbol,
    TimeInForce timeInForce,
    [CallerMemberName] string sendingSource = null)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    AdvancedTradingOperations.픘 픘 = new AdvancedTradingOperations.픘();
    // ISSUE: reference to a compiler-generated field
    픘.픞픎 = symbol;
    // ISSUE: reference to a compiler-generated field
    픘.픞퓠 = timeInForce;
    LoggerManager loggers = Core.Instance.Loggers;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(80 /*0x50*/, 3);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픅());
    // ISSUE: reference to a compiler-generated field
    interpolatedStringHandler.AppendFormatted<Symbol>(픘.픞픎);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픀());
    // ISSUE: reference to a compiler-generated field
    interpolatedStringHandler.AppendFormatted<TimeInForce>(픘.픞퓠);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픠());
    interpolatedStringHandler.AppendFormatted(sendingSource);
    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
    loggers.Log(stringAndClear);
    GroupTradingOperation tradingOperation = new GroupTradingOperation(GroupTradingOperationType.CancelOrders, GroupTradingOperationFilters.Symbol | GroupTradingOperationFilters.TimeInForce);
    // ISSUE: reference to a compiler-generated method
    return AdvancedTradingOperations.퓏(new Func<IOrder, bool>(픘.퓏), sendingSource, tradingOperation);
  }

  /// <summary>
  /// Cancel all pending <see cref="T:TradingPlatform.BusinessLayer.Order" />s by <see cref="T:TradingPlatform.BusinessLayer.Symbol" />, <see cref="T:TradingPlatform.BusinessLayer.Account" /> and <see cref="T:TradingPlatform.BusinessLayer.TimeInForce" />
  /// </summary>
  /// <param name="symbol"><see cref="T:TradingPlatform.BusinessLayer.Symbol" /></param>
  /// <param name="account"><see cref="T:TradingPlatform.BusinessLayer.Account" /></param>
  /// <param name="timeInForce"><see cref="T:TradingPlatform.BusinessLayer.TimeInForce" /></param>
  /// <param name="sendingSource">the name of the initiator of the call (optional)</param>
  public AdvancedTradingOperationResult CancelOrders(
    Symbol symbol,
    Account account,
    TimeInForce timeInForce,
    [CallerMemberName] string sendingSource = null)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    AdvancedTradingOperations.퓲 퓲 = new AdvancedTradingOperations.퓲();
    // ISSUE: reference to a compiler-generated field
    퓲.픁퓮 = symbol;
    // ISSUE: reference to a compiler-generated field
    퓲.픁픕 = account;
    // ISSUE: reference to a compiler-generated field
    퓲.픁픱 = timeInForce;
    LoggerManager loggers = Core.Instance.Loggers;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(92, 4);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픅());
    // ISSUE: reference to a compiler-generated field
    interpolatedStringHandler.AppendFormatted<Symbol>(퓲.픁퓮);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픕());
    // ISSUE: reference to a compiler-generated field
    interpolatedStringHandler.AppendFormatted<Account>(퓲.픁픕);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픀());
    // ISSUE: reference to a compiler-generated field
    interpolatedStringHandler.AppendFormatted<TimeInForce>(퓲.픁픱);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픠());
    interpolatedStringHandler.AppendFormatted(sendingSource);
    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
    loggers.Log(stringAndClear);
    GroupTradingOperation tradingOperation = new GroupTradingOperation(GroupTradingOperationType.CancelOrders, GroupTradingOperationFilters.Symbol | GroupTradingOperationFilters.Account | GroupTradingOperationFilters.TimeInForce);
    // ISSUE: reference to a compiler-generated method
    return AdvancedTradingOperations.퓏(new Func<IOrder, bool>(퓲.퓏), sendingSource, tradingOperation);
  }

  /// <summary>
  /// Cancel all pending <see cref="T:TradingPlatform.BusinessLayer.Order" />s by <see cref="T:TradingPlatform.BusinessLayer.TimeInForce" />
  /// </summary>
  /// <param name="timeInForce"><see cref="T:TradingPlatform.BusinessLayer.TimeInForce" /></param>
  /// <param name="sendingSource">the name of the initiator of the call (optional)</param>
  public AdvancedTradingOperationResult CancelOrders(TimeInForce timeInForce, [CallerMemberName] string sendingSource = null)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    AdvancedTradingOperations.핂 핂 = new AdvancedTradingOperations.핂();
    // ISSUE: reference to a compiler-generated field
    핂.픁픶 = timeInForce;
    LoggerManager loggers = Core.Instance.Loggers;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(69, 2);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픖());
    // ISSUE: reference to a compiler-generated field
    interpolatedStringHandler.AppendFormatted<TimeInForce>(핂.픁픶);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픠());
    interpolatedStringHandler.AppendFormatted(sendingSource);
    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
    loggers.Log(stringAndClear);
    GroupTradingOperation tradingOperation = new GroupTradingOperation(GroupTradingOperationType.CancelOrders, GroupTradingOperationFilters.TimeInForce);
    // ISSUE: reference to a compiler-generated method
    return AdvancedTradingOperations.퓏(new Func<IOrder, bool>(핂.퓏), sendingSource, tradingOperation);
  }

  /// <summary>
  /// Cancel all pending <see cref="T:TradingPlatform.BusinessLayer.Order" />s by <see cref="T:TradingPlatform.BusinessLayer.Symbol" /> and <see cref="T:TradingPlatform.BusinessLayer.OrderTypeBehavior" />
  /// </summary>
  /// <param name="symbol"><see cref="T:TradingPlatform.BusinessLayer.Symbol" /></param>
  /// <param name="orderTypeBehavior"><see cref="T:TradingPlatform.BusinessLayer.OrderTypeBehavior" /></param>
  /// <param name="sendingSource">the name of the initiator of the call (optional)</param>
  public AdvancedTradingOperationResult CancelOrders(
    Symbol symbol,
    OrderTypeBehavior orderTypeBehavior,
    [CallerMemberName] string sendingSource = null)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    AdvancedTradingOperations.픂 픂 = new AdvancedTradingOperations.픂();
    // ISSUE: reference to a compiler-generated field
    픂.픁픀 = symbol;
    // ISSUE: reference to a compiler-generated field
    픂.픁픖 = orderTypeBehavior;
    LoggerManager loggers = Core.Instance.Loggers;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(77, 3);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픅());
    // ISSUE: reference to a compiler-generated field
    interpolatedStringHandler.AppendFormatted<Symbol>(픂.픁픀);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓘());
    // ISSUE: reference to a compiler-generated field
    interpolatedStringHandler.AppendFormatted<OrderTypeBehavior>(픂.픁픖);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픠());
    interpolatedStringHandler.AppendFormatted(sendingSource);
    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
    loggers.Log(stringAndClear);
    GroupTradingOperation tradingOperation = new GroupTradingOperation(GroupTradingOperationType.CancelOrders, GroupTradingOperationFilters.Symbol | GroupTradingOperationFilters.OrderType);
    // ISSUE: reference to a compiler-generated method
    return AdvancedTradingOperations.퓏(new Func<IOrder, bool>(픂.퓏), sendingSource, tradingOperation);
  }

  /// <summary>
  /// Cancel all pending <see cref="T:TradingPlatform.BusinessLayer.Order" />s by <see cref="T:TradingPlatform.BusinessLayer.Symbol" />, <see cref="T:TradingPlatform.BusinessLayer.Account" /> and <see cref="T:TradingPlatform.BusinessLayer.OrderTypeBehavior" />
  /// </summary>
  /// <param name="symbol"><see cref="T:TradingPlatform.BusinessLayer.Symbol" /></param>
  /// <param name="account"><see cref="T:TradingPlatform.BusinessLayer.Account" /></param>
  /// <param name="orderTypeBehavior"><see cref="T:TradingPlatform.BusinessLayer.OrderTypeBehavior" /></param>
  /// <param name="sendingSource">the name of the initiator of the call (optional)</param>
  public AdvancedTradingOperationResult CancelOrders(
    Symbol symbol,
    Account account,
    OrderTypeBehavior orderTypeBehavior,
    [CallerMemberName] string sendingSource = null)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    AdvancedTradingOperations.픾 픾 = new AdvancedTradingOperations.픾();
    // ISSUE: reference to a compiler-generated field
    픾.픁퓘 = symbol;
    // ISSUE: reference to a compiler-generated field
    픾.픁픓 = account;
    // ISSUE: reference to a compiler-generated field
    픾.픁픩 = orderTypeBehavior;
    LoggerManager loggers = Core.Instance.Loggers;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(98, 4);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픅());
    // ISSUE: reference to a compiler-generated field
    interpolatedStringHandler.AppendFormatted<Symbol>(픾.픁퓘);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픕());
    // ISSUE: reference to a compiler-generated field
    interpolatedStringHandler.AppendFormatted<Account>(픾.픁픓);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픓());
    // ISSUE: reference to a compiler-generated field
    interpolatedStringHandler.AppendFormatted<OrderTypeBehavior>(픾.픁픩);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픠());
    interpolatedStringHandler.AppendFormatted(sendingSource);
    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
    loggers.Log(stringAndClear);
    GroupTradingOperation tradingOperation = new GroupTradingOperation(GroupTradingOperationType.CancelOrders, GroupTradingOperationFilters.Symbol | GroupTradingOperationFilters.Account | GroupTradingOperationFilters.OrderType);
    // ISSUE: reference to a compiler-generated method
    return AdvancedTradingOperations.퓏(new Func<IOrder, bool>(픾.퓏), sendingSource, tradingOperation);
  }

  /// <summary>
  /// Cancel all pending <see cref="T:TradingPlatform.BusinessLayer.Order" />s by <see cref="T:TradingPlatform.BusinessLayer.OrderTypeBehavior" />
  /// </summary>
  /// <param name="orderTypeBehavior"><see cref="T:TradingPlatform.BusinessLayer.OrderTypeBehavior" /></param>
  /// <param name="sendingSource">the name of the initiator of the call (optional)</param>
  public AdvancedTradingOperationResult CancelOrders(
    OrderTypeBehavior orderTypeBehavior,
    [CallerMemberName] string sendingSource = null)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    AdvancedTradingOperations.퓍 퓍 = new AdvancedTradingOperations.퓍();
    // ISSUE: reference to a compiler-generated field
    퓍.픁필 = orderTypeBehavior;
    LoggerManager loggers = Core.Instance.Loggers;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(75, 2);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픩());
    // ISSUE: reference to a compiler-generated field
    interpolatedStringHandler.AppendFormatted<OrderTypeBehavior>(퓍.픁필);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픠());
    interpolatedStringHandler.AppendFormatted(sendingSource);
    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
    loggers.Log(stringAndClear);
    GroupTradingOperation tradingOperation = new GroupTradingOperation(GroupTradingOperationType.CancelOrders, GroupTradingOperationFilters.OrderType);
    // ISSUE: reference to a compiler-generated method
    return AdvancedTradingOperations.퓏(new Func<IOrder, bool>(퓍.퓏), sendingSource, tradingOperation);
  }

  private static AdvancedTradingOperationResult 퓏([In] string obj0_1, [In] GroupTradingOperation obj1)
  {
    Connection[] array = AdvancedTradingOperations.퓏().Select<IOrder, Connection>((Func<IOrder, Connection>) (([In] obj0_2) => obj0_2.Symbol.Connection)).Distinct<Connection>().ToArray<Connection>();
    AdvancedTradingOperationResult tradingOperationResult = new AdvancedTradingOperationResult();
    foreach (Connection connection in array)
      tradingOperationResult.퓏(AdvancedTradingOperations.퓏(connection, obj0_1, obj1));
    return tradingOperationResult;
  }

  private static AdvancedTradingOperationResult 퓏(
    [In] Connection obj0_1,
    [In] string obj1,
    GroupTradingOperation _param2 = null)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    AdvancedTradingOperations.픁 픁 = new AdvancedTradingOperations.픁();
    // ISSUE: reference to a compiler-generated field
    픁.픁퓖 = obj0_1;
    // ISSUE: reference to a compiler-generated field
    bool flag1 = Core.Instance.RulesManager.IsAllowed(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬필(), 픁.픁퓖.Id).Status == TradingOperationStatus.Allowed;
    // ISSUE: reference to a compiler-generated field
    bool flag2 = Core.Instance.RulesManager.IsAllowed(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓖(), 픁.픁퓖.Id).Status == TradingOperationStatus.Allowed;
    // ISSUE: reference to a compiler-generated field
    bool flag3 = Core.Instance.RulesManager.IsAllowed(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픵(), 픁.픁퓖.Id).Status == TradingOperationStatus.Allowed;
    // ISSUE: reference to a compiler-generated method
    IOrder[] array1 = AdvancedTradingOperations.퓏().Where<IOrder>(new Func<IOrder, bool>(픁.퓏)).ToArray<IOrder>();
    Symbol[] array2 = ((IEnumerable<IOrder>) array1).Select<IOrder, Symbol>((Func<IOrder, Symbol>) (([In] obj0_2) => obj0_2.Symbol)).Distinct<Symbol>().ToArray<Symbol>();
    Account[] array3 = ((IEnumerable<IOrder>) array1).Select<IOrder, Account>((Func<IOrder, Account>) (([In] obj0_3) => obj0_3.Account)).Distinct<Account>().ToArray<Account>();
    if (flag1 && (!flag2 || array2.Length <= array3.Length))
    {
      foreach (Symbol symbol in array2)
      {
        // ISSUE: reference to a compiler-generated field
        Connection 픁퓖 = 픁.픁퓖;
        CancelAllOpenOrdersOnSymbolRequest parameters = new CancelAllOpenOrdersOnSymbolRequest(symbol.ComplexId, Array.Empty<string>());
        parameters.ParentOperation = _param2;
        parameters.SendingSource = obj1;
        픁퓖.SendCustomRequest((RequestParameters) parameters);
      }
      return AdvancedTradingOperationResult.퓏();
    }
    if (flag2 && (!flag1 || array2.Length > array3.Length))
    {
      foreach (Account account in array3)
      {
        // ISSUE: reference to a compiler-generated field
        Connection 픁퓖 = 픁.픁퓖;
        CancelAllOpenOrdersOnAccountRequest parameters = new CancelAllOpenOrdersOnAccountRequest(account.Id);
        parameters.ParentOperation = _param2;
        parameters.SendingSource = obj1;
        픁퓖.SendCustomRequest((RequestParameters) parameters);
      }
      return AdvancedTradingOperationResult.퓏();
    }
    if (flag3)
    {
      foreach (AdvancedTradingOperations.퓬 퓬 in ((IEnumerable<IOrder>) array1).Select<IOrder, AdvancedTradingOperations.퓬>((Func<IOrder, AdvancedTradingOperations.퓬>) (([In] obj0_4) => new AdvancedTradingOperations.퓬(obj0_4.Symbol, obj0_4.Account))).Distinct<AdvancedTradingOperations.퓬>().ToArray<AdvancedTradingOperations.퓬>())
      {
        // ISSUE: reference to a compiler-generated field
        Connection 픁퓖 = 픁.픁퓖;
        CancelAllOpenOrdersOnSymbolAndAccountRequest parameters = new CancelAllOpenOrdersOnSymbolAndAccountRequest(퓬.Symbol.ComplexId, 퓬.Account.Id);
        parameters.ParentOperation = _param2;
        parameters.SendingSource = obj1;
        픁퓖.SendCustomRequest((RequestParameters) parameters);
      }
      return AdvancedTradingOperationResult.퓏();
    }
    if ((object) _param2 == null)
      _param2 = new GroupTradingOperation(GroupTradingOperationType.CancelOrders, GroupTradingOperationFilters.Connection);
    // ISSUE: reference to a compiler-generated method
    return AdvancedTradingOperations.퓏(new Func<IOrder, bool>(픁.퓬), obj1, _param2);
  }

  private static AdvancedTradingOperationResult 퓏(
    [In] Symbol obj0_1,
    [In] IOrder[] obj1,
    [In] string obj2,
    [In] GroupTradingOperation obj3)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    AdvancedTradingOperations.픞 픞 = new AdvancedTradingOperations.픞();
    // ISSUE: reference to a compiler-generated field
    픞.픁픵 = obj0_1;
    // ISSUE: reference to a compiler-generated field
    if (픞.픁픵 == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핋());
    // ISSUE: reference to a compiler-generated field
    if (Core.Instance.RulesManager.IsAllowed(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬필(), 픞.픁픵).Status == TradingOperationStatus.Allowed)
    {
      // ISSUE: reference to a compiler-generated field
      Connection connection = 픞.픁픵.Connection;
      // ISSUE: reference to a compiler-generated field
      CancelAllOpenOrdersOnSymbolRequest parameters = new CancelAllOpenOrdersOnSymbolRequest(픞.픁픵.ComplexId, obj1 != null ? ((IEnumerable<IOrder>) obj1).Select<IOrder, string>((Func<IOrder, string>) (([In] obj0_2) => obj0_2.Id)).ToArray<string>() : (string[]) null);
      parameters.ParentOperation = obj3;
      parameters.SendingSource = obj2;
      connection.SendCustomRequest((RequestParameters) parameters);
      return AdvancedTradingOperationResult.퓏();
    }
    // ISSUE: reference to a compiler-generated method
    return obj1 == null || obj1.Length == 0 ? AdvancedTradingOperations.퓏(new Func<IOrder, bool>(픞.퓏), obj2, obj3) : AdvancedTradingOperations.퓏(new Func<IOrder, bool>(((Enumerable) obj1).Contains<IOrder>), obj2, obj3);
  }

  private static AdvancedTradingOperationResult 퓏(
    [In] Symbol obj0,
    [In] Account obj1,
    [In] string obj2,
    [In] GroupTradingOperation obj3)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    AdvancedTradingOperations.핁 핁 = new AdvancedTradingOperations.핁();
    // ISSUE: reference to a compiler-generated field
    핁.픁픬 = obj0;
    // ISSUE: reference to a compiler-generated field
    핁.픁퓕 = obj1;
    // ISSUE: reference to a compiler-generated field
    if (핁.픁픬 == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핋());
    // ISSUE: reference to a compiler-generated field
    if (핁.픁퓕 == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓑());
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated method
    if (Core.Instance.RulesManager.IsAllowed(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픵(), 핁.픁퓕, 핁.픁픬).Status != TradingOperationStatus.Allowed || !((IEnumerable<Order>) Core.Instance.Orders).Any<Order>(new Func<Order, bool>(핁.퓏)))
    {
      // ISSUE: reference to a compiler-generated method
      return AdvancedTradingOperations.퓏(new Func<IOrder, bool>(핁.퓏), obj2, obj3);
    }
    // ISSUE: reference to a compiler-generated field
    Connection connection = 핁.픁픬.Connection;
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    CancelAllOpenOrdersOnSymbolAndAccountRequest parameters = new CancelAllOpenOrdersOnSymbolAndAccountRequest(핁.픁픬.ComplexId, 핁.픁퓕.Id);
    parameters.ParentOperation = obj3;
    parameters.SendingSource = obj2;
    connection.SendCustomRequest((RequestParameters) parameters);
    return AdvancedTradingOperationResult.퓏();
  }

  private static AdvancedTradingOperationResult 퓏(
    [In] Func<IOrder, bool> obj0,
    [In] string obj1,
    [In] GroupTradingOperation obj2)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    AdvancedTradingOperations.픇 픇 = new AdvancedTradingOperations.픇();
    // ISSUE: reference to a compiler-generated field
    픇.픁픐 = obj0;
    AdvancedTradingOperationResult tradingOperationResult1 = new AdvancedTradingOperationResult();
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated method
    foreach (IOrder order in AdvancedTradingOperations.퓏().Where<IOrder>(픇.픁픭 ?? (픇.픁픭 = new Func<IOrder, bool>(픇.퓏))))
    {
      CancelOrderRequestParameters requestParameters = new CancelOrderRequestParameters();
      requestParameters.Order = order;
      requestParameters.SendingSource = obj1;
      requestParameters.ParentOperation = obj2;
      CancelOrderRequestParameters request = requestParameters;
      order.Symbol.Connection.Limitation?.Wait(request.Type, request.CancellationToken);
      TradingOperationResult tradingOperationResult2 = Core.Instance.CancelOrder(request);
      tradingOperationResult1.퓏((RequestParameters) request, tradingOperationResult2);
    }
    return tradingOperationResult1;
  }

  private static IEnumerable<IOrder> 퓏()
  {
    return Core.Instance.Orders.OfType<IOrder>().Concat<IOrder>((IEnumerable<IOrder>) Core.Instance.LocalOrders);
  }

  /// <summary>
  /// Close all <see cref="T:TradingPlatform.BusinessLayer.Position" />s
  /// </summary>
  /// <param name="sendingSource">the name of the initiator of the call (optional)</param>
  /// <returns>List of <see cref="T:TradingPlatform.BusinessLayer.TradingOperationResult" /></returns>
  public AdvancedTradingOperationResult ClosePositions([CallerMemberName] string sendingSource = null)
  {
    Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픬() + sendingSource);
    GroupTradingOperation tradingOperation = new GroupTradingOperation(GroupTradingOperationType.ClosePositions, GroupTradingOperationFilters.None);
    return AdvancedTradingOperations.퓬(sendingSource, tradingOperation);
  }

  /// <summary>
  /// Close all <see cref="T:TradingPlatform.BusinessLayer.Position" />s by <see cref="T:TradingPlatform.BusinessLayer.Symbol" />
  /// </summary>
  /// <param name="symbol"><see cref="T:TradingPlatform.BusinessLayer.Symbol" /></param>
  /// <param name="sendingSource">the name of the initiator of the call (optional)</param>
  /// <returns>List of <see cref="T:TradingPlatform.BusinessLayer.TradingOperationResult" /></returns>
  public AdvancedTradingOperationResult ClosePositions(Symbol symbol, [CallerMemberName] string sendingSource = null)
  {
    LoggerManager loggers = Core.Instance.Loggers;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(64 /*0x40*/, 2);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓕());
    interpolatedStringHandler.AppendFormatted<Symbol>(symbol);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픠());
    interpolatedStringHandler.AppendFormatted(sendingSource);
    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
    loggers.Log(stringAndClear);
    GroupTradingOperation tradingOperation = new GroupTradingOperation(GroupTradingOperationType.ClosePositions, GroupTradingOperationFilters.Symbol);
    return AdvancedTradingOperations.퓏(symbol, sendingSource, tradingOperation);
  }

  /// <summary>
  /// Close all <see cref="T:TradingPlatform.BusinessLayer.Position" />s by <see cref="T:TradingPlatform.BusinessLayer.Account" />
  /// </summary>
  /// <param name="account"><see cref="T:TradingPlatform.BusinessLayer.Account" /></param>
  /// <param name="sendingSource">the name of the initiator of the call (optional)</param>
  /// <returns>List of <see cref="T:TradingPlatform.BusinessLayer.TradingOperationResult" /></returns>
  public AdvancedTradingOperationResult ClosePositions(Account account, [CallerMemberName] string sendingSource = null)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    AdvancedTradingOperations.픣 픣 = new AdvancedTradingOperations.픣();
    // ISSUE: reference to a compiler-generated field
    픣.픁픔 = account;
    LoggerManager loggers = Core.Instance.Loggers;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(65, 2);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픐());
    // ISSUE: reference to a compiler-generated field
    interpolatedStringHandler.AppendFormatted<Account>(픣.픁픔);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픠());
    interpolatedStringHandler.AppendFormatted(sendingSource);
    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
    loggers.Log(stringAndClear);
    GroupTradingOperation tradingOperation = new GroupTradingOperation(GroupTradingOperationType.ClosePositions, GroupTradingOperationFilters.Account);
    // ISSUE: reference to a compiler-generated method
    return AdvancedTradingOperations.핇(new Func<Position, bool>(픣.퓏), sendingSource, tradingOperation);
  }

  /// <summary>
  /// Close all <see cref="T:TradingPlatform.BusinessLayer.Position" />s by <see cref="T:TradingPlatform.BusinessLayer.Symbol" /> and <see cref="T:TradingPlatform.BusinessLayer.Account" />
  /// </summary>
  /// <param name="symbol"><see cref="T:TradingPlatform.BusinessLayer.Symbol" /></param>
  /// <param name="account"><see cref="T:TradingPlatform.BusinessLayer.Account" /></param>
  /// <param name="sendingSource">the name of the initiator of the call (optional)</param>
  /// <returns>List of <see cref="T:TradingPlatform.BusinessLayer.TradingOperationResult" /></returns>
  public AdvancedTradingOperationResult ClosePositions(
    Symbol symbol,
    Account account,
    [CallerMemberName] string sendingSource = null)
  {
    LoggerManager loggers = Core.Instance.Loggers;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(76, 3);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓕());
    interpolatedStringHandler.AppendFormatted<Symbol>(symbol);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픕());
    interpolatedStringHandler.AppendFormatted<Account>(account);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픠());
    interpolatedStringHandler.AppendFormatted(sendingSource);
    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
    loggers.Log(stringAndClear);
    GroupTradingOperation tradingOperation = new GroupTradingOperation(GroupTradingOperationType.ClosePositions, GroupTradingOperationFilters.Symbol | GroupTradingOperationFilters.Account);
    return AdvancedTradingOperations.퓬(symbol, account, sendingSource, tradingOperation);
  }

  /// <summary>
  /// Close all <see cref="T:TradingPlatform.BusinessLayer.Position" />s by <see cref="T:TradingPlatform.BusinessLayer.Side" />
  /// </summary>
  /// <param name="side"><see cref="T:TradingPlatform.BusinessLayer.Side" /></param>
  /// <param name="sendingSource">the name of the initiator of the call (optional)</param>
  /// <returns>List of <see cref="T:TradingPlatform.BusinessLayer.TradingOperationResult" /></returns>
  public AdvancedTradingOperationResult ClosePositions(Side side, [CallerMemberName] string sendingSource = null)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    AdvancedTradingOperations.퓙 퓙 = new AdvancedTradingOperations.퓙();
    // ISSUE: reference to a compiler-generated field
    퓙.픁핈 = side;
    LoggerManager loggers = Core.Instance.Loggers;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(62, 2);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픭());
    // ISSUE: reference to a compiler-generated field
    interpolatedStringHandler.AppendFormatted<Side>(퓙.픁핈);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픠());
    interpolatedStringHandler.AppendFormatted(sendingSource);
    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
    loggers.Log(stringAndClear);
    GroupTradingOperation tradingOperation = new GroupTradingOperation(GroupTradingOperationType.ClosePositions, GroupTradingOperationFilters.Side);
    // ISSUE: reference to a compiler-generated method
    return AdvancedTradingOperations.핇(new Func<Position, bool>(퓙.퓏), sendingSource, tradingOperation);
  }

  /// <summary>
  /// Close all <see cref="T:TradingPlatform.BusinessLayer.Position" />s by <see cref="T:TradingPlatform.BusinessLayer.Symbol" /> and <see cref="T:TradingPlatform.BusinessLayer.Side" />
  /// </summary>
  /// <param name="symbol"><see cref="T:TradingPlatform.BusinessLayer.Symbol" /></param>
  /// <param name="side"><see cref="T:TradingPlatform.BusinessLayer.Side" /></param>
  /// <param name="sendingSource">the name of the initiator of the call (optional)</param>
  /// <returns>List of <see cref="T:TradingPlatform.BusinessLayer.TradingOperationResult" /></returns>
  public AdvancedTradingOperationResult ClosePositions(
    Symbol symbol,
    Side side,
    [CallerMemberName] string sendingSource = null)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    AdvancedTradingOperations.퓗 퓗 = new AdvancedTradingOperations.퓗();
    // ISSUE: reference to a compiler-generated field
    퓗.픁픤 = symbol;
    // ISSUE: reference to a compiler-generated field
    퓗.픁퓟 = side;
    LoggerManager loggers = Core.Instance.Loggers;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(73, 3);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓕());
    // ISSUE: reference to a compiler-generated field
    interpolatedStringHandler.AppendFormatted<Symbol>(퓗.픁픤);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픱());
    // ISSUE: reference to a compiler-generated field
    interpolatedStringHandler.AppendFormatted<Side>(퓗.픁퓟);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픠());
    interpolatedStringHandler.AppendFormatted(sendingSource);
    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
    loggers.Log(stringAndClear);
    GroupTradingOperation tradingOperation = new GroupTradingOperation(GroupTradingOperationType.ClosePositions, GroupTradingOperationFilters.Symbol | GroupTradingOperationFilters.Side);
    // ISSUE: reference to a compiler-generated method
    return AdvancedTradingOperations.핇(new Func<Position, bool>(퓗.퓏), sendingSource, tradingOperation);
  }

  /// <summary>
  /// Close all positive <see cref="T:TradingPlatform.BusinessLayer.Position" />s
  /// </summary>
  /// <param name="sendingSource">the name of the initiator of the call (optional)</param>
  /// <returns>List of <see cref="T:TradingPlatform.BusinessLayer.TradingOperationResult" /></returns>
  public AdvancedTradingOperationResult ClosePositivePositions([CallerMemberName] string sendingSource = null)
  {
    Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픔() + sendingSource);
    GroupTradingOperation tradingOperation = new GroupTradingOperation(GroupTradingOperationType.ClosePositions, GroupTradingOperationFilters.None);
    return AdvancedTradingOperations.퓏((Func<Position, bool>) delegate
    {
      return true;
    }, sendingSource, tradingOperation);
  }

  /// <summary>
  /// Close all positive <see cref="T:TradingPlatform.BusinessLayer.Position" />s by <see cref="T:TradingPlatform.BusinessLayer.Symbol" />
  /// </summary>
  /// <param name="symbol"><see cref="T:TradingPlatform.BusinessLayer.Symbol" /></param>
  /// <param name="sendingSource">the name of the initiator of the call (optional)</param>
  /// <returns>List of <see cref="T:TradingPlatform.BusinessLayer.TradingOperationResult" /></returns>
  public AdvancedTradingOperationResult ClosePositivePositions(Symbol symbol, [CallerMemberName] string sendingSource = null)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    AdvancedTradingOperations.픎 픎 = new AdvancedTradingOperations.픎();
    // ISSUE: reference to a compiler-generated field
    픎.픁핉 = symbol;
    LoggerManager loggers = Core.Instance.Loggers;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(73, 2);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬핈());
    // ISSUE: reference to a compiler-generated field
    interpolatedStringHandler.AppendFormatted<Symbol>(픎.픁핉);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픠());
    interpolatedStringHandler.AppendFormatted(sendingSource);
    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
    loggers.Log(stringAndClear);
    GroupTradingOperation tradingOperation = new GroupTradingOperation(GroupTradingOperationType.ClosePositions, GroupTradingOperationFilters.Symbol);
    // ISSUE: reference to a compiler-generated method
    return AdvancedTradingOperations.퓏(new Func<Position, bool>(픎.퓏), sendingSource, tradingOperation);
  }

  /// <summary>
  /// Close all negative <see cref="T:TradingPlatform.BusinessLayer.Position" />s
  /// </summary>
  /// <param name="sendingSource">the name of the initiator of the call (optional)</param>
  /// <returns>List of <see cref="T:TradingPlatform.BusinessLayer.TradingOperationResult" /></returns>
  public AdvancedTradingOperationResult CloseNegativePositions([CallerMemberName] string sendingSource = null)
  {
    Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픤() + sendingSource);
    GroupTradingOperation tradingOperation = new GroupTradingOperation(GroupTradingOperationType.ClosePositions, GroupTradingOperationFilters.None);
    return AdvancedTradingOperations.퓬((Func<Position, bool>) delegate
    {
      return true;
    }, sendingSource, tradingOperation);
  }

  /// <summary>
  /// Close all negative <see cref="T:TradingPlatform.BusinessLayer.Position" />s by <see cref="T:TradingPlatform.BusinessLayer.Symbol" />
  /// </summary>
  /// <param name="symbol"><see cref="T:TradingPlatform.BusinessLayer.Symbol" /></param>
  /// <param name="sendingSource">the name of the initiator of the call (optional)</param>
  /// <returns>List of <see cref="T:TradingPlatform.BusinessLayer.TradingOperationResult" /></returns>
  public AdvancedTradingOperationResult CloseNegativePositions(Symbol symbol, [CallerMemberName] string sendingSource = null)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    AdvancedTradingOperations.퓠 퓠 = new AdvancedTradingOperations.퓠();
    // ISSUE: reference to a compiler-generated field
    퓠.픁핊 = symbol;
    LoggerManager loggers = Core.Instance.Loggers;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(73, 2);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓟());
    // ISSUE: reference to a compiler-generated field
    interpolatedStringHandler.AppendFormatted<Symbol>(퓠.픁핊);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픠());
    interpolatedStringHandler.AppendFormatted(sendingSource);
    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
    loggers.Log(stringAndClear);
    GroupTradingOperation tradingOperation = new GroupTradingOperation(GroupTradingOperationType.ClosePositions, GroupTradingOperationFilters.Symbol);
    // ISSUE: reference to a compiler-generated method
    return AdvancedTradingOperations.퓬(new Func<Position, bool>(퓠.퓏), sendingSource, tradingOperation);
  }

  private static AdvancedTradingOperationResult 퓏(
    [In] Symbol obj0,
    [In] string obj1,
    [In] GroupTradingOperation obj2)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: reference to a compiler-generated method
    return AdvancedTradingOperations.핇(new Func<Position, bool>(new AdvancedTradingOperations.퓥()
    {
      픁픛 = obj0
    }.퓏), obj1, obj2);
  }

  private static AdvancedTradingOperationResult 퓬(
    [In] Symbol obj0,
    [In] Account obj1,
    [In] string obj2,
    [In] GroupTradingOperation obj3)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: reference to a compiler-generated method
    return AdvancedTradingOperations.핇(new Func<Position, bool>(new AdvancedTradingOperations.퓯()
    {
      픁퓜 = obj0,
      픁픺 = obj1
    }.퓏), obj2, obj3);
  }

  private static AdvancedTradingOperationResult 퓬([In] string obj0, [In] GroupTradingOperation obj1)
  {
    return AdvancedTradingOperations.핇((Func<Position, bool>) delegate
    {
      return true;
    }, obj0, obj1);
  }

  private static AdvancedTradingOperationResult 퓏(
    [In] Func<Position, bool> obj0,
    [In] string obj1,
    [In] GroupTradingOperation obj2)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: reference to a compiler-generated method
    return AdvancedTradingOperations.핇(new Func<Position, bool>(new AdvancedTradingOperations.픜()
    {
      픁핃 = obj0
    }.퓏), obj1, obj2);
  }

  private static AdvancedTradingOperationResult 퓬(
    [In] Func<Position, bool> obj0,
    [In] string obj1,
    [In] GroupTradingOperation obj2)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: reference to a compiler-generated method
    return AdvancedTradingOperations.핇(new Func<Position, bool>(new AdvancedTradingOperations.퓑()
    {
      픁퓫 = obj0
    }.퓏), obj1, obj2);
  }

  private static AdvancedTradingOperationResult 핇(
    [In] Func<Position, bool> obj0,
    [In] string obj1,
    [In] GroupTradingOperation obj2)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    AdvancedTradingOperations.핋 핋 = new AdvancedTradingOperations.핋();
    // ISSUE: reference to a compiler-generated field
    핋.픁핌 = obj0;
    AdvancedTradingOperationResult tradingOperationResult1 = new AdvancedTradingOperationResult();
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated method
    foreach (Position position in ((IEnumerable<Position>) Core.Instance.Positions).Where<Position>(핋.픁퓩 ?? (핋.픁퓩 = new Func<Position, bool>(핋.퓏))))
    {
      ClosePositionRequestParameters requestParameters = new ClosePositionRequestParameters();
      requestParameters.Position = position;
      requestParameters.CloseQuantity = position.Quantity;
      requestParameters.SendingSource = obj1;
      requestParameters.ParentOperation = obj2;
      ClosePositionRequestParameters request = requestParameters;
      TradingOperationResult tradingOperationResult2 = Core.Instance.ClosePosition(request);
      tradingOperationResult1.퓏((RequestParameters) request, tradingOperationResult2);
    }
    return tradingOperationResult1;
  }

  /// <summary>
  /// Reverse all <see cref="T:TradingPlatform.BusinessLayer.Position" />s
  /// </summary>
  /// <param name="sendingSource">the name of the initiator of the call (optional)</param>
  /// <returns>List of <see cref="T:TradingPlatform.BusinessLayer.TradingOperationResult" /></returns>
  public AdvancedTradingOperationResult ReversePositions([CallerMemberName] string sendingSource = null)
  {
    Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬핉() + sendingSource);
    GroupTradingOperation tradingOperation = new GroupTradingOperation(GroupTradingOperationType.ReversePositions, GroupTradingOperationFilters.None);
    return AdvancedTradingOperations.퓲((Func<Position, bool>) delegate
    {
      return true;
    }, sendingSource, tradingOperation);
  }

  /// <summary>
  /// Reverse all <see cref="T:TradingPlatform.BusinessLayer.Position" />s by <see cref="T:TradingPlatform.BusinessLayer.Symbol" />
  /// </summary>
  /// <param name="symbol"><see cref="T:TradingPlatform.BusinessLayer.Symbol" /></param>
  /// <param name="sendingSource">the name of the initiator of the call (optional)</param>
  /// <returns>List of <see cref="T:TradingPlatform.BusinessLayer.TradingOperationResult" /></returns>
  public AdvancedTradingOperationResult ReversePositions(Symbol symbol, [CallerMemberName] string sendingSource = null)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    AdvancedTradingOperations.퓞 퓞 = new AdvancedTradingOperations.퓞();
    // ISSUE: reference to a compiler-generated field
    퓞.픁퓨 = symbol;
    LoggerManager loggers = Core.Instance.Loggers;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(66, 2);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬핊());
    // ISSUE: reference to a compiler-generated field
    interpolatedStringHandler.AppendFormatted<Symbol>(퓞.픁퓨);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픠());
    interpolatedStringHandler.AppendFormatted(sendingSource);
    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
    loggers.Log(stringAndClear);
    GroupTradingOperation tradingOperation = new GroupTradingOperation(GroupTradingOperationType.ReversePositions, GroupTradingOperationFilters.Symbol);
    // ISSUE: reference to a compiler-generated method
    return AdvancedTradingOperations.퓲(new Func<Position, bool>(퓞.퓏), sendingSource, tradingOperation);
  }

  /// <summary>
  /// Reverse all <see cref="T:TradingPlatform.BusinessLayer.Position" />s by <see cref="T:TradingPlatform.BusinessLayer.Account" />
  /// </summary>
  /// <param name="account"><see cref="T:TradingPlatform.BusinessLayer.Account" /></param>
  /// <param name="sendingSource">the name of the initiator of the call (optional)</param>
  /// <returns>List of <see cref="T:TradingPlatform.BusinessLayer.TradingOperationResult" /></returns>
  public AdvancedTradingOperationResult ReversePositions(Account account, [CallerMemberName] string sendingSource = null)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    AdvancedTradingOperations.핅 핅 = new AdvancedTradingOperations.핅();
    // ISSUE: reference to a compiler-generated field
    핅.픁퓱 = account;
    LoggerManager loggers = Core.Instance.Loggers;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(67, 2);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픛());
    // ISSUE: reference to a compiler-generated field
    interpolatedStringHandler.AppendFormatted<Account>(핅.픁퓱);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픠());
    interpolatedStringHandler.AppendFormatted(sendingSource);
    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
    loggers.Log(stringAndClear);
    GroupTradingOperation tradingOperation = new GroupTradingOperation(GroupTradingOperationType.ReversePositions, GroupTradingOperationFilters.Account);
    // ISSUE: reference to a compiler-generated method
    return AdvancedTradingOperations.퓲(new Func<Position, bool>(핅.퓏), sendingSource, tradingOperation);
  }

  /// <summary>
  /// Reverse <see cref="T:TradingPlatform.BusinessLayer.Position" /> by <see cref="T:TradingPlatform.BusinessLayer.Symbol" /> and <see cref="T:TradingPlatform.BusinessLayer.Account" />
  /// </summary>
  /// <param name="symbol"><see cref="T:TradingPlatform.BusinessLayer.Symbol" /></param>
  /// <param name="account"><see cref="T:TradingPlatform.BusinessLayer.Account" /></param>
  /// <param name="sendingSource">the name of the initiator of the call (optional)</param>
  /// <returns><see cref="T:TradingPlatform.BusinessLayer.TradingOperationResult" /></returns>
  public AdvancedTradingOperationResult ReversePosition(
    Symbol symbol,
    Account account,
    [CallerMemberName] string sendingSource = null)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    AdvancedTradingOperations.픡 픡 = new AdvancedTradingOperations.픡();
    // ISSUE: reference to a compiler-generated field
    픡.픁픹 = symbol;
    // ISSUE: reference to a compiler-generated field
    픡.픁퓺 = account;
    LoggerManager loggers = Core.Instance.Loggers;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(78, 3);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬핊());
    // ISSUE: reference to a compiler-generated field
    interpolatedStringHandler.AppendFormatted<Symbol>(픡.픁픹);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픕());
    // ISSUE: reference to a compiler-generated field
    interpolatedStringHandler.AppendFormatted<Account>(픡.픁퓺);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픠());
    interpolatedStringHandler.AppendFormatted(sendingSource);
    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
    loggers.Log(stringAndClear);
    GroupTradingOperation tradingOperation = new GroupTradingOperation(GroupTradingOperationType.ReversePositions, GroupTradingOperationFilters.Symbol | GroupTradingOperationFilters.Account);
    // ISSUE: reference to a compiler-generated method
    return AdvancedTradingOperations.퓲(new Func<Position, bool>(픡.퓏), sendingSource, tradingOperation);
  }

  private static AdvancedTradingOperationResult 퓲(
    [In] Func<Position, bool> obj0_1,
    [In] string obj1,
    [In] GroupTradingOperation obj2)
  {
    AdvancedTradingOperationResult tradingOperationResult1 = new AdvancedTradingOperationResult();
    try
    {
      foreach (Position position in Core.Instance.Positions)
      {
        if ((position.Symbol.NettingType == NettingType.OnePosition || position.Symbol.NettingType == NettingType.Undefined || position.Account.NettingType == NettingType.OnePosition) && (obj0_1 == null || obj0_1(position)))
        {
          OrderType[] orderTypes = Core.Instance.Connections[position.ConnectionId]?.BusinessObjects?.OrderTypes;
          OrderType orderType = orderTypes != null ? ((IEnumerable<OrderType>) orderTypes).FirstOrDefault<OrderType>((Func<OrderType, bool>) (([In] obj0_2) => obj0_2.Behavior == OrderTypeBehavior.Market && (obj0_2.Usage & OrderTypeUsage.Order) == OrderTypeUsage.Order)) : (OrderType) null;
          if (orderType != null)
          {
            PlaceOrderRequestParameters requestParameters = new PlaceOrderRequestParameters();
            requestParameters.Account = position.Account;
            requestParameters.Symbol = position.Symbol;
            requestParameters.OrderTypeId = orderType.Id;
            requestParameters.Quantity = position.Quantity * 2.0;
            requestParameters.TimeInForce = TimeInForce.Default;
            requestParameters.Side = position.Side == Side.Buy ? Side.Sell : Side.Buy;
            requestParameters.SendingSource = obj1;
            requestParameters.ParentOperation = obj2;
            PlaceOrderRequestParameters request = requestParameters;
            TradingOperationResult tradingOperationResult2 = Core.Instance.PlaceOrder(request);
            tradingOperationResult1.퓏((RequestParameters) request, tradingOperationResult2);
          }
        }
      }
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
    return tradingOperationResult1;
  }

  /// <summary>
  /// Cancel all <see cref="T:TradingPlatform.BusinessLayer.Order" />s and close all <see cref="T:TradingPlatform.BusinessLayer.Position" />s
  /// </summary>
  /// <param name="sendingSource">the name of the initiator of the call (optional)</param>
  public AdvancedTradingOperationResult Flatten([CallerMemberName] string sendingSource = null)
  {
    Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓜() + sendingSource);
    AdvancedTradingOperationResult tradingOperationResult = new AdvancedTradingOperationResult();
    GroupTradingOperation tradingOperation = new GroupTradingOperation(GroupTradingOperationType.Flatten, GroupTradingOperationFilters.None);
    tradingOperationResult.퓏(AdvancedTradingOperations.퓏(sendingSource, tradingOperation));
    AdvancedTradingOperations.퓏((Symbol) null, (Account) null);
    tradingOperationResult.퓏(AdvancedTradingOperations.퓬(sendingSource, tradingOperation));
    return tradingOperationResult;
  }

  /// <summary>
  /// Cancel all <see cref="T:TradingPlatform.BusinessLayer.Order" />s and close all <see cref="T:TradingPlatform.BusinessLayer.Position" />s by <see cref="T:TradingPlatform.BusinessLayer.Symbol" />
  /// </summary>
  /// <param name="symbol"><see cref="T:TradingPlatform.BusinessLayer.Symbol" /></param>
  /// <param name="sendingSource">the name of the initiator of the call (optional)</param>
  public AdvancedTradingOperationResult Flatten(Symbol symbol, [CallerMemberName] string sendingSource = null)
  {
    LoggerManager loggers = Core.Instance.Loggers;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(56, 2);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픺());
    interpolatedStringHandler.AppendFormatted<Symbol>(symbol);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픠());
    interpolatedStringHandler.AppendFormatted(sendingSource);
    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
    loggers.Log(stringAndClear);
    AdvancedTradingOperationResult tradingOperationResult = new AdvancedTradingOperationResult();
    GroupTradingOperation tradingOperation = new GroupTradingOperation(GroupTradingOperationType.Flatten, GroupTradingOperationFilters.Symbol);
    tradingOperationResult.퓏(AdvancedTradingOperations.퓏(symbol, Array.Empty<IOrder>(), sendingSource, tradingOperation));
    AdvancedTradingOperations.퓏(symbol);
    tradingOperationResult.퓏(AdvancedTradingOperations.퓏(symbol, sendingSource, tradingOperation));
    return tradingOperationResult;
  }

  /// <summary>
  /// Cancel all <see cref="T:TradingPlatform.BusinessLayer.Order" />s and close all <see cref="T:TradingPlatform.BusinessLayer.Position" />s by <see cref="T:TradingPlatform.BusinessLayer.Symbol" /> and <see cref="T:TradingPlatform.BusinessLayer.Account" />
  /// </summary>
  /// <param name="symbol"><see cref="T:TradingPlatform.BusinessLayer.Symbol" /></param>
  /// <param name="account"><see cref="T:TradingPlatform.BusinessLayer.Account" /></param>
  /// <param name="sendingSource">the name of the initiator of the call (optional)</param>
  public AdvancedTradingOperationResult Flatten(
    Symbol symbol,
    Account account,
    [CallerMemberName] string sendingSource = null)
  {
    LoggerManager loggers = Core.Instance.Loggers;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(68, 3);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픺());
    interpolatedStringHandler.AppendFormatted<Symbol>(symbol);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픕());
    interpolatedStringHandler.AppendFormatted<Account>(account);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픠());
    interpolatedStringHandler.AppendFormatted(sendingSource);
    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
    loggers.Log(stringAndClear);
    AdvancedTradingOperationResult tradingOperationResult = new AdvancedTradingOperationResult();
    GroupTradingOperation tradingOperation = new GroupTradingOperation(GroupTradingOperationType.Flatten, GroupTradingOperationFilters.Symbol | GroupTradingOperationFilters.Account);
    tradingOperationResult.퓏(AdvancedTradingOperations.퓏(symbol, account, sendingSource, tradingOperation));
    AdvancedTradingOperations.퓏(symbol, account);
    tradingOperationResult.퓏(AdvancedTradingOperations.퓬(symbol, account, sendingSource, tradingOperation));
    return tradingOperationResult;
  }

  private static void 퓏(Symbol _param0 = null, Account _param1 = null)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    AdvancedTradingOperations.픏 픏 = new AdvancedTradingOperations.픏();
    // ISSUE: reference to a compiler-generated field
    픏.픁픊 = _param0;
    // ISSUE: reference to a compiler-generated field
    픏.픁픈 = _param1;
    try
    {
      CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5.0));
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      while (!cancellationTokenSource.IsCancellationRequested && (픏.픁픊 == null || 픏.픁픈 == null ? (픏.픁픊 == null ? Core.Instance.Orders.Length : ((IEnumerable<Order>) Core.Instance.Orders).Count<Order>(픏.픁퓚 ?? (픏.픁퓚 = new Func<Order, bool>(픏.퓬)))) : ((IEnumerable<Order>) Core.Instance.Orders).Count<Order>(픏.픁퓒 ?? (픏.픁퓒 = new Func<Order, bool>(픏.퓏)))) != 0)
        Task.Delay(50, cancellationTokenSource.Token).Wait(cancellationTokenSource.Token);
      if (!cancellationTokenSource.IsCancellationRequested)
        return;
      Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬핃());
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
  }

  /// <summary>Modify SL to breakeven price</summary>
  /// <param name="position"><see cref="T:TradingPlatform.BusinessLayer.Position" /></param>
  /// <param name="sendingSource">the name of the initiator of the call (optional)</param>
  public AdvancedTradingOperationResult BreakEven(Position position, [CallerMemberName] string sendingSource = null)
  {
    LoggerManager loggers = Core.Instance.Loggers;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(60, 2);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓫());
    interpolatedStringHandler.AppendFormatted<Position>(position);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픠());
    interpolatedStringHandler.AppendFormatted(sendingSource);
    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
    loggers.Log(stringAndClear);
    return AdvancedTradingOperations.퓏(position, 0, (IList<SettingItem>) null, sendingSource);
  }

  /// <summary>
  /// Modify SL to breakeven price with certain additional offset
  /// </summary>
  /// <param name="position"><see cref="T:TradingPlatform.BusinessLayer.Position" /></param>
  /// <param name="offset">offset in ticks</param>
  /// <param name="sendingSource">the name of the initiator of the call (optional)</param>
  public AdvancedTradingOperationResult BreakEven(
    Position position,
    int offset,
    [CallerMemberName] string sendingSource = null)
  {
    LoggerManager loggers = Core.Instance.Loggers;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(71, 3);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓫());
    interpolatedStringHandler.AppendFormatted<Position>(position);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬핌());
    interpolatedStringHandler.AppendFormatted<int>(offset);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픠());
    interpolatedStringHandler.AppendFormatted(sendingSource);
    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
    loggers.Log(stringAndClear);
    return AdvancedTradingOperations.퓏(position, offset, (IList<SettingItem>) null, sendingSource);
  }

  /// <summary>Modify SL to breakeven price</summary>
  /// <param name="position"><see cref="T:TradingPlatform.BusinessLayer.Position" /></param>
  /// <param name="additionalParameters">list of <see cref="T:TradingPlatform.BusinessLayer.SettingItem" />s that will be used for order placing</param>
  /// <param name="sendingSource">the name of the initiator of the call (optional)</param>
  public AdvancedTradingOperationResult BreakEven(
    Position position,
    IList<SettingItem> additionalParameters,
    [CallerMemberName] string sendingSource = null)
  {
    LoggerManager loggers = Core.Instance.Loggers;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(92, 3);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓫());
    interpolatedStringHandler.AppendFormatted<Position>(position);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓩());
    interpolatedStringHandler.AppendFormatted<int?>(additionalParameters?.Count);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픠());
    interpolatedStringHandler.AppendFormatted(sendingSource);
    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
    loggers.Log(stringAndClear);
    return AdvancedTradingOperations.퓏(position, 0, additionalParameters, sendingSource);
  }

  private static AdvancedTradingOperationResult 퓏(
    [In] Position obj0_1,
    [In] int obj1,
    [In] IList<SettingItem> obj2,
    [In] string obj3)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    AdvancedTradingOperations.퓳 퓳 = new AdvancedTradingOperations.퓳();
    // ISSUE: reference to a compiler-generated field
    퓳.픁픃 = obj0_1;
    // ISSUE: reference to a compiler-generated field
    if (퓳.픁픃 == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓨());
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    if (퓳.픁픃.Symbol.NettingType == NettingType.OnePosition || 퓳.픁픃.Account.NettingType == NettingType.OnePosition)
    {
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      return AdvancedTradingOperations.퓏(퓳.픁픃.Symbol, 퓳.픁픃.Account, obj1, obj2, obj3);
    }
    // ISSUE: reference to a compiler-generated field
    double price2 = AdvancedTradingOperations.퓏(퓳.픁픃, obj1);
    // ISSUE: reference to a compiler-generated field
    double currentPrice = 퓳.픁픃.CurrentPrice;
    // ISSUE: reference to a compiler-generated method
    Order order = ((IEnumerable<Order>) Core.Instance.Orders).Where<Order>(new Func<Order, bool>(퓳.퓏)).FirstOrDefault<Order>((Func<Order, bool>) (([In] obj0_2) =>
    {
      bool flag;
      switch (obj0_2.OrderType.Behavior)
      {
        case OrderTypeBehavior.Stop:
        case OrderTypeBehavior.TrailingStop:
          flag = true;
          break;
        default:
          flag = false;
          break;
      }
      return flag;
    }));
    if (order == null)
      return AdvancedTradingOperationResult.퓏(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓱());
    ModifyOrderRequestParameters request = new ModifyOrderRequestParameters((IOrder) order);
    if (order.OrderType.Behavior == OrderTypeBehavior.TrailingStop)
    {
      // ISSUE: reference to a compiler-generated field
      double ticks = 퓳.픁픃.Symbol.CalculateTicks(currentPrice, price2);
      request.TrailOffset = ticks;
    }
    else
      request.TriggerPrice = price2;
    request.SendingSource = obj3;
    TradingOperationResult tradingOperationResult = Core.Instance.ModifyOrder(request);
    return new AdvancedTradingOperationResult((RequestParameters) request, tradingOperationResult);
  }

  private static AdvancedTradingOperationResult 퓏(
    [In] Symbol obj0_1,
    [In] Account obj1,
    [In] int obj2,
    [In] IList<SettingItem> obj3,
    [In] string obj4)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    AdvancedTradingOperations.픷 픷 = new AdvancedTradingOperations.픷();
    // ISSUE: reference to a compiler-generated field
    픷.픁피 = obj0_1;
    // ISSUE: reference to a compiler-generated field
    픷.픁퓸 = obj1;
    // ISSUE: reference to a compiler-generated field
    if (픷.픁피 == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핋());
    // ISSUE: reference to a compiler-generated field
    if (픷.픁퓸 == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓑());
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    if (픷.픁피.NettingType != NettingType.OnePosition && 픷.픁퓸.NettingType != NettingType.OnePosition)
      return AdvancedTradingOperationResult.퓏(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픹());
    // ISSUE: reference to a compiler-generated field
    OrderType orderType = ((IEnumerable<OrderType>) 픷.픁피.Connection.BusinessObjects.OrderTypes).FirstOrDefault<OrderType>((Func<OrderType, bool>) (([In] obj0_2) => obj0_2.Behavior == OrderTypeBehavior.Stop));
    if (orderType == null)
      return AdvancedTradingOperationResult.퓏(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓺());
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated method
    픷.픁퓦 = ((IEnumerable<Position>) Core.Instance.Positions).FirstOrDefault<Position>(new Func<Position, bool>(픷.퓏));
    // ISSUE: reference to a compiler-generated field
    if (픷.픁퓦 == null)
      return AdvancedTradingOperationResult.퓏(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픊());
    AdvancedTradingOperationResult tradingOperationResult1 = new AdvancedTradingOperationResult();
    try
    {
      // ISSUE: reference to a compiler-generated method
      Order[] array = ((IEnumerable<Order>) Core.Instance.Orders).Where<Order>(new Func<Order, bool>(픷.퓏)).ToArray<Order>();
      // ISSUE: reference to a compiler-generated method
      Order order1 = ((IEnumerable<Order>) array).FirstOrDefault<Order>(new Func<Order, bool>(픷.퓬));
      if (order1 != null && !((IEnumerable<Order>) array).Any<Order>((Func<Order, bool>) (([In] obj0_5) => string.IsNullOrEmpty(obj0_5.GroupId))) && ((IEnumerable<Order>) array).GroupBy<Order, string>((Func<Order, string>) (([In] obj0_6) => obj0_6.GroupId)).Count<IGrouping<string, Order>>() == 1)
      {
        ModifyOrderRequestParameters requestParameters = new ModifyOrderRequestParameters((IOrder) order1);
        // ISSUE: reference to a compiler-generated field
        requestParameters.TriggerPrice = AdvancedTradingOperations.퓏(픷.픁퓦, obj2);
        requestParameters.SendingSource = obj4;
        ModifyOrderRequestParameters request = requestParameters;
        TradingOperationResult tradingOperationResult2 = Core.Instance.ModifyOrder(request);
        tradingOperationResult1.퓏((RequestParameters) request, tradingOperationResult2);
      }
      else if (order1 != null && ((IEnumerable<Order>) array).Count<Order>() % 2 == 0 && !((IEnumerable<Order>) array).Any<Order>((Func<Order, bool>) (([In] obj0_3) => string.IsNullOrEmpty(obj0_3.GroupId))) && ((IEnumerable<Order>) array).GroupBy<Order, string>((Func<Order, string>) (([In] obj0_4) => obj0_4.GroupId)).Count<IGrouping<string, Order>>() * 2 == ((IEnumerable<Order>) array).Count<Order>())
      {
        // ISSUE: reference to a compiler-generated method
        foreach (IOrder order2 in ((IEnumerable<Order>) array).Where<Order>(new Func<Order, bool>(픷.핇)).ToArray<Order>())
        {
          ModifyOrderRequestParameters requestParameters = new ModifyOrderRequestParameters(order2);
          // ISSUE: reference to a compiler-generated field
          requestParameters.TriggerPrice = AdvancedTradingOperations.퓏(픷.픁퓦, obj2);
          requestParameters.SendingSource = obj4;
          ModifyOrderRequestParameters request = requestParameters;
          TradingOperationResult tradingOperationResult3 = Core.Instance.ModifyOrder(request);
          tradingOperationResult1.퓏((RequestParameters) request, tradingOperationResult3);
        }
      }
      else
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        AdvancedTradingOperations.퓻 퓻 = new AdvancedTradingOperations.퓻();
        // ISSUE: reference to a compiler-generated field
        퓻.픁픋 = new TaskCompletionSource<OrderHistory>();
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        // ISSUE: reference to a compiler-generated method
        Action<OrderHistory> action = new Action<OrderHistory>(퓻.퓏);
        Core.Instance.OrdersHistoryAdded += action;
        cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(5.0));
        try
        {
          PlaceOrderRequestParameters requestParameters1 = new PlaceOrderRequestParameters();
          // ISSUE: reference to a compiler-generated field
          requestParameters1.Account = 픷.픁퓦.Account;
          // ISSUE: reference to a compiler-generated field
          requestParameters1.Symbol = 픷.픁퓦.Symbol;
          requestParameters1.OrderTypeId = orderType.Id;
          // ISSUE: reference to a compiler-generated field
          requestParameters1.TriggerPrice = AdvancedTradingOperations.퓏(픷.픁퓦, obj2);
          // ISSUE: reference to a compiler-generated field
          requestParameters1.Side = 픷.픁퓦.Side == Side.Buy ? Side.Sell : Side.Buy;
          // ISSUE: reference to a compiler-generated field
          requestParameters1.Quantity = 픷.픁퓦.Quantity;
          requestParameters1.SendingSource = obj4;
          PlaceOrderRequestParameters request1 = requestParameters1;
          if (obj3 != null)
            request1.AdditionalParameters = obj3;
          TradingOperationResult tradingOperationResult4 = Core.Instance.PlaceOrder(request1);
          tradingOperationResult1.퓏((RequestParameters) request1, tradingOperationResult4);
          if (tradingOperationResult4.Status == TradingOperationResultStatus.Failure)
            return tradingOperationResult1;
          CancellationToken token = cancellationTokenSource.Token;
          // ISSUE: reference to a compiler-generated method
          token.Register(new Action(퓻.퓏));
          // ISSUE: reference to a compiler-generated field
          OrderHistory result = 퓻.픁픋.Task.Result;
          if (token.IsCancellationRequested)
            return AdvancedTradingOperationResult.퓏(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픈());
          if (result.Status == OrderStatus.Refused)
            return AdvancedTradingOperationResult.퓏(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓒());
          foreach (Order order3 in array)
          {
            CancelOrderRequestParameters requestParameters2 = new CancelOrderRequestParameters();
            requestParameters2.Order = (IOrder) order3;
            requestParameters2.SendingSource = obj4;
            CancelOrderRequestParameters request2 = requestParameters2;
            TradingOperationResult tradingOperationResult5 = Core.Instance.CancelOrder(request2);
            tradingOperationResult1.퓏((RequestParameters) request2, tradingOperationResult5);
          }
        }
        finally
        {
          Core.Instance.OrdersHistoryAdded -= action;
        }
      }
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
    return tradingOperationResult1;
  }

  private static double 퓏([In] Position obj0, [In] int obj1)
  {
    if (obj0 == null)
      return double.NaN;
    double price = obj0.OpenPrice;
    Decimal tickSize = (Decimal) obj0.Symbol.RoundPriceToTickSize(obj0.OpenPrice);
    if ((Decimal) obj0.OpenPrice != tickSize)
      price = (double) (!(tickSize < (Decimal) obj0.OpenPrice) ? (obj0.Side == Side.Buy ? tickSize : (Decimal) obj0.Symbol.CalculatePrice((double) tickSize, -1.0)) : (obj0.Side == Side.Buy ? (Decimal) obj0.Symbol.CalculatePrice((double) tickSize, 1.0) : tickSize));
    if (obj1 != 0)
      price = obj0.Symbol.CalculatePrice(price, obj0.Side == Side.Buy ? (double) obj1 : (double) -obj1);
    return price;
  }

  /// <summary>
  /// Adjust SL/TP for given <see cref="T:TradingPlatform.BusinessLayer.Position" />
  /// </summary>
  /// <param name="position"><see cref="T:TradingPlatform.BusinessLayer.Position" /></param>
  /// <param name="cancellationToken"><see cref="T:System.Threading.CancellationToken" /></param>
  /// <param name="sendingSource">the name of the initiator of the call (optional)</param>
  public AdvancedTradingOperationResult AdjustSlTp(
    Position position,
    CancellationToken cancellationToken = default (CancellationToken),
    [CallerMemberName] string sendingSource = null)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    AdvancedTradingOperations.픸 픸 = new AdvancedTradingOperations.픸();
    // ISSUE: reference to a compiler-generated field
    픸.픁픲 = position;
    // ISSUE: reference to a compiler-generated field
    if (픸.픁픲 == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓨());
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    픸.픁핀 = 픸.픁픲.Symbol;
    // ISSUE: reference to a compiler-generated method
    List<Order> list1 = ((IEnumerable<Order>) Core.Instance.Orders).Where<Order>(new Func<Order, bool>(픸.퓏)).ToList<Order>();
    // ISSUE: reference to a compiler-generated method
    List<Order> list2 = ((IEnumerable<Order>) Core.Instance.Orders).Where<Order>(new Func<Order, bool>(픸.퓬)).ToList<Order>();
    if (!list1.Any<Order>() && !list2.Any<Order>())
      return AdvancedTradingOperationResult.퓏(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓚());
    LoggerManager loggers = Core.Instance.Loggers;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(63 /*0x3F*/, 2);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픃());
    // ISSUE: reference to a compiler-generated field
    interpolatedStringHandler.AppendFormatted<Position>(픸.픁픲);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픠());
    interpolatedStringHandler.AppendFormatted(sendingSource);
    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
    loggers.Log(stringAndClear);
    AdvancedTradingOperationResult tradingOperationResult1 = (AdvancedTradingOperationResult) null;
    AdvancedTradingOperationResult tradingOperationResult2 = (AdvancedTradingOperationResult) null;
    AdvancedTradingOperationResult tradingOperationResult3 = new AdvancedTradingOperationResult();
    try
    {
      if (list1.Any<Order>())
      {
        // ISSUE: reference to a compiler-generated field
        tradingOperationResult1 = AdvancedTradingOperations.퓏(new AdvancedTradingOperations.퓏()
        {
          Position = 픸.픁픲,
          Brackets = (IList<Order>) list1
        }, cancellationToken, sendingSource);
      }
      else if (list2.Count > 1)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        AdvancedTradingOperations.프 프 = new AdvancedTradingOperations.프();
        List<Order> list3 = list2.OrderBy<Order, double>((Func<Order, double>) (([In] obj0) => obj0.GetExecutionPrice())).ToList<Order>();
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        프.픁픽 = 픸.픁픲.Side == Side.Buy ? list3.First<Order>() : list3.Last<Order>();
        // ISSUE: reference to a compiler-generated field
        list3.Remove(프.픁픽);
        // ISSUE: reference to a compiler-generated method
        if (list3.All<Order>(new Func<Order, bool>(프.퓏)))
        {
          // ISSUE: reference to a compiler-generated field
          list2.Remove(프.픁픽);
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          tradingOperationResult1 = AdvancedTradingOperations.퓏(new AdvancedTradingOperations.퓏()
          {
            Position = 픸.픁픲,
            Brackets = (IList<Order>) new List<Order>()
            {
              프.픁픽
            }
          }, cancellationToken, sendingSource);
        }
      }
      if (list2.Any<Order>())
      {
        // ISSUE: reference to a compiler-generated field
        tradingOperationResult2 = AdvancedTradingOperations.퓬(new AdvancedTradingOperations.퓏()
        {
          Position = 픸.픁픲,
          Brackets = (IList<Order>) list2
        }, cancellationToken, sendingSource);
      }
      if (tradingOperationResult1 == null)
        return AdvancedTradingOperationResult.퓏(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓎());
      if (tradingOperationResult2 == null)
        return AdvancedTradingOperationResult.퓏(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬피());
      tradingOperationResult3.퓏(tradingOperationResult1).퓏(tradingOperationResult2);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      if (!(tradingOperationResult1.Value is string orderId1) || !(tradingOperationResult2.Value is string orderId2) || Core.Instance.RulesManager.IsAllowed(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓸(), 픸.픁픲.Account, 픸.픁픲.Symbol).Status != TradingOperationStatus.Allowed)
        return tradingOperationResult3;
      Order order1 = (Order) null;
      Order order2 = (Order) null;
      CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5.0));
      while ((order1 == null || order2 == null) && !cancellationTokenSource.IsCancellationRequested)
      {
        // ISSUE: reference to a compiler-generated field
        order1 = Core.Instance.GetOrderById(orderId1, 픸.픁픲.ConnectionId);
        // ISSUE: reference to a compiler-generated field
        order2 = Core.Instance.GetOrderById(orderId2, 픸.픁픲.ConnectionId);
        Task.Delay(100, cancellationTokenSource.Token).Wait(cancellationTokenSource.Token);
      }
      if (order1 == null || order2 == null)
        return tradingOperationResult3;
      Core instance = Core.Instance;
      // ISSUE: reference to a compiler-generated field
      string connectionId = 픸.픁픲.ConnectionId;
      LinkOCORequestParameters parameters = new LinkOCORequestParameters();
      int num = 2;
      List<IOrder> list4 = new List<IOrder>(num);
      CollectionsMarshal.SetCount<IOrder>(list4, num);
      Span<IOrder> span = CollectionsMarshal.AsSpan<IOrder>(list4);
      int index1 = 0;
      span[index1] = (IOrder) order1;
      int index2 = index1 + 1;
      span[index2] = (IOrder) order2;
      parameters.OrdersToLink = list4;
      parameters.CancellationToken = cancellationToken;
      instance.SendCustomRequest(connectionId, (RequestParameters) parameters);
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
    return tradingOperationResult3;
  }

  /// <summary>
  /// Adjust stop loss for given <see cref="T:TradingPlatform.BusinessLayer.Position" />
  /// </summary>
  /// <param name="position"><see cref="T:TradingPlatform.BusinessLayer.Position" /></param>
  /// <param name="stops">list of <see cref="T:TradingPlatform.BusinessLayer.Order" />s</param>
  /// <param name="initialStopLoss">initial stop loss parameters (optional)</param>
  /// <param name="cancellationToken"><see cref="T:System.Threading.CancellationToken" /></param>
  /// <param name="sendingSource">the name of the initiator of the call (optional)</param>
  /// <returns></returns>
  public AdvancedTradingOperationResult AdjustStopLoss(
    Position position,
    IList<Order> stops,
    SlTpHolder initialStopLoss = null,
    CancellationToken cancellationToken = default (CancellationToken),
    [CallerMemberName] string sendingSource = null)
  {
    LoggerManager loggers = Core.Instance.Loggers;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(97, 4);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓦());
    interpolatedStringHandler.AppendFormatted<Position>(position);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픋());
    interpolatedStringHandler.AppendFormatted<int>(stops.Count);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬핀());
    interpolatedStringHandler.AppendFormatted<SlTpHolder>(initialStopLoss);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픠());
    interpolatedStringHandler.AppendFormatted(sendingSource);
    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
    loggers.Log(stringAndClear);
    return AdvancedTradingOperations.퓏(new AdvancedTradingOperations.퓏()
    {
      Position = position,
      Brackets = stops,
      InitialBracketParameters = initialStopLoss
    }, cancellationToken, sendingSource);
  }

  /// <summary>
  /// Adjust take profit for given <see cref="T:TradingPlatform.BusinessLayer.Position" />
  /// </summary>
  /// <param name="position"><see cref="T:TradingPlatform.BusinessLayer.Position" /></param>
  /// <param name="takes">list of <see cref="T:TradingPlatform.BusinessLayer.Order" />s</param>
  /// <param name="initialTakeProfit">initial take profit parameters (optional)</param>
  /// <param name="cancellationToken"><see cref="T:System.Threading.CancellationToken" /></param>
  /// <param name="sendingSource">the name of the initiator of the call (optional)</param>
  /// <returns></returns>
  public AdvancedTradingOperationResult AdjustTakeProfit(
    Position position,
    IList<Order> takes,
    SlTpHolder initialTakeProfit,
    CancellationToken cancellationToken = default (CancellationToken),
    [CallerMemberName] string sendingSource = null)
  {
    LoggerManager loggers = Core.Instance.Loggers;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(101, 4);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픲());
    interpolatedStringHandler.AppendFormatted<Position>(position);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픽());
    interpolatedStringHandler.AppendFormatted<int>(takes.Count);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓏());
    interpolatedStringHandler.AppendFormatted<SlTpHolder>(initialTakeProfit);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픠());
    interpolatedStringHandler.AppendFormatted(sendingSource);
    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
    loggers.Log(stringAndClear);
    return AdvancedTradingOperations.퓬(new AdvancedTradingOperations.퓏()
    {
      Position = position,
      Brackets = takes,
      InitialBracketParameters = initialTakeProfit
    }, cancellationToken, sendingSource);
  }

  private static AdvancedTradingOperationResult 퓏(
    [In] AdvancedTradingOperations.퓏 obj0_1,
    [In] CancellationToken obj1_1,
    [In] string obj2)
  {
    AdvancedTradingOperationResult tradingOperationResult1 = new AdvancedTradingOperationResult();
    Position position = obj0_1.Position;
    IList<Order> brackets = obj0_1.Brackets;
    SlTpHolder bracketParameters = obj0_1.InitialBracketParameters;
    double quantity = position.Quantity;
    double price = AdvancedTradingOperations.퓏(position, (IEnumerable<Order>) brackets, bracketParameters);
    List<Order> list = brackets.Where<Order>((Func<Order, bool>) (([In] obj0_2) => string.IsNullOrEmpty(obj0_2.GroupId))).ToList<Order>();
    if (list.Any<Order>())
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      AdvancedTradingOperations.픴 픴 = new AdvancedTradingOperations.픴();
      // ISSUE: reference to a compiler-generated field
      픴.픞퓏 = list.Aggregate<Order>((Func<Order, Order, Order>) (([In] obj0_3, [In] obj1_2) => obj0_3.RemainingQuantity <= obj1_2.RemainingQuantity ? obj1_2 : obj0_3));
      // ISSUE: reference to a compiler-generated method
      tradingOperationResult1.퓏(AdvancedTradingOperations.퓏((IList<Order>) brackets.Where<Order>(new Func<Order, bool>(픴.퓏)).ToList<Order>(), obj1_1, obj2));
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      if (Math.Abs(픴.픞퓏.RemainingQuantity - quantity) > double.Epsilon || Math.Abs(픴.픞퓏.GetExecutionPrice() - price) > double.Epsilon)
      {
        // ISSUE: reference to a compiler-generated field
        ModifyOrderRequestParameters requestParameters = new ModifyOrderRequestParameters((IOrder) 픴.픞퓏);
        requestParameters.Quantity = quantity;
        requestParameters.CancellationToken = obj1_1;
        requestParameters.SendingSource = obj2;
        ModifyOrderRequestParameters parameters = requestParameters;
        parameters.SetExecutionPrice(price);
        TradingOperationResult tradingOperationResult2 = AdvancedTradingOperations.퓏(parameters);
        tradingOperationResult1.퓏((RequestParameters) parameters, tradingOperationResult2);
        if (tradingOperationResult2.Status != TradingOperationResultStatus.Success)
          return tradingOperationResult1;
        tradingOperationResult1.Value = (object) tradingOperationResult2.OrderId;
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        tradingOperationResult1.Value = (object) 픴.픞퓏.Id;
      }
    }
    else
    {
      PlaceOrderRequestParameters requestParameters = new PlaceOrderRequestParameters((IOrder) brackets.FirstOrDefault<Order>());
      requestParameters.Quantity = quantity;
      requestParameters.CancellationToken = obj1_1;
      requestParameters.GroupId = string.Empty;
      requestParameters.SendingSource = obj2;
      PlaceOrderRequestParameters parameters = requestParameters;
      tradingOperationResult1.퓏(AdvancedTradingOperations.퓏(brackets, obj1_1, obj2));
      parameters.SetExecutionPrice(price);
      TradingOperationResult tradingOperationResult3 = AdvancedTradingOperations.퓏(parameters);
      if (tradingOperationResult3.Status != TradingOperationResultStatus.Success)
        return tradingOperationResult1;
      tradingOperationResult1.퓏((RequestParameters) parameters, tradingOperationResult3);
      tradingOperationResult1.Value = (object) tradingOperationResult3.OrderId;
    }
    return tradingOperationResult1;
  }

  private static AdvancedTradingOperationResult 퓬(
    [In] AdvancedTradingOperations.퓏 obj0_1,
    [In] CancellationToken obj1_1,
    [In] string obj2)
  {
    AdvancedTradingOperationResult tradingOperationResult1 = new AdvancedTradingOperationResult();
    Position position = obj0_1.Position;
    IList<Order> brackets = obj0_1.Brackets;
    SlTpHolder bracketParameters = obj0_1.InitialBracketParameters;
    double quantity = position.Quantity;
    double num = AdvancedTradingOperations.퓬(position, (IEnumerable<Order>) brackets, bracketParameters);
    if (double.IsNaN(num))
      return AdvancedTradingOperationResult.퓏(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓬());
    List<Order> list = brackets.Where<Order>((Func<Order, bool>) (([In] obj0_2) => string.IsNullOrEmpty(obj0_2.GroupId))).ToList<Order>();
    if (list.Any<Order>())
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      AdvancedTradingOperations.픑 픑 = new AdvancedTradingOperations.픑();
      // ISSUE: reference to a compiler-generated field
      픑.픞퓬 = list.Aggregate<Order>((Func<Order, Order, Order>) (([In] obj0_3, [In] obj1_2) => obj0_3.RemainingQuantity <= obj1_2.RemainingQuantity ? obj1_2 : obj0_3));
      // ISSUE: reference to a compiler-generated method
      tradingOperationResult1.퓏(AdvancedTradingOperations.퓏((IList<Order>) brackets.Where<Order>(new Func<Order, bool>(픑.퓏)).ToList<Order>(), obj1_1, obj2));
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      if (Math.Abs(픑.픞퓬.RemainingQuantity - quantity) > double.Epsilon || Math.Abs(픑.픞퓬.GetExecutionPrice() - num) > double.Epsilon)
      {
        // ISSUE: reference to a compiler-generated field
        ModifyOrderRequestParameters requestParameters = new ModifyOrderRequestParameters((IOrder) 픑.픞퓬);
        requestParameters.Quantity = quantity;
        requestParameters.CancellationToken = obj1_1;
        requestParameters.SendingSource = obj2;
        ModifyOrderRequestParameters parameters = requestParameters;
        parameters.SetExecutionPrice(num);
        TradingOperationResult tradingOperationResult2 = AdvancedTradingOperations.퓏(parameters);
        tradingOperationResult1.퓏((RequestParameters) parameters, tradingOperationResult2);
        if (tradingOperationResult2.Status != TradingOperationResultStatus.Success)
          return tradingOperationResult1;
        tradingOperationResult1.Value = (object) tradingOperationResult2.OrderId;
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        tradingOperationResult1.Value = (object) 픑.픞퓬.Id;
      }
    }
    else
    {
      PlaceOrderRequestParameters requestParameters = new PlaceOrderRequestParameters((IOrder) brackets.FirstOrDefault<Order>());
      requestParameters.Quantity = quantity;
      requestParameters.CancellationToken = obj1_1;
      requestParameters.GroupId = string.Empty;
      requestParameters.SendingSource = obj2;
      PlaceOrderRequestParameters parameters = requestParameters;
      tradingOperationResult1.퓏(AdvancedTradingOperations.퓏(brackets, obj1_1, obj2));
      parameters.SetExecutionPrice(num);
      TradingOperationResult tradingOperationResult3 = AdvancedTradingOperations.퓏(parameters);
      tradingOperationResult1.퓏((RequestParameters) parameters, tradingOperationResult3);
      if (tradingOperationResult3.Status != TradingOperationResultStatus.Success)
        return tradingOperationResult1;
      tradingOperationResult1.Value = (object) tradingOperationResult3.OrderId;
    }
    return tradingOperationResult1;
  }

  private static double 퓏([In] Position obj0_1, [In] IEnumerable<Order> obj1, SlTpHolder _param2 = null)
  {
    return _param2 != null ? (_param2.PriceMeasurement != PriceMeasurement.Absolute ? obj0_1.Symbol.RoundPriceToTickSize(obj0_1.Symbol.CalculatePrice(obj0_1.OpenPrice, (obj0_1.Side == Side.Buy ? -1.0 : 1.0) * _param2.Price)) : _param2.Price) : (obj0_1.Side != Side.Buy ? obj1.Min<Order>((Func<Order, double>) (([In] obj0_2) => obj0_2.GetExecutionPrice())) : obj1.Max<Order>((Func<Order, double>) (([In] obj0_3) => obj0_3.GetExecutionPrice())));
  }

  private static double 퓬([In] Position obj0_1, [In] IEnumerable<Order> obj1, SlTpHolder _param2 = null)
  {
    if (_param2 == null)
      return CoreMath.GetWeightedAverage(obj1.Select<Order, (double, double)>((Func<Order, (double, double)>) (([In] obj0_2) => (obj0_2.GetExecutionPrice(), obj0_2.RemainingQuantity))), obj0_1.Symbol);
    return _param2.PriceMeasurement != PriceMeasurement.Absolute ? obj0_1.Symbol.RoundPriceToTickSize(obj0_1.Symbol.CalculatePrice(obj0_1.OpenPrice, (obj0_1.Side == Side.Buy ? 1.0 : -1.0) * _param2.Price)) : _param2.Price;
  }

  private static TradingOperationResult 퓏([In] PlaceOrderRequestParameters obj0)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    AdvancedTradingOperations.픿 픿 = new AdvancedTradingOperations.픿();
    // ISSUE: reference to a compiler-generated field
    픿.픞핂 = obj0;
    // ISSUE: reference to a compiler-generated field
    픿.픞핇 = new ManualResetEventSlim();
    // ISSUE: reference to a compiler-generated field
    픿.픞퓲 = (string) null;
    try
    {
      // ISSUE: reference to a compiler-generated method
      Core.Instance.OrderAdded += new Action<Order>(픿.퓏);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      Core.Instance.Connections[픿.픞핂.ConnectionId]?.Limitation?.Wait(픿.픞핂.Type, 픿.픞핂.CancellationToken);
      // ISSUE: reference to a compiler-generated field
      TradingOperationResult tradingOperationResult = Core.Instance.PlaceOrder(픿.픞핂);
      if (tradingOperationResult != null && tradingOperationResult.Status == TradingOperationResultStatus.Failure)
        return tradingOperationResult;
      // ISSUE: reference to a compiler-generated field
      픿.픞퓲 = tradingOperationResult.OrderId;
      // ISSUE: reference to a compiler-generated field
      픿.픞핇.Wait(TimeSpan.FromSeconds(5.0));
      return tradingOperationResult;
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
    finally
    {
      // ISSUE: reference to a compiler-generated method
      Core.Instance.OrderAdded -= new Action<Order>(픿.퓏);
    }
    return (TradingOperationResult) null;
  }

  private static TradingOperationResult 퓏([In] ModifyOrderRequestParameters obj0)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    AdvancedTradingOperations.퓔 퓔 = new AdvancedTradingOperations.퓔();
    // ISSUE: reference to a compiler-generated field
    퓔.픞픾 = obj0;
    // ISSUE: reference to a compiler-generated field
    퓔.픞픂 = new ManualResetEventSlim();
    try
    {
      // ISSUE: reference to a compiler-generated method
      Core.Instance.OrderAdded += new Action<Order>(퓔.퓏);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      Core.Instance.Connections[퓔.픞픾.ConnectionId]?.Limitation?.Wait(퓔.픞픾.Type, 퓔.픞픾.CancellationToken);
      // ISSUE: reference to a compiler-generated field
      TradingOperationResult tradingOperationResult = Core.Instance.ModifyOrder(퓔.픞픾);
      if (tradingOperationResult != null && tradingOperationResult.Status == TradingOperationResultStatus.Failure)
        return tradingOperationResult;
      // ISSUE: reference to a compiler-generated field
      퓔.픞픂.Wait(TimeSpan.FromSeconds(5.0));
      return tradingOperationResult;
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
    finally
    {
      // ISSUE: reference to a compiler-generated method
      Core.Instance.OrderAdded -= new Action<Order>(퓔.퓏);
    }
    return (TradingOperationResult) null;
  }

  private static AdvancedTradingOperationResult 퓏(
    [In] IList<Order> obj0_1,
    [In] CancellationToken obj1,
    [In] string obj2)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    AdvancedTradingOperations.픢 픢 = new AdvancedTradingOperations.픢();
    if (!obj0_1.Any<Order>())
      return AdvancedTradingOperationResult.퓏();
    AdvancedTradingOperationResult tradingOperationResult1 = new AdvancedTradingOperationResult();
    // ISSUE: reference to a compiler-generated field
    픢.픞픁 = new ManualResetEvent(false);
    // ISSUE: reference to a compiler-generated field
    픢.픞퓍 = new HashSet<string>(obj0_1.Select<Order, string>((Func<Order, string>) (([In] obj0_2) => obj0_2.Id)));
    try
    {
      // ISSUE: reference to a compiler-generated method
      Core.Instance.OrderRemoved += new Action<Order>(픢.퓏);
      foreach (Order order in (IEnumerable<Order>) obj0_1)
      {
        CancelOrderRequestParameters requestParameters = new CancelOrderRequestParameters();
        requestParameters.Order = (IOrder) order;
        requestParameters.CancellationToken = obj1;
        requestParameters.SendingSource = obj2;
        CancelOrderRequestParameters request = requestParameters;
        order.Connection.Limitation?.Wait(request.Type, request.CancellationToken);
        TradingOperationResult tradingOperationResult2 = Core.Instance.CancelOrder(request);
        if (tradingOperationResult2 != null && tradingOperationResult2.Status == TradingOperationResultStatus.Failure)
        {
          // ISSUE: reference to a compiler-generated field
          픢.픞퓍.Remove(order.Id);
        }
        tradingOperationResult1.퓏((RequestParameters) request, tradingOperationResult2);
      }
      // ISSUE: reference to a compiler-generated field
      if (!픢.픞퓍.Any<string>())
      {
        // ISSUE: reference to a compiler-generated field
        픢.픞픁.Set();
      }
      // ISSUE: reference to a compiler-generated field
      픢.픞픁.WaitOne(TimeSpan.FromSeconds(5.0));
    }
    finally
    {
      // ISSUE: reference to a compiler-generated method
      Core.Instance.OrderRemoved -= new Action<Order>(픢.퓏);
    }
    return tradingOperationResult1;
  }

  private class 퓏
  {
    public Position Position { get; [param: In] init; }

    public IList<Order> Brackets { get; [param: In] init; }

    public SlTpHolder InitialBracketParameters { get; [param: In] init; }
  }

  private class 퓬 : IEquatable<AdvancedTradingOperations.퓬>
  {
    public 퓬([In] Symbol obj0, [In] Account obj1)
    {
      // ISSUE: reference to a compiler-generated field
      this.픁픻 = obj0;
      // ISSUE: reference to a compiler-generated field
      this.픁퓤 = obj1;
      // ISSUE: explicit constructor call
      base.\u002Ector();
    }

    [CompilerGenerated]
    protected virtual 
    #nullable enable
    Type EqualityContract => typeof (AdvancedTradingOperations.퓬);

    public 
    #nullable disable
    Symbol Symbol { get; [param: In] init; }

    public Account Account { get; [param: In] init; }

    [CompilerGenerated]
    public override 
    #nullable enable
    string ToString()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓖());
      stringBuilder.Append(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓲());
      if (this.퓏(stringBuilder))
        stringBuilder.Append(' ');
      stringBuilder.Append('}');
      return stringBuilder.ToString();
    }

    [CompilerGenerated]
    protected virtual bool 퓏([In] StringBuilder obj0)
    {
      RuntimeHelpers.EnsureSufficientExecutionStack();
      obj0.Append(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픵());
      obj0.Append((object) this.Symbol);
      obj0.Append(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픬());
      obj0.Append((object) this.Account);
      return true;
    }

    [CompilerGenerated]
    public static bool operator !=(
      [In] AdvancedTradingOperations.퓬? obj0,
      [In] AdvancedTradingOperations.퓬? obj1)
    {
      return !(obj0 == obj1);
    }

    [CompilerGenerated]
    public static bool operator ==(
      [In] AdvancedTradingOperations.퓬? obj0,
      [In] AdvancedTradingOperations.퓬? obj1)
    {
      if ((object) obj0 == (object) obj1)
        return true;
      return (object) obj0 != null && obj0.Equals(obj1);
    }

    [CompilerGenerated]
    public override int GetHashCode()
    {
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      return (EqualityComparer<Type>.Default.GetHashCode(this.EqualityContract) * -1521134295 + EqualityComparer<Symbol>.Default.GetHashCode(this.픁픻)) * -1521134295 + EqualityComparer<Account>.Default.GetHashCode(this.픁퓤);
    }

    [CompilerGenerated]
    public override bool Equals(object? obj) => this.Equals(obj as AdvancedTradingOperations.퓬);

    [CompilerGenerated]
    public virtual bool Equals(AdvancedTradingOperations.퓬? other)
    {
      if ((object) this == (object) other)
        return true;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      return (object) other != null && this.EqualityContract == other.EqualityContract && EqualityComparer<Symbol>.Default.Equals(this.픁픻, other.픁픻) && EqualityComparer<Account>.Default.Equals(this.픁퓤, other.픁퓤);
    }

    [CompilerGenerated]
    public virtual AdvancedTradingOperations.퓬 퓏() => new AdvancedTradingOperations.퓬(this);

    [CompilerGenerated]
    protected 퓬(AdvancedTradingOperations.퓬 original)
    {
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.픁픻 = original.픁픻;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.픁퓤 = original.픁퓤;
    }

    [CompilerGenerated]
    public void 퓏(out 
    #nullable disable
    Symbol _param1, out Account _param2)
    {
      _param1 = this.Symbol;
      _param2 = this.Account;
    }
  }
}
