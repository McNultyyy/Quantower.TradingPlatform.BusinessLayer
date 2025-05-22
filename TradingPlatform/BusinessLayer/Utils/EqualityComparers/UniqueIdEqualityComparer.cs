// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.EqualityComparers.UniqueIdEqualityComparer
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Collections.Generic;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils.EqualityComparers;

public class UniqueIdEqualityComparer : IEqualityComparer<IUniqueID>
{
  public bool Equals(IUniqueID x, IUniqueID y)
  {
    if (x == y)
      return true;
    return x != null && y != null && !(x.GetType() != y.GetType()) && x.UniqueId == y.UniqueId;
  }

  public int GetHashCode(IUniqueID obj) => obj.UniqueId == null ? 0 : obj.UniqueId.GetHashCode();
}
