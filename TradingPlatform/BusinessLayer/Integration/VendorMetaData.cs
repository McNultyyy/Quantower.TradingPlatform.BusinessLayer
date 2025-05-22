// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.VendorMetaData
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

public class VendorMetaData
{
  public Func<IList<ConnectionInfo>> GetDefaultConnections;
  /// <summary>
  /// Gets a settings list from a vendor selection of the setup window
  /// </summary>
  public Func<IList<SettingItem>> GetConnectionParameters;

  public string VendorName { get; set; }

  public string VendorDescription { get; set; }

  public int SimultaneousConnectingProcessLimit { get; set; }

  public VendorMetaData()
  {
    this.GetDefaultConnections = (Func<IList<ConnectionInfo>>) (() => (IList<ConnectionInfo>) new List<ConnectionInfo>());
    this.GetConnectionParameters = (Func<IList<SettingItem>>) (() => (IList<SettingItem>) new List<SettingItem>());
  }
}
