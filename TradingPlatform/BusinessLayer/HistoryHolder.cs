// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.HistoryHolder
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Collections.Generic;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.History.Storage;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public class HistoryHolder
{
  public IList<IHistoryItem> History { get; }

  public HistoryRequestParameters RequestParameters { get; }

  public int ProgressPercent { get; [param: In] private set; }

  public HistoryHolder(
    IList<IHistoryItem> history,
    HistoryRequestParameters requestParameters,
    int progressPercent = 100)
  {
    this.History = history;
    this.RequestParameters = requestParameters;
    this.ProgressPercent = progressPercent;
  }

  public HistoryInterval ToHistoryInterval()
  {
    return new HistoryInterval()
    {
      Description = this.RequestParameters.ToDescription(),
      Interval = this.RequestParameters.Interval,
      History = this.History
    };
  }
}
