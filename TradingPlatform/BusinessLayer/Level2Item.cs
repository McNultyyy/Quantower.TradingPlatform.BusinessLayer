// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Level2Item
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>Represent access to level2 item.</summary>
[Published]
public class Level2Item
{
  public string Id { get; [param: In] internal set; }

  /// <summary>Cumulative size</summary>
  public double Cumulative { get; [param: In] internal set; }

  /// <summary>Imbalance Percent</summary>
  public double ImbalancePercent { get; [param: In] internal set; }

  /// <summary>Price</summary>
  public double Price { get; [param: In] private set; }

  /// <summary>Size</summary>
  public double Size { get; [param: In] private set; }

  /// <summary>Time</summary>
  public DateTime QuoteTime { get; [param: In] private set; }

  /// <summary>MMID</summary>
  public string MMID { get; [param: In] private set; }

  public long Priority { get; [param: In] private set; }

  public Level2Item[] DetailedLevels { get; set; }

  private Level2Item()
  {
    this.Cumulative = double.NaN;
    this.ImbalancePercent = double.NaN;
  }

  internal Level2Item([In] double obj0, [In] double obj1, [In] DateTime obj2, [In] string obj3, [In] long obj4)
    : this()
  {
    this.Price = obj0;
    this.Size = obj1;
    this.QuoteTime = obj2;
    this.MMID = obj3;
    this.Priority = obj4;
  }

  internal Level2Item(
    [In] double obj0,
    [In] double obj1,
    [In] DateTime obj2,
    [In] string obj3,
    [In] long obj4,
    [In] Level2Item[] obj5)
    : this(obj0, obj1, obj2, obj3, obj4)
  {
    this.DetailedLevels = obj5;
  }

  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 2);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픏());
    interpolatedStringHandler.AppendFormatted<double>(this.Price);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓳());
    interpolatedStringHandler.AppendFormatted<double>(this.Size);
    return interpolatedStringHandler.ToStringAndClear();
  }
}
