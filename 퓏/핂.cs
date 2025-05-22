// Decompiled with JetBrains decompiler
// Type: 퓏.핂
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer;
using TradingPlatform.BusinessLayer.Integration;

#nullable disable
namespace 퓏;

internal static class 핂
{
  public static (double ask, double bid, double askSize, double BidSize, DateTime QuoteDateTime) 퓏(
    [In] double[] obj0,
    [In] double[] obj1,
    [In] double[] obj2,
    [In] double[] obj3,
    [In] double[] obj4,
    [In] DateTime[] obj5,
    [In] SyntheticPriceModifier obj6)
  {
    if (obj0 == null || obj0.Length == 0)
      return (double.NaN, double.NaN, double.NaN, double.NaN, DateTime.MinValue);
    double num1 = 0.0;
    double num2 = 0.0;
    double num3 = obj3[0];
    double num4 = obj4[0];
    DateTime dateTime = obj5[0];
    for (int index = 0; index < obj0.Length; ++index)
    {
      if (obj1[index].IsNanOrDefault() && obj2[index].IsNanOrDefault())
        return (double.NaN, double.NaN, double.NaN, double.NaN, DateTime.MinValue);
      num1 += obj6.CalculatePrice(obj0[index], obj0[index] > 0.0 ? obj1[index] : obj2[index]);
      num2 += obj6.CalculatePrice(obj0[index], obj0[index] > 0.0 ? obj2[index] : obj1[index]);
      if (obj0[index] > 0.0)
      {
        if (obj3[index] < num3)
          num3 = obj3[index];
        if (obj4[index] < num4)
          num4 = obj4[index];
      }
      else
      {
        if (obj3[index] < num4)
          num4 = obj3[index];
        if (obj4[index] < num3)
          num3 = obj4[index];
      }
      if (obj5[index] > dateTime)
        dateTime = obj5[index];
    }
    return (num1, num2, num3, num4, dateTime);
  }

  public static (double last, double lastSize, DateTime LastDateTime) 퓏(
    [In] double[] obj0,
    [In] double[] obj1,
    [In] double[] obj2,
    [In] DateTime[] obj3,
    [In] SyntheticPriceModifier obj4)
  {
    if (obj0 == null || obj0.Length == 0)
      return (double.NaN, double.NaN, DateTime.MinValue);
    double num1 = 0.0;
    double num2 = obj2[0];
    DateTime dateTime = obj3[0];
    for (int index = 0; index < obj0.Length; ++index)
    {
      if (obj1[index].IsNanOrDefault())
        return (double.NaN, double.NaN, DateTime.MinValue);
      num1 += obj4.CalculatePrice(obj0[index], obj1[index]);
      if (obj2[index] < num2)
        num2 = obj2[index];
      if (obj3[index] > dateTime)
        dateTime = obj3[index];
    }
    return (num1, num2, dateTime);
  }

  public static (double mark, double markSize, DateTime markDateTime) 퓬(
    [In] double[] obj0,
    [In] double[] obj1,
    [In] double[] obj2,
    [In] DateTime[] obj3,
    [In] SyntheticPriceModifier obj4)
  {
    if (obj0 == null || obj0.Length == 0)
      return (double.NaN, double.NaN, DateTime.MinValue);
    double num1 = 0.0;
    double num2 = obj2[0];
    DateTime dateTime = obj3[0];
    for (int index = 0; index < obj0.Length; ++index)
    {
      if (obj1[index].IsNanOrDefault())
        return (double.NaN, double.NaN, DateTime.MinValue);
      num1 += obj4.CalculatePrice(obj0[index], obj1[index]);
      if (obj2[index] < num2)
        num2 = obj2[index];
      if (obj3[index] > dateTime)
        dateTime = obj3[index];
    }
    return (num1, num2, dateTime);
  }

