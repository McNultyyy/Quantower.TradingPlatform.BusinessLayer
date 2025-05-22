// Decompiled with JetBrains decompiler
// Type: 퓏.핅`2
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace 퓏;

internal class 핅<퓏, 퓬> : IEnumerable<퓬>, IEnumerable
{
  private readonly Dictionary<퓏, 퓬> 퓲퓲;
  private readonly List<퓬> 퓲핂;
  private readonly Dictionary<퓏, int> 퓲픂;
  private readonly Dictionary<int, 퓏> 퓲픾;

  public 핅()
  {
    this.퓲퓲 = new Dictionary<퓏, 퓬>();
    this.퓲핂 = new List<퓬>();
    this.퓲픂 = new Dictionary<퓏, int>();
    this.퓲픾 = new Dictionary<int, 퓏>();
  }

  public static 핅<퓏, 퓬> 핇() => (핅<퓏, 퓬>) new 픡<퓏, 퓬>();

  private void 퓲([In] int obj0)
  {
    for (; obj0 <= this.퓲핂.Count; ++obj0)
    {
      퓏 key = this.퓲픾[obj0];
      this.퓲픾[obj0 - 1] = key;
      this.퓲픂[key] = obj0 - 1;
    }
    this.퓲픾.Remove(obj0 - 1);
  }

  private int 퓬([In] 퓏 obj0, [In] 퓬 obj1)
  {
    this.퓲퓲.Add(obj0, obj1);
    this.퓲핂.Add(obj1);
    int key = this.퓲핂.Count - 1;
    this.퓲픂.Add(obj0, key);
    this.퓲픾.Add(key, obj0);
    return key;
  }

  private void 핂([In] int obj0)
  {
    this.퓲핂.RemoveAt(obj0);
    퓏 key = this.퓲픾[obj0];
    this.퓲퓲.Remove(key);
    this.퓲픂.Remove(key);
    this.퓲픾.Remove(obj0);
    this.퓲(obj0 + 1);
  }

  public virtual int Count => this.퓲핂.Count;

  public virtual 퓬 퓏([In] int obj0) => this.퓲핂[obj0];

  public virtual 퓬[] 퓏()
  {
    퓬[] 퓬Array = new 퓬[this.퓲퓲.Count];
    int num = 0;
    foreach (퓬 퓬 in this.퓲퓲.Values)
      퓬Array[num++] = 퓬;
    return 퓬Array;
  }

  public virtual 퓬 this[[In] 퓏 obj0]
  {
    get
    {
      return (object) obj0 != null && this.퓲퓲 != null && this.퓲퓲.ContainsKey(obj0) ? this.퓲퓲[obj0] : default (퓬);
    }
    [param: In] set
    {
      if (!this.퓲퓲.ContainsKey(obj0))
      {
        this.퓬(obj0, value);
      }
      else
      {
        this.퓲퓲[obj0] = value;
        this.퓲핂[this.퓲픂[obj0]] = value;
      }
    }
  }

  public virtual int 퓏([In] 퓏 obj0, [In] 퓬 obj1) => this.퓬(obj0, obj1);

  public virtual void 퓏([In] 퓏 obj0)
  {
    if (!this.퓲퓲.ContainsKey(obj0))
      return;
    this.퓲퓲.Remove(obj0);
    int num = this.퓲픂[obj0];
    this.퓲핂.RemoveAt(num);
    this.퓲픂.Remove(obj0);
    this.퓲픾.Remove(num);
    this.퓲(num + 1);
  }

  public virtual void 퓬([In] int obj0) => this.핂(obj0);

  public virtual void 퓏([In] int obj0, [In] int obj1)
  {
    this.퓲핂.RemoveRange(obj0, obj1);
    for (int key1 = obj0; key1 < obj0 + obj1; ++key1)
    {
      퓏 key2 = this.퓲픾[key1];
      this.퓲퓲.Remove(key2);
      this.퓲픂.Remove(key2);
      this.퓲픾.Remove(key1);
    }
    for (; obj0 < this.퓲핂.Count; ++obj0)
    {
      퓏 key = this.퓲픾[obj0 + obj1];
      if ((object) key != null)
      {
        this.퓲픾[obj0] = key;
        this.퓲픂[key] = obj0;
      }
    }
    for (int count = this.퓲핂.Count; count < this.퓲핂.Count + obj1; ++count)
      this.퓲픾.Remove(count);
  }

  public virtual void 퓏([In] 퓬 obj0) => this.핂(this.퓲핂.IndexOf(obj0));

  public virtual 퓏 핇([In] int obj0) => this.퓲픾[obj0];

  public virtual void 퓬()
  {
    this.퓲퓲.Clear();
    this.퓲핂.Clear();
    this.퓲픾.Clear();
    this.퓲픂.Clear();
  }

  public virtual bool 퓬([In] 퓏 obj0) => this.퓲퓲.ContainsKey(obj0);

  public virtual bool 퓬([In] 퓬 obj0) => this.퓲퓲.ContainsValue(obj0);

  public virtual ICollection<퓏> Keys => (ICollection<퓏>) this.퓲퓲.Keys;

  public virtual ICollection<퓬> Values => (ICollection<퓬>) this.퓲퓲.Values;

  public virtual IEnumerator<퓬> GetEnumerator() => (IEnumerator<퓬>) this.퓲핂.GetEnumerator();

  IEnumerator IEnumerable.퓲() => (IEnumerator) this.GetEnumerator();

  public virtual bool 퓏([In] 퓏 obj0, out 퓬 _param2) => this.퓲퓲.TryGetValue(obj0, out _param2);
}
