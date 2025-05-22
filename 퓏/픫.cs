// Decompiled with JetBrains decompiler
// Type: 퓏.픫
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System.Collections.Concurrent;
using System.Linq;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer;

#nullable disable
namespace 퓏;

internal class 픫 : 퓢
{
  private const int 퓞픉 = 1000000;
  private readonly ConcurrentQueue<IVolumeTickData> 퓞픒;
  private readonly ConcurrentQueue<IVolumeTickData> 퓞퓷;

  internal 픫([In] HistoricalData obj0, [In] VolumeAnalysisCalculationRequest obj1)
    : base(obj0, obj1)
  {
    if (this.퓑핂.Aggregation is HistoryAggregationRenko)
      this.퓑픂 = new Period();
    this.퓞픒 = new ConcurrentQueue<IVolumeTickData>();
    this.퓞퓷 = new ConcurrentQueue<IVolumeTickData>();
    this.퓑핂.NewHistoryItem += new HistoryEventHandler(this.퓏);
  }

  public override void Dispose()
  {
    if (this.퓑핂 != null)
      this.퓑핂.NewHistoryItem -= new HistoryEventHandler(this.퓏);
    base.Dispose();
  }

  private protected override void 퓏([In] HistoricalData obj0, [In] int obj1)
  {
    if (obj0.Count <= obj1 + 1)
      return;
    IHistoryItem historyItem1 = (IHistoryItem) null;
    if (this.퓑핂.Any<IHistoryItem>())
    {
      IHistoryItem historyItem2 = this.퓑핂[0];
      bool data;
      if (historyItem2.TryGetData<bool>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓓(), out data) & data)
      {
        historyItem1 = historyItem2;
        historyItem1.VolumeAnalysisData = this.퓏(historyItem2, this.퓑핂.Count - 1);
      }
    }
    foreach (IVolumeTickData volumeTickData in obj0.Skip<IHistoryItem>(obj1 + 1).OfType<IVolumeTickData>())
    {
      if (historyItem1 != null && historyItem1.TicksLeft <= volumeTickData.Time)
      {
        lock (historyItem1.VolumeAnalysisData)
          historyItem1.VolumeAnalysisData.퓏(this.핁픠, volumeTickData);
      }
      this.퓞픒.Enqueue(volumeTickData);
    }
  }

  protected override void 퓏([In] MessageQuote obj0)
  {
    if (!this.AllowByLicense || !(obj0 is IVolumeTickData volumeTickData))
      return;
    VolumeAnalysisData volumeAnalysisData = this.퓏(obj0.Time.Ticks);
    bool data = false;
    IHistoryItem historyItem = (IHistoryItem) null;
    if (this.퓑핂.Any<IHistoryItem>())
    {
      historyItem = this.퓑핂[0];
      if (historyItem.TimeLeft <= obj0.Time)
        historyItem.TryGetData<bool>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓓(), out data);
    }
    if (((volumeAnalysisData != null ? 0 : (historyItem != null ? 1 : 0)) & (data ? 1 : 0)) != 0)
      volumeAnalysisData = this.퓏(historyItem, this.퓑핂.Count - 1);
    if (volumeAnalysisData == null | data)
    {
      this.퓞퓷.Enqueue(volumeTickData);
      while (this.퓞퓷.Count > 1000000)
        this.퓞퓷.TryDequeue(out IVolumeTickData _);
      if (!data)
        return;
    }
    if (volumeAnalysisData == null)
      return;
    lock (volumeAnalysisData)
      volumeAnalysisData.퓏(this.핁픠, obj0);
    this.퓑핂?.픂();
  }

  private void 퓏([In] object obj0, [In] HistoryEventArgs obj1)
  {
    this.퓏(this.퓞픒);
    this.퓏(this.퓞퓷);
    this.퓑핂?.픂();
  }

  private void 퓏([In] ConcurrentQueue<IVolumeTickData> obj0)
  {
    IVolumeTickData result;
    while (obj0.TryPeek(out result))
    {
      VolumeAnalysisData volumeAnalysisData = this.퓏(result.Time);
      if (volumeAnalysisData == null)
        break;
      obj0.TryDequeue(out result);
      lock (volumeAnalysisData)
        volumeAnalysisData.퓏(this.핁픠, result);
    }
  }
}
