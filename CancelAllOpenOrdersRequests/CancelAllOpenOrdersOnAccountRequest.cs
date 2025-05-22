// Decompiled with JetBrains decompiler
// Type: CancelAllOpenOrdersRequests.CancelAllOpenOrdersOnAccountRequest
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using TradingPlatform.BusinessLayer;

#nullable disable
namespace CancelAllOpenOrdersRequests;

public class CancelAllOpenOrdersOnAccountRequest : RequestParameters, ISubTradingOperation
{
  public override RequestType Type => RequestType.Custom;

  public string AccountId { get; }

  public GroupTradingOperation ParentOperation { get; init; }

  public CancelAllOpenOrdersOnAccountRequest(string accountId) => this.AccountId = accountId;
}
