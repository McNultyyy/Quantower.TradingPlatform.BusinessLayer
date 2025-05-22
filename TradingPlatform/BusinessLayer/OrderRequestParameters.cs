// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.OrderRequestParameters
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.LocalOrders;
using TradingPlatform.BusinessLayer.Serialization;
using TradingPlatform.BusinessLayer.Utils;
using TradingPlatform.BusinessLayer.Utils.EqualityComparers;
using 퓏;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[Published]
public abstract class OrderRequestParameters : 
  TradingRequestParameters,
  ICloneable,
  IXElementSerialization,
  IEquatable<OrderRequestParameters>
{
  private string 픜퓯;
  private Symbol 픜픜;
  private string 픜퓑;
  private string 픜퓳;
  private OrderType 픜핆;
  private List<SettingItem> 픜퓽;
  private readonly LocalOrder 픜픘;
  private static readonly ListEqualityComparer<SlTpHolder> 픜픨 = new ListEqualityComparer<SlTpHolder>((IEqualityComparer<SlTpHolder>) EqualityComparer<SlTpHolder>.Default);
  private static readonly ListEqualityComparer<SettingItem> 픜퓪 = new ListEqualityComparer<SettingItem>((IEqualityComparer<SettingItem>) EqualityComparer<SettingItem>.Default);

  public override string ConnectionId => this.Symbol?.ConnectionId;

  public string SymbolId
  {
    get => this.Symbol?.Id ?? this.픜퓯;
    set => this.픜퓯 = value;
  }

  public Symbol Symbol
  {
    get => this.픜픜;
    set
    {
      this.픜픜 = value;
      this.픜핆 = (OrderType) null;
    }
  }

  public string AccountId
  {
    get => this.Account?.Id ?? this.픜퓑;
    set => this.픜퓑 = value;
  }

  public Account Account { get; set; }

  public Side Side { get; set; }

  public double Quantity { get; set; }

  public double Total { get; set; }

  public string QuantityDefinitionSettingName { get; set; }

  public string OrderTypeId
  {
    get => this.픜퓳;
    set
    {
      this.픜퓳 = value;
      this.픜핆 = (OrderType) null;
    }
  }

  public OrderType OrderType
  {
    get
    {
      if (this.픜픘 != null)
        return this.픜픘.OrderType;
      if (this.픜핆 == null && this.Symbol != null && !string.IsNullOrEmpty(this.OrderTypeId))
      {
        List<OrderType> alowedOrderTypes = this.Symbol.GetAlowedOrderTypes(new OrderTypeUsage?());
        this.픜핆 = alowedOrderTypes != null ? alowedOrderTypes.FirstOrDefault<OrderType>((Func<OrderType, bool>) (([In] obj0) => obj0.Id == this.OrderTypeId)) : (OrderType) null;
      }
      return this.픜핆;
    }
  }

  public double Price { get; set; }

  public double TriggerPrice { get; set; }

  public double TrailOffset { get; set; }

  public TimeInForce TimeInForce { get; set; }

  public DateTime ExpirationTime { get; set; }

  public int Slippage { get; set; }

  public string PositionId { get; set; }

  public SlTpHolder StopLoss
  {
    get => this.StopLossItems.FirstOrDefault<SlTpHolder>();
    set
    {
      this.StopLossItems.Clear();
      if (value == null)
        return;
      this.StopLossItems.Add(value);
    }
  }

  public SlTpHolder TakeProfit
  {
    get => this.TakeProfitItems.FirstOrDefault<SlTpHolder>();
    set
    {
      this.TakeProfitItems.Clear();
      if (value == null)
        return;
      this.TakeProfitItems.Add(value);
    }
  }

  public List<SlTpHolder> StopLossItems { get; [param: In] private set; }

  public List<SlTpHolder> TakeProfitItems { get; [param: In] private set; }

  public string GroupId { get; set; }

  public string Comment { get; set; }

  public IList<SettingItem> AdditionalParameters
  {
    get
    {
      List<SettingItem> list = new List<SettingItem>((IEnumerable<SettingItem>) this.픜퓽);
      if (this.TimeInForce != TimeInForce.Default)
        list.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓷(), (object) (int) this.TimeInForce, true);
      if (this.ExpirationTime != new DateTime())
        list.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픟(), (object) this.ExpirationTime, true);
      list.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇핈(), (object) (int) this.Side, true);
      if (!double.IsNaN(this.Quantity))
        list.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓢(), (object) this.Quantity, true);
      if (!double.IsNaN(this.Total))
        list.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓔(), (object) this.Total, true);
      if (!double.IsNaN(this.Price))
        list.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍핈(), (object) this.Price, true);
      if (!double.IsNaN(this.TriggerPrice))
        list.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓜(), (object) this.TriggerPrice, true);
      if (!double.IsNaN(this.TrailOffset))
        list.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픺(), (object) (int) this.TrailOffset, true);
      if (!string.IsNullOrEmpty(this.Comment))
        list.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픤(), (object) this.Comment, true);
      return (IList<SettingItem>) list;
    }
    set
    {
      if (value == null)
        throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇핌());
      this.픜퓽.Clear();
      foreach (SettingItem settingItem in (IEnumerable<SettingItem>) value)
      {
        string name = settingItem.Name;
        if (name != null)
        {
          switch (name.Length)
          {
            case 4:
              if (name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇핈() && settingItem.Value is SelectItem selectItem1)
              {
                this.Side = (Side) selectItem1.Value;
                break;
              }
              break;
            case 5:
              switch (name[0])
              {
                case 'P':
                  if (name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍핈())
                  {
                    this.Price = (double) settingItem.Value;
                    break;
                  }
                  break;
                case 'T':
                  if (name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓔())
                  {
                    this.Total = (double) settingItem.Value;
                    break;
                  }
                  break;
              }
              break;
            case 7:
              if (name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픤())
              {
                this.Comment = settingItem.Value?.ToString();
                break;
              }
              break;
            case 8:
              if (name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓢())
              {
                this.Quantity = (double) settingItem.Value;
                break;
              }
              break;
            case 10:
              if (name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픟())
              {
                this.ExpirationTime = (DateTime) settingItem.Value;
                break;
              }
              break;
            case 11:
              if (name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픺())
              {
                this.TrailOffset = (double) (int) settingItem.Value;
                break;
              }
              break;
            case 12:
              if (name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓜())
              {
                this.TriggerPrice = (double) settingItem.Value;
                break;
              }
              break;
            case 13:
              if (name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓷() && settingItem.Value is SelectItem selectItem2)
              {
                this.TimeInForce = (TimeInForce) selectItem2.Value;
                break;
              }
              break;
          }
        }
        this.픜퓽.Add(settingItem.GetCopy());
      }
    }
  }

  protected OrderRequestParameters() => this.퓏();

  protected OrderRequestParameters(IOrder order)
    : this()
  {
    this.Symbol = order.Symbol;
    this.Account = order.Account;
    this.Side = order.Side;
    this.Quantity = order.TotalQuantity;
    this.OrderTypeId = order.OrderTypeId;
    this.픜픘 = order as LocalOrder;
    this.Price = order.Price;
    this.TriggerPrice = order.TriggerPrice;
    this.TrailOffset = order.TrailOffset;
    this.TimeInForce = order.TimeInForce;
    this.ExpirationTime = order.ExpirationTime;
    this.PositionId = order.PositionId;
    this.GroupId = order.GroupId;
    this.Comment = order.Comment;
    foreach (SlTpHolder stopLossItem in order.StopLossItems)
      this.StopLossItems.Add(stopLossItem.Clone() as SlTpHolder);
    foreach (SlTpHolder takeProfitItem in order.TakeProfitItems)
      this.TakeProfitItems.Add(takeProfitItem.Clone() as SlTpHolder);
    try
    {
      if (this.OrderType == null)
        return;
      IList<SettingItem> orderSettings = this.OrderType.GetOrderSettings(this, new FormatSettings()
      {
        DisplayQuantityInLots = true
      });
      orderSettings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓷(), (object) (int) this.TimeInForce);
      orderSettings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픟(), (object) this.ExpirationTime);
      orderSettings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇핈(), (object) (int) this.Side);
      orderSettings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓢(), (object) this.Quantity);
      orderSettings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍핈(), (object) this.Price);
      orderSettings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓜(), (object) this.TriggerPrice);
      if (!double.IsNaN(this.TrailOffset))
        orderSettings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픺(), (object) (int) this.TrailOffset);
      orderSettings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픤(), (object) this.Comment);
      if (order.AdditionalInfo != null)
      {
        foreach (AdditionalInfoItem additionalInfoItem in order.AdditionalInfo)
          orderSettings.UpdateItemValue(additionalInfoItem.Id, additionalInfoItem.Value);
      }
      this.AdditionalParameters = orderSettings;
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
  }

  protected OrderRequestParameters(OrderRequestParameters origin)
    : base((TradingRequestParameters) origin)
  {
    this.퓏();
    this.UpdateFrom(origin);
  }

  private void 퓏()
  {
    this.픜퓽 = new List<SettingItem>();
    this.Price = double.NaN;
    this.TriggerPrice = double.NaN;
    this.TrailOffset = double.NaN;
    this.StopLossItems = new List<SlTpHolder>();
    this.TakeProfitItems = new List<SlTpHolder>();
  }

  protected override Account GetAccount() => this.Account;

  public abstract object Clone();

  public void UpdateFrom(OrderRequestParameters origin)
  {
    if (origin == null)
      return;
    this.Symbol = origin.Symbol;
    this.Account = origin.Account;
    this.Side = origin.Side;
    this.Quantity = origin.Quantity;
    this.Total = origin.Total;
    this.OrderTypeId = origin.OrderTypeId;
    this.Price = origin.Price;
    this.TriggerPrice = origin.TriggerPrice;
    this.TrailOffset = origin.TrailOffset;
    this.TimeInForce = origin.TimeInForce;
    this.ExpirationTime = origin.ExpirationTime;
    this.Slippage = origin.Slippage;
    this.PositionId = origin.PositionId;
    this.GroupId = origin.GroupId;
    this.Comment = origin.Comment;
    this.AdditionalParameters = origin.AdditionalParameters;
    this.SendingSource = origin.SendingSource;
    this.QuantityDefinitionSettingName = origin.QuantityDefinitionSettingName;
    this.CancellationToken = origin.CancellationToken;
    foreach (SlTpHolder stopLossItem in origin.StopLossItems)
      this.StopLossItems.Add(stopLossItem.Clone() as SlTpHolder);
    foreach (SlTpHolder takeProfitItem in origin.TakeProfitItems)
      this.TakeProfitItems.Add(takeProfitItem.Clone() as SlTpHolder);
  }

  public void ApplyValuesFrom(OrderRequestParameters other)
  {
    if (other == null)
      return;
    if (other.Symbol != null)
      this.Symbol = other.Symbol;
    if (other.Account != null)
      this.Account = other.Account;
    if (!string.IsNullOrEmpty(other.OrderTypeId))
      this.OrderTypeId = other.OrderTypeId;
    if (other.Slippage != 0)
      this.Slippage = other.Slippage;
    if (!string.IsNullOrEmpty(other.PositionId))
      this.PositionId = other.PositionId;
    if (!string.IsNullOrEmpty(other.GroupId))
      this.GroupId = other.GroupId;
    if (!string.IsNullOrEmpty(other.SendingSource))
      this.SendingSource = other.SendingSource;
    if (!string.IsNullOrEmpty(other.QuantityDefinitionSettingName))
      this.QuantityDefinitionSettingName = other.QuantityDefinitionSettingName;
    if (other.CancellationToken != CancellationToken.None)
      this.CancellationToken = other.CancellationToken;
    if (other.StopLossItems.Any<SlTpHolder>())
      this.StopLossItems = other.StopLossItems;
    if (other.TakeProfitItems.Any<SlTpHolder>())
      this.TakeProfitItems = other.TakeProfitItems;
    IList<SettingItem> additionalParameters1 = this.AdditionalParameters;
    IList<SettingItem> additionalParameters2 = other.AdditionalParameters;
    additionalParameters1.MergeWith(additionalParameters2);
    this.AdditionalParameters = additionalParameters1;
  }

  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 7);
    interpolatedStringHandler.AppendFormatted(base.ToString());
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프());
    interpolatedStringHandler.AppendFormatted<Side>(this.Side);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프());
    interpolatedStringHandler.AppendFormatted(this.OrderTypeId);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프());
    interpolatedStringHandler.AppendFormatted<double>(this.Quantity);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프());
    interpolatedStringHandler.AppendFormatted<Symbol>(this.Symbol);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프());
    interpolatedStringHandler.AppendFormatted<Account>(this.Account);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프());
    interpolatedStringHandler.AppendFormatted<double?>(this.OrderType?.GetFillPrice(this));
    return interpolatedStringHandler.ToStringAndClear();
  }

  public override string Message
  {
    get
    {
      OrderType orderType = this.OrderType;
      IOrderedEnumerable<DealTicketItem> orderedEnumerable1;
      if (orderType == null)
      {
        orderedEnumerable1 = (IOrderedEnumerable<DealTicketItem>) null;
      }
      else
      {
        IList<DealTicketItem> dealTicketItems = orderType.GetDealTicketItems(this);
        orderedEnumerable1 = dealTicketItems != null ? dealTicketItems.OrderBy<DealTicketItem, int>((Func<DealTicketItem, int>) (([In] obj0) => obj0.SortIndex)) : (IOrderedEnumerable<DealTicketItem>) null;
      }
      IOrderedEnumerable<DealTicketItem> orderedEnumerable2 = orderedEnumerable1;
      if (orderedEnumerable2 == null)
        return string.Empty;
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder.AppendInterpolatedStringHandler interpolatedStringHandler;
      foreach (DealTicketItem dealTicketItem in (IEnumerable<DealTicketItem>) orderedEnumerable2)
      {
        StringBuilder stringBuilder2 = stringBuilder1;
        StringBuilder stringBuilder3 = stringBuilder2;
        interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(4, 2, stringBuilder2);
        interpolatedStringHandler.AppendFormatted(dealTicketItem.Key);
        interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓡());
        interpolatedStringHandler.AppendFormatted(dealTicketItem.FormattedValue);
        interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬());
        ref StringBuilder.AppendInterpolatedStringHandler local = ref interpolatedStringHandler;
        stringBuilder3.Append(ref local);
      }
      StringBuilder stringBuilder4 = stringBuilder1;
      StringBuilder stringBuilder5 = stringBuilder4;
      interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(13, 1, stringBuilder4);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픈());
      interpolatedStringHandler.AppendFormatted<long>(this.RequestId);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬());
      ref StringBuilder.AppendInterpolatedStringHandler local1 = ref interpolatedStringHandler;
      stringBuilder5.Append(ref local1);
      return stringBuilder1.ToString();
    }
  }

  public XElement ToXElement()
  {
    XElement xelement1 = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓸());
    if (this.Symbol != null)
      xelement1.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픟(), (object) this.Symbol.CreateInfo().ToXElement()));
    if (this.Account != null)
      xelement1.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픆(), (object) this.Account.CreateInfo().ToXElement()));
    XElement xelement2 = xelement1;
    XName name1 = (XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇핈();
    int num = (int) this.Side;
    string content1 = num.ToString();
    XElement content2 = new XElement(name1, (object) content1);
    xelement2.Add((object) content2);
    xelement1.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓢(), (object) this.Quantity));
    xelement1.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓔(), (object) this.Total));
    xelement1.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓦(), (object) this.QuantityDefinitionSettingName));
    xelement1.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇핉(), (object) this.OrderTypeId));
    xelement1.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍핈(), (object) this.Price));
    xelement1.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓜(), (object) this.TriggerPrice));
    xelement1.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픺(), (object) this.TrailOffset));
    XElement xelement3 = xelement1;
    XName name2 = (XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇핊();
    num = (int) this.TimeInForce;
    string content3 = num.ToString();
    XElement content4 = new XElement(name2, (object) content3);
    xelement3.Add((object) content4);
    xelement1.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픛(), (object) this.ExpirationTime));
    xelement1.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픋(), (object) this.Slippage));
    xelement1.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픐(), (object) this.PositionId));
    if (this.StopLossItems.Count > 0)
    {
      XElement content5 = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙핀());
      foreach (SlTpHolder stopLossItem in this.StopLossItems)
        content5.Add((object) stopLossItem.ToXElement());
      xelement1.Add((object) content5);
    }
    if (this.TakeProfitItems.Count > 0)
    {
      XElement content6 = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픲());
      foreach (SlTpHolder takeProfitItem in this.TakeProfitItems)
        content6.Add((object) takeProfitItem.ToXElement());
      xelement1.Add((object) content6);
    }
    xelement1.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓕(), (object) this.GroupId));
    xelement1.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픤(), (object) this.Comment));
    if (this.AdditionalParameters != null)
    {
      XElement content7 = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픽());
      foreach (SettingItem additionalParameter in (IEnumerable<SettingItem>) this.AdditionalParameters)
        content7.Add((object) additionalParameter.ToXElement());
      xelement1.Add((object) content7);
    }
    return xelement1;
  }

  public void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    XElement xelement1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓸());
    if (xelement1 == null)
      return;
    XElement xelement2 = xelement1.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픟());
    if (xelement2 != null)
    {
      XElement element1 = xelement2.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픍());
      if (element1 != null)
      {
        SymbolInfo symbolInfo = new SymbolInfo();
        symbolInfo.FromXElement(element1, deserializationInfo);
        this.Symbol = Core.Instance.GetSymbol((BusinessObjectInfo) symbolInfo);
      }
    }
    XElement xelement3 = xelement1.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픆());
    if (xelement3 != null)
    {
      XElement element2 = xelement3.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픍());
      if (element2 != null)
      {
        픟 accountInfo = new 픟();
        accountInfo.FromXElement(element2, deserializationInfo);
        this.Account = Core.Instance.GetAccount((BusinessObjectInfo) accountInfo);
      }
    }
    XElement element3 = xelement1.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇핈());
    if (element3 != null)
      this.Side = (Side) element3.ToInt();
    XElement element4 = xelement1.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓢());
    if (element4 != null)
      this.Quantity = element4.ToDouble();
    XElement element5 = xelement1.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓔());
    if (element5 != null)
      this.Total = element5.ToDouble();
    XElement xelement4 = xelement1.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓦());
    if (xelement4 != null)
      this.QuantityDefinitionSettingName = xelement4.ToString();
    XElement xelement5 = xelement1.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇핉());
    if (xelement5 != null)
      this.OrderTypeId = xelement5.Value;
    XElement element6 = xelement1.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍핈());
    if (element6 != null)
      this.Price = element6.ToDouble();
    XElement element7 = xelement1.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓜());
    if (element7 != null)
      this.TriggerPrice = element7.ToDouble();
    XElement element8 = xelement1.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픺());
    if (element8 != null)
      this.TrailOffset = element8.ToDouble();
    XElement element9 = xelement1.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇핊());
    if (element9 != null)
      this.TimeInForce = (TimeInForce) element9.ToInt();
    XElement element10 = xelement1.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픛());
    if (element10 != null)
      this.ExpirationTime = element10.ToDateTime();
    XElement element11 = xelement1.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픋());
    if (element11 != null)
      this.Slippage = element11.ToInt();
    XElement xelement6 = xelement1.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픐());
    if (xelement6 != null)
      this.PositionId = xelement6.Value;
    XElement xelement7 = xelement1.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙핀());
    if (xelement7 != null)
    {
      foreach (XElement element12 in xelement7.Elements())
      {
        SlTpHolder slTpHolder = new SlTpHolder();
        slTpHolder.FromXElement(element12, deserializationInfo);
        this.StopLossItems.Add(slTpHolder);
      }
    }
    XElement xelement8 = xelement1.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픲());
    if (xelement8 != null)
    {
      foreach (XElement element13 in xelement8.Elements())
      {
        SlTpHolder slTpHolder = new SlTpHolder();
        slTpHolder.FromXElement(element13, deserializationInfo);
        this.TakeProfitItems.Add(slTpHolder);
      }
    }
    XElement xelement9 = xelement1.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픽());
    if (xelement9 == null)
      return;
    List<SettingItem> settingItemList = new List<SettingItem>();
    foreach (XElement element14 in xelement9.Elements())
    {
      if (Serializer.DeserializeNode(element14, deserializationInfo) is SettingItem settingItem)
        settingItemList.Add(settingItem);
    }
    this.AdditionalParameters = (IList<SettingItem>) settingItemList;
  }

  public bool Equals(OrderRequestParameters other)
  {
    if (other == null)
      return false;
    if (this == other)
      return true;
    if (this.픜퓳 == other.픜퓳 && object.Equals((object) this.픜픘, (object) other.픜픘) && object.Equals((object) this.Account, (object) other.Account) && this.Side == other.Side)
    {
      double num = this.Quantity;
      if (num.Equals(other.Quantity))
      {
        num = this.Total;
        if (num.Equals(other.Total) && this.QuantityDefinitionSettingName == other.QuantityDefinitionSettingName)
        {
          num = this.Price;
          if (num.Equals(other.Price))
          {
            num = this.TriggerPrice;
            if (num.Equals(other.TriggerPrice))
            {
              num = this.TrailOffset;
              if (num.Equals(other.TrailOffset) && this.TimeInForce == other.TimeInForce && this.ExpirationTime.Equals(other.ExpirationTime) && this.Slippage == other.Slippage && this.PositionId == other.PositionId && this.GroupId == other.GroupId && this.Comment == other.Comment && OrderRequestParameters.픜픨.Equals((IList<SlTpHolder>) this.StopLossItems, (IList<SlTpHolder>) other.StopLossItems) && OrderRequestParameters.픜픨.Equals((IList<SlTpHolder>) this.TakeProfitItems, (IList<SlTpHolder>) other.TakeProfitItems))
                return OrderRequestParameters.픜퓪.Equals((IList<SettingItem>) this.픜퓽, (IList<SettingItem>) other.픜퓽);
            }
          }
        }
      }
    }
    return false;
  }

  public override bool Equals(object obj)
  {
    if (obj == null)
      return false;
    if (this == obj)
      return true;
    return !(obj.GetType() != this.GetType()) && this.Equals((OrderRequestParameters) obj);
  }

  public override int GetHashCode()
  {
    HashCode hashCode = new HashCode();
    hashCode.Add<string>(this.픜퓳);
    hashCode.Add<List<SettingItem>>(this.픜퓽);
    hashCode.Add<LocalOrder>(this.픜픘);
    hashCode.Add<Account>(this.Account);
    hashCode.Add<int>((int) this.Side);
    hashCode.Add<double>(this.Quantity);
    hashCode.Add<double>(this.Total);
    hashCode.Add<string>(this.QuantityDefinitionSettingName);
    hashCode.Add<double>(this.Price);
    hashCode.Add<double>(this.TriggerPrice);
    hashCode.Add<double>(this.TrailOffset);
    hashCode.Add<int>((int) this.TimeInForce);
    hashCode.Add<DateTime>(this.ExpirationTime);
    hashCode.Add<int>(this.Slippage);
    hashCode.Add<string>(this.PositionId);
    hashCode.Add<List<SlTpHolder>>(this.StopLossItems);
    hashCode.Add<List<SlTpHolder>>(this.TakeProfitItems);
    hashCode.Add<string>(this.GroupId);
    hashCode.Add<string>(this.Comment);
    return hashCode.ToHashCode();
  }
}
