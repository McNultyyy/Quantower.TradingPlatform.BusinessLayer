// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemBooleanLocalized
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[DataContract]
[Serializable]
public class SettingItemBooleanLocalized : SettingItemList
{
  public override SettingItemType Type => SettingItemType.BooleanLocalized;

  public SettingItemBooleanLocalized()
  {
  }

  public SettingItemBooleanLocalized(string name, IList<SettingItem> items, int sortIndex = 0)
    : base(name, items, sortIndex)
  {
  }

  private SettingItemBooleanLocalized([In] SettingItemBooleanLocalized obj0)
    : base((SettingItemList) obj0)
  {
  }

  public override SettingItem GetCopy() => (SettingItem) new SettingItemBooleanLocalized(this);

  protected override bool IsValueTypeValid(object value)
  {
    return value is List<SettingItem> settingItemList && settingItemList.TrueForAll((Predicate<SettingItem>) (([In] obj0) => obj0 is SettingItemBoolean));
  }

  protected override XElement ValueToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픚());
    List<SettingItem> items = this.Items;
    for (int index = 0; index < items.Count; ++index)
      xelement.Add((object) items[index].ToXElement());
    return xelement;
  }

  protected override void ValueFromXElement(
    XElement element,
    DeserializationInfo deserializationInfo)
  {
    List<SettingItem> settingItemList = new List<SettingItem>();
    foreach (XElement element1 in element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픚()).Elements())
    {
      SettingItemBoolean settingItemBoolean = new SettingItemBoolean();
      settingItemBoolean.FromXElement(element1, deserializationInfo);
      settingItemList.Add((SettingItem) settingItemBoolean);
    }
    this.Items = settingItemList;
  }
}
