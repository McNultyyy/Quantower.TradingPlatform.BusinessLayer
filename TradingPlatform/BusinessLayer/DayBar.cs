// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.DayBar
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using ProtoBuf;
using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Integration;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>
/// Represent access to DayBar quote, which contains summary information about instrument prices.
/// </summary>
[DataContract(Name = "DayBar", Namespace = "TradingPlatform")]
[ProtoContract]
[Published]
public class DayBar : MessageQuote, IXElementSerialization
{
  [NotPublished]
  public override MessageType Type => MessageType.DayBar;

  /// <summary>High price</summary>
  [DataMember(Name = "High")]
  [ProtoMember(1)]
  public double High { get; set; }

  /// <summary>Open price</summary>
  [DataMember(Name = "Open")]
  [ProtoMember(2)]
  public double Open { get; set; }

  /// <summary>Low price</summary>
  [DataMember(Name = "Low")]
  [ProtoMember(3)]
  public double Low { get; set; }

  /// <summary>Previous Close price</summary>
  [DataMember(Name = "PreviousClose")]
  [ProtoMember(4)]
  public double PreviousClose { get; set; }

  /// <summary>Ticks value</summary>
  [DataMember(Name = "Ticks")]
  [ProtoMember(5)]
  public long Ticks { get; set; }

  /// <summary>Volume value</summary>
  [DataMember(Name = "Volume")]
  [ProtoMember(6)]
  public double Volume { get; set; }

  /// <summary>Volume value</summary>
  [DataMember(Name = "quoteAssetVolume")]
  [ProtoMember(7)]
  public double QuoteAssetVolume { get; set; }

  /// <summary>Previous settlement price</summary>
  [DataMember(Name = "PrevSettlementPrice")]
  [ProtoMember(8)]
  public double PrevSettlementPrice { get; set; }

  /// <summary>Bid price</summary>
  [DataMember(Name = "Bid")]
  [ProtoMember(9)]
  public double Bid { get; set; }

  /// <summary>Bid size</summary>
  [DataMember(Name = "BidSize")]
  [ProtoMember(10)]
  public double BidSize { get; set; }

  /// <summary>Ask price</summary>
  [DataMember(Name = "Ask")]
  [ProtoMember(11)]
  public double Ask { get; set; }

  /// <summary>Ask size</summary>
  [DataMember(Name = "AskSize")]
  [ProtoMember(12)]
  public double AskSize { get; set; }

  /// <summary>Last price</summary>
  [DataMember(Name = "Last")]
  [ProtoMember(13)]
  public double Last { get; set; }

  /// <summary>Last size</summary>
  [DataMember(Name = "LastSize")]
  [ProtoMember(14)]
  public double LastSize { get; set; }

  /// <summary>Trades value</summary>
  [DataMember(Name = "Trades")]
  [ProtoMember(15)]
  public long Trades { get; set; }

  /// <summary>Change value</summary>
  [DataMember(Name = "Change")]
  [ProtoMember(16 /*0x10*/)]
  public double Change { get; set; }

  /// <summary>Change value in percentage</summary>
  [DataMember(Name = "ChangePercentage")]
  [ProtoMember(17)]
  public double ChangePercentage { get; set; }

  /// <summary>
  /// 
  /// </summary>
  [DataMember(Name = "OpenInterest")]
  [ProtoMember(18)]
  public double OpenInterest { get; set; }

  [DataMember(Name = "TopPriceLimit")]
  [ProtoMember(19)]
  public double TopPriceLimit { get; set; }

  [DataMember(Name = "BottomPriceLimit")]
  [ProtoMember(20)]
  public double BottomPriceLimit { get; set; }

  [DataMember(Name = "AverageTradedPrice")]
  [ProtoMember(21)]
  public double AverageTradedPrice { get; set; }

  [DataMember(Name = "TotalBuyQuantity")]
  [ProtoMember(22)]
  public double TotalBuyQuantity { get; set; }

  [DataMember(Name = "TotalSellQuantity")]
  [ProtoMember(23)]
  public double TotalSellQuantity { get; set; }

  [DataMember(Name = "IV")]
  [ProtoMember(24)]
  public double IV { get; set; }

  [DataMember(Name = "Delta")]
  [ProtoMember(25)]
  public double Delta { get; set; }

  [DataMember(Name = "Vega")]
  [ProtoMember(26)]
  public double Vega { get; set; }

