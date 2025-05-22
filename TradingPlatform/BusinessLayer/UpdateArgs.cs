// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.UpdateArgs
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public class UpdateArgs
{
  public UpdateReason Reason { get; [param: In] private set; }

  public MessageQuote MessageQuote { get; [param: In] private set; }

  internal UpdateArgs([In] UpdateReason obj0, MessageQuote _param2 = null)
  {
    this.Reason = obj0;
    this.MessageQuote = _param2;
  }

  internal UpdateArgs 퓏() => new UpdateArgs(this.Reason, this.MessageQuote);
}
