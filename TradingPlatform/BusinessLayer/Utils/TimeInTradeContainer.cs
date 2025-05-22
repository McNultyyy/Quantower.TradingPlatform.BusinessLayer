// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.TimeInTradeContainer
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils;

public class TimeInTradeContainer
{
  public Action<TimeInTradeItem> OnItemEnabilityChanged;

  public TimeInTradeItem[] TimeInTradeItems { get; set; }

  public TimeInTradeContainer() => this.TimeInTradeItems = new TimeInTradeItem[0];

  public TimeInTradeContainer Clone()
  {
    TimeInTradeContainer inTradeContainer = new TimeInTradeContainer();
    if (this.TimeInTradeItems.Length != 0)
      inTradeContainer.TimeInTradeItems = ((IEnumerable<TimeInTradeItem>) this.TimeInTradeItems).Select<TimeInTradeItem, TimeInTradeItem>((Func<TimeInTradeItem, TimeInTradeItem>) (([In] obj0) => new TimeInTradeItem(obj0))).ToArray<TimeInTradeItem>();
    return inTradeContainer;
  }
}
