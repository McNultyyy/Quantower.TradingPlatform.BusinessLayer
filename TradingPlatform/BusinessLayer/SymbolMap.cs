// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SymbolMap
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Integration;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public sealed class SymbolMap : IDisposable, IUniqueID, ICustomizable, IConnectionStateDependent
{
  private Symbol 픁픿;
  private Symbol 픁퓔;
  private bool 픁픘;
  private readonly ConnectionStateObserver 픁픨;

  public string UniqueId => this.Id;

  public string Id { get; [param: In] private set; }

  public Symbol TradableSymbol
  {
    get => this.픁픿;
    [param: In] private set
    {
      SymbolMap.핇 핇 = new SymbolMap.핇();
      핇.픜픅 = this;
      핇.픜퓮 = value;
      if (this.픁픿 == 핇.픜퓮)
        return;
      핇.픜픠 = this.TradableSymbol;
      핇.픜픠.퓏(new Action(핇.퓏));
    }
  }

  public Symbol QuotesSymbol
  {
    get => this.픁퓔;
    [param: In] private set
    {
      SymbolMap.퓏 퓏 = new SymbolMap.퓏();
      퓏.픜퓣 = this;
      퓏.픜픦 = value;
      if (this.픁퓔 == 퓏.픜픦)
        return;
      this.TradableSymbol.퓏(new Action(퓏.퓏));
    }
  }

  public Symbol TickHistorySymbol { get; [param: In] private set; }

  public Symbol MinuteHistorySymbol { get; [param: In] private set; }

  public Symbol DayHistorySymbol { get; [param: In] private set; }

  public Symbol VolumeAnalysisSymbol { get; [param: In] private set; }

  public bool IsActive
  {
    get => this.픁픘;
    [param: In] private set
    {
      SymbolMap.퓬 퓬 = new SymbolMap.퓬();
      퓬.픜픍 = this;
      퓬.픜픆 = value;
      if (this.픁픘 == 퓬.픜픆)
        return;
      if (this.TradableSymbol == null)
        this.픁픘 = 퓬.픜픆;
      else
        this.TradableSymbol.퓏(new Action(퓬.퓏));
    }
  }

  public IList<SettingItem> Settings
  {
    get
    {
      return (IList<SettingItem>) new List<SettingItem>()
      {
        (SettingItem) new SettingItemString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓬(), this.Id),
        (SettingItem) new SettingItemSymbol(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픙(), this.TradableSymbol),
        (SettingItem) new SettingItemSymbol(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓭(), this.QuotesSymbol),
        (SettingItem) new SettingItemSymbol(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓣(), this.TickHistorySymbol),
        (SettingItem) new SettingItemSymbol(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픦(), this.MinuteHistorySymbol),
        (SettingItem) new SettingItemSymbol(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픍(), this.DayHistorySymbol),
        (SettingItem) new SettingItemSymbol(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픆(), this.VolumeAnalysisSymbol),
        (SettingItem) new SettingItemBoolean(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓸(), this.IsActive)
      };
    }
    set
    {
      this.Id = value.GetValueOrDefault<string>(this.Id, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓬());
      this.픁픿 = value.GetValueOrDefault<Symbol>(this.픁픿, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픙());
      this.픁퓔 = value.GetValueOrDefault<Symbol>(this.픁퓔, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓭());
      this.TickHistorySymbol = value.GetValueOrDefault<Symbol>(this.TickHistorySymbol, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓣());
      this.MinuteHistorySymbol = value.GetValueOrDefault<Symbol>(this.MinuteHistorySymbol, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픦());
      this.DayHistorySymbol = value.GetValueOrDefault<Symbol>(this.DayHistorySymbol, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픍());
      this.VolumeAnalysisSymbol = value.GetValueOrDefault<Symbol>(this.VolumeAnalysisSymbol, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픆());
      this.IsActive = value.GetValueOrDefault<bool>((this.IsActive ? 1 : 0) != 0, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓸());
      Symbol symbol;
      if (value.TryGetValue<Symbol>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픆(), out symbol))
        this.VolumeAnalysisSymbol = symbol;
      else
        this.VolumeAnalysisSymbol = this.DayHistorySymbol ?? this.MinuteHistorySymbol ?? this.TickHistorySymbol ?? this.QuotesSymbol;
    }
  }

  internal SymbolMap()
  {
    this.픁픨 = new ConnectionStateObserver((IConnectionStateDependent) this, ConnectionStateObserverPriority.High, new ConnectionState[3]
    {
      ConnectionState.Connected,
      ConnectionState.Disconnected,
      ConnectionState.ConnectionLost
    });
  }

  internal SymbolMap([In] Symbol obj0)
    : this()
  {
    this.Id = Guid.NewGuid().ToString();
    this.IsActive = true;
    this.픁픿 = obj0;
  }

  internal bool 퓏([In] Period obj0, out Symbol _param2)
  {
    _param2 = (Symbol) null;
    _param2 = obj0.BasePeriod < BasePeriod.Day ? (obj0.BasePeriod < BasePeriod.Minute ? this.TickHistorySymbol : this.MinuteHistorySymbol) : this.DayHistorySymbol;
    return _param2 != null;
  }

  internal void 퓏([In] SymbolMappingParameters obj0, bool _param2 = true)
  {
    this.IsActive = obj0.IsActive;
    this.TradableSymbol = obj0.TradableSymbol;
    if (_param2)
      this.QuotesSymbol = obj0.QuotesSymbol;
    else
      this.픁퓔 = obj0.QuotesSymbol;
    this.TickHistorySymbol = obj0.TickHistorySymbol;
    this.MinuteHistorySymbol = obj0.MinuteHistorySymbol;
    this.DayHistorySymbol = obj0.DayHistorySymbol;
    this.VolumeAnalysisSymbol = obj0.VolumeAnalysisSymbol;
  }

  internal void 퓏()
  {
    this.QuotesSymbol = (Symbol) null;
    this.TickHistorySymbol = (Symbol) null;
    this.MinuteHistorySymbol = (Symbol) null;
    this.DayHistorySymbol = (Symbol) null;
    this.VolumeAnalysisSymbol = (Symbol) null;
  }

  public SymbolMapState GetState() => new SymbolMapState(this);

  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 6);
    interpolatedStringHandler.AppendFormatted<Symbol>(this.TradableSymbol);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓛());
    interpolatedStringHandler.AppendFormatted<Symbol>(this.QuotesSymbol);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓛());
    interpolatedStringHandler.AppendFormatted<Symbol>(this.TickHistorySymbol);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓛());
    interpolatedStringHandler.AppendFormatted<Symbol>(this.MinuteHistorySymbol);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓛());
    interpolatedStringHandler.AppendFormatted<Symbol>(this.DayHistorySymbol);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓛());
    interpolatedStringHandler.AppendFormatted<Symbol>(this.VolumeAnalysisSymbol);
    return interpolatedStringHandler.ToStringAndClear();
  }

  public void Dispose() => this.픁픨.Dispose();

  public ConnectionDependency GetConnectionStateDependency()
  {
    List<string> stringList = new List<string>()
    {
      this.TradableSymbol.ConnectionId
    };
    this.퓏(this.QuotesSymbol, stringList);
    this.퓏(this.TickHistorySymbol, stringList);
    this.퓏(this.MinuteHistorySymbol, stringList);
    this.퓏(this.DayHistorySymbol, stringList);
    this.퓏(this.VolumeAnalysisSymbol, stringList);
    return new ConnectionDependency()
    {
      Behavior = ConnectionDependencyBehavior.PartialDependency,
      DependentConnectionsIds = stringList.ToArray()
    };
  }

  public void OnConnectionStateChanged(Connection connection, ConnectionStateChangedEventArgs e)
  {
    string id = connection.Id;
    if (this.TradableSymbol.ConnectionId == id)
      this.TradableSymbol = Core.Instance.GetSymbol(this.TradableSymbol.CreateInfo());
    if (this.QuotesSymbol?.ConnectionId == id)
      this.QuotesSymbol = Core.Instance.GetSymbol(this.QuotesSymbol.CreateInfo());
    if (this.TickHistorySymbol?.ConnectionId == id)
      this.TickHistorySymbol = Core.Instance.GetSymbol(this.TickHistorySymbol.CreateInfo());
    if (this.MinuteHistorySymbol?.ConnectionId == id)
      this.MinuteHistorySymbol = Core.Instance.GetSymbol(this.MinuteHistorySymbol.CreateInfo());
    if (this.DayHistorySymbol?.ConnectionId == id)
      this.DayHistorySymbol = Core.Instance.GetSymbol(this.DayHistorySymbol.CreateInfo());
    if (!(this.VolumeAnalysisSymbol?.ConnectionId == id))
      return;
    this.VolumeAnalysisSymbol = Core.Instance.GetSymbol(this.VolumeAnalysisSymbol.CreateInfo());
  }

  private void 퓏([In] Symbol obj0, [In] List<string> obj1)
  {
    if (obj0 == null)
      return;
    obj1.Add(obj0.ConnectionId);
  }

  private void 퓏([In] Symbol obj0)
  {
    if (obj0.QuotesSubscribed)
      obj0.SubscribeAction(SubscribeQuoteType.Quote);
    if (obj0.Level2Subscribed)
      obj0.SubscribeAction(SubscribeQuoteType.Level2);
    if (obj0.LastsSubscribed)
      obj0.SubscribeAction(SubscribeQuoteType.Last);
    if (!obj0.MarkSubscribed)
      return;
    obj0.SubscribeAction(SubscribeQuoteType.Mark);
  }

  private void 퓬([In] Symbol obj0)
  {
    if (obj0.QuotesSubscribed)
      obj0.UnSubscribeAction(SubscribeQuoteType.Quote);
    if (obj0.Level2Subscribed)
      obj0.UnSubscribeAction(SubscribeQuoteType.Level2);
    if (obj0.LastsSubscribed)
      obj0.UnSubscribeAction(SubscribeQuoteType.Last);
    if (!obj0.MarkSubscribed)
      return;
    obj0.UnSubscribeAction(SubscribeQuoteType.Mark);
  }

  private void 핇([In] Symbol obj0)
  {
    if (obj0 == null || !this.TradableSymbol.HasAnySubscription)
      return;
    DayBar dayBar = this.퓲(obj0);
    dayBar.FullRefresh = true;
    this.TradableSymbol.퓏((MessageQuote) dayBar);
  }

  private DayBar 퓲([In] Symbol obj0) => ((IMessageBuilder<DayBar>) obj0).BuildMessage();
}
