// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.NativeDragEventArgs
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Drawing;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public class NativeDragEventArgs
{
  public NativeDragDropEffects Effects { get; set; }

  public bool Handled { get; set; }

  public object[] Data { get; }

  public Point MousePosition { get; }

  public NativeDragEventArgs(NativeDragDropEffects effects, object[] data, Point mousePosition)
  {
    this.Effects = effects;
    this.Data = data;
    this.MousePosition = mousePosition;
  }

  public NativeDragEventArgs(object[] data, Point mousePosition)
  {
    this.Data = data;
    this.MousePosition = mousePosition;
  }
}
