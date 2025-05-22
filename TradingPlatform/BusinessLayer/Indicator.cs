// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Indicator
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using TradingPlatform.BusinessLayer.Chart;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>Base class for all indicators.</summary>
[Published]
public abstract class Indicator : ExecutionEntity, IIndicatorsCollection
{
  [NotPublished]
  public const string EMA = "Exponential Moving Average";
  [NotPublished]
  public const string LWMA = "Linearly Weighted Moving Average";
  [NotPublished]
  public const string SMA = "Simple Moving Average";
  [NotPublished]
  public const string SMMA = "Smoothed Moving Average";
  [NotPublished]
  public const string PPMA = "Pivot Point Moving Average";
  [NotPublished]
  public const string CCI = "Commodity Channel Index";
  [NotPublished]
  public const string MAS3 = "3MASignal";
  [NotPublished]
  public const string MMA = "Modified Moving Average";
  [NotPublished]
  public const string Regression = "Regression Line";
  [NotPublished]
  public const string BB = "Bollinger Bands";
  [NotPublished]
  public const string Channel = "Price Channel";
  [NotPublished]
  public const string AFIRMA = "Autoregressive Finite Impulse Response Moving Average";
  [NotPublished]
  public const string RSI = "Relative Strength Index";
  [NotPublished]
  public const string MD = "McGinley Dynamic";
  [NotPublished]
  public const string MAE = "Moving Average Envelope";
  [NotPublished]
  public const string SAR = "Parabolic SAR";
  [NotPublished]
  public const string AO = "Awesome Oscillator";
  [NotPublished]
  public const string CMO = "Chande Momentum Oscillator";
  [NotPublished]
  public const string ZZ = "ZigZag";
  [NotPublished]
  public const string AROON = "Aroon";
  [NotPublished]
  public const string MACD = "Moving Average Convergence/Divergence";
  [NotPublished]
  public const string SD = "Standard Deviation";
  [NotPublished]
  public const string KRI = "Kairi Relative Index";
  [NotPublished]
  public const string BBF = "Bollinger Bands Flat";
  [NotPublished]
  public const string ROC = "Rate of Change";
  [NotPublished]
  public const string Momentum = "Momentum";
  [NotPublished]
  public const string RLW = "%R Larry Williams";
  [NotPublished]
  public const string PO = "Price Oscillator";
  [NotPublished]
  public const string OBV = "On Balance Volume";
  [NotPublished]
  public const string OsMA = "Moving Average of Oscillator";
  [NotPublished]
  public const string PVI = "Positive Volume Index";
  [NotPublished]
  public const string VOLUME = "Volume";
  [NotPublished]
  public const string MFI = "Money Flow Index";
  [NotPublished]
  public const string AC = "Acceleration Oscillator";
  [NotPublished]
  public const string ATR = "Average True Range";
  [NotPublished]
  public const string KAMA = "Kaufman Adaptive Moving Average";
  [NotPublished]
  public const string Stochastic = "Stochastic Slow";
  [NotPublished]
  public const string StochasticxRSI = "Stochastic x Relative Strength Index";
  [NotPublished]
  public const string Qstick = "Qstick";
  [NotPublished]
  public const string SI = "Swing Index";
  [NotPublished]
  public const string ADX = "Average Directional Index";
  [NotPublished]
  public const string Keltner = "Keltner Channel";
  [NotPublished]
  public const string PPO = "Percentage Price Oscillator";
  [NotPublished]
  public const string TSI = "True Strength Index";
  [NotPublished]
  public const string DMI = "Directional Movement Index";
  [NotPublished]
  public const string ICH = "Ichimoku";
  [NotPublished]
  public const string Alligator = "Alligator";
  [NotPublished]
  public const string HV = "Historical Volatility";
  [NotPublished]
  public const string PAZ = "Price Action Zones";
  [NotPublished]
  public const string OSCILLATOR_GROUP = "Oscillators";
  [NotPublished]
  public const string MOVING_AVERAGE_GROUP = "Moving averages";
  [NotPublished]
  public const string TREND_GROUP = "Trend";
  [NotPublished]
  public const string VOLATILITY_GROUP = "Volatility";
  [NotPublished]
  public const string CHANNEL_GROUP = "Channels";
  [NotPublished]
  public const string VOLUME_GROUP = "Volume";
  [NotPublished]
  public const string HIDDEN_GROUP = "Hidden";
  [NotPublished]
  protected internal const IndicatorCalculationType DEFAULT_CALCULATION_TYPE = IndicatorCalculationType.AllAvailableData;
  private string 퓯퓣;
  private const string 퓯픀 = "Line_";
  private const string 퓯픖 = "Level_";
  private readonly List<LineSeries> 퓯픓;
  private readonly List<LineLevel> 퓯픩;
  private readonly object 퓯필;
  private readonly List<Indicator> 퓯퓖;
  private readonly object 퓯픵;
  private readonly List<HistoricalDataCustom> 퓯픬;
  private readonly object 퓯퓕;
  [EditorBrowsable(EditorBrowsableState.Never)]
  [Obfuscation(Exclude = true)]
  private bool debugMode;
  private bool 퓯픐;
  private readonly IDictionary<IndicatorCloudKey, List<Indicator.퓏>> 퓯픭;
  private readonly object 퓯픔;
  private readonly List<IndicatorBarAppearance> 퓯핈;

