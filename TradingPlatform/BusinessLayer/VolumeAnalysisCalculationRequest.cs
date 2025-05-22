// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.VolumeAnalysisCalculationRequest
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>
/// Provides VA calculation request per <see cref="T:TradingPlatform.BusinessLayer.Symbol" />
/// </summary>
[Published]
public class VolumeAnalysisCalculationRequest : VolumeAnalysisCalculationParameters
{
  public Symbol Symbol { get; set; }

  public DateTime From { get; set; }

  public DateTime To { get; set; }

  internal string Marker
  {
    get
    {
      return this.Symbol?.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픎() + this.Symbol?.ConnectionId;
    }
  }

  public VolumeAnalysisCalculationRequest()
  {
  }

  internal VolumeAnalysisCalculationRequest([In] VolumeAnalysisCalculationRequest obj0)
    : base((VolumeAnalysisCalculationParameters) obj0)
  {
    this.Symbol = obj0.Symbol;
    this.From = obj0.From;
    this.To = obj0.To;
  }

  internal VolumeAnalysisCalculationRequest([In] VolumeAnalysisCalculationParameters obj0)
    : base(obj0)
  {
  }
}
