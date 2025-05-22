// Decompiled with JetBrains decompiler
// Type: 퓏.퓢
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer;
using TradingPlatform.BusinessLayer.Integration;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace 퓏;

internal class 퓢 : 픗
{
  protected HistoricalData 퓑핂;
  protected Period 퓑픂;

  internal 퓢([In] HistoricalData obj0, [In] VolumeAnalysisCalculationRequest obj1)
    : base(obj1)
  {
    this.퓑핂 = obj0;
    Period allowedPeriod;
    if (!Vendor.TryCorrectPeriodForDirectDownload(this.VolumeAnalysisMetadata?.GetAllowedPeriods(obj1.CalculatePriceLevels), this.퓑핂.Aggregation.GetPeriod, out allowedPeriod))
      return;
    this.퓑픂 = allowedPeriod;
  }

  internal override void 퓏()
  {
    if (this.퓑핂 == null)
      this.State = VolumeAnalysisCalculationState.Finished;
    else
      base.퓏();
  }

  private protected override void 퓬()
  {
    base.퓬();
    double num = 0.0;
    DateTime dateTime = new DateTime();
    if (this.IsAborted)
      return;
    for (int offset = 0; offset < this.퓑핂.Count; ++offset)
    {
      IHistoryItem historyItem = this.퓑핂[offset, SeekOriginHistory.Begin];
      num = this.퓏(dateTime, historyItem.TimeLeft, num);
      if (historyItem.VolumeAnalysisData?.Total != null)
      {
        historyItem.VolumeAnalysisData.Total.핁핊 = num;
        num += (double) (Decimal) historyItem.VolumeAnalysisData.Total.Delta;
      }
      dateTime = historyItem.TimeLeft;
    }
  }

  public override void Dispose()
  {
    base.Dispose();
    if (this.퓑핂 == null)
      return;
    this.퓑핂.VolumeAnalysisCalculationProgress = (IVolumeAnalysisCalculationProgress) null;
    for (int offset = 0; offset < this.퓑핂.Count; ++offset)
      this.퓑핂[offset].VolumeAnalysisData = (VolumeAnalysisData) null;
    this.퓑핂 = (HistoricalData) null;
  }

  protected override bool 퓏(out 픗.퓏 _param1)
  {
    if (!(this.퓑픂 == new Period()))
      return base.퓏(out _param1);
    _param1 = 픗.퓏.픜퓸;
    return false;
  }

