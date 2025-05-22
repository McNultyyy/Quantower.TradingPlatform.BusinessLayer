// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemMinotauroFibonacciLevelOptions
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Collections.Generic;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public class SettingItemMinotauroFibonacciLevelOptions : SettingItemFibonacciLevelOptions
{
  public override SettingItemType Type => SettingItemType.MinotauroFibonacciLevelOptions;

  protected override FibonacciLevelOptions CreateFibonaccilevel()
  {
    return (FibonacciLevelOptions) new MinotauroFibonacciLevelOptions();
  }

  private SettingItemMinotauroFibonacciLevelOptions([In] SettingItemFibonacciLevelOptions obj0)
    : base(obj0)
  {
  }

  public override SettingItem GetCopy()
  {
    return (SettingItem) new SettingItemMinotauroFibonacciLevelOptions((SettingItemFibonacciLevelOptions) this);
  }

  public SettingItemMinotauroFibonacciLevelOptions()
  {
  }

  public SettingItemMinotauroFibonacciLevelOptions(
    string name,
    List<FibonacciLevelOptions> value,
    int sortIndex = 0)
    : base(name, value, sortIndex)
  {
  }
}
