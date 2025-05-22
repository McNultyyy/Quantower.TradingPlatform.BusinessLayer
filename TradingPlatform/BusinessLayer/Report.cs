// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Report
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Collections.Generic;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>
/// Represents a report grid which can hold system reports based on <see cref="T:TradingPlatform.BusinessLayer.ReportRow" />s and <see cref="T:TradingPlatform.BusinessLayer.ReportColumn" />s content.
/// </summary>
public class Report
{
  /// <summary>Columns collection</summary>
  public List<ReportColumn> Columns;
  /// <summary>Rows collection</summary>
  public List<ReportRow> Rows;
  internal string 핁;

  /// <summary>Initializes report grid</summary>
  public Report()
  {
    this.Columns = new List<ReportColumn>();
    this.Rows = new List<ReportRow>();
  }

  /// <summary>Adds coloring column to the report</summary>
  public void AddColumn(string header, ComparingType valueType, ColouringModes coloringModes)
  {
    this.Columns.Add(new ReportColumn(header, valueType, coloringModes));
  }

  /// <summary>Adds default(non-colored) column to the report</summary>
  public void AddColumn(string header, ComparingType valueType)
  {
    this.AddColumn(header, valueType, ColouringModes.None);
  }
}
