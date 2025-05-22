// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.VendorVolumeAnalysisByPeriodResponse
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

public class VendorVolumeAnalysisByPeriodResponse : VendorIntervalResponse<IList<VolumeAnalysisData>>
{
  private VendorVolumeAnalysisByPeriodResponse([In] IList<VolumeAnalysisData> obj0)
    : base(obj0)
  {
  }

  private VendorVolumeAnalysisByPeriodResponse([In] string obj0)
    : base(obj0)
  {
  }

  public static VendorVolumeAnalysisByPeriodResponse CreateDefault()
  {
    return new VendorVolumeAnalysisByPeriodResponse((IList<VolumeAnalysisData>) new List<VolumeAnalysisData>());
  }

  public static VendorVolumeAnalysisByPeriodResponse CreateSuccess(
    IList<VolumeAnalysisData> data,
    Interval<DateTime> actualInterval)
  {
    VendorVolumeAnalysisByPeriodResponse success = new VendorVolumeAnalysisByPeriodResponse(data);
    success.ActualDataInterval = actualInterval;
    return success;
  }

  public static VendorVolumeAnalysisByPeriodResponse CreateError(string errorText)
  {
    return new VendorVolumeAnalysisByPeriodResponse(errorText);
  }

  public static VendorVolumeAnalysisByPeriodResponse CreateError(Exception exception)
  {
    return new VendorVolumeAnalysisByPeriodResponse(exception.GetMessageRecursive());
  }
}
