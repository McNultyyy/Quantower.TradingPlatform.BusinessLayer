// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.StrategyManager
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public sealed class StrategyManager : ScriptManager<StrategyInfo, Strategy>
{
  private readonly List<Strategy> 퓬퓳;

  public Strategy[] Created => this.퓬퓳.ToArray();

  public event StrategyEventHandler StrategyStateChanged;

  public event Action<Strategy> StrategyCreated;

  public event Action<Strategy> StrategyRemoved;

  protected override string DefaultScriptsPath => Const.DEFAULT_STRATEGIES_RELATIVE_PATH;

  public override string CustomScriptsPath => Const.CUSTOM_STRATEGIES_PATH;

  public bool RestoreStateAfterShutdown { get; set; }

  internal StrategyManager()
  {
    this.퓬퓳 = new List<Strategy>();
    this.RestoreStateAfterShutdown = false;
  }

  internal override void 퓏()
  {
    Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓾(), LoggingLevel.Verbose);
    try
    {
      base.퓏();
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
    Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓐(), LoggingLevel.Verbose);
  }

  public Strategy CreateStrategy(
    string strategyName,
    string assemblyName = "",
    string relativePath = "",
    ScriptCreationType scriptCreationType = ScriptCreationType.Default)
  {
    if (string.IsNullOrEmpty(strategyName))
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픚());
    return this.CreateStrategy(this.SearchScriptKey(strategyName, assemblyName, relativePath, scriptCreationType));
  }

  public Strategy CreateStrategy(ScriptKey scriptKey)
  {
    StrategyInfo strategyInfo;
    return this.scriptsInfoCache.TryGetValue(scriptKey, out strategyInfo) ? this.CreateStrategy(strategyInfo) : (Strategy) null;
  }

  public Strategy CreateStrategy(StrategyInfo strategyInfo)
  {
    Strategy strategy = strategyInfo.퓏();
    this.퓏(strategy);
    return strategy;
  }

  private void 퓏([In] Strategy obj0)
  {
    obj0.퓏();
    this.퓬퓳.Add(obj0);
    // ISSUE: reference to a compiler-generated field
    Action<Strategy> 퓬픷 = this.퓬픷;
    if (퓬픷 == null)
      return;
    퓬픷(obj0);
  }

  public void DeleteStrategy(Strategy strategy)
  {
    if (strategy == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓵());
    this.퓬퓳.Remove(strategy);
    strategy.Remove();
    strategy.Dispose();
    // ISSUE: reference to a compiler-generated field
    Action<Strategy> 퓬퓻 = this.퓬퓻;
    if (퓬퓻 == null)
      return;
    퓬퓻(strategy);
  }

  public void OnSettingsLoaded()
  {
    if (!this.RestoreStateAfterShutdown)
      return;
    this.퓬();
  }

  public void SaveStrategies()
  {
    if (this.퓬퓳 == null)
      return;
    foreach (Strategy strategy in this.퓬퓳)
    {
      try
      {
        Serializer.SerializeXML(Path.Combine(strategy.DataFolderPath, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬플()), new List<IXElementSerialization>()
        {
          (IXElementSerialization) strategy
        });
      }
      catch (Exception ex)
      {
        Core.Instance.Loggers.Log(ex);
      }
    }
  }

  public void LoadStrategies()
  {
    if (!Directory.Exists(Const.SCRIPTS_DATA_PATH))
      return;
    foreach (string enumerateFile in Directory.EnumerateFiles(Const.SCRIPTS_DATA_PATH, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬플(), SearchOption.AllDirectories))
    {
      try
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        StrategyManager.퓏 퓏 = new StrategyManager.퓏();
        // ISSUE: reference to a compiler-generated field
        퓏.퓍퓒 = this;
        // ISSUE: reference to a compiler-generated field
        퓏.퓍픈 = Serializer.DeserializeXML(enumerateFile, out double _, new Func<XElement, IXElementSerialization>(this.퓏)).FirstOrDefault<IXElementSerialization>() as Strategy;
        // ISSUE: reference to a compiler-generated field
        if (퓏.퓍픈 != null)
        {
          // ISSUE: reference to a compiler-generated method
          Task.Run(new Action(퓏.퓏));
        }
      }
      catch (Exception ex)
      {
        Core.Instance.Loggers.Log(ex);
      }
    }
  }

  private void 퓬()
  {
    foreach (Strategy strategy in this.Created)
      strategy.퓬();
  }

  protected override string GetScriptsFolderPath(ScriptCreationType scriptCreationType)
  {
    return scriptCreationType != ScriptCreationType.Default ? Const.CUSTOM_STRATEGIES_PATH : Path.Combine(Const.EXECUTING_FOLDER, Const.DEFAULT_STRATEGIES_RELATIVE_PATH);
  }

  protected override StrategyInfo CreateScriptInfo(
    ConstructorInfo ctor,
    ScriptCreationType scriptCreationType,
    string relativePath,
    string assemblyName)
  {
    return new StrategyInfo(ctor, scriptCreationType, relativePath, assemblyName);
  }

  public override void Dispose()
  {
    if (this.퓬퓳 != null)
    {
      foreach (Strategy strategy in this.퓬퓳)
      {
        strategy.Stop();
        strategy.Dispose();
      }
      this.퓬퓳.Clear();
    }
    base.Dispose();
  }

  internal void 퓏([In] Strategy obj0, [In] StrategyState obj1, [In] StrategyState obj2)
  {
    // ISSUE: reference to a compiler-generated field
    StrategyEventHandler 퓬핆 = this.퓬핆;
    if (퓬핆 == null)
      return;
    퓬핆(obj0, new StrategyEventArgs(obj1)
    {
      StrategyPreviousState = obj2
    });
  }

  protected override void OnScriptUpdated(ScriptInfo scriptInfo)
  {
    foreach (Strategy strategy in this.Created)
    {
      if (!(strategy.Key != scriptInfo.Key))
        strategy.NewVersionAvailable = true;
    }
    base.OnScriptUpdated(scriptInfo);
  }

  private IXElementSerialization 퓏([In] XElement obj0)
  {
    if (obj0 == null)
      return (IXElementSerialization) null;
    string stringKey = obj0.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픥())?.Value;
    if (string.IsNullOrEmpty(stringKey))
      return SettingItem.DesserrializationFabric(obj0);
    StrategyInfo strategyInfo;
    return !this.scriptsInfoCache.TryGetValue(ScriptKey.CreateScriptKeyFromString(stringKey), out strategyInfo) ? (IXElementSerialization) null : (IXElementSerialization) strategyInfo.퓏();
  }
}
