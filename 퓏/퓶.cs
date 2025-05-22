// Decompiled with JetBrains decompiler
// Type: 퓏.퓶
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace 퓏;

[CompilerGenerated]
internal sealed class 퓶
{
  internal static uint 퓏([In] string obj0)
  {
    uint num;
    if (obj0 != null)
    {
      num = 2166136261U;
      for (int index = 0; index < obj0.Length; ++index)
        num = (uint) (((int) obj0[index] ^ (int) num) * 16777619);
    }
    return num;
  }
}
