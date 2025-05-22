// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.Comparers.TimeInForceComparer
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils.Comparers;

public class TimeInForceComparer : IComparer<TimeInForce>
{
  public int Compare(TimeInForce x, TimeInForce y)
  {
    return TimeInForceComparer.퓏(x) - TimeInForceComparer.퓏(y);
  }

  private static int 퓏([In] TimeInForce obj0)
  {
    int num;
    switch (obj0)
    {
      case TimeInForce.Day:
        num = 1;
        break;
      case TimeInForce.GTC:
        num = 0;
        break;
      default:
        num = 10;
        break;
    }
    return num;
  }
}
