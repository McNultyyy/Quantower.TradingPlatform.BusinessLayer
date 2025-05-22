// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.EqualityComparers.SettingItemNameEqualityComparer
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Collections.Generic;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils.EqualityComparers;

public class SettingItemNameEqualityComparer : IEqualityComparer<SettingItem>
{
  public bool Equals(SettingItem x, SettingItem y)
  {
    if (x == y)
      return true;
    return x != null && y != null && !(x.GetType() != y.GetType()) && x.Name == y.Name;
  }

  public int GetHashCode(SettingItem obj) => obj.Name == null ? 0 : obj.Name.GetHashCode();
}
