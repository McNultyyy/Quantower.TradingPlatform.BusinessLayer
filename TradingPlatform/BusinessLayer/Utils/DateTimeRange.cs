// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.DateTimeRange
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils;

public sealed class DateTimeRange : IXElementSerialization, IComparable
{
  private const string 픇픴 = "RangeSelector";

  public Period Period { get; [param: In] private set; }

  public Period? EndOffset { get; [param: In] private set; }

  public DateTimeRangeType RangeType { get; [param: In] private set; }

  public DateTime From { get; [param: In] private set; }

  public DateTime To { get; [param: In] private set; }

  public Connection TimeSourceConnection { get; set; }

  public DateTimeRange()
  {
  }

  public DateTimeRange(Period period)
    : this()
  {
    this.SetRange(period);
  }

  public DateTimeRange(Period period, DateTimeRangeType dateTimeRangeType)
    : this()
  {
    this.SetRange(period, dateTimeRangeType);
  }

  public DateTimeRange(Period period, Period endOffset, DateTimeRangeType dateTimeRangeType)
    : this()
  {
    this.퓏(period, endOffset, dateTimeRangeType);
  }

  public DateTimeRange(DateTime from, DateTime to)
    : this()
  {
    this.SetRange(from, to);
  }

  public DateTimeRange(DateTimeRange original)
    : this()
  {
    this.RangeType = original.RangeType;
    this.Period = original.Period;
    this.EndOffset = original.EndOffset;
    this.From = original.From;
    this.To = original.To;
    this.Update();
  }

  public void SetRange(Period period)
  {
    if (this.RangeType == DateTimeRangeType.Custom)
      throw new ArgumentException();
    this.Period = period;
    this.Update();
  }

  public void SetRange(Period period, DateTimeRangeType rangeType)
  {
    this.RangeType = rangeType != DateTimeRangeType.Custom ? rangeType : throw new ArgumentException();
    this.Period = period;
    this.Update();
  }

  private void 퓏([In] Period obj0, [In] Period obj1, [In] DateTimeRangeType obj2)
  {
    this.RangeType = obj2 != DateTimeRangeType.Custom ? obj2 : throw new ArgumentException();
    this.Period = obj0;
    this.EndOffset = new Period?(obj1);
    this.Update();
  }

  public void SetRange(DateTime from, DateTime to)
  {
    this.From = this.퓏(from, to) ? from : throw new ArgumentOutOfRangeException();
    this.To = to;
    this.RangeType = DateTimeRangeType.Custom;
  }

  public void Update()
  {
    if (this.RangeType == DateTimeRangeType.Custom)
      return;
    (DateTime from, DateTime to) = DateTimeRange.퓏(this.Period, this.EndOffset, this.RangeType, this.TimeSourceConnection);
    this.From = from;
    this.To = to;
  }

