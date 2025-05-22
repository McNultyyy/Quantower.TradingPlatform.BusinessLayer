// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.MessageSymbol
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

[DataContract(Name = "Instrument", Namespace = "TradingPlatform")]
[ProtoContract]
public sealed class MessageSymbol : MessageSymbolInfo, IXElementSerialization, INeedSymbolToPocess
{
  public override MessageType Type => MessageType.Symbol;

  [DataMember(Name = "productID")]
  [ProtoMember(100)]
  public string ProductAssetId { get; set; }

  [DataMember(Name = "quotingCurrencyID")]
  [ProtoMember(105)]
  public string QuotingCurrencyAssetID { get; set; }

  [DataMember(Name = "quoteDelay")]
  [ProtoMember(110)]
  public TimeSpan QuoteDelay { get; set; }

  [DataMember(Name = "quotingType")]
  [ProtoMember(115)]
  public SymbolQuotingType QuotingType { get; set; }

  [DataMember(Name = "lotSize")]
  [ProtoMember(120)]
  public double LotSize { get; set; }

  [DataMember(Name = "instrumentAdditionalInfo")]
  [ProtoMember(130)]
  public List<AdditionalInfoItem> SymbolAdditionalInfo { get; set; }

  [DataMember(Name = "nettingType")]
  [ProtoMember(135)]
  public NettingType NettingType { get; set; }

  [DataMember(Name = "VolumeType")]
  [ProtoMember(145)]
  public SymbolVolumeType VolumeType { get; set; }

  [DataMember(Name = "allowCalculateRealtimeTicks")]
  [ProtoMember(150)]
  public bool AllowCalculateRealtimeTicks { get; set; }

  [DataMember(Name = "allowCalculateRealtimeTrades")]
  [ProtoMember(155)]
  public bool AllowCalculateRealtimeTrades { get; set; }

  [DataMember(Name = "allowCalculateRealtimeVolume")]
  [ProtoMember(160 /*0xA0*/)]
  public bool AllowCalculateRealtimeVolume { get; set; }

  [DataMember(Name = "allowCalculateRealtimeChange")]
  [ProtoMember(165)]
  public bool AllowCalculateRealtimeChange { get; set; }

  [DataMember(Name = "allowAbbreviatePriceByTickSize")]
  [ProtoMember(170)]
  public bool AllowAbbreviatePriceByTickSize { get; set; }

  [DataMember(Name = "notionalValueStep")]
  [ProtoMember(175)]
  public double NotionalValueStep { get; set; }

  [DataMember(Name = "deltaCalculationType")]
  [ProtoMember(180)]
  public DeltaCalculationType DeltaCalculationType { get; set; }

  [DataMember(Name = "minVolumeAnalysisTickSize")]
  [ProtoMember(183)]
  public double MinVolumeAnalysisTickSize { get; set; }

  [ProtoMember(185)]
  public DateTime MaturityDate { get; set; }

  string INeedSymbolToPocess.SymbolId => this.UnderlierId;

  [DataMember(Name = "SessionsContainerId")]
  [ProtoMember(186)]
  public string SessionsContainerId { get; set; }

  [DataMember(Name = "HistoryMetadata")]
  [ProtoMember(187)]
  public HistoryMetadata HistoryMetadata { get; set; }

  [ProtoMember(188)]
  public VolumeAnalysisMetadata VolumeAnalysisMetadata { get; set; }

  private MessageSymbol()
  {
  }

  public MessageSymbol(string symbolId)
    : base(symbolId)
  {
  }

  public MessageSymbol(MessageSymbol origin)
    : base((MessageSymbolInfo) origin)
  {
    this.ProductAssetId = origin.ProductAssetId;
    this.QuotingCurrencyAssetID = origin.QuotingCurrencyAssetID;
    this.QuoteDelay = origin.QuoteDelay;
    this.QuotingType = origin.QuotingType;
    this.LotSize = origin.LotSize;
    this.SymbolAdditionalInfo = origin.SymbolAdditionalInfo != null ? new List<AdditionalInfoItem>(origin.SymbolAdditionalInfo.Select<AdditionalInfoItem, AdditionalInfoItem>((Func<AdditionalInfoItem, AdditionalInfoItem>) (([In] obj0) => (AdditionalInfoItem) obj0.Clone()))) : (List<AdditionalInfoItem>) null;
    this.NettingType = origin.NettingType;
    this.GroupId = origin.GroupId;
    this.VolumeType = origin.VolumeType;
    this.AllowCalculateRealtimeTicks = origin.AllowCalculateRealtimeTicks;
    this.AllowCalculateRealtimeTrades = origin.AllowCalculateRealtimeTrades;
    this.AllowCalculateRealtimeVolume = origin.AllowCalculateRealtimeVolume;
    this.AllowCalculateRealtimeChange = origin.AllowCalculateRealtimeChange;
    this.AllowAbbreviatePriceByTickSize = origin.AllowAbbreviatePriceByTickSize;
    this.NotionalValueStep = origin.NotionalValueStep;
    this.DeltaCalculationType = origin.DeltaCalculationType;
    this.MinVolumeAnalysisTickSize = origin.MinVolumeAnalysisTickSize;
    this.MaturityDate = origin.MaturityDate;
    this.SessionsContainerId = origin.SessionsContainerId;
    this.HistoryMetadata = origin.HistoryMetadata;
    this.VolumeAnalysisMetadata = origin.VolumeAnalysisMetadata;
  }

