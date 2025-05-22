// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SubscribeQuotesParameters
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using ProtoBuf;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>Defines quote parameters for subscribtion</summary>
[ProtoContract]
public class SubscribeQuotesParameters : RequestParameters
{
  public override RequestType Type => RequestType.QuoteSubscribe;

  /// <summary>Symbol Id</summary>
  [ProtoMember(1)]
  public string SymbolId { get; [param: In] internal set; }

  /// <summary>Quote type</summary>
  [ProtoMember(2)]
  public SubscribeQuoteType SubscribeType { get; [param: In] internal set; }

  /// <summary>SubscribeQuotesParameters constructor</summary>
  public SubscribeQuotesParameters(string symbolId, SubscribeQuoteType subscribeQuoteType)
  {
    this.SymbolId = symbolId;
    this.SubscribeType = subscribeQuoteType;
  }

  internal SubscribeQuotesParameters()
  {
  }
}
