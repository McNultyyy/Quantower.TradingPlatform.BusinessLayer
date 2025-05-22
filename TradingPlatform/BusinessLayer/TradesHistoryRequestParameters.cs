// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.TradesHistoryRequestParameters
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using ProtoBuf;
using System;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[Published]
[ProtoContract]
public class TradesHistoryRequestParameters : 
  ProgressRequestParameters<float>,
  IXElementSerialization
{
  public override RequestType Type => RequestType.TradesHistory;

  public TradingPlatform.BusinessLayer.Utils.Interval<DateTime> Interval
  {
    get => new TradingPlatform.BusinessLayer.Utils.Interval<DateTime>(this.From, this.To);
  }

  [ProtoMember(1)]
  public DateTime From { get; set; }

  [ProtoMember(2)]
  public DateTime To { get; set; }

  [ProtoMember(3)]
  public string SymbolId { get; set; }

  [ProtoMember(4)]
  public bool ForceReload { get; set; }

  public XElement ToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓾());
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픫(), (object) this.From));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픯(), (object) this.To));
    if (!string.IsNullOrEmpty(this.SymbolId))
      xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞핂(), (object) this.SymbolId));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓐(), (object) this.ForceReload));
    return xelement;
  }

  public void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    XElement element1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픫());
    if (element1 != null)
      this.From = element1.ToDateTime(true);
    XElement element2 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픯());
    if (element2 != null)
      this.From = element2.ToDateTime(true);
    XElement xelement = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞핂());
    if (xelement != null)
      this.SymbolId = xelement.ToString();
    XElement element3 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓐());
    if (element3 == null)
      return;
    this.ForceReload = element3.ToBool();
  }

  public TradesHistoryRequestParameters()
  {
  }

  public TradesHistoryRequestParameters(TradesHistoryRequestParameters origin)
    : base((ProgressRequestParameters<float>) origin)
  {
    this.From = origin.From;
    this.To = origin.To;
    this.SymbolId = origin.SymbolId;
    this.ForceReload = origin.ForceReload;
  }
}
