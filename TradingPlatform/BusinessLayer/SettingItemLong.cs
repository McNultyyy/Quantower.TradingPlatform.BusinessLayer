// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemLong
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

[Published]
[DataContract]
[ProtoContract]
[Serializable]
public sealed class SettingItemLong : SettingItemNumber<long>
{
  public override SettingItemType Type => SettingItemType.Long;

  public SettingItemLong()
  {
  }

  public SettingItemLong(string name, long value, int sortIndex = 0)
    : base(name, value, sortIndex)
  {
    this.Maximum = long.MaxValue;
    this.Minimum = long.MinValue;
    this.Increment = 1L;
  }

  private SettingItemLong([In] SettingItemLong obj0)
    : base((SettingItemNumber<long>) obj0)
  {
  }

  [NotPublished]
  public override SettingItem GetCopy() => (SettingItem) new SettingItemLong(this);

  [NotPublished]
  public static implicit operator long(SettingItemLong item) => (long) item.Value;

  [NotPublished]
  protected override bool IsValueTypeValid(object value) => value is long;

  [NotPublished]
  protected override object ValidateValue(object value)
  {
    value = base.ValidateValue(value);
    long num = (long) value;
    if (num > this.Maximum)
      num = this.Maximum;
    else if (num < this.Minimum)
      num = this.Minimum;
    else if (this.Increment != 0L)
      num -= num % this.Increment;
    return (object) num;
  }

  [DataMember(Name = "Value")]
  [ProtoMember(1)]
  private long ValueLong
  {
    get => (long) this.value;
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
    this.ValueLong = element1.ToLong();
  }
}
