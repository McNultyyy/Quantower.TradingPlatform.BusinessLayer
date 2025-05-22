// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.HistoryItemMark
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using ProtoBuf;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[ProtoContract]
public class HistoryItemMark : HistoryItem
{
  [ProtoMember(1)]
  public double Price { get; set; }

  [ProtoMember(2)]
  public double Volume { get; set; }

  /// <summary>
  /// Gets price by indexing <see cref="T:TradingPlatform.BusinessLayer.PriceType" />
  /// </summary>
  /// <param name="priceType"></param>
  /// <returns></returns>
  public override double this[PriceType priceType]
  {
    get
    {
      switch (priceType)
      {
        case PriceType.Open:
        case PriceType.High:
        case PriceType.Low:
        case PriceType.Close:
        case PriceType.Median:
        case PriceType.Typical:
        case PriceType.Weighted:
        case PriceType.Bid:
        case PriceType.Ask:
        case PriceType.Last:
        case PriceType.Mark:
          return this.Price;
        case PriceType.Volume:
          return this.Volume;
        default:
          return base[priceType];
      }
    }
  }

  /// <summary>Creates HistoryItemLast instance</summary>
  public HistoryItemMark()
  {
    this.Price = double.NaN;
    this.Volume = double.NaN;
  }

  private HistoryItemMark([In] HistoryItemMark obj0)
    : base((HistoryItem) obj0)
  {
    this.Price = obj0.Price;
    this.Volume = obj0.Volume;
  }

  [NotPublished]
  public override object Clone() => (object) new HistoryItemMark(this);
}
