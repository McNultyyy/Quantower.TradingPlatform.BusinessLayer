// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.GetFutureContractsRequestParameters
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using ProtoBuf;
using System;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[ProtoContract]
public class GetFutureContractsRequestParameters : CachedRequestParameters
{
  public override RequestType Type => RequestType.FutureContracts;

  public string ConnectionId { get; set; }

  [ProtoMember(1)]
  public string Root { get; set; }

  [ProtoMember(2)]
  public string ExchangeId { get; set; }

  [ProtoMember(3)]
  public string UnderlierId { get; set; }

  public GetFutureContractsRequestParameters()
  {
  }

  public GetFutureContractsRequestParameters(GetFutureContractsRequestParameters origin)
    : base((CachedRequestParameters) origin)
  {
    this.ConnectionId = origin.ConnectionId;
    this.Root = origin.Root;
    this.ExchangeId = origin.ExchangeId;
    this.UnderlierId = origin.UnderlierId;
  }

  public override int GetCacheKey()
  {
    if (!string.IsNullOrEmpty(this.UnderlierId))
      return this.UnderlierId.GetHashCode();
    HashCode hashCode = new HashCode();
    if (this.Root != null)
      hashCode.Add<string>(this.Root);
    if (this.ExchangeId != null)
      hashCode.Add<string>(this.ExchangeId);
    if (this.UnderlierId != null)
      hashCode.Add<string>(this.UnderlierId);
    return hashCode.ToHashCode();
  }
}
