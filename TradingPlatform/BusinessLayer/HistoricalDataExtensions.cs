// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.HistoricalDataExtensions
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public static class HistoricalDataExtensions
{
  /// <summary>Gets the price from historical data</summary>
  /// <param name="priceType"></param>
  /// <param name="offset"></param>
  /// <returns></returns>
  public static double GetPrice(
    this HistoricalData historicalData,
    PriceType priceType,
    int offset = 0)
  {
    return historicalData[offset][priceType];
  }

  /// <summary>Get Bid price</summary>
  /// <param name="offset">Offset value</param>
  /// <returns></returns>
  public static double Bid(this HistoricalData historicalData, int offset = 0)
  {
    return historicalData.GetPrice(PriceType.Bid, offset);
  }

  /// <summary>Get Ask price</summary>
  /// <param name="offset">Offset value</param>
  /// <returns></returns>
  public static double Ask(this HistoricalData historicalData, int offset = 0)
  {
    return historicalData.GetPrice(PriceType.Ask, offset);
  }

  /// <summary>Get Last price</summary>
  /// <param name="offset">Offset value</param>
  /// <returns></returns>
  public static double Last(this HistoricalData historicalData, int offset = 0)
  {
    return historicalData.GetPrice(PriceType.Last, offset);
  }

  /// <summary>Get Open price</summary>
  /// <param name="offset">Offset value</param>
  /// <returns></returns>
  public static double Open(this HistoricalData historicalData, int offset = 0)
  {
    return historicalData.GetPrice(PriceType.Open, offset);
  }

  /// <summary>Get High price</summary>
  /// <param name="offset">Offset value</param>
  /// <returns></returns>
  public static double High(this HistoricalData historicalData, int offset = 0)
  {
    return historicalData.GetPrice(PriceType.High, offset);
  }

  /// <summary>Get Low price</summary>
  /// <param name="offset">Offset value</param>
  /// <returns></returns>
  public static double Low(this HistoricalData historicalData, int offset = 0)
  {
    return historicalData.GetPrice(PriceType.Low, offset);
  }

  /// <summary>Get Close price</summary>
  /// <param name="offset">Offset value</param>
  /// <returns></returns>
  public static double Close(this HistoricalData historicalData, int offset = 0)
  {
    return historicalData.GetPrice(PriceType.Close, offset);
  }

  /// <summary>Get Median price</summary>
  /// <param name="offset">Offset value</param>
  /// <returns></returns>
  public static double Median(this HistoricalData historicalData, int offset = 0)
  {
    return historicalData.GetPrice(PriceType.Median, offset);
  }

  /// <summary>Get Typical price</summary>
  /// <param name="offset">Offset value</param>
  /// <returns></returns>
  public static double Typical(this HistoricalData historicalData, int offset = 0)
  {
    return historicalData.GetPrice(PriceType.Typical, offset);
  }

  /// <summary>Get Weighted price</summary>
  /// <param name="offset">Offset value</param>
  /// <returns></returns>
  public static double Weighted(this HistoricalData historicalData, int offset = 0)
  {
    return historicalData.GetPrice(PriceType.Weighted, offset);
  }

  /// <summary>Get Volume</summary>
  /// <param name="offset">Offset value</param>
  /// <returns></returns>
  public static double Volume(this HistoricalData historicalData, int offset = 0)
  {
    return historicalData.GetPrice(PriceType.Volume, offset);
  }

  /// <summary>Get Volume in quoting asset</summary>
  /// <param name="offset">Offset value</param>
  /// <returns></returns>
  public static double QuoteAssetVolume(this HistoricalData historicalData, int offset = 0)
  {
    return historicalData.GetPrice(PriceType.QuoteAssetVolume, offset);
  }

  /// <summary>Get Ticks</summary>
  /// <param name="offset">Offset value</param>
  /// <returns></returns>
  public static double Ticks(this HistoricalData historicalData, int offset = 0)
  {
    return historicalData.GetPrice(PriceType.Ticks, offset);
  }

  /// <summary>Get Open interest</summary>
  /// <param name="offset">Offset value</param>
  /// <returns></returns>
  public static double OpenInterest(this HistoricalData historicalData, int offset = 0)
  {
    return historicalData.GetPrice(PriceType.OpenInterest, offset);
  }

  /// <summary>Get Funding rate</summary>
  /// <param name="offset">Offset value</param>
  /// <returns></returns>
  public static double FundingRate(this HistoricalData historicalData, int offset = 0)
  {
    return historicalData.GetPrice(PriceType.FundingRate, offset);
  }

  /// <summary>Get Time</summary>
  /// <param name="offset">Offset value</param>
  /// <returns></returns>
  public static DateTime Time(this HistoricalData historicalData, int offset = 0)
  {
    return new DateTime(historicalData[offset].TicksLeft, DateTimeKind.Utc);
  }
}
