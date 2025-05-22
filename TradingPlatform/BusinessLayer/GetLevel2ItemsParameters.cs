// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.GetLevel2ItemsParameters
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>
/// Represent parameters of request for Leve2Item collection
/// </summary>
[Published]
public class GetLevel2ItemsParameters
{
  /// <summary>Aggregation method</summary>
  public AggregateMethod AggregateMethod { get; set; }

  public ImplicitOrderBookType ImplicitOrderBookType { get; set; }

  /// <summary>Required amount of level2</summary>
  public int LevelsCount { get; set; }

  /// <summary>Use custom tick size</summary>
  public double CustomTickSize { get; set; }

  /// <summary>Calculate cumulative size</summary>
  public bool CalculateCumulative { get; set; }

  public bool GetMBOItems { get; set; }

  public static bool operator ==(GetLevel2ItemsParameters p1, GetLevel2ItemsParameters p2)
  {
    if ((object) p1 != null && (object) p2 != null)
      return p1.Equals((object) p2);
    return (object) p1 == null && (object) p2 == null;
  }

  public static bool operator !=(GetLevel2ItemsParameters p1, GetLevel2ItemsParameters p2)
  {
    if ((object) p1 != null && (object) p2 != null)
      return !p1.Equals((object) p2);
    return (object) p1 != null || p2 != null;
  }

  public override bool Equals(object obj)
  {
    GetLevel2ItemsParameters level2ItemsParameters = obj as GetLevel2ItemsParameters;
    return (object) level2ItemsParameters != null && this.AggregateMethod == level2ItemsParameters.AggregateMethod && this.LevelsCount == level2ItemsParameters.LevelsCount && this.CustomTickSize == level2ItemsParameters.CustomTickSize && this.CalculateCumulative == level2ItemsParameters.CalculateCumulative && this.ImplicitOrderBookType == level2ItemsParameters.ImplicitOrderBookType && this.GetMBOItems == level2ItemsParameters.GetMBOItems;
  }

  public override int GetHashCode()
  {
    return (int) (this.AggregateMethod ^ (AggregateMethod) this.LevelsCount ^ (AggregateMethod) this.CustomTickSize.GetHashCode() ^ (AggregateMethod) this.CalculateCumulative.GetHashCode() ^ (AggregateMethod) this.ImplicitOrderBookType.GetHashCode() ^ (AggregateMethod) this.GetMBOItems.GetHashCode());
  }
}
