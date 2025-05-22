// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.VolumeAnalysisByPeriodRequestParameters
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.VolumeAnalysis.Storage;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

public class VolumeAnalysisByPeriodRequestParameters : VolumeAnalysisRequestParameters
{
  public override RequestType Type => RequestType.VolumeAnalysisByPeriod;

  public Period Period { get; set; }

  public bool ForceReload { get; set; }

  public VolumeAnalysisByPeriodRequestParameters() => this.CalculatePriceLevels = false;

  internal VolumeAnalysisByPeriodRequestParameters([In] VolumeAnalysisByPeriodRequestParameters obj0)
    : base((VolumeAnalysisRequestParameters) obj0)
  {
    this.Period = obj0.Period;
    this.ForceReload = obj0.ForceReload;
  }

  public VolumeAnalysisByPeriodRequestParameters Copy
  {
    get => new VolumeAnalysisByPeriodRequestParameters(this);
  }

  public VolumeAnalysisDescription ToDescription()
  {
    return new VolumeAnalysisDescription(this.SymbolId, new Period?(this.Period), this.CalculatePriceLevels);
  }
}
