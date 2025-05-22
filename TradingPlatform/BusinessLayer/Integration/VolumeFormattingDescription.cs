// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.VolumeFormattingDescription
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Globalization;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

public class VolumeFormattingDescription : FormattingDescription<double>
{
  private readonly string 핂퓠;

  public bool DisplayQuantityInLots { get; set; }

  public bool AbbreviateVolumes { get; set; }

  public VolumeFormattingDescription(double volume, string symbolId)
    : base(volume)
  {
    this.핂퓠 = symbolId;
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
      symbol1 = (Symbol) null;
    else
      symbol1 = connection.퓏(new GetSymbolRequestParameters()
      {
        SymbolId = this.핂퓠
      }, NonFixedListDownload.IgnoreDownload);
    Symbol symbol2 = symbol1;
    return symbol2 != null ? symbol2.FormatQuantity(value, this.DisplayQuantityInLots, this.AbbreviateVolumes) : value.ToString((IFormatProvider) CultureInfo.InvariantCulture);
  }
}
