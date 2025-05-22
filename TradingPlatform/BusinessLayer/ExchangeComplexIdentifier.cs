// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.ExchangeComplexIdentifier
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public readonly struct ExchangeComplexIdentifier(string connectionId, string exchangeId) : 
  IEquatable<ExchangeComplexIdentifier>
{
  public string ConnectionId { get; } = connectionId;

  public string ExchangeId { get; } = exchangeId;

  public bool Equals(ExchangeComplexIdentifier other)
  {
    return this.ConnectionId == other.ConnectionId && this.ExchangeId == other.ExchangeId;
  }

  public override bool Equals(object obj)
  {
    return obj is ExchangeComplexIdentifier other && this.Equals(other);
  }

  public override int GetHashCode()
  {
    return this.ConnectionId.GetHashCode() * 397 ^ this.ExchangeId.GetHashCode();
  }

  public static bool operator ==(ExchangeComplexIdentifier left, ExchangeComplexIdentifier right)
  {
    return left.Equals(right);
  }

  public static bool operator !=(ExchangeComplexIdentifier left, ExchangeComplexIdentifier right)
  {
    return !left.Equals(right);
  }
}
