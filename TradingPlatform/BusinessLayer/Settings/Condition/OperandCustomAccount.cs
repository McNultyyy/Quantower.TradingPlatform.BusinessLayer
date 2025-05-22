// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Settings.Condition.OperandCustomAccount
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer.Settings.Condition;

public sealed class OperandCustomAccount : ConditionOperandBase
{
  public override string Name => \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓾();

  public override ConditionOperandBaseType ValueType => ConditionOperandBaseType.Account;

  public Account Value { get; set; }

  public OperandCustomAccount()
  {
  }

  public OperandCustomAccount(OperandCustomAccount operandCustomDate)
  {
    this.Value = operandCustomDate.Value;
  }

  public override void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    SymbolInfo empty = SymbolInfo.Empty;
    XElement element1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픍());
    if (element1 == null)
      return;
    empty.FromXElement(element1, deserializationInfo);
    if ((BusinessObjectInfo) empty == BusinessObjectInfo.Empty || empty == SymbolInfo.Empty)
      return;
    this.Value = Core.Instance.GetAccount((BusinessObjectInfo) empty);
  }

  public override XElement ToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓧());
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓼(), (object) this.GetType().Name));
    BusinessObjectInfo businessObjectInfo = this.Value?.CreateInfo();
    if ((object) businessObjectInfo == null)
      businessObjectInfo = BusinessObjectInfo.Empty;
    xelement.Add((object) businessObjectInfo.ToXElement());
    return xelement;
  }

  public override object Clone() => (object) new OperandCustomAccount(this);
}
