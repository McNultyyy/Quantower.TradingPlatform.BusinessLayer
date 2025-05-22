// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.DayBarMessageCreator
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using 퓏;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

public abstract class DayBarMessageCreator : IDayBarUpdate, IDisposable
{
  public Action<DayBar> PushMessage;
  private protected ConcurrentDictionary<string, 픒> 픣퓜;
  private bool 픣픺;

  public virtual void Initialize() => this.픣퓜 = new ConcurrentDictionary<string, 픒>();

  public void TryCreateEmptyDb(string symbol, HistoryType updateType)
  {
    픒 픒;
    if (!this.픣퓜.TryGetValue(symbol, out 픒))
    {
      픒 = new 픒(symbol) { UpdateHistoryType = updateType };
      this.픣퓜[symbol] = 픒;
    }
    Action<DayBar> pushMessage = this.PushMessage;
    if (pushMessage == null)
      return;
    pushMessage(픒.LastDayBar);
  }

  public DayBar ProcessQuote(Quote quote1)
  {
    픒 픒;
    return !this.픣퓜.TryGetValue(quote1.SymbolId, out 픒) ? (DayBar) null : 픒.ProcessQuote(quote1);
  }

  public DayBar ProcessLast(Last last)
  {
    픒 픒;
    return !this.픣퓜.TryGetValue(last.SymbolId, out 픒) ? (DayBar) null : 픒.ProcessLast(last);
  }

  public DayBar ProcessMark(Mark mark)
  {
    픒 픒;
    return !this.픣퓜.TryGetValue(mark.SymbolId, out 픒) ? (DayBar) null : 픒.ProcessMark(mark);
  }

  public abstract void CreateDbFromHistory(string symbol, HistoryType updateType, Action callback = null);

  public void CheckIfNeedUpdate()
  {
    if (this.픣픺)
      return;
    this.픣픺 = true;
    try
    {
      foreach (KeyValuePair<string, 픒> keyValuePair in new Dictionary<string, 픒>((IDictionary<string, 픒>) this.픣퓜))
      {
        string key = keyValuePair.Key;
        픒 픒 = keyValuePair.Value;
        if ((Core.Instance.TimeUtils.DateTimeUtcNow - 픒.LastDayBarCreationTime).TotalDays > 1.0)
          this.CreateDbFromHistory(key, 픒.UpdateHistoryType);
      }
    }
    finally
    {
      this.픣픺 = false;
    }
  }

  public virtual void Dispose() => this.픣퓜?.Clear();
}
