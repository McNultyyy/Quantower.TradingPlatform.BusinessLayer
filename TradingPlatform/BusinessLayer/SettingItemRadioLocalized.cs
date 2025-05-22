// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemRadioLocalized
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
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
[Serializable]
public sealed class SettingItemRadioLocalized : SettingItem
{
  private List<SelectItem> 퓞픴;

  public override SettingItemType Type => SettingItemType.RadioLocalized;

  [Bindable("items")]
  public List<SelectItem> Items
  {
    get => this.퓞픴;
    set
    {
      this.SetValue<List<SelectItem>>(ref this.퓞픴, value, propertyName: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픚());
    }
  }

  public SettingItemRadioLocalized()
  {
  }

  public SettingItemRadioLocalized(
    string name,
    SelectItem value,
    List<SelectItem> items,
    int sortIndex = 0)
    : base(name, (object) value, sortIndex)
  {
    this.Items = items;
  }

  private SettingItemRadioLocalized([In] SettingItemRadioLocalized obj0)
    : base((SettingItem) obj0)
  {
    this.Items = obj0.Items;
  }

  public override SettingItem GetCopy() => (SettingItem) new SettingItemRadioLocalized(this);

  public static implicit operator SelectItem(SettingItemRadioLocalized item)
  {
    return item.Value as SelectItem;
  }

  protected override bool IsValueTypeValid(object value) => value is SelectItem;

  internal override void 퓏([In] object obj0, bool _param2 = false)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    SettingItemRadioLocalized.퓏 퓏 = new SettingItemRadioLocalized.퓏();
    // ISSUE: reference to a compiler-generated field
    퓏.핅퓠 = obj0;
    // ISSUE: reference to a compiler-generated field
    if (!(퓏.핅퓠 is SelectItem))
    {
      List<SelectItem> items = this.Items;
      // ISSUE: reference to a compiler-generated method
      SelectItem selectItem = items != null ? items.FirstOrDefault<SelectItem>(new Func<SelectItem, bool>(퓏.퓏)) : (SelectItem) null;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      퓏.핅퓠 = (object) (selectItem ?? new SelectItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓥(), (IComparable) 퓏.핅퓠));
    }
    // ISSUE: reference to a compiler-generated field
    base.퓏(퓏.핅퓠, _param2);
  }

  [DataMember(Name = "Value")]
  private SelectItem SeletedItem
  {
    get => this.Value as SelectItem;
    [param: In] set => this.Value = (object) value;
  }

  protected override XElement ValueToXElement()
  {
    string empty = string.Empty;
    if (this.SeletedItem != null)
    {
      if (this.SeletedItem.Value is int num)
        empty = num.ToString();
      else if (this.SeletedItem.Value != null)
        empty = this.SeletedItem.Value.ToString();
    }
    return new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓣(), (object) empty);
  }

  protected override void ValueFromXElement(
    XElement element,
    DeserializationInfo deserializationInfo)
  {
    XElement xelement = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓣());
    if (xelement == null)
      return;
    int result;
    if (int.TryParse(xelement.Value, out result))
      this.SeletedItem = new SelectItem(string.Empty, result);
    else
      this.SeletedItem = new SelectItem(string.Empty, xelement.Value);
  }
}
