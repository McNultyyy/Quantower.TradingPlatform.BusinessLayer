// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.TypeWrapper
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public class TypeWrapper
{
  public Type Type { get; [param: In] private set; }

  public string AssemblyLocation { get; [param: In] private set; }

  internal TypeWrapper([In] Type obj0, [In] string obj1)
  {
    this.Type = obj0;
    this.AssemblyLocation = obj1;
  }

  public static implicit operator Type(TypeWrapper typeWrapper) => typeWrapper.Type;

  public override string ToString() => this.Type?.ToString();
}
