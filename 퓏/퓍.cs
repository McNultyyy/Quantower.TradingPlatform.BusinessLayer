// Decompiled with JetBrains decompiler
// Type: 퓏.퓍
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer;
using TradingPlatform.BusinessLayer.Integration;

#nullable enable
namespace 퓏;

internal sealed class 퓍
{
  private readonly 
  #nullable disable
  object 퓹;
  private readonly QuotePriceType 퓛;
  private readonly 픁 픝;
  private readonly Func<Decimal, Decimal, Decimal> 픻;
  private Dictionary<int, Level2Item[]> 퓤;
  private readonly bool 픮;

  internal Dictionary<string, Level2Quote> Items { get; [param: In] private set; }

  internal 퓍([In] QuotePriceType obj0, [In] bool obj1)
  {
    this.퓛 = obj0;
    this.픮 = obj1;
    this.픝 = new 픁(this.퓛 == QuotePriceType.Bid);
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    this.픻 = 퓍.퓏.픂픕 ?? (퓍.퓏.픂픕 = new Func<Decimal, Decimal, Decimal>(퓍.퓬));
    this.Items = new Dictionary<string, Level2Quote>();
    this.퓤 = new Dictionary<int, Level2Item[]>();
    this.퓹 = new object();
  }

  internal void 퓏()
  {
    lock (this.퓹)
    {
      this.Items.Clear();
      this.퓤.Clear();
    }
  }

  internal Level2Item[] 퓏(GetLevel2ItemsParameters _param1 = null)
  {
    if (_param1 == (GetLevel2ItemsParameters) null)
      _param1 = new GetLevel2ItemsParameters();
    lock (this.퓹)
    {
      int hashCode = _param1.GetHashCode();
      Level2Item[] level2ItemArray;
      if (!this.퓤.TryGetValue(hashCode, out level2ItemArray))
      {
        level2ItemArray = this.퓬(_param1);
        this.퓤[hashCode] = level2ItemArray;
      }
      return level2ItemArray;
    }
  }

  internal void 퓏([In] Level2Quote obj0)
  {
    lock (this.퓹)
    {
      if (obj0.Closed)
        this.Items.Remove(obj0.Id);
      else
        this.Items[obj0.Id] = obj0;
      this.퓤 = new Dictionary<int, Level2Item[]>();
    }
  }

  internal void 퓏([In] IEnumerable<Level2Quote> obj0_1)
  {
    lock (this.퓹)
    {
      this.Items = obj0_1.ToDictionary<Level2Quote, string, Level2Quote>((Func<Level2Quote, string>) (([In] obj0_2) => obj0_2.Id), (Func<Level2Quote, Level2Quote>) (([In] obj0_3) => obj0_3));
      this.퓤 = new Dictionary<int, Level2Item[]>();
    }
  }

  private Level2Item[] 퓬([In] GetLevel2ItemsParameters obj0_1)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    퓍.핇 핇 = new 퓍.핇();
    // ISSUE: reference to a compiler-generated field
    핇.픂픵 = this;
    // ISSUE: reference to a compiler-generated field
    핇.픂픬 = obj0_1;
    Dictionary<string, Level2Quote>.ValueCollection values = this.Items.Values;
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    bool flag = 핇.픂픬.CustomTickSize > 0.0 && !핇.픂픬.CustomTickSize.IsNanOrDefault();
    // ISSUE: reference to a compiler-generated field
    int aggregateMethod = (int) 핇.픂픬.AggregateMethod;
    if (this.픮)
    {
      int num = flag ? 1 : 0;
    }
    Func<Level2Quote, double> func;
    // ISSUE: reference to a compiler-generated field
    switch (핇.픂픬.ImplicitOrderBookType)
    {
      case ImplicitOrderBookType.Implied:
        func = (Func<Level2Quote, double>) (([In] obj0_2) => obj0_2.ImpliedSize);
        break;
      case ImplicitOrderBookType.Outright:
        func = (Func<Level2Quote, double>) (([In] obj0_3) => obj0_3.Size - obj0_3.ImpliedSize);
        break;
      default:
        func = (Func<Level2Quote, double>) (([In] obj0_4) => obj0_4.Size);
        break;
    }
    // ISSUE: reference to a compiler-generated field
    핇.픂퓕 = func;
    IEnumerable<Level2Item> source1;
    // ISSUE: reference to a compiler-generated field
    switch (핇.픂픬.AggregateMethod)
    {
      case AggregateMethod.ByPriceLVL:
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        source1 = (flag ? values.GroupBy<Level2Quote, double>(new Func<Level2Quote, double>(핇.퓏)) : values.GroupBy<Level2Quote, double>((Func<Level2Quote, double>) (([In] obj0_5) => obj0_5.Price))).Select<IGrouping<double, Level2Quote>, Level2Item>(new Func<IGrouping<double, Level2Quote>, Level2Item>(핇.퓏));
        break;
      default:
        // ISSUE: reference to a compiler-generated method
        source1 = values.Select<Level2Quote, Level2Item>(new Func<Level2Quote, Level2Item>(핇.퓲));
        break;
    }
    IEnumerable<Level2Item> source2 = (IEnumerable<Level2Item>) source1.OrderBy<Level2Item, Level2Item>((Func<Level2Item, Level2Item>) (([In] obj0_6) => obj0_6), (IComparer<Level2Item>) this.픝);
    // ISSUE: reference to a compiler-generated field
    if (핇.픂픬.LevelsCount > 0)
    {
      // ISSUE: reference to a compiler-generated field
      source2 = source2.Take<Level2Item>(핇.픂픬.LevelsCount);
    }
    // ISSUE: reference to a compiler-generated field
    if (핇.픂픬.CalculateCumulative)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      source2 = source2.Select<Level2Item, Level2Item>(new Func<Level2Item, Level2Item>(new 퓍.퓲()
      {
        픂픔 = 0.0
      }.퓏));
    }
    return source2.ToArray<Level2Item>();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static Decimal 퓏([In] Decimal obj0, [In] Decimal obj1) => obj0 - obj0 % obj1;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static Decimal 퓬([In] Decimal obj0, [In] Decimal obj1)
  {
    Decimal num = 퓍.퓏(obj0, obj1);
    return num == obj0 ? obj0 : num + obj1;
  }
}
