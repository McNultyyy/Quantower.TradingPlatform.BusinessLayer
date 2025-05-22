// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.DealTicket
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public class DealTicket
{
  public string Header { get; init; }

  public string Description { get; init; }

  public DealTicketType Type { get; init; }

  public DateTime CreationTime { get; }

  public Action CustomAction { get; init; }

  internal DealTicket([In] string obj0, [In] string obj1, [In] DealTicketType obj2)
    : this()
  {
    this.Header = obj0;
    this.Description = obj1;
    this.Type = obj2;
  }

  protected DealTicket() => this.CreationTime = Core.Instance.TimeUtils.DateTimeUtcNow;
}
