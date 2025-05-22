// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemOrderRequestParameters
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[DataContract]
[Serializable]
public class SettingItemOrderRequestParameters : SettingItem
{
  public override SettingItemType Type => SettingItemType.OrderRequestParameters;

  public SettingItemOrderRequestParameters()
  {
  }

  public SettingItemOrderRequestParameters(
    string name,
    OrderRequestParameters value,
    int sortIndex = 0)
    : base(name, (object) value, sortIndex)
  {
  }

  private SettingItemOrderRequestParameters([In] SettingItemOrderRequestParameters obj0)
    : base((SettingItem) obj0)
  {
  }

  public override SettingItem GetCopy()
  {
    return (SettingItem) new SettingItemOrderRequestParameters(this);
  }

  protected override bool IsValueTypeValid(object value) => value is OrderRequestParameters;

  [DataMember(Name = "Value")]
  private OrderRequestParameters ValueInfo
  {
    get => this.Value as OrderRequestParameters;
    [param: In] set => this.Value = (object) value;
  }

  protected override XElement ValueToXElement() => this.ValueInfo.ToXElement();

  protected override void ValueFromXElement(
    XElement element,
    DeserializationInfo deserializationInfo)
  {
    PlaceOrderRequestParameters requestParameters = new PlaceOrderRequestParameters();
    requestParameters.FromXElement(element, deserializationInfo);
    this.value = (object) requestParameters;
  }
}
