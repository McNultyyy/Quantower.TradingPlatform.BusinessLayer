// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.UserTradesLocalStorage.UsersTradesStorage
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
using TradingPlatform.BusinessLayer.Utils.Storage;

#nullable enable
namespace TradingPlatform.BusinessLayer.Utils.UserTradesLocalStorage;

public class UsersTradesStorage : DataStorage
{
  private static readonly 
  #nullable disable
  Type 퓑퓥;
  private readonly IUserTradesLocalStorage 퓑퓯;
  private readonly string 퓑픜;
  private DateTime 퓑퓑;

  public bool IsRealtimeCollectingAllowed => !string.IsNullOrEmpty(this.퓑픜);

  static UsersTradesStorage()
  {
    try
    {
      List<TypeWrapper> source = AssemblyLoader.LoadTypes(Path.Combine(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픮(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픉()), typeof (IUserTradesLocalStorage), searchOption: SearchOption.AllDirectories);
      UsersTradesStorage.퓑퓥 = (Type) (source != null ? source.FirstOrDefault<TypeWrapper>() : (TypeWrapper) null);
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
  }

  public UsersTradesStorage(
    IUserTradesLocalStorage storage,
    string localFilePath,
    string connectionId)
    : base((ILocalStorage) storage, localFilePath)
  {
    this.퓑퓯 = storage;
    this.퓑픜 = connectionId;
    this.퓑퓑 = Core.Instance.TimeUtils.DateTimeUtcNow;
    if (!this.IsRealtimeCollectingAllowed)
      return;
    Core.Instance.TradeAdded += new Action<Trade>(this.퓏);
  }

  public override void Dispose()
  {
    Core.Instance.TradeAdded -= new Action<Trade>(this.퓏);
    base.Dispose();
  }

  public static UsersTradesStorage Create(string connectionString, string connectionId)
  {
    if (UsersTradesStorage.퓑퓥 == (Type) null)
      throw new InvalidOperationException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픒());
    if (!(Activator.CreateInstance(UsersTradesStorage.퓑퓥) is IUserTradesLocalStorage instance))
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 1);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓷());
      interpolatedStringHandler.AppendFormatted<Type>(UsersTradesStorage.퓑퓥);
      throw new InvalidOperationException(interpolatedStringHandler.ToStringAndClear());
    }
    string directoryName = Path.GetDirectoryName(connectionString);
    if (!Directory.Exists(directoryName))
      Directory.CreateDirectory(directoryName);
    return new UsersTradesStorage(instance, connectionString, connectionId);
  }

  public void Save(UserTradesInterval historyInterval)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    UsersTradesStorage.퓬 퓬 = new UsersTradesStorage.퓬();
    // ISSUE: reference to a compiler-generated field
    퓬.퓞퓾 = this;
    // ISSUE: reference to a compiler-generated field
    퓬.퓞퓐 = historyInterval;
    this.CheckDisposed();
    // ISSUE: reference to a compiler-generated method
    this.PushAction(new Action(퓬.퓏));
  }

  public IList<UserTradesInterval> Load(
    Interval<DateTime> requestParameters,
    out List<Interval<DateTime>> historyParametersForServerRequest)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    UsersTradesStorage.핇 핇 = new UsersTradesStorage.핇();
    this.CheckDisposed();
    List<UserTradesInterval> userTradesIntervalList = new List<UserTradesInterval>();
    historyParametersForServerRequest = new List<Interval<DateTime>>();
    UsersTradesStorageInfo info = this.퓑퓯.GetInfo();
    if (!info.StoredIntervals.Any<Interval<DateTime>>())
    {
      historyParametersForServerRequest.Add(requestParameters);
      return (IList<UserTradesInterval>) userTradesIntervalList;
    }
    // ISSUE: reference to a compiler-generated field
    핇.퓞픚 = requestParameters;
    // ISSUE: reference to a compiler-generated field
    Interval<DateTime>[] array = 핇.퓞픚.Subtract((IEnumerable<Interval<DateTime>>) info.StoredIntervals).ToArray<Interval<DateTime>>();
    historyParametersForServerRequest.AddRange((IEnumerable<Interval<DateTime>>) array);
    // ISSUE: reference to a compiler-generated method
    foreach (Interval<DateTime> interval in info.StoredIntervals.Select<Interval<DateTime>, Interval<DateTime>>(new Func<Interval<DateTime>, Interval<DateTime>>(핇.퓏)).Where<Interval<DateTime>>((Func<Interval<DateTime>, bool>) (([In] obj0) => !obj0.IsEmpty)).ToArray<Interval<DateTime>>())
    {
      UserTradesInterval userTradesInterval = this.퓑퓯.Load(interval);
      userTradesIntervalList.Add(userTradesInterval);
    }
    return (IList<UserTradesInterval>) userTradesIntervalList;
  }

  private void 퓏([In] Trade obj0)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    UsersTradesStorage.퓲 퓲 = new UsersTradesStorage.퓲();
    // ISSUE: reference to a compiler-generated field
    퓲.퓞퓵 = obj0;
    // ISSUE: reference to a compiler-generated field
    퓲.퓞플 = this;
    // ISSUE: reference to a compiler-generated field
    if (퓲.퓞퓵.ConnectionId != this.퓑픜)
      return;
    // ISSUE: reference to a compiler-generated method
    this.PushAction(new Action(퓲.퓏));
  }
}
