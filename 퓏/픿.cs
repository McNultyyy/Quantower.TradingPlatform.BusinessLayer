// Decompiled with JetBrains decompiler
// Type: 퓏.픿
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer;

#nullable disable
namespace 퓏;

internal sealed class 픿
{
  public readonly IEnumerable<SettingItem> 핂퓶;

  public DateTime lastRealTimeNewsRequestTime { get; [param: In] set; }

  public 픿([In] IEnumerable<SettingItem> obj0) => this.핂퓶 = obj0;
}
