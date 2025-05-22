// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.HistoryProcessor
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public abstract class HistoryProcessor : IHistoryProcessor, IDisposable
{
  protected long sessionOffset;

  public event HistoryEventHandler NewHistoryItem;

  public event HistoryEventHandler HistoryItemUpdated;

  public virtual SubscribeQuoteType? GetSubscribeQuoteType => new SubscribeQuoteType?();

  public virtual void Initialize(HistoryRequestParameters historyRequestParameters)
  {
    try
    {
      if (historyRequestParameters?.SessionsContainer == null)
        return;
      this.sessionOffset = -historyRequestParameters.SessionsContainer.GetSessionOpenTime(Core.Instance.TimeUtils.SelectedTimeZone);
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
  }

  public virtual IList<IHistoryItem> AggregateHistory(HistoryHolder historyHolder)
  {
    return historyHolder.History;
  }

  public virtual void ProcessQuote(MessageQuote messageQuote)
  {
  }

  public virtual void CorrectHistoryRequestBorders(HistoryRequestParameters historyRequestParameters)
  {
  }

  public virtual string GetTimeToNextBar() => (string) null;

  public virtual void Dispose()
  {
  }

  protected void OnNewHistoryItem(HistoryEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    HistoryEventHandler 퓍퓪 = this.퓍퓪;
    if (퓍퓪 == null)
      return;
    퓍퓪((object) this, e);
  }

  protected void OnHistoryItemUpdated(HistoryEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    HistoryEventHandler 퓍픪 = this.퓍픪;
    if (퓍픪 == null)
      return;
    퓍픪((object) this, e);
  }

  public static bool IsDayOpeningNow(long barTime, long currentTime, long sessionOffset)
  {
    return (barTime + sessionOffset) / 864000000000L != (currentTime + sessionOffset) / 864000000000L;
  }
}
