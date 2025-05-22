// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SymbolComplexIdentifier
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public readonly struct SymbolComplexIdentifier(
  string connectionId,
  string exchangeId,
  string symbolId) : IEquatable<SymbolComplexIdentifier>
{
  private readonly ExchangeComplexIdentifier 픥 = new ExchangeComplexIdentifier(connectionId, exchangeId);

  public string ConnectionId => this.픥.ConnectionId;

  public string ExchangeId => this.픥.ExchangeId;

  public string SymbolId { get; } = symbolId;

  public bool Equals(SymbolComplexIdentifier other)
  {
    return this.픥.Equals(other.픥) && this.SymbolId == other.SymbolId;
  }

  public override bool Equals(object obj)
  {
    return obj is SymbolComplexIdentifier other && this.Equals(other);
  }

  public override int GetHashCode() => this.픥.GetHashCode() * 397 ^ this.SymbolId.GetHashCode();

  public static bool operator ==(SymbolComplexIdentifier left, SymbolComplexIdentifier right)
  {
    return left.Equals(right);
  }

  public static bool operator !=(SymbolComplexIdentifier left, SymbolComplexIdentifier right)
  {
    return !left.Equals(right);
  }
}
