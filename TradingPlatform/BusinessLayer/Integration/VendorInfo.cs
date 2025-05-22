// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.VendorInfo
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

public class VendorInfo
{
  private readonly IList<SettingItem> 핂픉;
  private readonly Type 핂퓷;
  private readonly SemaphoreSlim 핂퓿;

  public VendorMetaData MetaData { get; [param: In] private set; }

  public SettingItem[] ConnectionParameters
  {
    get
    {
      return this.핂픉.Select<SettingItem, SettingItem>((Func<SettingItem, SettingItem>) (([In] obj0) => obj0.GetCopy())).ToArray<SettingItem>();
    }
  }

  public ConnectionInfo[] DefaultConnections { get; [param: In] private set; }

  internal VendorInfo([In] VendorMetaData obj0, [In] Type obj1)
  {
    this.MetaData = obj0;
    this.핂픉 = obj0.GetConnectionParameters();
    this.DefaultConnections = obj0.GetDefaultConnections().ToArray<ConnectionInfo>();
    foreach (ConnectionInfo defaultConnection in this.DefaultConnections)
      defaultConnection.VendorInfo = this;
    this.핂퓷 = obj1;
    if (obj0.SimultaneousConnectingProcessLimit <= 0)
      return;
    this.핂퓿 = new SemaphoreSlim(obj0.SimultaneousConnectingProcessLimit);
  }

  internal Vendor 퓏() => Activator.CreateInstance(this.핂퓷) as Vendor;

  internal void 퓬() => this.핂퓿?.Wait();

  internal void 핇() => this.핂퓿?.Release();

  public override string ToString() => this.MetaData?.VendorName;
}
