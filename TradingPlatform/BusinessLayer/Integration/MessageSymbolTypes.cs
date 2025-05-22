// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.MessageSymbolTypes
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using ProtoBuf;
using System.Collections.Generic;
using System.Runtime.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

[DataContract(Name = "InstrumentTypes", Namespace = "TradingPlatform")]
[ProtoContract]
public sealed class MessageSymbolTypes : Message
{
  public override MessageType Type => MessageType.SymbolTypes;

  [ProtoMember(1)]
  public IList<SymbolType> SymbolTypes { get; set; }
}
