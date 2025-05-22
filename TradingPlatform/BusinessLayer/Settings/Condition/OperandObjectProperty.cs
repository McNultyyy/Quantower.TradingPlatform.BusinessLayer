// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Settings.Condition.OperandObjectProperty
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer.Settings.Condition;

public sealed class OperandObjectProperty : ConditionOperandBase
{
  private string 퓑퓝;
  private ConditionOperandBaseType 퓑퓶;

  public override string Name => this.퓑퓝;

  public override ConditionOperandBaseType ValueType => this.퓑퓶;

  public OperandObjectProperty()
  {
  }

  public OperandObjectProperty(string name, ConditionOperandBaseType valueType)
  {
    this.퓑퓝 = name;
    this.퓑퓶 = valueType;
  }

  public OperandObjectProperty(OperandObjectProperty operandCustomDate)
  {
    this.퓑퓝 = operandCustomDate.Name;
    this.퓑퓶 = operandCustomDate.ValueType;
  }

  public override void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    this.퓑퓝 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픜()).Value;
    this.퓑퓶 = (ConditionOperandBaseType) element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픫()).ToInt();
  }

  public override XElement ToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓧());
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓼(), (object) this.GetType().Name));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픜(), (object) this.Name));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픫(), (object) (int) this.ValueType));
    return xelement;
  }

  public override object Clone() => (object) new OperandObjectProperty(this);
}
