// Decompiled with JetBrains decompiler
// Type: 퓏.퓯
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using TradingPlatform.BusinessLayer;
using TradingPlatform.BusinessLayer.TimeSync;

#nullable disable
namespace 퓏;

internal sealed class 퓯 : IDisposable
{
  private const int 핇퓾 = 1800000;
  private ReadOnlyCollection<string> 핇플;
  private Timer 핇픥;

  public int ServerTimeOffset { get; [param: In] private set; }

  public 픜 State { get; [param: In] private set; }

  public string LastSyncErrorMessage { get; [param: In] private set; }

  public 퓯() => this.State = 픜.핇퓼;

  public void 퓏()
  {
    this.ServerTimeOffset = 0;
    this.핇플 = ((IList<string>) new string[4]
    {
      \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픔(),
      \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇핈(),
      \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픤(),
      \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓟()
    }).AsReadOnly<string>();
    this.핇픥 = new Timer(new TimerCallback(this.퓏), (object) null, TimeSpan.FromMilliseconds(-1.0), new TimeSpan(1, 0, 0));
    this.퓬();
  }

  public void Dispose()
  {
    if (this.핇픥 == null)
      return;
    this.핇픥.Dispose();
    this.핇픥 = (Timer) null;
  }

  public void 퓬()
  {
    bool flag = false;
    string message = string.Empty;
    try
    {
      this.State = 픜.핇퓴;
      foreach (string host in this.핇플)
      {
        try
        {
          using (NTPClient ntpClient = new NTPClient(host))
          {
            ntpClient.Connect();
            if (ntpClient.IsResponseValid())
            {
              if (ntpClient.LocalClockOffset <= 1800000)
              {
                flag = true;
                this.ServerTimeOffset = ntpClient.LocalClockOffset;
                LoggerManager loggers = Core.Instance.Loggers;
                DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(45, 1);
                interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇핉());
                interpolatedStringHandler.AppendFormatted<int>(this.ServerTimeOffset);
                interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프());
                string stringAndClear = interpolatedStringHandler.ToStringAndClear();
                loggers.Log(stringAndClear);
                break;
              }
              Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇핊() + host);
            }
          }
        }
        catch (Exception ex)
        {
          message = ex.Message;
          Core.Instance.Loggers.Log(message, LoggingLevel.Verbose);
        }
      }
    }
    finally
    {
      if (flag)
      {
        this.State = 픜.핇픳;
        this.LastSyncErrorMessage = string.Empty;
      }
      else
      {
        this.State = 픜.핇픙;
        this.LastSyncErrorMessage = message;
      }
    }
  }

  private void 퓏([In] object obj0) => this.퓬();
}
