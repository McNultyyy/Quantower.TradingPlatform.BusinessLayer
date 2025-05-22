// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.ConnectionsManager
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using TradingPlatform.BusinessLayer.Integration;
using 퓏;

#nullable enable
namespace TradingPlatform.BusinessLayer;

public sealed class ConnectionsManager : ICustomizable, IDisposable
{
  private const int 픾픟 = 10000;
  private readonly 
  #nullable disable
  핅<string, Connection> 픾퓧;
  private readonly object 픾픰;
  private readonly 핅<string, ConnectionInfo> 픾퓢;
  private Timer 픾픫;
  private bool 픾퓴;
  private readonly List<ConnectionStateObserver> 픾픳;
  private readonly object 픾픙;
  private readonly Dictionary<string, 퓏.픞> 픾퓭;
  private int 픾퓣;
  internal static readonly 퓏.프 픾픦 = new 퓏.프();

  public Connection[] All => this.픾퓧.Values.ToArray<Connection>();

  public Connection[] Connected
  {
    get
    {
      return this.픾퓧.Values.ToList<Connection>().Where<Connection>((Func<Connection, bool>) (([In] obj0) => obj0.Connected)).ToArray<Connection>();
    }
  }

  public ConnectionInfo[] ConnectionsInfo => this.픾퓢.Values.ToArray<ConnectionInfo>();

  public Connection this[string id] => string.IsNullOrEmpty(id) ? (Connection) null : this.픾퓧[id];

  public event Action<Connection> ConnectionAdded;

  public event Action<Connection> ConnectionRemoved;

  public event EventHandler<ConnectionStateChangedEventArgs> ConnectionStateChanged;

  public event EventHandler<ConnectionConnectingProgressChangedEventArgs> ConnectionConnectingProgressChanged;

  public event Action PingUpdated;

  public event Action<ConnectionInfo> ConnectionInfoAdded;

  public event Action<ConnectionInfo> ConnectionInfoRemoved;

  public event Action<ConnectionInfo> ConnectionInfoRenamed;

  public ConnectionsManager()
  {
    this.픾퓧 = 핅<string, Connection>.핇();
    this.픾퓢 = new 핅<string, ConnectionInfo>();
    this.픾퓭 = new Dictionary<string, 퓏.픞>();
    this.픾픰 = new object();
    this.픾픳 = new List<ConnectionStateObserver>();
    this.픾픙 = new object();
  }

  internal ConnectionsManager([In] List<Connection> obj0)
    : this()
  {
    foreach (Connection connection in obj0)
      this.픾퓧.퓏(connection.Id, connection);
  }

