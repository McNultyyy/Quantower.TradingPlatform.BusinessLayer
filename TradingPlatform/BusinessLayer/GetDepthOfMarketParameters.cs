// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.GetDepthOfMarketParameters
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>Represent parameters of DepthOfMarket</summary>
[Published]
public class GetDepthOfMarketParameters
{
  public GetLevel2ItemsParameters GetLevel2ItemsParameters { get; set; }

  public bool CalculateImbalancePercent { get; set; }

  public GetDepthOfMarketParameters()
  {
    this.GetLevel2ItemsParameters = new GetLevel2ItemsParameters();
  }

  public static bool operator ==(GetDepthOfMarketParameters p1, GetDepthOfMarketParameters p2)
  {
    if ((object) p1 != null && (object) p2 != null)
      return p1.Equals((object) p2);
    return (object) p1 == null && (object) p2 == null;
  }

  public static bool operator !=(GetDepthOfMarketParameters p1, GetDepthOfMarketParameters p2)
  {
    if ((object) p1 != null && (object) p2 != null)
      return !p1.Equals((object) p2);
    return (object) p1 != null || p2 != null;
  }

  public override bool Equals(object obj)
  {
    GetDepthOfMarketParameters marketParameters = obj as GetDepthOfMarketParameters;
    return (object) marketParameters != null && !(this.GetLevel2ItemsParameters != marketParameters.GetLevel2ItemsParameters) && this.CalculateImbalancePercent == marketParameters.CalculateImbalancePercent;
  }

  public override int GetHashCode()
  {
    return this.GetLevel2ItemsParameters.GetHashCode() ^ this.CalculateImbalancePercent.GetHashCode();
  }
}
