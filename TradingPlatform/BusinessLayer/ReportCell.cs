// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.ReportCell
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Integration;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>Exposes report cell decoration</summary>
public class ReportCell
{
  /// <summary>Cell label</summary>
  public string Label;
  /// <summary>Cell value</summary>
  public object Value;
  public IFormattingDescription formattingDescription;

  internal ReportCell([In] string obj0, [In] object obj1, IFormattingDescription _param3 = null)
  {
    this.Label = obj0;
    this.Value = obj1;
    this.formattingDescription = _param3;
  }
}
