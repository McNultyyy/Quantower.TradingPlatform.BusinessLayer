// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.VendorEventArgs
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

public class VendorEventArgs : EventArgs
{
  public string VendorKey { get; [param: In] private set; }

  public Message Message { get; [param: In] private set; }

  public VendorEventArgs(string vendorKey, Message message)
  {
    this.VendorKey = vendorKey;
    this.Message = message;
  }
}
