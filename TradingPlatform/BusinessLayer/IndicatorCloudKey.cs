// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.IndicatorCloudKey
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public readonly struct IndicatorCloudKey(int line1Index, int line2Index) : 
  IEquatable<IndicatorCloudKey>
{
  public int Line1Index { get; } = line1Index;

  public int Line2Index { get; } = line2Index;

  public bool Equals(IndicatorCloudKey other)
  {
    return this.Line1Index == other.Line1Index && this.Line2Index == other.Line2Index;
  }

  public override bool Equals(object obj) => obj is IndicatorCloudKey other && this.Equals(other);

  public override int GetHashCode() => this.Line1Index * 397 ^ this.Line2Index;
}
