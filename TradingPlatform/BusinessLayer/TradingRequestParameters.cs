// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.TradingRequestParameters
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[Published]
public abstract class TradingRequestParameters : 
  RequestParameters,
  IConnectionBindedObject,
  ILoggable,
  ICurrentAccount,
  ISubTradingOperation
{
  public abstract string ConnectionId { get; }

  public abstract string Event { get; }

  public abstract string Message { get; }

  public GroupTradingOperation ParentOperation { get; init; }

  protected abstract Account GetAccount();

  Account ICurrentAccount.CurrentAccount
  {
    get => this.GetAccount();
    [param: In] set
    {
    }
  }

  public TradingRequestParameters()
  {
  }

  public TradingRequestParameters(TradingRequestParameters origin)
    : base((RequestParameters) origin)
  {
    this.ParentOperation = origin.ParentOperation;
  }
}
