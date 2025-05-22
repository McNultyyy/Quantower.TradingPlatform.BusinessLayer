// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemSelector
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using TradingPlatform.BusinessLayer.DataBinding;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>Typecasts setting as ComboBox item</summary>
[Published]
[DataContract]
[ProtoContract]
[Serializable]
public sealed class SettingItemSelector : SettingItem
{
  private IEnumerable<string> 퓞픑;

  public override SettingItemType Type => SettingItemType.Selector;

  [Bindable("items")]
  public IEnumerable<string> Items
  {
    get => this.퓞픑;
    set
    {
      this.SetValue<IEnumerable<string>>(ref this.퓞픑, value, propertyName: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픚());
    }
  }

  public SettingItemSelector()
  {
  }

  public SettingItemSelector(string name, string value, IEnumerable<string> items, int sortIndex = 0)
    : base(name, (object) value, sortIndex)
  {
    this.Items = items;
  }

  private SettingItemSelector([In] SettingItemSelector obj0)
    : base((SettingItem) obj0)
  {
    this.Items = obj0.Items;
  }

  [NotPublished]
  public override SettingItem GetCopy() => (SettingItem) new SettingItemSelector(this);

  [NotPublished]
  public static implicit operator string(SettingItemSelector item) => item.Value as string;

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
