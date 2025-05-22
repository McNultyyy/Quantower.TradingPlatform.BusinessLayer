// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemAlignment
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
public class SettingItemAlignment : SettingItem
{
  public override SettingItemType Type => SettingItemType.Alignment;

  public SettingItemAlignment()
  {
  }

  public SettingItemAlignment(string name, NativeAlignment value, int sortIndex = 0)
    : base(name, (object) value, sortIndex)
  {
  }

  private SettingItemAlignment([In] SettingItemAlignment obj0)
    : base((SettingItem) obj0)
  {
  }

  public override SettingItem GetCopy() => (SettingItem) new SettingItemAlignment(this);

  protected override bool IsValueTypeValid(object value) => value is NativeAlignment;

  [DataMember(Name = "Value")]
  private NativeAlignment ValueAlignment
  {
    get => (NativeAlignment) this.Value;
    [param: In] set => this.Value = (object) value;
  }

  protected override XElement ValueToXElement()
  {
    return new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓣(), (object) (int) this.ValueAlignment);
  }

  protected override void ValueFromXElement(
    XElement element,
    DeserializationInfo deserializationInfo)
  {
    XElement element1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓣());
    if (element1 == null)
      return;
    this.ValueAlignment = (NativeAlignment) element1.ToInt();
  }
}
