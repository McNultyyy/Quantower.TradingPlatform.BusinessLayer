// Decompiled with JetBrains decompiler
// Type: 퓏.픨`1
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer;
using TradingPlatform.BusinessLayer.Integration;

#nullable disable
namespace 퓏;

internal sealed class 픨<퓏> : Rule
{
  internal 퓏 Value { get; [param: In] private set; }

  internal 픨([In] string obj0, [In] 퓏 obj1)
    : base(obj0)
  {
    this.Value = obj1;
  }

  internal override void 퓏([In] MessageRule obj0)
  {
    if (!(obj0.Value is 퓏 퓏))
      throw new ArgumentException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓾() + typeof (퓏).Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓐());
    base.퓏(obj0);
    this.Value = 퓏;
  }
}
