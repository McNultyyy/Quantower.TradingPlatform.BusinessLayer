// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemAlert
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[DataContract]
[Serializable]
public class SettingItemAlert : SettingItem
{
  public override SettingItemType Type => SettingItemType.ConditionSet;

  public SettingItemAlert()
  {
  }

  public SettingItemAlert(string name, object value, int sortIndex = 0)
    : base(name, value, sortIndex)
  {
  }

  private SettingItemAlert([In] SettingItemAlert obj0)
    : base((SettingItem) obj0)
  {
  }

  public override SettingItem GetCopy() => (SettingItem) new SettingItemAlert(this);

  protected override bool IsValueTypeValid(object value) => value is AlertData;

  [DataMember(Name = "Value")]
  private AlertData ValueAlert
  {
    get => this.Value as AlertData;
    [param: In] set => this.Value = (object) value;
  }

  protected override void ValueFromXElement(
    XElement element,
    DeserializationInfo deserializationInfo)
  {
    AlertData alertData = new AlertData();
    alertData.FromXElement(element, deserializationInfo);
    this.value = (object) alertData;
  }
}
