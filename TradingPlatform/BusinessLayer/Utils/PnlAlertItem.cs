// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.PnlAlertItem
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils;

public class PnlAlertItem : ITriggerItem, IEquatable<PnlAlertItem>
{
  public bool IsChecked { get; set; }

  public Symbol Symbol { get; set; }

  public double TargetValue { get; set; }

  public double Increment { get; set; }

  public int Precision { get; set; }

  public PnlAlertItem()
  {
    this.IsChecked = false;
    this.TargetValue = 1.0;
    this.Increment = 1.0;
    this.Precision = 1;
  }

  public PnlAlertItem(PnlAlertItem source)
  {
    this.IsChecked = source.IsChecked;
    this.Symbol = source.Symbol;
    this.TargetValue = source.TargetValue;
    this.Increment = source.Increment;
    this.Precision = source.Precision;
  }

  public bool Equals(PnlAlertItem other)
  {
    if (other == null)
      return false;
    if (other == this)
      return true;
    return this.Symbol.Equals(other.Symbol) && this.TargetValue.Equals(other.TargetValue);
  }
}
