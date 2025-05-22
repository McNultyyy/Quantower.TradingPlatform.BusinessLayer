// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemList
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using TradingPlatform.BusinessLayer.Utils.EqualityComparers;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[DataContract]
[Serializable]
public abstract class SettingItemList : SettingItem
{
  private static readonly ListEqualityComparer<SettingItem> 핋퓨 = new ListEqualityComparer<SettingItem>((IEqualityComparer<SettingItem>) EqualityComparer<SettingItem>.Default);

  protected SettingItemList(string name, IList<SettingItem> items, int sortIndex = 0)
    : base(name, (object) items, sortIndex)
  {
    if (items == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓝());
  }

  public SettingItemList()
  {
  }

  protected SettingItemList(SettingItemList settingItem)
    : base((SettingItem) settingItem)
  {
    this.Items = settingItem.CopyItems() as List<SettingItem>;
  }

  protected override bool IsValueTypeValid(object value) => value is IList<SettingItem>;

  protected IList<SettingItem> CopyItems()
  {
    List<SettingItem> settingItemList1 = new List<SettingItem>();
    if (this.Value is IList<SettingItem> settingItemList2)
    {
      foreach (SettingItem settingItem in (IEnumerable<SettingItem>) settingItemList2)
        settingItemList1.Add(settingItem.GetCopy());
    }
    return (IList<SettingItem>) settingItemList1;
  }

  [DataMember(Name = "Items")]
  protected virtual List<SettingItem> Items
  {
    get => this.Value as List<SettingItem>;
    set => this.Value = (object) value;
  }

  protected override bool ValueEquals(object other)
  {
    return SettingItemList.핋퓨.Equals((IList<SettingItem>) this.Items, other as IList<SettingItem>);
  }
}
