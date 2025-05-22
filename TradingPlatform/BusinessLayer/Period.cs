// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Period
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using ProtoBuf;
using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>
/// Represents mechanism for supporting predefined and custom periods
/// </summary>
[Published]
[DataContract(Name = "Period", Namespace = "TradingPlatform")]
[ProtoContract]
[Serializable]
public struct Period : IComparable, IXElementSerialization
{
  /// <summary>Gets period multiplier</summary>
  [DataMember(Name = "PeriodMultiplier")]
  [ProtoMember(1)]
  public int PeriodMultiplier { get; [param: In] private set; }

  /// <summary>Gets base period type</summary>
  [DataMember(Name = "BasePeriod")]
  [ProtoMember(2)]
  public BasePeriod BasePeriod { get; [param: In] private set; }

  /// <summary>
  /// Gets ticks value as an result of base period <see cref="M:TradingPlatform.BusinessLayer.Period.TicksInBasePeriod(TradingPlatform.BusinessLayer.BasePeriod)" /> multiplicated by <see cref="P:TradingPlatform.BusinessLayer.Period.PeriodMultiplier" />
  /// </summary>
  public long Ticks => Period.TicksInBasePeriod(this.BasePeriod) * (long) this.PeriodMultiplier;

  public TimeSpan Duration => TimeSpan.FromTicks(this.Ticks);

  /// <summary>
  /// Creates Period instance with <see cref="P:TradingPlatform.BusinessLayer.Period.PeriodMultiplier" /> greater than 0
  /// </summary>
  /// <param name="basePeriod"></param>
  /// <param name="periodMultiplier"></param>
  public Period(BasePeriod basePeriod, int periodMultiplier)
  {
    if (periodMultiplier <= 0)
      throw new ArgumentException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓔(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픢());
    this.BasePeriod = basePeriod;
    this.PeriodMultiplier = periodMultiplier;
  }

  /// <summary>
  /// True if their base paeriods and <see cref="P:TradingPlatform.BusinessLayer.Period.PeriodMultiplier" /> are respectively equal.
  /// </summary>
  /// <param name="period1"></param>
  /// <param name="period2"></param>
  /// <returns></returns>
  [NotPublished]
  public static bool operator ==(Period period1, Period period2)
  {
    return period1.BasePeriod == period2.BasePeriod && period1.PeriodMultiplier == period2.PeriodMultiplier;
  }

  /// <summary>
  /// True if any of their base paeriods and <see cref="P:TradingPlatform.BusinessLayer.Period.PeriodMultiplier" /> are respectively not equal.
  /// </summary>
  /// <param name="period1"></param>
  /// <param name="period2"></param>
  /// <returns></returns>
  [NotPublished]
  public static bool operator !=(Period period1, Period period2)
  {
    return period1.BasePeriod != period2.BasePeriod || period1.PeriodMultiplier != period2.PeriodMultiplier;
  }

  /// <summary>
  /// True if their ticks values are satisfying initial condition
  /// </summary>
  /// <param name="period1"></param>
  /// <param name="period2"></param>
  /// <returns></returns>
  [NotPublished]
  public static bool operator <(Period period1, Period period2)
  {
    long ticks1 = period1.Ticks;
    long ticks2 = period2.Ticks;
    return ticks1 < 0L && ticks2 < 0L ? ticks1 > ticks2 : ticks1 < ticks2;
  }

  /// <summary>
  /// True if their ticks values are satisfying initial condition
  /// </summary>
  /// <param name="period1"></param>
  /// <param name="period2"></param>
  /// <returns></returns>
  [NotPublished]
  public static bool operator >(Period period1, Period period2)
  {
    long ticks1 = period1.Ticks;
    long ticks2 = period2.Ticks;
    return ticks1 < 0L && ticks2 < 0L ? ticks1 < ticks2 : ticks1 > ticks2;
  }

  /// <summary>
  /// True if their ticks values are satisfying initial condition
  /// </summary>
  /// <param name="period1"></param>
  /// <param name="period2"></param>
  /// <returns></returns>
  [NotPublished]
  public static bool operator <=(Period period1, Period period2)
  {
    long ticks1 = period1.Ticks;
    long ticks2 = period2.Ticks;
    return ticks1 < 0L && ticks2 < 0L ? ticks1 >= ticks2 : ticks1 <= ticks2;
  }

  /// <summary>
  /// True if their ticks values are satisfying initial condition
  /// </summary>
  /// <param name="period1"></param>
  /// <param name="period2"></param>
  /// <returns></returns>
  [NotPublished]
  public static bool operator >=(Period period1, Period period2)
  {
    long ticks1 = period1.Ticks;
    long ticks2 = period2.Ticks;
    return ticks1 < 0L && ticks2 < 0L ? ticks1 <= ticks2 : ticks1 >= ticks2;
  }

