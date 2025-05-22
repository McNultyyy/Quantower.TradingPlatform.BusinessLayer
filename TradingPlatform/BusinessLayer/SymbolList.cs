// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SymbolList
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

#nullable enable
namespace TradingPlatform.BusinessLayer;

/// <summary>Allows to save Symbols into named lists</summary>
public class SymbolList : IComparable, ICustomizable, IRenamable
{
  private 
  #nullable disable
  string 핁퓐;
  private List<BusinessObjectInfo> 핁퓵;

  public bool AllowToModify { get; [param: In] private set; }

  public string Name
  {
    get => this.핁퓐;
    set
    {
      if (!this.AllowToModify)
        return;
      if (((IEnumerable<SymbolList>) Core.Instance.SymbolList).FirstOrDefault<SymbolList>((Func<SymbolList, bool>) (([In] obj0) => obj0.Name == this.핁퓐)) != null)
        Core.Instance.RenameSymbolList(this.핁퓐, value);
      else
        Core.Instance.AddSymbolList(value, this.Symbols);
    }
  }

  public string Group { get; set; }

  public bool IsNameAllowed(string s, ref string error)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    SymbolList.퓏 퓏 = new SymbolList.퓏();
    // ISSUE: reference to a compiler-generated field
    퓏.픜퓜 = s;
    // ISSUE: reference to a compiler-generated field
    if (string.IsNullOrWhiteSpace(퓏.픜퓜))
    {
      error = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픞();
      return false;
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated method
    if (!(this.Name != 퓏.픜퓜) || !((IEnumerable<SymbolList>) Core.Instance.SymbolList).Any<SymbolList>(new Func<SymbolList, bool>(퓏.퓏)))
      return true;
    error = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁핁();
    return false;
  }

  public IEnumerable<Symbol> Symbols
  {
    get
    {
      List<BusinessObjectInfo>.Enumerator enumerator = this.핁퓵.GetEnumerator();
      while (enumerator.MoveNext())
        yield return new Symbol(enumerator.Current);
      this.퓬();
      enumerator = new List<BusinessObjectInfo>.Enumerator();
    }
    set
    {
      this.핁퓵.Clear();
      foreach (BusinessObject businessObject in value)
        this.핁퓵.Add(businessObject.CreateInfo());
    }
  }

  public IEnumerable<Symbol> GetRealSymbols()
  {
    List<BusinessObjectInfo>.Enumerator enumerator = this.핁퓵.GetEnumerator();
    while (enumerator.MoveNext())
      yield return Core.Instance.GetSymbol(enumerator.Current);
    // ISSUE: reference to a compiler-generated method
    this.퓬();
    enumerator = new List<BusinessObjectInfo>.Enumerator();
  }

  public IList<SettingItem> Settings
  {
    get
    {
      List<SettingItem> settings = new List<SettingItem>()
      {
        (SettingItem) new SettingItemString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픜(), this.Name)
      };
      foreach (Symbol symbol in this.Symbols)
        settings.Add((SettingItem) new SettingItemSymbol(symbol.Name, symbol));
      return (IList<SettingItem>) settings;
    }
    set
    {
      List<Symbol> symbolList = new List<Symbol>();
      foreach (SettingItem settingItem in (IEnumerable<SettingItem>) value)
      {
        if (settingItem.Type == SettingItemType.Symbol)
          symbolList.Add(settingItem.Value as Symbol);
        else if (settingItem.Name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픜())
          this.퓏(settingItem.Value as string);
      }
      if (symbolList.Count <= 0)
        return;
      this.Symbols = (IEnumerable<Symbol>) symbolList;
    }
  }

  internal SymbolList()
  {
    this.핁퓵 = new List<BusinessObjectInfo>();
    this.AllowToModify = true;
  }

  public SymbolList(string name, IEnumerable<Symbol> symbols)
    : this()
  {
    if (string.IsNullOrEmpty(name))
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓫());
    this.퓏(name);
    this.Symbols = symbols ?? throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픹());
  }

  internal SymbolList([In] IList<SettingItem> obj0, [In] bool obj1)
    : this()
  {
    this.Settings = obj0;
    this.AllowToModify = obj1;
  }

  public int CompareTo(object obj) => this.Name.CompareTo((obj as SymbolList).Name);

  internal void 퓏([In] string obj0)
  {
    if (!this.AllowToModify)
      return;
    this.핁퓐 = obj0;
  }
}
