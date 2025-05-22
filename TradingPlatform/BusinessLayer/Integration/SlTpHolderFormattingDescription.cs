// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.SlTpHolderFormattingDescription
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

public class SlTpHolderFormattingDescription : FormattingDescription<SlTpHolder>
{
  private readonly string 핂퓙;

  public SlTpHolderFormattingDescription(SlTpHolder slTpHolder, string symbolId)
    : base(slTpHolder)
  {
    this.핂퓙 = symbolId;
  }

  protected override string FormatValue(SlTpHolder value)
  {
    Connection connection = Core.Instance.Connections[this.ConnectionId];
    Symbol symbol1;
    if (connection == null)
    {
      symbol1 = (Symbol) null;
    }
    else
    {
      IBusinessObjectsProvider businessObjects = connection.BusinessObjects;
      if (businessObjects == null)
      {
        symbol1 = (Symbol) null;
      }
      else
      {
        Symbol[] symbols = businessObjects.Symbols;
        symbol1 = symbols != null ? ((IEnumerable<Symbol>) symbols).FirstOrDefault<Symbol>((Func<Symbol, bool>) (([In] obj0) => obj0.Id == this.핂퓙)) : (Symbol) null;
      }
    }
    Symbol symbol2 = symbol1;
    return value.Format(symbol2);
  }
}
