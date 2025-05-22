// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.UpdatesProvider.UpdatesProvider`2
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils.UpdatesProvider;

public class UpdatesProvider<TKey, TValue>
{
  private IDictionary<TKey, TValue> 퓲픨;
  private readonly object 퓲퓪;
  private readonly DifferenceObserver 퓲픪;

  public event Action<TValue> ItemAdded;

  public event Action<TValue> ItemUpdated;

  public event Action<TValue> ItemRemoved;

  public TValue[] Items
  {
    get
    {
      lock (this.퓲퓪)
        return this.퓲픨.Values.ToArray<TValue>();
    }
  }

  public bool UpdateItem { get; set; }

  public ApplyDifferencePredicate ApplyDifferencePredicate
  {
    get => this.퓲픪.ApplyDifferencePredicate;
    set => this.퓲픪.ApplyDifferencePredicate = value;
  }

  public UpdatesProvider(IDictionary<TKey, TValue> items, params string[] propertyNamesToObserve)
  {
    this.퓲픨 = (IDictionary<TKey, TValue>) new Dictionary<TKey, TValue>(items);
    this.퓲퓪 = new object();
    this.퓲픪 = new DifferenceObserver();
    this.퓲픪.RegisterType(typeof (TValue), propertyNamesToObserve);
    this.UpdateItem = true;
  }

  public void ProcessItems(IDictionary<TKey, TValue> newCache)
  {
    newCache = (IDictionary<TKey, TValue>) new Dictionary<TKey, TValue>(newCache);
    lock (this.퓲퓪)
    {
      IEnumerable<TKey> keys1 = newCache.Keys.Except<TKey>((IEnumerable<TKey>) this.퓲픨.Keys);
      IEnumerable<TKey> keys2 = this.퓲픨.Keys.Except<TKey>((IEnumerable<TKey>) newCache.Keys);
      IEnumerable<TKey> keys3 = this.퓲픨.Keys.Intersect<TKey>((IEnumerable<TKey>) newCache.Keys);
      foreach (TKey key in keys1)
        this.퓏(newCache[key]);
      foreach (TKey key in keys2)
        this.핇(this.퓲픨[key]);
      foreach (TKey key in keys3)
      {
        TValue entity1 = this.퓲픨[key];
        TValue entity2 = newCache[key];
        if (((IEnumerable<string>) this.퓲픪.GetDifference<TValue>(entity1, entity2, this.UpdateItem).ToArray<string>()).Any<string>())
          this.퓬(entity2);
      }
      this.퓲픨 = newCache;
    }
  }

  public void ProcessNewItem(TKey key, TValue newItem)
  {
    Action<TValue> action = (Action<TValue>) null;
    lock (this.퓲퓪)
    {
      TValue entity1;
      if (this.퓲픨.TryGetValue(key, out entity1))
      {
        if (!this.퓲픪.GetDifference<TValue>(entity1, newItem, this.UpdateItem).Any<string>())
          return;
        action = new Action<TValue>(this.퓬);
      }
      else
        action = new Action<TValue>(this.퓏);
      this.퓲픨[key] = newItem;
    }
    action(newItem);
  }

  public void RemoveItem(TKey key, TValue item)
  {
    lock (this.퓲퓪)
    {
      if (!this.퓲픨.ContainsKey(key))
        return;
      this.퓲픨.Remove(key);
    }
    this.핇(item);
  }

  public bool TryGetValue(TKey key, out TValue value)
  {
    lock (this.퓲퓪)
      return this.퓲픨.TryGetValue(key, out value);
  }

  private void 퓏([In] TValue obj0)
  {
    try
    {
      // ISSUE: reference to a compiler-generated field
      Action<TValue> 퓲퓶 = this.퓲퓶;
      if (퓲퓶 == null)
        return;
      퓲퓶(obj0);
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
  }

  private void 퓬([In] TValue obj0)
  {
    try
    {
      // ISSUE: reference to a compiler-generated field
      Action<TValue> 퓲퓽 = this.퓲퓽;
      if (퓲퓽 == null)
        return;
      퓲퓽(obj0);
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
  }

  private void 핇([In] TValue obj0)
  {
    try
    {
      // ISSUE: reference to a compiler-generated field
      Action<TValue> 퓲픘 = this.퓲픘;
      if (퓲픘 == null)
        return;
      퓲픘(obj0);
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
  }
}
