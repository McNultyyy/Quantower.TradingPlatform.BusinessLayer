// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.CustomHoliday
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public class CustomHoliday : ICustomizable
{
  public bool IsActive { get; set; }

  public string Name { get; set; }

  public DateTime Date { get; set; }

  public IList<SettingItem> Settings
  {
    get
    {
      return (IList<SettingItem>) new List<SettingItem>()
      {
        (SettingItem) new SettingItemBoolean(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓸(), this.IsActive),
        (SettingItem) new SettingItemString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓫(), this.Name),
        (SettingItem) new SettingItemDateTime(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓦(), this.Date)
      };
    }
    set
    {
      this.IsActive = value.GetValueOrDefault<bool>((this.IsActive ? 1 : 0) != 0, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓸());
      this.Name = value.GetValueOrDefault<string>(this.Name, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓫());
      this.Date = value.GetValueOrDefault<DateTime>(this.Date, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓦());
    }
  }
}
