// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemTimeZone
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using ProtoBuf;
using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[DataContract]
[ProtoContract]
[Serializable]
public sealed class SettingItemTimeZone : SettingItem
{
  [DataMember(Name = "Type")]
  [ProtoMember(1)]
  private TimeZoneType 퓞퓽;
  [DataMember(Name = "InfoId")]
  [ProtoMember(2)]
  private string 퓞픘;
  [DataMember(Name = "BaseUtcOffset")]
  [ProtoMember(3)]
  private TimeSpan 퓞픨;
  [DataMember(Name = "DisplayName")]
  [ProtoMember(4)]
  private string 퓞퓪;
  [DataMember(Name = "StandardDisplayName")]
  [ProtoMember(5)]
  private string 퓞픪;

  public override SettingItemType Type => SettingItemType.TimeZone;

  public bool IsFavorite { get; set; }

  public SettingItemTimeZone()
  {
  }

  public SettingItemTimeZone(string name, TimeZone value, int sortIndex = 0)
    : base(name, (object) value, sortIndex)
  {
    this.퓞퓽 = value.Type;
    this.퓞픘 = value.TimeZoneInfo.Id;
    this.퓞픨 = value.TimeZoneInfo.BaseUtcOffset;
    this.퓞퓪 = value.TimeZoneInfo.DisplayName;
    this.퓞픪 = value.TimeZoneInfo.StandardName;
  }

  private SettingItemTimeZone([In] SettingItemTimeZone obj0)
    : base((SettingItem) obj0)
  {
    this.퓞퓽 = obj0.퓞퓽;
    this.퓞픘 = obj0.퓞픘;
    this.퓞픨 = obj0.퓞픨;
    this.퓞퓪 = obj0.퓞퓪;
    this.퓞픪 = obj0.퓞픪;
  }

  public override SettingItem GetCopy() => (SettingItem) new SettingItemTimeZone(this);

  public static implicit operator TimeZone(SettingItemTimeZone item) => (TimeZone) item.Value;

  public override object Value
  {
    get
    {
      return this.퓞퓽 == TimeZoneType.Local ? (object) new TimeZone(this.퓞퓽) : (object) new TimeZone(this.퓞퓽, TimeZoneInfo.FindSystemTimeZoneById(this.퓞픘) ?? TimeZoneInfo.CreateCustomTimeZone(this.퓞픘, this.퓞픨, this.퓞퓪, this.퓞픪));
    }
    set => base.Value = value;
  }

  protected override bool IsValueTypeValid(object value) => value is TimeZone;

  protected override XElement ValueToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픙());
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓼(), (object) (int) this.퓞퓽));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓭(), (object) this.퓞픘));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓣(), (object) this.퓞픨));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픦(), (object) this.퓞퓪));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픍(), (object) this.퓞픪));
    return xelement;
  }

  protected override void ValueFromXElement(
    XElement element,
    DeserializationInfo deserializationInfo)
  {
    XElement xelement = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픙());
    if (xelement == null)
      return;
    this.퓞퓽 = (TimeZoneType) xelement.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓼()).ToInt();
    this.퓞픘 = xelement.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓭()).Value;
    this.퓞픨 = xelement.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓣()).ToTimeSpan();
    this.퓞퓪 = xelement.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픦()).Value;
    this.퓞픪 = xelement.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픍()).Value;
  }
}
