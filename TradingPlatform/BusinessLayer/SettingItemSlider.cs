// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemSlider
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using ProtoBuf;
using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using TradingPlatform.BusinessLayer.DataBinding;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[DataContract]
[ProtoContract]
[Serializable]
public class SettingItemSlider : SettingItem
{
  private ulong 퓞퓔;

  public override SettingItemType Type => SettingItemType.Slider;

  [Bindable("stepsCount")]
  public ulong StepsCount
  {
    get => this.퓞퓔;
    set
    {
      this.SetValue<ulong>(ref this.퓞퓔, value, propertyName: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓵());
    }
  }

  public SettingItemSlider()
  {
  }

  public SettingItemSlider(string name, ulong value, int sortIndex = 0)
    : base(name, (object) value, sortIndex)
  {
  }

  private SettingItemSlider([In] SettingItemSlider obj0)
    : base((SettingItem) obj0)
  {
    this.StepsCount = obj0.StepsCount;
  }

  [NotPublished]
  public static implicit operator ulong(SettingItemSlider item) => (ulong) item.Value;

  [NotPublished]
  public override SettingItem GetCopy() => (SettingItem) new SettingItemSlider(this);

  [NotPublished]
  protected override bool IsValueTypeValid(object value) => value is ulong;

  [NotPublished]
  protected override object ValidateValue(object value)
  {
    value = base.ValidateValue(value);
    return (object) Math.Min((ulong) value, this.StepsCount);
  }

  [DataMember(Name = "Value")]
  [ProtoMember(1)]
  private ulong ValueUlong
  {
    get => (ulong) this.Value;
    [param: In] set => this.Value = (object) value;
  }
}
