// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.Storage.UserTradesInterval
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using TradingPlatform.BusinessLayer.Integration;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils.Storage;

public class UserTradesInterval
{
  public TradingPlatform.BusinessLayer.Utils.Interval<DateTime> Interval { get; set; }

  public IEnumerable<MessageTrade> Trades { get; set; }
}
