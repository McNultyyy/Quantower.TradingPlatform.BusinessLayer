// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Native.NativeMouseButtons
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;

#nullable disable
namespace TradingPlatform.BusinessLayer.Native;

/// <summary>
/// Specifies constants that define which mouse button was pressed.
/// </summary>
[Flags]
public enum NativeMouseButtons
{
  /// <summary>No mouse button was pressed.</summary>
  None = 0,
  /// <summary>The left mouse button was pressed.</summary>
  Left = 1048576, // 0x00100000
  /// <summary>The right mouse button was pressed.</summary>
  Right = 2097152, // 0x00200000
  /// <summary>The middle mouse button was pressed.</summary>
  Middle = 4194304, // 0x00400000
  /// <summary>The first XButton was pressed.</summary>
  XButton1 = 8388608, // 0x00800000
  /// <summary>The second XButton was pressed.</summary>
  XButton2 = 16777216, // 0x01000000
}
