// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.Limitation.Limiter
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using TradingPlatform.BusinessLayer.Integration.Limitation;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils.Limitation;

public class Limiter : IDisposable
{
  private readonly 퓏.픏[] 퓲퓧;
  private readonly Timer 퓲픰;

  public Limiter(LimitationMetadata metadata)
  {
    this.퓲퓧 = metadata.Limits.Select<Limit, 퓏.픏>((Func<Limit, 퓏.픏>) (([In] obj0) => new 퓏.픏(obj0))).ToArray<퓏.픏>();
    this.퓲픰 = new Timer(new TimerCallback(this.퓏), (object) null, TimeSpan.FromMilliseconds(100.0), TimeSpan.FromMilliseconds(100.0));
  }

  public void Wait(RequestType requestType, CancellationToken cancellationToken)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: reference to a compiler-generated method
    foreach (퓏.픏 픏 in ((IEnumerable<퓏.픏>) this.퓲퓧).Where<퓏.픏>(new Func<퓏.픏, bool>(new Limiter.퓬()
    {
      픇픋 = requestType
    }.퓏)).ToArray<퓏.픏>())
      픏.퓏(cancellationToken);
  }

  public void Dispose()
  {
    this.퓲픰.Change(-1, -1);
    this.퓲픰.Dispose();
  }

  private void 퓏([In] object obj0)
  {
    foreach (퓏.픏 픏 in this.퓲퓧)
      픏.퓏();
  }
}
