// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.StrategyExtensions
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

#nullable disable
namespace TradingPlatform.BusinessLayer;

public static class StrategyExtensions
{
  /// <summary>Write info log message</summary>
  public static void LogInfo(this Strategy strategy, string message) => strategy.Log(message);

  /// <summary>Write trading log message</summary>
  public static void LogTrading(this Strategy strategy, string message)
  {
    strategy.Log(message, StrategyLoggingLevel.Trading);
  }

  /// <summary>Write error log message</summary>
  public static void LogError(this Strategy strategy, string message)
  {
    strategy.Log(message, StrategyLoggingLevel.Error);
  }
}
