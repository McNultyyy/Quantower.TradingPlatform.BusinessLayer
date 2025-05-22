// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Modules.OrderPlacingStrategy
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using TradingPlatform.BusinessLayer.Integration;

#nullable disable
namespace TradingPlatform.BusinessLayer.Modules;

public abstract class OrderPlacingStrategy : ExecutionEntity
{
  private OrderPlacingStrategyState 퓑픪;
  public readonly DateTime CreationTime;
  private readonly List<LoggerEvent> 퓑픗;

  public OrderPlacingStrategyState State
  {
    get => this.퓑픪;
    [param: In] private set
    {
      this.퓑픪 = value;
      Action<OrderPlacingStrategyState> 퓑퓡 = this.퓑퓡;
      if (퓑퓡 == null)
        return;
      퓑퓡(this.퓑픪);
    }
  }

  public event Action<OrderPlacingStrategyState> StateChanged;

  /// <summary>Event occurred when write a new log</summary>
  public event Action<LoggerEvent> NewLog;

  public PlaceOrderRequestParameters LastPlaceRequest { get; set; }

  public OrderPlacingStrategy()
  {
    this.CreationTime = Core.Instance.TimeUtils.DateTimeUtcNow;
    this.퓑픗 = new List<LoggerEvent>();
  }

  public TradingOperationResult PlaceOrder(PlaceOrderRequestParameters placeOrderRequest)
  {
    if (this.State != OrderPlacingStrategyState.Ready)
      return TradingOperationResult.CreateError(placeOrderRequest.RequestId, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓵());
    try
    {
      this.State = OrderPlacingStrategyState.Processing;
      this.LastPlaceRequest = placeOrderRequest;
      this.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픀());
      this.OnPlaceOrder(placeOrderRequest.Clone() as PlaceOrderRequestParameters);
    }
    catch (TaskCanceledException ex)
    {
    }
    catch (OperationCanceledException ex)
    {
    }
    catch (AggregateException ex) when (ex.InnerException is TaskCanceledException)
    {
    }
    catch (Exception ex)
    {
      Exception exception = ex.GetInnerExceptionsRecursive().Last<Exception>();
      string str = this.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓡() + exception.Message;
      this.Log(str, StrategyLoggingLevel.Error);
      this.State = OrderPlacingStrategyState.Error;
      placeOrderRequest.Symbol.ConnectionCache.Push((Message) MessageDealTicket.CreateRefuseDealTicket(str));
      return TradingOperationResult.CreateError(placeOrderRequest.RequestId, str);
    }
    finally
    {
      if (this.State == OrderPlacingStrategyState.Processing)
      {
        this.State = OrderPlacingStrategyState.Finished;
        this.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗플());
      }
    }
    return TradingOperationResult.CreateSuccess(placeOrderRequest.RequestId);
  }

  public void Cancel()
  {
    if (this.State != OrderPlacingStrategyState.Processing)
      return;
    try
    {
      this.State = OrderPlacingStrategyState.Cancelling;
      this.OnCancel();
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
    finally
    {
      this.State = OrderPlacingStrategyState.Cancelled;
    }
  }

  public void Remove() => Core.Instance.OrderPlacingStrategies.퓏(this);

  public override void Dispose()
  {
    if (this.State == OrderPlacingStrategyState.Processing)
      this.Cancel();
    this.퓑픗.Clear();
    base.Dispose();
  }

  public virtual string FormatParameters()
  {
    return string.Join(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픥(), this.Settings.Where<SettingItem>((Func<SettingItem, bool>) (([In] obj0) => obj0.VisibilityMode != VisibilityMode.Hidden)).Select<SettingItem, string>((Func<SettingItem, string>) (([In] obj0) => obj0.ToString())));
  }

  /// <summary>Get logs from the strategy for specified date range</summary>
  /// <param name="from"></param>
  /// <param name="to"></param>
  /// <returns></returns>
  public LoggerEvent[] GetLogs(DateTime from, DateTime to)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    OrderPlacingStrategy.퓬 퓬 = new OrderPlacingStrategy.퓬();
    // ISSUE: reference to a compiler-generated field
    퓬.퓞픆 = from;
    // ISSUE: reference to a compiler-generated field
    퓬.퓞픅 = to;
    // ISSUE: reference to a compiler-generated method
    // ISSUE: reference to a compiler-generated method
    return this.퓑픗.Where<LoggerEvent>(new Func<LoggerEvent, bool>(퓬.퓏)).Where<LoggerEvent>(new Func<LoggerEvent, bool>(퓬.퓬)).ToArray<LoggerEvent>();
  }

  protected abstract void OnPlaceOrder(PlaceOrderRequestParameters placeOrderRequest);

  protected abstract void OnCancel();

  /// <summary>Write log message</summary>
  /// <param name="message"></param>
  /// <param name="level"></param>
  protected void Log(string message, StrategyLoggingLevel level = StrategyLoggingLevel.Info)
  {
    DateTime dateTimeUtcNow = Core.Instance.TimeUtils.DateTimeUtcNow;
    LoggingLevel loggingLevel = LoggingLevel.System;
    switch (level)
    {
      case StrategyLoggingLevel.Trading:
        loggingLevel = LoggingLevel.Trading;
        break;
      case StrategyLoggingLevel.Error:
        loggingLevel = LoggingLevel.Error;
        break;
    }
    LoggerEvent loggerEvent = new LoggerEvent()
    {
      Date = dateTimeUtcNow,
      Event = message,
      Type = loggingLevel
    };
    this.퓑픗.Add(loggerEvent);
    // ISSUE: reference to a compiler-generated field
    Action<LoggerEvent> 퓑퓓 = this.퓑퓓;
    if (퓑퓓 == null)
      return;
    퓑퓓(loggerEvent);
  }
}
