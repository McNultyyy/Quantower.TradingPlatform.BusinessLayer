// Decompiled with JetBrains decompiler
// Type: 퓏.퓔
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
using System.Threading;
using System.Threading.Tasks;
using TradingPlatform.BusinessLayer;
using TradingPlatform.BusinessLayer.History.Storage;
using TradingPlatform.BusinessLayer.Utils;
using TradingPlatform.BusinessLayer.Utils.TaskSchedulers;

#nullable enable
namespace 퓏;

internal class 퓔 : IDisposable
{
  private readonly 
  #nullable disable
  HistoryStorage 핂퓣;
  private readonly TaskFactory 핂픦;
  private readonly DegreeOfParallelismTaskScheduler 핂픍;
  private readonly 픢 핂픆;
  private readonly Dictionary<int, List<퓔.퓏>> 핂픅;
  private readonly object 핂픠;

  public static 퓔 퓏([In] 퓝 obj0)
  {
    HistoryStorage historyStorage = (HistoryStorage) null;
    if (obj0.AllowLocalStorage)
      historyStorage = HistoryStorage.Create(obj0.LocalStorageConnectionString);
    return new 퓔(obj0.DegreeOfParallelism, obj0.LoadHistoryDelegate, historyStorage);
  }

  internal 퓔([In] int obj0, [In] 픢 obj1, HistoryStorage _param3 = null)
  {
    this.핂픍 = new DegreeOfParallelismTaskScheduler(obj0);
    this.핂픦 = new TaskFactory((TaskScheduler) this.핂픍);
    this.핂픆 = obj1;
    this.핂퓣 = _param3;
    this.핂픅 = new Dictionary<int, List<퓔.퓏>>();
    this.핂픠 = new object();
  }

