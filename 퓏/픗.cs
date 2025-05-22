// Decompiled with JetBrains decompiler
// Type: 퓏.픗
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using TradingPlatform.BusinessLayer;
using TradingPlatform.BusinessLayer.Integration;
using TradingPlatform.BusinessLayer.Utils;
using TradingPlatform.BusinessLayer.VolumeAnalysis.Storage;

#nullable enable
namespace 퓏;

internal abstract class 픗 : IVolumeAnalysisCalculationProgress, IDisposable
{
  private VolumeAnalysisCalculationState 핁픍;
  private readonly 
  #nullable disable
  CancellationTokenSource 핁픅;
  protected readonly VolumeAnalysisCalculationRequest 핁픠;
  private Interval<DateTime> 핁퓮;
  private Interval<DateTime> 핁픕;
  private readonly ManualResetEventSlim 핁픶;
  private readonly ConcurrentQueue<MessageQuote> 핁픀;
  private bool 핁픖;
  private DateTime? 핁퓘;

  public event EventHandler<VolumeAnalysisTaskEventArgs> StateChanged;

  public event EventHandler<VolumeAnalysisTaskEventArgs> ProgressChanged;

  public VolumeAnalysisCalculationState State
  {
    get => this.핁픍;
    [param: In] protected internal set
    {
      if (value == this.핁픍)
        return;
      this.핁픍 = value;
      this.퓍();
      if (this.State != VolumeAnalysisCalculationState.Finished)
        return;
      this.핁픶.Set();
    }
  }

  public int ProgressPercent
  {
    get
    {
      TimeSpan length = this.핁픕.GetLength();
      long num = length.Ticks * 100L;
      length = this.CorrectedInterval.GetLength();
      long ticks = length.Ticks;
      return (int) (num / ticks);
    }
  }

  public int ProgressBarIndex { get; [param: In] private set; }

  public bool IsAborted => this.핁픅.IsCancellationRequested;

  protected CancellationToken CancellationToken => this.핁픅.Token;

  protected Interval<DateTime> CorrectedInterval
  {
    get => this.핁퓮;
    [param: In] private set
    {
      this.핁퓮 = value;
      this.핁픕 = new Interval<DateTime>(this.핁퓮.To, this.핁퓮.To);
    }
  }

  public VolumeAnalysisCalculationParameters CalculationParameters
  {
    get => new VolumeAnalysisCalculationParameters((VolumeAnalysisCalculationParameters) this.핁픠);
  }

  protected Symbol Symbol => this.핁픠.Symbol;

  protected Connection Connection => this.Symbol?.Connection;

  protected VolumeAnalysisMetadata VolumeAnalysisMetadata => this.Symbol?.VolumeAnalysisMetadata;

  protected double PriceStep
  {
    get
    {
      double priceStep = this.Symbol.TickSize;
      if (!this.핁픠.CustomTickSize.IsNanOrDefault())
        priceStep = this.핁픠.CustomTickSize;
      if (this.핁픠.CustomStep > 1)
        priceStep *= (double) this.핁픠.CustomStep;
      return priceStep;
    }
  }

  public bool AllowByLicense { get; [param: In] set; } = true;

