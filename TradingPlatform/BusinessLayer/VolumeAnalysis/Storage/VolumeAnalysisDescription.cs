// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.VolumeAnalysis.Storage.VolumeAnalysisDescription
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System.Runtime.CompilerServices;

#nullable disable
namespace TradingPlatform.BusinessLayer.VolumeAnalysis.Storage;

public class VolumeAnalysisDescription
{
  public string SymbolId { get; set; }

  public TradingPlatform.BusinessLayer.Period? Period { get; set; }

  public bool IncludePriceLevels { get; set; }

  public VolumeAnalysisDescription(string symbolId, TradingPlatform.BusinessLayer.Period? period, bool includePriceLevels)
  {
    this.SymbolId = symbolId;
    this.Period = period;
    this.IncludePriceLevels = includePriceLevels;
  }

  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 3);
    interpolatedStringHandler.AppendFormatted(this.SymbolId);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓛());
    interpolatedStringHandler.AppendFormatted<TradingPlatform.BusinessLayer.Period?>(this.Period);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓛());
    interpolatedStringHandler.AppendFormatted<bool>(this.IncludePriceLevels);
    return interpolatedStringHandler.ToStringAndClear();
  }
}
