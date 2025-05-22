// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.PingMeter
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Net.NetworkInformation;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

public class PingMeter
{
  private readonly string 핂픘;
  private readonly Ping 핂픨;
  private readonly Uri 핂퓪;

  public PingMeter(string ownerName, string endpoint)
  {
    this.핂픘 = ownerName;
    this.핂픨 = new Ping();
    this.핂퓪 = new Uri(endpoint);
  }

  public TimeSpan? MeasurePing()
  {
    try
    {
      PingReply pingReply = this.핂픨.Send(this.핂퓪.Host);
      if (pingReply != null && pingReply.Status == IPStatus.Success)
        return new TimeSpan?(TimeSpan.FromMilliseconds((double) pingReply.RoundtripTime));
      Core.Instance.Loggers.Log(this.핂픘 + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓍() + this.핂퓪.Host);
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
    return new TimeSpan?();
  }
}
