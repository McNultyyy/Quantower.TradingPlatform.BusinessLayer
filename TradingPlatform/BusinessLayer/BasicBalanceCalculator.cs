// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.BasicBalanceCalculator
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using TradingPlatform.BusinessLayer.Utils;

#nullable enable
namespace TradingPlatform.BusinessLayer;

public class BasicBalanceCalculator : IBalanceCalculator, IDisposable
{
  protected 
  #nullable disable
  OrderRequestParameters RequestParameters;
  private string 픂픗;
  private Task 픂퓰;
  private Task 픂픧;
  protected SettingItem QuantityItem;
  private SettingItem 픂퓹;
  private SettingItem 픂퓛;

  public bool DisplayQuantityInLots { get; set; }

  public double? CurrentFillPrice { get; set; }

  public string QuantityDefiningSettingName { get; set; }

  public bool AsyncBehavior { get; init; }

  protected bool SkipChanges { get; set; }

  public BasicBalanceCalculator() => this.AsyncBehavior = false;

  public void Populate(SettingItem[] orderSettings, OrderRequestParameters requestParameters)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    BasicBalanceCalculator.퓬 퓬 = new BasicBalanceCalculator.퓬();
    // ISSUE: reference to a compiler-generated field
    퓬.픎픾 = this;
    // ISSUE: reference to a compiler-generated field
    퓬.픎퓍 = orderSettings;
    // ISSUE: reference to a compiler-generated field
    퓬.픎픁 = requestParameters;
    if (this.AsyncBehavior)
    {
      // ISSUE: reference to a compiler-generated method
      this.픂퓰 = Task.Run(new Action(퓬.퓏));
    }
    else
    {
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.PopulateAction(퓬.픎퓍, 퓬.픎픁);
    }
  }

  protected virtual void PopulateAction(
    SettingItem[] orderSettings,
    OrderRequestParameters requestParameters)
  {
    this.RequestParameters = requestParameters;
    this.QuantityItem = orderSettings != null ? ((IEnumerable<SettingItem>) orderSettings).GetItemByName(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓢()) : (SettingItem) null;
    this.픂퓹 = orderSettings != null ? ((IEnumerable<SettingItem>) orderSettings).GetItemByName(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픫()) : (SettingItem) null;
    this.픂퓛 = orderSettings != null ? ((IEnumerable<SettingItem>) orderSettings).GetItemByName(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픯()) : (SettingItem) null;
    if (this.픂퓹 != null)
      this.픂퓹.Visible = this.RequestParameters?.StopLoss != null;
    if (this.픂퓛 != null)
      this.픂퓛.Visible = this.RequestParameters?.StopLoss != null;
    this.퓬();
    this.Recalculate();
  }

  public void OnOrderSettingChanged(string settingName, OrderRequestParameters requestParameters)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    BasicBalanceCalculator.핇 핇 = new BasicBalanceCalculator.핇();
    // ISSUE: reference to a compiler-generated field
    핇.픎픞 = this;
    // ISSUE: reference to a compiler-generated field
    핇.픎핁 = requestParameters;
    // ISSUE: reference to a compiler-generated field
    핇.픎픇 = settingName;
    if (this.SkipChanges || this.픂픗 != null)
      return;
    if (this.AsyncBehavior)
    {
      // ISSUE: reference to a compiler-generated method
      this.픂픧 = Task.Run(new Action(핇.퓏));
    }
    else
    {
      // ISSUE: reference to a compiler-generated method
      핇.퓏();
    }
  }

  protected virtual void OnOrderSettingChanged(string settingName)
  {
    if (!(settingName == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓢()))
    {
      if (!(settingName == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픫()))
      {
        if (settingName == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픯())
        {
          this.QuantityDefiningSettingName = settingName;
          this.OnRiskPercentChanged();
        }
        else
          this.Recalculate();
      }
      else
      {
        this.QuantityDefiningSettingName = settingName;
        this.OnRiskChanged();
      }
    }
    else
    {
      this.QuantityDefiningSettingName = settingName;
      this.OnQuantityChanged();
    }
  }

  public void OnTimerTick()
  {
    OrderRequestParameters requestParameters = this.RequestParameters;
    if ((requestParameters != null ? (requestParameters.OrderType?.Behavior.GetValueOrDefault() == OrderTypeBehavior.Market ? 1 : 0) : 0) == 0 || this.픂픗 != null)
      return;
    this.Recalculate();
  }

  protected void Recalculate()
  {
    string 픂픗 = this.픂픗;
    try
    {
      this.픂픗 = this.QuantityDefiningSettingName ?? \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓢();
      this.퓬();
      this.RecalculateAction(this.픂픗);
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
    finally
    {
      this.픂픗 = 픂픗;
    }
  }

  protected virtual void RecalculateAction(string processingSettingName)
  {
    if (!(processingSettingName == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓢()))
    {
      if (!(processingSettingName == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픫()))
      {
        if (!(processingSettingName == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픯()))
          return;
        this.OnRiskPercentChanged();
      }
      else
        this.OnRiskChanged();
    }
    else
      this.OnQuantityChanged();
  }

  public void Dispose()
  {
    if (this.AsyncBehavior)
      Task.WhenAll(this.픂퓰 ?? Task.CompletedTask, this.픂픧 ?? Task.CompletedTask).ContinueWith((Action<Task>) delegate
      {
        this.DisposeAction();
      });
    else
      this.DisposeAction();
  }

  protected virtual void DisposeAction() => this.QuantityItem = (SettingItem) null;

  protected virtual void OnQuantityChanged()
  {
    if (this.QuantityItem == null)
      return;
    this.UpdateRisk(this.GetQuantity());
    this.UpdateRiskPercent(this.GetRisk());
  }

  protected virtual void OnRiskChanged()
  {
    if (this.픂퓹 == null)
      return;
    double? risk = this.GetRisk();
    this.퓏(risk);
    this.UpdateRiskPercent(risk);
  }

  protected virtual void OnRiskPercentChanged()
  {
    double? nullable = this.퓏();
    double? availableBalance = this.GetAvailableBalance();
    if (!nullable.HasValue || !availableBalance.HasValue)
      return;
    double num = availableBalance.Value * nullable.Value / 100.0;
    this.퓏(new double?(num), SettingItemValueChangingReason.Programmatically);
    this.퓏(new double?(num));
  }

  protected void UpdateQuantity(double? quantity, SettingItemValueChangingReason reason)
  {
    if (!quantity.HasValue)
      return;
    this.QuantityItem.SetValueWithReason((object) CoreMath.FloorToIncrement(quantity.Value, this.RequestParameters.Symbol.LotStep), reason);
  }

  private void 퓏([In] double? obj0_1)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    BasicBalanceCalculator.퓲 퓲 = new BasicBalanceCalculator.퓲();
    // ISSUE: reference to a compiler-generated field
    퓲.픎픣 = this;
    // ISSUE: reference to a compiler-generated field
    퓲.픎퓙 = this.RequestParameters?.Symbol;
    List<SlTpHolder> stopLossItems = this.RequestParameters?.StopLossItems;
    // ISSUE: reference to a compiler-generated field
    if (!obj0_1.HasValue || this.QuantityItem == null || !this.CurrentFillPrice.HasValue || stopLossItems == null || stopLossItems.Count == 0 || 퓲.픎퓙 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    퓲.픎퓗 = this.CurrentFillPrice.Value;
    double num1;
    if (stopLossItems.Count == 1)
    {
      SlTpHolder slTpHolder = stopLossItems[0];
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      num1 = CoreMath.RoundToIncrement(obj0_1.Value / this.퓏(퓲.픎퓙, slTpHolder, 1.0, 퓲.픎퓗), 퓲.픎퓙.LotStep);
    }
    else if (stopLossItems.All<SlTpHolder>((Func<SlTpHolder, bool>) (([In] obj0_3) => !double.IsNaN(obj0_3.QuantityPercentage))))
    {
      // ISSUE: reference to a compiler-generated method
      double num2 = stopLossItems.Sum<SlTpHolder>(new Func<SlTpHolder, double>(퓲.퓏));
      // ISSUE: reference to a compiler-generated field
      num1 = CoreMath.RoundToIncrement(obj0_1.Value / num2, 퓲.픎퓙.LotStep);
    }
    else
    {
      SlTpHolder[] array = stopLossItems.Take<SlTpHolder>(stopLossItems.Count - 1).ToArray<SlTpHolder>();
      SlTpHolder slTpHolder = stopLossItems.Last<SlTpHolder>();
      if (array.Length < 1)
        return;
      // ISSUE: reference to a compiler-generated method
      double num3 = ((IEnumerable<SlTpHolder>) array).Sum<SlTpHolder>(new Func<SlTpHolder, double>(퓲.퓬));
      double num4 = obj0_1.Value - num3;
      if (num4 <= 0.0)
      {
        // ISSUE: reference to a compiler-generated field
        num1 = 퓲.픎퓙.MinLot;
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        double increment = CoreMath.RoundToIncrement(num4 / this.퓏(퓲.픎퓙, slTpHolder, 1.0, 퓲.픎퓗), 퓲.픎퓙.LotStep);
        num1 = ((IEnumerable<SlTpHolder>) array).Sum<SlTpHolder>((Func<SlTpHolder, double>) (([In] obj0_2) => obj0_2.Quantity)) + increment;
      }
    }
    this.UpdateQuantity(new double?(num1), SettingItemValueChangingReason.Programmatically);
  }

  private void 퓏([In] double? obj0, [In] SettingItemValueChangingReason obj1)
  {
    if (!obj0.HasValue)
      return;
    this.픂퓹.SetValueWithReason((object) obj0.Value, obj1);
  }

  protected void UpdateRisk(double? quantity)
  {
    Symbol symbol = this.RequestParameters?.Symbol;
    List<SlTpHolder> stopLossItems = this.RequestParameters?.StopLossItems;
    if (!quantity.HasValue || this.픂퓹 == null || !this.CurrentFillPrice.HasValue || stopLossItems == null || stopLossItems.Count == 0 || symbol == null || !this.RequestParameters.TryCorrectBracketsQuantity(out string _))
      return;
    double num1 = this.CurrentFillPrice.Value;
    double num2 = 0.0;
    foreach (SlTpHolder slTpHolder in stopLossItems)
    {
      double quantity1 = slTpHolder.Quantity;
      if (double.IsNaN(quantity1))
        quantity1 = quantity.Value;
      num2 += this.퓏(symbol, slTpHolder, quantity1, num1);
    }
    this.픂퓹.SetValueWithReason((object) num2, SettingItemValueChangingReason.Programmatically);
  }

  protected void UpdateRiskPercent(double? risk)
  {
    double? availableBalance = this.GetAvailableBalance();
    if (!risk.HasValue || this.픂퓛 == null || !availableBalance.HasValue)
      return;
    double? nullable = availableBalance;
    double num = 0.0;
    if (nullable.GetValueOrDefault() == num & nullable.HasValue)
      return;
    this.픂퓛.SetValueWithReason((object) (risk.Value / availableBalance.Value * 100.0), SettingItemValueChangingReason.Programmatically);
  }

  protected virtual double? GetAvailableBalance() => this.RequestParameters?.Account?.Balance;

  protected double? GetQuantity()
  {
    SettingItem quantityItem = this.QuantityItem;
    double? nullable = quantityItem != null ? new double?(quantityItem.GetValue<double>()) : new double?();
    if (!nullable.HasValue)
      return new double?();
    return !this.DisplayQuantityInLots && this.RequestParameters?.Symbol != null ? new double?(nullable.Value / this.RequestParameters.Symbol.LotSize) : nullable;
  }

  protected double? GetRisk()
  {
    SettingItem 픂퓹 = this.픂퓹;
    return 픂퓹 == null ? new double?() : new double?(픂퓹.GetValue<double>());
  }

  private double? 퓏()
  {
    SettingItem 픂퓛 = this.픂퓛;
    return 픂퓛 == null ? new double?() : new double?(픂퓛.GetValue<double>());
  }

  private void 퓬()
  {
    this.CurrentFillPrice = this.RequestParameters.OrderType?.GetFillPrice(this.RequestParameters);
  }

  private double 퓏([In] Symbol obj0, [In] SlTpHolder obj1, [In] double obj2, [In] double obj3)
  {
    double price = obj1.Price;
    if (obj1.PriceMeasurement == PriceMeasurement.Offset)
      price = this.RequestParameters.Symbol.CalculatePrice(obj3, (this.RequestParameters.Side == Side.Buy ? -1.0 : 1.0) * price);
    return Math.Abs(Math.Abs(obj0.CalculateValue(this.RequestParameters.Side, obj3, obj2)) - Math.Abs(obj0.CalculateValue(this.RequestParameters.Side, price, obj2)));
  }
}
