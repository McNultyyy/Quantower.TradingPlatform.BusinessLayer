// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Chart.IChartWindowCoordinatesConverter
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;

#nullable disable
namespace TradingPlatform.BusinessLayer.Chart;

/// <summary>Converter between x/y and Time/Price scales</summary>
[Published]
public interface IChartWindowCoordinatesConverter
{
  /// <summary>
  /// Get the DateTime value that is corresponding to specified x coordinate
  /// </summary>
  /// <param name="x"></param>
  /// <returns></returns>
  DateTime GetTime(double x);

  /// <summary>
  /// Get the Price value that is corresponding to specified y coordinate
  /// </summary>
  /// <param name="y"></param>
  /// <returns></returns>
  double GetPrice(double y);

  /// <summary>
  /// Get the X coordinate that is corresponding to specified DateTime value
  /// </summary>
  /// <param name="dt"></param>
  /// <returns></returns>
  double GetChartX(DateTime dt);

  /// <summary>
  /// Get the Y coordinate that is corresponding to specified price value
  /// </summary>
  /// <param name="price"></param>
  /// <returns></returns>
  double GetChartY(double price);

  /// <summary>
  /// Get the bar index that is corresponding to specified DateTime value
  /// </summary>
  /// <param name="dt"></param>
  /// <returns></returns>
  double GetBarIndex(DateTime dt);
}
