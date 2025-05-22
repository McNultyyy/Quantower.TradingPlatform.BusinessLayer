// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.IndicatorLineMarker
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Drawing;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>
/// Using IndicatorLineMarker class you can mark by color or icon any point of your indicator's line.
/// </summary>
public class IndicatorLineMarker
{
  /// <summary>Color of the marker</summary>
  public Color Color { get; set; } = Color.Empty;

  /// <summary>Icon that will be drawn above the indicator line</summary>
  public IndicatorLineMarkerIconType UpperIcon { get; set; }

  /// <summary>Icon that will be drawn beyond the indicator line</summary>
  public IndicatorLineMarkerIconType BottomIcon { get; set; }

  /// <summary>Constructor for IndicatorLineMarker</summary>
  /// <param name="color"></param>
  /// <param name="upperIcon"></param>
  /// <param name="bottomIcon"></param>
  public IndicatorLineMarker(
    Color color,
    IndicatorLineMarkerIconType upperIcon = IndicatorLineMarkerIconType.None,
    IndicatorLineMarkerIconType bottomIcon = IndicatorLineMarkerIconType.None)
  {
    this.Color = color;
    this.UpperIcon = upperIcon;
    this.BottomIcon = bottomIcon;
  }

  /// <summary>Constructor for IndicatorLineMarker</summary>
  public IndicatorLineMarker()
  {
  }
}
