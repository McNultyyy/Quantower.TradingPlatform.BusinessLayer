// Decompiled with JetBrains decompiler
// Type: 퓏.픏
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using TradingPlatform.BusinessLayer;
using TradingPlatform.BusinessLayer.Integration.Limitation;

#nullable disable
namespace 퓏;

internal class 픏
{
  private readonly 퓳 퓲퓢;
  private readonly HashSet<RequestType> 퓲픫;

  public 픏([In] Limit obj0)
  {
    this.퓲퓢 = obj0.Interval == LimitInterval.FloatingWindow ? (퓳) new 픉(obj0.Period, obj0.Value) : (퓳) new 픮(obj0.Period, obj0.Value);
    HashSet<RequestType> requestTypeSet = new HashSet<RequestType>();
    foreach (RequestType requestType in obj0.RequestTypes)
      requestTypeSet.Add(requestType);
    this.퓲픫 = requestTypeSet;
  }

  public void 퓏([In] CancellationToken obj0) => this.퓲퓢.퓏(obj0);

  public void 퓏() => this.퓲퓢.퓏();

  public bool 퓏([In] RequestType obj0) => this.퓲픫.Contains(obj0);
}
