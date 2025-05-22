// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.Map`2
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils;

public class Map<T1, T2> : IEnumerable<KeyValuePair<T1, T2>>, IEnumerable
{
  private readonly Dictionary<T1, T2> 퓲픁;
  private readonly Dictionary<T2, T1> 퓲픞;

  public Map()
  {
    this.퓲픁 = new Dictionary<T1, T2>();
    this.퓲픞 = new Dictionary<T2, T1>();
  }

  public void Add(T1 item1, T2 item2)
  {
    this.퓲픁.Add(item1, item2);
    this.퓲픞.Add(item2, item1);
  }

  public void Remove(T1 item1, T2 item2)
  {
    this.퓲픁.Remove(item1);
    this.퓲픞.Remove(item2);
  }

  public void Clear()
  {
    this.퓲픁.Clear();
    this.퓲픞.Clear();
  }

  public bool TryGetDirect(T1 key, out T2 value) => this.퓲픁.TryGetValue(key, out value);

  public bool TryGetReverse(T2 key, out T1 value) => this.퓲픞.TryGetValue(key, out value);

  public bool ContainsDirect(T1 key) => this.퓲픁.ContainsKey(key);

  public bool ContainsReverse(T2 key) => this.퓲픞.ContainsKey(key);

  public IEnumerator<KeyValuePair<T1, T2>> GetEnumerator()
  {
    return (IEnumerator<KeyValuePair<T1, T2>>) this.퓲픁.GetEnumerator();
  }

  IEnumerator IEnumerable.퓏() => ((IEnumerable) this.퓲픁).GetEnumerator();
}
