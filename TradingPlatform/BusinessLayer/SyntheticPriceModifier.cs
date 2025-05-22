// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SyntheticPriceModifier
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public abstract class SyntheticPriceModifier
{
  public abstract SyntheticPriceModifierType Type { get; }

  public abstract double CalculatePrice(double coefficient, double price);

  public static SyntheticPriceModifier Create(SyntheticPriceModifierType type)
  {
    switch (type)
    {
      case SyntheticPriceModifierType.Undefined:
        return (SyntheticPriceModifier) new BasicSyntheticPriceModifier();
      case SyntheticPriceModifierType.Basic:
        return (SyntheticPriceModifier) new BasicSyntheticPriceModifier();
      case SyntheticPriceModifierType.Ln:
        return (SyntheticPriceModifier) new LnSyntheticPriceModifier();
      default:
        throw new ArgumentOutOfRangeException();
    }
  }
}
