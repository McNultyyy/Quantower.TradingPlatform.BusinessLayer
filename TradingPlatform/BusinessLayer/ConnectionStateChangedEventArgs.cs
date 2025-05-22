// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.ConnectionStateChangedEventArgs
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Integration;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public class ConnectionStateChangedEventArgs : EventArgs
{
  public ConnectionState PreviousState { get; [param: In] private set; }

  public ConnectionState NewState { get; [param: In] private set; }

  public ConnectionResult LastConnectionResult { get; [param: In] private set; }

  internal ConnectionStateChangedEventArgs(
    [In] ConnectionState obj0,
    [In] ConnectionState obj1,
    [In] ConnectionResult obj2)
  {
    this.PreviousState = obj0;
    this.NewState = obj1;
    this.LastConnectionResult = obj2;
  }
}
