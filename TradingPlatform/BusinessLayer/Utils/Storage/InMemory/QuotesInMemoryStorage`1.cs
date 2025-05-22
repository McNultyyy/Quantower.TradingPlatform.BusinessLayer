// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.Storage.InMemory.QuotesInMemoryStorage`1
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils.Storage.InMemory;

public class QuotesInMemoryStorage<TQuote> where TQuote : MessageQuote
{
  private readonly List<TQuote> 퓲픒;
  private readonly TimeSpan 퓲퓷;
  private const int 퓲퓿 = 1000;
  private int 퓲픟;

  public int MaxCapacity { get; init; }

  public QuotesInMemoryStorage(TimeSpan desiredDepth)
  {
    this.퓲픒 = new List<TQuote>();
    this.퓲퓷 = desiredDepth;
    this.MaxCapacity = 100000;
  }

  public void Put(TQuote item)
  {
    try
    {
      if (this.퓲픟++ >= 1000)
      {
        this.퓲픟 = 0;
        this.퓏(item);
      }
      this.퓲픒.Add(item);
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
  }

  private TQuote[] 퓏()
  {
    try
    {
      return this.퓲픒.ToArray();
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
    return (TQuote[]) null;
  }

  public bool TryGet(
    Interval<DateTime> interval,
    out TQuote[] items,
    out Interval<DateTime> remainingInterval)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    QuotesInMemoryStorage<TQuote>.퓏\u00601 퓏 = new QuotesInMemoryStorage<TQuote>.퓏\u00601();
    // ISSUE: reference to a compiler-generated field
    퓏.픇피 = interval;
    remainingInterval = Interval<DateTime>.Default;
    items = Array.Empty<TQuote>();
    TQuote[] source = this.퓏();
    TQuote quote = source != null ? ((IEnumerable<TQuote>) source).FirstOrDefault<TQuote>() : default (TQuote);
    // ISSUE: reference to a compiler-generated field
    if ((object) quote == null || 퓏.픇피.To <= quote.Time)
      return false;
    // ISSUE: reference to a compiler-generated method
    items = ((IEnumerable<TQuote>) source).Where<TQuote>(new Func<TQuote, bool>(퓏.퓏)).ToArray<TQuote>();
    // ISSUE: reference to a compiler-generated field
    if (퓏.픇피.From < quote.Time)
    {
      // ISSUE: reference to a compiler-generated field
      remainingInterval = new Interval<DateTime>(퓏.픇피.From, quote.Time);
    }
    return true;
  }

  private void 퓏([In] TQuote obj0)
  {
    if (this.퓲픒.Count <= 1)
      return;
    int num = 0;
    foreach (TQuote quote in this.퓲픒)
    {
      if (obj0.Time - quote.Time > this.퓲퓷)
        ++num;
      else
        break;
    }
    int val2 = num - 1;
    if (val2 < 1)
      return;
    this.퓲픒.RemoveRange(0, Math.Max(this.퓲픒.Count - this.MaxCapacity, val2));
  }
}
