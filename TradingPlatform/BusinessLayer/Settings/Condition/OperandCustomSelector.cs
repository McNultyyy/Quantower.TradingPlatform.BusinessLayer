// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Settings.Condition.OperandCustomSelector
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer.Settings.Condition;

public sealed class OperandCustomSelector : ConditionOperandBase
{
  public override string Name => \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓐();

  public override ConditionOperandBaseType ValueType => ConditionOperandBaseType.Selector;

  public SelectItem SelectedItem { get; set; }

  public OperandCustomSelector()
  {
  }

  public OperandCustomSelector(OperandCustomSelector operandCustomSelector)
  {
    this.SelectedItem = operandCustomSelector.SelectedItem;
  }

  public override void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    XElement xelement = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픚());
    if (xelement == null)
      return;
    string s = xelement.Value;
    int result;
    if (int.TryParse(s, out result))
      this.SelectedItem = new SelectItem(string.Empty, result);
    else
      this.SelectedItem = new SelectItem(string.Empty, s);
  }

  public override XElement ToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓧());
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓼(), (object) this.GetType().Name));
    string empty = string.Empty;
    if (this.SelectedItem == null)
      empty = string.Empty;
    else if (this.SelectedItem.Value is int || this.SelectedItem.Value is Enum)
      empty = ((int) this.SelectedItem.Value).ToString();
    else if (this.SelectedItem.Value != null)
      empty = this.SelectedItem.Value.ToString();
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픚(), (object) empty));
    return xelement;
  }

  public override object Clone() => (object) new OperandCustomSelector(this);
}
