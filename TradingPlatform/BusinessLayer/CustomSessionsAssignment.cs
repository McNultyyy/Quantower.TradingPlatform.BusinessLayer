// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.CustomSessionsAssignment
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Utils.Extensions;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public sealed class CustomSessionsAssignment : 
  IUniqueID,
  ICustomizable,
  IEquatable<CustomSessionsAssignment>
{
  public IList<SettingItem> Settings
  {
    get
    {
      return (IList<SettingItem>) new List<SettingItem>()
      {
        (SettingItem) new SettingItemString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓬(), this.UniqueId),
        (SettingItem) new SettingItemBoolean(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓸(), this.IsActive),
        (SettingItem) new SettingItemString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞핇(), this.ConnectionId),
        (SettingItem) new SettingItemString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓲(), this.ExchangeId),
        (SettingItem) new SettingItemString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞핂(), this.SymbolId),
        (SettingItem) new SettingItemString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픂(), this.CustomSessionsContainerId)
      };
    }
    set
    {
      this.UniqueId = value.GetValueOrDefault<string>(this.UniqueId, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓬());
      this.IsActive = value.GetValueOrDefault<bool>((this.IsActive ? 1 : 0) != 0, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓸());
      this.ConnectionId = value.GetValueOrDefault<string>(this.ConnectionId, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞핇());
      this.ExchangeId = value.GetValueOrDefault<string>(this.ExchangeId, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓲());
      this.SymbolId = value.GetValueOrDefault<string>(this.SymbolId, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞핂());
      this.CustomSessionsContainerId = value.GetValueOrDefault<string>(this.CustomSessionsContainerId, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픂());
    }
  }

  public string UniqueId { get; [param: In] private set; }

  public bool IsActive { get; set; }

  public string ConnectionId { get; [param: In] private set; }

  public string ExchangeId { get; [param: In] private set; }

  public string SymbolId { get; [param: In] private set; }

  public string CustomSessionsContainerId { get; [param: In] internal set; }

  public ExchangeComplexIdentifier ExchangeComplexId
  {
    get => new ExchangeComplexIdentifier(this.ConnectionId, this.ExchangeId);
  }

  public SymbolComplexIdentifier SymbolComplexId
  {
    get => new SymbolComplexIdentifier(this.ConnectionId, this.ExchangeId, this.SymbolId);
  }

  public Connection Connection => Core.Instance.Connections[this.ConnectionId];

  public Exchange Exchange
  {
    get
    {
      return ((IEnumerable<Exchange>) Core.Instance.Exchanges).FirstOrDefault<Exchange>((Func<Exchange, bool>) (([In] obj0) =>
      {
        ExchangeComplexIdentifier complexId = obj0.ComplexId;
        ExchangeComplexIdentifier? nullable = this != null ? new ExchangeComplexIdentifier?(this.ExchangeComplexId) : new ExchangeComplexIdentifier?();
        return nullable.HasValue && complexId == nullable.GetValueOrDefault();
      }));
    }
  }

  public Symbol Symbol
  {
    get
    {
      try
      {
        Core instance = Core.Instance;
        GetSymbolRequestParameters requestParameters = new GetSymbolRequestParameters();
        requestParameters.SymbolId = this.SymbolId;
        string connectionId = this.ConnectionId;
        return instance.GetSymbol(requestParameters, connectionId);
      }
      catch
      {
        return (Symbol) null;
      }
    }
  }

  public CustomSessionsContainer SessionsContainer
  {
    get => Core.Instance.CustomSessions[this.CustomSessionsContainerId];
  }

  public CustomSessionsAssignment(
    string containerId,
    string connectionId = null,
    string exchangeId = null,
    string symbolId = null)
    : this()
  {
    this.IsActive = true;
    this.CustomSessionsContainerId = containerId;
    this.ConnectionId = connectionId;
    this.ExchangeId = exchangeId;
    this.SymbolId = symbolId;
  }

  public CustomSessionsAssignment(CustomSessionsAssignment origin)
    : this()
  {
    this.IsActive = origin.IsActive;
    this.ConnectionId = origin.ConnectionId;
    this.ExchangeId = origin.ExchangeId;
    this.SymbolId = origin.SymbolId;
    this.CustomSessionsContainerId = origin.CustomSessionsContainerId;
  }

  internal CustomSessionsAssignment() => this.UniqueId = Guid.NewGuid().ToShortString();

  internal void 퓏([In] CustomSessionsAssignment obj0)
  {
    this.IsActive = obj0.IsActive;
    this.ConnectionId = obj0.ConnectionId;
    this.ExchangeId = obj0.ExchangeId;
    this.SymbolId = obj0.SymbolId;
    this.CustomSessionsContainerId = obj0.CustomSessionsContainerId;
  }

  public bool Equals(CustomSessionsAssignment other)
  {
    if (other == null)
      return false;
    if (this == other)
      return true;
    return this.ConnectionId == other.ConnectionId && this.ExchangeId == other.ExchangeId && this.SymbolId == other.SymbolId && this.CustomSessionsContainerId == other.CustomSessionsContainerId;
  }

  public override bool Equals(object obj)
  {
    if (obj == null)
      return false;
    if (this == obj)
      return true;
    return !(obj.GetType() != this.GetType()) && this.Equals((CustomSessionsAssignment) obj);
  }

  public override int GetHashCode()
  {
    return (((this.ConnectionId != null ? this.ConnectionId.GetHashCode() : 0) * 397 ^ (this.ExchangeId != null ? this.ExchangeId.GetHashCode() : 0)) * 397 ^ (this.SymbolId != null ? this.SymbolId.GetHashCode() : 0)) * 397 ^ (this.CustomSessionsContainerId != null ? this.CustomSessionsContainerId.GetHashCode() : 0);
  }
}
