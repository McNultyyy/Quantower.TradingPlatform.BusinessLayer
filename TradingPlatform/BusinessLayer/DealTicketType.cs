// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.DealTicketType
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.ComponentModel;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public enum DealTicketType
{
  [Description("Info")] Info,
  [Description("Refuse")] Refuse,
  [Description("Order opened")] OrderOpened,
  [Description("Order filled")] OrderFilled,
  [Description("Order partially filled")] OrderPartiallyFilled,
  [Description("Order cancelled")] OrderCancelled,
  [Description("Trading operation request")] TradingOperationRequest,
  [Description("Trading operation success")] TradingOperationResultSuccess,
  [Description("Trading operation refuse")] TradingOperationResultRefuse,
  [Description("Trading signal")] TradingSignal,
  [Description("Terminal update")] TerminalUpdate,
  [Description("License")] License,
  [Description("Connection success")] ConnectionSuccess,
  [Description("Connection lost")] ConnectionLost,
}
