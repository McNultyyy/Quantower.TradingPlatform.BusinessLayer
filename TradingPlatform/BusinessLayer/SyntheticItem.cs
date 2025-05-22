// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SyntheticItem
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public sealed class SyntheticItem : ICloneable, ICustomizable
{
  public Symbol Symbol { get; set; }

  public double Coefficient { get; set; }

  public double TradeRatio { get; set; }

  public string TradeComment { get; set; }

  public SyntheticItem()
  {
    this.Coefficient = 1.0;
    this.TradeRatio = 1.0;
    this.TradeComment = (string) null;
  }

  public SyntheticItem(SyntheticItem syntheticItem)
  {
    this.Symbol = syntheticItem.Symbol;
    this.Coefficient = syntheticItem.Coefficient;
    this.TradeRatio = syntheticItem.TradeRatio;
    this.TradeComment = syntheticItem.TradeComment;
  }

  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
    interpolatedStringHandler.AppendFormatted<double>(this.Coefficient);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓿());
    interpolatedStringHandler.AppendFormatted(this.Symbol?.Name);
    return interpolatedStringHandler.ToStringAndClear();
  }

  public object Clone() => (object) new SyntheticItem(this);

  public IList<SettingItem> Settings
  {
    get
    {
      return (IList<SettingItem>) new List<SettingItem>()
      {
        (SettingItem) new SettingItemSymbol(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픟(), this.Symbol),
        (SettingItem) new SettingItemDouble(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓧(), this.Coefficient),
        (SettingItem) new SettingItemDouble(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픰(), this.TradeRatio)
      };
    }
    set
    {
      if (value.GetItemByName(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픟()) is SettingItemSymbol itemByName1)
        this.Symbol = itemByName1.Value as Symbol;
      if (value.GetItemByName(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓧()) is SettingItemDouble itemByName2)
        this.Coefficient = (double) itemByName2.Value;
      if (!(value.GetItemByName(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픰()) is SettingItemDouble itemByName3))
        return;
      this.TradeRatio = (double) itemByName3.Value;
    }
  }
}
