// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.DayBarMessageFromHistoryCreator
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using 퓏;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

public class DayBarMessageFromHistoryCreator : DayBarMessageCreator
{
  private const int 퓑픔 = 5;
  public Func<HistoryRequestParameters, IList<IHistoryItem>> LoadHistory;
  public int GenerationThreadsCount;
  private readonly 퓏.픑 퓑픤;

  public Action<DayBar> CorrectDayBar { get; set; }

  public DayBarMessageFromHistoryCreator()
  {
    this.퓑픤 = new 퓏.픑();
    this.GenerationThreadsCount = 3;
  }

  public override void Initialize()
  {
    base.Initialize();
    this.퓑픤.핂핂 = this.LoadHistory;
    this.퓑픤.핂퓬 = this.GenerationThreadsCount;
    this.퓑픤.핂퓲 = new Action<픒>(this.퓏);
    this.퓑픤.퓏();
    this.퓑픤.Start();
  }

  public override void CreateDbFromHistory(string symbol, HistoryType updateType, Action callback = null)
  {
    this.퓑픤.Push(new DayBarMessageGenerationParameters()
    {
      SymbolId = symbol,
      UpdateHistoryType = updateType,
      DayToLoadCount = 5U,
      Callback = callback
    });
  }

  private void 퓏([In] 픒 obj0)
  {
    DayBar lastDayBar = obj0.LastDayBar;
    Action<DayBar> correctDayBar = this.CorrectDayBar;
    if (correctDayBar != null)
      correctDayBar(lastDayBar);
    this.픣퓜[obj0.SymbolId] = obj0;
    Action<DayBar> pushMessage = this.PushMessage;
    if (pushMessage == null)
      return;
    pushMessage(lastDayBar);
  }

  public override void Dispose()
  {
    this.퓑픤?.Stop();
    base.Dispose();
  }
}
