// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.NewsRealtimeByTimerUpdater
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

public sealed class NewsRealtimeByTimerUpdater : IDisposable
{
  private bool 핂픑;
  private readonly Timer 핂픿;
  private readonly ConcurrentDictionary<string, 퓏.픿> 핂퓔;
  private readonly Action<Message> 핂픢;
  private readonly Func<GetNewsRequestParameters, IEnumerable<MessageNewsHeadline>> 핂퓝;

  public NewsRealtimeByTimerUpdater(
    Action<Message> pushMessage,
    Func<GetNewsRequestParameters, IEnumerable<MessageNewsHeadline>> getNews,
    TimeSpan updatePeriod)
  {
    this.핂픢 = pushMessage;
    this.핂퓝 = getNews;
    this.핂퓔 = new ConcurrentDictionary<string, 퓏.픿>();
    this.핂픿 = new Timer(new TimerCallback(this.퓏), (object) null, updatePeriod, updatePeriod);
  }

  public void Dispose() => this.핂픿.Dispose();

  public void SubscribeNewsUpdates(SubscribeNewsRequestParameters parameters)
  {
    this.핂퓔[parameters.SubscribeId] = new 퓏.픿(parameters.AdditionalParameters)
    {
      lastRealTimeNewsRequestTime = Core.Instance.TimeUtils.DateTimeUtcNow
    };
  }

  public void UnsubscribeNewsUpdates(SubscribeNewsRequestParameters parameters)
  {
    this.핂퓔.TryRemove(parameters.SubscribeId, out 퓏.픿 _);
  }

  private void 퓏([In] object obj0)
  {
    if (this.핂픑)
      return;
    try
    {
      this.핂픑 = true;
      DateTime dateTimeUtcNow = Core.Instance.TimeUtils.DateTimeUtcNow;
      foreach (KeyValuePair<string, 퓏.픿> keyValuePair in this.핂퓔)
      {
        Func<GetNewsRequestParameters, IEnumerable<MessageNewsHeadline>> 핂퓝 = this.핂퓝;
        GetNewsRequestParameters requestParameters = new GetNewsRequestParameters();
        requestParameters.AdditionalParameters = keyValuePair.Value.핂퓶;
        requestParameters.From = keyValuePair.Value.lastRealTimeNewsRequestTime;
        requestParameters.To = dateTimeUtcNow;
        IEnumerable<MessageNewsHeadline> messageNewsHeadlines = 핂퓝(requestParameters);
        keyValuePair.Value.lastRealTimeNewsRequestTime = dateTimeUtcNow;
        foreach (MessageNewsHeadline messageNewsHeadline in messageNewsHeadlines)
        {
          messageNewsHeadline.SubscribeId = keyValuePair.Key;
          this.핂픢((Message) messageNewsHeadline);
        }
      }
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
    finally
    {
      this.핂픑 = false;
    }
  }
}
