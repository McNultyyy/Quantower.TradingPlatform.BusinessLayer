// Decompiled with JetBrains decompiler
// Type: 퓏.픇`1
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Runtime.InteropServices;

#nullable disable
namespace 퓏;

internal class 픇<퓏>
{
  public bool Finished { get; [param: In] set; }

  public 퓏 Result { get; [param: In] set; }

  internal 픇() => this.Result = default (퓏);

  internal 픇([In] 퓏 obj0)
  {
    this.Result = obj0;
    this.Finished = true;
  }
}
