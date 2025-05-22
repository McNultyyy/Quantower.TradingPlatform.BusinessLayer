// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemNumber`1
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using TradingPlatform.BusinessLayer.DataBinding;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[KnownType(typeof (SettingItemDouble))]
[KnownType(typeof (SettingItemInteger))]
[KnownType(typeof (SettingItemLong))]
[ProtoInclude(1, typeof (SettingItemDouble))]
[ProtoInclude(2, typeof (SettingItemInteger))]
[ProtoInclude(3, typeof (SettingItemLong))]
[DataContract]
[ProtoContract]
[Serializable]
public abstract class SettingItemNumber<T> : SettingItem where T : struct
{
  private T 퓞퓥;
  private T 퓞퓯;
  private T 퓞픜;
  private string 퓞퓑;

  [Bindable("maximum")]
  public T Maximum
  {
    get => this.퓞퓥;
    set
    {
      this.SetValue<T>(ref this.퓞퓥, value, propertyName: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓹());
    }
  }

  [Bindable("minimum")]
  public T Minimum
  {
    get => this.퓞퓯;
    set
    {
      this.SetValue<T>(ref this.퓞퓯, value, propertyName: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓛());
    }
  }

  [Bindable("increment")]
  public T Increment
  {
    get => this.퓞픜;
    set
    {
      this.SetValue<T>(ref this.퓞픜, value, propertyName: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픝());
    }
  }

  [Bindable("dimension")]
  public string Dimension
  {
    get => this.퓞퓑;
    set
    {
      this.SetValue<string>(ref this.퓞퓑, value, propertyName: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픻());
    }
  }

  public bool UseTradingNumeric { get; set; }

  public SettingItemNumber()
  {
  }

  public SettingItemNumber(string name, T value, int sortIndex = 0)
    : base(name, (object) value, sortIndex)
  {
  }

  protected SettingItemNumber(SettingItemNumber<T> settingItem)
    : base((SettingItem) settingItem)
  {
    this.Maximum = settingItem.Maximum;
    this.Minimum = settingItem.Minimum;
    this.Increment = settingItem.Increment;
    this.Dimension = settingItem.Dimension;
    this.UseTradingNumeric = settingItem.UseTradingNumeric;
  }

  public override bool Equals(SettingItem other)
  {
    return base.Equals(other) && other is SettingItemNumber<T> settingItemNumber && EqualityComparer<T>.Default.Equals(this.Maximum, settingItemNumber.Maximum) && EqualityComparer<T>.Default.Equals(this.Minimum, settingItemNumber.Minimum) && EqualityComparer<T>.Default.Equals(this.Increment, settingItemNumber.Increment) && this.Dimension == settingItemNumber.Dimension && this.UseTradingNumeric == settingItemNumber.UseTradingNumeric;
  }

  public override int GetHashCode()
  {
    HashCode hashCode = new HashCode();
    hashCode.Add<int>(base.GetHashCode());
    hashCode.Add<T>(this.Maximum);
    hashCode.Add<T>(this.Minimum);
    hashCode.Add<T>(this.Increment);
    hashCode.Add<string>(this.Dimension);
    hashCode.Add<bool>(this.UseTradingNumeric);
    return hashCode.ToHashCode();
  }
}
