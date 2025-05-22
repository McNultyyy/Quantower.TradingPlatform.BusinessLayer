// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.StrategyMetricExtensions
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Collections.Generic;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public static class StrategyMetricExtensions
{
  public static void Add(this List<StrategyMetric> metrics, string name, string formattedValue)
  {
    metrics.Add(new StrategyMetric()
    {
      Name = name,
      FormattedValue = formattedValue
    });
  }

  public static void Add(this List<StrategyMetric> metrics, string name, object value)
  {
    StrategyMetricExtensions.Add(metrics, name, value.ToString());
  }
}
