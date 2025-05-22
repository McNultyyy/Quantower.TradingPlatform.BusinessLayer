// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Settings.Condition.ConditionItem
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Linq;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace TradingPlatform.BusinessLayer.Settings.Condition;

public sealed class ConditionItem : IXElementSerialization
{
  public ConditionOperandBase Operand1 { get; set; }

  public ConditionOperandBase Operand2 { get; set; }

  public TableConditionType ConditionType { get; set; }

  public ConditionItem()
  {
  }

  public ConditionItem(ConditionItem conditionItem)
  {
    this.ConditionType = conditionItem.ConditionType;
    this.Operand1 = conditionItem.Operand1?.Clone() as ConditionOperandBase;
    this.Operand2 = conditionItem.Operand2?.Clone() as ConditionOperandBase;
  }

  public void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    this.ConditionType = (TableConditionType) Enum.Parse(typeof (TableConditionType), element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픉()).Value.ToString());
    XElement xelement1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓜());
    if (xelement1 != null)
    {
      XElement element1 = xelement1.Elements().FirstOrDefault<XElement>();
      this.Operand1 = ConditionOperandBase.CreateFromXml(element1, deserializationInfo);
      this.Operand1.FromXElement(element1, deserializationInfo);
    }
    XElement xelement2 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픺());
    if (xelement2 == null)
      return;
    XElement element2 = xelement2.Elements().FirstOrDefault<XElement>();
    this.Operand2 = ConditionOperandBase.CreateFromXml(element2, deserializationInfo);
    this.Operand2.FromXElement(element2, deserializationInfo);
  }

  public XElement ToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픮());
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픉(), (object) this.ConditionType.ToString()));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓜(), (object) this.Operand1.ToXElement()));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픺(), (object) this.Operand2.ToXElement()));
    return xelement;
  }
}
