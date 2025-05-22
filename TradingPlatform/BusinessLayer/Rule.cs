// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Rule
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Integration;
using 퓏;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public abstract class Rule
{
  public const string ALLOW_TRADING = "Allow trading";
  public const string ALLOW_SCREENER = "Allow screener";
  public const string ALLOW_CONTAINS_SCREENER_CONDITIONS = "Allow 'contains' screener conditions";
  public const string ALLOW_NEWS = "Allow news";
  public const string ALLOW_SL = "Allow SL";
  public const string ALLOW_TP = "Allow TP";
  public const string ALLOW_SL_TRAILING = "Allow SL Trailing";
  public const string ALLOW_TP_TRAILING = "Allow TP Trailing";
  public const string ALLOW_MULTI_SL_TP = "ALLOW_MULTI_SL_TP";
  public const string ALLOW_MODIFY_ORDER = "Allow modify order";
  public const string ALLOW_MODIFY_ORDER_TYPE = "Allow modify order type";
  public const string ALLOW_MODIFY_AMOUNT = "Allow modify amount";
  public const string ALLOW_MODIFY_PRICE = "Allow modify price";
  public const string ALLOW_MODIFY_TIF = "Allow modify tif";
  public const string ALLOW_CHANGE_TO_MARKET = "Allow change to market";
  public const string ALLOW_REVERSE_POSITION = "Allow reverse position";
  public const string ALLOW_REDUCE_ONLY = "Allow reduce-only";
  public const string ALLOW_EXPORT = "Allow export";
  public const string ALLOW_LINK_OCO = "Allow Link OCO";
  public const string ALLOW_NEW_OCO = "Allow New OCO";
  public const string ALLOW_GROUP_ORDERS = "Allow group orders";
  public const string ALLOW_PARTIAL_CLOSE_POSITION = "Allow partial close position";
  public const string DEFAULT_SHOW_STRIKES_COUNT = "DEFAULT_SHOW_STRIKES_COUNT";
  public const string LEVEL2_IS_AGGREGATED = "LEVEL2_IS_AGGREGATED";
  public const string LEVEL2_HAS_IMPLIED_SIZE = "LEVEL2_HAS_IMPLIED_SIZE";
  public const string PLACE_ORDER_TRADING_OPERATION_HAS_ORDER_ID = "PLACE_ORDER_TRADING_OPERATION_HAS_ORDER_ID";
  public const string ALLOW_VOLUME_ANALYSIS_FROM_TICK_HISTORY = "ALLOW_VOLUME_ANALYSIS_FROM_TICK_HISTORY";

  internal string Name { get; [param: In] private set; }

  protected Rule(string name) => this.Name = name;

  internal virtual void 퓏([In] MessageRule obj0) => this.Name = obj0.Name;

  internal static Rule 퓬([In] MessageRule obj0)
  {
    switch (obj0.Value)
    {
      case string str:
        return (Rule) new 픨<string>(obj0.Name, str);
      case int num:
        return (Rule) new 픨<int>(obj0.Name, num);
      case bool flag:
        return (Rule) new 픨<bool>(obj0.Name, flag);
      default:
        throw new ArgumentException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲());
    }
  }
}
