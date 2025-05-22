// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.DataBinding.Converters.IntDecimalConverter
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;

#nullable disable
namespace TradingPlatform.BusinessLayer.DataBinding.Converters;

public class IntDecimalConverter : IBindingValueConverter
{
  public bool TryConvert(
    object value,
    Type valueType,
    IBindableEntity source,
    out object convertedValue)
  {
    convertedValue = (object) null;
    switch (value)
    {
      case int num2:
        convertedValue = (object) (Decimal) num2;
        return true;
      case Decimal val1:
        Decimal num1 = Math.Min(Math.Max(val1, -2147483648M), 2147483647M);
        convertedValue = (object) (int) num1;
        return true;
      default:
        return false;
    }
  }
}
