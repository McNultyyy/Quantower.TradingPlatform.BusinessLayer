// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.VolumeAnalysisRequestParameters
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

public class VolumeAnalysisRequestParameters : RequestParameters
{
  public override RequestType Type => RequestType.VolumeAnalysis;

  public string SymbolId { get; set; }

  public DateTime FromTime { get; set; }

  public DateTime ToTime { get; set; }

  public double MinVolumeAnalysisTickSize { get; set; }

  public TradingPlatform.BusinessLayer.Utils.Interval<DateTime> Interval
  {
    get => new TradingPlatform.BusinessLayer.Utils.Interval<DateTime>(this.FromTime, this.ToTime);
    set
    {
      this.FromTime = value.From;
      this.ToTime = value.To;
    }
  }

  public bool CalculatePriceLevels { get; set; }

  public ISessionsContainer SessionsContainer { get; set; }

  public VolumeAnalysisRequestParameters()
  {
    this.CalculatePriceLevels = true;
    this.MinVolumeAnalysisTickSize = double.NaN;
  }

  internal VolumeAnalysisRequestParameters([In] VolumeAnalysisRequestParameters obj0)
  {
    this.SymbolId = obj0.SymbolId;
    this.FromTime = obj0.FromTime;
    this.ToTime = obj0.ToTime;
    this.CalculatePriceLevels = obj0.CalculatePriceLevels;
    this.CancellationToken = obj0.CancellationToken;
    this.SessionsContainer = obj0.SessionsContainer;
    this.MinVolumeAnalysisTickSize = obj0.MinVolumeAnalysisTickSize;
  }

  public VolumeAnalysisRequestParameters Copy => new VolumeAnalysisRequestParameters(this);
}
