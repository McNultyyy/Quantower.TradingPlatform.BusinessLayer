// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemIconedAction
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[DataContract]
[Serializable]
public sealed class SettingItemIconedAction : SettingItem
{
  public override SettingItemType Type => SettingItemType.IconedAction;

  public SettingItemIconedActionType IconType { get; set; }

  public SettingItemIconedAction()
  {
  }

  public SettingItemIconedAction(string name, SettingItemActionDelegate value, int sortIndex = 0)
    : base(name, (object) value, sortIndex)
  {
  }

  private SettingItemIconedAction([In] SettingItemIconedAction obj0)
    : base((SettingItem) obj0)
  {
  }

  public override SettingItem GetCopy() => (SettingItem) new SettingItemIconedAction(this);

  protected override bool IsValueTypeValid(object value) => value is SettingItemActionDelegate;

  public static implicit operator SettingItemActionDelegate(SettingItemIconedAction item)
  {
    return item.Value as SettingItemActionDelegate;
  }
}
