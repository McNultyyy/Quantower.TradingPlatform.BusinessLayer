// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.Storage.DataStorage
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Threading;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils.Storage;

public abstract class DataStorage : ActionBufferedProcessor, IDisposable
{
  private readonly ILocalStorage 픇퓒;
  private readonly List<ManualResetEventSlim> 픇퓚;
  private readonly object 픇픃;
  private bool 픇퓎;

  protected DataStorage(ILocalStorage storage, string localFilePath)
  {
    this.픇퓒 = storage ?? throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픤());
    this.픇퓒.Connect(localFilePath);
    this.픇퓚 = new List<ManualResetEventSlim>();
    this.픇픃 = new object();
    this.Start();
  }

  public virtual void Dispose()
  {
    this.CheckDisposed();
    this.픇퓎 = true;
    try
    {
      this.Clear();
      this.WaitAllMessagesProcess();
      this.Stop();
      this.픇퓒.Disconnect();
      lock (this.픇픃)
      {
        foreach (ManualResetEventSlim manualResetEventSlim in this.픇퓚)
          manualResetEventSlim.Set();
        this.픇퓚.Clear();
      }
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
  }

  protected void CheckDisposed()
  {
    if (this.픇퓎)
      throw new ObjectDisposedException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓟());
  }

  protected void PushAction(Action action)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: reference to a compiler-generated method
    this.Push(new Action(new DataStorage.퓏()
    {
      퓑핅 = this,
      퓑픡 = action
    }.퓏));
  }

  protected void WaitForAction(Action action)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    DataStorage.퓬 퓬 = new DataStorage.퓬();
    // ISSUE: reference to a compiler-generated field
    퓬.퓑픏 = this;
    // ISSUE: reference to a compiler-generated field
    퓬.퓑퓳 = action;
    // ISSUE: reference to a compiler-generated field
    퓬.퓑핆 = new ManualResetEventSlim(false);
    lock (this.픇픃)
    {
      // ISSUE: reference to a compiler-generated field
      this.픇퓚.Add(퓬.퓑핆);
    }
    // ISSUE: reference to a compiler-generated method
    this.Push(new Action(퓬.퓏));
    // ISSUE: reference to a compiler-generated field
    퓬.퓑핆.Wait();
    lock (this.픇픃)
    {
      // ISSUE: reference to a compiler-generated field
      this.픇퓚.Remove(퓬.퓑핆);
    }
  }
}
