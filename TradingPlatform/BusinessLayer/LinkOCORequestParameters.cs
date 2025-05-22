// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.LinkOCORequestParameters
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

#nullable disable
namespace TradingPlatform.BusinessLayer;

public class LinkOCORequestParameters : TradingRequestParameters
{
  public override RequestType Type => RequestType.Custom;

  public override string Event
  {
    get => \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓎();
  }

  public override string Message
  {
    get
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(21, 1);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙피());
      interpolatedStringHandler.AppendFormatted<long>(this.RequestId);
      return interpolatedStringHandler.ToStringAndClear();
    }
  }

  protected override Account GetAccount() => this.OrdersToLink.FirstOrDefault<IOrder>()?.Account;

  public override string ConnectionId
  {
    get
    {
      List<IOrder> ordersToLink = this.OrdersToLink;
      if (ordersToLink == null)
        return (string) null;
      return ordersToLink.FirstOrDefault<IOrder>()?.ConnectionId;
    }
  }

  public List<IOrder> OrdersToLink { get; set; }

  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
    interpolatedStringHandler.AppendFormatted(base.ToString());
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프());
    ref DefaultInterpolatedStringHandler local = ref interpolatedStringHandler;
    List<IOrder> ordersToLink = this.OrdersToLink;
    string[] array = ordersToLink != null ? ordersToLink.Select<IOrder, string>((Func<IOrder, string>) (([In] obj0) => obj0.Id)).ToArray<string>() : (string[]) null;
    local.AppendFormatted<string[]>(array);
    return interpolatedStringHandler.ToStringAndClear();
  }
}
