// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemBooleanSwitcher
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using ProtoBuf;
using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>Typecasts setting as CheckBox item</summary>
[DataContract]
[Serializable]
public sealed class SettingItemBooleanSwitcher : SettingItem
{
  public override SettingItemType Type => SettingItemType.BooleanSwitcher;

  public SettingItemBooleanSwitcher()
  {
  }

  public SettingItemBooleanSwitcher(string name, bool value, int sortIndex = 0)
    : base(name, (object) value, sortIndex)
  {
  }

  private SettingItemBooleanSwitcher([In] SettingItemBooleanSwitcher obj0)
    : base((SettingItem) obj0)
  {
  }

  public override SettingItem GetCopy() => (SettingItem) new SettingItemBooleanSwitcher(this);

  public static implicit operator bool(SettingItemBooleanSwitcher item) => (bool) item.Value;

  protected override bool IsValueTypeValid(object value) => value is bool;

  [DataMember(Name = "Value")]
  [ProtoMember(1)]
  private bool ValueBool
  {
    get => (bool) this.value;
    [param: In] set => this.value = (object) value;
  }

  protected override void ValueFromXElement(
    XElement element,
    DeserializationInfo deserializationInfo)
  {
    XElement element1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓣());
    if (element1 == null)
      return;
    this.ValueBool = element1.ToBool();
  }
}
