// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.ResponseWaiterBase
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

public class ResponseWaiterBase
{
  public readonly long RequestId;
  public bool isFinish;

  public TimeSpan Elapsed { get; [param: In] private set; }

  public ResponseWaiterBase(long requestId) => this.RequestId = requestId;

  public bool WaitForResponse(TimeSpan timeout, CancellationToken cancellationToken = default (CancellationToken))
  {
    this.Elapsed = TimeSpan.Zero;
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    while (!this.isFinish)
    {
      if (cancellationToken.IsCancellationRequested)
        return false;
      this.Elapsed = stopwatch.Elapsed;
      if (timeout < stopwatch.Elapsed)
        return false;
      Thread.Sleep(20);
    }
    return true;
  }
}
