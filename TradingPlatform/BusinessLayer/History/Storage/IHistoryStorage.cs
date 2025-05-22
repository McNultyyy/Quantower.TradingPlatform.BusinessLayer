// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.History.Storage.IHistoryStorage
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace TradingPlatform.BusinessLayer.History.Storage;

public interface IHistoryStorage
{
  IList<HistoryInterval> Load(
    HistoryRequestParameters requestParameters,
    out List<HistoryRequestParameters> historyParametersForServerRequest);

  void Save(HistoryInterval historyInterval, bool wait = false);

  void Delete(HistoryDescription description, Interval<DateTime> interval, bool wait = false);

  HistoryStorageInfo GetInfo(HistoryDescription description, HistoryStorageInfoScope scope);
}
