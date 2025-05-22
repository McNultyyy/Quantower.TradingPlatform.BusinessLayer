// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Chart.ChartMouseNativeEventArgs
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Native;

#nullable disable
namespace TradingPlatform.BusinessLayer.Chart;

public class ChartMouseNativeEventArgs : NativeMouseEventArgs
{
  public IChart Chart { get; }

  public IChartWindow Window { get; [param: In] private set; }

  public bool NeedRedraw { get; set; }

  public bool NeedMouseCapture { get; set; }

  public ChartMouseNativeEventArgs(IChart chart, IChartWindow window, NativeMouseEventArgs ev)
    : base(ev.Button, ev.Clicks, ev.X, ev.Y, ev.Delta)
  {
    this.Chart = chart;
    this.Window = window;
    this.NeedRedraw = false;
  }
}
