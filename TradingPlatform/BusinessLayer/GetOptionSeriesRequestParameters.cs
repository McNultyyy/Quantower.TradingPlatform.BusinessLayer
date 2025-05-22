// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.GetOptionSeriesRequestParameters
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using ProtoBuf;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[ProtoContract]
public class GetOptionSeriesRequestParameters : CachedRequestParameters
{
  public override RequestType Type => RequestType.OptionSeries;

  public string ConnectionId { get; set; }

  [ProtoMember(1)]
  public string UnderlierId { get; set; }

  [ProtoMember(2)]
  public string ExchangeId { get; set; }

  public GetOptionSeriesRequestParameters()
  {
  }

  public GetOptionSeriesRequestParameters(GetOptionSeriesRequestParameters origin)
    : base((CachedRequestParameters) origin)
  {
    this.ConnectionId = origin.ConnectionId;
    this.UnderlierId = origin.UnderlierId;
    this.ExchangeId = origin.ExchangeId;
  }

  internal GetOptionSeriesRequestParameters([In] Symbol obj0)
  {
    this.ConnectionId = obj0.ConnectionId;
    this.UnderlierId = obj0.Id;
    this.ExchangeId = obj0.ExchangeId;
  }

  public override int GetCacheKey()
  {
    HashCode hashCode = new HashCode();
    if (this.UnderlierId != null)
      hashCode.Add<string>(this.UnderlierId);
    if (this.ExchangeId != null)
      hashCode.Add<string>(this.ExchangeId);
    return hashCode.ToHashCode();
  }
}
