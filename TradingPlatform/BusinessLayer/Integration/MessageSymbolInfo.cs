// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.MessageSymbolInfo
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

[DataContract(Name = "Instrument", Namespace = "TradingPlatform")]
[ProtoContract]
[ProtoInclude(1000, typeof (MessageSymbol))]
public class MessageSymbolInfo : Message, IXElementSerialization
{
  public override MessageType Type => MessageType.SymbolInfo;

  [DataMember(Name = "id")]
  [ProtoMember(5)]
  public string Id { get; [param: In] internal set; }

  [DataMember(Name = "name")]
  [ProtoMember(10)]
  public string Name { get; set; }

  [DataMember(Name = "description")]
  [ProtoMember(15)]
  public string Description { get; set; }

  [DataMember(Name = "type")]
  [ProtoMember(20)]
  public SymbolType SymbolType { get; set; }

  [DataMember(Name = "ExchangeId")]
  [ProtoMember(25)]
  public string ExchangeId { get; set; }

  [DataMember(Name = "lotStep")]
  [ProtoMember(30)]
  public double LotStep { get; set; }

  [DataMember(Name = "minLot")]
  [ProtoMember(35)]
  public double MinLot { get; set; }

  [DataMember(Name = "maxLot")]
  [ProtoMember(40)]
  public double MaxLot { get; set; }

  [DataMember(Name = "underlierName")]
  [ProtoMember(45)]
  public string Root { get; set; }

  [DataMember(Name = "optionType")]
  [ProtoMember(50)]
  public OptionType OptionType { get; set; }

  [DataMember(Name = "strikePrice")]
  [ProtoMember(55)]
  public double StrikePrice { get; set; }

  [DataMember(Name = "expirationDate")]
  [ProtoMember(60)]
  public DateTime ExpirationDate { get; set; }

  [DataMember(Name = "HistoryType")]
  [ProtoMember(70)]
  public HistoryType HistoryType { get; set; }

  [DataMember(Name = "lastTradingDate")]
  [ProtoMember(80 /*0x50*/)]
  public DateTime LastTradingDate { get; set; }

  [DataMember(Name = "AvailableFutures")]
  [ProtoMember(85)]
  public AvailableDerivatives AvailableFutures { get; set; }

  [DataMember(Name = "AvailableOptions")]
  [ProtoMember(86)]
  public AvailableDerivatives AvailableOptions { get; set; }

  [DataMember(Name = "underlierId")]
  [ProtoMember(90)]
  public string UnderlierId { get; set; }

  [DataMember(Name = "optionSerieId")]
  [ProtoMember(95)]
  public string OptionSerieId { get; set; }

  [ProtoMember(96 /*0x60*/)]
  public string GroupId { get; set; }

  [ProtoMember(97)]
  public TradingPlatform.BusinessLayer.FutureContractType? FutureContractType { get; set; }

  [ProtoMember(98)]
  public string[] AvailableOptionsExchanges { get; set; }

  [DataMember(Name = "variableTickList")]
  [ProtoMember(125)]
  public List<VariableTick> VariableTickList { get; set; }

  protected MessageSymbolInfo() => this.InitialState();

  public MessageSymbolInfo(string symbolId)
    : this()
  {
    this.Id = symbolId;
  }

  public MessageSymbolInfo(MessageSymbolInfo origin)
    : this()
  {
    this.Fill(origin);
  }

  protected virtual void InitialState()
  {
    this.ExchangeId = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픿();
    this.AvailableFutures = AvailableDerivatives.None;
    this.AvailableOptions = AvailableDerivatives.None;
    this.MinLot = 1.0;
    this.MaxLot = (double) int.MaxValue;
    this.LotStep = 1.0;
  }

