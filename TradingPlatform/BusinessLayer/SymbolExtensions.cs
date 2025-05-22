// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SymbolExtensions
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Integration;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public static class SymbolExtensions
{
  public static ISessionsContainer FindSessionsContainer(this Symbol symbol)
  {
    if (symbol == null)
      return (ISessionsContainer) null;
    CustomSessionsContainer container;
    if (Core.Instance.CustomSessions.Assignments.TryGetSessionsContainer(symbol, out container))
      return (ISessionsContainer) container;
    SessionsContainer currentSessionsInfo = symbol.CurrentSessionsInfo;
    if (currentSessionsInfo != null)
      return (ISessionsContainer) currentSessionsInfo;
    Exchange exchange = symbol.Exchange;
    return exchange == null ? (ISessionsContainer) null : (ISessionsContainer) exchange.CurrentSessionsInfo;
  }

  public static TimeSpan GetHistoryDownloadingStep(
    this Symbol symbol,
    HistoryAggregation aggregation)
  {
    return symbol?.HistoryMetadata?.퓏(aggregation) ?? new TimeSpan(10, 0, 0, 0);
  }

  public static double CalculateValue(
    this Symbol symbol,
    Side side,
    double price,
    double quantity)
  {
    return symbol == null || double.IsNaN(price) || double.IsNaN(quantity) ? double.NaN : (side == Side.Buy ? 1.0 : -1.0) * (symbol.QuotingType == SymbolQuotingType.LotSize ? price * symbol.LotSize * quantity : price * (symbol.GetTickCost(price) / symbol.GetTickSize(price)) * quantity);
  }

  public static string GetFormattedPoints(
    this Symbol symbol,
    Side side,
    double closePrice,
    double openPrice)
  {
    double points = symbol.CalculatePoints(side, closePrice, openPrice);
    if (double.IsNaN(points))
      return \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓯();
    VariableTick variableTick = symbol.FindVariableTick(openPrice);
    int precision = variableTick != null ? variableTick.Precision : CoreMath.GetValuePrecision((Decimal) symbol.TickSize);
    return points.Format(precision);
  }

  public static string GetFormattedPoints(this Symbol symbol, double points, string suffix = "points")
  {
    if (double.IsNaN(points))
      return \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓯();
    int valuePrecision = CoreMath.GetValuePrecision((Decimal) symbol.TickSize);
    return points.Format(valuePrecision) + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프() + suffix;
  }

  public static double CalculatePoints(
    this Symbol symbol,
    Side side,
    double closePrice,
    double openPrice)
  {
    if (double.IsNaN(closePrice) || double.IsNaN(openPrice))
      return double.NaN;
    Decimal num1 = (Decimal) closePrice;
    Decimal num2 = (Decimal) openPrice;
    return side != Side.Buy ? (double) (num2 - num1) : (double) (num1 - num2);
  }

  public static HistoricalData GetHistory(
    this Symbol symbol,
    Period period,
    HistoryType historyType,
    int itemsCount)
  {
    TimeSpan timeSpan = TimeSpan.FromDays(36500.0);
    HistoricalData history = (HistoricalData) null;
    int num1 = 1;
    long val2 = period.Ticks * (long) itemsCount * 3L;
    long num2 = Math.Min(timeSpan.Ticks, val2);
    DateTime fromTime = Core.Instance.TimeUtils.DateTimeUtcNow.AddTicks(-num2);
    DateTime dateTime = Core.Instance.TimeUtils.DateTimeUtcNow.Add(-timeSpan);
    int num3 = -1;
    for (; history == null || fromTime > dateTime && 10 >= num1; ++num1)
    {
      if (period.BasePeriod != BasePeriod.Tick)
      {
        history = symbol.GetHistory(period, historyType, fromTime);
      }
      else
      {
        long ticks = SymbolExtensions.퓏(symbol.Connection, num1);
        history = symbol.GetHistory(period, historyType, new DateTime(ticks, DateTimeKind.Utc));
      }
      if (history.Count <= itemsCount && (num3 == -1 || num3 != history.Count || period.BasePeriod != BasePeriod.Day))
      {
        if (history.Count > 0)
          num2 *= (long) (itemsCount / history.Count + 1);
        if (num2 < fromTime.Ticks)
        {
          fromTime = fromTime.AddTicks(-num2);
          num3 = history.Count;
        }
        else
          break;
      }
      else
        break;
    }
    if (history.Count > itemsCount && itemsCount != 0)
      history.CutItems(history.Count - itemsCount);
    return history;
  }

  public static DeltaCalculationType GetDeltaCalculationTypeForQuotes(this Symbol symbol)
  {
    Symbol quotesSymbol;
    return !Core.Instance.SymbolsMapping.TryGetQuotesSymbol(symbol, out quotesSymbol) ? symbol.DeltaCalculationType : quotesSymbol.DeltaCalculationType;
  }

  public static DeltaCalculationType GetDeltaCalculationTypeForHistory(
    this Symbol symbol,
    Period period)
  {
    Symbol historySymbol;
    return !Core.Instance.SymbolsMapping.TryGetHistorySymbol(symbol, period, out historySymbol) ? symbol.DeltaCalculationType : historySymbol.DeltaCalculationType;
  }

  public static DeltaCalculationType GetDeltaCalculationTypeForVolumeAnalysis(this Symbol symbol)
  {
    Symbol volumeAnalysisSymbol;
    return !Core.Instance.SymbolsMapping.TryGetVolumeAnalysisSymbol(symbol, out volumeAnalysisSymbol) ? symbol.DeltaCalculationType : volumeAnalysisSymbol.DeltaCalculationType;
  }

  public static HistoryMetadata GetHistoryMetadata(this Symbol symbol)
  {
    Symbol volumeAnalysisSymbol;
    return !Core.Instance.SymbolsMapping.TryGetVolumeAnalysisSymbol(symbol, out volumeAnalysisSymbol) ? symbol.HistoryMetadata : volumeAnalysisSymbol.HistoryMetadata;
  }

  public static bool TryGetTradingSymbolId(this Symbol symbol, out string tradingSymbolId)
  {
    tradingSymbolId = (string) null;
    AdditionalInfoItem additionalInfoItem;
    if (symbol == null || symbol.State == BusinessObjectState.Fake || symbol.AdditionalInfo == null || !symbol.AdditionalInfo.TryGetItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓡(), out additionalInfoItem))
      return false;
    tradingSymbolId = additionalInfoItem.Value as string;
    return !string.IsNullOrEmpty(tradingSymbolId);
  }

  public static bool IsSameAs(this Symbol symbol, Symbol otherSymbol)
  {
    string tradingSymbolId;
    return symbol.Equals(otherSymbol) || symbol.TryGetTradingSymbolId(out tradingSymbolId) && otherSymbol.Id == tradingSymbolId || otherSymbol.TryGetTradingSymbolId(out tradingSymbolId) && symbol.Id == tradingSymbolId;
  }

  public static Symbol GetTradingSymbol(this Symbol symbol)
  {
    string tradingSymbolId;
    if (!symbol.TryGetTradingSymbolId(out tradingSymbolId))
      return (Symbol) null;
    Core instance = Core.Instance;
    GetSymbolRequestParameters requestParameters = new GetSymbolRequestParameters();
    requestParameters.SymbolId = tradingSymbolId;
    string connectionId = symbol.ConnectionId;
    return instance.GetSymbol(requestParameters, connectionId);
  }

  [CompilerGenerated]
  internal static long 퓏([In] Connection obj0, [In] int obj1)
  {
    return Core.Instance.TimeUtils.DateTimeUtcNow.Ticks - (long) ((double) obj0.HistoryMetaData.DownloadingStep_Tick.Ticks * Math.Pow(2.0, (double) --obj1));
  }
}
