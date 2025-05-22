// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.ModifyOrderRequestParameters
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[Published]
public class ModifyOrderRequestParameters : OrderRequestParameters
{
  public override RequestType Type => RequestType.ModifyOrder;

  public override string Event
  {
    get
    {
      return this.OrderType == null ? string.Empty : this.OrderType.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓝();
    }
  }

  /// <summary>Id of the order</summary>
  public string OrderId { get; set; }

  [NotPublished]
  public ModifyOrderRequestParameters()
  {
  }

  public ModifyOrderRequestParameters(IOrder order)
    : base(order)
  {
    this.OrderId = order.Id;
    this.Quantity = order.RemainingQuantity;
  }

  public ModifyOrderRequestParameters(ModifyOrderRequestParameters original)
    : base((OrderRequestParameters) original)
  {
    this.OrderId = original.OrderId;
  }

  public override object Clone() => (object) new ModifyOrderRequestParameters(this);

  public override string ToString()
  {
    return this.OrderId + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓓() + base.ToString() + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픗();
  }
}
