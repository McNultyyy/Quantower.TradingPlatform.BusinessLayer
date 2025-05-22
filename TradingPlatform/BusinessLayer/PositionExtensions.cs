// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.PositionExtensions
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

#nullable disable
namespace TradingPlatform.BusinessLayer;

public static class PositionExtensions
{
  public static bool IsBreakevenPossible(this Position position)
  {
    PnLItem pnLitem = position?.NetPnL ?? position?.GrossPnL;
    return pnLitem == null || pnLitem.Value > 0.0;
  }
}
