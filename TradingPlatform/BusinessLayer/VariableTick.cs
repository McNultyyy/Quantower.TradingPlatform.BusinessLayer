// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.VariableTick
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
using TradingPlatform.BusinessLayer.Serialization;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[DataContract(Name = "VariableTick", Namespace = "TradingPlatform")]
[ProtoContract]
public class VariableTick : IXElementSerialization
{
  [DataMember]
  [ProtoMember(1)]
  public double LeftBorder { get; [param: In] private set; }

  [DataMember]
  [ProtoMember(2)]
  public bool IncludeLeftBorder { get; [param: In] private set; }

  [DataMember]
  [ProtoMember(3)]
  public double TickSize { get; [param: In] private set; }

  [DataMember]
  [ProtoMember(4)]
  public double TickCost { get; [param: In] private set; }

  [DataMember]
  [ProtoMember(5)]
  public double RightBorder { get; [param: In] private set; }

  [DataMember]
  [ProtoMember(6)]
  public int Precision { get; [param: In] private set; }

  /// <summary>проверка на вхождение</summary>
  public bool CheckPrice(double price)
  {
    if (price > this.LeftBorder && price < this.RightBorder || price == this.LeftBorder && this.IncludeLeftBorder)
      return true;
    return price == this.RightBorder && !this.IncludeLeftBorder;
  }

  public VariableTick(
    double lowLimit,
    double highLimit,
    bool allowLimit,
    double tickSize,
    double tickCost,
    int? precision = null)
  {
    this.LeftBorder = lowLimit;
    this.RightBorder = highLimit;
    this.IncludeLeftBorder = allowLimit;
    this.TickSize = (double) (Decimal) tickSize;
    this.TickCost = tickCost;
    this.Precision = !precision.HasValue ? CoreMath.GetValuePrecision((Decimal) this.TickSize) : precision.Value;
  }

  public VariableTick(double tickSize, double tickCost = 1.0, int? precision = null)
    : this(double.NegativeInfinity, double.PositiveInfinity, true, tickSize, tickCost, precision)
  {
  }

  internal VariableTick()
  {
  }

  public override string ToString()
  {
    return this.LeftBorder.ToString() + (!this.IncludeLeftBorder || this.LeftBorder == double.NegativeInfinity ? \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍핊() : \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픛()) + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓖() + (this.IncludeLeftBorder || this.RightBorder == double.PositiveInfinity ? \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍핊() : \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픛()) + this.RightBorder.ToString();
  }

  public XElement ToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓜());
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픺(), (object) this.LeftBorder.ToString((IFormatProvider) CultureInfo.InvariantCulture)));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍핃(), (object) this.RightBorder.ToString((IFormatProvider) CultureInfo.InvariantCulture)));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓫(), (object) this.IncludeLeftBorder));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍핌(), (object) this.TickSize));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓩(), (object) this.TickCost));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓨(), (object) this.Precision));
    return xelement;
  }

  public void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    XElement element1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픺());
    if (element1 != null)
      this.LeftBorder = element1.ToDouble();
    XElement element2 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍핃());
    if (element2 != null)
      this.RightBorder = element2.ToDouble();
    XElement element3 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓫());
    if (element3 != null)
      this.IncludeLeftBorder = element3.ToBool();
    XElement element4 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍핌());
    if (element4 != null)
      this.TickSize = element4.ToDouble();
    XElement element5 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓩());
    if (element5 != null)
      this.TickCost = element5.ToDouble();
    XElement element6 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓨());
    if (element6 == null)
      return;
    this.Precision = element6.ToInt();
  }
}
