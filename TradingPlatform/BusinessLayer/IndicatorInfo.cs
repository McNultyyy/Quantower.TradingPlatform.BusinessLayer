// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.IndicatorInfo
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public class IndicatorInfo : ScriptInfo
{
  public string Group { get; [param: In] private set; }

  public bool IsAvailableInWatchlist { get; [param: In] private set; }

  public string ShortName { get; [param: In] private set; }

  internal IndicatorInfo([In] ConstructorInfo obj0, [In] ScriptCreationType obj1, [In] string obj2, [In] string obj3)
    : base(obj0, obj1, obj2, obj3)
  {
  }

  protected override void Initialize(string relativePath, string assemblyName)
  {
    using (Indicator indicator = this.ctor.Invoke((object[]) null) as Indicator)
    {
      this.Name = indicator.Name;
      this.ShortName = this.퓏(indicator);
      this.Description = indicator.Description;
      this.Version = indicator.Version;
      this.Key = new ScriptKey(this.ScriptCreationType, relativePath, assemblyName, this.Name);
      indicator.Key = this.Key;
      this.Settings = indicator.Settings as List<SettingItem>;
      this.IsAvailableInWatchlist = indicator is IWatchlistIndicator;
    }
  }

  internal Indicator 퓏()
  {
    if (this.ctor?.Invoke((object[]) null) is Indicator indicator)
      indicator.Key = this.Key;
    return indicator;
  }

  public override string ToString() => this.Name;

  private string 퓏([In] Indicator obj0)
  {
    if (string.IsNullOrEmpty(obj0.ShortName))
      return string.Empty;
    int length = obj0.ShortName.IndexOf('(');
    return length == -1 ? obj0.ShortName : obj0.ShortName.Substring(0, length).TrimEnd();
  }
}