  /// <summary>Short name of indicator</summary>
  public virtual string ShortName
  {
    get => string.IsNullOrEmpty(this.퓯퓣) ? this.Name : this.퓯퓣;
    [Obsolete("Override getter")] protected set => this.퓯퓣 = value;
  }

  /// <summary>Access to current Symbol of indicator</summary>
  public Symbol Symbol => this.HistoricalData?.Symbol;

  /// <summary>Amount of items in internal buffers</summary>
  public int Count { get; [param: In] private set; }

  /// <summary>Represent access to current used historical data.</summary>
  public HistoricalData HistoricalData { get; [param: In] internal set; }

  /// <summary>Represent access indicator series</summary>
  public LineSeries[] LinesSeries => this.퓯픓.ToArray();

  /// <summary>
  /// 
  /// </summary>
  public LineLevel[] LinesLevels => this.퓯픩.ToArray();

  /// <summary>
  /// Specified, whether indicator should use main or additional window on the chart
  /// </summary>
  public bool SeparateWindow { get; set; }

  /// <summary>
  /// Specified, whether indicator should draw on chart background by default.
  /// </summary>
  public bool OnBackGround { get; set; }

  /// <summary>
  /// Specified, whether indicator should participate into price auto scale system.
  /// </summary>
  public bool AllowFitAuto { get; set; } = true;

  /// <summary>
  /// Precision amount for formatting price (the count of digits after decimal point); By default = -1, which means to use precision from indicator's symbol
  /// </summary>
  public int Digits { get; set; } = -1;

  public TimeFrameConfig TFConfig { get; [param: In] private set; } = new TimeFrameConfig();

  public IndicatorUpdateType UpdateType { get; set; }

  protected bool IsUpdateTypesSupported { get; set; } = true;

