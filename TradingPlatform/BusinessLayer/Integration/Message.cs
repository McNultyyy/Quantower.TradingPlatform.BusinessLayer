// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.Message
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using ProtoBuf;
using System;
using System.Runtime.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

[DataContract(Name = "Message", Namespace = "TradingPlatform")]
[KnownType(typeof (CustomMessage))]
[KnownType(typeof (MessageAccount))]
[KnownType(typeof (MessageAsset))]
[KnownType(typeof (MessageCloseOrder))]
[KnownType(typeof (MessageClosePosition))]
[KnownType(typeof (MessageExchange))]
[KnownType(typeof (MessageSymbol))]
[KnownType(typeof (MessageSymbolTypes))]
[KnownType(typeof (MessageOpenOrder))]
[KnownType(typeof (MessageOpenPosition))]
[KnownType(typeof (MessageReportType))]
[KnownType(typeof (MessageTrade))]
[KnownType(typeof (MessageQuote))]
[KnownType(typeof (MessageDealTicket))]
[KnownType(typeof (MessageRule))]
[KnownType(typeof (MessageOrderHistory))]
[ProtoContract]
[ProtoInclude(1, typeof (MessageAsset))]
[ProtoInclude(2, typeof (MessageAccount))]
[ProtoInclude(3, typeof (MessageSymbolInfo))]
[ProtoInclude(4, typeof (MessageSymbolTypes))]
[ProtoInclude(5, typeof (MessageExchange))]
[ProtoInclude(6, typeof (MessageQuote))]
[ProtoInclude(7, typeof (MessageOpenOrder))]
[ProtoInclude(8, typeof (MessageCloseOrder))]
[ProtoInclude(9, typeof (MessageOpenPosition))]
[ProtoInclude(10, typeof (MessageClosePosition))]
[ProtoInclude(11, typeof (MessageTrade))]
[ProtoInclude(12, typeof (MessageSessionsContainer))]
[ProtoInclude(13, typeof (MessageOptionSerie))]
[ProtoInclude(14, typeof (MessageCryptoAssetBalances))]
[ProtoInclude(15, typeof (MessageOpenDeliveredAsset))]
[ProtoInclude(16 /*0x10*/, typeof (CustomMessage))]
[Serializable]
public abstract class Message
{
  public abstract MessageType Type { get; }

  public override string ToString() => this.Type.ToString();
}
