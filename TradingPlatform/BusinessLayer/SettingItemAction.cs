// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemAction
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Runtime.Serialization;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>Typecasts setting as Button item</summary>
[Published]
[DataContract]
[Serializable]
public sealed class SettingItemAction : SettingItem
{
  public override SettingItemType Type => SettingItemType.Action;

  public string LabelText { get; set; }

  public SettingItemAction()
  {
  }

  public SettingItemAction(string name, SettingItemActionDelegate value, int sortIndex = 0)
    : base(name, (object) value, sortIndex)
  {
  }

  public SettingItemAction(SettingItemAction settingItem)
    : base((SettingItem) settingItem)
  {
    this.LabelText = settingItem.LabelText;
  }

  [NotPublished]
  public override SettingItem GetCopy() => (SettingItem) new SettingItemAction(this);

  [NotPublished]
  public static implicit operator SettingItemActionDelegate(SettingItemAction item)
  {
    return item.Value as SettingItemActionDelegate;
  }

  [NotPublished]
  protected override bool IsValueTypeValid(object value) => value is SettingItemActionDelegate;

  protected override void ValueFromXElement(
    XElement element,
    DeserializationInfo deserializationInfo)
  {
  }
}
