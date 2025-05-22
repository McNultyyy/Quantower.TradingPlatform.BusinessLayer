// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.ReportRow
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Collections.Generic;
using TradingPlatform.BusinessLayer.Integration;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>Exposes report row decoration</summary>
public class ReportRow
{
  /// <summary>A collection of cells</summary>
  public List<ReportCell> Cells;

  /// <summary>Initializes cells in the row</summary>
  public ReportRow() => this.Cells = new List<ReportCell>();

  /// <summary>Adds cells to the row by label and value</summary>
  public void AddCell(string label, object value, IFormattingDescription formattingDescription = null)
  {
    this.Cells.Add(new ReportCell(label, value, formattingDescription));
  }

  /// <summary>Adds cells to the row by value only</summary>
  public void AddCell(object value, IFormattingDescription formattingDescription = null)
  {
    if (value == null)
      this.AddCell(string.Empty, (object) string.Empty, formattingDescription);
    else
      this.AddCell(!(value is double d) ? value.ToString() : (double.IsNaN(d) ? string.Empty : d.ToString()), value, formattingDescription);
  }
}
