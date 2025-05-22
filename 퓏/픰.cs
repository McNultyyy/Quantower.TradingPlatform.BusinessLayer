// Decompiled with JetBrains decompiler
// Type: 퓏.픰
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace 퓏;

internal class 픰 : 픗, IVolumeAnalysisCalculationTask, IDisposable
{
  private DateTime 퓑핇;
  private DateTime 퓑퓲;

  public VolumeAnalysisData Result { get; [param: In] private set; }

  public IVolumeAnalysisCalculationProgress Progress => (IVolumeAnalysisCalculationProgress) this;

  internal 픰([In] VolumeAnalysisCalculationRequest obj0)
    : base(obj0)
  {
    this.Result = new VolumeAnalysisData();
  }

  public override void Dispose()
  {
    this.Result = (VolumeAnalysisData) null;
    base.Dispose();
  }

  protected override void 핇()
  {
    try
    {
      this.퓏(this.CorrectedInterval, this.Result);
      if (this.PriceStep == this.Symbol.TickSize)
        return;
      this.Result = this.Result?.CreateAggregatedSnapshot(this.PriceStep);
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
    finally
    {
      this.퓏(this.CorrectedInterval.From);
    }
  }

  private void 퓏([In] Interval<DateTime> obj0_1, [In] VolumeAnalysisData obj1, Period _param3 = default (Period))
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    픰.퓬 퓬1 = new 픰.퓬();
    // ISSUE: reference to a compiler-generated field
    퓬1.퓞픧 = _param3;
    // ISSUE: reference to a compiler-generated field
    퓬1.퓞퓹 = this;
    // ISSUE: reference to a compiler-generated field
    퓬1.퓞퓤 = obj1;
    if (obj0_1.IsEmpty)
      return;
    Period[] allowedPeriods = this.VolumeAnalysisMetadata.GetAllowedPeriods(this.핁픠.CalculatePriceLevels);
    // ISSUE: variable of a compiler-generated type
    픰.퓬 퓬2 = 퓬1;
    TimeSpan timeSpan = obj0_1.To - obj0_1.From;
    long ticks1 = timeSpan.Ticks;
    // ISSUE: reference to a compiler-generated field
    퓬2.퓞퓰 = ticks1;
    // ISSUE: reference to a compiler-generated method
    Period[] array = ((IEnumerable<Period>) allowedPeriods).Where<Period>(new Func<Period, bool>(퓬1.퓏)).ToArray<Period>();
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated method
    퓬1.퓞픧 = !(퓬1.퓞픧 == new Period()) ? ((IEnumerable<Period>) array).FirstOrDefault<Period>(new Func<Period, bool>(퓬1.퓬)) : ((IEnumerable<Period>) array).Max<Period, Period>((Func<Period, Period>) (([In] obj0_2) => obj0_2));
    // ISSUE: reference to a compiler-generated field
    if (퓬1.퓞픧 == new Period())
    {
      Symbol symbol = this.Symbol;
      HistoryRequestParameters historyRequestParameters = new HistoryRequestParameters();
      historyRequestParameters.Symbol = this.Symbol;
      historyRequestParameters.Interval = obj0_1;
      historyRequestParameters.Aggregation = (HistoryAggregation) new HistoryAggregationTick(this.Symbol.VolumeType == SymbolVolumeType.Volume ? HistoryType.Last : HistoryType.BidAsk);
      historyRequestParameters.CancellationToken = this.CancellationToken;
      historyRequestParameters.ForceReload = this.핁픠.ForceReload;
      this.퓏(symbol.GetHistory(historyRequestParameters), obj0_1);
    }
    else
    {
      // ISSUE: reference to a compiler-generated field
      퓬1.퓞퓛 = obj0_1.From;
      // ISSUE: reference to a compiler-generated field
      퓬1.퓞픝 = obj0_1.To;
      // ISSUE: reference to a compiler-generated field
      long ticks2 = 퓬1.퓞픧.Ticks;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      timeSpan = 퓬1.퓞픝 - 퓬1.퓞퓛;
      long ticks3 = timeSpan.Ticks;
      if (ticks2 - ticks3 != 1L)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        퓬1.퓞퓛 = obj0_1.From.CeilingTo(퓬1.퓞픧);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        퓬1.퓞픝 = obj0_1.To.FloorTo(퓬1.퓞픧);
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      if (퓬1.퓞픝.Ticks + 퓬1.퓞픧.Ticks == obj0_1.To.Ticks + 1L)
      {
        // ISSUE: reference to a compiler-generated field
        퓬1.퓞픝 = obj0_1.To;
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      퓬1.퓞픻 = 퓬1.퓞퓛;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      if (!(퓬1.퓞퓛 == 퓬1.퓞픝))
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        this.퓏(new Interval<DateTime>(퓬1.퓞퓛, 퓬1.퓞픝), 퓬1.퓞픧, new 퓥(퓬1.퓏));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      퓬1.퓞픝 = 퓬1.퓞픻;
      // ISSUE: reference to a compiler-generated field
      if (obj0_1.From < 퓬1.퓞퓛)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.퓏(new Interval<DateTime>(obj0_1.From, 퓬1.퓞퓛), 퓬1.퓞퓤, 퓬1.퓞픧);
      }
      // ISSUE: reference to a compiler-generated field
      if (!(퓬1.퓞픝 < obj0_1.To))
        return;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.퓏(new Interval<DateTime>(퓬1.퓞픝, obj0_1.To), 퓬1.퓞퓤, 퓬1.퓞픧);
    }
  }

  protected override int 퓏([In] HistoricalData obj0, [In] Interval<DateTime> obj1)
  {
    this.Result?.퓏(this.핁픠, obj0);
    return 0;
  }

  protected override void 퓲()
  {
    DateTime dateTime = Core.Instance.TimeUtils.DateTimeUtcNow;
    if (this.핁픠?.Symbol?.Connection != null)
      dateTime = this.핁픠.Symbol.Connection.ServerTime;
    if (this.핁픠.To < dateTime)
      return;
    base.퓲();
  }

  protected override void 퓏([In] MessageQuote obj0)
  {
    if (obj0.Time > this.핁픠.To)
    {
      this.핂();
    }
    else
    {
      if (obj0.Time < this.핁픠.From)
        return;
      base.퓏(obj0);
    }
  }

  protected override VolumeAnalysisData 퓏([In] long obj0) => this.Result;
}
