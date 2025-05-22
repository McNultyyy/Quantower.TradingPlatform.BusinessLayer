// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.VolumeAnalysis.Storage.VolumeAnalysisStorage
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
using TradingPlatform.BusinessLayer.Integration;
using TradingPlatform.BusinessLayer.Utils;
using TradingPlatform.BusinessLayer.Utils.Storage;

#nullable disable
namespace TradingPlatform.BusinessLayer.VolumeAnalysis.Storage;

public class VolumeAnalysisStorage : DataStorage
{
  private readonly IVolumeAnalysisLocalStorage 퓑퓮;
  private static readonly Type 퓑픕;

  public VolumeAnalysisStorage(IVolumeAnalysisLocalStorage storage, string localFilePath)
    : base((ILocalStorage) storage, localFilePath)
  {
    this.퓑퓮 = storage;
  }

  public IList<VolumeAnalysisInterval> Load(
    VolumeAnalysisByPeriodRequestParameters requestParameters,
    out List<VolumeAnalysisByPeriodRequestParameters> parametersForServerRequest)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    VolumeAnalysisStorage.퓬 퓬 = new VolumeAnalysisStorage.퓬();
    // ISSUE: reference to a compiler-generated field
    퓬.퓞픀 = requestParameters;
    this.CheckDisposed();
    List<VolumeAnalysisInterval> analysisIntervalList = new List<VolumeAnalysisInterval>();
    parametersForServerRequest = new List<VolumeAnalysisByPeriodRequestParameters>();
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    VolumeAnalysisDescription description = 퓬.퓞픀 != null ? 퓬.퓞픀.ToDescription() : throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁필());
    VolumeAnalysisStorageInfo info = this.퓑퓮.GetInfo(description);
    if (info.StoredIntervals.Count == 0)
    {
      // ISSUE: reference to a compiler-generated field
      parametersForServerRequest.Add(퓬.퓞픀);
      return (IList<VolumeAnalysisInterval>) analysisIntervalList;
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    퓬.퓞픶 = 퓬.퓞픀.Interval;
    // ISSUE: reference to a compiler-generated field
    Interval<DateTime>[] array = 퓬.퓞픶.Subtract((IEnumerable<Interval<DateTime>>) info.StoredIntervals).ToArray<Interval<DateTime>>();
    // ISSUE: reference to a compiler-generated method
    parametersForServerRequest.AddRange(((IEnumerable<Interval<DateTime>>) array).Select<Interval<DateTime>, VolumeAnalysisByPeriodRequestParameters>(new Func<Interval<DateTime>, VolumeAnalysisByPeriodRequestParameters>(퓬.퓏)));
    // ISSUE: reference to a compiler-generated method
    foreach (Interval<DateTime> interval in info.StoredIntervals.Select<Interval<DateTime>, Interval<DateTime>>(new Func<Interval<DateTime>, Interval<DateTime>>(퓬.퓬)).Where<Interval<DateTime>>((Func<Interval<DateTime>, bool>) (([In] obj0) => !obj0.IsEmpty)).ToArray<Interval<DateTime>>())
    {
      VolumeAnalysisInterval analysisInterval = this.퓑퓮.Load(description, interval);
      analysisIntervalList.Add(analysisInterval);
    }
    return (IList<VolumeAnalysisInterval>) analysisIntervalList;
  }

  public void Save(VolumeAnalysisInterval volumeAnalysisInterval, bool wait = false)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    VolumeAnalysisStorage.핇 핇 = new VolumeAnalysisStorage.핇();
    // ISSUE: reference to a compiler-generated field
    핇.퓞픖 = this;
    // ISSUE: reference to a compiler-generated field
    핇.퓞퓘 = volumeAnalysisInterval;
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

  public void Delete(VolumeAnalysisDescription description, Interval<DateTime> interval, bool wait = false)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    VolumeAnalysisStorage.퓲 퓲 = new VolumeAnalysisStorage.퓲();
    // ISSUE: reference to a compiler-generated field
    퓲.퓞픓 = this;
    // ISSUE: reference to a compiler-generated field
    퓲.퓞픩 = description;
    // ISSUE: reference to a compiler-generated field
    퓲.퓞필 = interval;
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

  public VolumeAnalysisStorageInfo GetInfo(VolumeAnalysisDescription description)
  {
    this.CheckDisposed();
    return this.퓑퓮.GetInfo(description);
  }

  static VolumeAnalysisStorage()
  {
    try
    {
      List<TypeWrapper> source = AssemblyLoader.LoadTypes(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓣(), typeof (IVolumeAnalysisLocalStorage), searchOption: SearchOption.AllDirectories);
      VolumeAnalysisStorage.퓑픕 = (Type) (source != null ? source.FirstOrDefault<TypeWrapper>() : (TypeWrapper) null);
    }
    catch
    {
    }
  }

  public static VolumeAnalysisStorage Create(string connectionString)
  {
    if (VolumeAnalysisStorage.퓑픕 == (Type) null)
      throw new InvalidOperationException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픒());
    if (!(Activator.CreateInstance(VolumeAnalysisStorage.퓑픕) is IVolumeAnalysisLocalStorage instance))
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 1);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓷());
      interpolatedStringHandler.AppendFormatted<Type>(VolumeAnalysisStorage.퓑픕);
      throw new InvalidOperationException(interpolatedStringHandler.ToStringAndClear());
    }
    string directoryName = Path.GetDirectoryName(connectionString);
    if (!Directory.Exists(directoryName))
      Directory.CreateDirectory(directoryName);
    return new VolumeAnalysisStorage(instance, connectionString);
  }
}
