// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.ConnectionStateObserver
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

#nullable disable
namespace TradingPlatform.BusinessLayer;

public sealed class ConnectionStateObserver : IDisposable, IComparable<ConnectionStateObserver>
{
  private IConnectionStateDependent 픆;
  private readonly ConnectionStateObserverPriority 픅;
  private readonly ConnectionState[] 픠;

  public ConnectionStateObserver(
    IConnectionStateDependent dependencyObject,
    ConnectionStateObserverPriority priority = ConnectionStateObserverPriority.Normal,
    params ConnectionState[] monitoringStates)
  {
    this.픆 = dependencyObject;
    this.픅 = priority;
    this.픠 = monitoringStates;
    Core.Instance.Connections.퓏(this);
  }

  internal void 퓏([In] object obj0, [In] ConnectionStateChangedEventArgs obj1)
  {
    if (!((IEnumerable<ConnectionState>) this.픠).Contains<ConnectionState>(obj1.NewState))
      return;
    if (!(obj0 is Connection connection))
      return;
    try
    {
      ConnectionDependency connectionStateDependency = this.픆?.GetConnectionStateDependency();
      if (connectionStateDependency != null && connectionStateDependency.Behavior == ConnectionDependencyBehavior.NoDependency)
        return;
      if (connectionStateDependency == null || connectionStateDependency.Behavior != ConnectionDependencyBehavior.TotalDependency)
      {
        bool? nullable;
        if (connectionStateDependency == null)
        {
          nullable = new bool?();
        }
        else
        {
          string[] dependentConnectionsIds = connectionStateDependency.DependentConnectionsIds;
          nullable = dependentConnectionsIds != null ? new bool?(((IEnumerable<string>) dependentConnectionsIds).Contains<string>(connection.Id)) : new bool?();
        }
        if (!nullable.GetValueOrDefault())
          return;
      }
      this.픆?.OnConnectionStateChanged(connection, obj1);
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
  }

  public void Dispose()
  {
    Core.Instance.Connections.퓬(this);
    this.픆 = (IConnectionStateDependent) null;
  }

  public int CompareTo(ConnectionStateObserver other) => -1 * this.픅.CompareTo((object) other.픅);

  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 2);
    interpolatedStringHandler.AppendFormatted<ConnectionStateObserverPriority>(this.픅);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핆());
    interpolatedStringHandler.AppendFormatted<IConnectionStateDependent>(this.픆);
    return interpolatedStringHandler.ToStringAndClear();
  }
}
