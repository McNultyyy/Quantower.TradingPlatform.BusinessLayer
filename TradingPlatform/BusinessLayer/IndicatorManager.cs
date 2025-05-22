// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.IndicatorManager
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public sealed class IndicatorManager : ScriptManager<IndicatorInfo, Indicator>
{
  public BuiltInIndicators BuiltIn { get; [param: In] private set; }

  protected override string DefaultScriptsPath => Const.DEFAULT_INDICATORS_RELATIVE_PATH;

  public override string CustomScriptsPath => Const.CUSTOM_INDICATORS_PATH;

  internal IndicatorManager() => this.BuiltIn = new BuiltInIndicators();

  internal override void 퓏()
  {
    Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픻(), LoggingLevel.Verbose);
    try
    {
      base.퓏();
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
    Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓤(), LoggingLevel.Verbose);
  }

  public Indicator CreateIndicator(
    string indicatorName,
    string assemblyName = "",
    string relativePath = "",
    ScriptCreationType scriptCreationType = ScriptCreationType.Custom)
  {
    if (string.IsNullOrEmpty(indicatorName))
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픮());
    return this.CreateIndicator(this.SearchScriptKey(indicatorName, assemblyName, relativePath, scriptCreationType));
  }

  public Indicator CreateIndicator(ScriptKey scriptKey)
  {
    IndicatorInfo indicatorInfo;
    return this.scriptsInfoCache.TryGetValue(scriptKey, out indicatorInfo) ? this.CreateIndicator(indicatorInfo) : (Indicator) null;
  }

  public Indicator CreateIndicator(IndicatorInfo indicatorInfo) => indicatorInfo.퓏();

  protected override string GetScriptsFolderPath(ScriptCreationType scriptCreationType)
  {
    return scriptCreationType != ScriptCreationType.Default ? Const.CUSTOM_INDICATORS_PATH : Path.Combine(Const.EXECUTING_FOLDER, Const.DEFAULT_INDICATORS_RELATIVE_PATH);
  }

  protected override IndicatorInfo CreateScriptInfo(
    ConstructorInfo ctor,
    ScriptCreationType scriptCreationType,
    string relativePath,
    string assemblyName)
  {
    return new IndicatorInfo(ctor, scriptCreationType, relativePath, assemblyName);
  }
}
