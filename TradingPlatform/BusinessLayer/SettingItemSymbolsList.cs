// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemSymbolsList
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
public class SettingItemSymbolsList : SettingItemList
{
  public override SettingItemType Type => SettingItemType.SymbolsList;

  public SettingItemSymbolsList(string name, IList<SettingItem> items, int sortIndex = 0)
    : base(name, (IList<SettingItem>) new List<SettingItem>(), sortIndex)
  {
    this.Value = (object) this.퓏(items);
  }

  public SettingItemSymbolsList()
  {
  }

  protected SettingItemSymbolsList(SettingItemSymbolsList settingItem)
    : base((SettingItemList) settingItem)
  {
  }

  public override SettingItem GetCopy() => (SettingItem) new SettingItemSymbolsList(this);

  [DataMember(Name = "Items")]
  protected override List<SettingItem> Items
  {
    get
    {
      List<SettingItem> items = new List<SettingItem>();
      foreach (SettingItemSymbol settingItemSymbol in this.Value as List<SettingItemSymbol>)
      {
        if (settingItemSymbol.Value is Symbol)
          items.Add((SettingItem) settingItemSymbol);
      }
      return items;
    }
    set => this.Value = (object) this.퓏((IList<SettingItem>) value);
  }

  private IList<SettingItem> 퓏([In] IList<SettingItem> obj0)
  {
    List<SettingItem> settingItemList = new List<SettingItem>();
    foreach (SettingItem settingItem in (IEnumerable<SettingItem>) obj0)
    {
      if (settingItem.Value is Symbol)
        settingItemList.Add(settingItem);
    }
    return (IList<SettingItem>) settingItemList;
  }

  protected override XElement ValueToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픚());
    foreach (SettingItem settingItem in this.Items)
      xelement.Add((object) settingItem.ToXElement());
    return xelement;
  }

  protected override void ValueFromXElement(
    XElement element,
    DeserializationInfo deserializationInfo)
  {
    List<SettingItem> settingItemList = new List<SettingItem>();
    XElement xelement = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픚());
    if (xelement != null)
    {
      foreach (XElement element1 in xelement.Elements())
      {
        SettingItemSymbol settingItemSymbol = new SettingItemSymbol();
        settingItemSymbol.FromXElement(element1, deserializationInfo);
        settingItemList.Add((SettingItem) settingItemSymbol);
      }
    }
    this.Items = settingItemList;
  }
}
