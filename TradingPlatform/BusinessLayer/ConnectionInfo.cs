// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.ConnectionInfo
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Integration;
using TradingPlatform.BusinessLayer.Utils.Extensions;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>
/// Represents all needed parameters for the connection constructing process.
/// </summary>
[Published]
public sealed class ConnectionInfo : 
  ICustomizable,
  IRenamable,
  IComparable,
  IComparable<ConnectionInfo>
{
  internal const string 픾퓝 = "ConnectionId";
  private const string 픾퓶 = "Name";
  internal const string 픾퓽 = "Group";
  private const string 픾픘 = "VendorName";
  private const string 픾픨 = "IsFavourite";
  private const string 픾퓪 = "ConnectionState";
  private const string 픾픪 = "CreationType";
  private VendorInfo 픾퓷;

  /// <summary>Gets a user friendly name of the connection</summary>
  public string Name { get; [param: In] internal set; }

  /// <summary>Gets connection group</summary>
  public string Group { get; [param: In] private set; }

  /// <summary>Gets vendor's name</summary>
  public string VendorName { get; [param: In] private set; }

  /// <summary>Gets connection Id</summary>
  public string ConnectionId { get; [param: In] internal set; }

  /// <summary>
  /// Favorites one will be displayed in Control center toolbar
  /// </summary>
  public bool IsFavourite { get; set; }

  /// <summary>Gets ConnectionState</summary>
  public ConnectionState ConnectionState { get; [param: In] internal set; }

  /// <summary>Gets vendor's settings</summary>
  public IList<SettingItem> VendorSettings { get; [param: In] private set; }

  internal IList<SettingItem> ConnectionSettings { get; [param: In] set; }

  /// <summary>
  /// Specifies how connection was created: by default or by user
  /// </summary>
  public ConnectionCreationType CreationType { get; [param: In] private set; }

  public string ConnectionLogoPath { get; [param: In] internal set; }

  public bool AllowCreateCustomConnections { get; [param: In] internal set; }

  public List<ConnectionInfoLink> Links { get; [param: In] internal set; }

  public string Copyrights { get; [param: In] internal set; }

  public VendorInfo VendorInfo
  {
    get => this.픾퓷;
    [param: In] internal set
    {
      if (value == null)
        return;
      this.픾퓷 = value;
      List<SettingItem> origin = new List<SettingItem>((IEnumerable<SettingItem>) this.픾퓷.ConnectionParameters);
      if (this.ConnectionSettings != null)
        origin.MergeWith((IList<SettingItem>) this.ConnectionSettings.Select<SettingItem, SettingItem>((Func<SettingItem, SettingItem>) (([In] obj0_2) => obj0_2.GetCopy())).ToList<SettingItem>());
      this.VendorSettings = (IList<SettingItem>) origin;
    }
  }

  /// <summary>
  /// <see cref="T:TradingPlatform.BusinessLayer.ICustomizable" /> realization
  /// </summary>
  public IList<SettingItem> Settings
  {
    get
    {
      int num = this.ConnectionState == ConnectionState.Connecting ? 0 : (this.ConnectionState == ConnectionState.Disconnecting ? 2 : (int) this.ConnectionState);
      List<SettingItem> settingItemList = new List<SettingItem>();
      SettingItemString settingItemString1 = new SettingItemString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픐(), this.ConnectionId);
      settingItemString1.VisibilityMode = VisibilityMode.Hidden;
      settingItemList.Add((SettingItem) settingItemString1);
      SettingItemString settingItemString2 = new SettingItemString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픜(), this.Name);
      settingItemString2.Text = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓐();
      settingItemList.Add((SettingItem) settingItemString2);
      SettingItemString settingItemString3 = new SettingItemString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픭(), this.Group);
      settingItemString3.VisibilityMode = VisibilityMode.Hidden;
      settingItemList.Add((SettingItem) settingItemString3);
      SettingItemString settingItemString4 = new SettingItemString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픚(), this.VendorName);
      settingItemString4.VisibilityMode = VisibilityMode.Hidden;
      settingItemList.Add((SettingItem) settingItemString4);
      SettingItemBoolean settingItemBoolean = new SettingItemBoolean(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓵(), this.IsFavourite);
      settingItemBoolean.VisibilityMode = VisibilityMode.Hidden;
      settingItemList.Add((SettingItem) settingItemBoolean);
      SettingItemInteger settingItemInteger1 = new SettingItemInteger(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁플(), num);
      settingItemInteger1.VisibilityMode = VisibilityMode.Hidden;
      settingItemList.Add((SettingItem) settingItemInteger1);
      SettingItemInteger settingItemInteger2 = new SettingItemInteger(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픥(), (int) this.CreationType);
      settingItemInteger2.VisibilityMode = VisibilityMode.Hidden;
      settingItemList.Add((SettingItem) settingItemInteger2);
      List<SettingItem> settings = settingItemList;
      if (this.VendorSettings != null)
      {
        for (int index = 0; index < this.VendorSettings.Count; ++index)
          settings.Add(this.VendorSettings[index].GetCopy());
      }
      return (IList<SettingItem>) settings;
    }
    set
    {
      if (value == null)
        throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇핌());
      foreach (SettingItem settingItem in (IEnumerable<SettingItem>) value)
      {
        try
        {
          string name = settingItem.Name;
          if (name != null)
          {
            switch (name.Length)
            {
              case 4:
                if (name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픜())
                {
                  this.Name = settingItem.Value as string;
                  continue;
                }
                break;
              case 5:
                if (name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픭())
                {
                  this.Group = settingItem.Value as string;
                  continue;
                }
                break;
              case 10:
                if (name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픚())
                {
                  this.VendorName = settingItem.Value as string;
                  this.핇();
                  continue;
                }
                break;
              case 11:
                if (name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓵())
                {
                  this.IsFavourite = (bool) settingItem.Value;
                  continue;
                }
                break;
              case 12:
                switch (name[1])
                {
                  case 'o':
                    if (name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픐())
                    {
                      this.ConnectionId = settingItem.Value as string;
                      continue;
                    }
                    break;
                  case 'r':
                    if (name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픥())
                    {
                      this.CreationType = (ConnectionCreationType) settingItem.Value;
                      continue;
                    }
                    break;
                }
                break;
              case 15:
                if (name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁플())
                {
                  ConnectionState connectionState = (ConnectionState) settingItem.Value;
                  if (connectionState == ConnectionState.Disconnecting)
                    connectionState = ConnectionState.Disconnected;
                  this.ConnectionState = connectionState;
                  continue;
                }
                break;
            }
          }
          IList<SettingItem> vendorSettings = this.VendorSettings;
          if (vendorSettings != null)
            vendorSettings.UpdateItemValue(settingItem.Name, settingItem.Value);
        }
        catch (Exception ex)
        {
          Core.Instance.Loggers.Log(ex);
        }
      }
      if (!string.IsNullOrEmpty(this.ConnectionLogoPath) || this.CreationType != ConnectionCreationType.Custom)
        return;
      this.퓬();
    }
  }

  public bool SyncMsgProcessing { get; set; }

  /// <summary>Creates connection info instance</summary>
  /// <param name="name"></param>
  internal ConnectionInfo([In] string obj0)
  {
    this.Name = obj0;
    this.ConnectionState = ConnectionState.Disconnected;
    this.ConnectionId = string.Empty;
  }

  internal ConnectionInfo([In] string obj0, [In] string obj1)
    : this(obj0, obj1, obj1, ConnectionCreationType.Custom)
  {
  }

  /// <summary>Creates connection info instance.</summary>
  /// <param name="name"></param>
  /// <param name="group"></param>
  /// <param name="vendorName"></param>
  /// <param name="creationType"></param>
  internal ConnectionInfo([In] string obj0, [In] string obj1, [In] string obj2, ConnectionCreationType _param4 = ConnectionCreationType.Default)
    : this(obj0)
  {
    this.Group = obj1 ?? obj2;
    this.VendorName = obj2;
    this.CreationType = _param4;
    this.ConnectionId = this.퓏();
    if (this.CreationType == ConnectionCreationType.Custom)
    {
      this.퓬();
      this.핇();
    }
    else
    {
      if (this.CreationType != ConnectionCreationType.Technical)
        return;
      this.핇();
    }
  }

  private string 퓏()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 4);
    interpolatedStringHandler.AppendFormatted(this.VendorName);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픔());
    interpolatedStringHandler.AppendFormatted(this.Group);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픔());
    interpolatedStringHandler.AppendFormatted<ConnectionCreationType>(this.CreationType);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픔());
    interpolatedStringHandler.AppendFormatted(this.CreationType == ConnectionCreationType.Default ? this.Name : Guid.NewGuid().ToShortString());
    return interpolatedStringHandler.ToStringAndClear();
  }

  private void 퓬()
  {
    ConnectionInfo connectionInfo = ((IEnumerable<ConnectionInfo>) Core.Instance.Connections.ConnectionsInfo).FirstOrDefault<ConnectionInfo>((Func<ConnectionInfo, bool>) (([In] obj0) => obj0.CreationType == ConnectionCreationType.Default && obj0.Group == this.Group));
    if (connectionInfo == null)
      return;
    this.ConnectionLogoPath = connectionInfo.ConnectionLogoPath;
  }

  private void 핇()
  {
    if (this.VendorInfo != null)
      return;
    VendorInfo vendorInfo = ((IEnumerable<VendorInfo>) Core.Instance.Vendors.Vendors).FirstOrDefault<VendorInfo>((Func<VendorInfo, bool>) (([In] obj0) => obj0.MetaData.VendorName == this.VendorName));
    ConnectionInfo connectionInfo = vendorInfo != null ? ((IEnumerable<ConnectionInfo>) vendorInfo.DefaultConnections).FirstOrDefault<ConnectionInfo>((Func<ConnectionInfo, bool>) (([In] obj0) => obj0.Group == this.Group)) : (ConnectionInfo) null;
    if (connectionInfo != null)
      this.ConnectionSettings = connectionInfo.ConnectionSettings;
    this.VendorInfo = vendorInfo;
  }

  [NotPublished]
  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(26, 3);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓼());
    interpolatedStringHandler.AppendFormatted(this.Name);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓴());
    interpolatedStringHandler.AppendFormatted(this.VendorName);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픳());
    interpolatedStringHandler.AppendFormatted<bool>(this.IsFavourite);
    return interpolatedStringHandler.ToStringAndClear();
  }

  public override bool Equals(object obj)
  {
    return obj is ConnectionInfo connectionInfo && this.ConnectionId == connectionInfo.ConnectionId;
  }

  public override int GetHashCode()
  {
    return EqualityComparer<string>.Default.GetHashCode(this.ConnectionId) - 463474436;
  }

  string IRenamable.Name
  {
    get => this.Name;
    [param: In] set => Core.Instance.Connections.RenameConnectionInfo(this, value);
  }

  bool IRenamable.퓏([In] string obj0, [In] ref string obj1) => true;

  public int CompareTo(object obj) => this.CompareTo(obj as ConnectionInfo);

  public int CompareTo(ConnectionInfo other)
  {
    if (this == other)
      return 0;
    return other == null ? 1 : string.Compare(this.ConnectionId, other.ConnectionId, StringComparison.Ordinal);
  }
}
