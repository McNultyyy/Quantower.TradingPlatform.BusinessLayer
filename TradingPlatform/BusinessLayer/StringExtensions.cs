// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.StringExtensions
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.IO;
using System.Reflection;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public static class StringExtensions
{
  public static bool Contains(this string str1, string str2, StringComparison stringComparison)
  {
    return str1.IndexOf(str2, stringComparison) >= 0;
  }

  public static bool TryParseEnum<TEnum, TAttribute>(
    this string str,
    Func<TAttribute, string> getAttributeValue,
    out TEnum enumValue)
    where TEnum : struct, IConvertible
    where TAttribute : Attribute
  {
    if (!typeof (TEnum).IsEnum)
      throw new ArgumentException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픪());
    enumValue = default (TEnum);
    foreach (FieldInfo field in enumValue.GetType().GetFields())
    {
      object[] customAttributes = field.GetCustomAttributes(typeof (TAttribute), false);
      if (customAttributes.Length != 0)
      {
        foreach (object obj in customAttributes)
        {
          if (obj is TAttribute attribute && getAttributeValue(attribute) == str)
          {
            enumValue = (TEnum) field.GetValue((object) null);
            return true;
          }
        }
      }
    }
    return false;
  }

  public static string EncodeFilePathPart(this string fileName)
  {
    string str = fileName;
    foreach (char invalidFileNameChar in Path.GetInvalidFileNameChars())
      str = str.Replace($"{invalidFileNameChar}", $"{(int) invalidFileNameChar}");
    return str;
  }
}
