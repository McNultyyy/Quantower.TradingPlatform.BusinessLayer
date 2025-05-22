// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.ColorStyleWidth
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Drawing;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils;

public sealed class ColorStyleWidth : IXElementSerialization, ICloneable
{
  public Color Color;
  public LineStyle Style;
  public int Width;
  public bool DisableColor;
  public bool DisableStyle;
  public bool DisableWidth;
  public bool CheckBoxVisible;
  public bool Checked;
  public bool AllLineStyles;

  public ColorStyleWidth()
  {
    this.Width = 1;
    this.Checked = true;
  }

  public ColorStyleWidth(Color color, LineStyle Style, int Width)
    : this()
  {
    this.Color = color;
    this.Style = Style;
    this.Width = Width;
  }

  public void ApplyFromClone(ColorStyleWidth clone)
  {
    this.Color = Color.FromArgb(clone.Color.ToArgb());
    this.Style = clone.Style;
    this.Width = clone.Width;
  }

  public XElement ToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓹());
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓛(), (object) this.Color.ToArgb()));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픝(), (object) (int) this.Style));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픻(), (object) this.Width));
    return xelement;
  }

  public void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    XElement xelement = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓹());
    this.Color = Color.FromArgb(xelement.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓛()).ToInt());
    this.Style = (LineStyle) xelement.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픝()).ToInt();
    this.Width = xelement.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픻()).ToInt();
  }

  public object Clone()
  {
    return (object) new ColorStyleWidth()
    {
      AllLineStyles = this.AllLineStyles,
      CheckBoxVisible = this.CheckBoxVisible,
      Checked = this.Checked,
      Color = this.Color,
      DisableColor = this.DisableColor,
      DisableStyle = this.DisableStyle,
      DisableWidth = this.DisableWidth,
      Style = this.Style,
      Width = this.Width
    };
  }
}
