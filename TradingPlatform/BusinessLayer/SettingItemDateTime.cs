// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemDateTime
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using ProtoBuf;
using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.DataBinding;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>Typecasts setting as DateTimePicker item</summary>
[DataContract]
[Serializable]
public sealed class SettingItemDateTime : SettingItem
{
  private const string 퓞핂 = "ddMMyyyy HH:mm:ss.ffffff";
  private DatePickerFormat 퓞픾;

  public override SettingItemType Type => SettingItemType.DateTime;

  public bool ApplyOnEachInput { get; set; }

  [Bindable("format")]
  public DatePickerFormat Format
  {
    get => this.퓞픾;
    set
    {
      this.SetValue<DatePickerFormat>(ref this.퓞픾, value, propertyName: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓡());
    }
  }

  public DateTime MinDate { get; set; }

  public DateTime MaxDate { get; set; }

  public SettingItemDateTime()
  {
  }

  public SettingItemDateTime(string name, DateTime value = default (DateTime), int sortIndex = 0)
    : base(name, (object) value, sortIndex)
  {
    this.Format = DatePickerFormat.DateTime;
    this.ApplyOnEachInput = false;
    this.MinDate = DateTime.MinValue;
    this.MaxDate = DateTime.MaxValue;
  }

  private SettingItemDateTime([In] SettingItemDateTime obj0)
    : base((SettingItem) obj0)
  {
    this.Format = obj0.Format;
    this.ApplyOnEachInput = obj0.ApplyOnEachInput;
    this.MinDate = obj0.MinDate;
    this.MaxDate = obj0.MaxDate;
  }

  public override SettingItem GetCopy() => (SettingItem) new SettingItemDateTime(this);

  public static implicit operator DateTime(SettingItemDateTime item) => (DateTime) item.Value;

  protected override bool IsValueTypeValid(object value) => value is DateTime;

  protected override XElement ValueToXElement()
  {
    return new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓣(), (object) this.ValueDateTime.ToString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓢(), (IFormatProvider) CultureInfo.InvariantCulture));
  }

  [DataMember(Name = "Value")]
  [ProtoMember(1)]
  private DateTime ValueDateTime
  {
    get => (DateTime) this.Value;
    [param: In] set => this.Value = (object) value;
  }

  protected override void ValueFromXElement(
    XElement element,
    DeserializationInfo deserializationInfo)
  {
    XElement element1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓣());
    if (element1 == null)
      return;
    if (deserializationInfo.Version < 1.3)
    {
      XElement xelement = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓓());
      if (xelement != null && xelement.Value == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픗())
        this.ValueDateTime = element1.ToDateTime(true);
      else
        this.ValueDateTime = element1.ToDateTime();
    }
    else
      this.ValueDateTime = element1.ToDateTime(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓢());
  }
}
