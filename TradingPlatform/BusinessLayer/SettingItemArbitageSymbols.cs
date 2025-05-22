// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemArbitageSymbols
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[DataContract]
[Serializable]
public class SettingItemArbitageSymbols : SettingItem
{
  [DataMember(Name = "Value")]
  private List<ArbitrageSymbol> ArbitrageSymbols
  {
    get => this.Value as List<ArbitrageSymbol>;
    [param: In] set => this.Value = (object) value;
  }

  public override SettingItemType Type => SettingItemType.ArbitageSymbols;

  public ArbitrageSymbol FirstArbitrageSymbol { get; set; }

  public Decimal BaseMaxTradingQuantity { get; set; }

  public Decimal QuotingMaxTradingQuantity { get; set; }

  public ArbitrageSymbol AddedSymbol { get; set; }

  public ArbitrageSymbol RemovedSymbol { get; set; }

  public ArbitrageSymbol ModifiedSymbol { get; set; }

  public SettingItemArbitageSymbols()
  {
  }

  public SettingItemArbitageSymbols(string name, List<ArbitrageSymbol> symbols, int sortIndex = 0)
    : base(name, (object) symbols, sortIndex)
  {
    this.BaseMaxTradingQuantity = 0M;
    this.QuotingMaxTradingQuantity = 0M;
  }

  private SettingItemArbitageSymbols([In] SettingItemArbitageSymbols obj0)
    : base((SettingItem) obj0)
  {
    this.BaseMaxTradingQuantity = obj0.BaseMaxTradingQuantity;
    this.QuotingMaxTradingQuantity = obj0.QuotingMaxTradingQuantity;
  }

  public override SettingItem GetCopy() => (SettingItem) new SettingItemArbitageSymbols(this);

  protected override bool IsValueTypeValid(object value) => value is List<ArbitrageSymbol>;

  public override void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    XElement element1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓽());
    if (element1 != null)
      this.BaseMaxTradingQuantity = element1.ToDecimal();
    XElement element2 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픘());
    if (element2 != null)
      this.QuotingMaxTradingQuantity = element2.ToDecimal();
    base.FromXElement(element, deserializationInfo);
  }

  protected override void ValueFromXElement(
    XElement element,
    DeserializationInfo deserializationInfo)
  {
    List<ArbitrageSymbol> arbitrageSymbolList = new List<ArbitrageSymbol>();
    IEnumerable<XElement> xelements = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픨()).Elements();
    if (xelements != null)
    {
      foreach (XElement element1 in xelements)
      {
        ArbitrageSymbol arbitrageSymbol = new ArbitrageSymbol();
        arbitrageSymbol.FromXElement(element1, deserializationInfo);
        arbitrageSymbolList.Add(arbitrageSymbol);
      }
    }
    this.Value = (object) arbitrageSymbolList;
    base.ValueFromXElement(element, deserializationInfo);
  }

  public override XElement ToXElement()
  {
    XElement xelement = base.ToXElement();
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓽(), (object) this.BaseMaxTradingQuantity));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픘(), (object) this.QuotingMaxTradingQuantity));
    return xelement;
  }

  protected override XElement ValueToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픨());
    foreach (ArbitrageSymbol arbitrageSymbol in this.ArbitrageSymbols)
      xelement.Add((object) arbitrageSymbol.ToXElement());
    return xelement;
  }
}
