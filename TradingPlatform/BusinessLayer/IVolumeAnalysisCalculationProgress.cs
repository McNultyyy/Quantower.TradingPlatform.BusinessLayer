// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.IVolumeAnalysisCalculationProgress
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Threading;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[Published]
public interface IVolumeAnalysisCalculationProgress : IDisposable
{
  VolumeAnalysisCalculationState State { get; }

  int ProgressPercent { get; }

  int ProgressBarIndex { get; }

  bool IsAborted { get; }

  event EventHandler<VolumeAnalysisTaskEventArgs> StateChanged;

  event EventHandler<VolumeAnalysisTaskEventArgs> ProgressChanged;

  void AbortLoading();

  void Wait(CancellationToken token = default (CancellationToken));

  VolumeAnalysisCalculationParameters CalculationParameters { get; }
}
