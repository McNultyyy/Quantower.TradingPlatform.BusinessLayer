// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.MaMode
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>Moving average mode</summary>
[Published]
public enum MaMode
{
  /// <summary>Simple Moving Average</summary>
  SMA,
  /// <summary>Exponential Moving Average</summary>
  EMA,
  /// <summary>Smoothed Moving Average</summary>
  SMMA,
  /// <summary>Linearly Weighted Moving Average</summary>
  LWMA,
}
