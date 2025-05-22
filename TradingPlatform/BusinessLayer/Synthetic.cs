// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Synthetic
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using TradingPlatform.BusinessLayer.Integration;
using TradingPlatform.BusinessLayer.Utils;
using 퓏;

#nullable enable
namespace TradingPlatform.BusinessLayer;

public sealed class Synthetic : CustomSymbol, ICustomizable
{
  public const 
  #nullable disable
  string SYNTHETIC_CONNECTION_ID = "CUSTOM_SYMBOL_CONNECTION";
  private List<OrderType> 핅픾;
  private readonly object 핅퓍;
  private readonly ConnectionStateObserver 핅픁;
  private bool 핅픞;
  private bool 핅핁;

  public override Connection Connection
  {
    get
    {
      ReadOnlyCollection<SyntheticItem> items = this.Items;
      if (items == null)
        return (Connection) null;
      return items.FirstOrDefault<SyntheticItem>()?.Symbol?.Connection;
    }
  }

  public event Action<Synthetic> Reinitialized;

  public override BusinessObjectState State
  {
    get
    {
      return this.SyntheticState != SyntheticState.Initialized ? BusinessObjectState.Fake : base.State;
    }
    protected internal set => base.State = value;
  }

  public string[] LegsConnectionsIds
  {
    get
    {
      return this.Items.Select<SyntheticItem, string>((Func<SyntheticItem, string>) (([In] obj0) => obj0.Symbol.ConnectionId)).Distinct<string>().ToArray<string>();
    }
  }

  public SyntheticPriceModifierType PriceModifierType
  {
    get
    {
      SyntheticPriceModifier priceModifier = this.PriceModifier;
      return priceModifier == null ? SyntheticPriceModifierType.Undefined : priceModifier.Type;
    }
    set
    {
      SyntheticPriceModifier priceModifier = this.PriceModifier;
      if ((priceModifier != null ? (priceModifier.Type == value ? 1 : 0) : 0) != 0)
        return;
      this.PriceModifier = SyntheticPriceModifier.Create(value);
    }
  }

  public ReadOnlyCollection<SyntheticItem> Items { get; [param: In] private set; }

  public SyntheticState SyntheticState { get; [param: In] private set; }

  public SyntheticPriceModifier PriceModifier { get; [param: In] private set; }

  public bool ForceUseTicksForHistory { get; set; }

  public Synthetic(string name, SyntheticPriceModifierType priceModifierType)
    : base(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픖())
  {
    this.핅퓍 = new object();
    this.핅픾 = new List<OrderType>();
    this.ForceUseTicksForHistory = false;
    this.PriceModifierType = priceModifierType;
    this.Items = new ReadOnlyCollection<SyntheticItem>((IList<SyntheticItem>) Array.Empty<SyntheticItem>());
    this.SyntheticState = SyntheticState.NotInitialized;
    this.Name = name;
    Core.Instance.퓏(new Action(this.핂));
    this.핅픁 = new ConnectionStateObserver((IConnectionStateDependent) this, ConnectionStateObserverPriority.High, new ConnectionState[3]
    {
      ConnectionState.Connected,
      ConnectionState.Disconnected,
      ConnectionState.ConnectionLost
    });
  }

  public Synthetic(
    string name,
    SyntheticPriceModifierType priceModifierType,
    IEnumerable<SyntheticItem> items)
    : this(name, priceModifierType)
  {
    this.Reinitialize(items);
  }

  public Synthetic(string name, Synthetic origin)
    : this(name, origin.PriceModifierType, (IEnumerable<SyntheticItem>) origin.Items)
  {
  }

