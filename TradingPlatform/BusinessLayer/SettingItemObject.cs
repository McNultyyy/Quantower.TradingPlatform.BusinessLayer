// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemObject
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>Typecasts setting as AccountLookup item</summary>
[DataContract]
[Serializable]
public sealed class SettingItemObject : SettingItem
{
  public override SettingItemType Type => SettingItemType.Object;

  public SettingItemObject()
  {
  }

  public SettingItemObject(string name, object value, int sortIndex = 0)
    : base(name, value, sortIndex)
  {
  }

  private SettingItemObject([In] SettingItemObject obj0)
    : base((SettingItem) obj0)
  {
  }

  public override SettingItem GetCopy() => (SettingItem) new SettingItemObject(this);

  protected override bool IsValueTypeValid(object value) => true;
}
