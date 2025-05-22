// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.PlaceMultiOrderOrderRequestParameters
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public class PlaceMultiOrderOrderRequestParameters : TradingRequestParameters
{
  public override string ConnectionId
  {
    get
    {
      PlaceOrderRequestParameters[] orderParameters = this.OrderParameters;
      if (orderParameters == null)
        return (string) null;
      return ((IEnumerable<PlaceOrderRequestParameters>) orderParameters).FirstOrDefault<PlaceOrderRequestParameters>()?.Symbol?.ConnectionId;
    }
  }

  public override string Event
  {
    get => \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓏();
  }

  public override string Message
  {
    get
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 1);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓬());
      interpolatedStringHandler.AppendFormatted<long>(this.RequestId);
      return interpolatedStringHandler.ToStringAndClear();
    }
  }

  protected override Account GetAccount() => (Account) null;

  public override RequestType Type => RequestType.PlaceMultiOrderOrder;

  public PlaceOrderRequestParameters[] OrderParameters { get; set; }

  public GroupOrderType GroupOrderType { get; set; }

  public PlaceMultiOrderOrderRequestParameters()
  {
  }

  public PlaceMultiOrderOrderRequestParameters(PlaceMultiOrderOrderRequestParameters original)
    : base((TradingRequestParameters) original)
  {
    this.OrderParameters = original.OrderParameters;
    this.GroupOrderType = original.GroupOrderType;
  }
}
