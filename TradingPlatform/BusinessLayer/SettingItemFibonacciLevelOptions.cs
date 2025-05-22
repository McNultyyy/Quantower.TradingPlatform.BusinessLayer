// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemFibonacciLevelOptions
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public class SettingItemFibonacciLevelOptions : SettingItem
{
  public override SettingItemType Type => SettingItemType.FibonacciLevelOptions;

  public Font DefaultFont { get; set; }

  public int DecimalPlaces { get; set; }

  public Decimal Increment { get; set; }

  public SettingItemFibonacciLevelOptions() => this.퓏();

  public SettingItemFibonacciLevelOptions(
    string name,
    List<FibonacciLevelOptions> value,
    int sortIndex = 0)
    : base(name, (object) value, sortIndex)
  {
    this.퓏();
  }

  protected SettingItemFibonacciLevelOptions(SettingItemFibonacciLevelOptions settingItem)
    : base((SettingItem) settingItem)
  {
    this.퓏();
  }

  private void 퓏()
  {
    this.DecimalPlaces = 2;
    this.Increment = 0.01M;
  }

  public override SettingItem GetCopy() => (SettingItem) new SettingItemFibonacciLevelOptions(this);

  protected override bool IsValueTypeValid(object value) => value is List<FibonacciLevelOptions>;

  [DataMember(Name = "Value")]
  private List<FibonacciLevelOptions> ValuelevelOptions
  {
    get => this.Value as List<FibonacciLevelOptions>;
    [param: In] set => this.Value = (object) value;
  }

  protected override XElement ValueToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓰());
    foreach (FibonacciLevelOptions valuelevelOption in this.ValuelevelOptions)
      xelement.Add((object) valuelevelOption.ToXElement());
    return xelement;
  }

  protected override void ValueFromXElement(
    XElement element,
    DeserializationInfo deserializationInfo)
  {
    List<FibonacciLevelOptions> fibonacciLevelOptionsList = new List<FibonacciLevelOptions>();
    foreach (XElement element1 in element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓰()).Elements())
    {
      FibonacciLevelOptions fibonaccilevel = this.CreateFibonaccilevel();
      fibonaccilevel.FromXElement(element1, deserializationInfo);
      fibonacciLevelOptionsList.Add(fibonaccilevel);
    }
    this.Value = (object) fibonacciLevelOptionsList;
  }

  protected virtual FibonacciLevelOptions CreateFibonaccilevel() => new FibonacciLevelOptions();
}
