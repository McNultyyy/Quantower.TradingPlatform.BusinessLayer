// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.GetSymbolRequestParameters
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using ProtoBuf;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[Published]
[ProtoContract]
public class GetSymbolRequestParameters : CachedRequestParameters
{
  public override RequestType Type => RequestType.Symbol;

  [ProtoMember(1)]
  public string SymbolId { get; set; }

  public override int GetCacheKey() => this.SymbolId.GetHashCode();

  public GetSymbolRequestParameters()
  {
  }

  public GetSymbolRequestParameters(GetSymbolRequestParameters origin)
    : base((CachedRequestParameters) origin)
  {
    this.SymbolId = origin.SymbolId;
  }
}
