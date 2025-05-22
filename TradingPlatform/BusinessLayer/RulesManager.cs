// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.RulesManager
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Licence;
using 퓏;

#nullable enable
namespace TradingPlatform.BusinessLayer;

/// <summary>
/// Represents a permisions checking tool which use next priority order <see cref="T:TradingPlatform.BusinessLayer.Connection" />, <see cref="T:TradingPlatform.BusinessLayer.Account" />, <see cref="T:TradingPlatform.BusinessLayer.Symbol" /> and <see cref="T:TradingPlatform.BusinessLayer.OrderType" />
/// </summary>
public sealed class RulesManager
{
  internal static 
  #nullable disable
  HashSet<string> 퓗 = new HashSet<string>(((IEnumerable<FieldInfo>) typeof (CoreLicenceKeys).GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy)).Where<FieldInfo>((Func<FieldInfo, bool>) (([In] obj0) => obj0.IsLiteral && !obj0.IsInitOnly)).Where<FieldInfo>((Func<FieldInfo, bool>) (([In] obj0) => obj0.FieldType == typeof (string))).Select<FieldInfo, string>((Func<FieldInfo, string>) (([In] obj0) => obj0.GetValue((object) null) as string)));
  internal const int 픎 = 0;
  internal const int 퓠 = 10;
  internal const int 퓥 = 20;
  internal const int 퓯 = 30;

  internal List<Rule> Defaults
  {
    get
    {
      return new List<Rule>()
      {
        (Rule) new 픨<bool>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핂(), true),
        (Rule) new 픨<bool>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픂(), true),
        (Rule) new 픨<bool>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픾(), true),
        (Rule) new 픨<bool>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍(), true),
        (Rule) new 픨<bool>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁(), true),
        (Rule) new 픨<bool>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞(), true),
        (Rule) new 픨<bool>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁(), true),
        (Rule) new 픨<bool>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇(), true),
        (Rule) new 픨<bool>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣(), true),
        (Rule) new 픨<bool>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙(), true),
        (Rule) new 픨<bool>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗(), true),
        (Rule) new 픨<bool>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎(), true)
      };
    }
  }

  public AllowedResult IsAllowed(string ruleName, string connectionId)
  {
    this.퓬(ruleName);
    return this.퓏(ruleName, (퓏.픾) this.퓏(connectionId));
  }

  public AllowedResult IsAllowed(string ruleName, Account account)
  {
    this.퓏(ruleName, account);
    return this.퓏(ruleName, (퓏.픾) this.퓏(account.ConnectionId), (퓏.픾) account);
  }

  public AllowedResult IsAllowed(string ruleName, Symbol symbol)
  {
    this.퓏(ruleName, symbol);
    if (ruleName != \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓠() || !(symbol is Synthetic synthetic))
      return this.퓏(ruleName, (퓏.픾) this.퓏(symbol.ConnectionId), (퓏.픾) symbol);
    퓏.픾[] array = ((IEnumerable<string>) synthetic.LegsConnectionsIds).Select<string, 퓪>(new Func<string, 퓪>(this.퓏)).Cast<퓏.픾>().Concat<퓏.픾>((IEnumerable<퓏.픾>) synthetic.Items.Select<SyntheticItem, Symbol>((Func<SyntheticItem, Symbol>) (([In] obj0) => obj0.Symbol))).ToArray<퓏.픾>();
    return this.퓏(ruleName, array);
  }

  public AllowedResult IsAllowed(string ruleName, Account account, Symbol symbol)
  {
    this.퓏(ruleName, account, symbol);
    return this.퓏(ruleName, (퓏.픾) this.퓏(account.ConnectionId), (퓏.픾) account, (퓏.픾) symbol);
  }

  public AllowedResult IsAllowed(
    string ruleName,
    Account account,
    Symbol symbol,
    OrderType orderType)
  {
    this.퓏(ruleName, account, symbol, orderType);
    return this.퓏(ruleName, (퓏.픾) this.퓏(account.ConnectionId), (퓏.픾) account, (퓏.픾) symbol, (퓏.픾) orderType);
  }

  public int GetIntValue(string ruleName, string connectionId)
  {
    this.퓬(ruleName);
    return this.퓬(ruleName, (퓏.픾) this.퓏(connectionId));
  }

  public int GetIntValue(string ruleName, Account account)
  {
    this.퓏(ruleName, account);
    return this.퓬(ruleName, (퓏.픾) this.퓏(account.ConnectionId), (퓏.픾) account);
  }

  public int GetIntValue(string ruleName, Account account, Symbol symbol)
  {
    this.퓏(ruleName, account, symbol);
    return this.퓬(ruleName, (퓏.픾) this.퓏(account.ConnectionId), (퓏.픾) account, (퓏.픾) symbol);
  }

  public int GetIntValue(string ruleName, Account account, Symbol symbol, OrderType orderType)
  {
    this.퓏(ruleName, account, symbol, orderType);
    return this.퓬(ruleName, (퓏.픾) this.퓏(account.ConnectionId), (퓏.픾) account, (퓏.픾) symbol, (퓏.픾) orderType);
  }

  public string GetStringValue(string ruleName, string connectionId)
  {
    this.퓬(ruleName);
    return this.핇(ruleName, (퓏.픾) this.퓏(connectionId));
  }

  public string GetStringValue(string ruleName, Account account)
  {
    this.퓏(ruleName, account);
    return this.핇(ruleName, (퓏.픾) this.퓏(account.ConnectionId), (퓏.픾) account);
  }

  public string GetStringValue(string ruleName, Account account, Symbol symbol)
  {
    this.퓏(ruleName, account, symbol);
    return this.핇(ruleName, (퓏.픾) this.퓏(account.ConnectionId), (퓏.픾) account, (퓏.픾) symbol);
  }

  public string GetStringValue(
    string ruleName,
    Account account,
    Symbol symbol,
    OrderType orderType)
  {
    this.퓏(ruleName, account, symbol, orderType);
    return this.핇(ruleName, (퓏.픾) this.퓏(account.ConnectionId), (퓏.픾) account, (퓏.픾) symbol, (퓏.픾) orderType);
  }

  private AllowedResult 퓏([In] string obj0, params 퓏.픾[] rulesContainers)
  {
    IEnumerable<픨<bool>> source = this.퓲<픨<bool>>(obj0, rulesContainers);
    if (source.Count<픨<bool>>() == 0)
      return AllowedResult.GetNotAllowedResult(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓥());
    foreach (픨<bool> 픨 in source)
    {
      if (!픨.Value)
        return AllowedResult.GetNotAllowedResult(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓥());
    }
    return AllowedResult.GetAllowedResult();
  }

  private int 퓬([In] string obj0, params 퓏.픾[] rulesContainers)
  {
    픨<int> 픨 = this.퓲<픨<int>>(obj0, rulesContainers).LastOrDefault<픨<int>>();
    return 픨 == null ? -1 : 픨.Value;
  }

  private string 핇([In] string obj0, params 퓏.픾[] rulesContainers)
  {
    return this.퓲<픨<string>>(obj0, rulesContainers).LastOrDefault<픨<string>>()?.Value ?? \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓯();
  }

  private IEnumerable<퓏> 퓲<퓏>([In] string obj0_1, params 퓏.픾[] rulesContainers) where 퓏 : Rule
  {
    IEnumerator<퓏.픾> enumerator = ((IEnumerable<퓏.픾>) rulesContainers).Where<퓏.픾>((Func<퓏.픾, bool>) (([In] obj0_2) => obj0_2 != null)).OrderBy<퓏.픾, int>((Func<퓏.픾, int>) (([In] obj0_3) => obj0_3.PriorityIndex)).GetEnumerator();
    while (enumerator.MoveNext())
    {
      퓏.픾 current = enumerator.Current;
      Rule rule;
      if (current.Rules != null && current.Rules.퓏(obj0_1, out rule) && rule is 퓏 퓏)
        yield return 퓏;
    }
    // ISSUE: reference to a compiler-generated method
    this.퓬();
    enumerator = (IEnumerator<퓏.픾>) null;
  }

  private 퓪 퓏([In] string obj0) => Core.Instance.Connections[obj0]?.픂픹;

  private void 퓬([In] string obj0)
  {
    if (string.IsNullOrEmpty(obj0))
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픜());
  }

  private void 퓏([In] string obj0, [In] Account obj1)
  {
    this.퓬(obj0);
    if (obj1 == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓑());
  }

  private void 퓏([In] string obj0, [In] Symbol obj1)
  {
    this.퓬(obj0);
    if (obj1 == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핋());
  }

  private void 퓏([In] string obj0, [In] Account obj1, [In] Symbol obj2)
  {
    this.퓏(obj0, obj1);
    if (obj2 == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핋());
    if (obj2.SymbolType != SymbolType.Synthetic && obj1.ConnectionId != obj2.ConnectionId)
      throw new ArgumentException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓞());
  }

  private void 퓏([In] string obj0, [In] Account obj1, [In] Symbol obj2, [In] OrderType obj3)
  {
    this.퓏(obj0, obj1, obj2);
    if (obj3 == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핅());
    if (obj2.SymbolType != SymbolType.Synthetic && obj1.ConnectionId != obj3.ConnectionId)
      throw new ArgumentException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픡());
  }
}
