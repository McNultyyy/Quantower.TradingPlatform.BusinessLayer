// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.EqualityComparers.BusinessObjectEqualityComparer
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Collections.Generic;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils.EqualityComparers;

public class BusinessObjectEqualityComparer : IEqualityComparer<BusinessObject>
{
  public bool Equals(BusinessObject x, BusinessObject y)
  {
    if (x == y)
      return true;
    return x != null && y != null && !(x.GetType() != y.GetType()) && x.ConnectionId == y.ConnectionId && x.State == y.State && x.UniqueId == y.UniqueId;
  }

  public int GetHashCode(BusinessObject obj)
  {
    return (int) ((BusinessObjectState) ((obj.ConnectionId != null ? obj.ConnectionId.GetHashCode() : 0) * 397) ^ obj.State) * 397 ^ (obj.UniqueId != null ? obj.UniqueId.GetHashCode() : 0);
  }
}