  public void Rename(string newName)
  {
    this.Name = !string.IsNullOrEmpty(newName) ? newName : throw new ArgumentException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픭());
    // ISSUE: reference to a compiler-generated field
    Action<Synthetic> 핅퓬 = this.핅퓬;
    if (핅퓬 != null)
      핅퓬(this);
    base.퓬();
  }

  public void RenameGroup(string groupName)
  {
    if (string.IsNullOrEmpty(groupName))
    {
      this.Group = (SymbolGroup) null;
    }
    else
    {
      if (this.Group == null)
      {
        SymbolGroup symbolGroup;
        this.Group = symbolGroup = new SymbolGroup(this.ConnectionId);
      }
      this.Group.퓏(new MessageSymbolGroup()
      {
        GroupName = groupName,
        Id = groupName,
        SortIndex = 0
      });
    }
    // ISSUE: reference to a compiler-generated field
    Action<Synthetic> 핅퓬 = this.핅퓬;
    if (핅퓬 != null)
      핅퓬(this);
    base.퓬();
  }

  public void Reinitialize(IEnumerable<SyntheticItem> newItems)
  {
    if (newItems == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픔());
    try
    {
      lock (this.핅퓍)
      {
        this.SyntheticState = SyntheticState.NotInitialized;
        this.퓏();
        base.퓏();
        MessageSymbol messageSymbol1 = new MessageSymbol(this.Id);
        messageSymbol1.Name = this.Name;
        messageSymbol1.SymbolType = SymbolType.Synthetic;
        messageSymbol1.QuotingType = SymbolQuotingType.Undefined;
        messageSymbol1.MinLot = 1.0;
        messageSymbol1.LotStep = 1.0;
        messageSymbol1.LotSize = 1.0;
        messageSymbol1.VolumeType = SymbolVolumeType.Disable;
        messageSymbol1.NettingType = NettingType.Undefined;
        messageSymbol1.AllowCalculateRealtimeChange = true;
        messageSymbol1.AllowCalculateRealtimeTicks = false;
        messageSymbol1.AllowCalculateRealtimeTrades = false;
        messageSymbol1.AllowCalculateRealtimeVolume = false;
        MessageSymbol messageSymbol2 = messageSymbol1;
        this.퓏(messageSymbol2);
        if (!newItems.Any<SyntheticItem>() || newItems.Any<SyntheticItem>((Func<SyntheticItem, bool>) (([In] obj0) => obj0.Symbol == null)) || newItems.Any<SyntheticItem>((Func<SyntheticItem, bool>) (([In] obj0) => obj0.Symbol.State == BusinessObjectState.Fake)))
          return;
        this.Items = new ReadOnlyCollection<SyntheticItem>((IList<SyntheticItem>) newItems.Select<SyntheticItem, SyntheticItem>((Func<SyntheticItem, SyntheticItem>) (([In] obj0) => new SyntheticItem(obj0))).ToArray<SyntheticItem>());
        StringBuilder stringBuilder1 = new StringBuilder();
        double num = double.MinValue;
        double d = double.MaxValue;
        bool flag1 = true;
        bool flag2 = true;
        TimeSpan timeSpan = TimeSpan.MaxValue;
        double tickSize = double.MaxValue;
        foreach (SyntheticItem syntheticItem in this.Items)
        {
          if (stringBuilder1.Length < 100)
          {
            StringBuilder stringBuilder2 = stringBuilder1;
            StringBuilder stringBuilder3 = stringBuilder2;
            StringBuilder.AppendInterpolatedStringHandler interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(5, 2, stringBuilder2);
            interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎핈());
            interpolatedStringHandler.AppendFormatted(syntheticItem.Symbol.FormatQuantity(syntheticItem.Coefficient));
            interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픷());
            interpolatedStringHandler.AppendFormatted(syntheticItem.Symbol.Name);
            interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픤());
            ref StringBuilder.AppendInterpolatedStringHandler local = ref interpolatedStringHandler;
            stringBuilder3.Append(ref local);
          }
          if (syntheticItem.Symbol.MinLot > num)
            num = syntheticItem.Symbol.MinLot;
          if (syntheticItem.Symbol.MaxLot < d)
            d = syntheticItem.Symbol.MaxLot;
          if (syntheticItem.Symbol.HistoryType != HistoryType.Last)
            flag1 = false;
          if (syntheticItem.Symbol.HistoryType != HistoryType.Mark)
            flag2 = false;
          if (syntheticItem.Symbol.TickSize < tickSize)
            tickSize = syntheticItem.Symbol.TickSize;
          if (syntheticItem.Symbol.QuoteDelay < timeSpan)
            timeSpan = syntheticItem.Symbol.QuoteDelay;
        }
        if (this.PriceModifierType == SyntheticPriceModifierType.Ln)
          tickSize = 1E-05;
        messageSymbol2.Description = stringBuilder1.ToString().TrimEnd('+', ' ');
        messageSymbol2.QuoteDelay = timeSpan;
        messageSymbol2.VariableTickList = new List<VariableTick>()
        {
          new VariableTick(tickSize)
        };
        messageSymbol2.MaxLot = Math.Floor(d);
        messageSymbol2.HistoryType = flag1 ? HistoryType.Last : (flag2 ? HistoryType.Mark : HistoryType.Bid);
        this.퓏(messageSymbol2);
        bool flag3 = this.Items.All<SyntheticItem>((Func<SyntheticItem, bool>) (([In] obj0_1) =>
        {
          List<OrderType> alowedOrderTypes = obj0_1.Symbol.GetAlowedOrderTypes(new OrderTypeUsage?(OrderTypeUsage.Order));
          return (alowedOrderTypes != null ? alowedOrderTypes.FirstOrDefault<OrderType>((Func<OrderType, bool>) (([In] obj0_2) => obj0_2.Behavior == OrderTypeBehavior.Market)) : (OrderType) null) != null;
        }));
        if (((퓏.픾) this).Rules[\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핂()] is 픨<bool> rule)
          rule.퓏(new MessageRule()
          {
            Value = (object) flag3
          });
        if (flag3)
        {
          TimeInForce[] source = this.Items.Select<SyntheticItem, TimeInForce[]>((Func<SyntheticItem, TimeInForce[]>) (([In] obj0) => obj0.Symbol.GetAlowedOrderTypes(new OrderTypeUsage?(OrderTypeUsage.Order)).First<OrderType>((Func<OrderType, bool>) (([In] obj0) => obj0.Behavior == OrderTypeBehavior.Market)).AllowedTifs)).Cast<IEnumerable<TimeInForce>>().Aggregate<IEnumerable<TimeInForce>>((Func<IEnumerable<TimeInForce>, IEnumerable<TimeInForce>, IEnumerable<TimeInForce>>) (([In] obj0, [In] obj1) => obj0.Intersect<TimeInForce>(obj1))).ToArray<TimeInForce>();
          if (!((IEnumerable<TimeInForce>) source).Any<TimeInForce>())
            source = new TimeInForce[1];
          this.핅픾 = new List<OrderType>()
          {
            (OrderType) new MarketOrderType(((IEnumerable<TimeInForce>) source).ToArray<TimeInForce>())
          };
        }
        else
          this.핅픾 = new List<OrderType>()
          {
            (OrderType) new MarketOrderType(new TimeInForce[1])
          };
        this.historyMetadata = new HistoryMetadata()
        {
          AllowedAggregations = this.Items.SelectMany<SyntheticItem, string>((Func<SyntheticItem, IEnumerable<string>>) (([In] obj0) => (IEnumerable<string>) obj0.Symbol.HistoryMetadata.AllowedAggregations)).Distinct<string>().ToArray<string>(),
          AllowedPeriodsHistoryAggregationTime = this.Items.SelectMany<SyntheticItem, Period>((Func<SyntheticItem, IEnumerable<Period>>) (([In] obj0) => (IEnumerable<Period>) obj0.Symbol.HistoryMetadata.AllowedPeriodsHistoryAggregationTime)).Distinct<Period>().ToArray<Period>(),
          AllowedHistoryTypesHistoryAggregationTime = this.Items.SelectMany<SyntheticItem, HistoryType>((Func<SyntheticItem, IEnumerable<HistoryType>>) (([In] obj0) => (IEnumerable<HistoryType>) obj0.Symbol.HistoryMetadata.AllowedHistoryTypesHistoryAggregationTime)).Distinct<HistoryType>().ToArray<HistoryType>(),
          AllowedHistoryTypesHistoryAggregationTick = this.Items.SelectMany<SyntheticItem, HistoryType>((Func<SyntheticItem, IEnumerable<HistoryType>>) (([In] obj0) => (IEnumerable<HistoryType>) obj0.Symbol.HistoryMetadata.AllowedHistoryTypesHistoryAggregationTick)).Distinct<HistoryType>().ToArray<HistoryType>()
        };
        foreach (SyntheticItem syntheticItem in this.Items)
        {
          syntheticItem.Symbol.NewQuote += new QuoteHandler(this.퓏);
          syntheticItem.Symbol.NewLast += new LastHandler(this.퓏);
          syntheticItem.Symbol.NewMark += new MarkHandler(this.퓏);
          syntheticItem.Symbol.NewLevel2 += new Level2Handler(this.퓏);
          syntheticItem.Symbol.NewDayBar += new DayBarHandler(this.퓏);
        }
        this.퓲();
        this.SyntheticState = SyntheticState.Initialized;
        this.핅픞 = true;
      }
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
  }

  public override void Dispose()
  {
    this.핅픁.Dispose();
    this.퓏();
    this.SyntheticState = SyntheticState.NotInitialized;
    base.Dispose();
  }

  private new void 퓏()
  {
    try
    {
      foreach (SyntheticItem syntheticItem in this.Items)
      {
        syntheticItem.Symbol.NewQuote -= new QuoteHandler(this.퓏);
        syntheticItem.Symbol.NewLast -= new LastHandler(this.퓏);
        syntheticItem.Symbol.NewMark -= new MarkHandler(this.퓏);
        syntheticItem.Symbol.NewLevel2 -= new Level2Handler(this.퓏);
        syntheticItem.Symbol.NewDayBar -= new DayBarHandler(this.퓏);
      }
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
  }

  protected internal override void SubscribeAction(SubscribeQuoteType type)
  {
  }

  protected internal override void UnSubscribeAction(SubscribeQuoteType type)
  {
  }

  private new void 퓬()
  {
    try
    {
      ReadOnlyCollection<SyntheticItem> items = this.Items;
      // ISSUE: explicit non-virtual call
      if ((items != null ? (__nonvirtual (items.Count) == 0 ? 1 : 0) : 0) != 0)
        return;
      int count = this.Items.Count;
      double[] numArray = new double[count];
      Level2Item[][] level2ItemArray1 = new Level2Item[count][];
      Level2Item[][] level2ItemArray2 = new Level2Item[count][];
      DateTime dateTimeUtcNow = Core.Instance.TimeUtils.DateTimeUtcNow;
      for (int index1 = 0; index1 < this.Items.Count; ++index1)
      {
        SyntheticItem syntheticItem = this.Items[index1];
        SessionsContainer currentSessionsInfo = syntheticItem.Symbol.CurrentSessionsInfo;
        if ((currentSessionsInfo != null ? (!currentSessionsInfo.ContainsDate(dateTimeUtcNow) ? 1 : 0) : 0) != 0)
          return;
        numArray[index1] = syntheticItem.Coefficient;
        DepthOfMarketAggregatedCollections aggregatedCollections = syntheticItem.Symbol.DepthOfMarket.GetDepthOfMarketAggregatedCollections();
        if (syntheticItem.Coefficient > 0.0)
        {
          level2ItemArray2[index1] = new Level2Item[aggregatedCollections.Bids.Length];
          for (int index2 = 0; index2 < aggregatedCollections.Bids.Length; ++index2)
            level2ItemArray2[index1][index2] = aggregatedCollections.Bids[index2];
        }
        else
        {
          level2ItemArray2[index1] = new Level2Item[aggregatedCollections.Asks.Length];
          for (int index3 = 0; index3 < aggregatedCollections.Asks.Length; ++index3)
            level2ItemArray2[index1][index3] = aggregatedCollections.Asks[index3];
        }
        if (syntheticItem.Coefficient > 0.0)
        {
          level2ItemArray1[index1] = new Level2Item[aggregatedCollections.Asks.Length];
          for (int index4 = 0; index4 < aggregatedCollections.Asks.Length; ++index4)
            level2ItemArray1[index1][index4] = aggregatedCollections.Asks[index4];
        }
        else
        {
          level2ItemArray1[index1] = new Level2Item[aggregatedCollections.Bids.Length];
          for (int index5 = 0; index5 < aggregatedCollections.Bids.Length; ++index5)
            level2ItemArray1[index1][index5] = aggregatedCollections.Bids[index5];
        }
      }
      (Level2Quote[] quotes, DateTime Time) tuple1 = 퓏.핂.퓏(numArray, QuotePriceType.Bid, this.Id, level2ItemArray2, this.PriceModifier);
      (Level2Quote[] quotes, DateTime Time) tuple2 = 퓏.핂.퓏(numArray, QuotePriceType.Ask, this.Id, level2ItemArray1, this.PriceModifier);
      DOMQuote domQuote = new DOMQuote(this.Id, dateTimeUtcNow);
      foreach (Level2Quote level2Quote in tuple1.quotes)
        domQuote.Bids.Add(new Level2Quote(level2Quote.PriceType, level2Quote.SymbolId, level2Quote.Id, this.RoundPriceToTickSize(level2Quote.Price), level2Quote.Size, level2Quote.Time));
      foreach (Level2Quote level2Quote in tuple2.quotes)
        domQuote.Asks.Add(new Level2Quote(level2Quote.PriceType, level2Quote.SymbolId, level2Quote.Id, this.RoundPriceToTickSize(level2Quote.Price), level2Quote.Size, level2Quote.Time));
      this.퓏((MessageQuote) domQuote);
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
  }

  private void 핇()
  {
    ReadOnlyCollection<SyntheticItem> items = this.Items;
    // ISSUE: explicit non-virtual call
    if ((items != null ? (__nonvirtual (items.Count) == 0 ? 1 : 0) : 0) != 0)
      return;
    int count = this.Items.Count;
    double[] numArray1 = new double[count];
    double[] numArray2 = new double[count];
    double[] numArray3 = new double[count];
    double[] numArray4 = new double[count];
    double[] numArray5 = new double[count];
    DateTime[] dateTimeArray = new DateTime[count];
    for (int index = 0; index < this.Items.Count; ++index)
    {
      SyntheticItem syntheticItem = this.Items[index];
      numArray1[index] = syntheticItem.Coefficient;
      numArray2[index] = syntheticItem.Symbol.Open;
      numArray3[index] = syntheticItem.Symbol.High;
      numArray4[index] = syntheticItem.Symbol.Low;
      numArray5[index] = syntheticItem.Symbol.PrevClose;
      dateTimeArray[index] = syntheticItem.Symbol.QuoteDateTime;
    }
    (double open, double high, double low, double close, DateTime QuoteDateTime) tuple = 퓏.핂.퓬(numArray1, numArray2, numArray3, numArray4, numArray5, dateTimeArray, this.PriceModifier);
    this.퓏((MessageQuote) new DayBar(this.Name, tuple.QuoteDateTime)
    {
      Open = tuple.open,
      High = tuple.high,
      Low = tuple.low,
      PreviousClose = tuple.close
    });
  }

  private void 퓲()
  {
    ReadOnlyCollection<SyntheticItem> items = this.Items;
    // ISSUE: explicit non-virtual call
    if ((items != null ? (__nonvirtual (items.Count) == 0 ? 1 : 0) : 0) != 0)
      return;
    int count = this.Items.Count;
    double[] numArray1 = new double[count];
    double[] numArray2 = new double[count];
    double[] numArray3 = new double[count];
    double[] numArray4 = new double[count];
    double[] numArray5 = new double[count];
    double[] numArray6 = new double[count];
    double[] numArray7 = new double[count];
    double[] numArray8 = new double[count];
    double[] numArray9 = new double[count];
    double[] numArray10 = new double[count];
    double[] numArray11 = new double[count];
    double[] numArray12 = new double[count];
    double[] numArray13 = new double[count];
    DateTime[] dateTimeArray = new DateTime[count];
    for (int index = 0; index < this.Items.Count; ++index)
    {
      SyntheticItem syntheticItem = this.Items[index];
      numArray1[index] = syntheticItem.Coefficient;
      numArray2[index] = syntheticItem.Symbol.Ask;
      numArray3[index] = syntheticItem.Symbol.Bid;
      numArray4[index] = syntheticItem.Symbol.AskSize;
      numArray5[index] = syntheticItem.Symbol.BidSize;
      numArray6[index] = syntheticItem.Symbol.Last;
      numArray7[index] = syntheticItem.Symbol.LastSize;
      numArray8[index] = syntheticItem.Symbol.Mark;
      numArray9[index] = syntheticItem.Symbol.MarkSize;
      numArray10[index] = syntheticItem.Symbol.Open;
      numArray11[index] = syntheticItem.Symbol.High;
      numArray12[index] = syntheticItem.Symbol.Low;
      numArray13[index] = syntheticItem.Symbol.PrevClose;
      dateTimeArray[index] = syntheticItem.Symbol.QuoteDateTime;
    }
    (double ask, double bid, double askSize, double BidSize, DateTime QuoteDateTime) tuple1 = 퓏.핂.퓏(numArray1, numArray2, numArray3, numArray4, numArray5, dateTimeArray, this.PriceModifier);
    (double last, double lastSize, DateTime LastDateTime) tuple2 = 퓏.핂.퓏(numArray1, numArray6, numArray7, dateTimeArray, this.PriceModifier);
    (double mark, double markSize, DateTime markDateTime) tuple3 = 퓏.핂.퓬(numArray1, numArray8, numArray9, dateTimeArray, this.PriceModifier);
    (double open, double high, double low, double close, DateTime QuoteDateTime) tuple4 = 퓏.핂.퓬(numArray1, numArray10, numArray11, numArray12, numArray13, dateTimeArray, this.PriceModifier);
    this.퓏((MessageQuote) new DayBar(this.Name, tuple1.QuoteDateTime)
    {
      Bid = tuple1.bid,
      BidSize = tuple1.BidSize,
      Ask = tuple1.ask,
      AskSize = tuple1.askSize,
      Last = tuple2.last,
      LastSize = tuple2.lastSize,
      Mark = tuple3.mark,
      MarkSize = tuple3.markSize,
      Open = tuple4.open,
      High = tuple4.high,
      Low = tuple4.low,
      PreviousClose = tuple4.close
    });
  }

  private void 핂()
  {
    if (this.SyntheticState != SyntheticState.Initialized)
      return;
    if (this.핅픞)
    {
      this.핅픞 = false;
      this.퓬();
    }
    if (!this.핅핁)
      return;
    this.핅핁 = false;
    this.핇();
  }

  private void 퓏([In] Symbol obj0, [In] TradingPlatform.BusinessLayer.Last obj1)
  {
    if (this.SyntheticState == SyntheticState.NotInitialized)
      return;
    int count = this.Items.Count;
    double[] numArray1 = new double[count];
    double[] numArray2 = new double[count];
    double[] numArray3 = new double[count];
    DateTime[] dateTimeArray = new DateTime[count];
    for (int index = 0; index < this.Items.Count; ++index)
    {
      SyntheticItem syntheticItem = this.Items[index];
      numArray1[index] = syntheticItem.Coefficient;
      numArray2[index] = syntheticItem.Symbol.Last;
      numArray3[index] = syntheticItem.Symbol.LastSize;
      dateTimeArray[index] = syntheticItem.Symbol.LastDateTime;
      SessionsContainer currentSessionsInfo = syntheticItem.Symbol.CurrentSessionsInfo;
      if ((currentSessionsInfo != null ? (!currentSessionsInfo.ContainsDate(dateTimeArray[index]) ? 1 : 0) : 0) != 0)
        return;
    }
    (double last, double lastSize, DateTime LastDateTime) tuple = 퓏.핂.퓏(numArray1, numArray2, numArray3, dateTimeArray, this.PriceModifier);
    if (tuple.last.IsNanOrDefault())
      return;
    tuple.last = this.RoundPriceToTickSize(tuple.last);
    this.퓏((MessageQuote) new TradingPlatform.BusinessLayer.Last(this.Name, tuple.last, tuple.lastSize, tuple.LastDateTime)
    {
      AggressorFlag = AggressorFlag.NotSet
    });
  }

  private void 퓏([In] Symbol obj0, [In] TradingPlatform.BusinessLayer.Mark obj1)
  {
    if (this.SyntheticState == SyntheticState.NotInitialized)
      return;
    int count = this.Items.Count;
    double[] numArray1 = new double[count];
    double[] numArray2 = new double[count];
    double[] numArray3 = new double[count];
    DateTime[] dateTimeArray = new DateTime[count];
    for (int index = 0; index < this.Items.Count; ++index)
    {
      SyntheticItem syntheticItem = this.Items[index];
      numArray1[index] = syntheticItem.Coefficient;
      numArray2[index] = syntheticItem.Symbol.Mark;
      numArray3[index] = syntheticItem.Symbol.MarkSize;
      dateTimeArray[index] = syntheticItem.Symbol.LastDateTime;
      SessionsContainer currentSessionsInfo = syntheticItem.Symbol.CurrentSessionsInfo;
      if ((currentSessionsInfo != null ? (!currentSessionsInfo.ContainsDate(dateTimeArray[index]) ? 1 : 0) : 0) != 0)
        return;
    }
    (double mark, double markSize, DateTime markDateTime) tuple = 퓏.핂.퓬(numArray1, numArray2, numArray3, dateTimeArray, this.PriceModifier);
    if (tuple.mark == 0.0)
      return;
    tuple.mark = this.RoundPriceToTickSize(tuple.mark);
    this.퓏((MessageQuote) new TradingPlatform.BusinessLayer.Mark(this.Name, tuple.markDateTime, tuple.mark, tuple.markSize));
  }

  private void 퓏([In] Symbol obj0, [In] Quote obj1)
  {
    if (this.SyntheticState == SyntheticState.NotInitialized)
      return;
    int count = this.Items.Count;
    double[] numArray1 = new double[count];
    double[] numArray2 = new double[count];
    double[] numArray3 = new double[count];
    double[] numArray4 = new double[count];
    double[] numArray5 = new double[count];
    DateTime[] dateTimeArray = new DateTime[count];
    for (int index = 0; index < this.Items.Count; ++index)
    {
      SyntheticItem syntheticItem = this.Items[index];
      numArray1[index] = syntheticItem.Coefficient;
      numArray2[index] = syntheticItem.Symbol.Ask;
      numArray3[index] = syntheticItem.Symbol.Bid;
      numArray4[index] = syntheticItem.Symbol.AskSize;
      numArray5[index] = syntheticItem.Symbol.BidSize;
      dateTimeArray[index] = syntheticItem.Symbol.QuoteDateTime;
      SessionsContainer currentSessionsInfo = syntheticItem.Symbol.CurrentSessionsInfo;
      if ((currentSessionsInfo != null ? (!currentSessionsInfo.ContainsDate(dateTimeArray[index]) ? 1 : 0) : 0) != 0)
        return;
    }
    (double ask, double bid, double askSize, double BidSize, DateTime QuoteDateTime) tuple = 퓏.핂.퓏(numArray1, numArray2, numArray3, numArray4, numArray5, dateTimeArray, this.PriceModifier);
    if (tuple.bid.IsNanOrDefault() && tuple.ask.IsNanOrDefault())
      return;
    tuple.bid = this.RoundPriceToTickSize(tuple.bid);
    tuple.ask = this.RoundPriceToTickSize(tuple.ask);
    this.퓏((MessageQuote) new Quote(this.Name, tuple.bid, tuple.BidSize, tuple.ask, tuple.askSize, tuple.QuoteDateTime));
  }

  private void 퓏([In] Symbol obj0, [In] Level2Quote obj1, [In] DOMQuote obj2) => this.핅픞 = true;

  private void 퓏([In] Symbol obj0, [In] DayBar obj1) => this.핅핁 = true;

  private protected override HistoricalData 퓏([In] HistoryRequestParameters obj0)
  {
    return (HistoricalData) new 퓿(obj0);
  }

  public override List<OrderType> GetAlowedOrderTypes(OrderTypeUsage? usage) => this.핅픾;

  public override bool IsTradingAllowed(Account account)
  {
    foreach (Symbol symbol in this.Items.Select<SyntheticItem, Symbol>((Func<SyntheticItem, Symbol>) (([In] obj0) => obj0.Symbol)))
    {
      Connection connection = symbol.Connection;
      Account account1;
      if (connection == null)
      {
        account1 = (Account) null;
      }
      else
      {
        IBusinessObjectsProvider businessObjects = connection.BusinessObjects;
        if (businessObjects == null)
        {
          account1 = (Account) null;
        }
        else
        {
          Account[] accounts = businessObjects.Accounts;
          account1 = accounts != null ? ((IEnumerable<Account>) accounts).FirstOrDefault<Account>() : (Account) null;
        }
      }
      Account account2 = account1;
      if (account2 == null || !symbol.IsTradingAllowed(account2))
        return false;
    }
    return true;
  }

  internal override TradingOperationResult 퓏([In] PlaceOrderRequestParameters obj0)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Synthetic.퓬 퓬 = new Synthetic.퓬();
    // ISSUE: reference to a compiler-generated field
    퓬.핅퓤 = obj0;
    // ISSUE: reference to a compiler-generated field
    if (퓬.핅퓤 == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓫());
    // ISSUE: reference to a compiler-generated field
    if (퓬.핅퓤.OrderTypeId != \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁핃())
    {
      // ISSUE: reference to a compiler-generated field
      return TradingOperationResult.CreateError(퓬.핅퓤.RequestId, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓟());
    }
    // ISSUE: reference to a compiler-generated method
    List<SyntheticItem> list = this.Items.OrderByDescending<SyntheticItem, double>(new Func<SyntheticItem, double>(퓬.퓏)).ToList<SyntheticItem>();
    for (int index = 0; index < list.Count; ++index)
    {
      SyntheticItem syntheticItem = list[index];
      Symbol symbol = syntheticItem.Symbol;
      // ISSUE: reference to a compiler-generated field
      PlaceOrderRequestParameters requestParameters1 = new PlaceOrderRequestParameters((OrderRequestParameters) 퓬.핅퓤);
      requestParameters1.Symbol = symbol;
      // ISSUE: reference to a compiler-generated field
      requestParameters1.Account = this.LegsConnectionsIds.Length > 1 ? symbol.Connection.BusinessObjects.Accounts[0] : 퓬.핅퓤.Account;
      PlaceOrderRequestParameters requestParameters2 = requestParameters1;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      OrderType orderType = syntheticItem.Symbol.GetAlowedOrderTypes(new OrderTypeUsage?(OrderTypeUsage.Order)).FirstOrDefault<OrderType>(퓬.핅픮 ?? (퓬.핅픮 = new Func<OrderType, bool>(퓬.퓏)));
      if (orderType == null)
      {
        // ISSUE: reference to a compiler-generated field
        return TradingOperationResult.CreateError(퓬.핅퓤.RequestId, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓶());
      }
      requestParameters2.OrderTypeId = orderType.Id;
      requestParameters2.Quantity = (double) Math.Abs((Decimal) requestParameters2.Quantity * (Decimal) syntheticItem.TradeRatio);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      if (퓬.핅퓤.Side == Side.Buy && syntheticItem.TradeRatio > 0.0 || 퓬.핅퓤.Side == Side.Sell && syntheticItem.TradeRatio < 0.0)
        requestParameters2.Side = Side.Buy;
      else
        requestParameters2.Side = Side.Sell;
      if (!string.IsNullOrEmpty(syntheticItem.TradeComment))
        requestParameters2.Comment = syntheticItem.TradeComment;
      TradingOperationResult tradingOperationResult = syntheticItem.Symbol.퓏(requestParameters2);
      if (tradingOperationResult.Status == TradingOperationResultStatus.Failure)
        return tradingOperationResult;
    }
    // ISSUE: reference to a compiler-generated field
    return TradingOperationResult.CreateSuccess(퓬.핅퓤.RequestId);
  }

  public override Account GetDefaultAccount(Account currentValue = null)
  {
    if (this.LegsConnectionsIds.Length != 1)
      return (Account) null;
    if (currentValue?.ConnectionId == this.Items[0].Symbol.ConnectionId)
      return currentValue;
    Connection connection = Core.Instance.Connections[this.Items[0].Symbol.ConnectionId];
    if (connection == null)
      return (Account) null;
    IBusinessObjectsProvider businessObjects = connection.BusinessObjects;
    if (businessObjects == null)
      return (Account) null;
    Account[] accounts = businessObjects.Accounts;
    return accounts == null ? (Account) null : ((IEnumerable<Account>) accounts).FirstOrDefault<Account>();
  }

  public override string FormatQuantity(double quantity, bool inLots = true, bool abbreviate = false)
  {
    int valuePrecision = CoreMath.GetValuePrecision((Decimal) quantity);
    return quantity.Format(valuePrecision, abbreviate);
  }

  public IList<SettingItem> Settings
  {
    get
    {
      List<SettingItem> settings = new List<SettingItem>()
      {
        (SettingItem) new SettingItemString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픟(), this.Name),
        (SettingItem) new SettingItemString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓶(), this.Id),
        (SettingItem) new SettingItemInteger(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎핉(), (int) this.PriceModifierType)
      };
      if (this.Group != null)
        settings.Add((SettingItem) new SettingItemGroup(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎핊(), (IList<SettingItem>) new List<SettingItem>()
        {
          (SettingItem) new SettingItemString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픜(), this.Group.GroupName),
          (SettingItem) new SettingItemString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓶(), this.Group.Id)
        }));
      for (int index = 0; index < this.Items.Count; ++index)
        settings.Add((SettingItem) new SettingItemGroup(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픛(), this.Items[index].Settings));
      return (IList<SettingItem>) settings;
    }
    set
    {
      if (value.GetItemByName(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픟()) is SettingItemString itemByName1)
        this.Name = (string) itemByName1.Value;
      if (value.GetItemByName(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓶()) is SettingItemString itemByName2)
        this.Id = (string) itemByName2.Value;
      this.PriceModifierType = (SyntheticPriceModifierType) value.GetValueOrDefault<int>((int) this.PriceModifierType, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎핉());
      if (value.GetItemByName(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎핊())?.Value is IEnumerable<SettingItem> list1)
      {
        string str1 = list1.GetItemByName(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픜())?.Value?.ToString();
        string str2 = list1.GetItemByName(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓶())?.Value?.ToString();
        if (!string.IsNullOrEmpty(str1) && !string.IsNullOrEmpty(str2))
        {
          this.Group = new SymbolGroup(this.ConnectionId);
          this.Group.퓏(new MessageSymbolGroup()
          {
            GroupName = str1,
            Id = str2
          });
        }
      }
      List<SyntheticItem> list2 = new List<SyntheticItem>();
      for (int index = 0; index < value.Count; ++index)
      {
        if (!(value[index].Name != \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픛()))
          list2.Add(new SyntheticItem()
          {
            Settings = (IList<SettingItem>) (value[index].Value as List<SettingItem>)
          });
      }
      this.Items = new ReadOnlyCollection<SyntheticItem>((IList<SyntheticItem>) list2);
    }
  }

  public override ConnectionDependency GetConnectionStateDependency()
  {
    return new ConnectionDependency()
    {
      Behavior = ConnectionDependencyBehavior.PartialDependency,
      DependentConnectionsIds = this.LegsConnectionsIds
    };
  }

  public override void OnConnectionStateChanged(
    Connection connection,
    ConnectionStateChangedEventArgs e)
  {
    List<SyntheticItem> list = this.Items.ToList<SyntheticItem>();
    list.ForEach((Action<SyntheticItem>) (([In] obj0) => obj0.Symbol = Core.Instance.GetSymbol(obj0.Symbol.CreateInfo())));
    this.Reinitialize((IEnumerable<SyntheticItem>) list);
  }
}
