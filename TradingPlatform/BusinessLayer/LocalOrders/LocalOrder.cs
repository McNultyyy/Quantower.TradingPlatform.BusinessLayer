// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.LocalOrders.LocalOrder
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.DataBinding;
using 퓏;

#nullable disable
namespace TradingPlatform.BusinessLayer.LocalOrders;

public class LocalOrder : BindableEntity, IOrder, ITradingObject, IUniqueID, IDisposable
{
  private readonly Symbol 퓑퓛;
  private readonly OrderType 퓑픻;
  private double 퓑퓷;
  private double 퓑퓿;
  private double 퓑픟;
  private double 퓑퓧;
  private string 퓑픰;

  public string UniqueId => this.Id;

  public string Id { get; [param: In] internal set; }

  public Account Account { get; init; }

  public Symbol Symbol
  {
    get => this.퓑퓛;
    init
    {
      this.퓑퓛 = value;
      if (this.OrderType == null)
        return;
      this.OrderType.ConnectionId = this.Symbol.ConnectionId;
    }
  }

  public Side Side { get; init; }

  public OrderType OrderType
  {
    get => this.퓑픻;
    init
    {
      this.퓑픻 = value;
      if (this.OrderType == null)
        return;
      this.OrderType.ConnectionId = this.Symbol?.ConnectionId;
      this.Rules.퓏((퓏.픾) this.OrderType);
    }
  }

  public string OrderTypeId => this.OrderType?.Id;

  public TimeInForce TimeInForce { get; set; }

  public string GroupId { get; init; }

  public OrderStatus Status { get; [param: In] internal set; }

  public DateTime LastUpdateTime { get; [param: In] private set; }

  public double TotalQuantity
  {
    get => this.퓑퓷;
    set
    {
      this.SetValue<double>(ref this.퓑퓷, value, propertyName: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픭());
    }
  }

  public double Price
  {
    get => this.퓑퓿;
    set
    {
      this.SetValue<double>(ref this.퓑퓿, value, propertyName: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍핈());
    }
  }

  public double TriggerPrice
  {
    get => this.퓑픟;
    set
    {
      this.SetValue<double>(ref this.퓑픟, value, propertyName: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓜());
    }
  }

  public double TrailOffset
  {
    get => this.퓑퓧;
    set
    {
      this.SetValue<double>(ref this.퓑퓧, value, propertyName: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픺());
    }
  }

  public string Comment
  {
    get => this.퓑픰;
    set
    {
      this.SetValue<string>(ref this.퓑픰, value, propertyName: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픤());
    }
  }

  public string PositionId => (string) null;

  public SlTpHolder StopLoss => (SlTpHolder) null;

  public SlTpHolder TakeProfit => (SlTpHolder) null;

  public SlTpHolder[] StopLossItems => Array.Empty<SlTpHolder>();

  public SlTpHolder[] TakeProfitItems => Array.Empty<SlTpHolder>();

  public string ConnectionId => this.Symbol?.ConnectionId;

  public DateTime ExpirationTime => new DateTime();

  public BusinessObjectState State => BusinessObjectState.Normal;

  public double RemainingQuantity => this.TotalQuantity;

  public double FilledQuantity => 0.0;

  public string OriginalStatus => (string) null;

  public double AverageFillPrice => double.NaN;

  public AdditionalInfoCollection AdditionalInfo { get; set; }

  public event Action<IOrder> Updated;

  public LocalOrder.OrderTypeRules Rules { get; }

  public LocalOrder()
  {
    this.Rules = new LocalOrder.OrderTypeRules();
    this.PropertyChanged += new PropertyChangedEventHandler(this.퓏);
  }

  public void Dispose() => this.PropertyChanged -= new PropertyChangedEventHandler(this.퓏);

  private void 퓏([In] object obj0, [In] PropertyChangedEventArgs obj1)
  {
    this.LastUpdateTime = Core.Instance.TimeUtils.DateTimeUtcNow;
    this.퓏();
  }

  public override string ToString()
  {
    double price = double.IsNaN(this.TriggerPrice) ? this.Price : this.TriggerPrice;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 7);
    interpolatedStringHandler.AppendFormatted<Side>(this.Side);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프());
    interpolatedStringHandler.AppendFormatted(this.OrderType.Name);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픙());
    interpolatedStringHandler.AppendFormatted(this.TimeInForce.Format(this.ExpirationTime));
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓼());
    interpolatedStringHandler.AppendFormatted(this.Symbol.FormatQuantity(this.TotalQuantity));
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프());
    interpolatedStringHandler.AppendFormatted<Symbol>(this.Symbol);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓴());
    interpolatedStringHandler.AppendFormatted(this.Symbol.FormatPrice(price));
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프());
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픳());
    interpolatedStringHandler.AppendFormatted<Account>(this.Account);
    return interpolatedStringHandler.ToStringAndClear();
  }

  internal void 퓏([In] ModifyOrderRequestParameters obj0)
  {
    this.TimeInForce = obj0.TimeInForce;
    this.퓑퓷 = obj0.Quantity;
    this.퓑퓿 = obj0.Price;
    this.퓑픟 = obj0.TriggerPrice;
    this.퓑퓧 = obj0.TrailOffset;
    this.퓑픰 = obj0.Comment;
    this.AdditionalInfo?.퓏((IEnumerable<SettingItem>) obj0.AdditionalParameters);
    this.퓏();
  }

  private void 퓏()
  {
    // ISSUE: reference to a compiler-generated field
    Action<IOrder> 퓑픫 = this.퓑픫;
    if (퓑픫 == null)
      return;
    퓑픫((IOrder) this);
  }

  public class OrderTypeRules
  {
    private readonly IDictionary<string, Rule> 퓞픠;
    private 퓏.픾 퓞퓮;

    internal OrderTypeRules()
    {
      this.퓞픠 = (IDictionary<string, Rule>) new Dictionary<string, Rule>();
    }

    public void SetRule<T>(string ruleName, T value)
    {
      픨<T> 픨 = new 픨<T>(ruleName, value);
      this.퓞픠[ruleName] = (Rule) 픨;
      this.퓏((Rule) 픨);
    }

    internal void 퓏([In] 퓏.픾 obj0)
    {
      this.퓞퓮 = obj0;
      foreach (Rule rule in (IEnumerable<Rule>) this.퓞픠.Values)
        this.퓏(rule);
    }

    private void 퓏([In] Rule obj0)
    {
      if (this.퓞퓮 == null)
        return;
      if (this.퓞퓮.Rules.퓬(obj0.Name))
        this.퓞퓮.Rules[obj0.Name] = obj0;
      else
        this.퓞퓮.Rules.퓏(obj0.Name, obj0);
    }
  }
}
