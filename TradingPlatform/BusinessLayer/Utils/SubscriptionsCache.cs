// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.SubscriptionsCache
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

#nullable enable
namespace TradingPlatform.BusinessLayer.Utils;

public class SubscriptionsCache : IDisposable
{
  private readonly 
  #nullable disable
  IDictionary<SubscribeQuoteType, SubscriptionsCache.퓏> 퓲핅;

  public SubscriptionsCache()
  {
    this.퓲핅 = (IDictionary<SubscribeQuoteType, SubscriptionsCache.퓏>) new Dictionary<SubscribeQuoteType, SubscriptionsCache.퓏>();
    foreach (SubscribeQuoteType key in Enum.GetValues(typeof (SubscribeQuoteType)))
      this.퓲핅[key] = new SubscriptionsCache.퓏();
  }

  public bool AddSubscription(SubscribeQuoteType subscribeQuoteType, string symbolId)
  {
    return this.퓲핅[subscribeQuoteType].퓏(symbolId);
  }

  public bool RemoveSubscription(SubscribeQuoteType subscribeQuoteType, string symbolId)
  {
    return this.퓲핅[subscribeQuoteType].퓬(symbolId);
  }

  public bool IsSubscribed(SubscribeQuoteType subscribeQuoteType, string symbolId)
  {
    return this.퓲핅[subscribeQuoteType].핇(symbolId);
  }

  public bool HasAnySubscription(string symbolId)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: reference to a compiler-generated method
    return this.퓲핅.Values.Any<SubscriptionsCache.퓏>(new Func<SubscriptionsCache.퓏, bool>(new SubscriptionsCache.핇()
    {
      픇픓 = symbolId
    }.퓏));
  }

  public string[] FindSubscribedSymbols(SubscribeQuoteType subscribeQuoteType)
  {
    return this.퓲핅[subscribeQuoteType].퓏();
  }

  public string[] FindAllSubscribedSymbols()
  {
    return this.퓲핅.Values.SelectMany<SubscriptionsCache.퓏, string>((Func<SubscriptionsCache.퓏, IEnumerable<string>>) (([In] obj0) => (IEnumerable<string>) obj0.퓏())).Distinct<string>().ToArray<string>();
  }

  public void Dispose()
  {
    foreach (SubscriptionsCache.퓏 퓏 in (IEnumerable<SubscriptionsCache.퓏>) this.퓲핅.Values)
      퓏.Dispose();
  }

  private class 퓏 : IDisposable
  {
    private readonly IDictionary<string, int> 픇픶;
    private readonly object 픇픀;

    public 퓏()
    {
      this.픇픶 = (IDictionary<string, int>) new Dictionary<string, int>();
      this.픇픀 = new object();
    }

    public bool 퓏([In] string obj0)
    {
      lock (this.픇픀)
      {
        this.퓲(obj0);
        this.픇픶[obj0]++;
        return this.픇픶[obj0] == 1;
      }
    }

    public bool 퓬([In] string obj0)
    {
      lock (this.픇픀)
      {
        this.퓲(obj0);
        this.픇픶[obj0] = Math.Max(0, this.픇픶[obj0] - 1);
        return this.픇픶[obj0] == 0;
      }
    }

    public bool 핇([In] string obj0)
    {
      lock (this.픇픀)
        return this.픇픶.ContainsKey(obj0) && this.픇픶[obj0] > 0;
    }

    public string[] 퓏()
    {
      lock (this.픇픀)
        return this.픇픶.Where<KeyValuePair<string, int>>((Func<KeyValuePair<string, int>, bool>) (([In] obj0) => obj0.Value > 0)).Select<KeyValuePair<string, int>, string>((Func<KeyValuePair<string, int>, string>) (([In] obj0) => obj0.Key)).ToArray<string>();
    }

    private void 퓲([In] string obj0)
    {
      if (this.픇픶.ContainsKey(obj0))
        return;
      this.픇픶[obj0] = 0;
    }

    public void Dispose()
    {
      lock (this.픇픀)
        this.픇픶.Clear();
    }
  }
}
