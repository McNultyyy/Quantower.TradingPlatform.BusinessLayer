// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemClusterColoringLevel
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
public class SettingItemClusterColoringLevel : SettingItem
{
  public int NumericPrecision { get; set; }

  public Decimal Increment { get; set; } = 1M;

  public Decimal Minimum { get; set; } = Decimal.MinValue;

  public Decimal Maximum { get; set; } = Decimal.MaxValue;

  public bool WithRightColor { get; set; } = true;

  public override SettingItemType Type => SettingItemType.ClusterColoringLevels;

  [DataMember(Name = "Value")]
  private ClusterCustomColoringLevel Level
  {
    get => this.Value as ClusterCustomColoringLevel;
    [param: In] set => this.Value = (object) value;
  }

  public SettingItemClusterColoringLevel()
  {
  }

  public SettingItemClusterColoringLevel(
    string name,
    ClusterCustomColoringLevel level,
    int sortIndex = 0)
    : base(name, (object) level, sortIndex)
  {
    this.NumericPrecision = 0;
  }

  public SettingItemClusterColoringLevel(SettingItemClusterColoringLevel settingItem)
    : base((SettingItem) settingItem)
  {
    this.NumericPrecision = settingItem.NumericPrecision;
    this.Increment = settingItem.Increment;
    this.Minimum = settingItem.Minimum;
    this.Maximum = settingItem.Maximum;
  }

  public override SettingItem GetCopy() => (SettingItem) new SettingItemClusterColoringLevel(this);

  protected override bool IsValueTypeValid(object value) => value is ClusterCustomColoringLevel;

  protected override XElement ValueToXElement() => this.Level.ToXElement();

  protected override void ValueFromXElement(
    XElement element,
    DeserializationInfo deserializationInfo)
  {
    ClusterCustomColoringLevel customColoringLevel = new ClusterCustomColoringLevel();
    customColoringLevel.FromXElement(element, deserializationInfo);
    this.Value = (object) customColoringLevel;
  }
}
