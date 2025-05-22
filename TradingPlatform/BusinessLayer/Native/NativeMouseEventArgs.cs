// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Native.NativeMouseEventArgs
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Drawing;

#nullable disable
namespace TradingPlatform.BusinessLayer.Native;

public class NativeMouseEventArgs
{
  public NativeMouseEventArgs(NativeMouseButtons button, int clicks, int x, int y, int delta)
  {
    this.X = x;
    this.Y = y;
    this.Clicks = clicks;
    this.Button = button;
    this.Delta = delta;
  }

  public NativeMouseButtons Button { get; }

  public int Clicks { get; }

  public int X { get; }

  public int Y { get; }

  public int Delta { get; }

  public Point Location => new Point(this.X, this.Y);

  /// <summary>
  /// Gets or sets a value indicating whether the event was handled.
  /// true to bypass the control's default handling; otherwise, false to also pass the event along to the default control handler.
  /// </summary>
  public bool Handled { get; set; }
}
