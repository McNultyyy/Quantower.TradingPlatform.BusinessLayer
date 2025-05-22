// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.CrossRateCache
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils;

public class CrossRateCache : IDisposable
{
  private readonly Dictionary<CrossRateCache.퓏, double> 핇픃;

  public CrossRateCache() => this.핇픃 = new Dictionary<CrossRateCache.퓏, double>();

  public void ProcessPrice(string baseAsset, string quoteAsset, double price)
  {
    if (double.IsNaN(price))
      return;
    CrossRateCache.퓏 key = new CrossRateCache.퓏(baseAsset, quoteAsset);
    this.핇픃[key] = price;
    if (price == 0.0)
      return;
    key = new CrossRateCache.퓏(quoteAsset, baseAsset);
    this.핇픃[key] = 1.0 / price;
  }

  public bool TryGetCrossRate(string fromAsset, string toAsset, out double crossRate)
  {
    if (fromAsset == toAsset)
    {
      crossRate = 1.0;
      return true;
    }
    return this.핇픃.TryGetValue(new CrossRateCache.퓏(fromAsset, toAsset), out crossRate) && !double.IsNaN(crossRate);
  }

  public void Dispose() => this.핇픃.Clear();

  private readonly struct 퓏([In] string obj0, [In] string obj1) : IEquatable<CrossRateCache.퓏>
  {
    private readonly string 픇픸 = obj0;
    private readonly string 픇프 = obj1;

    public bool Equals(CrossRateCache.퓏 other) => this.픇픸 == other.픇픸 && this.픇프 == other.픇프;

    public override bool Equals(object obj) => obj is CrossRateCache.퓏 other && this.Equals(other);

    public override int GetHashCode()
    {
      return (this.픇픸 != null ? this.픇픸.GetHashCode() : 0) * 397 ^ (this.픇프 != null ? this.픇프.GetHashCode() : 0);
    }

    public override string ToString()
    {
      return this.픇픸 + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓛() + this.픇프;
    }
  }
}
