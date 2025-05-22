// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SlTpHolder
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[ProtoContract]
public sealed class SlTpHolder : 
  ICloneable,
  IXElementSerialization,
  IEquatable<SlTpHolder>,
  ICustomizable
{
  [ProtoMember(1)]
  public CloseOrderType Type { get; [param: In] private set; }

  [ProtoMember(2)]
  public double Price { get; [param: In] private set; }

  [ProtoMember(3)]
  public double Quantity { get; set; }

  [ProtoMember(4)]
  public PriceMeasurement PriceMeasurement { get; [param: In] private set; }

  [ProtoMember(5)]
  public bool IsTrailing { get; [param: In] private set; }

  [ProtoMember(6)]
  public double QuantityPercentage { get; set; }

  [NotPublished]
  public SlTpHolder(IList<SettingItem> settings) => this.Settings = settings;

  internal SlTpHolder()
  {
  }

  public static SlTpHolder CreateSL(
    double price,
    PriceMeasurement priceMeasurement = PriceMeasurement.Absolute,
    bool isTrailing = false,
    double quantity = double.NaN,
    double quantityPercentage = double.NaN)
  {
    return new SlTpHolder()
    {
      Type = CloseOrderType.StopLoss,
      Price = price,
      Quantity = quantity,
      PriceMeasurement = priceMeasurement,
      IsTrailing = isTrailing,
      QuantityPercentage = quantityPercentage
    };
  }

  public static SlTpHolder CreateTP(
    double price,
    PriceMeasurement priceMeasurement = PriceMeasurement.Absolute,
    double quantity = double.NaN,
    double quantityPercentage = double.NaN)
  {
    return new SlTpHolder()
    {
      Type = CloseOrderType.TakeProfit,
      Price = price,
      Quantity = quantity,
      PriceMeasurement = priceMeasurement,
      IsTrailing = false,
      QuantityPercentage = quantityPercentage
    };
  }

  public string Format(Symbol symbol)
  {
    return symbol == null ? this.Price.ToString() : (this.PriceMeasurement != PriceMeasurement.Absolute ? symbol.FormatOffset(this.Price, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픹()) : symbol.FormatPrice(this.Price));
  }

  public object Clone()
  {
    return this.Type == CloseOrderType.StopLoss ? (object) SlTpHolder.CreateSL(this.Price, this.PriceMeasurement, this.IsTrailing, this.Quantity, this.QuantityPercentage) : (object) SlTpHolder.CreateTP(this.Price, this.PriceMeasurement, this.Quantity, this.QuantityPercentage);
  }

  public IList<SettingItem> Settings
  {
    get
    {
      return (IList<SettingItem>) new List<SettingItem>()
      {
        (SettingItem) new SettingItemSelectorLocalized(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픓(), (IComparable) this.Type, new List<SelectItem>()
        {
          new SelectItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픩(), 0),
          new SelectItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍필(), 1)
        }),
        (SettingItem) new SettingItemDouble(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓖(), this.Price),
        (SettingItem) new SettingItemDouble(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픵(), this.Quantity),
        (SettingItem) new SettingItemSelectorLocalized(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픬(), (IComparable) this.PriceMeasurement, new List<SelectItem>()
        {
          new SelectItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓕(), 0),
          new SelectItem(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픐(), 1)
        }),
        (SettingItem) new SettingItemBoolean(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픭(), this.IsTrailing),
        (SettingItem) new SettingItemDouble(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픔(), this.QuantityPercentage)
      };
    }
    set
    {
      this.Type = (CloseOrderType) value.GetValueOrDefault<int>((int) this.Type, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픓());
      this.Price = value.GetValueOrDefault<double>(this.Price, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓖());
      this.Quantity = value.GetValueOrDefault<double>(this.Quantity, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픵());
      this.PriceMeasurement = (PriceMeasurement) value.GetValueOrDefault<int>((int) this.PriceMeasurement, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픬());
      this.IsTrailing = value.GetValueOrDefault<bool>((this.IsTrailing ? 1 : 0) != 0, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픭());
      this.QuantityPercentage = value.GetValueOrDefault<double>(this.QuantityPercentage, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픔());
    }
  }

  public XElement ToXElement()
  {
    XElement xelement = new XElement((XName) this.GetType().Name);
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓼(), (object) ((int) this.Type).ToString()));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍핈(), (object) this.Price));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓢(), (object) this.Quantity));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픤(), (object) ((int) this.PriceMeasurement).ToString()));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓟(), (object) this.IsTrailing));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍핉(), (object) this.QuantityPercentage));
    return xelement;
  }

  public void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    XElement element1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓼());
    if (element1 != null)
      this.Type = (CloseOrderType) element1.ToInt();
    XElement element2 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍핈());
    if (element2 != null)
      this.Price = element2.ToDouble();
    XElement element3 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픤());
    if (element3 != null)
      this.PriceMeasurement = (PriceMeasurement) element3.ToInt();
    XElement element4 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓟());
    if (element4 != null)
      this.IsTrailing = element4.ToBool();
    XElement element5 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓢());
    if (element5 != null)
      this.Quantity = element5.ToDouble();
    XElement element6 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍핉());
    if (element6 != null)
      this.QuantityPercentage = element6.ToDouble();
    if (this.Quantity != 0.0)
      return;
    this.Quantity = double.NaN;
  }

  public bool Equals(SlTpHolder other)
  {
    if (other == null)
      return false;
    if (this == other)
      return true;
    if (this.Type == other.Type)
    {
      double num = this.Price;
      if (num.Equals(other.Price))
      {
        num = this.Quantity;
        if (num.Equals(other.Quantity))
        {
          num = this.QuantityPercentage;
          if (num.Equals(other.QuantityPercentage) && this.PriceMeasurement == other.PriceMeasurement)
            return this.IsTrailing == other.IsTrailing;
        }
      }
    }
    return false;
  }

  public override bool Equals(object obj)
  {
    if (obj == null)
      return false;
    if (this == obj)
      return true;
    return !(obj.GetType() != this.GetType()) && this.Equals((SlTpHolder) obj);
  }

  public override int GetHashCode()
  {
    return (int) ((PriceMeasurement) (((((int) this.Type * 397 ^ this.Price.GetHashCode()) * 397 ^ this.Quantity.GetHashCode()) * 397 ^ this.QuantityPercentage.GetHashCode()) * 397) ^ this.PriceMeasurement) * 397 ^ this.IsTrailing.GetHashCode();
  }

  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 4);
    interpolatedStringHandler.AppendFormatted<CloseOrderType>(this.Type);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲핃());
    interpolatedStringHandler.AppendFormatted<PriceMeasurement>(this.PriceMeasurement);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲핃());
    interpolatedStringHandler.AppendFormatted<double>(this.Price);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲핃());
    ref DefaultInterpolatedStringHandler local = ref interpolatedStringHandler;
    string str;
    if (!double.IsNaN(this.QuantityPercentage))
      str = $"{this.QuantityPercentage}";
    else
      str = $"{this.Quantity}";
    local.AppendFormatted(str);
    return interpolatedStringHandler.ToStringAndClear();
  }
}
