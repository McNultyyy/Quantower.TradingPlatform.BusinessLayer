// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemRangeSelector
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using ProtoBuf;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public class SettingItemRangeSelector : SettingItem
{
  public override SettingItemType Type => SettingItemType.RangeSelector;

  public SettingItemRangeSelector()
  {
  }

  public SettingItemRangeSelector(string name, DateTimeRange value, int sortIndex = 0)
    : base(name, (object) value, sortIndex)
  {
  }

  private SettingItemRangeSelector([In] SettingItemRangeSelector obj0)
    : base((SettingItem) obj0)
  {
  }

  public override SettingItem GetCopy() => (SettingItem) new SettingItemRangeSelector(this);

  [DataMember(Name = "Value")]
  [ProtoMember(29)]
  private DateTimeRange ValueSelector
  {
    get => (DateTimeRange) this.value;
    [param: In] set => this.value = (object) value;
  }

  protected override bool IsValueTypeValid(object value) => this.Value is DateTimeRange;

  protected override void ValueFromXElement(
    XElement element,
    DeserializationInfo deserializationInfo)
  {
    base.ValueFromXElement(element, deserializationInfo);
    DateTimeRange dateTimeRange = new DateTimeRange();
    dateTimeRange.FromXElement(element, deserializationInfo);
    this.ValueSelector = dateTimeRange;
  }
}
