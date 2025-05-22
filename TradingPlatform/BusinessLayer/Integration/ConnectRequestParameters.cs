// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.ConnectRequestParameters
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

[ProtoContract]
public sealed class ConnectRequestParameters : RequestParameters
{
  public override RequestType Type => RequestType.Connect;

  [ProtoMember(1)]
  public IList<SettingItem> ConnectionSettings { get; [param: In] internal set; }

  public IBrowserFactory BrowserFactory { get; [param: In] internal set; }

  public string ConnectionId { get; [param: In] internal set; }

  public IProgress<string> ConnectingProgress { get; [param: In] internal set; }

  public ConnectRequestParameters()
  {
  }

  public ConnectRequestParameters(IList<SettingItem> connectionSettings)
  {
    this.ConnectionSettings = connectionSettings;
  }
}
