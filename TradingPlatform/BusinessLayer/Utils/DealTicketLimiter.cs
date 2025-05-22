// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.DealTicketLimiter
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Threading.Tasks;

#nullable enable
namespace TradingPlatform.BusinessLayer.Utils;

public class DealTicketLimiter
{
  private readonly TimeSpan 핇퓎;
  private readonly 
  #nullable disable
  object 핇피;
  private bool 핇퓸;

  public DealTicketLimiter(TimeSpan delay)
  {
    this.핇퓎 = delay;
    this.핇피 = new object();
    this.핇퓸 = true;
  }

  public bool AllowDealTicket(TimeSpan? currentDelay = null)
  {
    lock (this.핇피)
    {
      if (!this.핇퓸)
        return false;
      this.핇퓸 = false;
      Task.Delay(currentDelay ?? this.핇퓎).ContinueWith<bool>((Func<Task, bool>) delegate
      {
        return this.핇퓸 = true;
      });
      return true;
    }
  }
}
