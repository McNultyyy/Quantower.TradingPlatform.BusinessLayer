// Decompiled with JetBrains decompiler
// Type: 퓏.퓽
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer;

#nullable disable
namespace 퓏;

internal class 퓽 : ISyntheticSynhroniserItem
{
  public SyntheticItem SyntheticItem { get; set; }

  public HistoricalData HistoricalData { get; set; }

  public int Position { get; [param: In] private set; }

  public long NextPositionTime
  {
    get
    {
      return this.Position < this.HistoricalData.Count - 1 ? this.HistoricalData[this.Position + 1, SeekOriginHistory.Begin].TicksLeft : -1L;
    }
  }

  public 퓽() => this.Position = -1;

  public void Move() => ++this.Position;
}
