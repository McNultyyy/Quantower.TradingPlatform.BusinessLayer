// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.TradingOperationResult
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>Defines a trading operation respond bundle</summary>
public sealed class TradingOperationResult : ILoggable
{
  /// <summary>Respond operation state</summary>
  public TradingOperationResultStatus Status { get; [param: In] private set; }

  /// <summary>Respond message</summary>
  public string Message { get; [param: In] private set; }

  /// <summary>Respond order id</summary>
  public string OrderId { get; [param: In] private set; }

  public long RequestId { get; [param: In] private set; }

  private TradingOperationResult()
  {
  }

  public static TradingOperationResult CreateSuccess(long requestId, string orderId = null)
  {
    return new TradingOperationResult()
    {
      RequestId = requestId,
      Status = TradingOperationResultStatus.Success,
      OrderId = orderId
    };
  }

  public static TradingOperationResult CreateError(long requestId, string message)
  {
    return new TradingOperationResult()
    {
      RequestId = requestId,
      Status = TradingOperationResultStatus.Failure,
      Message = message
    };
  }

  [NotPublished]
  public void SetOrderId(string orderId) => this.OrderId = orderId;

  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 3);
    interpolatedStringHandler.AppendFormatted<TradingOperationResultStatus>(this.Status);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픇());
    interpolatedStringHandler.AppendFormatted(this.Status == TradingOperationResultStatus.Success ? \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픣() + this.OrderId : this.Message);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓙());
    interpolatedStringHandler.AppendFormatted<long>(this.RequestId);
    return interpolatedStringHandler.ToStringAndClear();
  }

  string ILoggable.Event => \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓗();

  string ILoggable.Message => this.ToString();
}
