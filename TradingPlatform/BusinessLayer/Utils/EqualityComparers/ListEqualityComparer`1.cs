// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.EqualityComparers.ListEqualityComparer`1
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Collections.Generic;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils.EqualityComparers;

public class ListEqualityComparer<TItem> : IEqualityComparer<IList<TItem>>
{
  private readonly IEqualityComparer<TItem> 퓲픯;

  public ListEqualityComparer(IEqualityComparer<TItem> itemEqualityComparer)
  {
    this.퓲픯 = itemEqualityComparer;
  }

  public bool Equals(IList<TItem> x, IList<TItem> y)
  {
    if (x == y)
      return true;
    if (x == null || y == null || x.GetType() != y.GetType() || x.Count != y.Count)
      return false;
    for (int index = 0; index < x.Count; ++index)
    {
      if (!this.퓲픯.Equals(x[index], y[index]))
        return false;
    }
    return true;
  }

  public int GetHashCode(IList<TItem> list)
  {
    int hashCode = list.Count.GetHashCode();
    foreach (TItem obj in (IEnumerable<TItem>) list)
      hashCode = hashCode * 397 ^ this.퓲픯.GetHashCode(obj);
    return hashCode;
  }
}
