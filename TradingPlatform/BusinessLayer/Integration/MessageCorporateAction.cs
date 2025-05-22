// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.MessageCorporateAction
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using ProtoBuf;
using System;
using System.Runtime.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

[DataContract(Name = "CorporateAction", Namespace = "TradingPlatform")]
[ProtoContract]
public sealed class MessageCorporateAction : Message, INeedSymbolToPocess
{
  public override MessageType Type => MessageType.CorporateAction;

  [DataMember(Name = "CorporateActionId")]
  [ProtoMember(1)]
  public string CorporateActionId { get; set; }

  [DataMember(Name = "DateTime")]
  [ProtoMember(2)]
  public DateTime DateTime { get; set; }

  [DataMember(Name = "InstrumentSymbol")]
  [ProtoMember(3)]
  public string SymbolId { get; set; }

  [DataMember(Name = "Details")]
  [ProtoMember(4)]
  public string Details { get; set; }

  [ProtoMember(5)]
  public CorporateActionType CorporateActionType { get; set; }
}
