// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.CryptoBalanceCalculator
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public abstract class CryptoBalanceCalculator : BasicBalanceCalculator
{
  private SettingItemDoubleWithLink 픎픎;
  private SettingItemSlider 픎퓠;

  protected override void PopulateAction(
    SettingItem[] orderSettings,
    OrderRequestParameters requestParameters)
  {
    this.RequestParameters = requestParameters;
    if (this.픎픎 != null)
      this.픎픎.LinkAction = (Action<object>) null;
    this.픎픎 = (orderSettings != null ? ((IEnumerable<SettingItem>) orderSettings).GetItemByName(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓔()) : (SettingItem) null) as SettingItemDoubleWithLink;
    this.픎퓠 = (orderSettings != null ? ((IEnumerable<SettingItem>) orderSettings).GetItemByName(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픢()) : (SettingItem) null) as SettingItemSlider;
    if (this.픎픎 != null)
    {
      this.픎픎.LinkAction = new Action<object>(this.OnLinkAction);
      this.PopulateTotal();
    }
    base.PopulateAction(orderSettings, requestParameters);
  }

  protected override void OnOrderSettingChanged(string settingName)
  {
    if (!(settingName == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇핈()))
    {
      if (!(settingName == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓔()))
      {
        if (settingName == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픢())
        {
          this.QuantityDefiningSettingName = settingName;
          this.OnPercentChanged();
        }
      }
      else
      {
        this.QuantityDefiningSettingName = settingName;
        this.OnTotalChanged();
      }
    }
    else
      this.OnSideChanged();
    base.OnOrderSettingChanged(settingName);
  }

  protected override void RecalculateAction(string processingSettingName)
  {
    if (!(processingSettingName == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓔()))
    {
      if (processingSettingName == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픢())
        this.OnPercentChanged();
      else
        base.RecalculateAction(processingSettingName);
    }
    else
      this.OnTotalChanged();
  }

  protected override void DisposeAction()
  {
    this.픎픎 = (SettingItemDoubleWithLink) null;
    this.픎퓠 = (SettingItemSlider) null;
    base.DisposeAction();
  }

  protected virtual double CalculateQuantity(double total, double fillPrice)
  {
    return (double) ((Decimal) total / (Decimal) fillPrice);
  }

  protected virtual double CalculateTotal(double quantity, double fillPrice)
  {
    return (double) ((Decimal) fillPrice * (Decimal) quantity);
  }

  protected virtual string GetTotalLinkText()
  {
    return \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓯();
  }

  protected virtual ulong CalculateSliderStep() => 0;

  protected override void OnQuantityChanged()
  {
    base.OnQuantityChanged();
    if (this.QuantityItem == null)
      return;
    this.UpdateTotal(this.GetQuantity());
    this.UpdateSlider();
  }

  protected override void OnRiskChanged()
  {
    base.OnRiskChanged();
    if (this.QuantityItem == null)
      return;
    this.UpdateTotal(this.GetQuantity());
    this.UpdateSlider();
  }

  protected override void OnRiskPercentChanged()
  {
    base.OnRiskPercentChanged();
    if (this.QuantityItem == null)
      return;
    this.UpdateTotal(this.GetQuantity());
    this.UpdateSlider();
  }

  protected virtual void OnSideChanged()
  {
  }

  protected virtual void OnTotalChanged()
  {
    if (this.픎픎 == null)
      return;
    this.UpdateQuantity(this.GetTotal());
    this.UpdateSlider();
    this.UpdateRisk(this.GetQuantity());
    this.UpdateRiskPercent(this.GetRisk());
  }

  protected abstract void OnLinkAction(object obj);

  protected abstract void OnPercentChanged();

  protected void UpdateQuantity(double? total)
  {
    if (!total.HasValue || this.QuantityItem == null || !this.CurrentFillPrice.HasValue)
      return;
    double fillPrice = this.CurrentFillPrice.Value;
    if (fillPrice.IsNanOrDefault())
      return;
    this.UpdateQuantity(new double?(this.CalculateQuantity(total.Value, fillPrice)), SettingItemValueChangingReason.Programmatically);
  }

  protected void UpdateTotal(double? quantity)
  {
    if (!quantity.HasValue || this.픎픎 == null || !this.CurrentFillPrice.HasValue)
      return;
    double num = this.CurrentFillPrice.Value;
    if (double.IsNaN(num))
      return;
    this.UpdateTotal(new double?(this.CalculateTotal(quantity.Value, num)), SettingItemValueChangingReason.Programmatically);
  }

  protected void UpdateTotal(double? total, SettingItemValueChangingReason reason)
  {
    if (!total.HasValue)
      return;
    this.픎픎.SetValueWithReason((object) total, reason);
  }

  protected void UpdateTotalLink()
  {
    if (this.픎픎 == null)
      return;
    this.픎픎.LinkText = this.GetTotalLinkText();
  }

  protected void UpdateSlider()
  {
    if (this.픎퓠 == null)
      return;
    this.픎퓠.SetValueWithReason((object) this.CalculateSliderStep(), SettingItemValueChangingReason.Programmatically);
  }

  protected void PopulateTotal()
  {
    if (this.픎픎 == null)
      return;
    double num1 = 1.0;
    int num2 = 0;
    string str = string.Empty;
    Asset totalAsset = this.GetTotalAsset();
    if (totalAsset != null)
    {
      num1 = totalAsset.MinimumChange;
      num2 = totalAsset.Precision;
      str = totalAsset.Name;
    }
    this.픎픎.Minimum = num1;
    this.픎픎.Maximum = double.MaxValue;
    this.픎픎.Increment = num1;
    this.픎픎.DecimalPlaces = num2;
    this.픎픎.Dimension = str;
  }

  protected double? GetTotal()
  {
    SettingItemDoubleWithLink 픎픎 = this.픎픎;
    return 픎픎 == null ? new double?() : new double?(픎픎.GetValue<double>());
  }

  protected double? GetSliderPercent()
  {
    SettingItemSlider 픎퓠 = this.픎퓠;
    ulong? nullable = 픎퓠 != null ? new ulong?(픎퓠.GetValue<ulong>()) : new ulong?();
    return !nullable.HasValue ? new double?() : new double?((double) nullable.GetValueOrDefault() / 100.0);
  }

  protected virtual Asset GetTotalAsset() => this.RequestParameters?.Symbol?.QuotingCurrency;
}
