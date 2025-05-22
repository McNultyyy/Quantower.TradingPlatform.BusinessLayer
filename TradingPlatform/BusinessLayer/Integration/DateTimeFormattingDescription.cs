// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.DateTimeFormattingDescription
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Globalization;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

public class DateTimeFormattingDescription(DateTime dateTime) : FormattingDescription<DateTime>(dateTime)
{
  protected override string FormatValue(DateTime value)
  {
    return Core.Instance.TimeUtils.ConvertFromUTCToSelectedTimeZone(value).ToString((IFormatProvider) CultureInfo.InvariantCulture);
  }
}
