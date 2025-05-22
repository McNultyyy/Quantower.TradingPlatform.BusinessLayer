// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.VolumeAnalysisManager
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Utils;
using 퓏;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>Volume Analysis calculations</summary>
[Published]
public class VolumeAnalysisManager
{
  private const int 핇퓤 = 10;
  private const int 핇픮 = 7;
  private int 핇픉;
  private readonly ActionBufferedProcessorWithPriority 핇픒;

  internal VolumeAnalysisManager() => this.핇픒 = new ActionBufferedProcessorWithPriority(3);

  internal void 퓏() => this.핇픒.Start();

  internal void 퓬() => this.핇픒?.Stop();

  /// <summary>Calculate volume profile for requested time range</summary>
  public IVolumeAnalysisCalculationTask CalculateProfile(VolumeAnalysisCalculationRequest request)
  {
    VolumeAnalysisCalculationRequest calculationRequest = new VolumeAnalysisCalculationRequest(request);
    Symbol volumeAnalysisSymbol;
    if (Core.Instance.SymbolsMapping.TryGetVolumeAnalysisSymbol(request.Symbol, out volumeAnalysisSymbol))
      calculationRequest.Symbol = volumeAnalysisSymbol;
    int num = this.퓏(calculationRequest) ? 1 : 0;
    픰 profile = new 픰(calculationRequest);
    if (num == 0)
    {
      profile.State = VolumeAnalysisCalculationState.Finished;
      return (IVolumeAnalysisCalculationTask) profile;
    }
    this.핇픒.Push(new Action(((픗) profile).퓏), 1, calculationRequest.Marker);
    return (IVolumeAnalysisCalculationTask) profile;
  }

  /// <summary>Calculate volume profile for each bar in History Data</summary>
  public IVolumeAnalysisCalculationProgress CalculateProfile(
    HistoricalData historicalData,
    VolumeAnalysisCalculationParameters calculationParameters)
  {
    VolumeAnalysisCalculationRequest calculationRequest = new VolumeAnalysisCalculationRequest(calculationParameters)
    {
      Symbol = historicalData.Symbol,
      From = historicalData.Count == 0 ? Core.Instance.TimeUtils.DateTimeUtcNow : historicalData[0, SeekOriginHistory.Begin].TimeLeft,
      To = historicalData.ToTime == DateTime.MinValue ? Core.Instance.TimeUtils.DateTimeUtcNow : historicalData.ToTime
    };
    Symbol volumeAnalysisSymbol;
    if (Core.Instance.SymbolsMapping.TryGetVolumeAnalysisSymbol(calculationRequest.Symbol, out volumeAnalysisSymbol))
      calculationRequest.Symbol = volumeAnalysisSymbol;
    int num = this.퓏(calculationRequest) ? 1 : 0;
    퓢 profile = historicalData.Aggregation.BarCreationBehavior == BarCreationBehavior.Deferred ? (퓢) new 픫(historicalData, calculationRequest) : new 퓢(historicalData, calculationRequest);
    if (num == 0)
    {
      profile.State = VolumeAnalysisCalculationState.Finished;
      return (IVolumeAnalysisCalculationProgress) profile;
    }
    historicalData.VolumeAnalysisCalculationProgress = (IVolumeAnalysisCalculationProgress) profile;
    this.핇픒.Push(new Action(((픗) profile).퓏), 1, calculationRequest.Marker);
    return (IVolumeAnalysisCalculationProgress) profile;
  }

  /// <summary>Calculate volume profile for requested time range</summary>
  public IVolumeAnalysisCalculationTask CalculateProfile(Symbol symbol, DateTime from, DateTime to)
  {
    return this.CalculateProfile(new VolumeAnalysisCalculationRequest()
    {
      Symbol = symbol,
      From = from,
      To = to
    });
  }

  /// <summary>Calculate volume profile for each bar in History Data</summary>
  public IVolumeAnalysisCalculationProgress CalculateProfile(HistoricalData historicalData)
  {
    return this.CalculateProfile(historicalData, new VolumeAnalysisCalculationParameters());
  }

  private bool 퓏([In] VolumeAnalysisCalculationRequest obj0)
  {
    if (obj0 == null)
      return false;
    if ((Core.Instance.Licences.GetLicenceRuleItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픠()) ?? Core.Instance.Licences.GetLicenceRuleItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓮()) ?? Core.Instance.Licences.GetLicenceRuleItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픕()) ?? Core.Instance.Licences.GetLicenceRuleItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓠())) == null && (Core.Instance.RulesManager.IsAllowed(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓠(), obj0.Symbol).Status == TradingOperationStatus.Allowed || Core.Instance.RulesManager.IsAllowed(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픠(), obj0.Symbol).Status == TradingOperationStatus.Allowed ? 1 : (obj0.Symbol == null ? 0 : (obj0.Symbol.State == BusinessObjectState.Fake ? 1 : 0))) == 0)
    {
      ++this.핇픉;
      if (this.핇픉 > 10)
      {
        Core.Instance.Licences.OnLicenceCheckError(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픱(), (string) null);
        return false;
      }
      DateTime dateTime = Core.Instance.TimeUtils.DateTimeUtcNow.AddDays(-7.0);
      if (obj0.From < dateTime)
      {
        obj0.From = dateTime;
        Core.Instance.Licences.OnLicenceCheckError(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픶(), (string) null);
      }
    }
    return true;
  }
}
