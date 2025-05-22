// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.HistoryDataSymbolProviderRealtime
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

#nullable disable
namespace TradingPlatform.BusinessLayer;

public sealed class HistoryDataSymbolProviderRealtime : IHistoryDataProvider, IDisposable
{
  private const int 픂핁 = 10000;
  private DateTime 픂퓙;
  private DateTime 픂퓗;
  private readonly HistoricalData 픂픎;
  private readonly HistoryRequestParameters 픂퓠;
  private readonly ManualResetEventSlim 픂퓥;

  public bool AllDataAlreadyProvided
  {
    get
    {
      return this.픂퓗 >= this.픂퓠.ToTime || Core.Instance.TimeUtils.DateTimeUtcNow - this.픂퓠.Symbol.QuoteDelay - TimeSpan.FromSeconds(10.0) > this.픂퓠.ToTime;
    }
  }

  public event Action<string> ProgressChanged;

  public string ProgressValue { get; [param: In] private set; }

  public HistoryDataSymbolProviderRealtime(HistoryRequestParameters historyRequestParameters)
  {
    this.픂퓠 = historyRequestParameters;
    HistoryRequestParameters historyRequestParameters1 = new HistoryRequestParameters(this.픂퓠)
    {
      ToTime = new DateTime()
    };
    this.픂퓥 = new ManualResetEventSlim();
    this.픂픎 = this.픂퓠.Symbol.GetHistory(historyRequestParameters1);
    this.픂픎.NewHistoryItem += new HistoryEventHandler(this.퓏);
  }

  public void Dispose()
  {
    this.픂퓥.Dispose();
    this.픂픎.NewHistoryItem -= new HistoryEventHandler(this.퓏);
    this.픂픎.Dispose();
  }

  public HistoryHolder GetHistory(CancellationToken cancellationToken)
  {
    if (this.픂퓠.Symbol == null)
      return (HistoryHolder) null;
    if (this.픂퓠.Symbol.State == BusinessObjectState.Fake)
      return (HistoryHolder) null;
    this.픂퓥.Wait(this.픂퓠.ToTime - Core.Instance.TimeUtils.DateTimeUtcNow + this.픂퓠.Symbol.QuoteDelay + TimeSpan.FromSeconds(10.0), cancellationToken);
    this.픂퓥.Reset();
    if (this.픂픎.Count == 0)
      return (HistoryHolder) null;
    List<IHistoryItem> historyItemList = new List<IHistoryItem>();
    HistoryRequestParameters requestParameters = new HistoryRequestParameters(this.픂퓠);
    int num;
    for (num = 0; num < 10000 && num < this.픂픎.Count; ++num)
    {
      IHistoryItem historyItem = this.픂픎[num, SeekOriginHistory.Begin];
      this.픂퓗 = historyItem.TimeLeft;
      if (!(historyItem.TimeLeft >= this.픂퓠.ToTime))
      {
        if (historyItem.TimeLeft >= this.픂퓠.FromTime)
          historyItemList.Add(historyItem);
      }
      else
        break;
    }
    if (!historyItemList.Any<IHistoryItem>())
      return (HistoryHolder) null;
    requestParameters.FromTime = historyItemList.First<IHistoryItem>().TimeLeft;
    requestParameters.ToTime = new DateTime(historyItemList.Last<IHistoryItem>().TicksRight + 1L, DateTimeKind.Utc);
    this.픂픎.CutItems(num);
    return new HistoryHolder((IList<IHistoryItem>) historyItemList, requestParameters);
  }

  private void 퓏([In] object obj0_1, [In] HistoryEventArgs obj1)
  {
    this.픂퓙 = obj1.HistoryItem.TimeLeft;
    if (this.픂퓙 < this.픂퓠.FromTime)
    {
      if (this.픂픎.Count > 10000)
        this.픂픎.CutItems(10000);
      this.ProgressValue = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓤();
      // ISSUE: reference to a compiler-generated field
      Action<string> 픂픇 = this.픂픇;
      if (픂픇 == null)
        return;
      픂픇(this.ProgressValue);
    }
    else if (this.픂픎.Count >= 10000)
      this.픂퓥.Set();
    else if (this.픂퓙 >= this.픂퓠.ToTime)
    {
      this.픂퓥.Set();
    }
    else
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 2);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픮());
      interpolatedStringHandler.AppendFormatted<int>(this.픂픎.Count<IHistoryItem>((Func<IHistoryItem, bool>) (([In] obj0_2) => obj0_2.TicksLeft > this.픂퓠.FromTime.Ticks)));
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픉());
      interpolatedStringHandler.AppendFormatted<int>(10000);
      this.ProgressValue = interpolatedStringHandler.ToStringAndClear();
      // ISSUE: reference to a compiler-generated field
      Action<string> 픂픇 = this.픂픇;
      if (픂픇 == null)
        return;
      픂픇(this.ProgressValue);
    }
  }
}
