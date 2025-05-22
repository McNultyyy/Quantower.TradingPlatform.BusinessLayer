// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.MessageOpenOrder
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

[DataContract(Name = "OpenOrder", Namespace = "TradingPlatform")]
[ProtoContract]
[ProtoInclude(23, typeof (MessageOrderHistory))]
public class MessageOpenOrder : Message, INeedSymbolToPocess, IXElementSerialization
{
  public override MessageType Type => MessageType.OpenOrder;

  internal MessageOpenOrder()
  {
    this.Price = double.NaN;
    this.TriggerPrice = double.NaN;
    this.TrailOffset = double.NaN;
    this.AverageFillPrice = double.NaN;
    this.StopLossItems = new List<SlTpHolder>();
    this.TakeProfitItems = new List<SlTpHolder>();
  }

  public MessageOpenOrder(string symbolId)
    : this()
  {
    this.SymbolId = symbolId;
  }

  [DataMember(Name = "OrderId")]
  [ProtoMember(1)]
  public string OrderId { get; set; }

  [DataMember(Name = "GroupId")]
  [ProtoMember(2)]
  public string GroupId { get; set; }

  [DataMember(Name = "PositionId")]
  [ProtoMember(3)]
  public string PositionId { get; set; }

  [DataMember(Name = "AccountId")]
  [ProtoMember(4)]
  public string AccountId { get; set; }

  [DataMember(Name = "TotalQuantity")]
  [ProtoMember(5)]
  public double TotalQuantity { get; set; }

  [DataMember(Name = "FilledQuantity")]
  [ProtoMember(6)]
  public double FilledQuantity { get; set; }

  [DataMember(Name = "Side")]
  [ProtoMember(7)]
  public Side Side { get; set; }

  [DataMember(Name = "Comment")]
  [ProtoMember(8)]
  public string Comment { get; set; }

  [DataMember(Name = "LastUpdateTime")]
  [ProtoMember(9)]
  public DateTime LastUpdateTime { get; set; }

  [DataMember(Name = "InstrumentSymbol")]
  [ProtoMember(10)]
  public string SymbolId { get; [param: In] private set; }

  [DataMember(Name = "OrderTypeId")]
  [ProtoMember(11)]
  public string OrderTypeId { get; set; }

  [DataMember(Name = "Tif")]
  [ProtoMember(12)]
  public TimeInForce TimeInForce { get; set; }

  [DataMember(Name = "ExpirationTime")]
  [ProtoMember(13)]
  public DateTime ExpirationTime { get; set; }

  [DataMember(Name = "Price")]
  [ProtoMember(14)]
  public double Price { get; set; }

  [DataMember(Name = "TriggerPrice")]
  [ProtoMember(15)]
  public double TriggerPrice { get; set; }

  [DataMember(Name = "TrailOffset")]
  [ProtoMember(16 /*0x10*/)]
  public double TrailOffset { get; set; }

  [DataMember(Name = "Status")]
  [ProtoMember(17)]
  public OrderStatus Status { get; set; }

  [DataMember(Name = "OriginalStatus")]
  [ProtoMember(18)]
  public string OriginalStatus { get; set; }

  [DataMember(Name = "AverageFillPrice")]
  [ProtoMember(19)]
  public double AverageFillPrice { get; set; }

  public SlTpHolder StopLoss
  {
    get => this.StopLossItems.FirstOrDefault<SlTpHolder>();
    set
    {
      if (value == null)
        this.StopLossItems.Clear();
      else if (this.StopLossItems.Any<SlTpHolder>())
        this.StopLossItems[0] = value;
      else
        this.StopLossItems.Add(value);
    }
  }

  public SlTpHolder TakeProfit
  {
    get => this.TakeProfitItems.FirstOrDefault<SlTpHolder>();
    set
    {
      if (value == null)
        this.TakeProfitItems.Clear();
      else if (this.TakeProfitItems.Any<SlTpHolder>())
        this.TakeProfitItems[0] = value;
      else
        this.TakeProfitItems.Add(value);
    }
  }

  [ProtoMember(20)]
  public List<SlTpHolder> StopLossItems { get; }

  [ProtoMember(21)]
  public List<SlTpHolder> TakeProfitItems { get; }

