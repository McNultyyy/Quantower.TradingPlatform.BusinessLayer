// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.GetStrikesRequestParameters
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
public class GetStrikesRequestParameters : CachedRequestParameters
{
  public override RequestType Type => RequestType.Strikes;

  public string ConnectionId { get; set; }

  [ProtoMember(1)]
  public string UnderlierId { get; set; }

  [ProtoMember(2)]
  public string SerieId { get; set; }

  [ProtoMember(3)]
  public DateTime ExpirationDate { get; set; }

  public GetStrikesRequestParameters()
  {
  }

  public GetStrikesRequestParameters(GetStrikesRequestParameters origin)
    : base((CachedRequestParameters) origin)
  {
    this.ConnectionId = origin.ConnectionId;
    this.UnderlierId = origin.UnderlierId;
    this.SerieId = origin.SerieId;
    this.ExpirationDate = origin.ExpirationDate;
  }

  internal GetStrikesRequestParameters([In] OptionSerie obj0)
  {
    this.ConnectionId = obj0.ConnectionId;
    this.UnderlierId = obj0.UnderlierId;
    this.SerieId = obj0.Id;
    this.ExpirationDate = obj0.ExpirationDate;
  }

  public override int GetCacheKey()
  {
    HashCode hashCode = new HashCode();
    if (this.UnderlierId != null)
      hashCode.Add<string>(this.UnderlierId);
    if (this.SerieId != null)
      hashCode.Add<string>(this.SerieId);
    hashCode.Add<DateTime>(this.ExpirationDate);
    return hashCode.ToHashCode();
  }
}
