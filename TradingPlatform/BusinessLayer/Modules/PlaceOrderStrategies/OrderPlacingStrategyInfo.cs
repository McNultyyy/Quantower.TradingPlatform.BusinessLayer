// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Modules.PlaceOrderStrategies.OrderPlacingStrategyInfo
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer.Modules.PlaceOrderStrategies;

public sealed class OrderPlacingStrategyInfo : ScriptInfo, IComparable
{
  public string ObsoleteText { get; [param: In] private set; }

  internal OrderPlacingStrategyInfo(
    [In] ConstructorInfo obj0,
    [In] ScriptCreationType obj1,
    [In] string obj2,
    [In] string obj3)
    : base(obj0, obj1, obj2, obj3)
  {
  }

  protected override void Initialize(string relativePath, string assemblyName)
  {
    using (OrderPlacingStrategy orderPlacingStrategy = this.ctor.Invoke((object[]) null) as OrderPlacingStrategy)
    {
      this.Name = orderPlacingStrategy.Name;
      this.Description = orderPlacingStrategy.Description;
      this.Version = orderPlacingStrategy.Version;
      this.Settings = orderPlacingStrategy.Settings as List<SettingItem>;
      this.Key = new ScriptKey(this.ScriptCreationType, relativePath, assemblyName, this.Name);
      if (!(((IEnumerable<object>) orderPlacingStrategy.GetType().GetCustomAttributes(typeof (ObsoleteAttribute), true)).FirstOrDefault<object>() is ObsoleteAttribute obsoleteAttribute))
        return;
      this.ObsoleteText = obsoleteAttribute.Message;
    }
  }

  internal OrderPlacingStrategy 퓏()
  {
    if (this.ctor?.Invoke((object[]) null) is OrderPlacingStrategy orderPlacingStrategy)
      orderPlacingStrategy.Key = this.Key;
    return orderPlacingStrategy;
  }

  public int CompareTo(object obj)
  {
    return !(obj is OrderPlacingStrategyInfo placingStrategyInfo) ? 0 : string.Compare(this.Key.ToString(), placingStrategyInfo.Key.ToString(), StringComparison.Ordinal);
  }
}
