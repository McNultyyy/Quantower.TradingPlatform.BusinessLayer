// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemBoolean
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
[Published]
[DataContract]
[Serializable]
public sealed class SettingItemBoolean : SettingItem
{
  public override SettingItemType Type => SettingItemType.Boolean;

  public SettingItemBoolean()
  {
  }

  public SettingItemBoolean(string name, bool value, int sortIndex = 0)
    : base(name, (object) value, sortIndex)
  {
  }

  private SettingItemBoolean([In] SettingItemBoolean obj0)
    : base((SettingItem) obj0)
  {
  }

  [NotPublished]
  public override SettingItem GetCopy() => (SettingItem) new SettingItemBoolean(this);

  [NotPublished]
  public static implicit operator bool(SettingItemBoolean item) => (bool) item.Value;

  [NotPublished]
  protected override bool IsValueTypeValid(object value) => value is bool;

  [DataMember(Name = "Value")]
  [ProtoMember(1, IsRequired = true)]
  private bool ValueBool
  {
    get => (bool) this.value;
    [param: In] set => this.value = (object) value;
  }

  [NotPublished]
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
