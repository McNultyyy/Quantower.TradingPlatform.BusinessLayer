// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.HistoricalData
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using TradingPlatform.BusinessLayer.Utils;
using 퓏;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>
/// Represent access to historical data information and indicators control.
/// </summary>
[Published]
public class HistoricalData : 
  IDisposable,
  IIndicatorsCollection,
  퓏.퓲,
  IEnumerable<IHistoryItem>,
  IEnumerable
{
  private readonly List<IHistoryItem> 퓍픧;
  protected readonly object itemsLocker;
  protected HistoryRequestParameters Parameters;
  private protected IHistoryProcessor 퓍퓹;
  private bool 퓍픝;
  private CancellationTokenSource 퓍픻;
  private HistoricalDataState 퓍퓤;
  private readonly ConcurrentQueue<MessageQuote> 퓍픮;
  private readonly bool 퓍픉;
  private MessageQuote 퓍픒;
  private MessageQuote 퓍퓷;
  private MessageQuote 퓍퓿;
  private readonly ManualResetEventSlim 퓍픟;
  private protected readonly List<Indicator> 퓍퓧;
  private readonly object 퓍픰;

  /// <summary>Gets HistoricalData symbol</summary>
  public Symbol Symbol => this.Parameters?.Symbol;

  /// <summary>Gets HistoricalData aggregation</summary>
  public HistoryAggregation Aggregation => this.Parameters?.Aggregation;

  /// <summary>Gets HistoricalData left time boundary</summary>
  public DateTime FromTime => this.Parameters.FromTime;

  /// <summary>Gets HistoricalData right time boundary</summary>
  public DateTime ToTime => this.Parameters.ToTime;

  /// <summary>Gets HistoricalData items amount</summary>
  public virtual int Count
  {
    get
    {
      lock (this.itemsLocker)
        return this.퓍픧.Count;
    }
  }

  /// <summary>
  /// Retrieves HistoricalData item by indexing offset and direction to find.
  /// </summary>
  /// <param name="offset"></param>
  /// <param name="origin"></param>
  /// <returns></returns>
  public virtual IHistoryItem this[int offset, SeekOriginHistory origin = SeekOriginHistory.End]
  {
    get => origin != SeekOriginHistory.End ? this.퓍픧[offset] : this.퓍픧[this.Count - 1 - offset];
    [param: In] private set
    {
      lock (this.itemsLocker)
      {
        if (_param2 == SeekOriginHistory.End)
          this.퓍픧[this.Count - 1 - obj0] = value;
        else
          this.퓍픧[obj0] = value;
      }
    }
  }

  /// <summary>Will be triggered when new historical item created</summary>
  public event HistoryEventHandler NewHistoryItem;

  /// <summary>
  /// Will be triggered when current historical item changed or updated
  /// </summary>
  public event HistoryEventHandler HistoryItemUpdated;

  [CompilerGenerated]
  [SpecialName]
  internal void 퓏([In] HistoryEventHandler obj0)
  {
    // ISSUE: reference to a compiler-generated field
    HistoryEventHandler historyEventHandler = this.퓍퓰;
    HistoryEventHandler comparand;
    do
    {
      comparand = historyEventHandler;
      // ISSUE: reference to a compiler-generated field
      historyEventHandler = Interlocked.CompareExchange<HistoryEventHandler>(ref this.퓍퓰, comparand + obj0, comparand);
    }
    while (historyEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  internal void 퓬([In] HistoryEventHandler obj0)
  {
    // ISSUE: reference to a compiler-generated field
    HistoryEventHandler historyEventHandler = this.퓍퓰;
    HistoryEventHandler comparand;
    do
    {
      comparand = historyEventHandler;
      // ISSUE: reference to a compiler-generated field
      historyEventHandler = Interlocked.CompareExchange<HistoryEventHandler>(ref this.퓍퓰, comparand - obj0, comparand);
    }
    while (historyEventHandler != comparand);
  }

  /// <summary>Gets access to built-in indicators</summary>
  public BuiltInIndicators BuiltInIndicators { get; }

  protected virtual bool NeedSubscribe => !this.퓍픝 && this.ToTime == new DateTime();

  private protected HistoricalData()
  {
    this.퓍픧 = new List<IHistoryItem>();
    this.itemsLocker = new object();
    this.퓍픝 = false;
    this.퓍퓧 = new List<Indicator>();
    this.퓍픰 = new object();
    this.퓍퓤 = HistoricalDataState.Pending;
    this.퓍픮 = new ConcurrentQueue<MessageQuote>();
    this.퓍픟 = new ManualResetEventSlim();
  }

  protected internal HistoricalData(HistoryRequestParameters historyRequestParameters)
    : this()
  {
    this.Parameters = historyRequestParameters;
    HistoryAggregation historyAggregation1 = Core.Instance.HistoryAggregations[this.Parameters.Aggregation.Name];
    if (historyAggregation1 == null)
      throw new ArgumentException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픣() + this.Parameters.Aggregation.Name);
    if (historyAggregation1.Clone() is HistoryAggregation historyAggregation2)
      historyAggregation2.Settings = this.Parameters.Aggregation.Settings;
    this.Parameters.Aggregation = historyAggregation2;
    this.퓍픉 = historyRequestParameters.ForceReload;
    this.BuiltInIndicators = new BuiltInIndicators((IIndicatorsCollection) this);
  }

  /// <summary>Reloads entire HistoricalData</summary>
  public void Reload()
  {
    if (this.Symbol == null)
      return;
    if (this.Symbol.State == BusinessObjectState.Fake)
      return;
    try
    {
      this.퓍퓤 = HistoricalDataState.Loading;
      this.퓍픻?.Cancel();
      if (this.Parameters.CancellationToken == CancellationToken.None)
        this.퓍픻 = new CancellationTokenSource();
      this.퓬();
      this.퓏();
      DateTime dateTimeUtcNow = Core.Instance.TimeUtils.DateTimeUtcNow;
      HistoryRequestParameters copy = this.Parameters.Copy;
      copy.ToTime = this.ToTime == new DateTime() || this.ToTime >= dateTimeUtcNow ? dateTimeUtcNow : this.ToTime;
      if (this.Symbol.QuoteDelay != new TimeSpan() && copy.ToTime > dateTimeUtcNow - this.Symbol.QuoteDelay)
        copy.ToTime = dateTimeUtcNow - this.Symbol.QuoteDelay;
      copy.ForceReload = this.퓍픉;
      HistoryRequestParameters requestParameters = copy;
      CancellationTokenSource 퓍픻 = this.퓍픻;
      CancellationToken cancellationToken = 퓍픻 != null ? 퓍픻.Token : this.Parameters.CancellationToken;
      requestParameters.CancellationToken = cancellationToken;
      copy.ProgressInfo = this.Parameters.ProgressInfo;
      Symbol historySymbol;
      if (Core.Instance.SymbolsMapping.TryGetHistorySymbol(this.Symbol, copy.Aggregation.GetPeriod, out historySymbol))
        copy.Symbol = historySymbol;
      if (this.NeedSubscribe)
      {
        this.SubscribeSymbol();
        WaitHandle.WaitAny(new WaitHandle[3]
        {
          copy.CancellationToken.WaitHandle,
          this.퓍픟.WaitHandle,
          new CancellationTokenSource(TimeSpan.FromSeconds(3.0)).Token.WaitHandle
        });
        if (this.퓍픒 != null)
          copy.ToTime = this.퓍픒.Time.AddMilliseconds(1.0);
      }
      if ((!(this.FromTime == this.ToTime) ? 0 : (this.ToTime == new DateTime() ? 1 : 0)) == 0)
      {
        IList<IHistoryItem> historyItemList = this.퓏(copy);
        if (this.Parameters.ExcludeOutOfSession && historyItemList != null && historyItemList.Count > 0 && this.Parameters.SessionsContainer != null && ((IEnumerable<ISession>) this.Parameters.SessionsContainer.ActiveSessions).Any<ISession>())
        {
          HistoryAggregation toDirectDownload = this.Parameters.Aggregation.GetAggregationToDirectDownload(this.Parameters.Symbol.HistoryMetadata);
          if (toDirectDownload == null || !(toDirectDownload is HistoryAggregationTime historyAggregationTime) || !(historyAggregationTime.Period >= Period.DAY1))
            historyItemList = (IList<IHistoryItem>) historyItemList.Where<IHistoryItem>((Func<IHistoryItem, bool>) (([In] obj0) => this.Parameters.SessionsContainer.ContainsDate(obj0.TicksLeft))).ToList<IHistoryItem>();
        }
        if (historyItemList != null)
        {
          lock (this.itemsLocker)
            this.퓍픧.AddRange((IEnumerable<IHistoryItem>) historyItemList);
        }
      }
      lock (this.퓍픰)
        this.퓍퓧.ForEach((Action<Indicator>) (([In] obj0) => obj0.Refresh()));
      this.핇();
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
    finally
    {
      this.퓍퓤 = HistoricalDataState.Working;
    }
  }

  private protected virtual IList<IHistoryItem> 퓏([In] HistoryRequestParameters obj0_1)
  {
    LoggerManager loggers1 = Core.Instance.Loggers;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(49, 4);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픡());
    interpolatedStringHandler.AppendFormatted<long>(obj0_1.RequestId);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓳());
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓙());
    interpolatedStringHandler.AppendFormatted<Symbol>(obj0_1.Symbol);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픆());
    interpolatedStringHandler.AppendFormatted<HistoryAggregation>(obj0_1.Aggregation);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픆());
    interpolatedStringHandler.AppendFormatted<Interval<DateTime>>(obj0_1.Interval);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픷());
    string stringAndClear1 = interpolatedStringHandler.ToStringAndClear();
    loggers1.Log(stringAndClear1, LoggingLevel.Performance);
    DateTime dateTimeUtcNow = Core.Instance.TimeUtils.DateTimeUtcNow;
    long num1 = 0;
    int num2 = 0;
    List<IHistoryItem> source = new List<IHistoryItem>();
    if (obj0_1.Symbol.State == BusinessObjectState.Fake)
      return (IList<IHistoryItem>) source;
    if (obj0_1.FromTime > obj0_1.ToTime)
      return (IList<IHistoryItem>) source;
    Connection connection = Core.Instance.Connections[obj0_1.Symbol.ConnectionId];
    if ((connection != null ? (!connection.Connected ? 1 : 0) : 1) != 0)
      return (IList<IHistoryItem>) source;
    CancellationToken cancellationToken = obj0_1.CancellationToken;
    HistoryRequestParameters copy1 = obj0_1.Copy;
    copy1.ProgressInfo = obj0_1.ProgressInfo;
    HistoryAggregation toDirectDownload = copy1.Aggregation.GetAggregationToDirectDownload(obj0_1.Symbol.HistoryMetadata);
    if (toDirectDownload == null)
      return (IList<IHistoryItem>) source;
    copy1.Aggregation = toDirectDownload;
    Interval<DateTime>[] array1 = copy1.Interval.Split(obj0_1.Symbol.GetHistoryDownloadingStep(copy1.Aggregation)).ToArray<Interval<DateTime>>();
    if (!((IEnumerable<Interval<DateTime>>) array1).Any<Interval<DateTime>>())
      return (IList<IHistoryItem>) source;
    long ticks1 = copy1.FromTime.Ticks;
    foreach (Interval<DateTime> interval in array1)
    {
      if (cancellationToken.IsCancellationRequested)
        return (IList<IHistoryItem>) source;
      int num3 = ++num2 * 100 / array1.Length;
      HistoryRequestParameters copy2 = copy1.Copy;
      copy2.FromTime = interval.From;
      copy2.ToTime = interval.To;
      LoggerManager loggers2 = Core.Instance.Loggers;
      interpolatedStringHandler = new DefaultInterpolatedStringHandler(35, 4);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픡());
      interpolatedStringHandler.AppendFormatted<long>(obj0_1.RequestId);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓳());
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓗());
      interpolatedStringHandler.AppendFormatted<int>(num2);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픉());
      interpolatedStringHandler.AppendFormatted<int>(array1.Length);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픎());
      interpolatedStringHandler.AppendFormatted<Interval<DateTime>>(copy2.Interval);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픷());
      string stringAndClear2 = interpolatedStringHandler.ToStringAndClear();
      loggers2.Log(stringAndClear2, LoggingLevel.Performance);
      IList<IHistoryItem> historyItemList1 = connection.HistoryLoadingManager.퓏(copy2);
      IHistoryItem historyItem1 = historyItemList1.LastOrDefault<IHistoryItem>();
      Period period;
      if (historyItem1 != null)
      {
        long ticksLeft = historyItem1.TicksLeft;
        period = copy1.Aggregation.GetPeriod;
        long ticks2 = period.Ticks;
        ticks1 = ticksLeft + ticks2;
      }
      LoggerManager loggers3 = Core.Instance.Loggers;
      interpolatedStringHandler = new DefaultInterpolatedStringHandler(75, 4);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픡());
      interpolatedStringHandler.AppendFormatted<long>(obj0_1.RequestId);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓠());
      interpolatedStringHandler.AppendFormatted<int>(num2);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픉());
      interpolatedStringHandler.AppendFormatted<int>(array1.Length);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓥());
      interpolatedStringHandler.AppendFormatted<int>(historyItemList1.Count);
      string stringAndClear3 = interpolatedStringHandler.ToStringAndClear();
      loggers3.Log(stringAndClear3, LoggingLevel.Performance);
      if (cancellationToken.IsCancellationRequested)
        return (IList<IHistoryItem>) source;
      num1 += (long) historyItemList1.Count;
      IList<IHistoryItem> collection1 = historyItemList1.Count > 0 ? this.퓍퓹.AggregateHistory(new HistoryHolder(historyItemList1, copy1, !obj0_1.Symbol.HistoryMetadata.BuildUncompletedBars || num3 != 100 ? num3 : 99)) : (IList<IHistoryItem>) new List<IHistoryItem>();
      if (cancellationToken.IsCancellationRequested)
        return (IList<IHistoryItem>) source;
      source.AddRange((IEnumerable<IHistoryItem>) collection1);
      LoggerManager loggers4 = Core.Instance.Loggers;
      interpolatedStringHandler = new DefaultInterpolatedStringHandler(76, 4);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픡());
      interpolatedStringHandler.AppendFormatted<long>(obj0_1.RequestId);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓳());
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓗());
      interpolatedStringHandler.AppendFormatted<int>(num2);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픉());
      interpolatedStringHandler.AppendFormatted<int>(array1.Length);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓯());
      interpolatedStringHandler.AppendFormatted<int>(collection1.Count);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픷());
      string stringAndClear4 = interpolatedStringHandler.ToStringAndClear();
      loggers4.Log(stringAndClear4, LoggingLevel.Performance);
      if (obj0_1.ProgressInfo != null && array1.Length > 2)
        obj0_1.ProgressInfo.Report((float) num3 / 100f);
      LoggerManager loggers5 = Core.Instance.Loggers;
      interpolatedStringHandler = new DefaultInterpolatedStringHandler(40, 3);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픡());
      interpolatedStringHandler.AppendFormatted<long>(obj0_1.RequestId);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓠());
      interpolatedStringHandler.AppendFormatted<int>(num2);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픉());
      interpolatedStringHandler.AppendFormatted<int>(array1.Length);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픜());
      string stringAndClear5 = interpolatedStringHandler.ToStringAndClear();
      loggers5.Log(stringAndClear5, LoggingLevel.Performance);
      if (obj0_1.Symbol.HistoryMetadata.BuildUncompletedBars && num3 == 100)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        HistoricalData.퓬 퓬 = new HistoricalData.퓬();
        HistoryAggregation aggregation1 = copy1.Aggregation;
        // ISSUE: reference to a compiler-generated field
        퓬.퓥픖 = aggregation1 as HistoryAggregationTime;
        DateTime toTime;
        // ISSUE: reference to a compiler-generated field
        if (퓬.퓥픖 == null)
        {
          if (!(aggregation1 is HistoryAggregationTickBars aggregationTickBars))
          {
            // ISSUE: reference to a compiler-generated field
            퓬.퓥퓘 = aggregation1 as HistoryAggregationTimeStatistics;
            // ISSUE: reference to a compiler-generated field
            if (퓬.퓥퓘 == null)
            {
              // ISSUE: reference to a compiler-generated field
              퓬.퓥픓 = aggregation1 as HistoryAggregationVolumeProfile;
              // ISSUE: reference to a compiler-generated field
              if (퓬.퓥픓 != null)
              {
                // ISSUE: reference to a compiler-generated method
                // ISSUE: reference to a compiler-generated method
                IEnumerable<HistoryAggregationVolumeProfile> first = ((IEnumerable<Period>) obj0_1.Symbol.HistoryMetadata.AllowedPeriodsHistoryAggregationTimeStatistics).Where<Period>(new Func<Period, bool>(퓬.픂)).GroupBy<Period, BasePeriod>((Func<Period, BasePeriod>) (([In] obj0_2) => obj0_2.BasePeriod)).Select<IGrouping<BasePeriod, Period>, Period>((Func<IGrouping<BasePeriod, Period>, Period>) (([In] obj0_4) => obj0_4.OrderByDescending<Period, int>((Func<Period, int>) (([In] obj0_3) => obj0_3.PeriodMultiplier)).Last<Period>())).Union<Period>(((IEnumerable<BasePeriod>) obj0_1.Symbol.HistoryMetadata.AllowedBasePeriodsHistoryAggregationTimeStatistics).Select<BasePeriod, Period>((Func<BasePeriod, Period>) (([In] obj0_5) => new Period(obj0_5, 1)))).Where<Period>(new Func<Period, bool>(퓬.픾)).OrderByDescending<Period, long>((Func<Period, long>) (([In] obj0_6) => obj0_6.Ticks)).Select<Period, HistoryAggregationVolumeProfile>((Func<Period, HistoryAggregationVolumeProfile>) (([In] obj0_7) => new HistoryAggregationVolumeProfile(obj0_7)));
                HistoryAggregation[] second;
                if (!((IEnumerable<string>) obj0_1.Symbol.HistoryMetadata.AllowedAggregations).Contains<string>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓑()))
                  second = Array.Empty<HistoryAggregation>();
                else
                  second = new HistoryAggregation[1]
                  {
                    (HistoryAggregation) new HistoryAggregationTick(HistoryType.Last)
                  };
                HistoryAggregation[] array2 = ((IEnumerable<HistoryAggregation>) first).Union<HistoryAggregation>((IEnumerable<HistoryAggregation>) second).ToArray<HistoryAggregation>();
                for (int index = 0; index < array2.Length; ++index)
                {
                  HistoryAggregation aggregation2 = array2[index];
                  TimeSpan historyDownloadingStep = obj0_1.Symbol.GetHistoryDownloadingStep(aggregation2);
                  toTime = copy1.ToTime;
                  if (toTime.Ticks - ticks1 > historyDownloadingStep.Ticks)
                  {
                    toTime = copy1.ToTime;
                    ticks1 = toTime.Ticks - historyDownloadingStep.Ticks;
                  }
                  HistoryRequestParameters requestParameters = new HistoryRequestParameters(copy1)
                  {
                    FromTime = new DateTime(ticks1, DateTimeKind.Utc),
                    Aggregation = aggregation2
                  };
                  IList<IHistoryItem> historyItemList2 = connection.HistoryLoadingManager.퓏(requestParameters);
                  IHistoryItem historyItem2 = historyItemList2.LastOrDefault<IHistoryItem>();
                  if (historyItem2 != null && aggregation2 is HistoryAggregationVolumeProfile aggregationVolumeProfile)
                  {
                    long ticksLeft = historyItem2.TicksLeft;
                    period = aggregationVolumeProfile.Period;
                    long ticks3 = period.Ticks;
                    ticks1 = ticksLeft + ticks3;
                  }
                  IList<IHistoryItem> collection2 = this.퓍퓹.AggregateHistory(new HistoryHolder(historyItemList2, requestParameters, index == array2.Length - 1 ? 100 : 99));
                  source.AddRange((IEnumerable<IHistoryItem>) collection2);
                }
              }
            }
            else
            {
              // ISSUE: reference to a compiler-generated method
              // ISSUE: reference to a compiler-generated method
              IEnumerable<HistoryAggregationTimeStatistics> first = ((IEnumerable<Period>) obj0_1.Symbol.HistoryMetadata.AllowedPeriodsHistoryAggregationTimeStatistics).Where<Period>(new Func<Period, bool>(퓬.퓲)).GroupBy<Period, BasePeriod>((Func<Period, BasePeriod>) (([In] obj0_8) => obj0_8.BasePeriod)).Select<IGrouping<BasePeriod, Period>, Period>((Func<IGrouping<BasePeriod, Period>, Period>) (([In] obj0_10) => obj0_10.OrderByDescending<Period, int>((Func<Period, int>) (([In] obj0_9) => obj0_9.PeriodMultiplier)).Last<Period>())).Union<Period>(((IEnumerable<BasePeriod>) obj0_1.Symbol.HistoryMetadata.AllowedBasePeriodsHistoryAggregationTimeStatistics).Select<BasePeriod, Period>((Func<BasePeriod, Period>) (([In] obj0_11) => new Period(obj0_11, 1)))).Where<Period>(new Func<Period, bool>(퓬.핂)).OrderByDescending<Period, long>((Func<Period, long>) (([In] obj0_12) => obj0_12.Ticks)).Select<Period, HistoryAggregationTimeStatistics>((Func<Period, HistoryAggregationTimeStatistics>) (([In] obj0_13) => new HistoryAggregationTimeStatistics(obj0_13)));
              HistoryAggregation[] second;
              if (!((IEnumerable<string>) obj0_1.Symbol.HistoryMetadata.AllowedAggregations).Contains<string>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓑()))
                second = Array.Empty<HistoryAggregation>();
              else
                second = new HistoryAggregation[1]
                {
                  (HistoryAggregation) new HistoryAggregationTick(HistoryType.Last)
                };
              HistoryAggregation[] array3 = ((IEnumerable<HistoryAggregation>) first).Union<HistoryAggregation>((IEnumerable<HistoryAggregation>) second).ToArray<HistoryAggregation>();
              for (int index = 0; index < array3.Length; ++index)
              {
                HistoryAggregation aggregation3 = array3[index];
                TimeSpan historyDownloadingStep = obj0_1.Symbol.GetHistoryDownloadingStep(aggregation3);
                toTime = copy1.ToTime;
                if (toTime.Ticks - ticks1 > historyDownloadingStep.Ticks)
                {
                  toTime = copy1.ToTime;
                  ticks1 = toTime.Ticks - historyDownloadingStep.Ticks;
                }
                HistoryRequestParameters requestParameters = new HistoryRequestParameters(copy1)
                {
                  FromTime = new DateTime(ticks1, DateTimeKind.Utc),
                  Aggregation = aggregation3
                };
                IList<IHistoryItem> historyItemList3 = connection.HistoryLoadingManager.퓏(requestParameters);
                IHistoryItem historyItem3 = historyItemList3.LastOrDefault<IHistoryItem>();
                if (historyItem3 != null && aggregation3 is HistoryAggregationTimeStatistics aggregationTimeStatistics)
                {
                  long ticksLeft = historyItem3.TicksLeft;
                  period = aggregationTimeStatistics.Period;
                  long ticks4 = period.Ticks;
                  ticks1 = ticksLeft + ticks4;
                }
                IList<IHistoryItem> collection3 = this.퓍퓹.AggregateHistory(new HistoryHolder(historyItemList3, requestParameters, index == array3.Length - 1 ? 100 : 99));
                source.AddRange((IEnumerable<IHistoryItem>) collection3);
              }
            }
          }
          else if (((IEnumerable<string>) obj0_1.Symbol.HistoryMetadata.AllowedAggregations).Contains<string>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓑()) && ((IEnumerable<HistoryType>) obj0_1.Symbol.HistoryMetadata.AllowedHistoryTypesHistoryAggregationTick).Contains<HistoryType>(aggregationTickBars.HistoryType))
          {
            if (source.Any<IHistoryItem>())
            {
              IHistoryItem historyItem4 = source.Last<IHistoryItem>();
              if (historyItem4.TicksRight == 0L)
              {
                source.RemoveAt(source.Count - 1);
                ticks1 = historyItem4.TicksLeft;
              }
              else
                ticks1 = historyItem4.TicksRight + 1L;
            }
            TimeSpan downloadingStepTick = obj0_1.Symbol.HistoryMetadata.DownloadingStep_Tick;
            toTime = copy1.ToTime;
            if (toTime.Ticks - ticks1 > downloadingStepTick.Ticks)
            {
              toTime = copy1.ToTime;
              ticks1 = toTime.Ticks - downloadingStepTick.Ticks;
            }
            HistoryRequestParameters requestParameters = new HistoryRequestParameters(copy1)
            {
              FromTime = new DateTime(ticks1, DateTimeKind.Utc),
              Aggregation = (HistoryAggregation) new HistoryAggregationTick(aggregationTickBars.HistoryType)
            };
            IList<IHistoryItem> collection4 = this.퓍퓹.AggregateHistory(new HistoryHolder(connection.HistoryLoadingManager.퓏(requestParameters), requestParameters));
            source.AddRange((IEnumerable<IHistoryItem>) collection4);
          }
        }
        else
        {
          // ISSUE: reference to a compiler-generated method
          // ISSUE: reference to a compiler-generated method
          // ISSUE: reference to a compiler-generated method
          IEnumerable<HistoryAggregationTime> first = ((IEnumerable<Period>) obj0_1.Symbol.HistoryMetadata.AllowedPeriodsHistoryAggregationTime).Where<Period>(new Func<Period, bool>(퓬.퓏)).GroupBy<Period, BasePeriod>((Func<Period, BasePeriod>) (([In] obj0_14) => obj0_14.BasePeriod)).Select<IGrouping<BasePeriod, Period>, Period>((Func<IGrouping<BasePeriod, Period>, Period>) (([In] obj0_16) => obj0_16.OrderByDescending<Period, int>((Func<Period, int>) (([In] obj0_15) => obj0_15.PeriodMultiplier)).Last<Period>())).Union<Period>(((IEnumerable<BasePeriod>) obj0_1.Symbol.HistoryMetadata.AllowedBasePeriodsHistoryAggregationTime).Select<BasePeriod, Period>((Func<BasePeriod, Period>) (([In] obj0_17) => new Period(obj0_17, 1)))).Where<Period>(new Func<Period, bool>(퓬.퓬)).OrderByDescending<Period, long>((Func<Period, long>) (([In] obj0_18) => obj0_18.Ticks)).Select<Period, HistoryAggregationTime>(new Func<Period, HistoryAggregationTime>(퓬.핇));
          HistoryAggregation[] second;
          if (!((IEnumerable<string>) obj0_1.Symbol.HistoryMetadata.AllowedAggregations).Contains<string>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓑()))
          {
            second = Array.Empty<HistoryAggregation>();
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            second = new HistoryAggregation[1]
            {
              (HistoryAggregation) new HistoryAggregationTick(퓬.퓥픖.HistoryType == HistoryType.Bid || 퓬.퓥픖.HistoryType == HistoryType.Ask ? HistoryType.BidAsk : 퓬.퓥픖.HistoryType)
            };
          }
          HistoryAggregation[] array4 = ((IEnumerable<HistoryAggregation>) first).Union<HistoryAggregation>((IEnumerable<HistoryAggregation>) second).ToArray<HistoryAggregation>();
          for (int index = 0; index < array4.Length; ++index)
          {
            HistoryAggregation aggregation4 = array4[index];
            TimeSpan historyDownloadingStep = obj0_1.Symbol.GetHistoryDownloadingStep(aggregation4);
            toTime = copy1.ToTime;
            if (toTime.Ticks - ticks1 > historyDownloadingStep.Ticks)
            {
              toTime = copy1.ToTime;
              ticks1 = toTime.Ticks - historyDownloadingStep.Ticks;
            }
            HistoryRequestParameters requestParameters = new HistoryRequestParameters(copy1)
            {
              FromTime = new DateTime(ticks1, DateTimeKind.Utc),
              Aggregation = aggregation4
            };
            IList<IHistoryItem> historyItemList4 = connection.HistoryLoadingManager.퓏(requestParameters);
            IHistoryItem historyItem5 = historyItemList4.LastOrDefault<IHistoryItem>();
            if (historyItem5 != null && aggregation4 is HistoryAggregationTime historyAggregationTime)
            {
              long ticksLeft = historyItem5.TicksLeft;
              period = historyAggregationTime.Period;
              long ticks5 = period.Ticks;
              ticks1 = ticksLeft + ticks5;
            }
            IList<IHistoryItem> collection5 = this.퓍퓹.AggregateHistory(new HistoryHolder(historyItemList4, requestParameters, index == array4.Length - 1 ? 100 : 99));
            source.AddRange((IEnumerable<IHistoryItem>) collection5);
          }
        }
      }
    }
    LoggerManager loggers6 = Core.Instance.Loggers;
    interpolatedStringHandler = new DefaultInterpolatedStringHandler(123, 4);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픡());
    interpolatedStringHandler.AppendFormatted<long>(obj0_1.RequestId);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓳());
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞핋());
    interpolatedStringHandler.AppendFormatted<double>((Core.Instance.TimeUtils.DateTimeUtcNow - dateTimeUtcNow).TotalSeconds, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓞());
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞핅());
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픡());
    interpolatedStringHandler.AppendFormatted<long>(num1);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픏());
    interpolatedStringHandler.AppendFormatted<int>(source.Count);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픷());
    string stringAndClear6 = interpolatedStringHandler.ToStringAndClear();
    loggers6.Log(stringAndClear6, LoggingLevel.Performance);
    return (IList<IHistoryItem>) source;
  }

  /// <summary>Gets index by time with counting on search direction</summary>
  public double GetIndexByTime(long time, SeekOriginHistory origin = SeekOriginHistory.End)
  {
    if (this.Count == 0 || time > this[0].TicksRight)
      return -1.0;
    double num1 = -1.0;
    int offset1 = 0;
    int offset2 = this.Count - 1;
    while (offset1 <= offset2)
    {
      int offset3 = (offset1 + offset2) / 2;
      if (offset2 - offset1 < 2)
      {
        int num2;
        num1 = time >= this[offset1, SeekOriginHistory.Begin].TicksLeft ? (time >= this[offset2, SeekOriginHistory.Begin].TicksLeft ? (double) offset2 : (double) offset1) : (double) (num2 = offset1 - 1);
        break;
      }
      if (time < this[offset3, SeekOriginHistory.Begin].TicksLeft)
        offset2 = offset3 - 1;
      else
        offset1 = offset3 + 1;
    }
    return origin == SeekOriginHistory.End && num1 != -1.0 ? (double) (this.Count - 1) - num1 : num1;
  }

  private void 퓬()
  {
    if (this.퓍퓹 != null)
    {
      this.퓍퓹.NewHistoryItem -= new HistoryEventHandler(this.퓏);
      this.퓍퓹.HistoryItemUpdated -= new HistoryEventHandler(this.퓬);
      this.퓍퓹.Dispose();
      this.퓍퓹 = (IHistoryProcessor) null;
    }
    this.퓍픮.Clear();
    lock (this.itemsLocker)
      this.퓍픧.Clear();
  }

  [NotPublished]
  public virtual void Dispose()
  {
    this.퓍픻?.Cancel();
    this.퓲();
    this.UnSubscribeSymbol();
    this.퓬();
    if (this.VolumeAnalysisCalculationProgress != null)
    {
      this.VolumeAnalysisCalculationProgress.AbortLoading();
      this.VolumeAnalysisCalculationProgress.Dispose();
      this.VolumeAnalysisCalculationProgress = (IVolumeAnalysisCalculationProgress) null;
    }
    this.Parameters = (HistoryRequestParameters) null;
  }

  protected virtual void SubscribeSymbol()
  {
    if (this.Symbol == null || this.퓍퓹 == null)
      return;
    SubscribeQuoteType? subscribeQuoteType = this.퓍퓹.GetSubscribeQuoteType;
    if (subscribeQuoteType.HasValue)
    {
      switch (subscribeQuoteType.GetValueOrDefault())
      {
        case SubscribeQuoteType.Quote:
          this.Symbol.NewQuote += new QuoteHandler(this.Symbol_NewQuote);
          break;
        case SubscribeQuoteType.Level2:
          this.Symbol.NewLevel2 += new Level2Handler(this.퓏);
          break;
        case SubscribeQuoteType.Last:
          this.Symbol.NewLast += new LastHandler(this.Symbol_NewLast);
          break;
        case SubscribeQuoteType.Mark:
          this.Symbol.NewMark += new MarkHandler(this.퓏);
          break;
      }
    }
    this.Symbol.NewDayBar += new DayBarHandler(this.퓏);
    this.퓍픝 = true;
  }

  protected virtual void UnSubscribeSymbol()
  {
    if (this.Symbol == null || this.퓍퓹 == null)
      return;
    SubscribeQuoteType? subscribeQuoteType = this.퓍퓹.GetSubscribeQuoteType;
    if (subscribeQuoteType.HasValue)
    {
      switch (subscribeQuoteType.GetValueOrDefault())
      {
        case SubscribeQuoteType.Quote:
          this.Symbol.NewQuote -= new QuoteHandler(this.Symbol_NewQuote);
          break;
        case SubscribeQuoteType.Level2:
          this.Symbol.NewLevel2 -= new Level2Handler(this.퓏);
          break;
        case SubscribeQuoteType.Last:
          this.Symbol.NewLast -= new LastHandler(this.Symbol_NewLast);
          break;
        case SubscribeQuoteType.Mark:
          this.Symbol.NewMark -= new MarkHandler(this.퓏);
          break;
      }
    }
    this.Symbol.NewDayBar -= new DayBarHandler(this.퓏);
    this.퓍픒 = (MessageQuote) null;
    this.퓍퓷 = (MessageQuote) null;
    this.퓍픟.Reset();
  }

  protected void Symbol_NewQuote(Symbol symbol, Quote quote)
  {
    if (this.퓏((MessageQuote) quote))
      return;
    this.ProcessQuote(quote);
  }

  protected void Symbol_NewLast(Symbol symbol, Last last)
  {
    if (this.퓏((MessageQuote) last))
      return;
    this.ProcessLast(last);
  }

  private void 퓏([In] Symbol obj0, [In] Mark obj1)
  {
    if (this.퓏((MessageQuote) obj1))
      return;
    this.ProcessMark(obj1);
  }

  private void 퓏([In] Symbol obj0, [In] DayBar obj1)
  {
    if (this.퓏((MessageQuote) obj1))
      return;
    this.퓏(obj1);
  }

  private void 퓏([In] Symbol obj0, [In] Level2Quote obj1, [In] DOMQuote obj2)
  {
    MessageQuote quote = (MessageQuote) obj1 ?? (MessageQuote) obj2;
    if (this.퓏(quote))
      return;
    this.ProcessLevel2Qute(quote);
  }

  private bool 퓏([In] MessageQuote obj0)
  {
    // ISSUE: variable of a compiler-generated type
    HistoricalData.핇 핇;
    // ISSUE: reference to a compiler-generated field
    핇.퓥픩 = this;
    // ISSUE: reference to a compiler-generated field
    핇.퓥필 = obj0;
    if (this.퓍퓤 != HistoricalDataState.Loading && this.퓍픮.IsEmpty)
      return false;
    // ISSUE: reference to a compiler-generated method
    if (this.퓍픒 == null && this.퓏(ref 핇))
    {
      // ISSUE: reference to a compiler-generated field
      this.퓍픒 = 핇.퓥필;
      this.퓍픟.Set();
    }
    // ISSUE: reference to a compiler-generated field
    this.퓍픮.Enqueue(핇.퓥필);
    return true;
  }

  private void 핇()
  {
    DateTime? timeLeft = this.LastOrDefault<IHistoryItem>()?.TimeLeft;
    MessageQuote result;
    while (this.퓍픮.TryDequeue(out result))
    {
      if (result != null)
      {
        if (timeLeft.HasValue)
        {
          DateTime time = result.Time;
          DateTime? nullable = timeLeft;
          if ((nullable.HasValue ? (time <= nullable.GetValueOrDefault() ? 1 : 0) : 0) != 0)
            continue;
        }
        switch (result)
        {
          case Quote quote:
            this.ProcessQuote(quote);
            continue;
          case Last last:
            this.ProcessLast(last);
            continue;
          case Mark mark:
            this.ProcessMark(mark);
            continue;
          default:
            continue;
        }
      }
    }
  }

  protected virtual void ProcessQuote(Quote quote)
  {
    this.퓍퓷 = (MessageQuote) quote;
    this.퓍퓹?.ProcessQuote((MessageQuote) quote);
  }

  protected virtual void ProcessLast(Last last)
  {
    this.퓍퓷 = (MessageQuote) last;
    this.퓍퓹?.ProcessQuote((MessageQuote) last);
  }

  protected virtual void ProcessMark(Mark mark)
  {
    this.퓍퓷 = (MessageQuote) mark;
    this.퓍퓹?.ProcessQuote((MessageQuote) mark);
  }

  private void 퓏([In] DayBar obj0)
  {
    this.퓍퓷 = (MessageQuote) obj0;
    this.퓍퓹?.ProcessQuote((MessageQuote) obj0);
  }

  protected virtual void ProcessLevel2Qute(MessageQuote quote)
  {
    this.퓍퓷 = quote;
    this.퓍퓹?.ProcessQuote(quote);
  }

  /// <summary>Gets array of attached indicators</summary>
  public Indicator[] AttachedIndicators
  {
    get
    {
      lock (this.퓍픰)
        return this.퓍퓧.ToArray();
    }
  }

  /// <summary>
  /// Creates indicator by it's name and if it successfully created adds it to the HistoricalData
  /// </summary>
  /// <param name="indicatorName"></param>
  /// <param name="settings"></param>
  /// <returns></returns>
  public Indicator AddIndicator(string indicatorName, params SettingItem[] settings)
  {
    if (string.IsNullOrEmpty(indicatorName))
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픮());
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(indicatorName, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓥(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓥());
    if (indicator == null)
      throw new InvalidOperationException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓳());
    indicator.Settings = (IList<SettingItem>) settings;
    this.AddIndicator(indicator);
    return indicator;
  }

  /// <summary>Adds indicator to the HistoricalData</summary>
  /// <param name="indicator"></param>
  public void AddIndicator(Indicator indicator)
  {
    if (indicator == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞핆());
    lock (this.퓍픰)
    {
      if (this.퓍퓧.Contains(indicator))
        throw new InvalidOperationException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픷());
      this.퓍퓧.Add(indicator);
      lock (this.itemsLocker)
      {
        indicator.HistoricalData = this;
        indicator.Init();
        bool flag = this.Count > 0;
        DefaultInterpolatedStringHandler interpolatedStringHandler;
        if (flag)
        {
          LoggerManager loggers = Core.Instance.Loggers;
          interpolatedStringHandler = new DefaultInterpolatedStringHandler(39, 3);
          interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓻());
          interpolatedStringHandler.AppendFormatted<Symbol>(this.Symbol);
          interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프());
          interpolatedStringHandler.AppendFormatted(indicator.Name);
          interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픸());
          interpolatedStringHandler.AppendFormatted<int>(this.Count);
          interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓷());
          string stringAndClear = interpolatedStringHandler.ToStringAndClear();
          loggers.Log(stringAndClear);
        }
        DateTime dateTimeUtcNow = Core.Instance.TimeUtils.DateTimeUtcNow;
        for (int index = indicator.UpdateType != 0 ? 1 : 0; index < this.Count; ++index)
          indicator.Update(new UpdateArgs(UpdateReason.HistoricalBar));
        if (!flag)
          return;
        LoggerManager loggers1 = Core.Instance.Loggers;
        interpolatedStringHandler = new DefaultInterpolatedStringHandler(50, 3);
        interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓻());
        interpolatedStringHandler.AppendFormatted<Symbol>(this.Symbol);
        interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프());
        interpolatedStringHandler.AppendFormatted(indicator.Name);
        interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞프());
        interpolatedStringHandler.AppendFormatted((Core.Instance.TimeUtils.DateTimeUtcNow - dateTimeUtcNow).TotalSeconds.ToString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓞()));
        interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픴());
        string stringAndClear1 = interpolatedStringHandler.ToStringAndClear();
        loggers1.Log(stringAndClear1);
      }
    }
  }

  /// <summary>Removes indicator from the HistoricalData</summary>
  /// <param name="indicator"></param>
  public void RemoveIndicator(Indicator indicator)
  {
    if (indicator == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞핆());
    lock (this.퓍픰)
      this.퓍퓧.Remove(indicator);
    indicator.Clear();
  }

  void 퓏.퓲.퓏([In] Indicator obj0)
  {
    lock (this.퓍픰)
    {
      lock (this.itemsLocker)
      {
        obj0.Clear();
        obj0.Init();
        int num = obj0.UpdateType == IndicatorUpdateType.OnBarClose ? this.Count - 1 : this.Count;
        for (int index = 0; index < num; ++index)
          obj0.Update(new UpdateArgs(UpdateReason.HistoricalBar));
      }
    }
  }

  private protected void 퓏([In] UpdateArgs obj0, IndicatorUpdateType? _param2 = null)
  {
    lock (this.퓍픰)
    {
      foreach (Indicator indicator in this.퓍퓧)
      {
        if (_param2.HasValue)
        {
          int updateType = (int) indicator.UpdateType;
          IndicatorUpdateType? nullable = _param2;
          int valueOrDefault = (int) nullable.GetValueOrDefault();
          if (!(updateType == valueOrDefault & nullable.HasValue))
            continue;
        }
        indicator.Update(obj0.퓏());
      }
    }
  }

  private void 퓲()
  {
    lock (this.퓍픰)
    {
      foreach (Indicator indicator in this.퓍퓧)
      {
        indicator.Clear();
        indicator.Dispose();
      }
      this.퓍퓧.Clear();
    }
  }

  /// <summary>
  /// Will be triggered when volume analysis of current historical item changed or updated
  /// </summary>
  public event Action HistoryItemVolumeAnalysisUpdated;

  [NotPublished]
  public IVolumeAnalysisCalculationProgress VolumeAnalysisCalculationProgress { get; set; }

  public IVolumeAnalysisCalculationProgress CalculateVolumeProfile(
    VolumeAnalysisCalculationParameters volumeAnalysisCalculationParameters)
  {
    return Core.Instance.VolumeAnalysis.CalculateProfile(this, volumeAnalysisCalculationParameters);
  }

  public IEnumerator GetEnumerator() => (IEnumerator) this.퓍픧.GetEnumerator();

  IEnumerator<IHistoryItem> IEnumerable<IHistoryItem>.핂()
  {
    return (IEnumerator<IHistoryItem>) this.퓍픧.GetEnumerator();
  }

  protected virtual IHistoryProcessor CreateHistoryProcessor()
  {
    return Core.Instance.HistoryAggregations.CreateHistoryProcessor(this.Parameters);
  }

  private protected virtual void 퓏()
  {
    this.퓍퓹 = this.CreateHistoryProcessor();
    if (this.퓍퓹 == null)
      throw new InvalidOperationException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픑());
    this.퓍퓹.CorrectHistoryRequestBorders(this.Parameters);
    this.퓍퓹.NewHistoryItem += new HistoryEventHandler(this.퓏);
    this.퓍퓹.HistoryItemUpdated += new HistoryEventHandler(this.퓬);
  }

  private void 퓏([In] object obj0, [In] HistoryEventArgs obj1)
  {
    if (obj1.HistoryItem == null || this.Parameters.ExcludeOutOfSession && this.Parameters.SessionsContainer != null && !this.Parameters.SessionsContainer.ContainsDate(obj1.HistoryItem.TicksLeft))
      return;
    this.AddNewItem(obj1.HistoryItem, e: obj1);
  }

  private void 퓬([In] object obj0, [In] HistoryEventArgs obj1)
  {
    if (obj1.HistoryItem == null || this.Parameters.ExcludeOutOfSession && this.Parameters.SessionsContainer != null && !this.Parameters.SessionsContainer.ContainsDate(obj1.HistoryItem.TicksLeft))
      return;
    if (obj1.ResetVolumeAnalysisRequired)
    {
      obj1.HistoryItem.VolumeAnalysisData = (VolumeAnalysisData) null;
    }
    else
    {
      IHistoryItem historyItem = obj1.HistoryItem;
      if (historyItem.VolumeAnalysisData == null)
      {
        VolumeAnalysisData volumeAnalysisData;
        historyItem.VolumeAnalysisData = volumeAnalysisData = this[0]?.VolumeAnalysisData;
      }
    }
    this[0] = obj1.HistoryItem;
    this.퓬(obj1.HistoryItem);
    this.퓏(new UpdateArgs(UpdateReason.NewTick), new IndicatorUpdateType?(IndicatorUpdateType.OnTick));
    this.퓏(obj1);
  }

  protected virtual void AddNewItem(
    IHistoryItem historyItem,
    bool updateIndicators = true,
    HistoryEventArgs e = null)
  {
    if (updateIndicators)
      this.퓏(e, new IndicatorUpdateType?(IndicatorUpdateType.OnBarClose));
    lock (this.itemsLocker)
      this.퓍픧.Add(historyItem);
    this.퓬(historyItem);
    if (updateIndicators)
      this.퓏(e, new IndicatorUpdateType?(IndicatorUpdateType.OnTick));
    this.퓏(historyItem);
  }

  private protected virtual void 퓏([In] IHistoryItem obj0)
  {
    // ISSUE: reference to a compiler-generated field
    this.퓍퓓.InvokeSafely((object) this, (object) new HistoryEventArgs()
    {
      HistoryItem = obj0
    });
  }

  private void 퓏([In] HistoryEventArgs obj0)
  {
    // ISSUE: reference to a compiler-generated field
    HistoryEventHandler 퓍픗 = this.퓍픗;
    if (퓍픗 == null)
      return;
    퓍픗((object) this, obj0);
  }

  private void 퓬([In] IHistoryItem obj0)
  {
    if (this.퓍퓿 == this.퓍퓷)
      return;
    this.퓍퓿 = this.퓍퓷;
    // ISSUE: reference to a compiler-generated field
    HistoryEventHandler 퓍퓰 = this.퓍퓰;
    if (퓍퓰 == null)
      return;
    픪 e = new 픪();
    e.HistoryItem = obj0;
    e.MessageQuote = this.퓍퓷;
    퓍퓰((object) this, (HistoryEventArgs) e);
  }

  private protected virtual void 퓏(HistoryEventArgs _param1 = null, IndicatorUpdateType? _param2 = null)
  {
    this.퓏(new UpdateArgs(UpdateReason.NewBar), _param2);
  }

  internal void 픂()
  {
    // ISSUE: reference to a compiler-generated field
    Action 퓍퓢 = this.퓍퓢;
    if (퓍퓢 == null)
      return;
    퓍퓢();
  }

  [NotPublished]
  [EditorBrowsable(EditorBrowsableState.Never)]
  public void CutItems(int count)
  {
    lock (this.itemsLocker)
      count = Math.Min(this.퓍픧.Count, Math.Abs(count));
    lock (this.itemsLocker)
      this.퓍픧.RemoveRange(0, count);
    this.Parameters.FromTime = this.Count > 0 ? this[0, SeekOriginHistory.Begin].TimeLeft : Core.Instance.TimeUtils.DateTimeUtcNow;
  }

  [NotPublished]
  protected void InsertRange(int index, IList<IHistoryItem> range)
  {
    lock (this.itemsLocker)
      this.퓍픧.InsertRange(index, (IEnumerable<IHistoryItem>) range);
    lock (this.퓍픰)
    {
      foreach (Indicator indicator in this.퓍퓧)
        indicator.Refresh();
    }
  }

  public string GetTimeToNextBar() => this.퓍퓹.GetTimeToNextBar();
}
