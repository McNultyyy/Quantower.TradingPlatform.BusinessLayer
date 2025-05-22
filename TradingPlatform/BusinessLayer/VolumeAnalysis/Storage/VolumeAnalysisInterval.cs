// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.VolumeAnalysis.Storage.VolumeAnalysisInterval
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer.VolumeAnalysis.Storage;

public class VolumeAnalysisInterval
{
  public VolumeAnalysisDescription Description { get; set; }

  public TradingPlatform.BusinessLayer.Utils.Interval<DateTime> Interval { get; set; }

  public IList<VolumeAnalysisData> VolumeAnalysis { get; set; }

  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(32 /*0x20*/, 4);
    interpolatedStringHandler.AppendFormatted<VolumeAnalysisDescription>(this.Description);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲핃());
    interpolatedStringHandler.AppendFormatted<TradingPlatform.BusinessLayer.Utils.Interval<DateTime>>(this.Interval);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓫());
    interpolatedStringHandler.AppendFormatted<int>(this.VolumeAnalysis.Count);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲핌());
    interpolatedStringHandler.AppendFormatted<int>(this.VolumeAnalysis.Sum<VolumeAnalysisData>((Func<VolumeAnalysisData, int>) (([In] obj0) => obj0.PriceLevels.Count)));
    return interpolatedStringHandler.ToStringAndClear();
  }
}
