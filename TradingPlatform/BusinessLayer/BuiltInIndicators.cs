// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.BuiltInIndicators
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[Published]
public sealed class BuiltInIndicators
{
  private readonly IIndicatorsCollection 픤;

  internal BuiltInIndicators(IIndicatorsCollection _param1 = null) => this.픤 = _param1;

  private void 퓏([In] Indicator obj0) => this.픤?.AddIndicator(obj0);

  /// <summary>
  /// Returns an instance of the Exponential Moving Average (EMA) indicator.
  /// <para>EMA provides a weighted price calculation for the last N periods.</para>
  /// </summary>
  /// <param name="maPeriod">Period of Exponential Moving Average</param>
  /// <param name="priceType">Sources prices for MA</param>
  /// <param name="calculationType">Calculation type</param>
  public Indicator EMA(int maPeriod, PriceType priceType, IndicatorCalculationType calculationType = IndicatorCalculationType.AllAvailableData)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓽(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픘(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픘(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픨(), (object) maPeriod);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓪(), (object) new SelectItem(priceType.ToString(), (int) priceType));
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픪(), (object) new SelectItem(calculationType.ToString(), (int) calculationType));
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Gets the Linearly Weighted Moving Average
  /// <para> Linear Weighted Moving Average makes the most recent bar more important unlike SMA.</para>
  /// </summary>
  /// <param name="maPeriod">Moving average period</param>
  /// <param name="priceType">Type of the price</param>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator LWMA(int maPeriod, PriceType priceType)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓡(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픘(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픘(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓓(), (object) maPeriod);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픗(), (object) new SelectItem(priceType.ToString(), (int) priceType));
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  ///  Gets the SMA(Simple Moving Average) indicator.
  ///  <para> The 'SMA' indicator provides an average price for the last N periods. </para>
  /// </summary>
  /// <param name="period">Period of simple moving average.</param>
  /// <param name="priceType">Sources prices for MA.</param>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator SMA(int period, PriceType priceType)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓰(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픘(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픘(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픧(), (object) period);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓪(), (object) new SelectItem(priceType.ToString(), (int) priceType));
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Returns an instance of the Smoothed Moving Average (SMMA) indicator.
  /// <para>SMMA indicator provides a smoothed average price for the last N periods.</para>
  /// </summary>
  /// <param name="period">Moving average period</param>
  /// <param name="priceType">Type of the price</param>
  /// <param name="calculationType">Calculation type</param>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator SMMA(int period, PriceType priceType, IndicatorCalculationType calculationType = IndicatorCalculationType.AllAvailableData)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓹(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픘(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픘(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓛(), (object) period);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓪(), (object) new SelectItem(priceType.ToString(), (int) priceType));
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픪(), (object) new SelectItem(calculationType.ToString(), (int) calculationType));
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Gets the PPMA(Pivot Point Moving Average) indicator.
  /// <para> The 'PPMA' indicator uses the pivot point calculation as the input a simple moving average.</para>
  /// </summary>
  /// <param name="period">Period of PPMA indicator</param>
  /// <returns></returns>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator PPMA(int period)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픝(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픘(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픘(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픻(), (object) period);
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  ///  Gets the MAS3 (3MASignal) indicator.
  /// <para>The 'MAS3' indicator offers buy and sell signals according to intersections of three moving averages.</para>
  /// </summary>
  /// <param name="shortPeriod">Short moving average period.</param>
  /// <param name="middlePeriod">Middle moving average period.</param>
  /// <param name="longPeriod">Long moving average period.</param>
  /// <param name="barsInterval">The count of bars. The trend will be determined on this interval.</param>
  /// <returns></returns>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator MAS3(int shortPeriod, int middlePeriod, int longPeriod, int barsInterval)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓤(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픘(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픘(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픮(), (object) shortPeriod);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픉(), (object) middlePeriod);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픒(), (object) longPeriod);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓷(), (object) barsInterval);
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Gets the specific MA indicator, according to selected 'MaMode'.
  /// </summary>
  /// <param name="period">Period of moving average.</param>
  /// <param name="priceType">Type of price.</param>
  /// <param name="maMode">MA mode.</param>
  /// <param name="calculationType">Calculation type</param>
  /// <returns></returns>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator MA(
    int period,
    PriceType priceType,
    MaMode maMode,
    IndicatorCalculationType calculationType = IndicatorCalculationType.AllAvailableData)
  {
    Indicator indicator;
    switch (maMode)
    {
      case MaMode.SMA:
        indicator = this.SMA(period, priceType);
        break;
      case MaMode.EMA:
        indicator = this.EMA(period, priceType, calculationType);
        break;
      case MaMode.SMMA:
        indicator = this.SMMA(period, priceType, calculationType);
        break;
      case MaMode.LWMA:
        indicator = this.LWMA(period, priceType);
        break;
      default:
        indicator = (Indicator) null;
        break;
    }
    return indicator;
  }

  /// <summary>
  /// Gets the BB(Bollinger Bands) indicator.
  /// <para>The 'BB' indicator provides a relative definition of high and low based on standard deviation and a simple moving average.</para>
  /// </summary>
  /// <param name="period">Period of MA for envelopes.</param>
  /// <param name="coefficient">Value of confidence interval.</param>
  /// <param name="priceType">Sources prices for MA.</param>
  /// <param name="maMode">Type of moving average.</param>
  /// <param name="calculationType">Calculation type</param>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator BB(
    int period,
    double coefficient,
    PriceType priceType,
    MaMode maMode,
    IndicatorCalculationType calculationType = IndicatorCalculationType.AllAvailableData)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓿(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픟(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픟(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓧(), (object) period);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픰(), (object) coefficient);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓪(), (object) new SelectItem(priceType.ToString(), (int) priceType));
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓢(), (object) new SelectItem(maMode.ToString(), (int) maMode));
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픪(), (object) new SelectItem(calculationType.ToString(), (int) calculationType));
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Gets the Commodity Channel Index.
  /// <para>Measures the position of price in relation to its moving average.</para>
  /// </summary>
  /// <param name="maPeriod">Period for CCI MA</param>
  /// <param name="priceType">Sources prices for CCI</param>
  /// <param name="maMode">MA mode for CCI</param>
  /// <param name="calculationType">Calculation type</param>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator CCI(
    int maPeriod,
    PriceType priceType,
    MaMode maMode,
    IndicatorCalculationType calculationType = IndicatorCalculationType.AllAvailableData)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픫(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픯(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픯(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓾(), (object) maPeriod);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓪(), (object) new SelectItem(priceType.ToString(), (int) priceType));
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓐(), (object) new SelectItem(maMode.ToString(), (int) maMode));
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픪(), (object) new SelectItem(calculationType.ToString(), (int) calculationType));
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Returns an instance of the Modified Moving Average (MMA) indicator.
  /// <para>MMA comprises a sloping factor to help it overtake with the growing or declining value of the trading price of the currency.</para>
  /// </summary>
  /// <param name="maPeriod">Period of Modified Moving Average</param>
  /// <param name="priceType">Sources prices for MA</param>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator MMA(int maPeriod, PriceType priceType)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픚(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픘(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픘(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓵(), (object) maPeriod);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓪(), (object) new SelectItem(priceType.ToString(), (int) priceType));
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Gets the Regression indicator
  /// <para>The Linear Regression Indicator plots the ending value of a Linear Regression Line for a specified number of bars; showing, statistically, where the price is expected to be.</para>
  /// </summary>
  /// <param name="period">Moving average period</param>
  /// <param name="priceType">Type of the price</param>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator Regression(int period, PriceType priceType)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.플(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픘(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픘(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픥(), (object) period);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓼(), (object) new SelectItem(priceType.ToString(), (int) priceType));
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Gets the Channel (Price Channel) indicator.
  /// <para>The 'Channel' indicator is based on measurement of min and max prices for the definite number of periods.</para>
  /// </summary>
  /// <param name="period">Period of price channel</param>
  /// <returns></returns>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator Channel(int period)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓴(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픟(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픟(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픳(), (object) period);
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Gets the AFIRMA indicator
  /// <para> Autoregressive finite impulse response moving average. A digital filter accurately shows the price movement as powered with least square method to minimise time lag</para>
  /// </summary>
  /// <param name="period">Moving average period</param>
  /// <param name="priceType">Type of the price</param>
  /// <param name="afirmaMode">Afirma mode</param>
  /// <param name="least_squares_method">with least squares method overlapping if true</param>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator AFIRMA(
    int period,
    PriceType priceType,
    AfirmaMode afirmaMode,
    bool least_squares_method)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픙(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓭(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓭(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓣(), (object) period);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픦(), (object) new SelectItem(priceType.ToString(), (int) priceType));
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픍(), (object) new SelectItem(afirmaMode.ToString(), (int) afirmaMode));
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픆(), (object) least_squares_method);
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Gets the RSI indicator.
  /// <para> Relative Strength Index (RSI) is a momentum oscillator that measures the speed and change of price movements.</para>
  /// </summary>
  /// <param name="period">RSI Period</param>
  /// <param name="priceType">Price Type</param>
  /// <param name="rsiMode">RSI Mode (Simple or Exponential)</param>
  /// <param name="maMode">MA Mode for smooth data</param>
  /// <param name="maperiod">MA period for smooth data</param>
  /// <param name="calculationType">Calculation type</param>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator RSI(
    int period,
    PriceType priceType,
    RSIMode rsiMode,
    MaMode maMode,
    int maperiod,
    IndicatorCalculationType calculationType = IndicatorCalculationType.AllAvailableData)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픅(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픯(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픯(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픠(), (object) period);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓮(), (object) new SelectItem(priceType.ToString(), (int) priceType));
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픕(), (object) new SelectItem(rsiMode.ToString(), (int) rsiMode));
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓐(), (object) new SelectItem(maMode.ToString(), (int) maMode));
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픱(), (object) maperiod);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픪(), (object) new SelectItem(calculationType.ToString(), (int) calculationType));
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Returns an instance of the McGinley Dynamic indicator.
  /// <para>McGinley Dynamic avoids of most whipsaws and it rapidly moves up or down according to a quickly changing market. It needs no adjusting because it is dynamic and it adjusts itself.</para>
  /// </summary>
  /// <param name="period">Period of exponential moving average</param>
  /// <param name="trackingFactor">Dynamic tracking factor</param>
  /// <param name="priceType">Source price type</param>
  /// <param name="calculationType">Calculation type</param>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator MD(
    int period,
    int trackingFactor,
    PriceType priceType,
    IndicatorCalculationType calculationType = IndicatorCalculationType.AllAvailableData)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픶(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픘(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픘(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓾(), (object) period);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픀(), (object) trackingFactor);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픖(), (object) new SelectItem(priceType.ToString(), (int) priceType));
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픪(), (object) new SelectItem(calculationType.ToString(), (int) calculationType));
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Gets the MAE (Moving Average Envelope) indicator.
  /// <para> The 'MAE' indicator demonstrates a range of the prices discrepancy from a Moving Average.</para>
  /// </summary>
  /// <param name="period">Period of MA for envelopes.</param>
  /// <param name="priceType">Sources prices for MA.</param>
  /// <param name="maMode">Type of moving average.</param>
  /// <param name="upShift">Upband deviation in %.</param>
  /// <param name="downShift">Downband deviation in %.</param>
  /// <param name="calculationType">Calculation type</param>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator MAE(
    int period,
    PriceType priceType,
    MaMode maMode,
    double upShift,
    double downShift,
    IndicatorCalculationType calculationType = IndicatorCalculationType.AllAvailableData)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓘(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픟(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픟(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓧(), (object) period);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓪(), (object) new SelectItem(priceType.ToString(), (int) priceType));
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓢(), (object) new SelectItem(maMode.ToString(), (int) maMode));
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픓(), (object) upShift);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픩(), (object) downShift);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픪(), (object) new SelectItem(calculationType.ToString(), (int) calculationType));
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Returns an instance of the Parabolic Time/Price System (SAR) indicator.
  /// <para>SAR indicator helps to define the direction of the prevailing trend and the moment to close positions opened during the reversal.</para>
  /// </summary>
  /// <param name="step">Step of parabolic SAR system</param>
  /// <param name="maximum">Maximum value for the acceleration factor</param>
  /// <returns></returns>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator SAR(double step, double maximum)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.필(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓖(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓖(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픵(), (object) step);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픬(), (object) maximum);
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Gets the AO (Awesome Oscillator) indicator.
  /// <para> The 'AO' indicator determines market momentum.</para>
  /// </summary>
  /// <returns></returns>
  public Indicator AO()
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓕(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픯(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픯(), ScriptCreationType.Default);
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Gets the CMO (Chande Momentum Oscillator) indicator.
  /// <para>The CMO calculates the dividing of difference between the sum of all recent gains and the sum of all recent losses by the sum of all price movement over the period.</para>
  /// </summary>
  /// <param name="period">Period of MA for envelopes.</param>
  /// <param name="priceType">Sources prices for MA.</param>
  /// <returns></returns>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator CMO(int period, PriceType priceType)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픐(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픭(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픭(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓧(), (object) period);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓪(), (object) new SelectItem(priceType.ToString(), (int) priceType));
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Returns an instance of the ZigZag indicator.
  /// <para>ZigZag is a trend following indicator that is used to predict when a given symbol's momentum is reversing.</para>
  /// </summary>
  /// <param name="deviation">Percent Deviation</param>
  /// <returns></returns>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator ZZ(double deviation)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픔(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓖(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓖(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핈(), (object) deviation);
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Gets the Aroon indicator.
  /// <para>Reveals the beginning of a new trend and determines how strong it is</para>
  /// </summary>
  /// <param name="period">Aroons period</param>
  /// <returns></returns>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator AROON(int period)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픤(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픯(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픯(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓟(), (object) period);
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Returns an instance of the Standart Deviation (SD) indicator.
  /// <para>The SD shows the difference of the volatility value from the average one.</para>
  /// </summary>
  /// <param name="period">Period of indicator</param>
  /// <param name="priceType">Sources prices for MA</param>
  /// <param name="mode">Type of Moving Average</param>
  /// <param name="calculationType">Calculation type</param>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator SD(
    int period,
    PriceType priceType,
    MaMode mode,
    IndicatorCalculationType calculationType = IndicatorCalculationType.AllAvailableData)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핉(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픭(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픭(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓾(), (object) period);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓪(), (object) new SelectItem(priceType.ToString(), (int) priceType));
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓐(), (object) new SelectItem(mode.ToString(), (int) mode));
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픪(), (object) new SelectItem(calculationType.ToString(), (int) calculationType));
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  ///  Gets the MACD (Moving Average Convergence/Divergence) indicator.
  ///  <para> The MACD is a trend-following momentum indicator that shows the relationship between two moving averages of prices.</para>
  /// </summary>
  /// <param name="fastEMA">Period of fast EMA.</param>
  /// <param name="slowEMA">Period of slow EMA.</param>
  /// <param name="signalEMA">Period of signal EMA.</param>
  /// <param name="calculationType">Calculation type</param>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator MACD(
    int fastEMA,
    int slowEMA,
    int signalEMA,
    IndicatorCalculationType calculationType = IndicatorCalculationType.AllAvailableData)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핊(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픯(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픯(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픛(), (object) fastEMA);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓜(), (object) slowEMA);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픺(), (object) signalEMA);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픪(), (object) new SelectItem(calculationType.ToString(), (int) calculationType));
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Returns an instance of the Kairi Relative Index (KRI) indicator.
  /// <para>KRI calculates deviation of the current price from its simple moving average as a percent of the moving average.</para>
  /// </summary>
  /// <param name="period"></param>
  /// <returns></returns>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator KRI(int period)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핃(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픯(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픯(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓾(), (object) period);
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Returns an instance of the Bollinger Bands Flat (BBF) indicator.
  /// <para>The BBF provides the same data as BB, but drawn in separate field and easier to recognize whether price is in or out of the band.</para>
  /// </summary>
  /// <param name="period">Period</param>
  /// <param name="deviation">Deviation</param>
  /// <param name="priceType">Sources prices for MA</param>
  /// <param name="mode">Type of Moving Average</param>
  /// <param name="calculationType">Calculation type</param>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator BBF(
    int period,
    double deviation,
    PriceType priceType,
    MaMode mode,
    IndicatorCalculationType calculationType = IndicatorCalculationType.AllAvailableData)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓫(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픟(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픟(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓾(), (object) period);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핌(), (object) deviation);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓪(), (object) new SelectItem(priceType.ToString(), (int) priceType));
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓐(), (object) new SelectItem(mode.ToString(), (int) mode));
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픪(), (object) new SelectItem(calculationType.ToString(), (int) calculationType));
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  ///  Gets the ROC (Rate of Change) indicator.
  ///  <para>The ROC shows the speed at which price is changing.</para>
  /// </summary>
  /// <param name="period">Period of momentum.</param>
  /// <returns></returns>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator ROC(int period)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓩(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픯(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픯(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓨(), (object) period);
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Gets the Momentum indicator.
  /// <para>Momentum compares where the current price is in relation to where the price was in the past.</para>
  /// </summary>
  /// <param name="period">Period for Momentum</param>
  /// <param name="priceType">Sources prices for Momentum</param>
  /// <returns></returns>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator Momentum(int period, PriceType priceType)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓱(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픯(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픯(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픹(), (object) period);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓺(), (object) new SelectItem(priceType.ToString(), (int) priceType));
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Gets the %R Larry Williams.
  /// <para>Uses Stochastic to determine overbought and oversold levels.</para>
  /// </summary>
  /// <param name="period">Period for Momentum</param>
  /// <returns></returns>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator RLW(int period)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픊(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픯(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픯(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓾(), (object) period);
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Returns an instance of the Price Oscillator (PO) indicator.
  /// <para>PO calculates the variation between price moving averages.</para>
  /// </summary>
  /// <param name="period1">Period of MA1</param>
  /// <param name="period2">Period of MA2</param>
  /// <param name="priceType">Sources prices for MA</param>
  /// <param name="mode">Type of Moving Average</param>
  /// <param name="calculationType">Calculation type</param>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator PO(
    int period1,
    int period2,
    PriceType priceType,
    MaMode mode,
    IndicatorCalculationType calculationType = IndicatorCalculationType.AllAvailableData)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픈(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픯(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픯(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓒(), (object) period1);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓚(), (object) period2);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓪(), (object) new SelectItem(priceType.ToString(), (int) priceType));
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓐(), (object) new SelectItem(mode.ToString(), (int) mode));
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픪(), (object) new SelectItem(calculationType.ToString(), (int) calculationType));
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  ///  Gets the OsMA (Moving Average of Oscillator) indicator.
  ///  <para> The OsMA reflects the difference between an oscillator (MACD) and its moving average (signal line).</para>
  /// </summary>
  /// <param name="fastEMA">Period of fast EMA.</param>
  /// <param name="slowEMA">Period of slow EMA.</param>
  /// <param name="signalEMA">Period of signal EMA.</param>
  /// <param name="calculationType">Calculation type</param>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator OsMA(
    int fastEMA,
    int slowEMA,
    int signalEMA,
    IndicatorCalculationType calculationType = IndicatorCalculationType.AllAvailableData)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픃(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픯(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픯(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픛(), (object) fastEMA);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓜(), (object) slowEMA);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픺(), (object) signalEMA);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픪(), (object) new SelectItem(calculationType.ToString(), (int) calculationType));
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Gets On Balance Volume.
  /// <para>On Balance Volume (OBV) measures buying and selling pressure as a cumulative indicator that adds volume on up days and subtracts volume on down days.</para>
  /// </summary>
  /// <param name="priceType">Sources prices for OBV</param>
  /// <returns></returns>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator OBV(PriceType priceType)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓎(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.피(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.피(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓪(), (object) new SelectItem(priceType.ToString(), (int) priceType));
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Returns an instance of the Positive Volume Index (PVI) indicator.
  /// <para>The PVI value changes on the periods in which value of volume has increased in comparison with the previous period.</para>
  /// </summary>
  /// <param name="priceType"></param>
  /// <returns></returns>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator PVI(PriceType priceType)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓸(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.피(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.피(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픖(), (object) new SelectItem(priceType.ToString(), (int) priceType));
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Returns an instance of the Volume indicator.
  /// <para>Volume allows to confirm the strength of a trend or to suggest about it's weakness.</para>
  /// </summary>
  /// <returns></returns>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator Volume()
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.피(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.피(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.피(), ScriptCreationType.Default);
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  ///  Gets the MFI(Money Flow Index) indicator.
  ///  <para>The MFI(Money Flow Index) is an oscillator that uses both price and volume to measure buying and selling pressure.</para>
  /// </summary>
  /// <param name="period">Period of MFI.</param>
  /// <returns></returns>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator MFI(int period)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓦(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.피(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.피(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픋(), (object) period);
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Returns an instance of the Acceleration/Deceleration Oscillator (AC).
  /// <para>AC measures the acceleration and deceleration of the current momentum.</para>
  /// </summary>
  /// <returns></returns>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator AC()
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핀(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픯(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픯(), ScriptCreationType.Default);
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Gets the Average True Range (ATR) indicator.
  /// <para>The ATR measures of market volatility.</para>
  /// </summary>
  /// <returns></returns>
  /// <param name="period">Period of Moving Average.</param>
  /// <param name="mode">Type of Moving Average</param>
  /// <param name="calculationType">Calculation type</param>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator ATR(int period, MaMode mode, IndicatorCalculationType calculationType = IndicatorCalculationType.AllAvailableData)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픲(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픭(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픭(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픽(), (object) period);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓐(), (object) new SelectItem(mode.ToString(), (int) mode));
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픪(), (object) new SelectItem(calculationType.ToString(), (int) calculationType));
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Returns an instance of the Kaufman Adaptive Moving Average (KAMA) indicator.
  /// <para>KAMA is an exponential style average with a smoothing that varies according to recent data.</para>
  /// </summary>
  /// <param name="period">Period</param>
  /// <param name="fast">Fast factor</param>
  /// <param name="slow">Slow factor</param>
  /// <param name="priceType">Sources prices for MA</param>
  /// <returns></returns>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator KAMA(int period, double fast, double slow, PriceType priceType)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓏(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픘(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픘(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓾(), (object) period);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓬(), (object) fast);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬핇(), (object) slow);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓪(), (object) new SelectItem(priceType.ToString(), (int) priceType));
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Returns an instance of the Qstick indicator.
  /// <para>The Qstick is a moving average that shows the difference between the prices at which an issue opens and closes.</para>
  /// </summary>
  /// <param name="period"></param>
  /// <param name="mode"></param>
  /// <param name="calculationType">Calculation type</param>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator Qstick(int period, MaMode mode, IndicatorCalculationType calculationType = IndicatorCalculationType.AllAvailableData)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓲(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픯(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픯(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓾(), (object) period);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓐(), (object) new SelectItem(mode.ToString(), (int) mode));
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픪(), (object) new SelectItem(calculationType.ToString(), (int) calculationType));
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Get the Swing Index (SI) indicator.
  /// <para> The SI is used to confirm trend line breakouts on price charts.</para>
  /// </summary>
  /// <param name="divider">The divider.</param>
  /// <returns></returns>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator SI(double divider)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬핂(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓖(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓖(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픂(), (object) divider);
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Get the True Strength Index (TSI) indicator.
  /// <para>
  /// The TSI is a variation of the Relative Strength Indicator which uses a doubly-smoothed
  /// EMA of price momentum to eliminate choppy price changes and spot trend changes.
  ///  </para>
  /// </summary>
  /// <param name="firstPeriod">First MA period.</param>
  /// <param name="secondPeriod">Second MA period.</param>
  /// <param name="calculationType">Calculation type</param>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator TSI(int firstPeriod, int secondPeriod, IndicatorCalculationType calculationType = IndicatorCalculationType.AllAvailableData)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픾(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픯(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픯(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓍(), (object) firstPeriod);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픁(), (object) secondPeriod);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픪(), (object) new SelectItem(calculationType.ToString(), (int) calculationType));
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Returns an instance of the Average Directional Index (ADX) indicator.
  /// <para>The ADX determines the strength of a prevailing trend.</para>
  /// </summary>
  /// <param name="period">Period</param>
  /// <param name="mode">Type of Moving Average</param>
  /// <param name="calculationType">Calculation type</param>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator ADX(int period, MaMode mode, IndicatorCalculationType calculationType = IndicatorCalculationType.AllAvailableData)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픞(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓖(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓖(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓾(), (object) period);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓐(), (object) new SelectItem(mode.ToString(), (int) mode));
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픪(), (object) new SelectItem(calculationType.ToString(), (int) calculationType));
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Returns an instance of the Keltner Channel indicator.
  /// <para>Keltner Channels are volatility-based envelopes set above and below an exponential moving average.</para>
  /// </summary>
  /// <param name="period">Period of MA for Keltner's Channel</param>
  /// <param name="offset">Coefficient of channel's width</param>
  /// <param name="priceType">Sources prices for MA</param>
  /// <param name="mode">Type of Moving Average</param>
  /// <param name="calculationType">Calculation type</param>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator Keltner(
    int period,
    double offset,
    PriceType priceType,
    MaMode mode,
    IndicatorCalculationType calculationType = IndicatorCalculationType.AllAvailableData)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬핁(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픟(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픟(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픇(), (object) period);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픣(), (object) offset);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓪(), (object) new SelectItem(priceType.ToString(), (int) priceType));
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓐(), (object) new SelectItem(mode.ToString(), (int) mode));
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픪(), (object) new SelectItem(calculationType.ToString(), (int) calculationType));
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Returns an instance of the Percentage Price Oscillator (PPO).
  /// <para>Percentage Price Oscillator is a momentum indicator. Signal line is EMA of PPO. Formula: (FastEMA-SlowEMA)/SlowEMA.</para>
  /// </summary>
  /// <param name="fastPeriod">Fast EMA Period</param>
  /// <param name="slowPeriod">Slow EMA Period</param>
  /// <param name="signalPeriod">Signal EMA Period</param>
  /// <param name="calculationType">Calculation type</param>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator PPO(
    int fastPeriod,
    int slowPeriod,
    int signalPeriod,
    IndicatorCalculationType calculationType = IndicatorCalculationType.AllAvailableData)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓙(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픯(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픯(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓗(), (object) fastPeriod);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픎(), (object) slowPeriod);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓠(), (object) signalPeriod);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픪(), (object) new SelectItem(calculationType.ToString(), (int) calculationType));
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Gets the Stochastic Slow.
  /// <para>Shows the location of the current close relative to the high/low range over a set number of periods (Slow).</para>
  /// </summary>
  /// <param name="period">Period</param>
  /// <param name="smooth">Smoothing</param>
  /// <param name="doubleSmooth">Double smoothing</param>
  /// <param name="MaType">Moving type</param>
  /// <param name="calculationType">Calculation type</param>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator Stochastic(
    int period,
    int smooth,
    int doubleSmooth,
    MaMode MaType,
    IndicatorCalculationType calculationType = IndicatorCalculationType.AllAvailableData)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓥(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픯(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픯(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓾(), (object) period);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓯(), (object) smooth);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픜(), (object) doubleSmooth);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓑(), (object) new SelectItem(MaType.ToString(), (int) MaType));
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픪(), (object) new SelectItem(calculationType.ToString(), (int) calculationType));
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Gets the Stochastic x Relative Strength Index.
  /// <para>StochRSI is an oscillator that measures the level of RSI relative to its range.</para>
  /// </summary>
  /// <param name="rsiPeriod">Period</param>
  /// <param name="kPeriod">Smoothing</param>
  /// <param name="dPeriod">Double smoothing</param>
  /// <returns></returns>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator StochasticxRSI(int rsiPeriod, int kPeriod, int dPeriod)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬핋(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픯(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픯(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓞(), (object) rsiPeriod);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬핅(), (object) kPeriod);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픡(), (object) dPeriod);
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Gets the Ichimoku.
  /// <para>Enables to quickly discern and filter 'at a glance' the low-probability trading setups from those of higher probability.</para>
  /// </summary>
  /// <param name="TenkanPeriod">Tenkan Period</param>
  /// <param name="KijunPeriod">Kijun Period</param>
  /// <param name="SenkouSpanB">Senkou Span B</param>
  /// <returns></returns>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator ICH(int TenkanPeriod, int KijunPeriod, int SenkouSpanB)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픏(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓖(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓖(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓳(), (object) TenkanPeriod);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬핆(), (object) KijunPeriod);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픷(), (object) SenkouSpanB);
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Gets the Directional Movement Index(DMI) indicator.
  /// <para>The DMI іdentifies whether there is a definable trend in the market.</para>
  /// </summary>
  /// <param name="period">Period of Moving Average.</param>
  /// <param name="mode">Type of Moving Average.</param>
  /// <param name="calculationType">Calculation type</param>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator DMI(int period, MaMode mode, IndicatorCalculationType calculationType = IndicatorCalculationType.AllAvailableData)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓻(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓖(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓖(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픽(), (object) period);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓐(), (object) new SelectItem(mode.ToString(), (int) mode));
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픪(), (object) new SelectItem(calculationType.ToString(), (int) calculationType));
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  /// <summary>
  /// Gets the Alligator.
  /// <para>Three moving averages with different colors, periods and calculation methods.</para>
  /// </summary>
  /// <param name="JawMAType">Type of Jaw Moving Average.</param>
  /// <param name="JawSourcePrice">SourcePrice of Jaw Moving Average.</param>
  /// <param name="JawMAPeiod">Period of Jaw Moving Average.</param>
  /// <param name="JawMAShift">Shift of Jaw Moving Average.</param>
  /// <param name="TeethMAType">Period of Moving Average.</param>
  /// <param name="TeethSourcePrice">Type of Moving Average.</param>
  /// <param name="TeethMAPeiod">Period of Moving Average.</param>
  /// <param name="TeethMAShift">Type of Moving Average.</param>
  /// <param name="LipsMAType">Period of Moving Average.</param>
  /// <param name="LipsSourcePrice">Type of Moving Average.</param>
  /// <param name="LipsMAPeiod">Period of Moving Average.</param>
  /// <param name="LipsMAShift">Type of Moving Average.</param>
  /// <returns></returns>
  /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
  public Indicator Alligator(
    MaMode JawMAType,
    PriceType JawSourcePrice,
    int JawMAPeiod,
    int JawMAShift,
    MaMode TeethMAType,
    PriceType TeethSourcePrice,
    int TeethMAPeiod,
    int TeethMAShift,
    MaMode LipsMAType,
    PriceType LipsSourcePrice,
    int LipsMAPeiod,
    int LipsMAShift)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픸(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓭(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓭(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬프(), (object) new SelectItem(JawMAType.ToString(), (int) JawMAType));
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픴(), (object) new SelectItem(JawSourcePrice.ToString(), (int) JawSourcePrice));
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픑(), (object) JawMAPeiod);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픿(), (object) JawMAShift);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓔(), (object) new SelectItem(TeethMAType.ToString(), (int) TeethMAType));
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픢(), (object) new SelectItem(TeethSourcePrice.ToString(), (int) TeethSourcePrice));
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓝(), (object) TeethMAPeiod);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓶(), (object) TeethMAShift);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓽(), (object) new SelectItem(LipsMAType.ToString(), (int) LipsMAType));
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픘(), (object) new SelectItem(LipsSourcePrice.ToString(), (int) LipsSourcePrice));
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픨(), (object) LipsMAPeiod);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓪(), (object) LipsMAShift);
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }

  public Indicator HV(
    int stdPeriod,
    int volatilityPeriod,
    PriceType priceType,
    HVSheduleMode hvMode)
  {
    return this.퓏(stdPeriod, volatilityPeriod, priceType, hvMode, true, 0);
  }

  public Indicator HV(
    int stdPeriod,
    int volatilityPeriod,
    PriceType priceType,
    HVSheduleMode hvMode,
    int percentilePeriod)
  {
    return this.퓏(stdPeriod, volatilityPeriod, priceType, hvMode, false, percentilePeriod);
  }

  private Indicator 퓏(
    [In] int obj0,
    [In] int obj1,
    [In] PriceType obj2,
    [In] HVSheduleMode obj3,
    [In] bool obj4,
    [In] int obj5)
  {
    Indicator indicator = Core.Instance.Indicators.CreateIndicator(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픪(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픭(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픭(), ScriptCreationType.Default);
    IList<SettingItem> settings = indicator.Settings;
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓡(), (object) obj0);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓓(), (object) obj1);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픗(), (object) new SelectItem(obj2.ToString(), (int) obj2));
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓰(), (object) obj4);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픧(), (object) obj5);
    settings.UpdateItemValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓹(), (object) new SelectItem(obj3.ToString(), (int) obj3));
    indicator.Settings = settings;
    this.퓏(indicator);
    return indicator;
  }
}
