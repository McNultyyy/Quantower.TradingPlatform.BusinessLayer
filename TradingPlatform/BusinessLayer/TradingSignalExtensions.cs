// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.TradingSignalExtensions
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public static class TradingSignalExtensions
{
  public static bool TryFindSymbol(this TradingSignal tradingSignal, out Symbol symbol)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    TradingSignalExtensions.퓬 퓬 = new TradingSignalExtensions.퓬();
    // ISSUE: reference to a compiler-generated field
    퓬.픞픤 = tradingSignal;
    symbol = (Symbol) null;
    // ISSUE: reference to a compiler-generated field
    if (!string.IsNullOrEmpty(퓬.픞픤.Ticker))
    {
      // ISSUE: reference to a compiler-generated field
      SearchSymbolsRequestParameters requestParameters = new SearchSymbolsRequestParameters()
      {
        FilterName = 퓬.픞픤.Ticker
      };
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      IList<Symbol> source = !string.IsNullOrEmpty(퓬.픞픤.VendorName) ? ((IEnumerable<Connection>) Core.Instance.Connections.Connected).FirstOrDefault<Connection>(new Func<Connection, bool>(퓬.퓏))?.퓏(requestParameters) : Core.Instance.SearchSymbols(requestParameters);
      if (source == null || !source.Any<Symbol>())
        return false;
      // ISSUE: reference to a compiler-generated method
      symbol = source.FirstOrDefault<Symbol>(new Func<Symbol, bool>(퓬.퓏));
    }
    else
    {
      // ISSUE: reference to a compiler-generated field
      if (!string.IsNullOrEmpty(퓬.픞픤.Root))
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        foreach (Connection connection in ((IEnumerable<Connection>) Core.Instance.Connections.Connected).Where<Connection>(퓬.픞퓟 ?? (퓬.픞퓟 = new Func<Connection, bool>(퓬.퓬))))
        {
          // ISSUE: reference to a compiler-generated field
          SearchSymbolsRequestParameters requestParameters = new SearchSymbolsRequestParameters()
          {
            FilterName = 퓬.픞픤.Root,
            SymbolTypes = (IList<SymbolType>) new SymbolType[1]
            {
              SymbolType.Futures
            }
          };
          IList<Symbol> source = connection.퓏(requestParameters);
          if (source.Any<Symbol>())
          {
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated method
            List<Symbol> list = source.Where<Symbol>(퓬.픞핉 ?? (퓬.픞핉 = new Func<Symbol, bool>(퓬.퓬))).ToList<Symbol>();
            if (list.Any<Symbol>())
            {
              symbol = list.MinBy<Symbol, DateTime>((Func<Symbol, DateTime>) (([In] obj0) => obj0.ExpirationDate));
              if (symbol != null)
                break;
            }
          }
        }
      }
    }
    if (symbol != null)
      symbol = Core.Instance.GetSymbol(symbol.CreateInfo());
    Symbol symbol1 = symbol;
    return symbol1 != null && symbol1.State == BusinessObjectState.Normal;
  }
}