  public static (Level2Quote[] quotes, DateTime Time) 퓏(
    [In] double[] obj0_1,
    [In] QuotePriceType obj1,
    [In] string obj2,
    [In] Level2Item[][] obj3,
    [In] SyntheticPriceModifier obj4)
  {
    try
    {
      if (obj3 == null)
        return ((Level2Quote[]) null, DateTime.MinValue);
      핂.퓏[] source = new 핂.퓏[obj0_1.Length];
      for (int index = 0; index < source.Length; ++index)
        source[index] = new 핂.퓏(obj3[index]);
      List<Level2Quote> level2QuoteList1 = new List<Level2Quote>();
      bool flag = false;
      do
      {
        double num1 = 0.0;
        for (int index = 0; index < obj0_1.Length; ++index)
          num1 += obj4.CalculatePrice(obj0_1[index], source[index].PriceOnCurrentLevel);
        double num2 = ((IEnumerable<핂.퓏>) source).Min<핂.퓏>((Func<핂.퓏, double>) (([In] obj0_2) => obj0_2.SizeOnCurrentLevel));
        List<Level2Quote> level2QuoteList2 = level2QuoteList1;
        int priceType = (int) obj1;
        string symbolId = obj2;
        string str1 = obj1.ToString();
        int index1 = level2QuoteList1.Count;
        string str2 = index1.ToString();
        string id = str1 + str2;
        double price = num1;
        double size = num2;
        DateTime dateTimeUtcNow = Core.Instance.TimeUtils.DateTimeUtcNow;
        Level2Quote level2Quote = new Level2Quote((QuotePriceType) priceType, symbolId, id, price, size, dateTimeUtcNow);
        level2QuoteList2.Add(level2Quote);
        핂.퓏[] 퓏Array = source;
        for (index1 = 0; index1 < 퓏Array.Length; ++index1)
        {
          if (!퓏Array[index1].퓏(num2))
          {
            flag = true;
            break;
          }
        }
      }
      while (!flag);
      return (level2QuoteList1.ToArray(), DateTime.MinValue);
    }
    catch
    {
      return ((Level2Quote[]) null, DateTime.MinValue);
    }
  }

  public static (double open, double high, double low, double close, DateTime QuoteDateTime) 퓬(
    [In] double[] obj0,
    [In] double[] obj1,
    [In] double[] obj2,
    [In] double[] obj3,
    [In] double[] obj4,
    [In] DateTime[] obj5,
    [In] SyntheticPriceModifier obj6)
  {
    if (obj0 == null || obj0.Length == 0)
      return (0.0, 0.0, 0.0, 0.0, DateTime.MinValue);
    double num1 = 0.0;
    double num2 = 0.0;
    double num3 = 0.0;
    double num4 = 0.0;
    DateTime dateTime = obj5[0];
    for (int index = 0; index < obj0.Length; ++index)
    {
      num1 += obj6.CalculatePrice(obj0[index], obj1[index]);
      num2 += obj6.CalculatePrice(obj0[index], obj2[index]);
      num3 += obj6.CalculatePrice(obj0[index], obj3[index]);
      num4 += obj6.CalculatePrice(obj0[index], obj4[index]);
      if (obj5[index] > dateTime)
        dateTime = obj5[index];
    }
    return (num1, num2, num3, num4, dateTime);
  }