  [ProtoMember(22)]
  public List<AdditionalInfoItem> AdditionalInfoItems { get; set; }

  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(41, 6);
    interpolatedStringHandler.AppendFormatted<MessageType>(this.Type);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓧());
    interpolatedStringHandler.AppendFormatted(this.OrderId);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픓());
    interpolatedStringHandler.AppendFormatted(this.SymbolId);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픩());
    interpolatedStringHandler.AppendFormatted<double>(this.Price);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇필());
    interpolatedStringHandler.AppendFormatted<Side>(this.Side);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓖());
    interpolatedStringHandler.AppendFormatted(this.OrderTypeId);
    return interpolatedStringHandler.ToStringAndClear();
  }

  public string Format()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 8);
    interpolatedStringHandler.AppendFormatted(this.OrderId);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픆());
    interpolatedStringHandler.AppendFormatted(this.SymbolId);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픆());
    interpolatedStringHandler.AppendFormatted(this.AccountId);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픆());
    interpolatedStringHandler.AppendFormatted<Side>(this.Side);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픆());
    interpolatedStringHandler.AppendFormatted(this.OrderTypeId);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픆());
    interpolatedStringHandler.AppendFormatted<double>(this.FilledQuantity);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픉());
    interpolatedStringHandler.AppendFormatted<double>(this.TotalQuantity);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픆());
    interpolatedStringHandler.AppendFormatted<OrderStatus>(this.Status);
    return interpolatedStringHandler.ToStringAndClear();
  }

  public XElement ToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픵());
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픬(), (object) this.OrderId));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓕(), (object) this.GroupId));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픐(), (object) this.PositionId));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓼(), (object) this.AccountId));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픭(), (object) this.TotalQuantity));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픔(), (object) this.FilledQuantity));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇핈(), (object) this.Side));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픤(), (object) this.Comment));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓟(), (object) this.LastUpdateTime));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픀(), (object) this.SymbolId));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇핉(), (object) this.OrderTypeId));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇핊(), (object) (int) this.TimeInForce));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픛(), (object) this.ExpirationTime));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍핈(), (object) this.Price));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓜(), (object) this.TriggerPrice));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픺(), (object) this.TrailOffset));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픖(), (object) (int) this.Status));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇핃(), (object) this.OriginalStatus));
    XElement content = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓫());
    foreach (AdditionalInfoItem additionalInfoItem in this.AdditionalInfoItems)
      content.Add((object) additionalInfoItem.ToXElement());
    xelement.Add((object) content);
    return xelement;
  }

  public void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    XElement xelement1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픬());
    if (xelement1 != null)
      this.OrderId = xelement1.Value;
    XElement xelement2 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓕());
    if (xelement2 != null)
      this.GroupId = xelement2.Value;
    XElement xelement3 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픐());
    if (xelement3 != null)
      this.PositionId = xelement3.Value;
    XElement xelement4 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓼());
    if (xelement4 != null)
      this.AccountId = xelement4.Value;
    XElement element1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픭());
    if (element1 != null)
      this.TotalQuantity = element1.ToDouble();
    XElement element2 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픔());
    if (element2 != null)
      this.FilledQuantity = element2.ToDouble();
    XElement element3 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇핈());
    if (element3 != null)
      this.Side = (Side) element3.ToInt();
    XElement xelement5 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픤());
    if (xelement5 != null)
      this.Comment = xelement5.Value;
    XElement element4 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓟());
    if (element4 != null)
      this.LastUpdateTime = element4.ToDateTime(true);
    XElement xelement6 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픀());
    if (xelement6 != null)
      this.SymbolId = xelement6.Value;
    XElement xelement7 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇핉());
    if (xelement7 != null)
      this.OrderTypeId = xelement7.Value;
    XElement element5 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇핊());
    if (element5 != null)
      this.TimeInForce = (TimeInForce) element5.ToInt();
    XElement element6 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픛());
    if (element6 != null)
      this.ExpirationTime = element6.ToDateTime(true);
    XElement element7 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍핈());
    if (element7 != null)
      this.Price = element7.ToDouble();
    XElement element8 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓜());
    if (element8 != null)
      this.TriggerPrice = element8.ToDouble();
    XElement element9 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픺());
    if (element9 != null)
      this.TrailOffset = element9.ToDouble();
    XElement element10 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픖());
    if (element10 != null)
      this.Status = (OrderStatus) element10.ToInt();
    XElement xelement8 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇핃());
    if (xelement8 != null)
      this.OriginalStatus = xelement8.Value;
    XElement xelement9 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓫());
    if (xelement9 == null)
      return;
    List<AdditionalInfoItem> additionalInfoItemList = new List<AdditionalInfoItem>();
    foreach (XElement element11 in xelement9.Elements())
    {
      AdditionalInfoItem additionalInfoItem = new AdditionalInfoItem();
      additionalInfoItem.FromXElement(element11, deserializationInfo);
      additionalInfoItemList.Add(additionalInfoItem);
    }
    this.AdditionalInfoItems = additionalInfoItemList;
  }
}
