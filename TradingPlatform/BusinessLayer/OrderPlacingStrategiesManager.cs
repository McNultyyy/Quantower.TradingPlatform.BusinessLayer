// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.OrderPlacingStrategiesManager
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Modules;
using TradingPlatform.BusinessLayer.Modules.PlaceOrderStrategies;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public sealed class OrderPlacingStrategiesManager : 
  ScriptManager<OrderPlacingStrategyInfo, OrderPlacingStrategy>
{
  private readonly List<OrderPlacingStrategy> 픽;

  public OrderPlacingStrategy[] Created => this.픽.ToArray();

  public event Action<OrderPlacingStrategy> StrategyCreated;

  public event Action<OrderPlacingStrategy> StrategyRemoved;

  public override string CustomScriptsPath => Const.CUSTOM_PLACE_ORDER_STRATEGIES_PATH;

  protected override string DefaultScriptsPath
  {
    get => Const.DEFAULT_PLACE_ORDER_STRATEGIES_RELATIVE_PATH;
  }

  public OrderPlacingStrategiesManager() => this.픽 = new List<OrderPlacingStrategy>();

  internal override void 퓏()
  {
    Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픉(), LoggingLevel.Verbose);
    try
    {
      base.퓏();
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
    Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픒(), LoggingLevel.Verbose);
  }

  protected override OrderPlacingStrategyInfo CreateScriptInfo(
    ConstructorInfo ctor,
    ScriptCreationType scriptCreationType,
    string relativePath,
    string assemblyName)
  {
    return new OrderPlacingStrategyInfo(ctor, scriptCreationType, relativePath, assemblyName);
  }

  protected override string GetScriptsFolderPath(ScriptCreationType scriptCreationType)
  {
    return scriptCreationType != ScriptCreationType.Default ? Const.CUSTOM_PLACE_ORDER_STRATEGIES_PATH : Path.Combine(Const.EXECUTING_FOLDER, Const.DEFAULT_PLACE_ORDER_STRATEGIES_RELATIVE_PATH);
  }

  public OrderPlacingStrategy CreateStrategy(OrderPlacingStrategyInfo orderPlacingStrategyInfo)
  {
    OrderPlacingStrategy strategy = orderPlacingStrategyInfo.퓏();
    this.픽.Add(strategy);
    // ISSUE: reference to a compiler-generated field
    Action<OrderPlacingStrategy> 퓬퓏 = this.퓬퓏;
    if (퓬퓏 != null)
      퓬퓏(strategy);
    return strategy;
  }

  internal void 퓏([In] OrderPlacingStrategy obj0)
  {
    if (!this.픽.Remove(obj0))
      return;
    obj0.Dispose();
    // ISSUE: reference to a compiler-generated field
    Action<OrderPlacingStrategy> 퓬퓬 = this.퓬퓬;
    if (퓬퓬 == null)
      return;
    퓬퓬(obj0);
  }
}
