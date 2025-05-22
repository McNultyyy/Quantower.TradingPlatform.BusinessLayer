// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.History.Storage.HistoryStorage
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
using TradingPlatform.BusinessLayer.Utils;
using TradingPlatform.BusinessLayer.Utils.Storage;

#nullable disable
namespace TradingPlatform.BusinessLayer.History.Storage;

public class HistoryStorage : DataStorage, IHistoryStorage
{
  private readonly IHistoryLocalStorage 퓑픲;
  private static readonly Type 퓑픽;

  public HistoryStorage(IHistoryLocalStorage storage, string localFilePath)
    : base((ILocalStorage) storage, localFilePath)
  {
    this.퓑픲 = storage;
  }

  public IList<HistoryInterval> Load(
    HistoryRequestParameters requestParameters,
    out List<HistoryRequestParameters> historyParametersForServerRequest)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    HistoryStorage.퓬 퓬 = new HistoryStorage.퓬();
    // ISSUE: reference to a compiler-generated field
    퓬.퓞퓚 = requestParameters;
    // ISSUE: reference to a compiler-generated field
    퓬.퓞픃 = this;
    this.CheckDisposed();
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    퓬.퓞퓎 = 퓬.퓞퓚 != null ? 퓬.퓞퓚.ToDescription() : throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁필());
    // ISSUE: reference to a compiler-generated field
    HistoryStorageInfo info = this.퓑픲.GetInfo(퓬.퓞퓎, HistoryStorageInfoScope.StoredIntervals);
    if (info.StoredIntervals.Count == 0)
    {
      // ISSUE: reference to a compiler-generated field
      historyParametersForServerRequest = new List<HistoryRequestParameters>()
      {
        퓬.퓞퓚
      };
      return (IList<HistoryInterval>) new List<HistoryInterval>();
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated method
    historyParametersForServerRequest = 퓬.퓞퓚.Interval.Subtract((IEnumerable<Interval<DateTime>>) info.StoredIntervals).Select<Interval<DateTime>, HistoryRequestParameters>(new Func<Interval<DateTime>, HistoryRequestParameters>(퓬.퓏)).ToList<HistoryRequestParameters>();
    // ISSUE: reference to a compiler-generated method
    // ISSUE: reference to a compiler-generated method
    return (IList<HistoryInterval>) info.StoredIntervals.Select<Interval<DateTime>, Interval<DateTime>>(new Func<Interval<DateTime>, Interval<DateTime>>(퓬.퓬)).Where<Interval<DateTime>>((Func<Interval<DateTime>, bool>) (([In] obj0) => !obj0.IsEmpty)).Select<Interval<DateTime>, HistoryInterval>(new Func<Interval<DateTime>, HistoryInterval>(퓬.핇)).ToList<HistoryInterval>();
  }

  public void Save(HistoryInterval historyInterval, bool wait = false)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    HistoryStorage.핇 핇 = new HistoryStorage.핇();
    // ISSUE: reference to a compiler-generated field
    핇.퓞피 = this;
    // ISSUE: reference to a compiler-generated field
    핇.퓞퓸 = historyInterval;
    this.CheckDisposed();
    if (wait)
    {
      // ISSUE: reference to a compiler-generated method
      this.WaitForAction(new Action(핇.퓏));
    }
    else
    {
      // ISSUE: reference to a compiler-generated method
      this.PushAction(new Action(핇.퓬));
    }
  }

  public void Delete(HistoryDescription description, Interval<DateTime> interval, bool wait = false)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    HistoryStorage.퓲 퓲 = new HistoryStorage.퓲();
    // ISSUE: reference to a compiler-generated field
    퓲.퓞퓦 = this;
    // ISSUE: reference to a compiler-generated field
    퓲.퓞픋 = description;
    // ISSUE: reference to a compiler-generated field
    퓲.퓞핀 = interval;
    this.CheckDisposed();
    if (wait)
    {
      // ISSUE: reference to a compiler-generated method
      this.WaitForAction(new Action(퓲.퓏));
    }
    else
    {
      // ISSUE: reference to a compiler-generated method
      this.PushAction(new Action(퓲.퓬));
    }
  }

  public HistoryStorageInfo GetInfo(HistoryDescription description, HistoryStorageInfoScope scope)
  {
    this.CheckDisposed();
    return this.퓑픲.GetInfo(description, scope);
  }

  public List<HistoryDescription> GetAllAvailableHistoryDescriptions()
  {
    this.CheckDisposed();
    return this.퓑픲.GetAllAvailableHistoryDescriptions();
  }

  internal void 퓏() => this.퓑픲?.Vacuum();

  static HistoryStorage()
  {
    try
    {
      List<TypeWrapper> source = AssemblyLoader.LoadTypes(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓟(), typeof (IHistoryLocalStorage), searchOption: SearchOption.AllDirectories);
      HistoryStorage.퓑픽 = (Type) (source != null ? source.FirstOrDefault<TypeWrapper>() : (TypeWrapper) null);
    }
    catch
    {
    }
  }

  public static HistoryStorage Create(string connectionString)
  {
    if (HistoryStorage.퓑픽 == (Type) null)
      throw new InvalidOperationException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픒());
    if (!(Activator.CreateInstance(HistoryStorage.퓑픽) is IHistoryLocalStorage instance))
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 1);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓷());
      interpolatedStringHandler.AppendFormatted<Type>(HistoryStorage.퓑픽);
      throw new InvalidOperationException(interpolatedStringHandler.ToStringAndClear());
    }
    string directoryName = Path.GetDirectoryName(connectionString);
    if (!Directory.Exists(directoryName))
      Directory.CreateDirectory(directoryName);
    return new HistoryStorage(instance, connectionString);
  }
}
