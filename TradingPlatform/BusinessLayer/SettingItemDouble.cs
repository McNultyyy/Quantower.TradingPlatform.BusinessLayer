// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemDouble
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

/// <summary>Typecasts setting as NumericUpDown item</summary>
[Published]
[DataContract]
[ProtoContract]
[Serializable]
public class SettingItemDouble : SettingItemNumber<double>
{
  private int 퓬퓷;

  public override SettingItemType Type => SettingItemType.Double;

  [Bindable("decimalPlaces")]
  public int DecimalPlaces
  {
    get => this.퓬퓷;
    set
    {
      this.SetValue<int>(ref this.퓬퓷, value, propertyName: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓭());
    }
  }

  public SettingItemDouble()
  {
  }

  public SettingItemDouble(string name, double value, int sortIndex = 0)
    : base(name, value, sortIndex)
  {
    this.Maximum = (double) int.MaxValue;
    this.Minimum = (double) int.MinValue;
    this.DecimalPlaces = 0;
    this.Increment = 1.0;
  }

  private protected SettingItemDouble([In] SettingItemDouble obj0)
    : base((SettingItemNumber<double>) obj0)
  {
    this.DecimalPlaces = obj0.DecimalPlaces;
  }

  [NotPublished]
  public override SettingItem GetCopy() => (SettingItem) new SettingItemDouble(this);

  [NotPublished]
  public static implicit operator double(SettingItemDouble item) => (double) item.Value;

  [NotPublished]
  protected override bool IsValueTypeValid(object value) => value is double;

  [NotPublished]
  protected override object ValidateValue(object value)
  {
    value = base.ValidateValue(value);
    double d = (double) value;
    if (double.IsNaN(d))
      d = 0.0;
    else if (d > this.Maximum)
      d = this.Maximum;
    else if (d < this.Minimum)
      d = this.Minimum;
    else if (this.Increment != 0.0)
      d -= (double) ((Decimal) d % (Decimal) this.Increment);
    return (object) d;
  }

  [DataMember(Name = "Value")]
  [ProtoMember(1)]
  private double ValueDouble
  {
    get => (double) this.value;
    [param: In] set => this.value = (object) value;
  }

  [NotPublished]
  protected override XElement ValueToXElement()
  {
    return new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓣(), (object) this.ValueDouble.ToString((IFormatProvider) CultureInfo.InvariantCulture));
  }

  [NotPublished]
  protected override void ValueFromXElement(
    XElement element,
    DeserializationInfo deserializationInfo)
  {
    XElement element1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓣());
    if (element1 == null)
      return;
    this.ValueDouble = element1.ToDouble();
  }

  public override bool Equals(SettingItem other)
  {
    return base.Equals(other) && other is SettingItemDouble settingItemDouble && this.DecimalPlaces == settingItemDouble.DecimalPlaces;
  }

  public override int GetHashCode()
  {
    HashCode hashCode = new HashCode();
    hashCode.Add<int>(base.GetHashCode());
    hashCode.Add<int>(this.DecimalPlaces);
    return hashCode.ToHashCode();
  }
}
