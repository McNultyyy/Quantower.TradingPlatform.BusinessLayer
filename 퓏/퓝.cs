// Decompiled with JetBrains decompiler
// Type: 퓏.퓝
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Runtime.InteropServices;

#nullable disable
namespace 퓏;

internal class 퓝
{
  public string LocalStorageConnectionString { get; [param: In] set; }

  public int DegreeOfParallelism { get; [param: In] set; }

  public 픢 LoadHistoryDelegate { get; [param: In] set; }

  public bool AllowLocalStorage { get; [param: In] set; }
}
