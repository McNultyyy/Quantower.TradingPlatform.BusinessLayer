// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Chart.IChartWindow
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Drawing;

#nullable disable
namespace TradingPlatform.BusinessLayer.Chart;

/// <summary>Access to the particular window from chart panel</summary>
[Published]
public interface IChartWindow
{
  /// <summary>Client rectangle of the chart window</summary>
  Rectangle ClientRectangle { get; }

  /// <summary>
  /// Determines, whether this window is the main window of the chart
  /// </summary>
  bool IsMainWindow { get; }

  /// <summary>Chart window number</summary>
  int WindowNumber { get; }

  /// <summary>
  /// Special object, allows you to convert values from x/y scale to Time/Price and back
  /// </summary>
  IChartWindowCoordinatesConverter CoordinatesConverter { get; }

  /// <summary>
  /// 
  /// </summary>
  double YScaleFactor { get; }
}
