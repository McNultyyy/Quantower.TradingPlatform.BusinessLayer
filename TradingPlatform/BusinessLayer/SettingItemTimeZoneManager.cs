// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemTimeZoneManager
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
public class SettingItemTimeZoneManager : SettingItemList
{
  public override SettingItemType Type => SettingItemType.TimeZoneManager;

  public List<TimeZone> FavoriteTimeZones
  {
    get
    {
      List<TimeZone> favoriteTimeZones = new List<TimeZone>();
      foreach (SettingItemTimeZone settingItemTimeZone in this.Value as List<SettingItemTimeZone>)
      {
        if (settingItemTimeZone.IsFavorite)
          favoriteTimeZones.Add((TimeZone) settingItemTimeZone.Value);
      }
      return favoriteTimeZones;
    }
  }

  public SettingItemTimeZoneManager()
  {
  }

  public SettingItemTimeZoneManager(string name, IList<SettingItem> items, int sortIndex = 0)
    : base(name, (IList<SettingItem>) new List<SettingItem>(), sortIndex)
  {
    this.Value = (object) this.퓏(items);
  }

  private SettingItemTimeZoneManager([In] SettingItemTimeZoneManager obj0)
    : base((SettingItemList) obj0)
  {
    this.Value = (object) this.퓏(this.CopyItems());
  }

  public override SettingItem GetCopy() => (SettingItem) new SettingItemTimeZoneManager(this);

  protected override bool IsValueTypeValid(object value) => value is IList<SettingItemTimeZone>;

  [DataMember(Name = "Items")]
  protected override List<SettingItem> Items
  {
    get
    {
      List<SettingItem> items = new List<SettingItem>();
      foreach (SettingItemTimeZone settingItemTimeZone in this.Value as List<SettingItemTimeZone>)
      {
        if (settingItemTimeZone.IsFavorite)
          items.Add((SettingItem) settingItemTimeZone);
      }
      return items;
    }
    set => this.Value = (object) this.퓏((IList<SettingItem>) value);
  }

  private List<SettingItemTimeZone> 퓏([In] IList<SettingItem> obj0)
  {
    List<SettingItemTimeZone> settingItemTimeZoneList = new List<SettingItemTimeZone>();
    Dictionary<string, SettingItemTimeZone> dictionary = new Dictionary<string, SettingItemTimeZone>();
    foreach (SettingItem settingItem in (IEnumerable<SettingItem>) obj0)
    {
      if (settingItem is SettingItemTimeZone settingItemTimeZone)
      {
        TimeZone timeZone = (TimeZone) settingItemTimeZone.Value;
        dictionary[timeZone.TimeZoneInfo.Id] = settingItemTimeZone;
      }
    }
    foreach (TimeZoneInfo systemTimeZone in TimeZoneInfo.GetSystemTimeZones())
    {
      SettingItemTimeZone settingItemTimeZone = new SettingItemTimeZone(systemTimeZone.Id, new TimeZone(TimeZoneType.Specific, systemTimeZone));
      if (dictionary.ContainsKey(systemTimeZone.Id))
        settingItemTimeZone.IsFavorite = true;
      settingItemTimeZoneList.Add(settingItemTimeZone);
    }
    return settingItemTimeZoneList;
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
    XElement xelement = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픚());
    if (xelement != null)
    {
      foreach (XElement element1 in xelement.Elements())
      {
        SettingItemTimeZone settingItemTimeZone = new SettingItemTimeZone();
        settingItemTimeZone.FromXElement(element1, deserializationInfo);
        settingItemList.Add((SettingItem) settingItemTimeZone);
      }
    }
    this.Items = settingItemList;
  }
}