  /// <summary>Indicator's settings</summary>
  public override IList<SettingItem> Settings
  {
    get
    {
      IList<SettingItem> settings1 = base.Settings;
      if (this.퓯픓 != null)
      {
        for (int index = 0; index < this.퓯픓.Count; ++index)
        {
          int sortIndex = index + 1;
          LineSeries lineSeries = this.퓯픓[index];
          string str = string.Format(loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓹(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓛()), (object) sortIndex);
          SettingItemSeparatorGroup itemSeparatorGroup = new SettingItemSeparatorGroup(string.IsNullOrEmpty(lineSeries.Name) || lineSeries.Name.Contains(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픝()) ? str : string.Format(loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픻(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓛()), (object) lineSeries.Name), sortIndex);
          IList<SettingItem> settings2 = lineSeries.Settings;
          foreach (SettingItem settingItem in (IEnumerable<SettingItem>) settings2)
            settingItem.SeparatorGroup = itemSeparatorGroup;
          IList<SettingItem> settingItemList = settings1;
          SettingItemGroup settingItemGroup = new SettingItemGroup($"{\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픝()}{index}", settings2);
          settingItemGroup.Text = str + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓤();
          settingItemList.Add((SettingItem) settingItemGroup);
        }
        if (this.퓯픩 != null)
        {
          for (int index = 0; index < this.퓯픩.Count; ++index)
          {
            int num = this.퓯픓.Count + index;
            LineLevel lineLevel = this.퓯픩[index];
            string str = string.Format(loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픮(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓛()), (object) (index + 1));
            SettingItemSeparatorGroup itemSeparatorGroup = new SettingItemSeparatorGroup(string.IsNullOrEmpty(lineLevel.Name) || lineLevel.Name.Contains(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픉()) ? str : string.Format(loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픻(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓛()), (object) lineLevel.Name), num + 1);
            IList<SettingItem> settings3 = lineLevel.Settings;
            foreach (SettingItem settingItem in (IEnumerable<SettingItem>) settings3)
              settingItem.SeparatorGroup = itemSeparatorGroup;
            IList<SettingItem> settingItemList = settings1;
            SettingItemGroup settingItemGroup = new SettingItemGroup($"{\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픝()}{num}", settings3);
            settingItemGroup.Text = str + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓤();
            settingItemList.Add((SettingItem) settingItemGroup);
          }
        }
      }
      if (this.HistoricalData != null && (this.TFConfig.DefaultAggregation == null || this.HistoricalData.Aggregation != null && !this.HistoricalData.Aggregation.Equals(this.TFConfig.DefaultAggregation)))
        this.TFConfig.DefaultAggregation = this.HistoricalData.Aggregation;
      IList<SettingItem> settingItemList1 = settings1;
      SettingItemTimeFrameConfig itemTimeFrameConfig = new SettingItemTimeFrameConfig(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픘(), this.TFConfig);
      itemTimeFrameConfig.SeparatorGroup = new SettingItemSeparatorGroup(string.Empty, 1000);
      settingItemList1.Add((SettingItem) itemTimeFrameConfig);
      List<SelectItem> selectItemList = new List<SelectItem>()
      {
        new SelectItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픒(), 0),
        new SelectItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓷(), 1)
      };
      if (this.IsUpdateTypesSupported)
      {
        IList<SettingItem> settingItemList2 = settings1;
        SettingItemSelectorLocalized selectorLocalized = new SettingItemSelectorLocalized(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓿(), selectItemList.GetItemByValue<int>((int) this.UpdateType), selectItemList);
        selectorLocalized.SeparatorGroup = new SettingItemSeparatorGroup(string.Empty, 1100);
        settingItemList2.Add((SettingItem) selectorLocalized);
      }
      return settings1;
    }
    set
    {
      base.Settings = value;
      foreach (SettingItem settingItem in (IEnumerable<SettingItem>) value)
      {
        int result;
        if (settingItem is SettingItemGroup settingItemGroup && settingItemGroup.Value is IList<SettingItem> source && source.Any<SettingItem>() && source[0].Group != null && int.TryParse(source[0].Group.Name.Replace(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픝(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓥()), out result))
        {
          if (result < this.퓯픓.Count)
          {
            this.퓯픓[result].Settings = source;
          }
          else
          {
            int index = result - this.퓯픓.Count;
            if (index < this.퓯픩.Count)
              this.퓯픩[index].Settings = source;
          }
        }
      }
      bool flag = false;
      if (value.GetItemByName(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픘()) is SettingItemTimeFrameConfig itemByName1)
        this.TFConfig = (TimeFrameConfig) itemByName1.Value;
      if (this.IsUpdateTypesSupported && value.GetItemByName(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓿()) is SettingItemSelectorLocalized itemByName2)
      {
        this.UpdateType = (IndicatorUpdateType) ((SelectItem) itemByName2.Value).Value;
        flag = itemByName2.ValueChangingReason == SettingItemValueChangingReason.Manually;
      }
      if (!flag)
        return;
      this.OnSettingsUpdated();
    }
  }

  /// <summary>Represent access to the chart, that created indicator</summary>
  public IChart CurrentChart { get; set; }

  public virtual string HelpLink => string.Empty;

  public virtual string SourceCodeLink => string.Empty;

  protected virtual void OnInit()
  {
  }

  protected virtual void OnUpdate(UpdateArgs args)
  {
  }

  protected virtual void OnClear()
  {
  }

  public LineSeries AddLineSeries(
    string lineName = "",
    Color lineColor = default (Color),
    int lineWidth = 1,
    LineStyle lineStyle = LineStyle.Solid)
  {
    if (string.IsNullOrEmpty(lineName))
      lineName = $"{\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픝()}{this.퓯픓.Count + 1}";
    if (lineColor == new Color())
      lineColor = Color.Blue;
    LineSeries lineSeries = new LineSeries(lineName, lineColor, lineWidth, lineStyle);
    this.AddLineSeries(lineSeries);
    return lineSeries;
  }

  public void AddLineSeries(LineSeries lineSeries)
  {
    if (lineSeries == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픟());
    lock (this.퓯필)
      this.퓯픓.Add(lineSeries);
  }

  public LineLevel AddLineLevel(
    double level,
    string lineName = "",
    Color lineColor = default (Color),
    int lineWidth = 1,
    LineStyle lineStyle = LineStyle.Solid)
  {
    if (string.IsNullOrEmpty(lineName))
      lineName = $"{\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픉()}{level}";
    if (lineColor == new Color())
      lineColor = Color.Blue;
    LineLevel lineLevel = new LineLevel(level, lineName, lineColor, lineWidth, lineStyle);
    this.AddLineLevel(lineLevel);
    return lineLevel;
  }

  public void AddLineLevel(LineLevel lineLevel)
  {
    if (lineLevel == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓧());
    this.퓯픩.Add(lineLevel);
  }

  /// <summary>Recalculate indicator</summary>
  public void Refresh() => ((퓏.퓲) this.HistoricalData)?.퓏(this);

  /// <summary>
  /// 
  /// </summary>
  /// <param name="indicator"></param>
  public void AddIndicator(Indicator indicator)
  {
    if (indicator == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞핆());
    lock (this.퓯픵)
    {
      if (this.퓯퓖.Contains(indicator))
        throw new InvalidOperationException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픰());
      indicator.HistoricalData = this.HistoricalData;
      indicator.Init();
      for (int index = 0; index < this.Count; ++index)
        indicator.Update(new UpdateArgs(UpdateReason.HistoricalBar));
      this.퓯퓖.Add(indicator);
    }
  }

  public void RemoveIndicator(Indicator indicator)
  {
    if (indicator == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞핆());
    lock (this.퓯픵)
      this.퓯퓖.Remove(indicator);
    indicator.Clear();
    indicator.Dispose();
  }

  /// <summary>Sets the value of indicator into internal buffer</summary>
  /// <param name="value">Value</param>
  /// <param name="lineIndex">Index of indicator line</param>
  /// <param name="offset">Offset value</param>
  public void SetValue(double value, int lineIndex = 0, int offset = 0)
  {
    this.퓯픓[lineIndex].SetValue(value, offset);
  }

  /// <summary>Gets the value of indicator from internal buffer</summary>
  /// <param name="offset">Offset value</param>
  /// <param name="lineIndex">Index of indicator line</param>
  /// <param name="origin">Offset start point</param>
  /// <returns></returns>
  public double GetValue(int offset = 0, int lineIndex = 0, SeekOriginHistory origin = SeekOriginHistory.End)
  {
    double num = double.NaN;
    return lineIndex < 0 || lineIndex >= this.퓯픓.Count ? num : this.퓯픓[lineIndex].GetValue(offset, origin);
  }

  /// <summary>Set line break point.</summary>
  /// <param name="offset">Offset value</param>
  /// <param name="lineIndex">Index of indicator line</param>
  /// <param name="origin">Offset start point</param>
  public void SetLineBreak(int offset = 0, int lineIndex = 0, SeekOriginHistory origin = SeekOriginHistory.End)
  {
    if (lineIndex < 0 || lineIndex >= this.퓯픓.Count)
      throw new ArgumentOutOfRangeException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓢());
    int offset1 = origin == SeekOriginHistory.End ? offset : this.Count - offset - 1;
    this.LinesSeries[lineIndex].SetLineBreak(offset1);
  }

  /// <summary>Remove line break point.</summary>
  /// <param name="offset">Offset value</param>
  /// <param name="lineIndex">Index of indicator line</param>
  /// <param name="origin">Offset start point</param>
  public void RemoveLineBreak(int offset = 0, int lineIndex = 0, SeekOriginHistory origin = SeekOriginHistory.End)
  {
    if (lineIndex < 0 || lineIndex >= this.퓯픓.Count)
      throw new ArgumentOutOfRangeException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓢());
    int offset1 = origin == SeekOriginHistory.End ? offset : this.Count - offset - 1;
    this.LinesSeries[lineIndex].RemoveLineBreak(offset1);
  }

  /// <summary>Check if the point is a break point.</summary>
  /// <param name="offset">Offset value</param>
  /// <param name="lineIndex">Index of indicator line</param>
  /// <param name="origin">Offset start point</param>
  public bool GetLineBreak(int offset = 0, int lineIndex = 0, SeekOriginHistory origin = SeekOriginHistory.End)
  {
    if (lineIndex < 0 || lineIndex >= this.퓯픓.Count)
      throw new ArgumentOutOfRangeException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓢());
    int offset1 = origin == SeekOriginHistory.End ? offset : this.Count - offset - 1;
    return this.LinesSeries[lineIndex].GetLineBreak(offset1);
  }

  /// <summary>Gets the price from historical data</summary>
  /// <param name="priceType"></param>
  /// <param name="offset"></param>
  /// <returns></returns>
  protected double GetPrice(PriceType priceType, int offset = 0)
  {
    return this.HistoricalData[this.Count - 1 - offset, SeekOriginHistory.Begin][priceType];
  }

  protected VolumeAnalysisData GetVolumeAnalysisData(int offset = 0)
  {
    return this.HistoricalData[this.Count - 1 - offset, SeekOriginHistory.Begin].VolumeAnalysisData;
  }

  /// <summary>Get Bid price</summary>
  /// <param name="offset">Offset value</param>
  /// <returns></returns>
  protected double Bid(int offset = 0) => this.GetPrice(PriceType.Bid, offset);

  /// <summary>Get Ask price</summary>
  /// <param name="offset">Offset value</param>
  /// <returns></returns>
  protected double Ask(int offset = 0) => this.GetPrice(PriceType.Ask, offset);

  /// <summary>Get Last price</summary>
  /// <param name="offset">Offset value</param>
  /// <returns></returns>
  protected double Last(int offset = 0) => this.GetPrice(PriceType.Last, offset);

  /// <summary>Get Open price</summary>
  /// <param name="offset">Offset value</param>
  /// <returns></returns>
  protected double Open(int offset = 0) => this.GetPrice(PriceType.Open, offset);

  /// <summary>Get High price</summary>
  /// <param name="offset">Offset value</param>
  /// <returns></returns>
  protected double High(int offset = 0) => this.GetPrice(PriceType.High, offset);

  /// <summary>Get Low price</summary>
  /// <param name="offset">Offset value</param>
  /// <returns></returns>
  protected double Low(int offset = 0) => this.GetPrice(PriceType.Low, offset);

  /// <summary>Get Close price</summary>
  /// <param name="offset">Offset value</param>
  /// <returns></returns>
  protected double Close(int offset = 0) => this.GetPrice(PriceType.Close, offset);

  /// <summary>Get Median price</summary>
  /// <param name="offset">Offset value</param>
  /// <returns></returns>
  protected double Median(int offset = 0) => this.GetPrice(PriceType.Median, offset);

  /// <summary>Get Typical price</summary>
  /// <param name="offset">Offset value</param>
  /// <returns></returns>
  protected double Typical(int offset = 0) => this.GetPrice(PriceType.Typical, offset);

  /// <summary>Get Weighted price</summary>
  /// <param name="offset">Offset value</param>
  /// <returns></returns>
  protected double Weighted(int offset = 0) => this.GetPrice(PriceType.Weighted, offset);

  /// <summary>Get Volume</summary>
  /// <param name="offset">Offset value</param>
  /// <returns></returns>
  protected double Volume(int offset = 0) => this.GetPrice(PriceType.Volume, offset);

  /// <summary>Get Volume in quoting asset</summary>
  /// <param name="offset">Offset value</param>
  /// <returns></returns>
  protected double QuoteAssetVolume(int offset = 0)
  {
    return this.GetPrice(PriceType.QuoteAssetVolume, offset);
  }

  /// <summary>Get Ticks</summary>
  /// <param name="offset">Offset value</param>
  /// <returns></returns>
  protected double Ticks(int offset = 0) => this.GetPrice(PriceType.Ticks, offset);

  /// <summary>Get Open interest</summary>
  /// <param name="offset">Offset value</param>
  /// <returns></returns>
  protected double OpenInterest(int offset = 0) => this.GetPrice(PriceType.OpenInterest, offset);

  /// <summary>Get Funding rate</summary>
  /// <param name="offset">Offset value</param>
  /// <returns></returns>
  protected double FundingRate(int offset = 0) => this.GetPrice(PriceType.FundingRate, offset);

  /// <summary>Get Time</summary>
  /// <param name="offset">Offset value</param>
  /// <returns></returns>
  protected DateTime Time(int offset = 0)
  {
    return new DateTime(this.HistoricalData[this.Count - 1 - offset, SeekOriginHistory.Begin].TicksLeft, DateTimeKind.Utc);
  }

  /// <summary>
  /// Formatting price, using precision from assigned symbol or Digits value if specified
  /// </summary>
  /// <param name="price">Price value</param>
  /// <returns></returns>
  public string FormatPrice(double price)
  {
    if (this.Digits != -1)
      return price.Format(this.Digits);
    return this.Symbol != null ? this.Symbol.FormatPrice(price) : price.ToString();
  }

  [NotPublished]
  public override void Dispose()
  {
    base.Dispose();
    this.HistoricalData = (HistoricalData) null;
  }

  public virtual void OnPaintChart(PaintChartEventArgs args)
  {
  }

  public void Calculate(HistoricalData historicalData)
  {
    if (historicalData == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픫());
    this.HistoricalData?.RemoveIndicator(this);
    historicalData.AddIndicator(this);
  }

  /// <summary>
  /// Marks cloud begin between two line series with specific color
  /// </summary>
  /// <param name="line1Index">First line series index</param>
  /// <param name="line2Index">Second line series index</param>
  /// <param name="color">Cloud color</param>
  /// <param name="offset">Offset</param>
  protected void BeginCloud(int line1Index, int line2Index, Color color, int offset = 0)
  {
    Indicator.퓏 퓏 = this.퓏(new IndicatorCloudKey(line1Index, line2Index), this.Count - 1 - offset);
    Color? endColor = 퓏.EndColor;
    Color color1 = color;
    if ((endColor.HasValue ? (endColor.GetValueOrDefault() == color1 ? 1 : 0) : 0) != 0)
      퓏.EndColor = new Color?();
    else
      퓏.BeginColor = new Color?(color);
  }

  /// <summary>
  /// Marks cloud end between two line series with specific color
  /// </summary>
  /// <param name="line1Index">First line series index</param>
  /// <param name="line2Index">Second line series index</param>
  /// <param name="color">Cloud color</param>
  /// <param name="offset">Offset</param>
  protected void EndCloud(int line1Index, int line2Index, Color color, int offset = 0)
  {
    Indicator.퓏 퓏 = this.퓏(new IndicatorCloudKey(line1Index, line2Index), this.Count - 1 - offset);
    Color? beginColor = 퓏.BeginColor;
    Color color1 = color;
    if ((beginColor.HasValue ? (beginColor.GetValueOrDefault() == color1 ? 1 : 0) : 0) != 0)
      퓏.BeginColor = new Color?();
    else
      퓏.EndColor = new Color?(color);
  }

  private Indicator.퓏 퓏([In] IndicatorCloudKey obj0, [In] int obj1)
  {
    lock (this.퓯픔)
    {
      List<Indicator.퓏> 퓏List;
      if (!this.퓯픭.TryGetValue(obj0, out 퓏List))
      {
        this.퓯픭[obj0] = 퓏List = new List<Indicator.퓏>();
        for (int index = 0; index < this.Count; ++index)
          퓏List.Add(new Indicator.퓏());
      }
      Indicator.퓏 퓏 = 퓏List[obj1];
      if (퓏 == null)
        퓏List[obj1] = 퓏 = new Indicator.퓏();
      return 퓏;
    }
  }

  [NotPublished]
  public IDictionary<IndicatorCloudKey, IndicatorCloud[]> AnalyzeClouds()
  {
    IDictionary<IndicatorCloudKey, List<Indicator.퓏>> dictionary1;
    lock (this.퓯픔)
    {
      if (this.퓯픭.Count == 0)
        return (IDictionary<IndicatorCloudKey, IndicatorCloud[]>) null;
      dictionary1 = (IDictionary<IndicatorCloudKey, List<Indicator.퓏>>) new Dictionary<IndicatorCloudKey, List<Indicator.퓏>>(this.퓯픭);
    }
    Dictionary<IndicatorCloudKey, IndicatorCloud[]> dictionary2 = new Dictionary<IndicatorCloudKey, IndicatorCloud[]>();
    foreach (KeyValuePair<IndicatorCloudKey, List<Indicator.퓏>> keyValuePair in (IEnumerable<KeyValuePair<IndicatorCloudKey, List<Indicator.퓏>>>) dictionary1)
    {
      IndicatorCloudKey key = keyValuePair.Key;
      List<Indicator.퓏> 퓏List = keyValuePair.Value;
      List<IndicatorCloud> indicatorCloudList = new List<IndicatorCloud>();
      IndicatorCloud indicatorCloud1 = (IndicatorCloud) null;
      for (int index = 0; index < 퓏List.Count; ++index)
      {
        Indicator.퓏 퓏 = 퓏List[index];
        Color? nullable = 퓏.EndColor;
        if (nullable.HasValue && indicatorCloud1 != null)
        {
          indicatorCloud1.ToIndex = index;
          if (indicatorCloud1.ToIndex - indicatorCloud1.FromIndex > 0)
            --indicatorCloud1.ToIndex;
          indicatorCloudList.Add(indicatorCloud1);
          indicatorCloud1 = (IndicatorCloud) null;
        }
        nullable = 퓏.BeginColor;
        if (nullable.HasValue)
        {
          IndicatorCloud indicatorCloud2 = new IndicatorCloud();
          nullable = 퓏.BeginColor;
          indicatorCloud2.Color = nullable.Value;
          indicatorCloud2.FromIndex = index;
          indicatorCloud1 = indicatorCloud2;
        }
      }
      if (indicatorCloud1 != null)
      {
        if (indicatorCloud1.ToIndex == -1)
          indicatorCloud1.ToIndex = this.Count - 1;
        indicatorCloudList.Add(indicatorCloud1);
      }
      dictionary2.Add(key, indicatorCloudList.ToArray());
    }
    return (IDictionary<IndicatorCloudKey, IndicatorCloud[]>) dictionary2;
  }

  public void SetBarColor(Color? color = null, int offset = 0)
  {
    int index = this.퓯핈.Count - 1 - offset;
    if (!color.HasValue)
      this.퓯핈[index] = (IndicatorBarAppearance) null;
    else
      this.퓯핈[index] = new IndicatorBarAppearance()
      {
        BarColor = color.Value
      };
  }

  public IndicatorBarAppearance GetBarAppearance(int offset = 0)
  {
    int index = this.퓯핈.Count - 1 - offset;
    return index < 0 ? (IndicatorBarAppearance) null : this.퓯핈[index];
  }

  public void SetBarAppearance(IndicatorBarAppearance barAppearance, int offset = 0)
  {
    this.퓯핈[this.퓯핈.Count - 1 - offset] = barAppearance;
  }

  protected virtual bool OnTryGetMinMax(
    int fromOffset,
    int toOffset,
    out double min,
    out double max)
  {
    min = double.NaN;
    max = double.NaN;
    return false;
  }

  internal int ChildIndicatorsCount
  {
    get
    {
      lock (this.퓯픵)
        return this.퓯퓖.Count;
    }
  }

  protected Indicator()
  {
    this.퓯필 = new object();
    this.퓯픓 = new List<LineSeries>();
    this.퓯픩 = new List<LineLevel>();
    this.퓯퓖 = new List<Indicator>();
    this.퓯픵 = new object();
    this.퓯픬 = new List<HistoricalDataCustom>();
    this.퓯퓕 = new object();
    this.퓯픭 = (IDictionary<IndicatorCloudKey, List<Indicator.퓏>>) new Dictionary<IndicatorCloudKey, List<Indicator.퓏>>();
    this.퓯픔 = new object();
    this.퓯핈 = new List<IndicatorBarAppearance>();
  }

  public void Init()
  {
    try
    {
      this.OnInit();
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex, this.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픯());
    }
  }

  public void Update(UpdateArgs args)
  {
    if (this.debugMode)
    {
      while (!this.Disposed)
      {
        Thread.Sleep(100);
        if (this.퓯픐)
          break;
      }
    }
    int num = this.퓏(args.Reason) ? 1 : 0;
    this.퓏(args);
    if (num != 0)
    {
      ++this.Count;
      this.퓬();
      this.퓲();
    }
    try
    {
      this.OnUpdate(args);
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex, this.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓾());
    }
    this.퓯픐 = false;
  }

  public void Clear()
  {
    this.핇();
    this.핂();
    this.Count = 0;
    if (this.퓯픓 == null)
      return;
    lock (this.퓯필)
    {
      foreach (LineSeries lineSeries in this.퓯픓)
        lineSeries.Clear();
    }
    lock (this.퓯픔)
      this.퓯픭.Clear();
    this.퓯핈.Clear();
    try
    {
      this.OnClear();
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex, this.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓐());
    }
  }

  public bool TryGetMinMax(int fromOffset, int toOffset, out double min, out double max)
  {
    min = double.NaN;
    max = double.NaN;
    try
    {
      return this.OnTryGetMinMax(fromOffset, toOffset, out min, out max);
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex, this.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픚());
    }
    return false;
  }

  public void PaintChart(PaintChartEventArgs ev)
  {
    try
    {
      this.OnPaintChart(ev);
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
    this.퓯픐 = true;
  }

  private bool 퓏([In] UpdateReason obj0)
  {
    bool flag;
    switch (obj0)
    {
      case UpdateReason.HistoricalBar:
        flag = true;
        break;
      case UpdateReason.NewTick:
        if (this.HistoricalData.Aggregation == null)
        {
          flag = false;
          break;
        }
        if (this.HistoricalData.Aggregation.Name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓑() && this.HistoricalData.Aggregation.GetPeriod == Period.TICK1)
        {
          flag = true;
          break;
        }
        goto default;
      case UpdateReason.NewBar:
        flag = true;
        break;
      default:
        flag = false;
        break;
    }
    return flag;
  }

  private void 퓬()
  {
    lock (this.퓯필)
    {
      foreach (LineSeries lineSeries in this.퓯픓)
        lineSeries.퓏();
    }
    lock (this.퓯픭)
    {
      foreach (KeyValuePair<IndicatorCloudKey, List<Indicator.퓏>> keyValuePair in (IEnumerable<KeyValuePair<IndicatorCloudKey, List<Indicator.퓏>>>) this.퓯픭)
        keyValuePair.Value.Add(new Indicator.퓏());
    }
    this.퓯핈.Add((IndicatorBarAppearance) null);
  }

  private void 퓏([In] UpdateArgs obj0)
  {
    lock (this.퓯픵)
    {
      foreach (Indicator indicator in this.퓯퓖)
        indicator.Update(obj0);
    }
  }

  private void 핇()
  {
    lock (this.퓯픵)
    {
      foreach (Indicator indicator in this.퓯퓖)
      {
        indicator.Clear();
        indicator.Dispose();
      }
      this.퓯퓖.Clear();
    }
  }

  internal void 퓏([In] HistoricalDataCustom obj0)
  {
    if (obj0 == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓵());
    lock (this.퓯퓕)
    {
      if (this.퓯픬.Contains(obj0))
        throw new InvalidOperationException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙플());
      for (int index = 0; index < this.Count; ++index)
        obj0.퓬();
      this.퓯픬.Add(obj0);
    }
  }

  private void 퓲()
  {
    lock (this.퓯퓕)
    {
      foreach (HistoricalDataCustom historicalDataCustom in this.퓯픬)
        historicalDataCustom.퓬();
    }
  }

  private void 핂()
  {
    lock (this.퓯퓕)
    {
      foreach (HistoricalData historicalData in this.퓯픬)
        historicalData.Dispose();
      this.퓯픬.Clear();
    }
  }

  protected override void OnSettingsUpdated() => this.Refresh();

  private new class 퓏
  {
    public Color? BeginColor { get; [param: In] set; }

    public Color? EndColor { get; [param: In] set; }

    public override string ToString()
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 2);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓔());
      interpolatedStringHandler.AppendFormatted<Color?>(this.BeginColor);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픢());
      interpolatedStringHandler.AppendFormatted<Color?>(this.EndColor);
      return interpolatedStringHandler.ToStringAndClear();
    }
  }
}
