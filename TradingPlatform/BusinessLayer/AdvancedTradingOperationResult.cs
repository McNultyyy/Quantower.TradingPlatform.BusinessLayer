// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.AdvancedTradingOperationResult
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>Defines advanced trading operation respond bundle</summary>
public sealed class AdvancedTradingOperationResult
{
  /// <summary>
  /// Respond operation state <see cref="T:TradingPlatform.BusinessLayer.AdvancedTradingOperationResultStatus" />
  /// </summary>
  public AdvancedTradingOperationResultStatus Status { get; [param: In] private set; }

  /// <summary>Respond message</summary>
  public string Message { get; [param: In] private set; }

  /// <summary>Respond value (optional)</summary>
  public object Value { get; [param: In] internal set; }

  /// <summary>Details of sub-operations</summary>
  public IDictionary<RequestParameters, TradingOperationResult> Details { get; [param: In] private set; }

  internal AdvancedTradingOperationResult()
  {
    this.Status = AdvancedTradingOperationResultStatus.Success;
    this.Details = (IDictionary<RequestParameters, TradingOperationResult>) new Dictionary<RequestParameters, TradingOperationResult>();
  }

  internal AdvancedTradingOperationResult([In] RequestParameters obj0, [In] TradingOperationResult obj1)
    : this()
  {
    this.퓏(obj0, obj1);
  }

  internal static AdvancedTradingOperationResult 퓏() => new AdvancedTradingOperationResult();

  internal static AdvancedTradingOperationResult 퓏([In] string obj0)
  {
    return new AdvancedTradingOperationResult()
    {
      Status = AdvancedTradingOperationResultStatus.Failure,
      Message = obj0
    };
  }

  internal void 퓏([In] RequestParameters obj0, [In] TradingOperationResult obj1)
  {
    this.Details.Add(obj0, obj1);
    this.퓬();
  }

  internal AdvancedTradingOperationResult 퓏([In] AdvancedTradingOperationResult obj0)
  {
    foreach ((RequestParameters key, TradingOperationResult tradingOperationResult) in (IEnumerable<KeyValuePair<RequestParameters, TradingOperationResult>>) obj0.Details)
      this.Details.Add(key, tradingOperationResult);
    this.퓬();
    return this;
  }

  private void 퓬()
  {
    int num = 0;
    string str = (string) null;
    foreach (TradingOperationResult tradingOperationResult in (IEnumerable<TradingOperationResult>) this.Details.Values)
    {
      switch (tradingOperationResult.Status)
      {
        case TradingOperationResultStatus.Success:
          ++num;
          continue;
        case TradingOperationResultStatus.Failure:
          if (str == null)
          {
            str = tradingOperationResult.Message;
            continue;
          }
          continue;
        default:
          continue;
      }
    }
    if (num == this.Details.Count)
    {
      this.Status = AdvancedTradingOperationResultStatus.Success;
    }
    else
    {
      this.Message = str;
      this.Status = num > 0 ? AdvancedTradingOperationResultStatus.PartiallySuccess : AdvancedTradingOperationResultStatus.Failure;
    }
  }
}
