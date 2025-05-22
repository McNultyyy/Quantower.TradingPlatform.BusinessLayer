// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.PingResult
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

/// <summary>Ping respond bundle</summary>
public class PingResult
{
  /// <summary>Ping time</summary>
  public TimeSpan? PingTime { get; set; }

  /// <summary>Time spent for single request</summary>
  public TimeSpan? RoundTripTime { get; set; }

  /// <summary>Ping state</summary>
  public PingEnum State { get; set; }

  /// <summary>Disable auto reconnecting</summary>
  public bool StopReconnecting { get; set; }

  public static PingResult Disconnected()
  {
    return new PingResult()
    {
      State = PingEnum.Disconnected
    };
  }
}
