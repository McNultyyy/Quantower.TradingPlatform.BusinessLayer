// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.GroupTradingOperationFilters
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[Flags]
public enum GroupTradingOperationFilters
{
  None = 0,
  Connection = 1,
  Symbol = 2,
  Account = 4,
  Side = 8,
  TimeInForce = 16, // 0x00000010
  OrderType = 32, // 0x00000020
}
