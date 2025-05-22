// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.IntervalExtensions
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Utils;

#nullable enable
namespace TradingPlatform.BusinessLayer;

public static class IntervalExtensions
{
  /// <summary>Combines intersecting intervals</summary>
  public static 
  #nullable disable
  IEnumerable<Interval<T>> Optimize<T>(this IEnumerable<Interval<T>> intervals) where T : IComparable<T>
  {
    Interval<퓏>[] array = intervals.ToArray<Interval<퓏>>();
    퓏[] array1 = ((IEnumerable<Interval<퓏>>) array).Select<Interval<퓏>, 퓏>((Func<Interval<퓏>, 퓏>) (([In] obj0) => obj0.Min)).OrderBy<퓏, 퓏>((Func<퓏, 퓏>) (([In] obj0) => obj0)).ToArray<퓏>();
    퓏[] array2 = ((IEnumerable<Interval<퓏>>) array).Select<Interval<퓏>, 퓏>((Func<Interval<퓏>, 퓏>) (([In] obj0) => obj0.Max)).OrderBy<퓏, 퓏>((Func<퓏, 퓏>) (([In] obj0) => obj0)).ToArray<퓏>();
    int index1 = 0;
    int index2 = 0;
    퓏 from = ((IEnumerable<퓏>) array1).First<퓏>();
    int num = 0;
    while (index1 < array1.Length && index2 < array2.Length)
    {
      퓏 퓏 = array1[index1];
      퓏 퓏1 = array2[index2];
      if (퓏.CompareTo(퓏1) <= 0)
      {
        ++num;
        ++index1;
      }
      else
      {
        --num;
        ++index2;
      }
      if (num == 0)
      {
        yield return new Interval<퓏>(from, 퓏1);
        from = 퓏;
      }
      퓏 = default (퓏);
    }
    yield return new Interval<퓏>(from, ((IEnumerable<퓏>) array2).Last<퓏>());
  }
}
