// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemTimeFrameConfig
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public class SettingItemTimeFrameConfig : SettingItem
{
  public override SettingItemType Type => SettingItemType.TimeFrameConfig;

  public SettingItemTimeFrameConfig()
  {
  }

  public SettingItemTimeFrameConfig(string name, TimeFrameConfig value, int sortIndex = 0)
    : base(name, (object) value, sortIndex)
  {
  }

  private SettingItemTimeFrameConfig([In] SettingItemTimeFrameConfig obj0)
    : base((SettingItem) obj0)
  {
  }

  public override SettingItem GetCopy() => (SettingItem) new SettingItemTimeFrameConfig(this);

  protected override bool IsValueTypeValid(object value) => value is TimeFrameConfig;

  [DataMember(Name = "Value")]
  private string ValueString
  {
    get => this.Value as string;
    [param: In] set => this.Value = (object) value;
  }

  protected override void ValueFromXElement(
    XElement element,
    DeserializationInfo deserializationInfo)
  {
    TimeFrameConfig timeFrameConfig = new TimeFrameConfig();
    timeFrameConfig.FromXElement(element, deserializationInfo);
    this.Value = (object) timeFrameConfig;
  }
}
