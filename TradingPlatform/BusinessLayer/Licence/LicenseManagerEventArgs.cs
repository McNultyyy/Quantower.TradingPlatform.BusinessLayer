// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Licence.LicenseManagerEventArgs
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer.Licence;

public class LicenseManagerEventArgs : EventArgs
{
  public ConnectionState PreviousState { get; }

  public ConnectionState NewState { get; }

  internal LicenseManagerEventArgs([In] ConnectionState obj0, [In] ConnectionState obj1)
  {
    this.PreviousState = obj0;
    this.NewState = obj1;
  }
}
