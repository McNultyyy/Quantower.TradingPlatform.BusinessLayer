// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.HistoryAggregationLevel2
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Integration;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public sealed class HistoryAggregationLevel2 : HistoryAggregation
{
  public override string Name => \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓚();

  public HistoryAggregationLevel2()
  {
  }

  public override string FormatTime(DateTime dt)
  {
    return dt.ToString(DateTimeFormatInfo.CurrentInfo.ShortDatePattern + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓶());
  }

  private HistoryAggregationLevel2([In] HistoryAggregationLevel2 obj0)
    : base((HistoryAggregation) obj0)
  {
  }

  [NotPublished]
  public override object Clone() => (object) new HistoryAggregationLevel2(this);

  [NotPublished]
  public override Period GetPeriod => Period.TICK1;

  [NotPublished]
  public override HistoryType GetHistoryType
  {
    get => throw new Exception(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣핊());
  }

  public override HistoryAggregation GetAggregationToDirectDownload(HistoryMetadata metadata)
  {
    return !((IEnumerable<string>) metadata.AllowedAggregations).Contains<string>(this.Name) ? (HistoryAggregation) null : (HistoryAggregation) this;
  }
}
