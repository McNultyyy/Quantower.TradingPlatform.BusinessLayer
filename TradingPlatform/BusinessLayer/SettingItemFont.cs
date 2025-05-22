// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemFont
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

[DataContract]
[KnownType(typeof (FontStyle))]
[KnownType(typeof (GraphicsUnit))]
[Serializable]
public sealed class SettingItemFont : SettingItem
{
  public bool UseGeneral;

  public override SettingItemType Type => SettingItemType.Font;

  public SettingItemFont()
  {
  }

  public SettingItemFont(string name, Font value, int sortIndex = 0)
    : base(name, (object) value, sortIndex)
  {
  }

  private SettingItemFont([In] SettingItemFont obj0)
    : base((SettingItem) obj0)
  {
  }

  public override SettingItem GetCopy() => (SettingItem) new SettingItemFont(this);

  public static implicit operator Font(SettingItemFont item) => item.Value as Font;

  protected override bool IsValueTypeValid(object value) => value is Font || value == null;

  [DataMember(Name = "Value")]
  private Font ValueFont
  {
    get => this.Value as Font;
    [param: In] set
    {
      if (value == null)
        return;
      this.Value = (object) value;
    }
  }

  protected override XElement ValueToXElement()
  {
    return this.ValueFont.ToXElement(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픦());
  }

  protected override void ValueFromXElement(
    XElement element,
    DeserializationInfo deserializationInfo)
  {
    XElement element1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픦());
    if (element1 == null)
      return;
    this.ValueFont = element1.ToFont();
  }
}
