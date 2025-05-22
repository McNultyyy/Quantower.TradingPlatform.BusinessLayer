// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.LimitedCollection`1
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils;

public class LimitedCollection<T> : ICollection<T>, IEnumerable<T>, IEnumerable
{
  public const int DEFAULT_CAPACITY = 100;
  private readonly IList<T> 퓲퓬;

  public int Capacity { get; }

  public bool IsFull => this.Count == this.Capacity;

  public int Count => this.퓲퓬.Count;

  bool ICollection<T>.IsReadOnly => false;

  public LimitedCollection(int capacity = 100)
  {
    this.퓲퓬 = (IList<T>) new List<T>(capacity);
    this.Capacity = capacity;
  }

  public void Add(T item)
  {
    lock (this.퓲퓬)
    {
      if (this.IsFull)
        this.퓲퓬.Remove(this.퓲퓬[0]);
      this.퓲퓬.Add(item);
    }
  }

  public void Clear() => this.퓲퓬.Clear();

  public bool Contains(T item) => this.퓲퓬.Contains(item);

  public bool Remove(T item) => this.퓲퓬.Remove(item);

  public void CopyTo(T[] array, int arrayIndex) => this.퓲퓬.CopyTo(array, arrayIndex);

  public IEnumerator<T> GetEnumerator()
  {
    lock (this.퓲퓬)
      return (IEnumerator<T>) new List<T>((IEnumerable<T>) this.퓲퓬).GetEnumerator();
  }

  IEnumerator IEnumerable.퓏() => (IEnumerator) this.GetEnumerator();
}
