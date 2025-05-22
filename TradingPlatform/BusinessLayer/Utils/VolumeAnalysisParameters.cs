// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.VolumeAnalysisParameters
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils;

public class VolumeAnalysisParameters
{
  public Action RefreshChart;

  public VolumeAnalysisPluginType Type { get; set; }

  public object Parameter { get; set; }

  public object Chart { get; set; }

  public SymbolVolumeType SymbolVolumeType { get; set; }

  public ISessionsContainer SessionsContainer { get; set; }

  public TradingPlatform.BusinessLayer.TimeZone CurrentTimezone { get; set; }
}
