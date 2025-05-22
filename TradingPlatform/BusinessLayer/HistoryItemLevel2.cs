// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.HistoryItemLevel2
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using ProtoBuf;
using TradingPlatform.BusinessLayer.Integration;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[ProtoContract]
public sealed class HistoryItemLevel2 : HistoryItem
{
  [ProtoMember(1)]
  public string Id { get; set; }

  [ProtoMember(2)]
  public QuotePriceType PriceType { get; set; }

  [ProtoMember(3)]
  public double Price { get; set; }

  [ProtoMember(4)]
  public double Size { get; set; }

  [ProtoMember(5)]
  public bool Closed { get; set; }

  /// <summary>Creates HistoryItemLast instance</summary>
  public HistoryItemLevel2()
  {
    this.Price = double.NaN;
    this.Size = double.NaN;
  }

  public HistoryItemLevel2(Level2Quote level2Quote)
    : base((MessageQuote) level2Quote)
  {
    this.Id = level2Quote.Id;
    this.PriceType = level2Quote.PriceType;
    this.Price = level2Quote.Price;
    this.Size = level2Quote.Size;
    this.Closed = level2Quote.Closed;
  }

  public HistoryItemLevel2(HistoryItemLevel2 original)
    : base((HistoryItem) original)
  {
    this.Id = original.Id;
    this.PriceType = original.PriceType;
    this.Price = original.Price;
    this.Size = original.Size;
    this.Closed = original.Closed;
  }

  [NotPublished]
  public override object Clone() => (object) new HistoryItemLevel2(this);
}
