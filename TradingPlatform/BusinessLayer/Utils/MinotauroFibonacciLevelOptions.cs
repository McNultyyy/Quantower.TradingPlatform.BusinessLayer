// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.MinotauroFibonacciLevelOptions
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System.Drawing;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils;

public class MinotauroFibonacciLevelOptions : FibonacciLevelOptions
{
  public bool ShowExtension { get; set; }

  public bool ShowExtensionLine { get; set; }

  public bool ShowBaseLevel { get; set; }

  public string BaseLevelText { get; set; }

  public double ExtensionLevel { get; set; }

  public Color ExtensionBackColor { get; set; }

  public Color ExtensionBorderColor { get; set; }

  public string ExtensionLabel { get; set; }

  public MinotauroFibonacciLevelOptions(double level)
    : base(level)
  {
    this.ShowBaseLevel = true;
    this.ShowExtensionLine = true;
  }

  public MinotauroFibonacciLevelOptions() => this.ShowExtensionLine = true;

  public override FibonacciLevelOptions Clone()
  {
    MinotauroFibonacciLevelOptions fibonacciLevelOptions = new MinotauroFibonacciLevelOptions();
    fibonacciLevelOptions.UseCustom = this.UseCustom;
    fibonacciLevelOptions.Line = this.Line;
    fibonacciLevelOptions.CaptionFontColor = this.CaptionFontColor;
    fibonacciLevelOptions.CaptionFont = this.CaptionFont;
    fibonacciLevelOptions.Level = this.Level;
    fibonacciLevelOptions.ShowExtension = this.ShowExtension;
    fibonacciLevelOptions.ShowExtensionLine = this.ShowExtensionLine;
    fibonacciLevelOptions.ShowBaseLevel = this.ShowBaseLevel;
    fibonacciLevelOptions.ExtensionLevel = this.ExtensionLevel;
    fibonacciLevelOptions.ExtensionBackColor = this.ExtensionBackColor;
    fibonacciLevelOptions.ExtensionBorderColor = this.ExtensionBorderColor;
    fibonacciLevelOptions.ExtensionLabel = this.ExtensionLabel;
    fibonacciLevelOptions.BaseLevelText = this.BaseLevelText;
    return (FibonacciLevelOptions) fibonacciLevelOptions;
  }

  public override XElement ToXElement()
  {
    XElement xelement = base.ToXElement();
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픗(), (object) this.ShowExtension));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓰(), (object) this.ShowExtensionLine));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픧(), (object) this.ShowBaseLevel));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓹(), (object) this.ExtensionLevel));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓛(), (object) this.ExtensionBackColor.ToArgb()));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픝(), (object) this.ExtensionBorderColor.ToArgb()));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픻(), (object) this.ExtensionLabel));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓤(), (object) this.BaseLevelText));
    return xelement;
  }

  public override void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    base.FromXElement(element, deserializationInfo);
    this.ShowExtension = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픗()).ToBool();
    this.ShowExtensionLine = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓰()).ToBool();
    this.ShowBaseLevel = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픧()).ToBool();
    this.ExtensionLevel = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓹()).ToDouble();
    this.ExtensionBackColor = Color.FromArgb(element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓛()).ToInt());
    this.ExtensionBorderColor = Color.FromArgb(element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픝()).ToInt());
    this.ExtensionLabel = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픻()).Value.ToString();
    this.BaseLevelText = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓤()).Value.ToString();
  }
}
