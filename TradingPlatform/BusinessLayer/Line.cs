// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Line
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System.Collections.Generic;
using System.Drawing;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public abstract class Line : ICustomizable
{
  public string Name { get; set; }

  public Color Color { get; set; }

  public int Width { get; set; }

  public LineStyle Style { get; set; }

  public bool Visible { get; set; }

  protected Line(string name, Color color, int width, LineStyle style)
  {
    this.Name = name;
    this.Color = color;
    this.Width = width;
    this.Style = style;
    this.Visible = true;
  }

  public virtual IList<SettingItem> Settings
  {
    get
    {
      List<SettingItem> settings = new List<SettingItem>();
      SettingItemBoolean settingItemBoolean = new SettingItemBoolean(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픗(), this.Visible);
      settingItemBoolean.SortIndex = 0;
      settings.Add((SettingItem) settingItemBoolean);
      SettingItemLineOptions settingItemLineOptions = new SettingItemLineOptions(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓧(), new LineOptions()
      {
        WithCheckBox = false,
        Color = this.Color,
        Width = this.Width,
        LineStyle = this.Style
      });
      settingItemLineOptions.SortIndex = 1;
      settings.Add((SettingItem) settingItemLineOptions);
      return (IList<SettingItem>) settings;
    }
    set
    {
      IList<SettingItem> list = value;
      SettingItem itemByName1 = list.GetItemByName(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픗());
      if (itemByName1 != null && itemByName1.Value is bool flag)
        this.Visible = flag;
      SettingItem itemByName2 = list.GetItemByName(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓧());
      if (itemByName2 == null || !(itemByName2.Value is LineOptions lineOptions))
        return;
      this.Color = lineOptions.Color;
      this.Width = lineOptions.Width;
      this.Style = lineOptions.LineStyle;
    }
  }
}
