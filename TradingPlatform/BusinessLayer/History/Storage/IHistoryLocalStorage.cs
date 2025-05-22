// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.History.Storage.IHistoryLocalStorage
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using TradingPlatform.BusinessLayer.Utils;
using TradingPlatform.BusinessLayer.Utils.Storage;

#nullable disable
namespace TradingPlatform.BusinessLayer.History.Storage;

public interface IHistoryLocalStorage : ILocalStorage
{
  void Save(HistoryInterval interval);

  HistoryInterval Load(HistoryDescription description, Interval<DateTime> interval);

  void Delete(HistoryDescription description, Interval<DateTime> interval);

  HistoryStorageInfo GetInfo(HistoryDescription description, HistoryStorageInfoScope scope);

  List<HistoryDescription> GetAllAvailableHistoryDescriptions();

  void Vacuum();
}
