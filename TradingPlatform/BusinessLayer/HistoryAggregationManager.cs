// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.HistoryAggregationManager
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

#nullable disable
namespace TradingPlatform.BusinessLayer;

public sealed class HistoryAggregationManager
{
  private const string 픓 = "HistoryProcessors";
  private Dictionary<string, HistoryAggregation> 픩;

  public HistoryAggregation[] All => this.픩.Values.ToArray<HistoryAggregation>();

  public HistoryAggregation this[string aggregatorName]
  {
    get
    {
      HistoryAggregation historyAggregation;
      return this.픩.TryGetValue(aggregatorName, out historyAggregation) ? historyAggregation : (HistoryAggregation) null;
    }
  }

  internal HistoryAggregationManager() => this.픩 = new Dictionary<string, HistoryAggregation>();

  internal void 퓏()
  {
    Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픷(), LoggingLevel.Verbose);
    List<TypeWrapper> typeWrapperList = AssemblyLoader.LoadTypes(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓻(), typeof (IHistoryProcessor), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픸(), SearchOption.AllDirectories);
    if (typeWrapperList == null)
      return;
    foreach (TypeWrapper typeWrapper in typeWrapperList)
    {
      Type type = (Type) typeWrapper;
      try
      {
        MethodInfo method = type.GetMethod(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.프(), BindingFlags.Static | BindingFlags.Public);
        if (method == (MethodInfo) null)
          Core.Instance.Loggers.Log(type.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픴(), LoggingLevel.Verbose);
        else if (!(method.Invoke((object) null, (object[]) null) is HistoryAggregation historyAggregation))
          Core.Instance.Loggers.Log(type.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픑(), LoggingLevel.Verbose);
        else if (this.픩.ContainsKey(historyAggregation.Name))
        {
          Core.Instance.Loggers.Log(type.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픿(), LoggingLevel.Verbose);
        }
        else
        {
          historyAggregation.HistoryProcessorType = type;
          this.픩.Add(historyAggregation.Name, historyAggregation);
        }
      }
      catch (Exception ex)
      {
        Core.Instance.Loggers.Log(ex);
      }
    }
    Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓔(), LoggingLevel.Verbose);
  }

  public IHistoryProcessor CreateHistoryProcessor(HistoryRequestParameters parameter)
  {
    if (parameter == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픢());
    if (parameter.Aggregation == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓝());
    HistoryAggregation historyAggregation = this[parameter.Aggregation.Name];
    if (historyAggregation == null)
      throw new ArgumentException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓶() + parameter.Aggregation.Name);
    try
    {
      if (Activator.CreateInstance(historyAggregation.HistoryProcessorType) is IHistoryProcessor instance)
        instance.Initialize(parameter.Copy);
      return instance;
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
    return (IHistoryProcessor) null;
  }

  internal void 퓬()
  {
    if (this.픩 == null)
      return;
    this.픩.Clear();
    this.픩 = (Dictionary<string, HistoryAggregation>) null;
  }
}