  protected 픗([In] VolumeAnalysisCalculationRequest obj0)
  {
    this.핁픠 = obj0 ?? throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓫());
    this.CorrectedInterval = new Interval<DateTime>(this.핁픠.From, this.핁픠.To);
    this.핁픅 = new CancellationTokenSource();
    this.핁픍 = VolumeAnalysisCalculationState.None;
    this.ProgressBarIndex = int.MaxValue;
    this.핁픀 = new ConcurrentQueue<MessageQuote>();
    this.핁픶 = new ManualResetEventSlim();
  }

  internal virtual void 퓏()
  {
    if (this.Symbol == null || this.Symbol.State == BusinessObjectState.Fake || this.Connection == null && this.Symbol.SymbolType != SymbolType.Synthetic)
    {
      this.State = VolumeAnalysisCalculationState.Finished;
    }
    else
    {
      try
      {
        this.State = VolumeAnalysisCalculationState.Processing;
        this.퓲();
        this.CorrectedInterval = this.픂();
        Interval<DateTime> correctedInterval = this.CorrectedInterval;
        if (correctedInterval.IsEmpty)
        {
          this.State = VolumeAnalysisCalculationState.Finished;
        }
        else
        {
          픗.퓏 퓏;
          if (this.퓏(out 퓏))
          {
            this.핇();
          }
          else
          {
            bool flag;
            switch (퓏)
            {
              case 픗.퓏.픜픃:
              case 픗.퓏.픜퓎:
              case 픗.퓏.픜퓦:
                flag = true;
                break;
              default:
                flag = false;
                break;
            }
            if (flag && Core.Instance.RulesManager.IsAllowed(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎(), this.핁픠.Symbol).Status == TradingOperationStatus.NotAllowed)
            {
              Core.Instance.PushDealTicket(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓒(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓠() + this.Symbol?.Connection?.VendorName, DealTicketType.Refuse);
            }
            else
            {
              correctedInterval = this.CorrectedInterval;
              foreach (Interval<DateTime> interval in correctedInterval.Reverse().Split(this.Symbol?.HistoryMetadata?.DownloadingStep_Tick ?? TimeSpan.FromHours(1.0), true))
              {
                int num = 0;
                try
                {
                  if (this.IsAborted)
                  {
                    LoggerManager loggers = Core.Instance.Loggers;
                    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 1);
                    interpolatedStringHandler.AppendFormatted<픗>(this);
                    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓥());
                    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
                    loggers.Log(stringAndClear, LoggingLevel.Verbose);
                    break;
                  }
                  Symbol symbol = this.Symbol;
                  HistoryRequestParameters historyRequestParameters = new HistoryRequestParameters();
                  historyRequestParameters.Symbol = this.Symbol;
                  historyRequestParameters.FromTime = interval.From;
                  historyRequestParameters.ToTime = interval.To;
                  historyRequestParameters.Aggregation = (HistoryAggregation) new HistoryAggregationTick(this.Symbol.VolumeType == SymbolVolumeType.Volume ? HistoryType.Last : HistoryType.BidAsk);
                  historyRequestParameters.CancellationToken = this.CancellationToken;
                  historyRequestParameters.ForceReload = this.핁픠.ForceReload;
                  HistoricalData history = symbol.GetHistory(historyRequestParameters);
                  if (history.Count > 0)
                  {
                    IHistoryItem historyItem = history.LastOrDefault<IHistoryItem>();
                    if (historyItem != null)
                    {
                      if (this.핁퓘.HasValue)
                      {
                        DateTime? 핁퓘 = this.핁퓘;
                        DateTime timeLeft = historyItem.TimeLeft;
                        if ((핁퓘.HasValue ? (핁퓘.GetValueOrDefault() < timeLeft ? 1 : 0) : 0) == 0)
                          goto label_21;
                      }
                      this.핁퓘 = new DateTime?(historyItem.TimeLeft);
                    }
label_21:
                    num = this.퓏(history, interval);
                  }
                  else if (!this.핁퓘.HasValue)
                  {
                    correctedInterval = this.CorrectedInterval;
                    this.핁퓘 = new DateTime?(correctedInterval.From);
                  }
                }
                catch (Exception ex)
                {
                  Core.Instance.Loggers.Log(ex);
                }
                finally
                {
                  if (interval.To == this.CorrectedInterval.To)
                  {
                    this.핁픖 = true;
                    this.픾();
                  }
                  this.퓏(interval.From, num != 0 ? num : this.ProgressBarIndex);
                }
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        Core.Instance.Loggers.Log(ex);
      }
      finally
      {
        try
        {
          if (!this.핁픖)
          {
            this.핁픖 = true;
            this.픾();
          }
          this.퓬();
        }
        catch (Exception ex)
        {
          Core.Instance.Loggers.Log(ex);
        }
        this.State = VolumeAnalysisCalculationState.Finished;
      }
    }
  }

  private protected virtual void 퓬()
  {
  }

  public void AbortLoading() => this.핁픅?.Cancel();

  public void Wait(CancellationToken token = default (CancellationToken))
  {
    WaitHandle.WaitAny(new WaitHandle[3]
    {
      this.핁픶.WaitHandle,
      this.핁픅?.Token.WaitHandle,
      token.WaitHandle
    });
  }

  public virtual void Dispose()
  {
    this.핂();
    this.핁픀.Clear();
  }

  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 3);
    interpolatedStringHandler.AppendFormatted(this.GetType().Name);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓯());
    interpolatedStringHandler.AppendFormatted<Symbol>(this.Symbol);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬());
    interpolatedStringHandler.AppendFormatted<Interval<DateTime>>(this.CorrectedInterval);
    return interpolatedStringHandler.ToStringAndClear();
  }

  protected virtual bool 퓏(out 픗.퓏 _param1)
  {
    _param1 = 픗.퓏.픜픈;
    VolumeAnalysisMetadata analysisMetadata = this.VolumeAnalysisMetadata;
    if (analysisMetadata == null || !analysisMetadata.IsVolumeAnalysisAvailable)
    {
      _param1 = 픗.퓏.픜퓒;
      return false;
    }
    if (this.Symbol.VolumeType != SymbolVolumeType.Volume)
    {
      _param1 = 픗.퓏.픜퓚;
      return false;
    }
    if (this.핁픠.DeltaCalculationType != this.Symbol.GetDeltaCalculationTypeForVolumeAnalysis())
    {
      _param1 = 픗.퓏.픜픃;
      return false;
    }
    if (!this.핁픠.FilteredVolume.IsNanOrDefault())
    {
      _param1 = 픗.퓏.픜퓎;
      return false;
    }
    if (this.핁픠.ForceUsingTickData)
    {
      _param1 = 픗.퓏.픜퓦;
      return false;
    }
    if (this.VolumeAnalysisMetadata.TryFindLargestLoadingPeriod(this.CorrectedInterval, this.핁픠.CalculatePriceLevels, out Period _))
      return true;
    _param1 = 픗.퓏.픜피;
    return false;
  }

  protected abstract void 핇();

  protected void 퓏([In] Interval<DateTime> obj0_1, [In] Period obj1, [In] 퓥 obj2)
  {
    IDictionary<Period, TimeSpan> downloadingStepByPeriod = this.VolumeAnalysisMetadata.GetDownloadingStepByPeriod(this.핁픠.CalculatePriceLevels);
    foreach (Interval<DateTime> interval1 in obj0_1.Reverse().Split(downloadingStepByPeriod[obj1], true))
    {
      int progressBarIndex = this.ProgressBarIndex;
      try
      {
        if (this.IsAborted)
        {
          LoggerManager loggers = Core.Instance.Loggers;
          DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 1);
          interpolatedStringHandler.AppendFormatted<픗>(this);
          interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓥());
          string stringAndClear = interpolatedStringHandler.ToStringAndClear();
          loggers.Log(stringAndClear, LoggingLevel.Verbose);
          break;
        }
        VolumeAnalysisByPeriodRequestParameters requestParameters1 = new VolumeAnalysisByPeriodRequestParameters();
        requestParameters1.SymbolId = this.Symbol.Id;
        requestParameters1.FromTime = interval1.From;
        requestParameters1.ToTime = interval1.To.AddTicks(-1L);
        requestParameters1.Period = obj1;
        requestParameters1.CalculatePriceLevels = this.핁픠.CalculatePriceLevels;
        requestParameters1.CancellationToken = this.CancellationToken;
        requestParameters1.MinVolumeAnalysisTickSize = this.Symbol.MinVolumeAnalysisTickSize;
        requestParameters1.SessionsContainer = this.핁픠.SessionsContainer;
        VolumeAnalysisByPeriodRequestParameters requestParameters2 = requestParameters1;
        List<VolumeAnalysisInterval> source = new List<VolumeAnalysisInterval>();
        List<VolumeAnalysisByPeriodRequestParameters> parametersForServerRequest = new List<VolumeAnalysisByPeriodRequestParameters>();
        VolumeAnalysisStorage volumeAnalysisStorage = this.Symbol.Connection.VolumeAnalysisStorage;
        if (!this.핁픠.ForceReload && volumeAnalysisStorage != null)
        {
          IList<VolumeAnalysisInterval> collection = volumeAnalysisStorage.Load(requestParameters2, out parametersForServerRequest);
          if (this.IsAborted)
          {
            LoggerManager loggers = Core.Instance.Loggers;
            DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 1);
            interpolatedStringHandler.AppendFormatted<픗>(this);
            interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓥());
            string stringAndClear = interpolatedStringHandler.ToStringAndClear();
            loggers.Log(stringAndClear, LoggingLevel.Verbose);
            break;
          }
          source.AddRange((IEnumerable<VolumeAnalysisInterval>) collection);
        }
        else
          parametersForServerRequest.Add(requestParameters2);
        foreach (VolumeAnalysisByPeriodRequestParameters requestParameters3 in parametersForServerRequest)
        {
          if (this.IsAborted)
          {
            LoggerManager loggers = Core.Instance.Loggers;
            DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 1);
            interpolatedStringHandler.AppendFormatted<픗>(this);
            interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓥());
            string stringAndClear = interpolatedStringHandler.ToStringAndClear();
            loggers.Log(stringAndClear, LoggingLevel.Verbose);
            return;
          }
          DateTime dateTimeUtcNow = Core.Instance.TimeUtils.DateTimeUtcNow;
          requestParameters3.ForceReload = this.핁픠.ForceReload;
          DateTime dateTime1 = requestParameters3.ToTime;
          if (dateTime1.Ticks % 10L == 0L)
          {
            VolumeAnalysisByPeriodRequestParameters requestParameters4 = requestParameters3;
            dateTime1 = requestParameters3.ToTime;
            DateTime dateTime2 = dateTime1.AddTicks(-1L);
            requestParameters4.ToTime = dateTime2;
          }
          VolumeAnalysisInterval volumeAnalysisInterval = this.Connection.LoadVolumeAnalysis(requestParameters3);
          if (volumeAnalysisInterval?.VolumeAnalysis != null)
          {
            source.Add(volumeAnalysisInterval);
            Period period = requestParameters3.Period;
            TimeSpan timeSpan1;
            switch (period.BasePeriod)
            {
              case BasePeriod.Month:
                timeSpan1 = TimeSpan.FromDays(2.0);
                break;
              case BasePeriod.Year:
                timeSpan1 = TimeSpan.FromDays(2.0);
                break;
              default:
                timeSpan1 = TimeSpan.FromHours(2.0);
                break;
            }
            TimeSpan timeSpan2 = timeSpan1;
            VolumeAnalysisData volumeAnalysisData = volumeAnalysisInterval.VolumeAnalysis.LastOrDefault<VolumeAnalysisData>();
            Interval<DateTime> interval2;
            if (volumeAnalysisData != null)
            {
              switch (period.BasePeriod)
              {
                case BasePeriod.Month:
                  dateTime1 = volumeAnalysisData.TimeLeft.AddMonths(period.PeriodMultiplier);
                  break;
                case BasePeriod.Year:
                  dateTime1 = volumeAnalysisData.TimeLeft.AddYears(period.PeriodMultiplier);
                  break;
                default:
                  dateTime1 = volumeAnalysisData.TimeLeft.AddTicks(period.Ticks);
                  break;
              }
              DateTime to1 = dateTime1;
              DateTime dateTime3 = to1;
              interval2 = requestParameters3.Interval;
              DateTime to2 = interval2.To;
              if (dateTime3 > to2 && to1 > dateTimeUtcNow)
              {
                VolumeAnalysisInterval analysisInterval = new VolumeAnalysisInterval();
                analysisInterval.Description = volumeAnalysisInterval.Description;
                analysisInterval.VolumeAnalysis = (IList<VolumeAnalysisData>) volumeAnalysisInterval.VolumeAnalysis.Take<VolumeAnalysisData>(volumeAnalysisInterval.VolumeAnalysis.Count - 1).ToList<VolumeAnalysisData>();
                interval2 = volumeAnalysisInterval.Interval;
                analysisInterval.Interval = new Interval<DateTime>(interval2.From, volumeAnalysisData.TimeLeft);
                volumeAnalysisInterval = analysisInterval;
              }
              else
              {
                interval2 = volumeAnalysisInterval.Interval;
                if (interval2.To > dateTimeUtcNow - timeSpan2)
                {
                  VolumeAnalysisInterval analysisInterval = new VolumeAnalysisInterval();
                  analysisInterval.Description = volumeAnalysisInterval.Description;
                  analysisInterval.VolumeAnalysis = (IList<VolumeAnalysisData>) volumeAnalysisInterval.VolumeAnalysis.ToList<VolumeAnalysisData>();
                  interval2 = volumeAnalysisInterval.Interval;
                  analysisInterval.Interval = new Interval<DateTime>(interval2.From, to1);
                  volumeAnalysisInterval = analysisInterval;
                }
              }
            }
            else if (!volumeAnalysisInterval.Interval.IsEmpty)
            {
              DateTime from = requestParameters3.Interval.To.FloorTo(new TimeSpan(period.Ticks));
              if (from > dateTimeUtcNow - timeSpan2)
                from = (dateTimeUtcNow - timeSpan2).FloorTo(new TimeSpan(period.Ticks));
              if (from < requestParameters3.Interval.From)
                from = requestParameters3.Interval.From;
              volumeAnalysisInterval = new VolumeAnalysisInterval()
              {
                Description = volumeAnalysisInterval.Description,
                VolumeAnalysis = (IList<VolumeAnalysisData>) volumeAnalysisInterval.VolumeAnalysis.ToList<VolumeAnalysisData>(),
                Interval = new Interval<DateTime>(volumeAnalysisInterval.Interval.From, from)
              };
            }
            interval2 = volumeAnalysisInterval.Interval;
            if (!interval2.IsEmpty)
            {
              interval2 = volumeAnalysisInterval.Interval;
              dateTime1 = interval2.To;
              if (dateTime1.Microsecond == 999)
              {
                VolumeAnalysisInterval analysisInterval = new VolumeAnalysisInterval();
                analysisInterval.Description = volumeAnalysisInterval.Description;
                analysisInterval.VolumeAnalysis = volumeAnalysisInterval.VolumeAnalysis;
                interval2 = volumeAnalysisInterval.Interval;
                DateTime from = interval2.From;
                interval2 = volumeAnalysisInterval.Interval;
                dateTime1 = interval2.To;
                DateTime to = dateTime1.AddTicks(1L);
                analysisInterval.Interval = new Interval<DateTime>(from, to);
                volumeAnalysisInterval = analysisInterval;
              }
              interval2 = volumeAnalysisInterval.Interval;
              dateTime1 = interval2.To;
              int second = dateTime1.Second;
              volumeAnalysisStorage?.Save(volumeAnalysisInterval);
            }
          }
        }
        List<VolumeAnalysisData> list = source.OrderBy<VolumeAnalysisInterval, DateTime>((Func<VolumeAnalysisInterval, DateTime>) (([In] obj0_2) => obj0_2.Interval.From)).SelectMany<VolumeAnalysisInterval, VolumeAnalysisData>((Func<VolumeAnalysisInterval, IEnumerable<VolumeAnalysisData>>) (([In] obj0_3) => (IEnumerable<VolumeAnalysisData>) obj0_3.VolumeAnalysis)).ToList<VolumeAnalysisData>();
        if (list != null)
        {
          if (list.Count > 0)
          {
            VolumeAnalysisData volumeAnalysisData = list.LastOrDefault<VolumeAnalysisData>();
            if (volumeAnalysisData != null)
            {
              DateTime dateTime4 = this.VolumeAnalysisMetadata.BuildUncompletedBars ? volumeAnalysisData.TimeLeft.AddTicks(obj1.Ticks) : volumeAnalysisData.TimeLeft;
              if (this.핁퓘.HasValue)
              {
                DateTime? 핁퓘 = this.핁퓘;
                DateTime dateTime5 = dateTime4;
                if ((핁퓘.HasValue ? (핁퓘.GetValueOrDefault() < dateTime5 ? 1 : 0) : 0) == 0)
                  goto label_50;
              }
              this.핁퓘 = new DateTime?(dateTime4);
            }
label_50:
            if (obj2 != null)
              obj2((IList<VolumeAnalysisData>) list, interval1, ref progressBarIndex);
          }
        }
      }
      catch (Exception ex)
      {
        Core.Instance.Loggers.Log(ex);
      }
      finally
      {
        if (!this.핁픖 && interval1.To == this.CorrectedInterval.To)
        {
          this.퓏(obj1, interval1, obj2);
          this.핁픖 = true;
          this.픾();
        }
        this.퓏(interval1.From, progressBarIndex);
      }
    }
  }

  private void 퓏([In] Period obj0_1, [In] Interval<DateTime> obj1, [In] 퓥 obj2)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    픗.핇 핇 = new 픗.핇();
    // ISSUE: reference to a compiler-generated field
    핇.퓑퓏 = obj0_1;
    if (!this.VolumeAnalysisMetadata.BuildUncompletedBars)
      return;
    // ISSUE: reference to a compiler-generated method
    Period[] array = ((IEnumerable<Period>) this.VolumeAnalysisMetadata.GetAllowedPeriods(this.핁픠.CalculatePriceLevels)).Where<Period>(new Func<Period, bool>(핇.퓏)).OrderByDescending<Period, long>((Func<Period, long>) (([In] obj0_2) => obj0_2.Ticks)).ToArray<Period>();
    if (!((IEnumerable<Period>) array).Any<Period>())
    {
      Interval<DateTime> interval;
      if (this.핁퓘.HasValue)
      {
        interval = new Interval<DateTime>(this.핁퓘.Value, obj1.To);
      }
      else
      {
        TimeSpan ticksLoadingPeriod = this.VolumeAnalysisMetadata.MaxTicksLoadingPeriod;
        interval = !(obj1.GetLength() > ticksLoadingPeriod) ? obj1 : new Interval<DateTime>(obj1.To - ticksLoadingPeriod, obj1.To);
      }
      Symbol symbol = this.Symbol;
      HistoryRequestParameters historyRequestParameters = new HistoryRequestParameters();
      historyRequestParameters.Symbol = this.Symbol;
      historyRequestParameters.Interval = interval;
      historyRequestParameters.Aggregation = (HistoryAggregation) new HistoryAggregationTick(this.Symbol.VolumeType == SymbolVolumeType.Volume ? HistoryType.Last : HistoryType.BidAsk);
      historyRequestParameters.CancellationToken = this.CancellationToken;
      historyRequestParameters.ForceReload = this.핁픠.ForceReload;
      HistoricalData history = symbol.GetHistory(historyRequestParameters);
      IHistoryItem historyItem = history.LastOrDefault<IHistoryItem>();
      if (historyItem != null)
      {
        if (this.핁퓘.HasValue)
        {
          DateTime? 핁퓘 = this.핁퓘;
          DateTime timeLeft = historyItem.TimeLeft;
          if ((핁퓘.HasValue ? (핁퓘.GetValueOrDefault() < timeLeft ? 1 : 0) : 0) == 0)
            goto label_10;
        }
        this.핁퓘 = new DateTime?(historyItem.TimeLeft);
      }
label_10:
      this.퓏(history, obj1);
    }
    else
    {
      foreach (Period period in array)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        DateTime from = !this.핁퓘.HasValue ? (핇.퓑퓏.BasePeriod != BasePeriod.Tick ? ((obj1.To - obj1.From).Ticks >= 핇.퓑퓏.Ticks ? obj1.To.AddTicks(-핇.퓑퓏.Ticks) : obj1.From) : obj1.From) : this.핁퓘.Value;
        if (from == obj1.To)
          break;
        this.퓏(new Interval<DateTime>(from, obj1.To), period, obj2);
      }
    }
  }

  protected abstract int 퓏([In] HistoricalData obj0, [In] Interval<DateTime> obj1);

  protected virtual void 퓲()
  {
    if (this.Symbol == null)
      return;
    if (this.Symbol.VolumeType == SymbolVolumeType.Volume)
      this.Symbol.NewLast += new LastHandler(this.퓏);
    else
      this.Symbol.NewQuote += new QuoteHandler(this.퓏);
  }

  protected virtual void 핂()
  {
    if (this.Symbol == null)
      return;
    if (this.Symbol.VolumeType == SymbolVolumeType.Volume)
      this.Symbol.NewLast -= new LastHandler(this.퓏);
    else
      this.Symbol.NewQuote -= new QuoteHandler(this.퓏);
  }

  private void 퓏([In] Symbol obj0, [In] MessageQuote obj1) => this.퓏(obj1);

  protected virtual void 퓏([In] MessageQuote obj0)
  {
    if (this.퓬(obj0))
      return;
    this.핇(obj0);
  }

  protected abstract VolumeAnalysisData 퓏([In] long obj0);

  private bool 퓬([In] MessageQuote obj0)
  {
    if (this.핁픖 && this.핁픀.IsEmpty)
      return false;
    this.핁픀.Enqueue(obj0);
    return true;
  }

  private void 픾()
  {
    MessageQuote result;
    while (this.핁픀.TryDequeue(out result))
    {
      if (result != null)
        this.핇(result);
    }
  }

  private void 핇([In] MessageQuote obj0)
  {
    if (obj0.Time <= (this.핁퓘 ?? this.CorrectedInterval.To) || !this.AllowByLicense)
      return;
    VolumeAnalysisData volumeAnalysisData = this.퓏(obj0.Time.Ticks);
    if (volumeAnalysisData == null)
      return;
    lock (volumeAnalysisData)
      volumeAnalysisData.퓏(this.핁픠, obj0);
  }

  protected virtual Interval<DateTime> 픂()
  {
    DateTime from = this.핁픠.From;
    DateTime to = this.핁픠.To;
    DateTime dateTimeUtcNow = Core.Instance.TimeUtils.DateTimeUtcNow;
    if (from > dateTimeUtcNow)
      from = dateTimeUtcNow;
    if (to > dateTimeUtcNow)
      to = dateTimeUtcNow;
    if (this.Symbol.QuoteDelay != new TimeSpan() && to > dateTimeUtcNow - this.Symbol.QuoteDelay)
      to = dateTimeUtcNow - this.Symbol.QuoteDelay;
    return new Interval<DateTime>(from, to);
  }

  protected void 퓏([In] DateTime obj0, int _param2 = 2147483647 /*0x7FFFFFFF*/)
  {
    this.핁픕 = new Interval<DateTime>(obj0, this.핁픕.To);
    this.ProgressBarIndex = _param2;
    this.픁();
  }

  private void 퓍()
  {
    // ISSUE: reference to a compiler-generated field
    EventHandler<VolumeAnalysisTaskEventArgs> 핁퓣 = this.핁퓣;
    if (핁퓣 == null)
      return;
    핁퓣.InvokeSafely((object) this, (object) new VolumeAnalysisTaskEventArgs((IVolumeAnalysisCalculationProgress) this));
  }

  private void 픁()
  {
    // ISSUE: reference to a compiler-generated field
    EventHandler<VolumeAnalysisTaskEventArgs> 핁픦 = this.핁픦;
    if (핁픦 == null)
      return;
    핁픦.InvokeSafely((object) this, (object) new VolumeAnalysisTaskEventArgs((IVolumeAnalysisCalculationProgress) this));
  }

  protected enum 퓏
  {
    픜픈,
    픜퓒,
    픜퓚,
    픜픃,
    픜퓎,
    픜피,
    픜퓸,
    픜퓦,
  }
}
