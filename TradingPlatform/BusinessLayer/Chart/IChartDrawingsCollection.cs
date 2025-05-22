// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Chart.IChartDrawingsCollection
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;

#nullable disable
namespace TradingPlatform.BusinessLayer.Chart;

/// <summary>Access to the chart drawingsCollection collection</summary>
[Published]
public interface IChartDrawingsCollection
{
  /// <summary>Add chart drawing to the collection</summary>
  /// <param name="drawing"></param>
  void Add(IDrawing drawing);

  /// <summary>Remove specified chart drawing from collection</summary>
  /// <param name="drawing"></param>
  void Remove(IDrawing drawing);

  /// <summary>Get chart drawing by ID</summary>
  /// <param name="drawingId"></param>
  /// <returns></returns>
  IDrawing FindById(string drawingId);

  /// <summary>
  /// Get all chart drawingsCollection assigned to specified symbol
  /// </summary>
  /// <returns></returns>
  List<IDrawing> GetAll(Symbol symbol = null);

  /// <summary>
  /// The Added events occured, when new chart drawing was added to collection
  /// </summary>
  event Action<DrawingEventArgs> Added;

  /// <summary>
  /// The Moved events occured, when chart drawing was moved
  /// </summary>
  event Action<DrawingEventArgs> Moved;

  /// <summary>
  /// The Removed events occured, when chart drawing was removed from the collection
  /// </summary>
  event Action<DrawingEventArgs> Removed;

  /// <summary>
  /// The SelectionChanged events occured, when selected chart drawing was changed
  /// </summary>
  event Action<DrawingSelectionEventArgs> SelectionChanged;
}
