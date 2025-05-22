// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Chart.IDrawing
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;

#nullable disable
namespace TradingPlatform.BusinessLayer.Chart;

/// <summary>Access to the chart drawing</summary>
[Published]
public interface IDrawing : ICustomizable
{
  DrawingType Type { get; }

  /// <summary>
  /// Determines, the way how chart drawing was created: manually or programmatically
  /// </summary>
  DrawingCreationMode CreationMode { get; }

  /// <summary>
  /// Determines, the availability of drawing - only current chart or all charts with same symbol
  /// </summary>
  DrawingAvailability Availability { get; }

  /// <summary>The unique ID of the chart drawing</summary>
  string Id { get; }

  /// <summary>
  /// Determines, whether chart drawing draws above or below the main chart
  /// </summary>
  bool MoveToBackground { get; set; }

  /// <summary>
  /// Determines, state of the chart drawing: Locked or Unlocked
  /// </summary>
  DrawingState State { get; set; }

  /// <summary>
  /// Get time and price of the particular point of the chart drawing
  /// </summary>
  (DateTime, double) GetPoint(int pointIndex);

  /// <summary>
  /// Set time and price value for particular point of the chart drawing
  /// </summary>
  void SetPoint(int pointIndex, DateTime time, double price);
}
