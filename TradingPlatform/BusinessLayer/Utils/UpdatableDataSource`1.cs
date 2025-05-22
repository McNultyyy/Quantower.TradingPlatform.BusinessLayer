// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.UpdatableDataSource`1
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils;

public class UpdatableDataSource<T>
{
  private T 퓲픡;
  private DateTime 퓲픏;
  private readonly Func<CancellationToken, T> 퓲퓳;
  private readonly TimeSpan 퓲핆;
  private readonly object 퓲픷;

  public UpdatableDataSource(Func<CancellationToken, T> updateFunc, TimeSpan expirationPeriod)
  {
    this.퓲퓳 = updateFunc;
    this.퓲핆 = expirationPeriod;
    this.퓲픷 = new object();
  }

  public bool TryGetData(out T value, CancellationToken cancellation)
  {
    this.퓏(cancellation);
    return this.TryGetData(out value);
  }

  public bool TryGetData(out T value)
  {
    value = this.퓲픡;
    return !EqualityComparer<T>.Default.Equals(value, default (T));
  }

  private void 퓏([In] CancellationToken obj0)
  {
    if (this.퓲퓳 == null)
      return;
    lock (this.퓲픷)
    {
      DateTime dateTimeUtcNow = Core.Instance.TimeUtils.DateTimeUtcNow;
      if (dateTimeUtcNow - this.퓲픏 < this.퓲핆)
        return;
      try
      {
        this.퓲픡 = this.퓲퓳(obj0);
      }
      catch
      {
      }
      finally
      {
        this.퓲픏 = dateTimeUtcNow;
      }
    }
  }
}
