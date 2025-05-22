// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SymbolsMappingManager
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

#nullable enable
namespace TradingPlatform.BusinessLayer;

public class SymbolsMappingManager : ICustomizable
{
  private readonly 
  #nullable disable
  Dictionary<string, SymbolMap> 픁퓰;
  private readonly object 픁픧;

  public IList<SettingItem> Settings
  {
    get
    {
      List<SettingItem> settings = new List<SettingItem>();
      lock (this.픁픧)
      {
        foreach (KeyValuePair<string, SymbolMap> keyValuePair in this.픁퓰)
          settings.Add((SettingItem) new SettingItemGroup(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픅(), keyValuePair.Value.Settings));
      }
      return (IList<SettingItem>) settings;
    }
    set
    {
      foreach (SettingItem settingItem in (IEnumerable<SettingItem>) value)
      {
        if (!(settingItem.Name != \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픅()) && settingItem.Value is IList<SettingItem> settingItemList)
        {
          SymbolMap symbolMap = new SymbolMap()
          {
            Settings = settingItemList
          };
          lock (this.픁픧)
            this.픁퓰.Add(symbolMap.Id, symbolMap);
        }
      }
    }
  }

  public event EventHandler<SymbolsMappingEventArgs> MapAdded;

  public event EventHandler<SymbolsMappingEventArgs> MapUpdating;

  public event EventHandler<SymbolsMappingEventArgs> MapUpdated;

  public event EventHandler<SymbolsMappingEventArgs> MapDeleting;

  public event EventHandler<SymbolsMappingEventArgs> MapDeleted;

  public SymbolMap[] AllMaps
  {
    get
    {
      lock (this.픁픧)
        return this.픁퓰.Values.ToArray<SymbolMap>();
    }
  }

  internal SymbolsMappingManager()
  {
    this.픁퓰 = new Dictionary<string, SymbolMap>();
    this.픁픧 = new object();
  }

  internal void 퓏()
  {
  }

  public string AddSymbolMap(SymbolMappingParameters parameters)
  {
    SymbolMap symbolMap;
    lock (this.픁픧)
    {
      this.퓏(parameters, (string) null);
      symbolMap = new SymbolMap(parameters.TradableSymbol);
      this.픁퓰.Add(symbolMap.Id, symbolMap);
      symbolMap.퓏(parameters);
    }
    this.퓏(symbolMap);
    return symbolMap.Id;
  }

