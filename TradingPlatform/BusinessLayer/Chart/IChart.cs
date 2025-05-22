// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Chart.IChart
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;

#nullable disable
namespace TradingPlatform.BusinessLayer.Chart;

/// <summary>Access to the chart panel</summary>
[Published]
public interface IChart
{
  /// <summary>Chart panel unique ID</summary>
  string ID { get; }

  /// <summary>Collection of chart windows</summary>
  IChartWindow[] Windows { get; }

  /// <summary>Current X scale value - width of the bar in pixels</summary>
  int BarsWidth { get; }

  /// <summary>Provides time zone of current chart.</summary>
  TradingPlatform.BusinessLayer.TimeZone CurrentTimeZone { get; }

  /// <summary>Provides account of current chart.</summary>
  Account Account { get; }

  /// <summary>Provides custom sessions of current chart.</summary>
  ISessionsContainer CurrentSessionContainer { get; }

  /// <summary>Current tick size of the chart</summary>
  double TickSize { get; }

  /// <summary>Main window of the chart</summary>
  IChartWindow MainWindow { get; }

  /// <summary>Current right offset value</summary>
  int RightOffset { get; }

  /// <summary>Collection of chart drawingsCollection</summary>
  IChartDrawingsCollection Drawings { get; }

  /// <summary>Force chart redraw</summary>
  void RedrawBuffer();

  /// <summary>
  /// The MouseDown event occurs when the mouse button is pressed down
  /// </summary>
  event EventHandler<ChartMouseNativeEventArgs> MouseDown;

  /// <summary>
  /// The MouseUp event occurs when the mouse button is released
  /// </summary>
  event EventHandler<ChartMouseNativeEventArgs> MouseUp;

  /// <summary>
  /// The MouseClick event occurs when the mouse button is clicked
  /// </summary>
  event EventHandler<ChartMouseNativeEventArgs> MouseClick;

  /// <summary>
  /// The MouseMove event occurs when the mouse moving over the chart
  /// </summary>
  event EventHandler<ChartMouseNativeEventArgs> MouseMove;

  /// <summary>
  /// The MouseDown event occurs when the user scrolling mouse wheel
  /// </summary>
  event EventHandler<ChartMouseNativeEventArgs> MouseWheel;

  /// <summary>
  /// The MouseDown event occurs when the mouse enter the chart
  /// </summary>
  event EventHandler<ChartMouseNativeEventArgs> MouseEnter;

  /// <summary>
  /// The MouseDown event occurs when the mouse leave the chart
  /// </summary>
  event EventHandler<ChartMouseNativeEventArgs> MouseLeave;

  /// <summary>
  /// The SettingsChanged event occurs when any settings were changed
  /// </summary>
  event EventHandler<ChartEventArgs> SettingsChanged;

  /// <summary>
  /// The AccountChanged event occurs when the account was changed
  /// </summary>
  event EventHandler<ChartEventArgs> AccountChanged;
}
