// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.ConditionItem
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils;

public class ConditionItem : IXElementSerialization
{
  public ColumnBaseInformation Column { get; set; }

  public TableConditionType ConditionType { get; set; }

  public object ConditionValue { get; set; }

  public ColumnBaseInformation Column2 { get; set; }

  public int Column1Offset { get; set; }

  public int Column2Offset { get; set; }

  public void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    ColumnBaseInformation columnBaseInformation1 = new ColumnBaseInformation();
    columnBaseInformation1.FromXElement(element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓤()), deserializationInfo);
    this.Column = columnBaseInformation1;
    this.ConditionType = (TableConditionType) Enum.Parse(typeof (TableConditionType), element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픉()).Value.ToString());
    this.ConditionValue = (object) element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픒()).Value.ToString();
    if (element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓷()) != null)
      this.Column1Offset = int.Parse(element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓷()).Value.ToString());
    if (element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓿()) != null)
      this.Column2Offset = int.Parse(element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓿()).Value.ToString());
    if (element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픟()) == null)
      return;
    ColumnBaseInformation columnBaseInformation2 = new ColumnBaseInformation();
    columnBaseInformation2.FromXElement(element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픟()), deserializationInfo);
    this.Column2 = columnBaseInformation2;
  }

  public XElement ToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픮());
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓤(), (object) this.Column.ToXElement()));
    if (this.Column2 != null)
      xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픟(), (object) this.Column2.ToXElement()));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픉(), (object) this.ConditionType.ToString()));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픒(), (object) this.ConditionValue?.ToString()));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓷(), (object) this.Column1Offset.ToString()));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓿(), (object) this.Column2Offset.ToString()));
    return xelement;
  }
}
