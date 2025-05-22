// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemLabel
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public class SettingItemLabel : SettingItem
{
  public override SettingItemType Type => SettingItemType.Label;

  public SettingItemLabel()
  {
  }

  public SettingItemLabel(string name, string value = null, int sortIndex = 0)
    : base(name, (object) (value ?? string.Empty), sortIndex)
  {
  }

  private SettingItemLabel([In] SettingItemLabel obj0)
    : base((SettingItem) obj0)
  {
  }

  public override SettingItem GetCopy() => (SettingItem) new SettingItemLabel(this);

  protected override bool IsValueTypeValid(object value) => value is string;

  [DataMember(Name = "Value")]
  private string ValueString
  {
    get => this.Value as string;
    [param: In] set => this.Value = (object) value;
  }
}
