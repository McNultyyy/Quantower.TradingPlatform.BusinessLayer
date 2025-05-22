// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.HistoryItemVolumeProfile
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public sealed class HistoryItemVolumeProfile : HistoryItem
{
  public HistoryItemVolumeProfile()
  {
  }

  public HistoryItemVolumeProfile(HistoryItemVolumeProfile item)
    : base((HistoryItem) item)
  {
    this.TicksRight = item.TicksRight;
    this.PriceLevels = item.PriceLevels.ToDictionary<KeyValuePair<double, VolumeDataItem>, double, VolumeDataItem>((Func<KeyValuePair<double, VolumeDataItem>, double>) (([In] obj0) => obj0.Key), (Func<KeyValuePair<double, VolumeDataItem>, VolumeDataItem>) (([In] obj0) => new VolumeDataItem(obj0.Value)));
  }

  public override long TicksRight { get; set; }

  public Dictionary<double, VolumeDataItem> PriceLevels { get; set; }

  public override object Clone() => (object) new HistoryItemVolumeProfile(this);
}
