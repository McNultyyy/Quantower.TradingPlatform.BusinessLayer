// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.Storage.OrdersHistoryStorage
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils.Storage;

public sealed class OrdersHistoryStorage : DataStorage
{
  private static readonly Type 퓑핋;
  private readonly IOrdersHistoryLocalStorage 퓑퓞;

  static OrdersHistoryStorage()
  {
    try
    {
      List<TypeWrapper> source = AssemblyLoader.LoadTypes(Path.Combine(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픮(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓿()), typeof (IOrdersHistoryLocalStorage), searchOption: SearchOption.AllDirectories);
      OrdersHistoryStorage.퓑핋 = (Type) (source != null ? source.FirstOrDefault<TypeWrapper>() : (TypeWrapper) null);
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
  }

  public OrdersHistoryStorage(
    IOrdersHistoryLocalStorage storage,
    string localFilePath,
    string connectionId)
    : base((ILocalStorage) storage, localFilePath)
  {
    this.퓑퓞 = storage;
  }

  public static OrdersHistoryStorage Create(string connectionString, string connectionId)
  {
    if (OrdersHistoryStorage.퓑핋 == (Type) null)
      throw new InvalidOperationException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픒());
    if (!(Activator.CreateInstance(OrdersHistoryStorage.퓑핋) is IOrdersHistoryLocalStorage instance))
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 1);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓷());
      interpolatedStringHandler.AppendFormatted<Type>(OrdersHistoryStorage.퓑핋);
      throw new InvalidOperationException(interpolatedStringHandler.ToStringAndClear());
    }
    string directoryName = Path.GetDirectoryName(connectionString);
    if (!Directory.Exists(directoryName))
      Directory.CreateDirectory(directoryName);
    return new OrdersHistoryStorage(instance, connectionString, connectionId);
  }

  public void Save(OrdersHistoryInterval historyInterval)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    OrdersHistoryStorage.퓬 퓬 = new OrdersHistoryStorage.퓬();
    // ISSUE: reference to a compiler-generated field
    퓬.퓞퓴 = this;
    // ISSUE: reference to a compiler-generated field
    퓬.퓞픳 = historyInterval;
    this.CheckDisposed();
    // ISSUE: reference to a compiler-generated method
    this.PushAction(new Action(퓬.퓏));
  }

  public IList<OrdersHistoryInterval> Load(
    Interval<DateTime> requestParameters,
    out List<Interval<DateTime>> historyParametersForServerRequest)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    OrdersHistoryStorage.핇 핇 = new OrdersHistoryStorage.핇();
    this.CheckDisposed();
    List<OrdersHistoryInterval> ordersHistoryIntervalList = new List<OrdersHistoryInterval>();
    historyParametersForServerRequest = new List<Interval<DateTime>>();
    OrdersHistoryStorageInfo info = this.퓑퓞.GetInfo();
    if (!info.StoredIntervals.Any<Interval<DateTime>>())
    {
      historyParametersForServerRequest.Add(requestParameters);
      return (IList<OrdersHistoryInterval>) ordersHistoryIntervalList;
    }
    // ISSUE: reference to a compiler-generated field
    핇.퓞픙 = requestParameters;
    // ISSUE: reference to a compiler-generated field
    Interval<DateTime>[] array = 핇.퓞픙.Subtract((IEnumerable<Interval<DateTime>>) info.StoredIntervals).ToArray<Interval<DateTime>>();
    historyParametersForServerRequest.AddRange((IEnumerable<Interval<DateTime>>) array);
    // ISSUE: reference to a compiler-generated method
    foreach (Interval<DateTime> interval in info.StoredIntervals.Select<Interval<DateTime>, Interval<DateTime>>(new Func<Interval<DateTime>, Interval<DateTime>>(핇.퓏)).Where<Interval<DateTime>>((Func<Interval<DateTime>, bool>) (([In] obj0) => !obj0.IsEmpty)).ToArray<Interval<DateTime>>())
    {
      OrdersHistoryInterval ordersHistoryInterval = this.퓑퓞.Load(interval);
      ordersHistoryIntervalList.Add(ordersHistoryInterval);
    }
    return (IList<OrdersHistoryInterval>) ordersHistoryIntervalList;
  }
}
