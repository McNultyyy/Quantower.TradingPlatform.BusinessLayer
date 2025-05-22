// Decompiled with JetBrains decompiler
// Type: 퓏.퓙
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace 퓏;

internal class 퓙 : IBufferedProcessorValue<픣>
{
  public 픣 퓬픋;
  public IConnectionBindedObject 퓬핀;

  public 퓙([In] 픣 obj0, [In] IConnectionBindedObject obj1)
  {
    this.퓬픋 = obj0;
    this.퓬핀 = obj1;
  }

  public 픣 Key => this.퓬픋;
}
