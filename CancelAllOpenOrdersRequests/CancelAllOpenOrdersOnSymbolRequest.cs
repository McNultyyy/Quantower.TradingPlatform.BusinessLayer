// Decompiled with JetBrains decompiler
// Type: CancelAllOpenOrdersRequests.CancelAllOpenOrdersOnSymbolRequest
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using TradingPlatform.BusinessLayer;

#nullable disable
namespace CancelAllOpenOrdersRequests;

public class CancelAllOpenOrdersOnSymbolRequest : RequestParameters, ISubTradingOperation
{
  public override RequestType Type => RequestType.Custom;

  public SymbolComplexIdentifier SymbolComplexIdentifier { get; }

  public string[] OrderIdArray { get; }

  public GroupTradingOperation ParentOperation { get; init; }

  public CancelAllOpenOrdersOnSymbolRequest(
    SymbolComplexIdentifier symbolComplexIdentifier,
    params string[] orderIdArray)
  {
    this.SymbolComplexIdentifier = symbolComplexIdentifier;
    this.OrderIdArray = orderIdArray;
  }
}