  protected override void 핇()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: reference to a compiler-generated method
    this.퓏(this.CorrectedInterval, this.퓑픂, new 퓥(new 퓢.퓏()
    {
      퓞퓿 = this,
      퓞픟 = this.PriceStep
    }.퓏));
  }

  protected override int 퓏([In] HistoricalData obj0, [In] Interval<DateTime> obj1)
  {
    int offset1 = this.퓬(this.퓑핂, obj1);
    int offset2 = 0;
    if (offset1 < 0)
      return 0;
    int num = offset1;
    while (offset2 < obj0.Count && offset1 < this.퓑핂.Count)
    {
      IHistoryItem historyItem1 = this.퓑핂[offset1, SeekOriginHistory.Begin];
      bool data;
      if (historyItem1.TryGetData<bool>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓓(), out data) & data)
      {
        ++offset1;
      }
      else
      {
        DateTime timeLeft = historyItem1.TimeLeft;
        DateTime dateTime = new DateTime(historyItem1.TicksRight, DateTimeKind.Utc);
        while (obj0[offset2, SeekOriginHistory.Begin].TimeLeft < timeLeft)
        {
          ++offset2;
          if (offset2 >= obj0.Count)
            break;
        }
        for (; offset2 < obj0.Count; ++offset2)
        {
          IHistoryItem historyItem2 = obj0[offset2, SeekOriginHistory.Begin];
          if (!(historyItem2.TimeLeft > dateTime))
          {
            IHistoryItem historyItem3 = historyItem1;
            if (historyItem3.VolumeAnalysisData == null)
              historyItem3.VolumeAnalysisData = new VolumeAnalysisData()
              {
                TimeLeft = timeLeft
              };
            historyItem1.VolumeAnalysisData.퓏(this.핁픠, (object) historyItem2);
          }
          else
            break;
        }
        ++offset1;
      }
    }
    this.퓏(obj0, offset2);
    return num;
  }

  private protected virtual void 퓏([In] HistoricalData obj0, [In] int obj1)
  {
  }

  protected override void 퓲()
  {
    if (this.퓑핂 == null)
      return;
    this.퓑핂.퓏(new HistoryEventHandler(this.퓏));
  }

  protected override void 핂()
  {
    if (this.퓑핂 == null)
      return;
    this.퓑핂.퓬(new HistoryEventHandler(this.퓏));
  }

  protected override VolumeAnalysisData 퓏([In] long obj0)
  {
    int indexByTime = (int) this.퓑핂.GetIndexByTime(obj0, SeekOriginHistory.Begin);
    if (indexByTime < 0 || indexByTime >= this.퓑핂.Count)
      return (VolumeAnalysisData) null;
    IHistoryItem historyItem = this.퓑핂[indexByTime, SeekOriginHistory.Begin];
    return historyItem == null ? (VolumeAnalysisData) null : this.퓏(historyItem, indexByTime);
  }

  private protected VolumeAnalysisData 퓏([In] IHistoryItem obj0, [In] int obj1)
  {
    if (obj0.VolumeAnalysisData != null)
      return obj0.VolumeAnalysisData;
    obj0.VolumeAnalysisData = new VolumeAnalysisData()
    {
      TimeLeft = obj0.TimeLeft
    };
    if (obj1 <= 0)
      return obj0.VolumeAnalysisData;
    IHistoryItem historyItem = this.퓑핂[obj1 - 1, SeekOriginHistory.Begin];
    if (historyItem?.VolumeAnalysisData != null)
      obj0.VolumeAnalysisData.Total.핁핊 = this.퓏(historyItem.TimeLeft, obj0.TimeLeft, historyItem.VolumeAnalysisData.Total.CumulativeDelta);
    return obj0.VolumeAnalysisData;
  }

  private void 퓏([In] object obj0, [In] HistoryEventArgs obj1)
  {
    if (!(obj1 is 픪 픪) || 픪.MessageQuote == null)
      return;
    this.퓏(픪.MessageQuote);
  }

  protected override void 퓏([In] MessageQuote obj0)
  {
    base.퓏(obj0);
    this.퓑핂?.픂();
  }

  protected override Interval<DateTime> 픂()
  {
    DateTime dateTimeUtcNow = Core.Instance.TimeUtils.DateTimeUtcNow;
    DateTime from = this.핁픠.From;
    DateTime to = this.퓑핂.ToTime == new DateTime() ? dateTimeUtcNow : this.퓑핂.ToTime;
    if (from > dateTimeUtcNow)
      from = dateTimeUtcNow;
    if (to > dateTimeUtcNow)
      to = dateTimeUtcNow;
    if (this.Symbol.QuoteDelay != new TimeSpan() && to > dateTimeUtcNow - this.Symbol.QuoteDelay)
      to -= this.Symbol.QuoteDelay;
    return new Interval<DateTime>(from, to);
  }

  private int 퓬([In] HistoricalData obj0, [In] Interval<DateTime> obj1)
  {
    if (obj0 == null || obj0.Count == 0 || new Interval<DateTime>(obj0[0, SeekOriginHistory.Begin].TimeLeft, new DateTime(obj0[0].TicksRight, DateTimeKind.Utc)).Intersect(obj1) == Interval<DateTime>.Default)
      return -1;
    long ticks = obj1.From.Ticks;
    long num = Math.Abs(obj0.Aggregation.GetPeriod.Ticks);
    do
    {
      int indexByTime = (int) obj0.GetIndexByTime(ticks, SeekOriginHistory.Begin);
      if (indexByTime >= 0)
        return indexByTime;
      ticks += num;
    }
    while (ticks <= obj1.To.Ticks);
    return -1;
  }

  private double 퓏([In] DateTime obj0, [In] DateTime obj1, [In] double obj2)
  {
    TimeZoneInfo timeZoneInfo = this.핁픠.TimeZone.TimeZoneInfo;
    DateTime dateTime1 = obj0;
    DateTime dateTime2 = obj1;
    if (timeZoneInfo != null)
    {
      dateTime1 = TimeZoneInfo.ConvertTime(obj0, timeZoneInfo);
      dateTime2 = TimeZoneInfo.ConvertTime(obj1, timeZoneInfo);
    }
    double num;
    switch (this.핁픠.CumulativeDeltaReset)
    {
      case CumulativeDeltaReset.Never:
        num = obj2;
        break;
      case CumulativeDeltaReset.Daily:
        num = dateTime1.DayOfWeek != dateTime2.DayOfWeek ? 0.0 : obj2;
        break;
      case CumulativeDeltaReset.Weekly:
        num = dateTime1.GetWeekOfYear() != dateTime2.GetWeekOfYear() ? 0.0 : obj2;
        break;
      case CumulativeDeltaReset.ByChartSession:
        num = this.퓏(this.핁픠.SessionsContainer, obj0, obj1) ? 0.0 : obj2;
        break;
      default:
        num = obj2;
        break;
    }
    return num;
  }

  private bool 퓏([In] ISessionsContainer obj0, [In] DateTime obj1, [In] DateTime obj2)
  {
    if (obj0 == null)
      return false;
    ISession sessionForDate1 = obj0.GetSessionForDate(obj2);
    if (sessionForDate1 == null)
      return false;
    ISession sessionForDate2 = obj0.GetSessionForDate(obj1);
    return sessionForDate2 == null || obj1.TimeOfDay <= sessionForDate2.CloseTime && obj1.TimeOfDay < sessionForDate1.OpenTime && sessionForDate1.OpenTime <= obj2.TimeOfDay && sessionForDate2.CloseTime < obj2.TimeOfDay;
  }
}
