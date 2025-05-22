// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.StrategyInfo
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public class StrategyInfo : ScriptInfo
{
  internal StrategyInfo([In] ConstructorInfo obj0, [In] ScriptCreationType obj1, [In] string obj2, [In] string obj3)
    : base(obj0, obj1, obj2, obj3)
  {
  }

  protected override void Initialize(string relativePath, string assemblyName)
  {
    using (Strategy strategy = this.ctor.Invoke((object[]) null) as Strategy)
    {
      this.Name = strategy.Name;
      this.Description = strategy.Description;
      this.Version = strategy.Version;
      this.Key = new ScriptKey(this.ScriptCreationType, relativePath, assemblyName, this.Name);
      strategy.Key = this.Key;
      this.Settings = strategy.Settings as List<SettingItem>;
    }
  }

  internal Strategy 퓏()
  {
    if (this.ctor?.Invoke((object[]) null) is Strategy strategy)
      strategy.Key = this.Key;
    return strategy;
  }

  public override string ToString() => this.Name;
}
