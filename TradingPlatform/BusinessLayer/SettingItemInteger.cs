// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemInteger
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

/// <summary>Typecasts setting as NumericUpDown item</summary>
[Published]
[DataContract]
[ProtoContract]
[Serializable]
public sealed class SettingItemInteger : SettingItemNumber<int>
{
  public override SettingItemType Type => SettingItemType.Integer;

  public SettingItemInteger()
  {
  }

  public SettingItemInteger(string name, int value, int sortIndex = 0)
    : base(name, value, sortIndex)
  {
    this.Maximum = int.MaxValue;
    this.Minimum = int.MinValue;
    this.Increment = 1;
  }

  private SettingItemInteger([In] SettingItemInteger obj0)
    : base((SettingItemNumber<int>) obj0)
  {
  }

  [NotPublished]
  public override SettingItem GetCopy() => (SettingItem) new SettingItemInteger(this);

  [NotPublished]
  public static implicit operator int(SettingItemInteger item) => (int) item.Value;

  [NotPublished]
  protected override bool IsValueTypeValid(object value) => value is int;

  [NotPublished]
  protected override object ValidateValue(object value)
  {
    value = base.ValidateValue(value);
    int num = (int) value;
    if (num > this.Maximum)
      num = this.Maximum;
    else if (num < this.Minimum)
      num = this.Minimum;
    else if (this.Increment != 0)
      num -= num % this.Increment;
    return (object) num;
  }

  [DataMember(Name = "Value")]
  [ProtoMember(1)]
  private int ValueInt
  {
    get => (int) this.value;
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
    this.ValueInt = element1.ToInt();
  }
}