  public void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    XElement xelement1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓧());
    XElement element1 = xelement1.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픰());
    if (element1 != null)
      this.RangeType = (DateTimeRangeType) element1.ToInt();
    XElement element2 = xelement1.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓾());
    if (element2 != null)
    {
      Period period = new Period();
      period.FromXElement(element2, deserializationInfo);
      this.Period = period;
    }
    XElement xelement2 = xelement1.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓢());
    if (xelement2 != null)
    {
      XElement element3 = xelement2.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓾());
      if (element3 != null)
      {
        Period period = new Period();
        period.FromXElement(element3, deserializationInfo);
        this.EndOffset = new Period?(period);
      }
    }
    if (this.RangeType != DateTimeRangeType.Custom)
    {
      this.Update();
    }
    else
    {
      XElement element4 = xelement1.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픫());
      if (element4 != null)
        this.From = element4.ToDateTime(true);
      XElement element5 = xelement1.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픯());
      if (element5 == null)
        return;
      this.To = element5.ToDateTime(true);
    }
  }

  public XElement ToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓧());
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픰(), (object) (int) this.RangeType));
    xelement.Add((object) this.Period.ToXElement());
    if (this.EndOffset.HasValue)
    {
      XElement content = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓢());
      content.Add((object) this.EndOffset.Value.ToXElement());
      xelement.Add((object) content);
    }
    if (this.RangeType == DateTimeRangeType.Custom)
    {
      xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픫(), (object) this.From));
      xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픯(), (object) this.To));
    }
    return xelement;
  }

  private static (DateTime from, DateTime to) 퓏(
    [In] Period obj0,
    [In] Period? obj1,
    [In] DateTimeRangeType obj2,
    [In] Connection obj3)
  {
    return DateTimeRange.퓏(obj0, obj1, obj2, DayOfWeek.Monday, obj3);
  }

  private static (DateTime from, DateTime to) 퓏(
    [In] Period obj0,
    [In] Period? obj1,
    [In] DateTimeRangeType obj2,
    [In] DayOfWeek obj3,
    [In] Connection obj4)
  {
    DateTime dateTime1 = Core.Instance.TimeUtils.DateTimeUtcNow;
    if (obj4 != null)
      dateTime1 = obj4.ServerTime;
    DateTime dateTime2 = dateTime1;
    DateTime dateTime3 = dateTime1;
    switch (obj2)
    {
      case DateTimeRangeType.Slide:
        dateTime2 = dateTime1.AddTicks(-obj0.Ticks);
        break;
      case DateTimeRangeType.FixedStart:
        switch (obj0.BasePeriod)
        {
          case BasePeriod.Tick:
            dateTime2 = dateTime2.AddTicks((long) obj0.PeriodMultiplier);
            break;
          case BasePeriod.Second:
            double num1 = dateTime1.TimeOfDay.TotalSeconds % (double) obj0.PeriodMultiplier;
            dateTime2 = dateTime1.AddSeconds(-num1);
            dateTime3 = dateTime2.AddTicks(obj0.Ticks);
            break;
          case BasePeriod.Minute:
            DateTime dateTime4 = dateTime1.TrimSeconds();
            double num2 = dateTime4.TimeOfDay.TotalMinutes % (double) obj0.PeriodMultiplier;
            dateTime2 = dateTime4.AddMinutes(-num2);
            dateTime3 = dateTime2.AddTicks(obj0.Ticks);
            break;
          case BasePeriod.Hour:
            DateTime dateTime5 = dateTime1.TrimSeconds();
            double num3 = dateTime5.TimeOfDay.TotalHours % (double) obj0.PeriodMultiplier;
            dateTime2 = dateTime5.AddHours(-num3);
            dateTime3 = dateTime2.AddTicks(obj0.Ticks);
            break;
          case BasePeriod.Day:
            dateTime2 = dateTime1.TrimSeconds().Date.AddDays((double) -(obj0.PeriodMultiplier - 1));
            dateTime3 = dateTime2.AddDays((double) obj0.PeriodMultiplier);
            break;
          case BasePeriod.Week:
            DateTime dateTime6 = dateTime1.TrimSeconds();
            while (dateTime6.DayOfWeek != obj3)
              dateTime6 = dateTime6.AddDays(-1.0);
            dateTime2 = dateTime6.Date;
            dateTime3 = dateTime2.AddDays((double) (7 * obj0.PeriodMultiplier));
            break;
          case BasePeriod.Month:
            dateTime2 = new DateTime(dateTime1.Year, dateTime1.Month, 1, 0, 0, 0, DateTimeKind.Utc).AddMonths(-(obj0.PeriodMultiplier - 1));
            dateTime3 = dateTime2.AddMonths(obj0.PeriodMultiplier);
            break;
          case BasePeriod.Year:
            dateTime2 = new DateTime(dateTime1.Year, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddYears(-(obj0.PeriodMultiplier - 1));
            dateTime3 = dateTime2.AddYears(obj0.PeriodMultiplier);
            break;
        }
        break;
    }
    if (obj1.HasValue)
    {
      dateTime2 = dateTime2.AddTicks(-obj1.Value.Ticks);
      dateTime3 = dateTime3.AddTicks(-obj1.Value.Ticks);
    }
    return (dateTime2, dateTime3);
  }

  private bool 퓏([In] DateTime obj0, [In] DateTime obj1) => obj1.Ticks >= obj0.Ticks;

  public string ToShortDateString()
  {
    DateTime selectedTimeZone = this.From.ToSelectedTimeZone();
    string shortDateString1 = selectedTimeZone.ToShortDateString();
    string str = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓛();
    selectedTimeZone = this.To.ToSelectedTimeZone();
    string shortDateString2 = selectedTimeZone.ToShortDateString();
    return shortDateString1 + str + shortDateString2;
  }

  [NotPublished]
  public static bool operator ==(DateTimeRange dateTimeRange1, DateTimeRange dateTimeRange2)
  {
    return dateTimeRange1.Equals((object) dateTimeRange2);
  }

  [NotPublished]
  public static bool operator !=(DateTimeRange dateTimeRange1, DateTimeRange dateTimeRange2)
  {
    return !dateTimeRange1.Equals((object) dateTimeRange2);
  }

  public int CompareTo(object obj)
  {
    DateTimeRange dateTimeRange = obj as DateTimeRange;
    if ((object) dateTimeRange == null)
      return 0;
    int num1 = this.RangeType.CompareTo((object) dateTimeRange.RangeType);
    if (num1 != 0)
      return num1;
    if (this.RangeType == DateTimeRangeType.Custom)
    {
      int num2 = this.From.CompareTo(dateTimeRange.From);
      if (num2 != 0)
        return num2;
      int num3 = this.To.CompareTo(dateTimeRange.To);
      if (num3 != 0)
        return num3;
    }
    else
    {
      int num4 = this.Period.CompareTo((object) dateTimeRange.Period);
      if (num4 != 0)
        return num4;
    }
    return 0;
  }

  public override bool Equals(object obj)
  {
    DateTimeRange dateTimeRange = obj as DateTimeRange;
    if ((object) dateTimeRange == null)
      return false;
    bool flag1 = this.RangeType == dateTimeRange.RangeType;
    if (!flag1)
      return flag1;
    if (this.RangeType == DateTimeRangeType.Custom)
    {
      bool flag2 = this.From == dateTimeRange.From;
      if (!flag2)
        return flag2;
      bool flag3 = this.To == dateTimeRange.To;
      if (!flag3)
        return flag3;
    }
    else
    {
      bool flag4 = this.Period == dateTimeRange.Period;
      if (!flag4)
        return flag4;
      Period? endOffset1 = this.EndOffset;
      Period? endOffset2 = dateTimeRange.EndOffset;
      bool flag5 = endOffset1.HasValue == endOffset2.HasValue && (!endOffset1.HasValue || endOffset1.GetValueOrDefault() == endOffset2.GetValueOrDefault());
      if (!flag5)
        return flag5;
    }
    return true;
  }

  public override int GetHashCode()
  {
    int hashCode1 = this.RangeType.GetHashCode();
    int hashCode2;
    if (this.RangeType == DateTimeRangeType.Custom)
    {
      hashCode2 = hashCode1 ^ this.From.GetHashCode() ^ this.To.GetHashCode();
    }
    else
    {
      Period? endOffset = this.EndOffset;
      if (endOffset.HasValue)
      {
        int num1 = hashCode1;
        int hashCode3 = this.Period.GetHashCode();
        endOffset = this.EndOffset;
        int num2 = endOffset.GetHashCode() * 397;
        int num3 = hashCode3 ^ num2;
        hashCode2 = num1 ^ num3;
      }
      else
        hashCode2 = hashCode1 ^ this.Period.GetHashCode();
    }
    return hashCode2;
  }
}
