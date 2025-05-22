// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemString
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using ProtoBuf;
using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>Typecasts setting as TextBox item</summary>
[Published]
[DataContract]
[ProtoContract]
[Serializable]
public sealed class SettingItemString : SettingItem
{
  public override SettingItemType Type => SettingItemType.String;

  public bool ApplyOnEachInput { get; set; }

  public SettingItemString()
  {
  }

  public SettingItemString(string name, string value, int sortIndex = 0)
    : base(name, (object) value, sortIndex)
  {
  }

  private SettingItemString([In] SettingItemString obj0)
    : base((SettingItem) obj0)
  {
  }

  [NotPublished]
  public static implicit operator string(SettingItemString item) => item.Value as string;

  [NotPublished]
  public override SettingItem GetCopy() => (SettingItem) new SettingItemString(this);

  [NotPublished]
  protected override bool IsValueTypeValid(object value) => value is string;

  [DataMember(Name = "Value")]
  [ProtoMember(1)]
  private string ValueString
  {
    get => this.Value as string;
    [param: In] set => this.Value = (object) value;
  }
}
