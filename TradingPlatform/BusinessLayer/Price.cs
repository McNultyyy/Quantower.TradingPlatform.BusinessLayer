// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Price
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public class Price
{
  public PriceType Type { get; [param: In] private set; }

  public double Value { get; [param: In] private set; }

  public Price(PriceType priceType)
  {
    this.Type = priceType;
    this.Value = double.NaN;
  }

  public Price(PriceType priceType, double value)
  {
    this.Type = priceType;
    this.Value = value;
  }
}
