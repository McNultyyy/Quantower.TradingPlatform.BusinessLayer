// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.PairColor
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
namespace TradingPlatform.BusinessLayer;

[Serializable]
public class PairColor : IXElementSerialization, IEquatable<PairColor>
{
  public Color Color1 { get; set; }

  public Color Color2 { get; set; }

  public string Text1 { get; set; }

  public string Text2 { get; set; }

  public PairColor()
  {
  }

  public PairColor(Color color1, Color color2, string text1 = null, string text2 = null)
  {
    this.Color1 = color1;
    this.Color2 = color2;
    this.Text1 = text1;
    this.Text2 = text2;
  }

  public XElement ToXElement()
  {
    return new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픾(), new object[2]
    {
      (object) this.Color1.ToXElement(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓍()),
      (object) this.Color2.ToXElement(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픁())
    });
  }

  public void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    XElement element1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓍());
    if (element1 != null)
      this.Color1 = element1.ToColor();
    XElement element2 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픁());
    if (element2 == null)
      return;
    this.Color2 = element2.ToColor();
  }

  public bool Equals(PairColor other)
  {
    if (other == null)
      return false;
    if (this == other)
      return true;
    Color color = this.Color1;
    if (color.Equals(other.Color1))
    {
      color = this.Color2;
      if (color.Equals(other.Color2) && this.Text1 == other.Text1)
        return this.Text2 == other.Text2;
    }
    return false;
  }

  public override bool Equals(object obj)
  {
    if (obj == null)
      return false;
    if (this == obj)
      return true;
    return !(obj.GetType() != this.GetType()) && this.Equals((PairColor) obj);
  }

  public override int GetHashCode()
  {
    return HashCode.Combine<Color, Color, string, string>(this.Color1, this.Color2, this.Text1, this.Text2);
  }
}
