// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.RequestParameters
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Runtime.CompilerServices;
using System.Threading;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[Published]
public abstract class RequestParameters : IEquatable<RequestParameters>
{
  private static long 퓬퓝;

  public abstract RequestType Type { get; }

  public CancellationToken CancellationToken { get; set; }

  public string SendingSource { get; set; }

  public long RequestId { get; }

  protected RequestParameters() => this.RequestId = Interlocked.Increment(ref RequestParameters.퓬퓝);

  protected RequestParameters(RequestParameters origin)
  {
    this.CancellationToken = origin.CancellationToken;
    this.SendingSource = origin.SendingSource;
    this.RequestId = origin.RequestId;
  }

  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 2);
    interpolatedStringHandler.AppendFormatted<RequestType>(this.Type);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓼());
    interpolatedStringHandler.AppendFormatted<long>(this.RequestId);
    return interpolatedStringHandler.ToStringAndClear();
  }

  public bool Equals(RequestParameters other)
  {
    if (other == null)
      return false;
    return this == other || this.RequestId == other.RequestId;
  }

  public override bool Equals(object obj)
  {
    if (obj == null)
      return false;
    if (this == obj)
      return true;
    return !(obj.GetType() != this.GetType()) && this.Equals((RequestParameters) obj);
  }

  public override int GetHashCode() => this.RequestId.GetHashCode();
}
