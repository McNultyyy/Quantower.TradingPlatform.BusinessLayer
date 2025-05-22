// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.FibonacciLevelOptions
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils;

public class FibonacciLevelOptions : ICloneable, IXElementSerialization
{
  public double Level { get; set; }

  public bool IsEnabled { get; set; }

  public bool UseCustom { get; set; }

  public Color CaptionFontColor { get; set; }

  public Font CaptionFont { get; set; }

  public ColorStyleWidth Line { get; set; }

  public int[] screenPoints { get; set; }

  public FibonacciLevelOptions()
  {
    this.UseCustom = false;
    this.screenPoints = new int[4];
  }

  public FibonacciLevelOptions(double level)
    : this()
  {
    this.Level = level;
  }

  public virtual FibonacciLevelOptions Clone()
  {
    return new FibonacciLevelOptions()
    {
      UseCustom = this.UseCustom,
      IsEnabled = this.IsEnabled,
      Line = this.Line.Clone() as ColorStyleWidth,
      CaptionFontColor = this.CaptionFontColor,
      CaptionFont = this.CaptionFont,
      Level = this.Level
    };
  }

  object ICloneable.퓏() => (object) this.Clone();

  public virtual XElement ToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓾());
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓐(), (object) this.Level));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픚(), (object) this.UseCustom));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓵(), (object) this.IsEnabled));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁플(), (object) this.CaptionFontColor.ToArgb()));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픥(), (object) this.CaptionFont.FontFamily.Name));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓼(), (object) this.CaptionFont.Size));
    xelement.Add((object) this.Line.ToXElement());
    foreach (int screenPoint in this.screenPoints)
      xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓴(), (object) screenPoint));
    return xelement;
  }

  public virtual void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    this.Level = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓐()).ToDouble();
    this.UseCustom = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픚()).ToBool();
    this.IsEnabled = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓵()).ToBool();
    this.CaptionFontColor = Color.FromArgb(element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁플()).ToInt());
    this.CaptionFont = new Font(element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픥()).Value.ToString(), (float) element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓼()).ToDouble(), GraphicsUnit.Pixel);
    this.Line = new ColorStyleWidth();
    this.Line.FromXElement(element, deserializationInfo);
    List<int> intList = new List<int>();
    foreach (XElement element1 in element.Elements((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓴()))
      intList.Add(element1.ToInt());
    this.screenPoints = intList.ToArray();
  }
}
