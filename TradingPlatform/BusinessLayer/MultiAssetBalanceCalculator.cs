// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.MultiAssetBalanceCalculator
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public class MultiAssetBalanceCalculator : CryptoBalanceCalculator
{
  private CryptoAssetBalances 핋픸;
  private CryptoAccount 핋프;

  protected CryptoAssetBalances CurrentBalance
  {
    get => this.핋픸;
    set
    {
      if (this.핋픸 == value)
        return;
      this.핋픸 = value;
      this.UpdateTotalLink();
      this.Recalculate();
    }
  }

  private CryptoAccount CurrentAccount
  {
    get => this.핋프;
    [param: In] set
    {
      if (this.핋프 == value)
      {
        this.퓏();
      }
      else
      {
        if (this.핋프 != null)
          this.핋프.BalanceUpdated -= new EventHandler<CryptoAccountEventArgs>(this.퓏);
        this.핋프 = value;
        if (this.핋프 != null)
          this.핋프.BalanceUpdated += new EventHandler<CryptoAccountEventArgs>(this.퓏);
        this.퓏();
      }
    }
  }

  protected override void PopulateAction(
    SettingItem[] orderSettings,
    OrderRequestParameters requestParameters)
  {
    base.PopulateAction(orderSettings, requestParameters);
    this.CurrentAccount = requestParameters.Account as CryptoAccount;
  }

  protected override void DisposeAction()
  {
    base.DisposeAction();
    this.CurrentAccount = (CryptoAccount) null;
    this.CurrentBalance = (CryptoAssetBalances) null;
  }

  protected override string GetTotalLinkText()
  {
    return this.CurrentBalance == null ? base.GetTotalLinkText() : this.CurrentBalance.Asset.FormatPriceWithCurrency(this.GetAvailableBalance().GetValueOrDefault());
  }

  protected override ulong CalculateSliderStep()
  {
    if (this.RequestParameters == null || this.CurrentBalance == null)
      return base.CalculateSliderStep();
    double? nullable1 = this.RequestParameters.Side != Side.Buy ? this.GetQuantity() : this.GetTotal();
    if (!nullable1.HasValue)
      return base.CalculateSliderStep();
    double? nullable2 = this.GetAvailableBalance();
    if (!nullable2.HasValue || nullable2.GetValueOrDefault() == 0.0)
      nullable2 = new double?(1.0);
    double num = nullable1.Value * 100.0 * 100.0;
    double? nullable3 = nullable2;
    return (ulong) (nullable3.HasValue ? new double?(num / nullable3.GetValueOrDefault()) : new double?()).Value;
  }

  protected override double? GetAvailableBalance()
  {
    CryptoAssetBalances currentBalance = this.CurrentBalance;
    return new double?(currentBalance != null ? currentBalance.AvailableBalance : 0.0);
  }

  protected override void OnSideChanged()
  {
    this.퓏();
    this.UpdateSlider();
  }

  protected override void OnLinkAction(object obj)
  {
    if (this.CurrentBalance == null || this.RequestParameters == null)
      return;
    double valueOrDefault = this.GetAvailableBalance().GetValueOrDefault();
    if (this.RequestParameters.Side == Side.Buy)
      this.UpdateTotal(new double?(valueOrDefault), SettingItemValueChangingReason.Manually);
    else
      this.UpdateQuantity(new double?(valueOrDefault), SettingItemValueChangingReason.Manually);
  }

  protected override void OnPercentChanged()
  {
    double? sliderPercent = this.GetSliderPercent();
    if (!sliderPercent.HasValue || this.CurrentBalance == null || this.RequestParameters == null)
      return;
    double valueOrDefault = this.GetAvailableBalance().GetValueOrDefault();
    if (this.RequestParameters.Side == Side.Buy)
    {
      double num = valueOrDefault * sliderPercent.Value / 100.0;
      this.UpdateQuantity(new double?(num));
      this.UpdateTotal(new double?(num), SettingItemValueChangingReason.Programmatically);
      this.UpdateRisk(this.GetQuantity());
      this.UpdateRiskPercent(this.GetRisk());
    }
    else
    {
      double num = valueOrDefault * sliderPercent.Value / 100.0;
      this.UpdateTotal(new double?(num));
      this.UpdateQuantity(new double?(num), SettingItemValueChangingReason.Programmatically);
      this.UpdateRisk(this.GetQuantity());
      this.UpdateRiskPercent(this.GetRisk());
    }
  }

  private void 퓏([In] object obj0, [In] CryptoAccountEventArgs obj1)
  {
    if (this.CurrentBalance == null || obj1.Balances.AssetId != this.CurrentBalance.AssetId)
      return;
    this.UpdateTotalLink();
    this.Recalculate();
  }

  private void 퓏()
  {
    try
    {
      // ISSUE: reference to a compiler-generated method
      this.CurrentBalance = this.퓬();
    }
    finally
    {
      this.UpdateTotalLink();
      this.Recalculate();
    }
  }
}
