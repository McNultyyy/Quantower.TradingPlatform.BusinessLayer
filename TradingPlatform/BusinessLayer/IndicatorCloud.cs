// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.IndicatorCloud
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public class IndicatorCloud : IComparable<IndicatorCloud>
{
  private Color 픺;
  internal const int 퓫 = -1;

  public int FromIndex { get; set; }

  public int ToIndex { get; set; }

  public TradingPlatform.BusinessLayer.Utils.Interval<int> Interval
  {
    get => new TradingPlatform.BusinessLayer.Utils.Interval<int>(this.FromIndex, this.ToIndex);
  }

  public Color Color
  {
    get => this.픺;
    set
    {
      this.픺 = value;
      this.Brush = new SolidBrush(this.픺);
    }
  }

  public SolidBrush Brush { get; [param: In] private set; }

  public IndicatorCloud()
  {
    this.FromIndex = -1;
    this.ToIndex = -1;
  }

  public int CompareTo(IndicatorCloud other)
  {
    if (this == other)
      return 0;
    return other == null ? 1 : this.FromIndex.CompareTo(other.FromIndex);
  }

  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 3);
    interpolatedStringHandler.AppendFormatted<int>(this.FromIndex);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓛());
    interpolatedStringHandler.AppendFormatted<int>(this.ToIndex);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픝());
    interpolatedStringHandler.AppendFormatted(this.Color.Name);
    return interpolatedStringHandler.ToStringAndClear();
  }
}
