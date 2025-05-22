// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.NativeDragDropEffects
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

#nullable disable
namespace TradingPlatform.BusinessLayer;

public enum NativeDragDropEffects
{
  Scroll = -2147483648, // 0x80000000
  All = -2147483645, // 0x80000003
  None = 0,
  Copy = 1,
  Move = 2,
  Link = 4,
}
