// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.HistoricalDataCustom
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public sealed class HistoricalDataCustom : HistoricalData
{
  private Indicator 퓥픰;

  public double this[PriceType priceType, int offset = 0]
  {
    get
    {
      IHistoryItem historyItem = this[offset];
      switch (priceType)
      {
        case PriceType.Open:
          return historyItem[PriceType.Open];
        case PriceType.High:
          return historyItem[PriceType.High];
        case PriceType.Low:
          return historyItem[PriceType.Low];
        case PriceType.Close:
          return historyItem[PriceType.Close];
        default:
          DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 1);
          interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙핁());
          interpolatedStringHandler.AppendFormatted<PriceType>(priceType);
          throw new InvalidOperationException(interpolatedStringHandler.ToStringAndClear());
      }
    }
    set
    {
      IHistoryItem historyItem = this[offset];
      switch (priceType)
      {
        case PriceType.Open:
          this.SetValue(value, historyItem[PriceType.High], historyItem[PriceType.Low], historyItem[PriceType.Close], offset);
          break;
        case PriceType.High:
          this.SetValue(historyItem[PriceType.Open], value, historyItem[PriceType.Low], historyItem[PriceType.Close], offset);
          break;
        case PriceType.Low:
          this.SetValue(historyItem[PriceType.Open], historyItem[PriceType.High], value, historyItem[PriceType.Close], offset);
          break;
        case PriceType.Close:
          this.SetValue(historyItem[PriceType.Open], historyItem[PriceType.High], historyItem[PriceType.Low], value, offset);
          break;
        default:
          DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 1);
          interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙핁());
          interpolatedStringHandler.AppendFormatted<PriceType>(priceType);
          throw new InvalidOperationException(interpolatedStringHandler.ToStringAndClear());
      }
    }
  }

  public HistoricalDataCustom(Indicator indicator = null)
  {
    this.Parameters = new HistoryRequestParameters();
    if (indicator != null)
    {
      this.퓥픰 = indicator;
      this.Parameters.Symbol = indicator.HistoricalData.Symbol;
      this.Parameters.Aggregation = indicator.HistoricalData.Aggregation.Clone() as HistoryAggregation;
      indicator.퓏(this);
    }
    else
      this.Parameters.Aggregation = (HistoryAggregation) new HistoryAggregationTime(Period.MIN1, HistoryType.Bid);
  }

  public void AddValue(double open, double high, double low, double close)
  {
    if (this.퓥픰 != null)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(153, 4);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픇());
      interpolatedStringHandler.AppendFormatted(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픣());
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓙());
      interpolatedStringHandler.AppendFormatted(this.퓥픰.ShortName);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓗());
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픎());
      interpolatedStringHandler.AppendFormatted(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓠());
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓥());
      interpolatedStringHandler.AppendFormatted(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픣());
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓯());
      throw new InvalidOperationException(interpolatedStringHandler.ToStringAndClear());
    }
    this.AddNewItem((IHistoryItem) new HistoryItemCustom(open, high, low, close));
  }

  public void SetValue(double open, double high, double low, double close, int offset = 0)
  {
    if (!(this[offset] is HistoryItemCustom historyItemCustom))
      throw new IndexOutOfRangeException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픜());
    if (this.퓍퓧.Count > 0)
    {
      while (this.Count - this.퓍퓧[0].Count > 1)
        this.퓏(new UpdateArgs(UpdateReason.NewBar));
    }
    bool isEmpty = historyItemCustom.IsEmpty;
    historyItemCustom.Open = open;
    historyItemCustom.High = high;
    historyItemCustom.Low = low;
    historyItemCustom.Close = close;
    historyItemCustom.IsEmpty = false;
    if (offset != 0)
      return;
    this.퓏(new UpdateArgs(isEmpty ? UpdateReason.NewBar : UpdateReason.NewTick));
  }

  internal void 퓬()
  {
    this.AddNewItem((IHistoryItem) new HistoryItemCustom(double.NaN, double.NaN, double.NaN, double.NaN)
    {
      IsEmpty = true
    }, false);
  }

  private protected override void 퓏([In] IHistoryItem obj0)
  {
    if ((obj0 is HistoryItemCustom historyItemCustom ? (historyItemCustom.IsEmpty ? 1 : 0) : 1) != 0)
      return;
    base.퓏(obj0);
  }

  private protected override void 퓏(HistoryEventArgs _param1 = null, IndicatorUpdateType? _param2 = null)
  {
    if (this.Count == 0 || (this[0] as HistoryItemCustom).IsEmpty)
      return;
    this.퓏(new UpdateArgs(UpdateReason.NewBar), _param2);
  }

  public override void Dispose()
  {
    base.Dispose();
    this.퓥픰 = (Indicator) null;
  }

  internal HistoricalDataCustom([In] HistoryRequestParameters obj0)
    : base(obj0)
  {
  }

  private protected override void 퓏()
  {
  }

  protected override void SubscribeSymbol()
  {
  }

  protected override void UnSubscribeSymbol()
  {
  }
}
