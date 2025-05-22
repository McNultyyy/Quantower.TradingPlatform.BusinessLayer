// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.HistoryDataSymbolProvider
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public sealed class HistoryDataSymbolProvider : IHistoryDataProvider
{
  private readonly Symbol 픂픾;
  private readonly HistoryRequestParameters 픂퓍;
  private readonly Interval<DateTime>[] 픂픁;
  private int 픂픞;

  public bool AllDataAlreadyProvided => this.픂픞 >= this.픂픁.Length;

  public event Action<string> ProgressChanged;

  public string ProgressValue
  {
    get
    {
      return ((float) this.픂픞 / (float) this.픂픁.Length).ToString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픻());
    }
  }

  public HistoryDataSymbolProvider(
    Symbol realSymbolToImportHistory,
    HistoryRequestParameters historyRequestParameters)
  {
    this.픂픾 = realSymbolToImportHistory;
    this.픂퓍 = historyRequestParameters;
    this.픂픁 = this.픂퓍.Interval.Split(this.픂픾.GetHistoryDownloadingStep(this.픂퓍.Aggregation)).ToArray<Interval<DateTime>>();
    this.픂픞 = 0;
  }

  public HistoryHolder GetHistory(CancellationToken cancellationToken)
  {
    Interval<DateTime> interval = this.픂픁[this.픂픞];
    HistoryRequestParameters requestParameters1 = new HistoryRequestParameters(this.픂퓍);
    requestParameters1.Interval = interval;
    requestParameters1.CancellationToken = cancellationToken;
    HistoryRequestParameters requestParameters2 = requestParameters1;
    if (this.픂픾 == null)
      return (HistoryHolder) null;
    HistoricalData history1 = this.픂픾.GetHistory(requestParameters2);
    List<IHistoryItem> history2 = new List<IHistoryItem>();
    for (int offset = 0; offset < history1.Count; ++offset)
      history2.Add(history1[offset, SeekOriginHistory.Begin]);
    ++this.픂픞;
    // ISSUE: reference to a compiler-generated field
    Action<string> 픂픂 = this.픂픂;
    if (픂픂 != null)
      픂픂(this.ProgressValue);
    return new HistoryHolder((IList<IHistoryItem>) history2, requestParameters2);
  }
}