  public void Initialize()
  {
    Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픙(), LoggingLevel.Verbose);
    foreach (ConnectionInfo connectionInfo in ((IEnumerable<VendorInfo>) Core.Instance.Vendors.Vendors).SelectMany<VendorInfo, ConnectionInfo>((Func<VendorInfo, IEnumerable<ConnectionInfo>>) (([In] obj0) => (IEnumerable<ConnectionInfo>) obj0.DefaultConnections)))
      this.픾퓢[connectionInfo.ConnectionId] = connectionInfo;
    this.퓏();
    Core.Instance.퓏(new Action(this.핇));
    Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓭(), LoggingLevel.Verbose);
  }

  public Connection CreateConnection(ConnectionInfo info)
  {
    lock (this.픾픰)
    {
      Connection connection;
      if (this.픾퓧.퓏(info.ConnectionId, out connection))
        return connection;
      connection = new Connection(info);
      this.픾퓧.퓏(connection.Id, connection);
      this.퓏(connection);
      return connection;
    }
  }

  public void RemoveConnection(Connection connection)
  {
    if (connection == null)
      return;
    lock (this.픾픰)
    {
      this.픾퓭.Remove(connection.Id);
      if (!this.픾퓧.퓬(connection.Id))
        return;
      connection.Disconnect();
      this.픾퓧.퓏(connection.Id);
      this.퓬(connection);
    }
  }

  public ConnectionInfo CreateCustomConnectionInfo(string name, string vendorName, string group = null)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    ConnectionsManager.퓬 퓬 = new ConnectionsManager.퓬();
    // ISSUE: reference to a compiler-generated field
    퓬.퓠핊 = vendorName;
    // ISSUE: reference to a compiler-generated field
    퓬.퓠픛 = group;
    if (name == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓫());
    // ISSUE: reference to a compiler-generated field
    if (퓬.퓠핊 == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓣());
    // ISSUE: reference to a compiler-generated field
    if (퓬.퓠픛 == null)
    {
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      퓬.퓠픛 = 퓬.퓠핊;
    }
    // ISSUE: reference to a compiler-generated method
    List<ConnectionInfo> list = ((IEnumerable<ConnectionInfo>) this.ConnectionsInfo).Where<ConnectionInfo>(new Func<ConnectionInfo, bool>(퓬.퓏)).ToList<ConnectionInfo>();
    if (list.Count == 0)
    {
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      throw new ArgumentException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픦() + 퓬.퓠핊 + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픍() + 퓬.퓠픛);
    }
    if (!list.Any<ConnectionInfo>((Func<ConnectionInfo, bool>) (([In] obj0) => obj0.AllowCreateCustomConnections)))
    {
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      throw new InvalidOperationException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픆() + 퓬.퓠핊 + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픍() + 퓬.퓠픛);
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    return new ConnectionInfo(name, 퓬.퓠픛, 퓬.퓠핊, ConnectionCreationType.Custom)
    {
      Links = list[0].Links
    };
  }

  public ConnectionInfo CreateTechnicalConnectionInfo(string name, string vendorName, string id = null)
  {
    if (name == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓫());
    ConnectionInfo technicalConnectionInfo = vendorName != null ? new ConnectionInfo(name, vendorName, vendorName, ConnectionCreationType.Technical) : throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓣());
    if (!string.IsNullOrEmpty(id))
      technicalConnectionInfo.ConnectionId = id;
    return technicalConnectionInfo;
  }

  public void AddConnectionInfo(ConnectionInfo connectionInfo)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    ConnectionsManager.핇 핇 = new ConnectionsManager.핇();
    // ISSUE: reference to a compiler-generated field
    핇.퓠퓜 = connectionInfo;
    // ISSUE: reference to a compiler-generated field
    if (핇.퓠퓜 == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픅());
    // ISSUE: reference to a compiler-generated field
    if (핇.퓠퓜.CreationType == ConnectionCreationType.Technical)
      throw new InvalidOperationException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픠());
    ConnectionInfo connectionInfo1;
    // ISSUE: reference to a compiler-generated field
    if (this.픾퓢.퓏(핇.퓠퓜.ConnectionId, out connectionInfo1))
    {
      // ISSUE: reference to a compiler-generated field
      connectionInfo1.Settings = 핇.퓠퓜.Settings;
    }
    else
    {
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.픾퓢[핇.퓠퓜.ConnectionId] = 핇.퓠퓜;
      // ISSUE: reference to a compiler-generated method
      List<ConnectionInfo> list = ((IEnumerable<ConnectionInfo>) this.ConnectionsInfo).Where<ConnectionInfo>(new Func<ConnectionInfo, bool>(핇.퓏)).ToList<ConnectionInfo>();
      if (list.Count > 0)
      {
        // ISSUE: reference to a compiler-generated field
        핇.퓠퓜.Links = list[0].Links;
        // ISSUE: reference to a compiler-generated field
        핇.퓠퓜.Copyrights = list[0].Copyrights;
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.픾플.InvokeSafely((object) 핇.퓠퓜);
    }
  }

  public void RemoveConnectionInfo(ConnectionInfo connectionInfo)
  {
    if (connectionInfo == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픅());
    if (!this.픾퓢.퓬(connectionInfo.ConnectionId))
      return;
    this.픾퓢.퓏(connectionInfo.ConnectionId);
    Connection connection;
    if (this.픾퓧.퓏(connectionInfo.ConnectionId, out connection))
      this.RemoveConnection(connection);
    // ISSUE: reference to a compiler-generated field
    this.픾픥.InvokeSafely((object) connectionInfo);
  }

  public void RenameConnectionInfo(ConnectionInfo connectionInfo, string newName)
  {
    if (connectionInfo == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픅());
    if (string.IsNullOrEmpty(newName))
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓮());
    if (connectionInfo.Name == newName)
      return;
    connectionInfo.Name = newName;
    // ISSUE: reference to a compiler-generated field
    this.픾퓼.InvokeSafely((object) connectionInfo);
  }

  private void 퓏([In] Connection obj0)
  {
    obj0.StateChanged += new EventHandler<ConnectionStateChangedEventArgs>(this.퓏);
    obj0.ConnectingProgressChanged += new EventHandler<ConnectionConnectingProgressChangedEventArgs>(this.퓏);
    // ISSUE: reference to a compiler-generated field
    this.픾픯.InvokeSafely((object) obj0);
  }

  private void 퓬([In] Connection obj0)
  {
    obj0.StateChanged -= new EventHandler<ConnectionStateChangedEventArgs>(this.퓏);
    obj0.ConnectingProgressChanged -= new EventHandler<ConnectionConnectingProgressChangedEventArgs>(this.퓏);
    // ISSUE: reference to a compiler-generated field
    this.픾퓾.InvokeSafely((object) obj0);
  }

  private void 퓏([In] object obj0, [In] ConnectionStateChangedEventArgs obj1)
  {
    if (!(obj0 is Connection connection))
      return;
    lock (this.픾픰)
    {
      if (obj1.NewState == ConnectionState.ConnectionLost)
      {
        if (!this.픾퓭.ContainsKey(connection.Id))
          this.픾퓭.Add(connection.Id, new 퓏.픞(connection));
      }
    }
    List<ConnectionStateObserver> connectionStateObserverList = (List<ConnectionStateObserver>) null;
    lock (this.픾픙)
      connectionStateObserverList = new List<ConnectionStateObserver>((IEnumerable<ConnectionStateObserver>) this.픾픳);
    foreach (ConnectionStateObserver connectionStateObserver in connectionStateObserverList)
      connectionStateObserver.퓏(obj0, obj1);
    // ISSUE: reference to a compiler-generated field
    this.픾퓐.InvokeSafely(obj0, (object) obj1);
  }

  private void 퓏([In] object obj0, [In] ConnectionConnectingProgressChangedEventArgs obj1)
  {
    if (!(obj0 is Connection))
      return;
    // ISSUE: reference to a compiler-generated field
    EventHandler<ConnectionConnectingProgressChangedEventArgs> 픾픚 = this.픾픚;
    if (픾픚 == null)
      return;
    픾픚(obj0, obj1);
  }

  public void Dispose()
  {
    this.퓬();
    if (this.픾퓧 != null)
    {
      List<Connection> connectionList = new List<Connection>((IEnumerable<Connection>) this.픾퓧.Values);
      foreach (Connection connection in connectionList)
        connection.Disconnect();
      this.픾퓧.퓬();
      connectionList.Clear();
    }
    Core.Instance.퓬(new Action(this.핇));
  }

  internal void 퓏([In] ConnectionStateObserver obj0)
  {
    lock (this.픾픙)
    {
      this.픾픳.Add(obj0);
      this.픾픳.Sort();
    }
  }

  internal void 퓬([In] ConnectionStateObserver obj0)
  {
    lock (this.픾픙)
      this.픾픳.Remove(obj0);
  }

  private void 퓏()
  {
    try
    {
      if (this.픾픫 != null)
        return;
      this.픾픫 = new Timer(new TimerCallback(this.퓏));
      this.픾픫.Change(0, 10000);
    }
    catch
    {
    }
  }

  private void 퓬()
  {
    try
    {
      if (this.픾픫 == null)
        return;
      this.픾픫.Change(-1, -1);
      this.픾픫.Dispose();
      this.픾픫 = (Timer) null;
    }
    catch (Exception ex)
    {
    }
  }

  private void 퓏([In] object obj0)
  {
    if (this.픾퓴)
      return;
    try
    {
      this.픾퓴 = true;
      foreach (Connection connection in this.All)
        connection.퓬();
      // ISSUE: reference to a compiler-generated field
      Action 픾퓵 = this.픾퓵;
      if (픾퓵 == null)
        return;
      픾퓵();
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
    finally
    {
      this.픾퓴 = false;
    }
  }

  private void 핇()
  {
    if (this.픾퓣 < 10)
    {
      ++this.픾퓣;
    }
    else
    {
      List<퓏.픞> 픞List = new List<퓏.픞>();
      lock (this.픾픰)
        픞List.AddRange((IEnumerable<퓏.픞>) this.픾퓭.Values);
      foreach (퓏.픞 픞 in 픞List)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        ConnectionsManager.퓲 퓲 = new ConnectionsManager.퓲();
        // ISSUE: reference to a compiler-generated field
        퓲.퓠핃 = this;
        // ISSUE: reference to a compiler-generated field
        퓲.퓠픺 = 픞;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        if (퓲.퓠픺.CurrentTask == null && 퓲.퓠픺.Connection.State != ConnectionState.Connecting)
        {
          // ISSUE: reference to a compiler-generated field
          --퓲.퓠픺.ReconnectDelay;
          // ISSUE: reference to a compiler-generated field
          if (퓲.퓠픺.ReconnectDelay <= 0.0)
          {
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            퓲.퓠픺.CurrentTask = (Task) Task.Run(new Action(퓲.퓏)).ContinueWith<Task>(new Func<Task, Task>(퓲.퓏));
          }
        }
      }
      this.픾퓣 = 0;
    }
  }

  private void 핇([In] Connection obj0)
  {
    퓏.픞 픞;
    lock (this.픾픰)
    {
      if (!this.픾퓭.TryGetValue(obj0.Id, out 픞))
        return;
    }
    ++픞.ReconnectAttempts;
    ConnectionResult connectionResult = obj0.Connect();
    if (obj0.State == ConnectionState.Connected || connectionResult.Cancelled)
    {
      lock (this.픾픰)
        this.픾퓭.Remove(obj0.Id);
    }
    else
    {
      if (connectionResult.State != ConnectionState.Fail)
        return;
      픞.ReconnectDelay = 5.0;
    }
  }

  public IList<SettingItem> Settings
  {
    get
    {
      List<SettingItem> settings = new List<SettingItem>();
      foreach (ConnectionInfo connectionInfo in Core.Instance.Connections.ConnectionsInfo)
      {
        try
        {
          settings.Add((SettingItem) new SettingItemGroup(connectionInfo.Name, connectionInfo.Settings));
        }
        catch (Exception ex)
        {
          Core.Instance.Loggers.Log(ex, connectionInfo.Name);
        }
      }
      return (IList<SettingItem>) settings;
    }
    set
    {
      foreach (SettingItem settingItem in (IEnumerable<SettingItem>) value)
      {
        ConnectionsManager.픾픦.퓏(settingItem);
        ConnectionInfo connectionInfo = new ConnectionInfo(settingItem.Name)
        {
          Settings = settingItem.Value as IList<SettingItem>
        };
        if (connectionInfo.VendorInfo != null)
          this.AddConnectionInfo(connectionInfo);
      }
    }
  }
}
