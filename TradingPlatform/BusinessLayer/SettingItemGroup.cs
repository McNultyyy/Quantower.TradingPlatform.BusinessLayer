// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemGroup
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
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>Typecasts setting as TabControl item</summary>
[Published]
[DataContract]
[Serializable]
public sealed class SettingItemGroup : SettingItemList, ISettingsGroup
{
  public bool AllowCreateEmptyGroup;

  public override SettingItemType Type => SettingItemType.Group;

  public GroupActionInfo FirstActionInfo { get; set; }

  public GroupActionInfo SecondActionInfo { get; set; }

  string ISettingsGroup.Text => this.Text;

  int ISettingsGroup.SortIndex => this.SortIndex;

  ISettingsGroup ISettingsGroup.ParentGroup => (ISettingsGroup) this.Group;

  IList<ISettingsGroup> ISettingsGroup.ChildGroups
  {
    get
    {
      return (this.Value is IList<SettingItem> source ? (IList<ISettingsGroup>) source.OfType<ISettingsGroup>().ToList<ISettingsGroup>() : (IList<ISettingsGroup>) null) ?? (IList<ISettingsGroup>) new List<ISettingsGroup>();
    }
  }

  public SettingItemGroup()
    : base(string.Empty, (IList<SettingItem>) new List<SettingItem>())
  {
  }

  public SettingItemGroup(string name, IList<SettingItem> items, int sortIndex = 0)
    : base(name, items, sortIndex)
  {
    foreach (SettingItem settingItem in (IEnumerable<SettingItem>) items)
      this.퓬(settingItem);
  }

  [NotPublished]
  public override SettingItem GetCopy()
  {
    SettingItemGroup copy = new SettingItemGroup(this.Name, this.CopyItems(), this.SortIndex);
    copy.Text = this.Text;
    return (SettingItem) copy;
  }

  public void AddItem(SettingItem item)
  {
    this.Items.Add(item);
    this.퓬(item);
  }

  public override int GetHashCode() => SettingItemVisualGroup.퓏((ISettingsGroup) this);

  protected override List<SettingItem> Items
  {
    get => base.Items;
    set
    {
      if (value != null)
      {
        foreach (SettingItem settingItem in value)
          settingItem.Group = this;
      }
      base.Items = value;
    }
  }

  private void 퓬([In] SettingItem obj0) => obj0.Group = this;

  [NotPublished]
  public override XElement ToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁핋());
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픜(), (object) this.Name));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓼(), (object) this.GetType().Name));
    for (int index = 0; index < this.Items.Count; ++index)
    {
      try
      {
        xelement.Add((object) this.Items[index].ToXElement());
      }
      catch (Exception ex)
      {
        Core.Instance.Loggers.Log(ex);
      }
    }
    return xelement;
  }

  [NotPublished]
  public override void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    this.Name = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픜()).Value;
    this.Items.Clear();
    foreach (XElement element1 in element.Elements((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁핋()))
    {
      if (Serializer.DeserializeNode(element1, deserializationInfo) is SettingItem settingItem)
      {
        settingItem.Group = this;
        this.Items.Add(settingItem);
      }
    }
  }
}