  public void Fill(MessageSymbolInfo messageSymbolInfo)
  {
    this.Id = messageSymbolInfo.Id;
    this.Name = messageSymbolInfo.Name;
    this.Description = messageSymbolInfo.Description;
    this.SymbolType = messageSymbolInfo.SymbolType;
    this.ExchangeId = messageSymbolInfo.ExchangeId;
    this.LotStep = messageSymbolInfo.LotStep;
    this.MinLot = messageSymbolInfo.MinLot;
    this.MaxLot = messageSymbolInfo.MaxLot;
    this.Root = messageSymbolInfo.Root;
    this.OptionType = messageSymbolInfo.OptionType;
    this.StrikePrice = messageSymbolInfo.StrikePrice;
    this.ExpirationDate = messageSymbolInfo.ExpirationDate;
    this.HistoryType = messageSymbolInfo.HistoryType;
    this.LastTradingDate = messageSymbolInfo.LastTradingDate;
    this.AvailableFutures = messageSymbolInfo.AvailableFutures;
    this.AvailableOptions = messageSymbolInfo.AvailableOptions;
    this.UnderlierId = messageSymbolInfo.UnderlierId;
    this.OptionSerieId = messageSymbolInfo.OptionSerieId;
    this.FutureContractType = messageSymbolInfo.FutureContractType;
    this.VariableTickList = messageSymbolInfo.VariableTickList != null ? new List<VariableTick>((IEnumerable<VariableTick>) messageSymbolInfo.VariableTickList) : (List<VariableTick>) null;
  }

  public virtual XElement ToXElement()
  {
    XElement xelement = new XElement((XName) this.GetType().Name);
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓶(), (object) this.Id));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픜(), (object) this.Name));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓵(), (object) this.Description));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓼(), (object) ((int) this.SymbolType).ToString()));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓮(), (object) this.ExchangeId));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픋(), (object) this.LotStep));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇핀(), (object) this.MinLot));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픲(), (object) this.MaxLot));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픽(), (object) this.Root));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓏(), (object) ((int) this.AvailableFutures).ToString()));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓬(), (object) ((int) this.AvailableOptions).ToString()));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픬(), (object) this.UnderlierId));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣핇(), (object) this.OptionSerieId));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓲(), (object) ((int) this.OptionType).ToString()));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣핂(), (object) this.StrikePrice));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓚(), (object) this.ExpirationDate));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픂(), (object) this.LastTradingDate));
    XElement content = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픾());
    if (this.VariableTickList != null && this.VariableTickList.Count > 0)
    {
      for (int index = 0; index < this.VariableTickList.Count; ++index)
        content.Add((object) this.VariableTickList[index].ToXElement());
    }
    xelement.Add((object) content);
    return xelement;
  }

  public virtual void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    XElement xelement1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓶());
    if (xelement1 != null)
      this.Id = xelement1.Value;
    XElement xelement2 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픜());
    if (xelement2 != null)
      this.Name = xelement2.Value;
    XElement xelement3 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓵());
    if (xelement3 != null)
      this.Description = xelement3.Value;
    XElement element1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓼());
    if (element1 != null)
      this.SymbolType = (SymbolType) element1.ToInt();
    XElement xelement4 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓮());
    if (xelement4 != null)
      this.ExchangeId = xelement4.Value;
    XElement element2 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픋());
    if (element2 != null)
      this.LotStep = element2.ToDouble();
    XElement element3 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픲());
    if (element3 != null)
      this.MaxLot = element3.ToDouble();
    XElement element4 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇핀());
    if (element4 != null)
      this.MinLot = element4.ToDouble();
    XElement xelement5 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픽());
    if (xelement5 != null)
      this.Root = xelement5.Value;
    XElement element5 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓏());
    if (element5 != null)
      this.AvailableFutures = (AvailableDerivatives) element5.ToInt();
    XElement element6 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓬());
    if (element6 != null)
      this.AvailableOptions = (AvailableDerivatives) element6.ToInt();
    XElement xelement6 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픬());
    if (xelement6 != null)
      this.UnderlierId = xelement6.Value;
    XElement xelement7 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣핇());
    if (xelement7 != null)
      this.OptionSerieId = xelement7.Value;
    XElement element7 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓲());
    if (element7 != null)
      this.OptionType = (OptionType) element7.ToInt();
    XElement element8 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣핂());
    if (element8 != null)
      this.StrikePrice = element8.ToDouble();
    XElement element9 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓚());
    if (element9 != null)
      this.ExpirationDate = element9.ToDateTime();
    XElement element10 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픂());
    if (element10 != null)
      this.LastTradingDate = element10.ToDateTime();
    XElement xelement8 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픾());
    if (xelement8 == null)
      return;
    List<VariableTick> variableTickList = new List<VariableTick>();
    foreach (XElement element11 in xelement8.Elements())
    {
      VariableTick variableTick = new VariableTick();
      variableTick.FromXElement(element11, deserializationInfo);
      variableTickList.Add(variableTick);
    }
    this.VariableTickList = variableTickList;
  }
}
