// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.OffsetFormattingDescription
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

public class OffsetFormattingDescription : FormattingDescription<double>
{
  private readonly string 핂픇;

  public OffsetFormattingDescription(double offset, string symbolId)
    : base(offset)
  {
    this.핂픇 = symbolId;
  }

  protected override bool IsValueValid(double value)
  {
    return !double.IsNaN(value) && base.IsValueValid(value);
  }

  protected override string FormatValue(double value)
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
        symbol1 = symbols != null ? ((IEnumerable<Symbol>) symbols).FirstOrDefault<Symbol>((Func<Symbol, bool>) (([In] obj0) => obj0.Id == this.핂픇)) : (Symbol) null;
      }
    }
    Symbol symbol2 = symbol1;
    return symbol2 == null ? value.ToString((IFormatProvider) CultureInfo.InvariantCulture) : symbol2.FormatOffset(value, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픹());
  }
}
