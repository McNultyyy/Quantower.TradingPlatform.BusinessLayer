// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemColor
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>Typecasts setting as Color item</summary>
[Published]
[DataContract]
[Serializable]
public sealed class SettingItemColor : SettingItem
{
  public override SettingItemType Type => SettingItemType.Color;

  public string ColorText { get; set; }

  public bool Checked { get; set; }

  public bool WithCheckBox { get; set; }

  public bool AllowDisableColor { get; set; }

  public SettingItemColor()
  {
  }

  public SettingItemColor(string name, Color value, int sortIndex = 0)
    : base(name, (object) value, sortIndex)
  {
  }

  private SettingItemColor([In] SettingItemColor obj0)
    : base((SettingItem) obj0)
  {
    this.ColorText = obj0.ColorText;
    this.Checked = obj0.Checked;
    this.WithCheckBox = obj0.WithCheckBox;
    this.AllowDisableColor = obj0.AllowDisableColor;
  }

  [NotPublished]
  public override SettingItem GetCopy() => (SettingItem) new SettingItemColor(this);

  [NotPublished]
  public static implicit operator Color(SettingItemColor item) => (Color) item.Value;

  [NotPublished]
  protected override bool IsValueTypeValid(object value) => value is Color;

  [DataMember(Name = "Value")]
  private Color ValueColor
  {
    get => (Color) this.Value;
    [param: In] set => this.Value = (object) value;
  }

  [NotPublished]
  protected override XElement ValueToXElement()
  {
    return this.ValueColor.ToXElement(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓛());
  }

  [NotPublished]
  protected override void ValueFromXElement(
    XElement element,
    DeserializationInfo deserializationInfo)
  {
    XElement element1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓛());
    if (element1 == null)
      return;
    this.ValueColor = element1.ToColor();
  }

  [NotPublished]
  public override void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    base.FromXElement(element, deserializationInfo);
    XElement element1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픙());
    if (element1 != null)
      this.WithCheckBox = element1.ToBool();
    XElement element2 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓪());
    if (element2 != null)
      this.Checked = element2.ToBool();
    XElement element3 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픪());
    if (element3 == null)
      return;
    this.AllowDisableColor = element3.ToBool();
  }

  [NotPublished]
  public override XElement ToXElement()
  {
    XElement xelement = base.ToXElement();
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓪(), (object) this.Checked));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픙(), (object) this.WithCheckBox));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픪(), (object) this.AllowDisableColor));
    return xelement;
  }
}
