// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemSelectorLocalized
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.DataBinding;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[DataContract]
[ProtoContract]
[Serializable]
public sealed class SettingItemSelectorLocalized : SettingItem
{
  private List<SelectItem> 퓞픿;

  public override SettingItemType Type => SettingItemType.SelectorLocalized;

  [Bindable("items")]
  public List<SelectItem> Items
  {
    get => this.퓞픿;
    set
    {
      this.SetValue<List<SelectItem>>(ref this.퓞픿, value, propertyName: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픚());
    }
  }

  public SettingItemSelectorLocalized()
  {
  }

  public SettingItemSelectorLocalized(
    string name,
    SelectItem value,
    List<SelectItem> items,
    int sortIndex = 0)
    : base(name, (object) value, sortIndex)
  {
    this.Items = items;
  }

  public SettingItemSelectorLocalized(
    string name,
    IComparable value,
    List<SelectItem> items,
    int sortIndex = 0)
    : this(name, items != null ? items.FirstOrDefault<SelectItem>(new Func<SelectItem, bool>(new SettingItemSelectorLocalized.핇()
    {
      핅픜 = value
    }.퓏)) : (SelectItem) null, items, sortIndex)
  {
    // ISSUE: reference to a compiler-generated method (out of statement scope)
    // ISSUE: object of a compiler-generated type is created (out of statement scope)
  }

  private SettingItemSelectorLocalized([In] SettingItemSelectorLocalized obj0)
    : base((SettingItem) obj0)
  {
    this.Items = obj0.Items;
  }

  public override SettingItem GetCopy() => (SettingItem) new SettingItemSelectorLocalized(this);

  public static implicit operator SelectItem(SettingItemSelectorLocalized item)
  {
    return item.Value as SelectItem;
  }

  protected override bool IsValueTypeValid(object value) => value is SelectItem;

  protected override object ValidateValue(object value)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    SettingItemSelectorLocalized.퓏 퓏 = new SettingItemSelectorLocalized.퓏();
    // ISSUE: reference to a compiler-generated field
    퓏.핅퓥 = value as SelectItem;
    // ISSUE: reference to a compiler-generated field
    if (퓏.핅퓥 == null)
      return this.Value;
    // ISSUE: reference to a compiler-generated method
    return this.Items == null || this.Items.Count == 0 || this.Items.Any<SelectItem>(new Func<SelectItem, bool>(퓏.퓏)) ? value : this.Value;
  }

  internal override void 퓏([In] object obj0, bool _param2 = false)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    SettingItemSelectorLocalized.퓬 퓬 = new SettingItemSelectorLocalized.퓬();
    // ISSUE: reference to a compiler-generated field
    퓬.핅퓯 = obj0;
    // ISSUE: reference to a compiler-generated field
    if (퓬.핅퓯 is SelectItem 핅퓯)
    {
      // ISSUE: reference to a compiler-generated field
      퓬.핅퓯 = (object) 핅퓯.Value;
    }
    List<SelectItem> items = this.Items;
    // ISSUE: reference to a compiler-generated method
    SelectItem selectItem = items != null ? items.FirstOrDefault<SelectItem>(new Func<SelectItem, bool>(퓬.퓏)) : (SelectItem) null;
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    퓬.핅퓯 = (object) (selectItem ?? new SelectItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓥(), (IComparable) 퓬.핅퓯));
    // ISSUE: reference to a compiler-generated field
    base.퓏(퓬.핅퓯, _param2);
  }

  internal override void 퓏([In] SettingItem obj0)
  {
    if (obj0 is SettingItemSelectorLocalized selectorLocalized && selectorLocalized.Items != null)
      this.Items = selectorLocalized.Items;
    base.퓏(obj0);
  }

  private SelectItem SeletedItem
  {
    get => this.Value as SelectItem;
    [param: In] set => this.Value = (object) value;
  }

  [DataMember(Name = "Value")]
  [ProtoMember(1)]
  private string SerializeValue
  {
    get
    {
      string empty = string.Empty;
      if (this.SeletedItem == null)
        return empty;
      if (this.SeletedItem.Value is int || this.SeletedItem.Value is Enum)
        empty = ((int) this.SeletedItem.Value).ToString();
      else if (this.SeletedItem.Value != null)
        empty = this.SeletedItem.Value.ToString();
      return empty;
    }
    [param: In] set
    {
      int result;
      if (int.TryParse(value, out result))
        this.SeletedItem = new SelectItem(string.Empty, result);
      else
        this.SeletedItem = new SelectItem(string.Empty, value);
    }
  }

  protected override XElement ValueToXElement()
  {
    return new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓣(), (object) this.SerializeValue);
  }

  protected override void ValueFromXElement(
    XElement element,
    DeserializationInfo deserializationInfo)
  {
    XElement xelement = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓣());
    if (xelement == null)
      return;
    this.SerializeValue = xelement.Value;
  }
}
