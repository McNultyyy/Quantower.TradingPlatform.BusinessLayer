// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.HistoryAggregationReversal
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Integration;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public sealed class HistoryAggregationReversal : HistoryAggregation
{
  private const string 퓥퓓 = "Length";
  private const string 퓥픗 = "Reversal Length";

  public override string Name => \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픋();

  public override IList<SettingItem> Settings
  {
    get
    {
      List<SettingItem> settings = new List<SettingItem>();
      SettingItemInteger settingItemInteger1 = new SettingItemInteger(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣핀(), this.Length);
      settingItemInteger1.Minimum = 0;
      settingItemInteger1.Increment = 1;
      settingItemInteger1.SortIndex = 10;
      settings.Add((SettingItem) settingItemInteger1);
      SettingItemInteger settingItemInteger2 = new SettingItemInteger(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픲(), this.ReversalLength);
      settingItemInteger2.Minimum = 1;
      settingItemInteger2.Increment = 1;
      settingItemInteger2.SortIndex = 10;
      settings.Add((SettingItem) settingItemInteger2);
      return (IList<SettingItem>) settings;
    }
    set
    {
      if (value == null)
        return;
      foreach (SettingItem settingItem in (IEnumerable<SettingItem>) value)
      {
        string name = settingItem.Name;
        if (!(name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣핀()))
        {
          if (name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픲())
            this.ReversalLength = (int) settingItem.Value;
        }
        else
          this.Length = (int) settingItem.Value;
      }
    }
  }

  public int Length { get; [param: In] private set; }

  public int ReversalLength { get; [param: In] private set; }

  public HistoryAggregationReversal(int length, int reversalLength)
  {
    this.Length = length;
    this.ReversalLength = reversalLength;
  }

  private HistoryAggregationReversal([In] HistoryAggregationReversal obj0)
    : base((HistoryAggregation) obj0)
  {
    this.Length = obj0.Length;
    this.ReversalLength = obj0.ReversalLength;
  }

  public override Period GetPeriod => Period.TICK1;

  public override HistoryType GetHistoryType => HistoryType.Last;

  [NotPublished]
  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 3);
    interpolatedStringHandler.AppendFormatted(this.Name);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓛());
    interpolatedStringHandler.AppendFormatted<int>(this.Length);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓛());
    interpolatedStringHandler.AppendFormatted<int>(this.ReversalLength);
    return interpolatedStringHandler.ToStringAndClear();
  }

  [NotPublished]
  public override object Clone() => (object) new HistoryAggregationReversal(this);

  [NotPublished]
  public override string FormatTime(DateTime dt)
  {
    return dt.ToString(DateTimeFormatInfo.CurrentInfo.ShortDatePattern + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓶());
  }

  [NotPublished]
  public override Period DefaultRange => Period.HOUR1;

  public override HistoryAggregation GetAggregationToDirectDownload(HistoryMetadata metadata)
  {
    return (HistoryAggregation) new HistoryAggregationTick(HistoryType.Last);
  }
}
