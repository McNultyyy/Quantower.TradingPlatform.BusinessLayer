// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.DealticketConnection
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using TradingPlatform.BusinessLayer.Integration;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public sealed class DealticketConnection : DealTicket, IConnectionBindedObject, ILoggable
{
  private readonly string 픂픅;

  string IConnectionBindedObject.ConnectionId => this.픂픅;

  public DealticketConnection(string connectionId, MessageDealTicket message)
  {
    this.픂픅 = connectionId;
    this.Header = message.Header;
    this.Description = message.Description;
    this.Type = message.DealTicketType;
  }

  public string Event => this.Header;

  public string Message
  {
    get
    {
      return \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픠() + this.Description + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓮();
    }
  }
}
