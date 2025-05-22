// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.LineLevel
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public sealed class LineLevel : Line
{
  public double Level { get; set; }

  public LineLevel(double level, string name, Color color, int width, LineStyle style)
    : base(name, color, width, style)
  {
    this.Level = level;
  }

  public override IList<SettingItem> Settings
  {
    get
    {
      IList<SettingItem> settings = base.Settings;
      SettingItemDouble settingItemDouble = new SettingItemDouble(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓣(), this.Level);
      settingItemDouble.SortIndex = 2;
      settings.Add((SettingItem) settingItemDouble);
      return settings;
    }
    set
    {
      IList<SettingItem> list = value;
      SettingItem itemByName = list.GetItemByName(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓣());
      if (itemByName != null && itemByName.Value is double num)
        this.Level = num;
      base.Settings = list;
    }
  }
}
