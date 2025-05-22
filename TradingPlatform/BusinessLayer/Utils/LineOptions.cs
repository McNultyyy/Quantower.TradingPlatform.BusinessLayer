// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.LineOptions
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

[Serializable]
public class LineOptions : IXElementSerialization, ICloneable, IEquatable<LineOptions>
{
  public bool Enabled { get; set; }

  public bool WithCheckBox { get; set; } = true;

  public bool WithNumeric { get; set; } = true;

  public bool WithColor { get; set; } = true;

  public Font Font { get; set; }

  public int Width { get; set; }

  public int MaximumWidth { get; set; } = 10;

  public Color Color { get; set; }

  public LineStyle LineStyle { get; set; }

  public XElement ToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픳());
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픏(), (object) this.Enabled));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픙(), (object) this.WithCheckBox));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓭(), (object) this.WithNumeric));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓣(), (object) this.WithColor));
    xelement.Add((object) this.Font.ToXElement(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픦()));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픻(), (object) this.Width));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픍(), (object) this.MaximumWidth));
    xelement.Add((object) this.Color.ToXElement(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓛()));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픆(), (object) (int) this.LineStyle));
    return xelement;
  }

  public void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    this.Enabled = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픏()).ToBool();
    this.WithCheckBox = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픙()).ToBool();
    this.WithNumeric = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓭()).ToBool();
    this.WithColor = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓣()).ToBool();
    this.Font = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픦()).ToFont();
    this.Width = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픻()).ToInt();
    XElement element1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픍());
    if (element1 != null)
      this.MaximumWidth = element1.ToInt();
    this.Color = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓛()).ToColor();
    this.LineStyle = (LineStyle) element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픆()).ToInt();
  }

  public object Clone()
  {
    LineOptions lineOptions = new LineOptions()
    {
      Color = this.Color,
      Enabled = this.Enabled,
      LineStyle = this.LineStyle,
      Width = this.Width,
      WithCheckBox = this.WithCheckBox,
      WithColor = this.WithColor,
      WithNumeric = this.WithNumeric,
      MaximumWidth = this.MaximumWidth
    };
    if (this.Font != null)
      lineOptions.Font = (Font) this.Font.Clone();
    return (object) lineOptions;
  }

  public bool Equals(LineOptions other)
  {
    if (other == null)
      return false;
    if (this == other)
      return true;
    return this.Enabled == other.Enabled && this.WithCheckBox == other.WithCheckBox && this.WithNumeric == other.WithNumeric && this.WithColor == other.WithColor && object.Equals((object) this.Font, (object) other.Font) && this.Width == other.Width && this.MaximumWidth == other.MaximumWidth && this.Color.Equals(other.Color) && this.LineStyle == other.LineStyle;
  }

  public override bool Equals(object obj)
  {
    if (obj == null)
      return false;
    if (this == obj)
      return true;
    return !(obj.GetType() != this.GetType()) && this.Equals((LineOptions) obj);
  }

  public override int GetHashCode()
  {
    HashCode hashCode = new HashCode();
    hashCode.Add<bool>(this.Enabled);
    hashCode.Add<bool>(this.WithCheckBox);
    hashCode.Add<bool>(this.WithNumeric);
    hashCode.Add<bool>(this.WithColor);
    hashCode.Add<Font>(this.Font);
    hashCode.Add<int>(this.Width);
    hashCode.Add<int>(this.MaximumWidth);
    hashCode.Add<Color>(this.Color);
    hashCode.Add<int>((int) this.LineStyle);
    return hashCode.ToHashCode();
  }
}
