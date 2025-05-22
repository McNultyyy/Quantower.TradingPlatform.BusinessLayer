// Decompiled with JetBrains decompiler
// Type: 퓏.픑
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Threading;
using TradingPlatform.BusinessLayer;
using TradingPlatform.BusinessLayer.Integration;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace 퓏;

internal class 픑 : BufferedProcessor<DayBarMessageGenerationParameters>
{
  public int 핂퓬;
  private readonly Dictionary<string, CancellationTokenSource> 핂핇;
  public Action<픒> 핂퓲;
  public Func<HistoryRequestParameters, IList<IHistoryItem>> 핂핂;

  public 픑() => this.핂핇 = new Dictionary<string, CancellationTokenSource>();

  public void 퓏() => this.ProcessTreadsCount = this.핂퓬;

  protected override void Process(DayBarMessageGenerationParameters subject)
  {
    try
    {
      CancellationToken token;
      lock (this.핂핇)
      {
        CancellationTokenSource cancellationTokenSource;
        if (this.핂핇.TryGetValue(subject.SymbolId, out cancellationTokenSource))
          cancellationTokenSource.Cancel();
        cancellationTokenSource = new CancellationTokenSource();
        this.핂핇[subject.SymbolId] = cancellationTokenSource;
        token = cancellationTokenSource.Token;
      }
      if (token.IsCancellationRequested)
        return;
      DateTime dateTimeUtcNow = Core.Instance.TimeUtils.DateTimeUtcNow;
      HistoryRequestParameters requestParameters1 = new HistoryRequestParameters();
      requestParameters1.SymbolId = subject.SymbolId;
      requestParameters1.FromTime = dateTimeUtcNow.Date.AddDays((double) -subject.DayToLoadCount).AddMilliseconds(-1.0);
      requestParameters1.ToTime = dateTimeUtcNow;
      requestParameters1.Aggregation = (HistoryAggregation) new HistoryAggregationTime(new Period(BasePeriod.Day, 1), subject.UpdateHistoryType);
      requestParameters1.CancellationToken = token;
      HistoryRequestParameters requestParameters2 = requestParameters1;
      Func<HistoryRequestParameters, IList<IHistoryItem>> 핂핂 = this.핂핂;
      IList<IHistoryItem> historyItemList = 핂핂 != null ? 핂핂(requestParameters2) : (IList<IHistoryItem>) null;
      if (historyItemList == null || historyItemList.Count == 0 || token.IsCancellationRequested)
        return;
      픒 픒 = new 픒(subject.SymbolId)
      {
        UpdateHistoryType = subject.UpdateHistoryType
      };
      픒.퓏(token, subject.SymbolId, historyItemList);
      Action<픒> 핂퓲 = this.핂퓲;
      if (핂퓲 != null)
        핂퓲(픒);
      this.핂핇.Remove(subject.SymbolId);
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
    finally
    {
      if (subject != null)
      {
        Action callback = subject.Callback;
        if (callback != null)
          callback();
      }
    }
  }

  protected internal override void Clear()
  {
    foreach (CancellationTokenSource cancellationTokenSource in this.핂핇.Values)
      cancellationTokenSource.Cancel();
    base.Clear();
  }
}
