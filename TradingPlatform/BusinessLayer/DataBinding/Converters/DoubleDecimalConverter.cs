// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.DataBinding.Converters.DoubleDecimalConverter
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;

#nullable disable
namespace TradingPlatform.BusinessLayer.DataBinding.Converters;

public class DoubleDecimalConverter : IBindingValueConverter
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
      case double num1:
        if (num1 > -7.9228162514264338E+28)
        {
          if (num1 >= 7.9228162514264338E+28)
          {
            convertedValue = (object) Decimal.MaxValue;
            return true;
          }
          convertedValue = (object) (Decimal) num1;
          return true;
        }
        convertedValue = (object) Decimal.MinValue;
        return true;
      case Decimal num2:
        convertedValue = (object) (double) num2;
        return true;
      default:
        return false;
    }
  }
}
