// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SearchSymbolsRequestParameters
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using ProtoBuf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[ProtoContract]
public class SearchSymbolsRequestParameters : CachedRequestParameters
{
  public override RequestType Type => RequestType.SearchSymbol;

  public string ConnectionId { get; set; }

  [ProtoMember(1)]
  public string FilterName { get; set; }

  [ProtoMember(2)]
  public IList<string> ExchangeIds { get; set; } = (IList<string>) new List<string>();

  [ProtoMember(3)]
  public IList<SymbolType> SymbolTypes { get; set; } = (IList<SymbolType>) new List<SymbolType>();

  public Func<string, string> GetSynonyms { get; set; }

  public SearchSymbolsRequestParameters()
  {
  }

  public SearchSymbolsRequestParameters(SearchSymbolsRequestParameters origin)
    : base((CachedRequestParameters) origin)
  {
    this.ConnectionId = origin.ConnectionId;
    this.FilterName = origin.FilterName;
    this.ExchangeIds = (IList<string>) new List<string>((IEnumerable<string>) origin.ExchangeIds);
    this.SymbolTypes = (IList<SymbolType>) new List<SymbolType>((IEnumerable<SymbolType>) origin.SymbolTypes);
    this.GetSynonyms = origin.GetSynonyms;
  }

  public override int GetCacheKey()
  {
    HashCode hashCode = new HashCode();
    hashCode.Add<string>(this.FilterName ?? string.Empty);
    hashCode.Add<int>(((IStructuralEquatable) this.ExchangeIds.ToArray<string>()).GetHashCode((IEqualityComparer) EqualityComparer<string>.Default));
    hashCode.Add<int>(((IStructuralEquatable) this.SymbolTypes.Cast<int>().ToArray<int>()).GetHashCode((IEqualityComparer) EqualityComparer<int>.Default));
    return hashCode.ToHashCode();
  }
}
