// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.PlaceOrderRequestParameters
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[Published]
public class PlaceOrderRequestParameters : OrderRequestParameters
{
  public override RequestType Type => RequestType.PlaceOrder;

  public override string Event
  {
    get
    {
      return (this.OrderType?.Name ?? \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓘()) + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓶();
    }
  }

  public PlaceOrderRequestParameters()
  {
  }

  public PlaceOrderRequestParameters(IOrder order)
    : base(order)
  {
  }

  public PlaceOrderRequestParameters(OrderRequestParameters original)
    : base(original)
  {
  }

  public override object Clone()
  {
    return (object) new PlaceOrderRequestParameters((OrderRequestParameters) this);
  }
}
