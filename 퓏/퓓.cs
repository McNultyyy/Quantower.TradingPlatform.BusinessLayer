// Decompiled with JetBrains decompiler
// Type: 퓏.퓓
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer;

#nullable disable
namespace 퓏;

internal class 퓓 : ILogger, IDisposable
{
  private readonly ICollection<ILogger> 핁픸;

  public LoggerScope AllowedScopes { get; }

  public 퓓([In] ICollection<ILogger> obj0)
  {
    this.핁픸 = (ICollection<ILogger>) new List<ILogger>();
    foreach (ILogger logger in (IEnumerable<ILogger>) obj0)
      this.핁픸.Add(logger);
  }

  public void Configure(LoggerConfig loggerConfig)
  {
    foreach (ILogger logger in (IEnumerable<ILogger>) this.핁픸)
    {
      try
      {
        logger.Configure(loggerConfig);
      }
      catch (Exception ex)
      {
      }
    }
  }

  public void Log(string message, DateTime date, LoggingLevel level = LoggingLevel.System, string connection = null)
  {
    foreach (ILogger logger in (IEnumerable<ILogger>) this.핁픸)
    {
      try
      {
        logger.Log(message, date, level, connection);
      }
      catch (Exception ex)
      {
      }
    }
  }

  public void Log(
    string message,
    Exception exception,
    DateTime date,
    LoggingLevel level = LoggingLevel.Error,
    string connection = null)
  {
    foreach (ILogger logger in (IEnumerable<ILogger>) this.핁픸)
    {
      try
      {
        logger.Log(message, exception, date, level, connection);
      }
      catch (Exception ex)
      {
      }
    }
  }

  public void Log(Exception exception, DateTime date, LoggingLevel level = LoggingLevel.Error, string connection = null)
  {
    foreach (ILogger logger in (IEnumerable<ILogger>) this.핁픸)
    {
      try
      {
        logger.Log(exception, date, level, connection);
      }
      catch (Exception ex)
      {
      }
    }
  }

  public void Log(ILoggable loggable, DateTime date, LoggingLevel level = LoggingLevel.Error, string connection = null)
  {
    foreach (ILogger logger in (IEnumerable<ILogger>) this.핁픸)
    {
      try
      {
        logger.Log(loggable, date, level, connection);
      }
      catch (Exception ex)
      {
      }
    }
  }

  public List<LoggerEvent> GetHistory(DateTime from, DateTime to)
  {
    List<LoggerEvent> history = new List<LoggerEvent>();
    ILogger logger = this.핁픸.FirstOrDefault<ILogger>();
    if (logger != null)
      history.AddRange((IEnumerable<LoggerEvent>) logger.GetHistory(from, to));
    return history;
  }

  public void DeleteLogFilesExcept(DateTime from, DateTime to)
  {
    foreach (ILogger logger in (IEnumerable<ILogger>) this.핁픸)
      logger.DeleteLogFilesExcept(from, to);
  }

  public void Dispose()
  {
    foreach (IDisposable disposable in (IEnumerable<ILogger>) this.핁픸)
      disposable.Dispose();
    this.핁픸.Clear();
  }
}
