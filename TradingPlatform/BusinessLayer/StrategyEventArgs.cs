// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.StrategyEventArgs
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public class StrategyEventArgs : EventArgs
{
  public StrategyState StrategyState { get; [param: In] private set; }

  public StrategyState StrategyPreviousState { get; [param: In] internal set; }

  public LoggerEvent LoggerEvent { get; [param: In] private set; }

  public StrategyEventArgs(StrategyState strategyState, LoggerEvent loggerEvent = null)
  {
    this.StrategyState = strategyState;
    this.LoggerEvent = loggerEvent;
  }
}