  public void UpdateSymbolMap(string symbolMapId, SymbolMappingParameters parameters)
  {
    if (string.IsNullOrEmpty(symbolMapId))
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픠());
    SymbolMap symbolMap;
    SymbolMapState state;
    lock (this.픁픧)
    {
      symbolMap = this.픁퓰[symbolMapId];
      this.퓏(parameters, symbolMapId);
      this.퓬(symbolMap);
      state = symbolMap.GetState();
      symbolMap.퓏(parameters, parameters.IsActive && state.IsActive == parameters.IsActive);
    }
    this.퓏(symbolMap, state);
  }

  public void DeleteSymbolMap(string symbolMapId)
  {
    if (string.IsNullOrEmpty(symbolMapId))
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픠());
    SymbolMap symbolMap;
    lock (this.픁픧)
    {
      symbolMap = this.픁퓰[symbolMapId];
      this.핇(symbolMap);
      symbolMap.퓏();
      this.픁퓰.Remove(symbolMapId);
    }
    symbolMap.Dispose();
    this.퓲(symbolMap);
  }

  public void DeleteAllMaps()
  {
    foreach (SymbolMap allMap in this.AllMaps)
    {
      this.핇(allMap);
      allMap.퓏();
      lock (this.픁픧)
        this.픁퓰.Remove(allMap.Id);
      this.퓲(allMap);
    }
  }

  public bool TryGetSymbolMapState(Symbol symbol, out SymbolMapState mapState)
  {
    SymbolMap symbolMap = this.퓏(symbol);
    mapState = symbolMap == null ? (SymbolMapState) null : new SymbolMapState(symbolMap);
    return mapState != null;
  }

  public bool TryGetQuotesSymbol(Symbol tradableSymbol, out Symbol quotesSymbol)
  {
    quotesSymbol = (Symbol) null;
    lock (this.픁픧)
    {
      SymbolMap symbolMap = this.퓏(tradableSymbol);
      if (symbolMap == null || !symbolMap.IsActive)
        return false;
      quotesSymbol = symbolMap.QuotesSymbol;
    }
    return quotesSymbol != null;
  }

  public bool TryGetHistorySymbol(Symbol tradableSymbol, Period period, out Symbol historySymbol)
  {
    lock (this.픁픧)
    {
      int num = 0;
      Symbol symbol = (Symbol) null;
      for (; this.퓏(tradableSymbol, period, out historySymbol); tradableSymbol = historySymbol)
      {
        symbol = historySymbol;
        ++num;
        if (historySymbol.Id == tradableSymbol.Id)
          break;
      }
      historySymbol = symbol;
      return num > 0;
    }
  }

  public bool TryGetVolumeAnalysisSymbol(Symbol tradableSymbol, out Symbol volumeAnalysisSymbol)
  {
    lock (this.픁픧)
    {
      int num = 0;
      Symbol symbol = (Symbol) null;
      for (; this.퓏(tradableSymbol, out volumeAnalysisSymbol); tradableSymbol = volumeAnalysisSymbol)
      {
        symbol = volumeAnalysisSymbol;
        ++num;
        if (volumeAnalysisSymbol.Id == tradableSymbol.Id)
          break;
      }
      volumeAnalysisSymbol = symbol;
      return num > 0;
    }
  }

  private bool 퓏([In] Symbol obj0, [In] Period obj1, out Symbol _param3)
  {
    _param3 = (Symbol) null;
    SymbolMap symbolMap = this.퓏(obj0);
    return symbolMap != null && symbolMap.IsActive && symbolMap.퓏(obj1, out _param3);
  }

  private bool 퓏([In] Symbol obj0, out Symbol _param2)
  {
    _param2 = (Symbol) null;
    SymbolMap symbolMap = this.퓏(obj0);
    if (symbolMap == null || !symbolMap.IsActive)
      return false;
    _param2 = symbolMap.VolumeAnalysisSymbol;
    return true;
  }

  private SymbolMap 퓏([In] Symbol obj0)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: reference to a compiler-generated method
    return this.픁퓰.Values.SingleOrDefault<SymbolMap>(new Func<SymbolMap, bool>(new SymbolsMappingManager.퓬()
    {
      픜픩 = obj0
    }.퓏));
  }

  private void 퓏([In] SymbolMappingParameters obj0, string _param2 = null)
  {
    if (obj0 == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픾());
    if (obj0.TradableSymbol == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓮());
    this.퓬(obj0, _param2);
    this.퓬(obj0);
  }

  private void 퓬([In] SymbolMappingParameters obj0, string _param2 = null)
  {
    SymbolMap symbolMap = this.퓏(obj0.TradableSymbol);
    if ((string.IsNullOrEmpty(_param2) ? (symbolMap != null ? 1 : 0) : (symbolMap == null ? 0 : (symbolMap.Id != _param2 ? 1 : 0))) != 0)
      throw new InvalidOperationException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픕() + obj0.TradableSymbol.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픱());
  }

  private void 퓏([In] SymbolMappingParameters obj0)
  {
    if (obj0.TradableSymbol.Equals(obj0.QuotesSymbol))
      throw new InvalidOperationException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픶());
    if (obj0.TradableSymbol.Equals(obj0.TickHistorySymbol))
      throw new InvalidOperationException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픀());
    if (obj0.TradableSymbol.Equals(obj0.MinuteHistorySymbol))
      throw new InvalidOperationException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픖());
    if (obj0.TradableSymbol.Equals(obj0.DayHistorySymbol))
      throw new InvalidOperationException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓘());
    if (obj0.TradableSymbol.Equals(obj0.VolumeAnalysisSymbol))
      throw new InvalidOperationException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픓());
  }

  private void 퓬([In] SymbolMappingParameters obj0_1)
  {
    this.퓏(obj0_1.TradableSymbol, obj0_1.QuotesSymbol, (Func<SymbolMapState, Symbol>) (([In] obj0_2) => obj0_2.QuotesSymbol));
    this.퓏(obj0_1.TradableSymbol, obj0_1.TickHistorySymbol, (Func<SymbolMapState, Symbol>) (([In] obj0_3) => obj0_3.TickHistorySymbol));
    this.퓏(obj0_1.TradableSymbol, obj0_1.MinuteHistorySymbol, (Func<SymbolMapState, Symbol>) (([In] obj0_4) => obj0_4.MinuteHistorySymbol));
    this.퓏(obj0_1.TradableSymbol, obj0_1.DayHistorySymbol, (Func<SymbolMapState, Symbol>) (([In] obj0_5) => obj0_5.DayHistorySymbol));
    this.퓏(obj0_1.TradableSymbol, obj0_1.VolumeAnalysisSymbol, (Func<SymbolMapState, Symbol>) (([In] obj0_6) => obj0_6.VolumeAnalysisSymbol));
  }

  private void 퓏([In] Symbol obj0, [In] Symbol obj1, [In] Func<SymbolMapState, Symbol> obj2)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    SymbolsMappingManager.핇 핇 = new SymbolsMappingManager.핇();
    // ISSUE: reference to a compiler-generated field
    핇.픜필 = obj0;
    // ISSUE: reference to a compiler-generated field
    if (핇.픜필.Equals(obj1))
      return;
    Symbol[] array = this.GetSymbolsChainRecursive(obj1, obj2).ToArray<Symbol>();
    // ISSUE: reference to a compiler-generated method
    if (((IEnumerable<Symbol>) array).Any<Symbol>(new Func<Symbol, bool>(핇.퓏)))
    {
      // ISSUE: reference to a compiler-generated field
      StringBuilder stringBuilder = new StringBuilder(핇.픜필.Name);
      foreach (Symbol symbol in array)
      {
        stringBuilder.Append(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픩());
        stringBuilder.Append(symbol.Name);
        // ISSUE: reference to a compiler-generated field
        if (symbol.Equals(핇.픜필))
          break;
      }
      string str = stringBuilder.ToString();
      throw new InvalidOperationException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞필() + str + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픗());
    }
  }

  public IEnumerable<Symbol> GetSymbolsChainRecursive(
    Symbol mappedSymbol,
    Func<SymbolMapState, Symbol> getMappedSymbolFromMap)
  {
    yield return mappedSymbol;
    SymbolMap symbolMap = this.퓏(mappedSymbol);
    if (symbolMap != null)
    {
      Symbol symbol = getMappedSymbolFromMap(symbolMap.GetState());
      if (!mappedSymbol.Equals(symbol))
      {
        IEnumerator<Symbol> enumerator = this.GetSymbolsChainRecursive(symbol, getMappedSymbolFromMap).GetEnumerator();
        while (enumerator.MoveNext())
          yield return enumerator.Current;
        // ISSUE: reference to a compiler-generated method
        this.퓬();
        enumerator = (IEnumerator<Symbol>) null;
      }
    }
  }

  private void 퓏([In] SymbolMap obj0)
  {
    // ISSUE: reference to a compiler-generated field
    EventHandler<SymbolsMappingEventArgs> 픁퓪 = this.픁퓪;
    if (픁퓪 == null)
      return;
    픁퓪((object) this, new SymbolsMappingEventArgs(obj0));
  }

  private void 퓬([In] SymbolMap obj0)
  {
    // ISSUE: reference to a compiler-generated field
    EventHandler<SymbolsMappingEventArgs> 픁픪 = this.픁픪;
    if (픁픪 == null)
      return;
    픁픪((object) this, new SymbolsMappingEventArgs(obj0));
  }

  private void 퓏([In] SymbolMap obj0, [In] SymbolMapState obj1)
  {
    // ISSUE: reference to a compiler-generated field
    EventHandler<SymbolsMappingEventArgs> 픁퓡 = this.픁퓡;
    if (픁퓡 == null)
      return;
    픁퓡((object) this, new SymbolsMappingEventArgs(obj0, obj1));
  }

  private void 핇([In] SymbolMap obj0)
  {
    // ISSUE: reference to a compiler-generated field
    EventHandler<SymbolsMappingEventArgs> 픁퓓 = this.픁퓓;
    if (픁퓓 == null)
      return;
    픁퓓((object) this, new SymbolsMappingEventArgs(obj0));
  }

  private void 퓲([In] SymbolMap obj0)
  {
    // ISSUE: reference to a compiler-generated field
    EventHandler<SymbolsMappingEventArgs> 픁픗 = this.픁픗;
    if (픁픗 == null)
      return;
    픁픗((object) this, new SymbolsMappingEventArgs(obj0));
  }
}