  [DataMember(Name = "Gamma")]
  [ProtoMember(27)]
  public double Gamma { get; set; }

  [DataMember(Name = "Theta")]
  [ProtoMember(28)]
  public double Theta { get; set; }

  [DataMember(Name = "Rho")]
  [ProtoMember(29)]
  public double Rho { get; set; }

  [DataMember(Name = "Mark")]
  [ProtoMember(30)]
  public double Mark { get; set; }

  [DataMember(Name = "MarkSize")]
  [ProtoMember(31 /*0x1F*/)]
  public double MarkSize { get; set; }

  [DataMember(Name = "FundingRate")]
  [ProtoMember(32 /*0x20*/)]
  public double FundingRate { get; set; }

  internal bool FullRefresh { get; [param: In] set; }

  private DayBar()
  {
  }

  [NotPublished]
  public DayBar(string symbolId, DateTime time)
    : base(symbolId, time)
  {
    this.High = double.NaN;
    this.Open = double.NaN;
    this.Low = double.NaN;
    this.PreviousClose = double.NaN;
    this.Ticks = -1L;
    this.Volume = double.NaN;
    this.QuoteAssetVolume = double.NaN;
    this.PrevSettlementPrice = double.NaN;
    this.Bid = double.NaN;
    this.BidSize = double.NaN;
    this.Ask = double.NaN;
    this.AskSize = double.NaN;
    this.Last = double.NaN;
    this.LastSize = double.NaN;
    this.Mark = double.NaN;
    this.Trades = -1L;
    this.Change = double.NaN;
    this.ChangePercentage = double.NaN;
    this.OpenInterest = double.NaN;
    this.TopPriceLimit = double.NaN;
    this.BottomPriceLimit = double.NaN;
    this.AverageTradedPrice = double.NaN;
    this.TotalBuyQuantity = double.NaN;
    this.TotalSellQuantity = double.NaN;
    this.IV = double.NaN;
    this.Delta = double.NaN;
    this.Vega = double.NaN;
    this.Gamma = double.NaN;
    this.Theta = double.NaN;
    this.Rho = double.NaN;
    this.FundingRate = double.NaN;
  }

  [NotPublished]
  public XElement ToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픸());
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픀(), (object) this.SymbolId));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓱(), (object) this.Ask));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙프(), (object) this.AskSize));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓨(), (object) this.Bid));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픴(), (object) this.BidSize));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣핌(), (object) this.Last));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픑(), (object) this.LastSize));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓩()), (object) this.Mark);
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픿(), (object) this.Open));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓔(), (object) this.High));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픢(), (object) this.Low));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓝(), (object) this.PreviousClose));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓦(), (object) this.Ticks));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓶(), (object) this.Trades));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.피(), (object) this.Volume));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓽(), (object) this.QuoteAssetVolume));
    return xelement;
  }

  [NotPublished]
  public void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    XElement xelement = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픀());
    if (xelement != null)
      this.SymbolId = xelement.Value;
    XElement element1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓱());
    if (element1 != null)
      this.Ask = element1.ToDouble();
    XElement element2 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙프());
    if (element2 != null)
      this.AskSize = element2.ToDouble();
    XElement element3 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓨());
    if (element3 != null)
      this.Bid = element3.ToDouble();
    XElement element4 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픴());
    if (element4 != null)
      this.BidSize = element4.ToDouble();
    XElement element5 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣핌());
    if (element5 != null)
      this.Last = element5.ToDouble();
    XElement element6 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픑());
    if (element6 != null)
      this.LastSize = element6.ToDouble();
    XElement element7 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓩());
    if (element7 != null)
      this.Mark = element7.ToDouble();
    XElement element8 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픿());
    if (element8 != null)
      this.Open = element8.ToDouble();
    XElement element9 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓔());
    if (element9 != null)
      this.High = element9.ToDouble();
    XElement element10 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픢());
    if (element10 != null)
      this.Low = element10.ToDouble();
    XElement element11 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓝());
    if (element11 != null)
      this.PreviousClose = element11.ToDouble();
    XElement element12 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓦());
    if (element12 != null)
      this.Ticks = element12.ToLong();
    XElement element13 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓶());
    if (element13 != null)
      this.Trades = element13.ToLong();
    XElement element14 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.피());
    if (element14 != null)
      this.Volume = element14.ToDouble();
    XElement element15 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓽());
    if (element15 == null)
      return;
    this.QuoteAssetVolume = element15.ToDouble();
  }
}
