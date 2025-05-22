// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.ReportColumn
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Drawing;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>Exposes report column decoration</summary>
public class ReportColumn
{
  /// <summary>Header of the column</summary>
  public string Header;
  public ColouringModes ColoringModes;
  /// <summary>Column value type</summary>
  public ComparingType ValueType;

  public Color UpForeColor { get; [param: In] private set; }

  public Color DownForeColor { get; [param: In] private set; }

  internal ReportColumn([In] string obj0, [In] ComparingType obj1, [In] ColouringModes obj2)
  {
    this.Header = obj0;
    this.ValueType = obj1;
    this.ColoringModes = obj2;
    if (obj2 != ColouringModes.Signed)
      return;
    this.UpForeColor = Color.FromArgb(55, 219, 186);
    this.DownForeColor = Color.FromArgb(235, 96 /*0x60*/, 47);
  }
}
