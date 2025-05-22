// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.ReportType
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Integration;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>
/// Defines report request parameters from <see cref="P:TradingPlatform.BusinessLayer.ICustomizable.Settings" /> which can be used in <see cref="T:TradingPlatform.BusinessLayer.ReportRequestParameters" />
/// </summary>
public class ReportType : BusinessObject, IComparable, ICustomizable
{
  private IList<SettingItem> 픎픏;

  /// <summary>Gets report Id</summary>
  public int Id { [param: In] private set; get; }

  /// <summary>Gets report Name</summary>
  public string Name { [param: In] private set; get; }

  internal ReportType([In] string obj0)
    : base(obj0)
  {
    this.픎픏 = (IList<SettingItem>) new List<SettingItem>();
  }

  internal void 퓏([In] MessageReportType obj0)
  {
    this.Id = obj0.Id;
    this.Name = obj0.Name;
    if (this.픎픏 == null)
      this.픎픏 = (IList<SettingItem>) new List<SettingItem>();
    foreach (SettingItem parameter in obj0.Parameters)
      this.픎픏.Add(parameter);
  }

  internal ReportType 퓏()
  {
    return new ReportType(this.ConnectionId)
    {
      Id = this.Id,
      Name = this.Name,
      Settings = this.Settings
    };
  }

  public int CompareTo(object obj) => 0;

  /// <summary>
  /// <see cref="T:TradingPlatform.BusinessLayer.ICustomizable" /> report settings
  /// </summary>
  public IList<SettingItem> Settings
  {
    get => this.픎픏;
    set
    {
      this.픎픏 = (IList<SettingItem>) new List<SettingItem>();
      foreach (SettingItem settingItem in (IEnumerable<SettingItem>) value)
        this.픎픏.Add(settingItem.GetCopy());
    }
  }
}
