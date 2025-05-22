// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemPairColor
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[DataContract]
[Serializable]
public sealed class SettingItemPairColor : SettingItem
{
  public override SettingItemType Type => SettingItemType.PairColor;

  public bool Checked { get; set; }

  public bool WithCheckBox { get; set; }

  public bool AllowDisableColor1 { get; set; }

  public bool AllowDisableColor2 { get; set; }

  public SettingItemPairColor()
  {
  }

  public SettingItemPairColor(string name, PairColor value, int sortIndex = 0)
    : base(name, (object) value, sortIndex)
  {
  }

  private SettingItemPairColor([In] SettingItemPairColor obj0)
    : base((SettingItem) obj0)
  {
    this.Checked = obj0.Checked;
    this.WithCheckBox = obj0.WithCheckBox;
    this.AllowDisableColor1 = obj0.AllowDisableColor1;
    this.AllowDisableColor2 = obj0.AllowDisableColor2;
  }

  public override SettingItem GetCopy() => (SettingItem) new SettingItemPairColor(this);

  public static implicit operator PairColor(SettingItemPairColor item) => (PairColor) item.Value;

  protected override bool IsValueTypeValid(object value) => value is PairColor;

  [DataMember(Name = "Value")]
  private PairColor ValueColor
  {
    get => (PairColor) this.Value;
    [param: In] set => this.Value = (object) value;
  }

  protected override void ValueFromXElement(
    XElement element,
    DeserializationInfo deserializationInfo)
  {
    this.value = (object) new PairColor();
    this.ValueColor.FromXElement(element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픾()), deserializationInfo);
  }

  public override void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    base.FromXElement(element, deserializationInfo);
    XElement element1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픙());
    if (element1 != null)
      this.WithCheckBox = element1.ToBool();
    XElement element2 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓪());
    if (element2 != null)
      this.Checked = element2.ToBool();
    XElement element3 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓤());
    if (element3 != null)
      this.AllowDisableColor1 = element3.ToBool();
    XElement element4 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픮());
    if (element4 == null)
      return;
    this.AllowDisableColor2 = element4.ToBool();
  }

  public override XElement ToXElement()
  {
    XElement xelement = base.ToXElement();
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓪(), (object) this.Checked));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픙(), (object) this.WithCheckBox));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓤(), (object) this.AllowDisableColor1));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픮(), (object) this.AllowDisableColor2));
    return xelement;
  }
}
