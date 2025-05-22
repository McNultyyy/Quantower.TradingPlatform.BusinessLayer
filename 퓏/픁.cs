// Decompiled with JetBrains decompiler
// Type: 퓏.픁
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Collections.Generic;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer;

#nullable disable
namespace 퓏;

internal class 픁 : IComparer<Level2Item>
{
  private readonly bool 픯;

  public 픁([In] bool obj0) => this.픯 = obj0;

  public int Compare(Level2Item x, Level2Item y)
  {
    double price1 = x.Price;
    double size1 = x.Size;
    long ticks1 = x.QuoteTime.Ticks;
    double price2 = y.Price;
    double size2 = y.Size;
    long ticks2 = y.QuoteTime.Ticks;
    double num1 = price2;
    double num2 = price1 - num1;
    if (num2 <= -1E-12)
      return !this.픯 ? -1 : 1;
    if (num2 >= 1E-12)
      return !this.픯 ? 1 : -1;
    if (ticks1 > ticks2)
      return 1;
    if (ticks1 < ticks2 || size1 > size2)
      return -1;
    return size1 < size2 ? 1 : string.CompareOrdinal(x.MMID, y.MMID);
  }
}
