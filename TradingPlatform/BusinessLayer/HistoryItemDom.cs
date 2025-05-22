// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.HistoryItemDom
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[ProtoContract]
public sealed class HistoryItemDom : HistoryItem
{
  [ProtoMember(1)]
  public List<HistoryItemLevel2> Asks { get; set; }

  [ProtoMember(2)]
  public List<HistoryItemLevel2> Bids { get; set; }

  /// <summary>Creates HistoryItemLast instance</summary>
  public HistoryItemDom()
  {
    this.Asks = new List<HistoryItemLevel2>();
    this.Bids = new List<HistoryItemLevel2>();
  }

  public HistoryItemDom(DOMQuote domQuote)
    : base((MessageQuote) domQuote)
  {
    this.Asks = domQuote.Asks.Select<Level2Quote, HistoryItemLevel2>((Func<Level2Quote, HistoryItemLevel2>) (([In] obj0) => new HistoryItemLevel2(obj0))).ToList<HistoryItemLevel2>();
    this.Bids = domQuote.Bids.Select<Level2Quote, HistoryItemLevel2>((Func<Level2Quote, HistoryItemLevel2>) (([In] obj0) => new HistoryItemLevel2(obj0))).ToList<HistoryItemLevel2>();
  }

  public HistoryItemDom(HistoryItemDom original)
    : base((HistoryItem) original)
  {
    this.Asks = original.Asks.Select<HistoryItemLevel2, HistoryItemLevel2>((Func<HistoryItemLevel2, HistoryItemLevel2>) (([In] obj0) => new HistoryItemLevel2(obj0))).ToList<HistoryItemLevel2>();
    this.Bids = original.Bids.Select<HistoryItemLevel2, HistoryItemLevel2>((Func<HistoryItemLevel2, HistoryItemLevel2>) (([In] obj0) => new HistoryItemLevel2(obj0))).ToList<HistoryItemLevel2>();
  }

  [NotPublished]
  public override object Clone() => (object) new HistoryItemDom(this);
}
