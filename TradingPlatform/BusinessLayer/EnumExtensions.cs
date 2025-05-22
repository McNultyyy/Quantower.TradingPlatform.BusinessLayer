// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.EnumExtensions
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public static class EnumExtensions
{
  public static string GetEnumMember(this Enum value)
  {
    return value.GetAttributeValueOrDefault<string, EnumMemberAttribute>((Func<EnumMemberAttribute, string>) (([In] obj0) => obj0.Value), value.ToString());
  }

  public static string GetDescription(this Enum value)
  {
    return value.GetAttributeValueOrDefault<string, DescriptionAttribute>((Func<DescriptionAttribute, string>) (([In] obj0) => obj0.Description), value.ToString());
  }

  public static TValue GetAttributeValueOrDefault<TValue, TAttribute>(
    this Enum value,
    Func<TAttribute, TValue> valueFunc,
    TValue defaultValue)
    where TAttribute : Attribute
  {
    TAttribute attribute = value.GetAttribute<TAttribute>();
    return valueFunc == null || (object) attribute == null ? defaultValue : valueFunc(attribute);
  }

  public static TAttribute GetAttribute<TAttribute>(this Enum value) where TAttribute : Attribute
  {
    return value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof (TAttribute), false).Cast<TAttribute>().FirstOrDefault<TAttribute>();
  }
}
