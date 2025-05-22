// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.PnL
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using ProtoBuf;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[ProtoContract]
public class PnL
{
  [ProtoMember(1)]
  public PnLItem GrossPnL { get; set; }

  [ProtoMember(2)]
  public PnLItem NetPnL { get; set; }

  [ProtoMember(3)]
  public PnLItem Fee { get; set; }

  [ProtoMember(4)]
  public PnLItem Swaps { get; set; }
}
