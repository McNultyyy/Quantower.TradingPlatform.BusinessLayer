// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemSeparatorGroup
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>Typecasts setting as GroupBox item</summary>
[Published]
public sealed class SettingItemSeparatorGroup(string text = "", int sortIndex = 0) : 
  SettingItemVisualGroup(text, sortIndex)
{
  private string 픜퓓;

  public string Key
  {
    get => string.IsNullOrEmpty(this.픜퓓) ? this.Text : this.픜퓓;
    set => this.픜퓓 = value;
  }
}
