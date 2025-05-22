// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Settings.Condition.SettingItemCondition
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer.Settings.Condition;

[DataContract]
[Serializable]
public sealed class SettingItemCondition : SettingItem
{
  public override SettingItemType Type => SettingItemType.Condition;

  public List<ConditionOperandBase> AvailableOperands { get; set; }

  public SettingItemCondition()
  {
  }

  public SettingItemCondition(
    string name,
    object value,
    List<ConditionOperandBase> operands,
    int sortIndex = 0)
    : base(name, value, sortIndex)
  {
    this.AvailableOperands = operands;
  }

  private SettingItemCondition([In] SettingItemCondition obj0)
    : base((SettingItem) obj0)
  {
    this.AvailableOperands = new List<ConditionOperandBase>((IEnumerable<ConditionOperandBase>) obj0.AvailableOperands);
  }

  public override SettingItem GetCopy() => (SettingItem) new SettingItemCondition(this);

  protected override bool IsValueTypeValid(object value) => value is ConditionData;

  [DataMember(Name = "Value")]
  private ConditionData ValueConditionData
  {
    get => this.Value as ConditionData;
    [param: In] set => this.Value = (object) value;
  }

  protected override void ValueFromXElement(
    XElement element,
    DeserializationInfo deserializationInfo)
  {
    ConditionData conditionData = new ConditionData();
    conditionData.FromXElement(element, deserializationInfo);
    this.value = (object) conditionData;
  }
}
