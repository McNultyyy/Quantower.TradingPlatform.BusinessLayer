// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.ClosedPosition
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Integration;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public class ClosedPosition : Position
{
  public double LastTradedPrice { get; [param: In] private set; }

  internal ClosedPosition([In] string obj0)
    : base(obj0)
  {
  }

  public override TradingOperationResult Close(double closeQuantity = -1.0)
  {
    return TradingOperationResult.CreateError(new ClosePositionRequestParameters().RequestId, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎필());
  }

  internal override void 퓏([In] MessageOpenPosition obj0)
  {
    base.퓏(obj0);
    if (!(obj0 is MessageClosedPosition messageClosedPosition))
      return;
    this.LastTradedPrice = messageClosedPosition.LastTradedPrice;
  }
}
