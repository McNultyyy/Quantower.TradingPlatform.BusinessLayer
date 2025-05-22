// Decompiled with JetBrains decompiler
// Type: 퓏.픉
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

internal class 픉 : 퓳
{
  private readonly Period 픣핇;
  private readonly int 픣퓲;
  private readonly Queue<픉.퓏> 픣핂;
  private readonly object 픣픂;

  public 픉([In] Period obj0, [In] int obj1)
  {
    this.픣핇 = obj0;
    this.픣퓲 = obj1;
    this.픣핂 = new Queue<픉.퓏>();
    this.픣픂 = new object();
  }

  public void 퓏([In] CancellationToken obj0)
  {
    픉.퓏 result;
    lock (this.픣픂)
    {
      if (this.픣핂.Count < this.픣퓲)
      {
        this.픣핂.Enqueue(new 픉.퓏(Core.Instance.TimeUtils.DateTimeUtcNow + this.픣핇.Duration));
        return;
      }
      this.픣핂.TryPeek(out result);
    }
    if (result == null)
      return;
    result.퓏(obj0);
    if (obj0.IsCancellationRequested)
      return;
    this.퓏(obj0);
  }

  public void 퓏()
  {
    lock (this.픣픂)
    {
      DateTime dateTimeUtcNow = Core.Instance.TimeUtils.DateTimeUtcNow;
      픉.퓏 result;
      while (this.픣핂.Count > 0 && this.픣핂.TryPeek(out result) && !(result.ExpirationTime > dateTimeUtcNow))
      {
        this.픣핂.Dequeue();
        result.퓏();
      }
    }
  }

  private class 퓏
  {
    private readonly ManualResetEventSlim 퓑퓻;

    public DateTime ExpirationTime { get; }

    public 퓏([In] DateTime obj0)
    {
      this.ExpirationTime = obj0;
      this.퓑퓻 = new ManualResetEventSlim();
    }

    public void 퓏() => this.퓑퓻.Set();

    public void 퓏([In] CancellationToken obj0) => this.퓑퓻.Wait(obj0);
  }
}
