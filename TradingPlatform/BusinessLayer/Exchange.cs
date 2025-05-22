// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Exchange
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Integration;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>
/// Contains all information which belong to the given exchange
/// </summary>
[Published]
public sealed class Exchange : BusinessObject, IComparable, IMessageBuilder<MessageExchange>
{
  private string 퓗픃;

  /// <summary>Gets Exchange Id</summary>
  public string Id { get; [param: In] private set; }

  /// <summary>Gets Exchange name</summary>
  public string ExchangeName { get; [param: In] private set; }

  /// <summary>Used for the Exchanges comparing</summary>
  public int SortIndex { get; [param: In] private set; }

  internal SessionsContainer CurrentSessionsInfo
  {
    get
    {
      if (string.IsNullOrEmpty(this.퓗픃))
        return (SessionsContainer) null;
      SessionsContainer currentSessionsInfo;
      this.ConnectionCache.TradingSessions.TryGetValue(this.퓗픃, out currentSessionsInfo);
      return currentSessionsInfo;
    }
  }

  public ExchangeComplexIdentifier ComplexId
  {
    get => new ExchangeComplexIdentifier(this.ConnectionId, this.Id);
  }

  internal Exchange([In] string obj0)
    : base(obj0)
  {
  }

  internal void 퓏([In] MessageExchange obj0)
  {
    this.Id = obj0.Id;
    this.ExchangeName = obj0.ExchangeName;
    this.SortIndex = obj0.SortIndex;
    this.퓗픃 = obj0.SessionsContainerId;
  }

  MessageExchange IMessageBuilder<MessageExchange>.퓏()
  {
    return new MessageExchange()
    {
      Id = this.Id,
      ExchangeName = this.ExchangeName,
      SortIndex = this.SortIndex,
      SessionsContainerId = this.퓗픃
    };
  }

  /// <summary>
  /// Compares Exchnges in order by next - SortIndex, Exchange name, Connection Id, Exchange Id.
  /// </summary>
  /// <param name="obj"></param>
  /// <returns></returns>
  [NotPublished]
  public int CompareTo(object obj)
  {
    if (!(obj is Exchange exchange))
      return 1;
    int num1 = this.SortIndex.CompareTo(exchange.SortIndex);
    if (num1 != 0)
      return num1;
    int num2 = this.ExchangeName.CompareTo(exchange.ExchangeName);
    if (num2 != 0)
      return num2;
    int num3 = this.ConnectionId.CompareTo(exchange.ConnectionId);
    return num3 != 0 ? num3 : this.Id.CompareTo(exchange.Id);
  }

  public override string ToString() => this.ExchangeName ?? this.Id.ToString() ?? base.ToString();
}
