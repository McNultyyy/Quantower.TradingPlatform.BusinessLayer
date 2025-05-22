// Decompiled with JetBrains decompiler
// Type: 퓏.퓑
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.GlobalVariables;

#nullable disable
namespace 퓏;

internal class 퓑
{
  public GlobalVariable Variable { get; [param: In] private set; }

  public byte[] ObjectBytes { get; [param: In] set; }

  public VariableLifetime Lifetime { get; [param: In] set; }

  internal 퓑([In] GlobalVariable obj0) => this.Variable = obj0;
}