  public IList<IHistoryItem> 퓏([In] HistoryRequestParameters obj0)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    퓔.핇 핇 = new 퓔.핇() { 퓗픧 = this, 퓗퓹 = obj0 };
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    핇.퓗퓛 = 퓔.핇(핇.퓗퓹);
    // ISSUE: reference to a compiler-generated field
    퓔.퓏 퓏 = new 퓔.퓏(핇.퓗퓹.CancellationToken);
    bool flag = false;
    lock (this.핂픠)
    {
      List<퓔.퓏> 퓏List;
      // ISSUE: reference to a compiler-generated field
      if (this.핂픅.TryGetValue(핇.퓗퓛, out 퓏List))
      {
        퓏List.Add(퓏);
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        this.핂픅.Add(핇.퓗퓛, new List<퓔.퓏>() { 퓏 });
        flag = true;
      }
    }
    if (flag)
    {
      // ISSUE: reference to a compiler-generated method
      this.핂픦.StartNew(new Action(핇.퓏));
    }
    // ISSUE: reference to a compiler-generated field
    퓏.퓏(핇.퓗퓹.CancellationToken);
    return 퓏.History ?? (IList<IHistoryItem>) new List<IHistoryItem>();
  }

  internal virtual IList<IHistoryItem> 퓬([In] HistoryRequestParameters obj0_1)
  {
    List<IHistoryItem> historyItemList1 = new List<IHistoryItem>();
    List<HistoryInterval> source = new List<HistoryInterval>();
    List<HistoryRequestParameters> historyParametersForServerRequest = new List<HistoryRequestParameters>();
    DefaultInterpolatedStringHandler interpolatedStringHandler;
    if (!obj0_1.ForceReload && this.핂퓣 != null)
    {
      LoggerManager loggers1 = Core.Instance.Loggers;
      interpolatedStringHandler = new DefaultInterpolatedStringHandler(52, 1);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픡());
      interpolatedStringHandler.AppendFormatted<long>(obj0_1.RequestId);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픏());
      string stringAndClear1 = interpolatedStringHandler.ToStringAndClear();
      loggers1.Log(stringAndClear1, LoggingLevel.Performance);
      IList<HistoryInterval> historyIntervalList = this.핂퓣.Load(obj0_1, out historyParametersForServerRequest);
      if (this.퓲(obj0_1))
        return (IList<IHistoryItem>) historyItemList1;
      source.AddRange((IEnumerable<HistoryInterval>) historyIntervalList);
      LoggerManager loggers2 = Core.Instance.Loggers;
      interpolatedStringHandler = new DefaultInterpolatedStringHandler(75, 2);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픡());
      interpolatedStringHandler.AppendFormatted<long>(obj0_1.RequestId);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓳());
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍핆());
      interpolatedStringHandler.AppendFormatted<int>(historyIntervalList.Sum<HistoryInterval>((Func<HistoryInterval, int>) (([In] obj0_2) => obj0_2.History.Count)));
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픷());
      string stringAndClear2 = interpolatedStringHandler.ToStringAndClear();
      loggers2.Log(stringAndClear2, LoggingLevel.Performance);
    }
    else
      historyParametersForServerRequest.Add(obj0_1);
    foreach (HistoryRequestParameters requestParameters in historyParametersForServerRequest)
    {
      if (!this.퓲(obj0_1))
      {
        LoggerManager loggers3 = Core.Instance.Loggers;
        interpolatedStringHandler = new DefaultInterpolatedStringHandler(50, 1);
        interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픡());
        interpolatedStringHandler.AppendFormatted<long>(obj0_1.RequestId);
        interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓻());
        string stringAndClear3 = interpolatedStringHandler.ToStringAndClear();
        loggers3.Log(stringAndClear3, LoggingLevel.Performance);
        DateTime dateTimeUtcNow = Core.Instance.TimeUtils.DateTimeUtcNow;
        if (this.핂픆(requestParameters) is List<IHistoryItem> historyItemList2)
        {
          if (!this.퓲(obj0_1))
          {
            if (requestParameters.Aggregation is HistoryAggregationTick && !requestParameters.Symbol.HistoryMetadata.ServerSideTickDirectionAvailable)
              historyItemList2.ProcessTickDirection(obj0_1.CancellationToken);
            source.Add(new HistoryInterval()
            {
              Description = requestParameters.ToDescription(),
              Interval = requestParameters.Interval,
              History = (IList<IHistoryItem>) new List<IHistoryItem>((IEnumerable<IHistoryItem>) historyItemList2)
            });
            if (퓔.퓏(requestParameters, historyItemList2, dateTimeUtcNow, requestParameters.Symbol.HistoryMetadata.BuildUncompletedBars))
            {
              HistoryStorage 핂퓣 = this.핂퓣;
              if (핂퓣 != null)
              {
                // ISSUE: explicit non-virtual call
                __nonvirtual (핂퓣.Save(new HistoryInterval()
                {
                  Description = requestParameters.ToDescription(),
                  Interval = requestParameters.Interval,
                  History = (IList<IHistoryItem>) historyItemList2
                }, false));
              }
            }
            LoggerManager loggers4 = Core.Instance.Loggers;
            interpolatedStringHandler = new DefaultInterpolatedStringHandler(73, 2);
            interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픡());
            interpolatedStringHandler.AppendFormatted<long>(obj0_1.RequestId);
            interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픸());
            interpolatedStringHandler.AppendFormatted<int>(historyItemList2.Count);
            interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픷());
            string stringAndClear4 = interpolatedStringHandler.ToStringAndClear();
            loggers4.Log(stringAndClear4, LoggingLevel.Performance);
          }
          else
            break;
        }
        else
          break;
      }
      else
        break;
    }
    return (IList<IHistoryItem>) source.OrderBy<HistoryInterval, DateTime>((Func<HistoryInterval, DateTime>) (([In] obj0_3) => obj0_3.Interval.From)).SelectMany<HistoryInterval, IHistoryItem>((Func<HistoryInterval, IEnumerable<IHistoryItem>>) (([In] obj0_4) => (IEnumerable<IHistoryItem>) obj0_4.History)).ToList<IHistoryItem>();
  }

  public void Dispose()
  {
    this.핂픍.Dispose();
    this.핂퓣?.Dispose();
  }

  internal static bool 퓏(
    [In] HistoryRequestParameters obj0,
    [In] List<IHistoryItem> obj1,
    [In] DateTime obj2,
    [In] bool obj3)
  {
    switch (obj0.Aggregation)
    {
      case HistoryAggregationTick _:
        TimeSpan timeSpan = TimeSpan.FromSeconds(5.0);
        if (obj0.Interval.To < obj2 && obj2 - obj0.Interval.To > timeSpan)
          return true;
        if (!obj1.Any<IHistoryItem>())
        {
          obj0.Interval = new Interval<DateTime>(obj0.Interval.From, obj0.Interval.To - timeSpan);
          return !obj0.Interval.IsReversal;
        }
        obj0.Interval = new Interval<DateTime>(obj0.Interval.From, obj1.Last<IHistoryItem>().TimeLeft.AddTicks(1L));
        return true;
      case HistoryAggregationTickBars aggregationTickBars:
        if (!obj1.Any<IHistoryItem>())
          return !obj3 || (obj2 - obj0.ToTime).TotalSeconds >= 60.0;
        List<IHistoryItem> historyItemList = obj1;
        IHistoryItem historyItem = historyItemList[historyItemList.Count - 1];
        if (historyItem.TicksLeft <= obj0.ToTime.Ticks)
        {
          HistoryItemBar historyItemBar = historyItem as HistoryItemBar;
          if ((object) historyItemBar != null && historyItemBar.Ticks < (long) aggregationTickBars.TicksCount)
          {
            obj1.Remove(historyItem);
            obj0.ToTime = historyItem.TimeLeft;
            goto label_14;
          }
        }
        obj0.ToTime = new DateTime(Math.Max(historyItem.TicksRight, historyItem.TicksLeft + (long) aggregationTickBars.TicksCount), DateTimeKind.Utc);
label_14:
        return true;
      case HistoryAggregationTime historyAggregationTime:
        return 퓔.퓏(obj0, obj1, obj2, obj3, historyAggregationTime.Period);
      case HistoryAggregationTimeStatistics aggregationTimeStatistics:
        return 퓔.퓏(obj0, obj1, obj2, obj3, aggregationTimeStatistics.Period);
      default:
        throw new Exception(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍프() + obj0.Aggregation.Name);
    }
  }

  private static bool 퓏(
    [In] HistoryRequestParameters obj0,
    [In] List<IHistoryItem> obj1,
    [In] DateTime obj2,
    [In] bool obj3,
    [In] Period obj4)
  {
    if (!obj1.Any<IHistoryItem>())
    {
      if (obj0.ToTime.Ticks - obj0.FromTime.Ticks < obj4.Ticks)
        return false;
      TimeSpan timeSpan;
      if (obj3)
      {
        timeSpan = obj2 - obj0.ToTime;
        if (timeSpan.TotalSeconds < 60.0)
          return false;
      }
      timeSpan = obj0.Interval.GetLength();
      long num = timeSpan.Ticks / obj4.Ticks * obj4.Ticks;
      obj0.ToTime = obj0.FromTime.AddTicks(num);
      return true;
    }
    List<IHistoryItem> historyItemList = obj1;
    IHistoryItem historyItem = historyItemList[historyItemList.Count - 1];
    long num1;
    switch (obj4.BasePeriod)
    {
      case BasePeriod.Month:
        num1 = historyItem.TimeLeft.AddMonths(obj4.PeriodMultiplier).Ticks;
        break;
      case BasePeriod.Year:
        num1 = historyItem.TimeLeft.AddYears(obj4.PeriodMultiplier).Ticks;
        break;
      default:
        num1 = historyItem.TicksLeft + obj4.Ticks;
        break;
    }
    long ticks1 = num1;
    long ticksLeft = historyItem.TicksLeft;
    DateTime toTime = obj0.ToTime;
    long ticks2 = toTime.Ticks;
    if (ticksLeft <= ticks2)
    {
      long num2 = ticks1;
      toTime = obj0.ToTime;
      long num3 = toTime.Ticks + 1L;
      if (num2 > num3)
      {
        obj1.Remove(historyItem);
        obj0.ToTime = historyItem.TimeLeft;
        goto label_15;
      }
    }
    obj0.ToTime = new DateTime(ticks1, DateTimeKind.Utc);
label_15:
    return true;
  }

  private static int 핇([In] HistoryRequestParameters obj0)
  {
    HashCode hashCode = new HashCode();
    hashCode.Add<string>(obj0.SymbolId);
    hashCode.Add<Interval<DateTime>>(obj0.Interval);
    hashCode.Add<bool>(obj0.ForceReload);
    hashCode.Add<string>(obj0.Aggregation.Name);
    switch (obj0.Aggregation)
    {
      case HistoryAggregationTick historyAggregationTick:
        hashCode.Add<HistoryType>(historyAggregationTick.HistoryType);
        break;
      case HistoryAggregationTickBars aggregationTickBars:
        hashCode.Add<int>(aggregationTickBars.TicksCount);
        hashCode.Add<HistoryType>(aggregationTickBars.HistoryType);
        break;
      case HistoryAggregationTime historyAggregationTime:
        hashCode.Add<Period>(historyAggregationTime.Period);
        hashCode.Add<HistoryType>(historyAggregationTime.HistoryType);
        break;
      case HistoryAggregationTimeStatistics aggregationTimeStatistics:
        hashCode.Add<Period>(aggregationTimeStatistics.Period);
        break;
      default:
        throw new Exception(obj0.Aggregation.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픴());
    }
    return hashCode.ToHashCode();
  }

  private bool 퓲([In] HistoryRequestParameters obj0_1)
  {
    if (!obj0_1.CancellationToken.IsCancellationRequested)
      return false;
    int key = 퓔.핇(obj0_1);
    lock (this.핂픠)
    {
      List<퓔.퓏> source;
      if (!this.핂픅.TryGetValue(key, out source))
        return true;
      if (source.Any<퓔.퓏>((Func<퓔.퓏, bool>) (([In] obj0_2) => !obj0_2.IsCancelled)))
        return false;
      this.핂픅.Remove(key);
      return true;
    }
  }

  private class 퓏
  {
    private readonly CancellationToken 퓗픘;
    private readonly ManualResetEventSlim 퓗픨;
    private IList<IHistoryItem> 퓗퓪;

    public bool IsCancelled => this.퓗픘.IsCancellationRequested;

    public IList<IHistoryItem> History
    {
      get => this.퓗퓪;
      [param: In] set
      {
        this.퓗퓪 = value;
        this.퓗픨.Set();
      }
    }

    public 퓏([In] CancellationToken obj0)
    {
      this.퓗픘 = obj0;
      this.퓗픨 = new ManualResetEventSlim();
    }

    public void 퓏([In] CancellationToken obj0)
    {
      WaitHandle.WaitAny(new WaitHandle[2]
      {
        this.퓗픨.WaitHandle,
        obj0.WaitHandle
      });
    }
  }
}
