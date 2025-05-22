// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.AllowedResult
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>The allowed result.</summary>
public sealed class AllowedResult
{
  /// <summary>Gets the status.</summary>
  public TradingOperationStatus Status { get; [param: In] private set; }

  /// <summary>Gets the reason.</summary>
  public string Reason { get; [param: In] private set; }

  /// <summary>Get the allowed result.</summary>
  /// <returns>An AllowedResult.</returns>
  public static AllowedResult GetAllowedResult()
  {
    return new AllowedResult()
    {
      Status = TradingOperationStatus.Allowed
    };
  }

  /// <summary>Gets the not allowed result.</summary>
  /// <param name="reason">The reason.</param>
  /// <returns>An AllowedResult.</returns>
  public static AllowedResult GetNotAllowedResult(string reason = "")
  {
    return new AllowedResult()
    {
      Status = TradingOperationStatus.NotAllowed,
      Reason = reason
    };
  }
}
