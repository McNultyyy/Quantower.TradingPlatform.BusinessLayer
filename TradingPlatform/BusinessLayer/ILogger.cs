// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.ILogger
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public interface ILogger : IDisposable
{
  LoggerScope AllowedScopes { get; }

  void Configure(LoggerConfig loggerConfig);

  void Log(string message, DateTime date, LoggingLevel level = LoggingLevel.System, string connection = null);

  void Log(
    string message,
    Exception exception,
    DateTime date,
    LoggingLevel level = LoggingLevel.Error,
    string connection = null);

  void Log(Exception exception, DateTime date, LoggingLevel level = LoggingLevel.Error, string connection = null);

  void Log(ILoggable loggable, DateTime date, LoggingLevel level = LoggingLevel.Error, string connection = null);

  List<LoggerEvent> GetHistory(DateTime from, DateTime to);

  void DeleteLogFilesExcept(DateTime from, DateTime to);
}
