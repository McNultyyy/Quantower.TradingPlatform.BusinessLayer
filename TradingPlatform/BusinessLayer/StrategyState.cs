// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.StrategyState
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

#nullable disable
namespace TradingPlatform.BusinessLayer;

[Published]
public enum StrategyState
{
  Created = 10, // 0x0000000A
  Working = 20, // 0x00000014
  Stopped = 30, // 0x0000001E
  Removed = 40, // 0x00000028
  WaitingForConnection = 50, // 0x00000032
}
