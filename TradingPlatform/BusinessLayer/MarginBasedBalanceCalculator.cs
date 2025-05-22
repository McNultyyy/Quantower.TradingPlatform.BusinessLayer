// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.MarginBasedBalanceCalculator
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

public abstract class MarginBasedBalanceCalculator : CryptoBalanceCalculator
{
  private Symbol 핋핆;
  private Account 핋픷;
  private Asset 핋퓻;

  protected Symbol CurrentSymbol
  {
    get => this.핋핆;
    set
    {
      if (this.핋핆 == value)
        return;
      this.핋퓻 = (Asset) null;
      if (this.핋핆 != null)
        this.핋핆.Updated -= new SymbolUpdateHandler(this.퓏);
      this.핋핆 = value;
      if (this.핋핆 == null)
        return;
      this.핋핆.Updated += new SymbolUpdateHandler(this.퓏);
      Connection connection = this.CurrentSymbol.Connection;
      this.핋퓻 = connection != null ? ((IEnumerable<Asset>) connection.BusinessObjects.Assets).FirstOrDefault<Asset>((Func<Asset, bool>) (([In] obj0) => obj0.Id == this.BalanceCurrency)) : (Asset) null;
    }
  }

  protected Account CurrentAccount
  {
    get => this.핋픷;
    set
    {
      if (this.핋픷 == value)
        return;
      if (this.핋픷 != null)
        this.핋픷.Updated -= new Action<Account>(this.퓏);
      this.핋픷 = value;
      if (this.핋픷 == null)
        return;
      this.핋픷.Updated += new Action<Account>(this.퓏);
    }
  }

  protected virtual string BalanceCurrency => this.CurrentSymbol?.QuotingCurrency?.Id;

  protected override void PopulateAction(
    SettingItem[] orderSettings,
    OrderRequestParameters requestParameters)
  {
    base.PopulateAction(orderSettings, requestParameters);
    this.CurrentSymbol = requestParameters.Symbol;
    this.CurrentAccount = requestParameters.Account;
    this.PopulateTotal();
    this.UpdateTotalLink();
    this.Recalculate();
  }

  protected override void DisposeAction()
  {
    base.DisposeAction();
    this.CurrentAccount = (Account) null;
  }

  protected override string GetTotalLinkText()
  {
    double? availableBalance = this.GetAvailableBalance();
    if (!availableBalance.HasValue)
      return base.GetTotalLinkText();
    return this.핋퓻?.FormatPriceWithCurrency(availableBalance.Value);
  }

  protected override ulong CalculateSliderStep()
  {
    double? total = this.GetTotal();
    if (!total.HasValue)
      return base.CalculateSliderStep();
    double? nullable1 = this.GetAvailableBalance();
    if (!nullable1.HasValue)
      return base.CalculateSliderStep();
    double? nullable2 = nullable1;
    double num1 = 0.0;
    if (nullable2.GetValueOrDefault() == num1 & nullable2.HasValue)
      nullable1 = new double?(1.0);
    double num2 = total.Value * 100.0 * 100.0;
    nullable2 = nullable1;
    return (ulong) (nullable2.HasValue ? new double?(num2 / nullable2.GetValueOrDefault()) : new double?()).Value;
  }

  protected override Asset GetTotalAsset() => this.핋퓻;

  protected abstract double? GetAvailableForOrder();

  protected abstract int? GetLeverage();

  protected override void OnLinkAction(object obj)
  {
    this.UpdateTotal(this.GetAvailableBalance(), SettingItemValueChangingReason.Manually);
  }

  protected override void OnPercentChanged()
  {
    double? sliderPercent = this.GetSliderPercent();
    if (!sliderPercent.HasValue)
      return;
    double? availableBalance = this.GetAvailableBalance();
    if (!availableBalance.HasValue)
      return;
    this.UpdateQuantity(new double?(availableBalance.Value * sliderPercent.Value / 100.0));
    this.UpdateTotal(this.GetQuantity());
    this.UpdateRisk(this.GetQuantity());
    this.UpdateRiskPercent(this.GetRisk());
  }

  private void 퓏([In] Symbol obj0)
  {
    try
    {
      this.SkipChanges = true;
      this.UpdateTotalLink();
      this.Recalculate();
    }
    finally
    {
      this.SkipChanges = false;
    }
  }

  private void 퓏([In] Account obj0)
  {
    try
    {
      this.SkipChanges = true;
      this.UpdateTotalLink();
      this.Recalculate();
    }
    finally
    {
      this.SkipChanges = false;
    }
  }

  protected override double? GetAvailableBalance()
  {
    double? availableForOrder = this.GetAvailableForOrder();
    if (!availableForOrder.HasValue)
      return new double?();
    int? leverage = this.GetLeverage();
    if (!leverage.HasValue)
      return new double?();
    double? nullable1 = availableForOrder;
    int? nullable2 = leverage;
    double? nullable3 = nullable2.HasValue ? new double?((double) nullable2.GetValueOrDefault()) : new double?();
    return !(nullable1.HasValue & nullable3.HasValue) ? new double?() : new double?(nullable1.GetValueOrDefault() * nullable3.GetValueOrDefault());
  }
}
