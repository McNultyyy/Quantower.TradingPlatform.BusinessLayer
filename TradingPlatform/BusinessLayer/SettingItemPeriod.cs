// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemPeriod
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>Typecasts setting as Period item</summary>
[Published]
[DataContract]
[ProtoContract]
[Serializable]
public sealed class SettingItemPeriod : SettingItem
{
  public override SettingItemType Type => SettingItemType.Period;

  public int MultiplierMinimum { get; set; }

  public int MultiplierMaximum { get; set; }

  public BasePeriod[] ExcludedPeriods { get; set; }

  public SettingItemPeriod()
  {
  }

  public SettingItemPeriod(string name, Period value, int sortIndex = 0)
    : base(name, (object) value, sortIndex)
  {
    this.MultiplierMinimum = 1;
    this.MultiplierMaximum = int.MaxValue;
  }

  private SettingItemPeriod([In] SettingItemPeriod obj0)
    : base((SettingItem) obj0)
  {
    this.MultiplierMinimum = obj0.MultiplierMinimum;
    this.MultiplierMaximum = obj0.MultiplierMaximum;
    this.ExcludedPeriods = obj0.ExcludedPeriods;
  }

  [NotPublished]
  public override SettingItem GetCopy() => (SettingItem) new SettingItemPeriod(this);

  [NotPublished]
  public static implicit operator Period(SettingItemPeriod item) => (Period) item.Value;

  [NotPublished]
  protected override bool IsValueTypeValid(object value) => value is Period;

  [NotPublished]
  protected override object ValidateValue(object value)
  {
    Period period = (Period) value;
    if (period.PeriodMultiplier < this.MultiplierMinimum)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 3);
      interpolatedStringHandler.AppendFormatted(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픉());
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픒());
      interpolatedStringHandler.AppendFormatted(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓷());
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇());
      interpolatedStringHandler.AppendFormatted<int>(this.MultiplierMinimum);
      throw new ArgumentException(interpolatedStringHandler.ToStringAndClear());
    }
    if (period.PeriodMultiplier > this.MultiplierMaximum)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 3);
      interpolatedStringHandler.AppendFormatted(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픉());
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓿());
      interpolatedStringHandler.AppendFormatted(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픟());
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇());
      interpolatedStringHandler.AppendFormatted<int>(this.MultiplierMaximum);
      throw new ArgumentException(interpolatedStringHandler.ToStringAndClear());
    }
    BasePeriod[] excludedPeriods = this.ExcludedPeriods;
    if ((excludedPeriods != null ? (((IEnumerable<BasePeriod>) excludedPeriods).Contains<BasePeriod>(period.BasePeriod) ? 1 : 0) : 0) != 0)
      throw new ArgumentException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓧());
    return value;
  }

  [NotPublished]
  protected override XElement ValueToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓾());
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓣(), (object) ((IXElementSerialization) this.Value).ToXElement()));
    return xelement;
  }

  [NotPublished]
  protected override void ValueFromXElement(
    XElement element,
    DeserializationInfo deserializationInfo)
  {
    XElement xelement1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓾());
    if (xelement1 == null)
      return;
    XElement xelement2 = xelement1.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓣());
    if (xelement2 == null)
      return;
    Period period = new Period();
    period.FromXElement(xelement2.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓾()), deserializationInfo);
    this.value = (object) period;
  }

  [DataMember(Name = "Value")]
  [ProtoMember(1)]
  private Period ValuePeriod
  {
    get => this.value != null ? (Period) this.value : new Period();
    [param: In] set => this.value = (object) value;
  }
}
