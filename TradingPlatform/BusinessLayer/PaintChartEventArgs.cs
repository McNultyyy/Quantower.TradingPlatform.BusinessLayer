// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.PaintChartEventArgs
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Drawing;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[Published]
public class PaintChartEventArgs
{
  public Graphics Graphics { get; set; }

  public bool DrawBackground { get; set; }

  public Rectangle Rectangle { get; set; }

  public Point MousePosition { get; set; }

  public int WindowIndex { get; set; }

  public PaintChartEventArgs(
    Graphics graphics,
    Rectangle rectangle,
    Point mousePosition,
    int windowIndex)
  {
    this.Graphics = graphics;
    this.Rectangle = rectangle;
    this.MousePosition = mousePosition;
    this.WindowIndex = windowIndex;
  }
}
