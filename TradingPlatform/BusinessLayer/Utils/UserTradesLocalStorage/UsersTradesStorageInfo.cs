// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.UserTradesLocalStorage.UsersTradesStorageInfo
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils.UserTradesLocalStorage;

public class UsersTradesStorageInfo
{
  public List<Interval<DateTime>> StoredIntervals { get; set; }

  public UsersTradesStorageInfo() => this.StoredIntervals = new List<Interval<DateTime>>();
}
