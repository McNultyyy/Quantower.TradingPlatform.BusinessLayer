// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.DataBinding.Converters.ValueConverter`1
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;

#nullable disable
namespace TradingPlatform.BusinessLayer.DataBinding.Converters;

public class ValueConverter<TValue> : IBindingValueConverter
{
  private readonly Func<TValue, object> 픣퓭;

  public ValueConverter(Func<TValue, object> convertDelegate)
  {
    this.픣퓭 = convertDelegate ?? throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓔());
  }

  public bool TryConvert(
    object value,
    Type valueType,
    IBindableEntity source,
    out object convertedValue)
  {
    convertedValue = (object) null;
    if (valueType != typeof (TValue))
      return false;
    convertedValue = !(value is TValue obj) ? this.픣퓭(default (TValue)) : this.픣퓭(obj);
    return true;
  }
}
