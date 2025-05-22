// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.StrategyMetric
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using ProtoBuf;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[ProtoContract]
[Published]
public class StrategyMetric : IXElementSerialization
{
  [ProtoMember(1)]
  public string Name { get; set; }

  [ProtoMember(2)]
  public string FormattedValue { get; set; }

  public void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    XElement xelement1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픜());
    if (xelement1 != null)
      this.Name = xelement1.Value;
    XElement xelement2 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픰());
    if (xelement2 == null)
      return;
    this.FormattedValue = xelement2.Value;
  }

  public XElement ToXElement()
  {
    XElement xelement = new XElement((XName) this.GetType().Name);
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픜(), (object) this.Name));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픰(), (object) this.FormattedValue));
    return xelement;
  }
}
