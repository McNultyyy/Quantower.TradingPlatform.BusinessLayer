// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.VolumeAnalysis.Storage.IVolumeAnalysisLocalStorage
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using TradingPlatform.BusinessLayer.Utils;
using TradingPlatform.BusinessLayer.Utils.Storage;

#nullable disable
namespace TradingPlatform.BusinessLayer.VolumeAnalysis.Storage;

public interface IVolumeAnalysisLocalStorage : ILocalStorage
{
  void Save(VolumeAnalysisInterval volumeAnalysisInterval);

  VolumeAnalysisInterval Load(VolumeAnalysisDescription description, Interval<DateTime> interval);

  void Delete(VolumeAnalysisDescription description, Interval<DateTime> interval);

  VolumeAnalysisStorageInfo GetInfo(VolumeAnalysisDescription description);
}
