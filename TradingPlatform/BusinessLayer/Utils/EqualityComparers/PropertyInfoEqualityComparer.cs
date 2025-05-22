// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.EqualityComparers.PropertyInfoEqualityComparer
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils.EqualityComparers;

public class PropertyInfoEqualityComparer : IEqualityComparer<PropertyInfo>
{
  public bool Equals(PropertyInfo x, PropertyInfo y)
  {
    if ((object) x == (object) y)
      return true;
    return (object) x != null && (object) y != null && !(x.GetType() != y.GetType()) && object.Equals((object) x.Name, (object) y.Name);
  }

  public int GetHashCode(PropertyInfo obj) => obj.Name.GetHashCode();
}
