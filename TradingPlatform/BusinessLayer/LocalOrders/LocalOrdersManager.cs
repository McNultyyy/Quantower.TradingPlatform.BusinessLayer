// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.LocalOrders.LocalOrdersManager
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Utils.Extensions;

#nullable disable
namespace TradingPlatform.BusinessLayer.LocalOrders;

public class LocalOrdersManager : IDisposable, IEnumerable<LocalOrder>, IEnumerable
{
  private readonly IDictionary<string, LocalOrder> 퓲퓼;
  private readonly object 퓲퓴;

  public event EventHandler<LocalOrderEventArgs> Updated;

  public LocalOrdersManager()
  {
    this.퓲퓼 = (IDictionary<string, LocalOrder>) new Dictionary<string, LocalOrder>();
    this.퓲퓴 = new object();
  }

  public void Initialize()
  {
    Core.Instance.Connections.ConnectionStateChanged += new EventHandler<ConnectionStateChangedEventArgs>(this.퓏);
  }

  public string AddOrder(LocalOrder localOrder)
  {
    localOrder.Id = Guid.NewGuid().ToShortString();
    lock (this.퓲퓴)
      this.퓲퓼.Add(localOrder.Id, localOrder);
    localOrder.Updated += new Action<IOrder>(this.퓏);
    this.퓏(localOrder, EntityLifecycle.Created);
    return localOrder.Id;
  }

  public bool RemoveOrder(string orderId)
  {
    LocalOrder localOrder;
    lock (this.퓲퓴)
    {
      if (this.퓲퓼.TryGetValue(orderId, out localOrder))
        this.퓲퓼.Remove(orderId);
    }
    if (localOrder == null)
      return false;
    localOrder.Updated -= new Action<IOrder>(this.퓏);
    localOrder.Dispose();
    this.퓏(localOrder, EntityLifecycle.Removed);
    return true;
  }

  public bool TryHandleTradingOperationRequest(
    TradingRequestParameters requestParameters,
    out TradingOperationResult result)
  {
    result = (TradingOperationResult) null;
    bool flag;
    switch (requestParameters)
    {
      case ModifyOrderRequestParameters requestParameters1:
        flag = this.퓏(requestParameters1, out result);
        break;
      case CancelOrderRequestParameters requestParameters2:
        flag = this.퓏(requestParameters2, out result);
        break;
      default:
        flag = false;
        break;
    }
    return flag;
  }

  private bool 퓏([In] ModifyOrderRequestParameters obj0, out TradingOperationResult _param2)
  {
    _param2 = (TradingOperationResult) null;
    LocalOrder localOrder;
    if (!this.퓏(obj0.OrderId, out localOrder))
      return false;
    localOrder.퓏(obj0);
    _param2 = TradingOperationResult.CreateSuccess(obj0.RequestId);
    return true;
  }

  private bool 퓏([In] CancelOrderRequestParameters obj0, out TradingOperationResult _param2)
  {
    bool flag = this.RemoveOrder(obj0.OrderId);
    _param2 = flag ? TradingOperationResult.CreateSuccess(obj0.RequestId) : TradingOperationResult.CreateError(obj0.RequestId, string.Empty);
    return flag;
  }

  public void Dispose()
  {
    Core.Instance.Connections.ConnectionStateChanged -= new EventHandler<ConnectionStateChangedEventArgs>(this.퓏);
    lock (this.퓲퓴)
    {
      foreach (LocalOrder localOrder in (IEnumerable<LocalOrder>) this.퓲퓼.Values)
        localOrder.Updated -= new Action<IOrder>(this.퓏);
      this.퓲퓼.Clear();
    }
  }

  private void 퓏([In] object obj0_1, [In] ConnectionStateChangedEventArgs obj1)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    LocalOrdersManager.퓬 퓬 = new LocalOrdersManager.퓬();
    if (obj1.NewState != ConnectionState.Disconnected && obj1.NewState != ConnectionState.ConnectionLost)
      return;
    // ISSUE: reference to a compiler-generated field
    퓬.픣퓠 = obj0_1 as Connection;
    // ISSUE: reference to a compiler-generated field
    if (퓬.픣퓠 == null)
      return;
    List<string> list;
    lock (this.퓲퓴)
    {
      // ISSUE: reference to a compiler-generated method
      list = this.퓲퓼.Where<KeyValuePair<string, LocalOrder>>(new Func<KeyValuePair<string, LocalOrder>, bool>(퓬.퓏)).Select<KeyValuePair<string, LocalOrder>, string>((Func<KeyValuePair<string, LocalOrder>, string>) (([In] obj0_2) => obj0_2.Key)).ToList<string>();
    }
    foreach (string orderId in list)
      this.RemoveOrder(orderId);
  }

  private bool 퓏([In] string obj0, out LocalOrder _param2)
  {
    _param2 = (LocalOrder) null;
    lock (this.퓲퓴)
      this.퓲퓼.TryGetValue(obj0, out _param2);
    return _param2 != null;
  }

  private void 퓏([In] IOrder obj0)
  {
    if (!(obj0 is LocalOrder localOrder))
      return;
    this.퓏(localOrder, EntityLifecycle.Changed);
  }

  private void 퓏([In] LocalOrder obj0, [In] EntityLifecycle obj1)
  {
    // ISSUE: reference to a compiler-generated field
    EventHandler<LocalOrderEventArgs> 퓲픳 = this.퓲픳;
    if (퓲픳 == null)
      return;
    object[] objArray = new object[2]{ (object) this, null };
    LocalOrderEventArgs localOrderEventArgs = new LocalOrderEventArgs();
    localOrderEventArgs.LocalOrder = obj0;
    localOrderEventArgs.Lifecycle = obj1;
    objArray[1] = (object) localOrderEventArgs;
    퓲픳.InvokeSafely(objArray);
  }

  public IEnumerator<LocalOrder> GetEnumerator()
  {
    lock (this.퓲퓴)
      return this.퓲퓼.Values.GetEnumerator();
  }

  IEnumerator IEnumerable.퓏() => (IEnumerator) this.GetEnumerator();
}
