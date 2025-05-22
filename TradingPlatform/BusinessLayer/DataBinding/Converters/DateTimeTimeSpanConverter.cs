// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.DataBinding.Converters.DateTimeTimeSpanConverter
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;

#nullable disable
namespace TradingPlatform.BusinessLayer.DataBinding.Converters;

public class DateTimeTimeSpanConverter : IBindingValueConverter
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
      case DateTime dateTime:
        convertedValue = (object) dateTime.TimeOfDay;
        return true;
      case TimeSpan timeSpan:
        convertedValue = (object) new DateTime().Add(timeSpan);
        return true;
      default:
        return false;
    }
  }
}