  /// <summary>
  /// True if their base paeriods and <see cref="P:TradingPlatform.BusinessLayer.Period.PeriodMultiplier" /> are respectively equal.
  /// </summary>
  /// <param name="obj"></param>
  /// <returns></returns>
  [NotPublished]
  public override bool Equals(object obj)
  {
    return obj is Period period && this.BasePeriod == period.BasePeriod && this.PeriodMultiplier == period.PeriodMultiplier;
  }

  [NotPublished]
  public override int GetHashCode() => (int) ((BasePeriod) this.PeriodMultiplier ^ this.BasePeriod);

  /// <summary>
  /// Formats given value to a specific user friendly string
  /// </summary>
  /// <param name="dateTime"></param>
  /// <returns></returns>
  [NotPublished]
  public string Format(DateTime dateTime)
  {
    string shortDatePattern = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
    switch (this.BasePeriod)
    {
      case BasePeriod.Tick:
        return this.PeriodMultiplier > 1 ? dateTime.ToString(shortDatePattern + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓝()) : dateTime.ToString(shortDatePattern + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓶());
      case BasePeriod.Second:
        return dateTime.ToString(shortDatePattern + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓝());
      case BasePeriod.Minute:
      case BasePeriod.Hour:
        return dateTime.ToString(shortDatePattern + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓽());
      case BasePeriod.Day:
      case BasePeriod.Week:
        return dateTime.ToString(shortDatePattern);
      case BasePeriod.Month:
      case BasePeriod.Year:
        return dateTime.ToString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픘());
      default:
        return dateTime.ToString(shortDatePattern);
    }
  }

  [NotPublished]
  public string Format()
  {
    return $"{this.PeriodMultiplier}{Period.BasePeriodToShortString(this.BasePeriod)}";
  }

  [NotPublished]
  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 2);
    interpolatedStringHandler.AppendFormatted<int>(this.PeriodMultiplier);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓛());
    interpolatedStringHandler.AppendFormatted<BasePeriod>(this.BasePeriod);
    return interpolatedStringHandler.ToStringAndClear();
  }

  /// <summary>Returns value in ticks according to base period type</summary>
  /// <param name="basePeriod"></param>
  /// <returns></returns>
  public static long TicksInBasePeriod(BasePeriod basePeriod)
  {
    switch (basePeriod)
    {
      case BasePeriod.Tick:
        return -1;
      case BasePeriod.Second:
        return 10000000;
      case BasePeriod.Minute:
        return 600000000;
      case BasePeriod.Hour:
        return 36000000000;
      case BasePeriod.Day:
        return 864000000000;
      case BasePeriod.Week:
        return 6048000000000;
      case BasePeriod.Month:
        return 25920000000000;
      case BasePeriod.Year:
        return 315360000000000;
      default:
        throw new ArgumentException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픨());
    }
  }

  /// <summary>Returns shorted string according to base period type</summary>
  /// <param name="basePeriod"></param>
  /// <returns></returns>
  public static string BasePeriodToShortString(BasePeriod basePeriod)
  {
    string shortString;
    switch (basePeriod)
    {
      case BasePeriod.Tick:
        shortString = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픹(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓪());
        break;
      case BasePeriod.Second:
        shortString = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픿(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓪());
        break;
      case BasePeriod.Minute:
        shortString = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픪(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓪());
        break;
      case BasePeriod.Hour:
        shortString = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓡(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓪());
        break;
      case BasePeriod.Day:
        shortString = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓓(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓪());
        break;
      case BasePeriod.Week:
        shortString = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픗(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓪());
        break;
      case BasePeriod.Month:
        shortString = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓻(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓪());
        break;
      case BasePeriod.Year:
        shortString = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓰(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓪());
        break;
      default:
        shortString = string.Empty;
        break;
    }
    return shortString;
  }

  /// <summary>Converts time gap into dates range</summary>
  /// <param name="from"></param>
  /// <param name="to"></param>
  public void ToDatesRange(out DateTime from, out DateTime to)
  {
    DateTime dateTimeUtcNow = Core.Instance.TimeUtils.DateTimeUtcNow;
    from = this.BasePeriod != BasePeriod.Day ? (this.BasePeriod != BasePeriod.Month ? (this.BasePeriod != BasePeriod.Year ? dateTimeUtcNow.AddTicks(-this.Ticks) : dateTimeUtcNow.AddYears(-this.PeriodMultiplier)) : dateTimeUtcNow.AddMonths(-this.PeriodMultiplier)) : dateTimeUtcNow.AddDays((double) -this.PeriodMultiplier);
    to = dateTimeUtcNow;
  }

  /// <summary>
  /// Compares by <see cref="P:TradingPlatform.BusinessLayer.Period.Ticks" />
  /// </summary>
  /// <param name="other"></param>
  /// <returns></returns>
  [NotPublished]
  public int CompareTo(object other) => this.Ticks.CompareTo(((Period) other).Ticks);

  public static bool TryParse(string value, out Period period)
  {
    period = new Period();
    string[] strArray = value.Split('-');
    int result1;
    BasePeriod result2;
    if (strArray.Length != 2 || !int.TryParse(strArray[0].Trim(), out result1) || !Enum.TryParse<BasePeriod>(strArray[1].Trim(), true, out result2))
      return false;
    period = new Period(result2, result1);
    return true;
  }

  /// <summary>
  /// Serialize into <see cref="T:System.Xml.Linq.XElement" /> object
  /// </summary>
  /// <returns></returns>
  [NotPublished]
  public XElement ToXElement()
  {
    return new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓾(), new object[2]
    {
      (object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픧(), (object) ((int) this.BasePeriod).ToString()),
      (object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓹(), (object) this.PeriodMultiplier.ToString())
    });
  }

  /// <summary>
  /// Deserialize from <see cref="T:System.Xml.Linq.XElement" />
  /// </summary>
  /// <param name="element"></param>
  /// <param name="deserializationInfo"></param>
  [NotPublished]
  public void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    XElement element1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픧());
    if (element1 != null)
      this.BasePeriod = (BasePeriod) element1.ToInt();
    XElement element2 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓹());
    if (element2 == null)
      return;
    this.PeriodMultiplier = element2.ToInt();
  }

  /// <summary>Predefined period</summary>
  public static Period TICK1 => new Period(BasePeriod.Tick, 1);

  /// <summary>Predefined period</summary>
  public static Period SECOND1 => new Period(BasePeriod.Second, 1);

  /// <summary>Predefined period</summary>
  public static Period SECOND5 => new Period(BasePeriod.Second, 5);

  /// <summary>Predefined period</summary>
  public static Period SECOND10 => new Period(BasePeriod.Second, 10);

  /// <summary>Predefined period</summary>
  public static Period SECOND15 => new Period(BasePeriod.Second, 15);

  /// <summary>Predefined period</summary>
  public static Period SECOND30 => new Period(BasePeriod.Second, 30);

  /// <summary>Predefined period</summary>
  public static Period MIN1 => new Period(BasePeriod.Minute, 1);

  /// <summary>Predefined period</summary>
  public static Period MIN2 => new Period(BasePeriod.Minute, 2);

  /// <summary>Predefined period</summary>
  public static Period MIN3 => new Period(BasePeriod.Minute, 3);

  /// <summary>Predefined period</summary>
  public static Period MIN4 => new Period(BasePeriod.Minute, 4);

  /// <summary>Predefined period</summary>
  public static Period MIN5 => new Period(BasePeriod.Minute, 5);

  /// <summary>Predefined period</summary>
  public static Period MIN10 => new Period(BasePeriod.Minute, 10);

  /// <summary>Predefined period</summary>
  public static Period MIN15 => new Period(BasePeriod.Minute, 15);

  /// <summary>Predefined period</summary>
  public static Period MIN30 => new Period(BasePeriod.Minute, 30);

  /// <summary>Predefined period</summary>
  public static Period HOUR1 => new Period(BasePeriod.Hour, 1);

  /// <summary>Predefined period</summary>
  public static Period HOUR2 => new Period(BasePeriod.Hour, 2);

  /// <summary>Predefined period</summary>
  public static Period HOUR3 => new Period(BasePeriod.Hour, 3);

  /// <summary>Predefined period</summary>
  public static Period HOUR4 => new Period(BasePeriod.Hour, 4);

  /// <summary>Predefined period</summary>
  public static Period HOUR6 => new Period(BasePeriod.Hour, 6);

  /// <summary>Predefined period</summary>
  public static Period HOUR8 => new Period(BasePeriod.Hour, 8);

  /// <summary>Predefined period</summary>
  public static Period HOUR12 => new Period(BasePeriod.Hour, 12);

  /// <summary>Predefined period</summary>
  public static Period DAY1 => new Period(BasePeriod.Day, 1);

  /// <summary>Predefined period</summary>
  public static Period WEEK1 => new Period(BasePeriod.Week, 1);

  /// <summary>Predefined period</summary>
  public static Period MONTH1 => new Period(BasePeriod.Month, 1);

  /// <summary>Predefined period</summary>
  public static Period YEAR1 => new Period(BasePeriod.Year, 1);
}
