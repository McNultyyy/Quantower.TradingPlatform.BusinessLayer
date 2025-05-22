// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.VendorVolumeAnalysisResponse
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

public class VendorVolumeAnalysisResponse : VendorIntervalResponse<VolumeAnalysisData>
{
  private VendorVolumeAnalysisResponse([In] VolumeAnalysisData obj0)
    : base(obj0)
  {
  }

  private VendorVolumeAnalysisResponse([In] string obj0)
    : base(obj0)
  {
  }

  public static VendorVolumeAnalysisResponse CreateDefault()
  {
    return new VendorVolumeAnalysisResponse(new VolumeAnalysisData());
  }

  public static VendorVolumeAnalysisResponse CreateSuccess(
    VolumeAnalysisData data,
    Interval<DateTime> actualInterval)
  {
    VendorVolumeAnalysisResponse success = new VendorVolumeAnalysisResponse(data);
    success.ActualDataInterval = actualInterval;
    return success;
  }

  public static VendorVolumeAnalysisResponse CreateError(string errorText)
  {
    return new VendorVolumeAnalysisResponse(errorText);
  }

  public static VendorVolumeAnalysisResponse CreateError(Exception exception)
  {
    return new VendorVolumeAnalysisResponse(exception.GetMessageRecursive());
  }
}