  public static IHistoryItem 퓏([In] double[] obj0, [In] IHistoryItem[] obj1, [In] SyntheticPriceModifier obj2)
  {
    if (obj1 == null)
      return (IHistoryItem) null;
    if (obj1.Length == 0)
      return (IHistoryItem) null;
    IHistoryItem historyItem = obj1[0];
    if ((object) (historyItem as HistoryItemBar) == null)
    {
      if ((object) (historyItem as HistoryItemTick) == null)
      {
        if ((object) (historyItem as HistoryItemLast) == null)
          return (IHistoryItem) null;
        double num1 = 0.0;
        double num2 = 0.0;
        long num3 = long.MinValue;
        for (int index = 0; index < obj0.Length; ++index)
        {
          HistoryItemLast historyItemLast = (HistoryItemLast) obj1[index];
          num1 += obj2.CalculatePrice(obj0[index], historyItemLast.Price);
          if (historyItemLast.TicksLeft > num3)
            num3 = historyItemLast.TicksLeft;
        }
        HistoryItemLast historyItemLast1 = new HistoryItemLast();
        historyItemLast1.Price = num1;
        historyItemLast1.Volume = num2;
        historyItemLast1.TicksLeft = num3;
        return (IHistoryItem) historyItemLast1;
      }
      double num4 = 0.0;
      double num5 = 0.0;
      double num6 = 0.0;
      double num7 = 0.0;
      long num8 = long.MinValue;
      for (int index = 0; index < obj0.Length; ++index)
      {
        HistoryItemTick historyItemTick = (HistoryItemTick) obj1[index];
        num4 += obj2.CalculatePrice(obj0[index], obj0[index] > 0.0 ? historyItemTick.Bid : historyItemTick.Ask);
        num5 += obj2.CalculatePrice(obj0[index], obj0[index] > 0.0 ? historyItemTick.Ask : historyItemTick.Bid);
        if (historyItemTick.TicksLeft > num8)
          num8 = historyItemTick.TicksLeft;
      }
      HistoryItemTick historyItemTick1 = new HistoryItemTick();
      historyItemTick1.Bid = num4;
      historyItemTick1.Ask = num5;
      historyItemTick1.AskSize = num7;
      historyItemTick1.BidSize = num6;
      historyItemTick1.TicksLeft = num8;
      return (IHistoryItem) historyItemTick1;
    }
    double num9 = 0.0;
    double num10 = 0.0;
    double num11 = 0.0;
    double num12 = 0.0;
    double num13 = 0.0;
    int num14 = 0;
    long num15 = long.MinValue;
    long num16 = long.MinValue;
    for (int index = 0; index < obj0.Length; ++index)
    {
      HistoryItemBar historyItemBar = (HistoryItemBar) obj1[index];
      num9 += obj2.CalculatePrice(obj0[index], historyItemBar.Open);
      num11 += obj2.CalculatePrice(obj0[index], historyItemBar.High);
      num12 += obj2.CalculatePrice(obj0[index], historyItemBar.Low);
      num10 += obj2.CalculatePrice(obj0[index], historyItemBar.Close);
      if (historyItemBar.TicksLeft > num15)
      {
        num15 = historyItemBar.TicksLeft;
        num16 = historyItemBar.TicksRight;
      }
    }
    double[] source = new double[4]
    {
      num9,
      num11,
      num12,
      num10
    };
    HistoryItemBar historyItemBar1 = new HistoryItemBar();
    historyItemBar1.Open = num9;
    historyItemBar1.High = ((IEnumerable<double>) source).Max();
    historyItemBar1.Low = ((IEnumerable<double>) source).Min();
    historyItemBar1.Close = num10;
    historyItemBar1.Volume = num13;
    historyItemBar1.Ticks = (long) num14;
    historyItemBar1.TicksLeft = num15;
    historyItemBar1.TicksRight = num16;
    return (IHistoryItem) historyItemBar1;
  }

  internal class 퓏
  {
    private readonly List<Level2Item> 픂핆;
    private int 픂픷;
    private double 픂퓻;

    private bool HasNextLevel => this.픂픷 < this.픂핆.Count - 1;

    public double PriceOnCurrentLevel => this.픂픷 >= this.픂핆.Count ? 0.0 : this.픂핆[this.픂픷].Price;

    public double SizeOnCurrentLevel
    {
      get => this.픂픷 >= this.픂핆.Count ? 0.0 : this.픂핆[this.픂픷].Size - this.픂퓻;
    }

    public 퓏([In] Level2Item[] obj0)
    {
      this.픂핆 = new List<Level2Item>((IEnumerable<Level2Item>) obj0);
    }

    public bool 퓏([In] double obj0)
    {
      double num = obj0;
      do
      {
        if (this.SizeOnCurrentLevel > num)
        {
          this.픂퓻 += num;
          num = 0.0;
        }
        else
        {
          num -= this.SizeOnCurrentLevel;
          if (!this.HasNextLevel)
            return false;
          ++this.픂픷;
          this.픂퓻 = 0.0;
        }
      }
      while (num > 0.0);
      return true;
    }
  }
}
