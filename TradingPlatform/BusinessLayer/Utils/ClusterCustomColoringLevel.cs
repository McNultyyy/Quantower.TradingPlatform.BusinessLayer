// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.ClusterCustomColoringLevel
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

public class ClusterCustomColoringLevel : 
  IXElementSerialization,
  IEquatable<ClusterCustomColoringLevel>
{
  public bool IsChecked { get; set; }

  public double Value { get; set; }

  public Color LeftColor { get; set; }

  public Color RightColor { get; set; }

  public string LeftColorLabel { get; set; }

  public string RightColorLabel { get; set; }

  public XElement ToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓓());
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픗(), (object) this.IsChecked));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓣(), (object) this.Value));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓰(), (object) this.LeftColor.ToArgb()));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픧(), (object) this.RightColor.ToArgb()));
    return xelement;
  }

  public void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    XElement xelement = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓓());
    if (xelement == null)
      return;
    this.Value = xelement.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓣()).ToDouble();
    this.IsChecked = xelement.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픗()).ToBool();
    this.LeftColor = Color.FromArgb(xelement.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓰()).ToInt());
    this.RightColor = Color.FromArgb(xelement.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픧()).ToInt());
  }

  public void UpdateLevel(ClusterCustomColoringLevel level)
  {
    this.IsChecked = level.IsChecked;
    this.Value = level.Value;
    this.LeftColor = level.LeftColor;
    this.RightColor = level.RightColor;
    if (!string.IsNullOrEmpty(level.LeftColorLabel))
      this.LeftColorLabel = level.LeftColorLabel;
    if (string.IsNullOrEmpty(level.RightColorLabel))
      return;
    this.RightColorLabel = level.RightColorLabel;
  }

  public bool Equals(ClusterCustomColoringLevel other)
  {
    if (other == null)
      return false;
    if (this == other)
      return true;
    if (this.IsChecked == other.IsChecked && this.Value.Equals(other.Value))
    {
      Color color = this.LeftColor;
      if (color.Equals(other.LeftColor))
      {
        color = this.RightColor;
        if (color.Equals(other.RightColor) && this.LeftColorLabel == other.LeftColorLabel)
          return this.RightColorLabel == other.RightColorLabel;
      }
    }
    return false;
  }

  public override bool Equals(object obj)
  {
    if (obj == null)
      return false;
    if (this == obj)
      return true;
    return !(obj.GetType() != this.GetType()) && this.Equals((ClusterCustomColoringLevel) obj);
  }

  public override int GetHashCode()
  {
    return HashCode.Combine<bool, double, Color, Color, string, string>(this.IsChecked, this.Value, this.LeftColor, this.RightColor, this.LeftColorLabel, this.RightColorLabel);
  }
}
