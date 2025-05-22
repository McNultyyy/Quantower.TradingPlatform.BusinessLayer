// Decompiled with JetBrains decompiler
// Type: 퓏.픮
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Runtime.InteropServices;
using System.Threading;
using TradingPlatform.BusinessLayer;

#nullable disable
namespace 퓏;

internal class 픮 : 퓳
{
  private readonly Period 픇핀;
  private readonly int 픇픲;
  private DateTime 픇픽;
  private readonly ManualResetEvent 픣퓏;
  private int 픣퓬;

  public 픮([In] Period obj0, [In] int obj1)
  {
    this.픇핀 = obj0;
    this.픇픲 = obj1;
    this.퓬();
    this.픣퓏 = new ManualResetEvent(false);
  }

  public void 퓏([In] CancellationToken obj0)
  {
    if (this.픇픲 >= Interlocked.Increment(ref this.픣퓬))
      return;
    this.픣퓏.Reset();
    WaitHandle.WaitAny(new WaitHandle[2]
    {
      (WaitHandle) this.픣퓏,
      obj0.WaitHandle
    });
    if (obj0.IsCancellationRequested)
      return;
    this.퓏(obj0);
  }

  public void 퓏()
  {
    if (Core.Instance.TimeUtils.DateTimeUtcNow < this.픇픽)
      return;
    this.퓬();
    this.픣퓬 = 0;
    this.픣퓏.Set();
  }

  private void 퓬() => this.픇픽 = Core.Instance.TimeUtils.DateTimeUtcNow.CeilingTo(this.픇핀);
}
