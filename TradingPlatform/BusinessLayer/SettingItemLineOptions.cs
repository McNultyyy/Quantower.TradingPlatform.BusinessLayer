// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemLineOptions
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[DataContract]
[Serializable]
public class SettingItemLineOptions : SettingItem
{
  public override SettingItemType Type => SettingItemType.LineOptions;

  public LineStyle[] ExcludedStyles { get; set; }

  public SettingItemLineOptions()
  {
  }

  public SettingItemLineOptions(string name, LineOptions value, int sortIndex = 0)
    : base(name, value?.Clone(), sortIndex)
  {
  }

  private SettingItemLineOptions([In] SettingItemLineOptions obj0)
    : base((SettingItem) obj0)
  {
    if (obj0.Value is ICloneable cloneable)
      this.value = (object) (cloneable.Clone() as LineOptions);
    this.ExcludedStyles = obj0.ExcludedStyles;
  }

  public override SettingItem GetCopy() => (SettingItem) new SettingItemLineOptions(this);

  protected override bool IsValueTypeValid(object value) => value is LineOptions;

  protected override object ValidateValue(object value)
  {
    LineOptions lineOptions = (LineOptions) value;
    LineStyle[] excludedStyles = this.ExcludedStyles;
    if ((excludedStyles != null ? (((IEnumerable<LineStyle>) excludedStyles).Contains<LineStyle>(lineOptions.LineStyle) ? 1 : 0) : 0) != 0)
      throw new ArgumentException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픧());
    return base.ValidateValue(value);
  }

  [DataMember(Name = "Value")]
  private LineOptions ValueColor
  {
    get => (LineOptions) this.Value;
    [param: In] set => this.Value = (object) value;
  }

  protected override void ValueFromXElement(
    XElement element,
    DeserializationInfo deserializationInfo)
  {
    LineOptions lineOptions = new LineOptions();
    XElement element1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픳());
    lineOptions.FromXElement(element1, deserializationInfo);
    this.ValueColor = lineOptions;
  }
}