  protected override void InitialState()
  {
    base.InitialState();
    this.NettingType = NettingType.Undefined;
    this.AllowCalculateRealtimeTicks = true;
    this.AllowCalculateRealtimeTrades = true;
    this.AllowCalculateRealtimeVolume = true;
    this.AllowCalculateRealtimeChange = true;
    this.AllowAbbreviatePriceByTickSize = false;
    this.LotSize = 1.0;
    this.NotionalValueStep = 1.0;
    this.MinVolumeAnalysisTickSize = double.NaN;
  }

  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(16 /*0x10*/, 3);
    interpolatedStringHandler.AppendFormatted<MessageType>(this.Type);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓧());
    interpolatedStringHandler.AppendFormatted(this.Id);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픓());
    interpolatedStringHandler.AppendFormatted(this.Name);
    return interpolatedStringHandler.ToStringAndClear();
  }

  public override XElement ToXElement()
  {
    XElement xelement = base.ToXElement();
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픦(), (object) this.ProductAssetId));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픍(), (object) this.QuotingCurrencyAssetID));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픆(), (object) this.QuoteDelay.ToString()));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픅(), (object) ((int) this.QuotingType).ToString()));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픠(), (object) this.LotSize));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓮(), (object) this.NotionalValueStep));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓐(), (object) ((int) this.NettingType).ToString()));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픕(), (object) ((int) this.HistoryType).ToString()));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픱(), (object) ((int) this.VolumeType).ToString()));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픶(), (object) ((int) this.DeltaCalculationType).ToString()));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픀(), (object) this.MinVolumeAnalysisTickSize));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픖(), (object) this.AllowCalculateRealtimeTicks));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓘(), (object) this.AllowCalculateRealtimeTrades));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픓(), (object) this.AllowCalculateRealtimeVolume));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픩(), (object) this.AllowCalculateRealtimeChange));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗필(), (object) this.AllowAbbreviatePriceByTickSize));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓖(), (object) this.MaturityDate));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픱(), (object) this.SessionsContainerId));
    if (this.FutureContractType.HasValue)
      xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픵(), (object) ((int) this.FutureContractType.Value).ToString()));
    return xelement;
  }

  public override void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    base.FromXElement(element, deserializationInfo);
    XElement xelement1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픦());
    if (xelement1 != null)
      this.ProductAssetId = xelement1.Value;
    XElement xelement2 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픍());
    if (xelement2 != null)
      this.QuotingCurrencyAssetID = xelement2.Value;
    XElement element1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픆());
    if (element1 != null)
      this.QuoteDelay = element1.ToTimeSpan();
    element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픬());
    XElement element2 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓐());
    if (element2 != null)
      this.NettingType = (NettingType) element2.ToInt();
    XElement element3 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픅());
    if (element3 != null)
      this.QuotingType = (SymbolQuotingType) element3.ToInt();
    XElement element4 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픠());
    if (element4 != null)
      this.LotSize = element4.ToDouble();
    XElement element5 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓮());
    if (element5 != null)
      this.NotionalValueStep = element5.ToDouble();
    XElement element6 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픕());
    if (element6 != null)
      this.HistoryType = (HistoryType) element6.ToInt();
    XElement element7 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픱());
    if (element7 != null)
      this.VolumeType = (SymbolVolumeType) element7.ToInt();
    XElement element8 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픶());
    if (element8 != null)
      this.DeltaCalculationType = (DeltaCalculationType) element8.ToInt();
    XElement element9 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픀());
    if (element9 != null)
      this.MinVolumeAnalysisTickSize = element9.ToDouble();
    XElement element10 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픖());
    if (element10 != null)
      this.AllowCalculateRealtimeTicks = element10.ToBool();
    XElement element11 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓘());
    if (element11 != null)
      this.AllowCalculateRealtimeTrades = element11.ToBool();
    XElement element12 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픓());
    if (element12 != null)
      this.AllowCalculateRealtimeVolume = element12.ToBool();
    XElement element13 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픩());
    if (element13 != null)
      this.AllowCalculateRealtimeChange = element13.ToBool();
    XElement element14 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗필());
    if (element14 != null)
      this.AllowAbbreviatePriceByTickSize = element14.ToBool();
    XElement element15 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓖());
    if (element15 != null)
      this.MaturityDate = element15.ToDateTime();
    XElement xelement3 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픱());
    if (xelement3 != null)
      this.SessionsContainerId = xelement3.Value;
    XElement element16 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픵());
    if (element16 == null)
      return;
    this.FutureContractType = new TradingPlatform.BusinessLayer.FutureContractType?((TradingPlatform.BusinessLayer.FutureContractType) element16.ToInt());
  }
}
