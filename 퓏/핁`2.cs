// Decompiled with JetBrains decompiler
// Type: 퓏.핁`2
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

internal class 핁<퓏, 퓬> : IDisposable where 퓏 : CachedRequestParameters
{
  private Dictionary<int, 픇<퓬>> RequestsCache { get; [param: In] set; }

  public 핁() => this.RequestsCache = new Dictionary<int, 픇<퓬>>();

  public 픇<퓬> 퓏([In] 퓏 obj0)
  {
    int cacheKey = obj0.GetCacheKey();
    픇<퓬> 픇;
    lock (this.RequestsCache)
    {
      if (!this.RequestsCache.TryGetValue(cacheKey, out 픇))
      {
        픇 = new 픇<퓬>();
        this.RequestsCache[cacheKey] = 픇;
      }
      else if (픇.Finished)
        return 픇;
    }
    Monitor.Enter((object) 픇);
    if (픇.Finished)
      Monitor.Exit((object) 픇);
    return 픇;
  }

  public void 퓏([In] 퓏 obj0, [In] 퓬 obj1)
  {
    int cacheKey = obj0.GetCacheKey();
    픇<퓬> 픇;
    bool finished;
    lock (this.RequestsCache)
    {
      if (!this.RequestsCache.TryGetValue(cacheKey, out 픇))
      {
        this.RequestsCache[cacheKey] = 픇 = new 픇<퓬>(obj1);
        return;
      }
      finished = 픇.Finished;
      픇.Result = obj1;
      픇.Finished = true;
    }
    if (finished)
      return;
    try
    {
      Monitor.Exit((object) 픇);
    }
    catch
    {
    }
  }

  public void Dispose() => this.RequestsCache.Clear();
}
