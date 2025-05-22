// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.VolumeAnalysisCalculationParameters
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>Provides VA calculation parameters</summary>
[Published]
public class VolumeAnalysisCalculationParameters
{
  public double FilteredVolume { get; set; }

  public bool ForceReload { get; set; }

  public DeltaCalculationType DeltaCalculationType { get; set; }

  public CumulativeDeltaReset CumulativeDeltaReset { get; set; }

  public double CustomTickSize { get; set; }

  public int CustomStep { get; set; }

  public ISessionsContainer SessionsContainer { get; set; }

  public TimeZone TimeZone { get; set; }

  public bool CalculatePriceLevels { get; set; }

  public bool ForceUsingTickData { get; set; }

  public VolumeAnalysisCalculationParameters()
  {
    this.FilteredVolume = 0.0;
    this.ForceReload = false;
    this.DeltaCalculationType = DeltaCalculationType.AggressorFlag;
    this.CustomTickSize = double.NaN;
    this.CustomStep = 1;
    this.CalculatePriceLevels = true;
    this.ForceUsingTickData = false;
  }

  internal VolumeAnalysisCalculationParameters([In] VolumeAnalysisCalculationParameters obj0)
  {
    this.FilteredVolume = obj0.FilteredVolume;
    this.ForceReload = obj0.ForceReload;
    this.DeltaCalculationType = obj0.DeltaCalculationType;
    this.CumulativeDeltaReset = obj0.CumulativeDeltaReset;
    this.CustomTickSize = obj0.CustomTickSize;
    this.CustomStep = obj0.CustomStep;
    this.SessionsContainer = obj0.SessionsContainer;
    this.TimeZone = obj0.TimeZone;
    this.CalculatePriceLevels = obj0.CalculatePriceLevels;
    this.ForceUsingTickData = obj0.ForceUsingTickData;
  }
}
