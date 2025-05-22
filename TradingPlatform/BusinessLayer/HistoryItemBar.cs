// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.HistoryItemBar
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using ProtoBuf;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>Represents historical data bar item</summary>
[Published]
[ProtoContract]
public class HistoryItemBar : HistoryItem
{
  /// <summary>Gets bar's right time border</summary>
  public DateTime TimeRight => new DateTime(this.TicksRight, DateTimeKind.Utc);

  /// <summary>Defines bar's ticks count</summary>
  public override long TicksRight { get; set; }

  /// <summary>Defines Open price</summary>
  [ProtoMember(1)]
  public double Open { get; set; }

  /// <summary>Defines High price</summary>
  [ProtoMember(2)]
  public double High { get; set; }

  /// <summary>Defines Low price</summary>
  [ProtoMember(3)]
  public double Low { get; set; }

  /// <summary>Defines Close price</summary>
  [ProtoMember(4)]
  public double Close { get; set; }

  /// <summary>Gets Median (High+Low)/2 price</summary>
  public double Median => (this.High + this.Low) / 2.0;

  /// <summary>Gets Typical (High+Low+Close)/3  price</summary>
  public double Typical => (this.High + this.Low + this.Close) / 3.0;

  /// <summary>Gets Weighted (High+Low+Close+Close)/4  price</summary>
  public double Weighted => (this.High + this.Low + this.Close + this.Close) / 4.0;

  /// <summary>Defines ticks amount</summary>
  [ProtoMember(5)]
  public long Ticks { get; set; }

  /// <summary>Defines volume value</summary>
  [ProtoMember(6)]
  public double Volume { get; set; }

  [ProtoMember(7)]
  public double OpenInterest { get; set; }

  [ProtoMember(8)]
  public double FundingRate { get; set; }

  [ProtoMember(9)]
  public double QuoteAssetVolume { get; set; }

  /// <summary>
  /// Gets price by indexing <see cref="T:TradingPlatform.BusinessLayer.PriceType" />
  /// </summary>
  /// <param name="priceType"></param>
  /// <returns></returns>
  public override double this[PriceType priceType]
  {
    get
    {
      double num;
      switch (priceType)
      {
        case PriceType.Open:
          num = this.Open;
          break;
        case PriceType.High:
          num = this.High;
          break;
        case PriceType.Low:
          num = this.Low;
          break;
        case PriceType.Close:
          num = this.Close;
          break;
        case PriceType.Median:
          num = this.Median;
          break;
        case PriceType.Typical:
          num = this.Typical;
          break;
        case PriceType.Weighted:
          num = this.Weighted;
          break;
        case PriceType.Volume:
          num = this.Volume;
          break;
        case PriceType.Ticks:
          num = (double) this.Ticks;
          break;
        case PriceType.OpenInterest:
          num = this.OpenInterest;
          break;
        case PriceType.FundingRate:
          num = this.FundingRate;
          break;
        case PriceType.QuoteAssetVolume:
          num = this.QuoteAssetVolume;
          break;
        default:
          num = base[priceType];
          break;
      }
      return num;
    }
  }

  /// <summary>
  /// Creates HistoryItemBar instance with default OHLC price = <see cref="F:TradingPlatform.BusinessLayer.Utils.Const.DOUBLE_UNDEFINED" />
  /// </summary>
  public HistoryItemBar()
  {
    this.Open = double.NaN;
    this.High = double.NaN;
    this.Low = double.NaN;
    this.Close = double.NaN;
  }

  /// <summary>
  /// Comparing by <see cref="P:TradingPlatform.BusinessLayer.HistoryItem.TicksLeft" />, OHLC, <see cref="P:TradingPlatform.BusinessLayer.HistoryItemBar.Volume" />
  /// </summary>
  /// <param name="obj"></param>
  /// <returns></returns>
  [NotPublished]
  public override bool Equals(object obj)
  {
    HistoryItemBar historyItemBar = obj as HistoryItemBar;
    return !(historyItemBar == (HistoryItemBar) null) && this.TicksLeft == historyItemBar.TicksLeft && this.Open == historyItemBar.Open && this.High == historyItemBar.High && this.Low == historyItemBar.Low && this.Close == historyItemBar.Close && this.Ticks == historyItemBar.Ticks && this.Volume == historyItemBar.Volume && this.QuoteAssetVolume == historyItemBar.QuoteAssetVolume;
  }

  [NotPublished]
  public override int GetHashCode()
  {
    long num1 = this.TicksLeft;
    int num2 = num1.GetHashCode() ^ this.Open.GetHashCode() ^ this.High.GetHashCode() ^ this.Low.GetHashCode() ^ this.Close.GetHashCode();
    num1 = this.Ticks;
    int hashCode = num1.GetHashCode();
    return num2 ^ hashCode ^ this.Volume.GetHashCode() ^ this.QuoteAssetVolume.GetHashCode();
  }

  [NotPublished]
  public static bool operator ==(HistoryItemBar a, HistoryItemBar b)
  {
    if ((object) a == (object) b)
      return true;
    return (object) a != null && (object) b != null && a.Equals((object) b);
  }

  [NotPublished]
  public static bool operator !=(HistoryItemBar a, HistoryItemBar b) => !(a == b);

  [NotPublished]
  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(39, 10);
    interpolatedStringHandler.AppendFormatted<long>(this.TicksLeft);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓛());
    interpolatedStringHandler.AppendFormatted<long>(this.TicksRight);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓑());
    interpolatedStringHandler.AppendFormatted<long>(this.Ticks);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙핋());
    interpolatedStringHandler.AppendFormatted<DateTime>(this.TimeLeft);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓛());
    interpolatedStringHandler.AppendFormatted<DateTime>(this.TimeRight);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓞());
    interpolatedStringHandler.AppendFormatted<double>(this.Open);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙핅());
    interpolatedStringHandler.AppendFormatted<double>(this.High);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픡());
    interpolatedStringHandler.AppendFormatted<double>(this.Low);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픏());
    interpolatedStringHandler.AppendFormatted<double>(this.Close);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프());
    interpolatedStringHandler.AppendFormatted(this.Close > this.Open ? \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙핆() : \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓳());
    return interpolatedStringHandler.ToStringAndClear();
  }

  private HistoryItemBar([In] HistoryItemBar obj0)
    : base((HistoryItem) obj0)
  {
    this.TicksRight = obj0.TicksRight;
    this.Open = obj0.Open;
    this.High = obj0.High;
    this.Low = obj0.Low;
    this.Close = obj0.Close;
    this.Ticks = obj0.Ticks;
    this.Volume = obj0.Volume;
    this.OpenInterest = obj0.OpenInterest;
    this.FundingRate = obj0.FundingRate;
    this.QuoteAssetVolume = obj0.QuoteAssetVolume;
    this.VolumeAnalysisData = obj0.VolumeAnalysisData;
  }

  [NotPublished]
  public override object Clone() => (object) new HistoryItemBar(this);
}
