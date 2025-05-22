// Decompiled with JetBrains decompiler
// Type: 퓏.픂
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using TradingPlatform.BusinessLayer;

#nullable disable
namespace 퓏;

internal class 픂
{
  public List<ISyntheticSynhroniserItem> 픁;
  private bool 픞;

  public 픂([In] List<ISyntheticSynhroniserItem> obj0_1, [In] CancellationToken obj1)
  {
    this.픁 = obj0_1;
    this.픞 = obj0_1.Count > 0 && obj0_1[0].HistoricalData?.Aggregation is HistoryAggregationTime aggregation && aggregation.Period.BasePeriod >= BasePeriod.Day;
    do
      ;
    while (this.퓏(obj1) && this.픁.Exists((Predicate<ISyntheticSynhroniserItem>) (([In] obj0_2) => obj0_2.Position == -1)));
  }

  public bool 퓏([In] CancellationToken obj0)
  {
    foreach (ISyntheticSynhroniserItem syntheticSynhroniserItem in this.픁)
    {
      if (obj0.IsCancellationRequested)
        return false;
      if (syntheticSynhroniserItem.NextPositionTime >= 0L)
      {
        using (List<ISyntheticSynhroniserItem>.Enumerator enumerator = this.픁.GetEnumerator())
        {
label_17:
          while (enumerator.MoveNext())
          {
            ISyntheticSynhroniserItem current = enumerator.Current;
            if (obj0.IsCancellationRequested)
              return false;
            while (true)
            {
              long nextPositionTime = syntheticSynhroniserItem.NextPositionTime;
              if (nextPositionTime >= 0L && !this.픞)
              {
                SyntheticItem syntheticItem = current.SyntheticItem;
                bool? nullable;
                if (syntheticItem == null)
                {
                  nullable = new bool?();
                }
                else
                {
                  SessionsContainer currentSessionsInfo = syntheticItem.Symbol.CurrentSessionsInfo;
                  nullable = currentSessionsInfo != null ? new bool?(currentSessionsInfo.ContainsDate(nextPositionTime)) : new bool?();
                }
                if (!(nullable ?? true))
                {
                  if (!obj0.IsCancellationRequested)
                    syntheticSynhroniserItem.Move();
                  else
                    break;
                }
                else
                  goto label_17;
              }
              else
                goto label_17;
            }
            return false;
          }
        }
      }
    }
    long num = long.MaxValue;
    for (int index = 0; index < this.픁.Count; ++index)
    {
      if (obj0.IsCancellationRequested)
        return false;
      long nextPositionTime = this.픁[index].NextPositionTime;
      if (nextPositionTime > 0L && nextPositionTime < num)
        num = nextPositionTime;
    }
    if (num == long.MaxValue)
      return false;
    bool flag = false;
    foreach (ISyntheticSynhroniserItem syntheticSynhroniserItem in this.픁)
    {
      if (obj0.IsCancellationRequested)
        return false;
      if (syntheticSynhroniserItem.NextPositionTime == num)
      {
        syntheticSynhroniserItem.Move();
        flag = true;
      }
    }
    return flag;
  }
}
