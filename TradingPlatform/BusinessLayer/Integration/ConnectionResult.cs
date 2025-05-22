// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.ConnectionResult
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using ProtoBuf;
using System;
using System.Collections.Generic;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

/// <summary>Vendor connection respond bundle</summary>
[ProtoContract]
public sealed class ConnectionResult : ICloneable
{
  /// <summary>The connection status</summary>
  [ProtoMember(1)]
  public ConnectionState State { get; set; }

  /// <summary>The respond message</summary>
  [ProtoMember(2)]
  public string Message { get; set; }

  [ProtoMember(3)]
  public bool Cancelled { get; set; }

  public IList<SettingItem> UpdatedSettings { get; set; }

  public static ConnectionResult CreateFail(string message, IList<SettingItem> updatedSettings = null)
  {
    return new ConnectionResult()
    {
      State = ConnectionState.Fail,
      Message = message,
      UpdatedSettings = updatedSettings
    };
  }

  public static ConnectionResult CreateSuccess(string message = "", IList<SettingItem> updatedSettings = null)
  {
    return new ConnectionResult()
    {
      State = ConnectionState.Connected,
      Message = message,
      UpdatedSettings = updatedSettings
    };
  }

  public static ConnectionResult CreateCancelled(string message = "")
  {
    return new ConnectionResult()
    {
      State = ConnectionState.Fail,
      Message = message,
      Cancelled = true
    };
  }

  public object Clone()
  {
    return (object) new ConnectionResult()
    {
      State = this.State,
      Message = this.Message,
      Cancelled = this.Cancelled
    };
  }
}
