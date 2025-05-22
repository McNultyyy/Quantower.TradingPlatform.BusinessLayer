// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Licence.LoopbackBase
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace TradingPlatform.BusinessLayer.Licence;

public abstract class LoopbackBase : IDisposable
{
  protected readonly TaskCompletionSource<string> taskSource;

  public LoopbackBase() => this.taskSource = new TaskCompletionSource<string>();

  public abstract Task<string> WaitForCallbackAsync(CancellationToken token);

  public void CancelWaiting()
  {
    if (!this.taskSource.TrySetCanceled())
      return;
    Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓮(), LoggingLevel.Verbose);
  }

  public virtual void Dispose()
  {
  }
}
