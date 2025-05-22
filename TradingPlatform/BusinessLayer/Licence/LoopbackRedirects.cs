// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Licence.LoopbackRedirects
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

#nullable disable
namespace TradingPlatform.BusinessLayer.Licence;

public sealed class LoopbackRedirects : LoopbackBase, IDisposable
{
  private readonly IOAuthBrowserControl 픣퓡;

  public LoopbackRedirects(IOAuthBrowserControl browserControl)
  {
    this.픣퓡 = browserControl;
    this.픣퓡.Navigated += new Action<string>(this.퓏);
  }

  public override void Dispose()
  {
    if (this.픣퓡 == null)
      return;
    this.픣퓡.Navigated -= new Action<string>(this.퓏);
  }

  private void 퓏([In] string obj0)
  {
    try
    {
      string query = new Uri(obj0).Query;
      NameValueCollection queryString = HttpUtility.ParseQueryString(query);
      if (!((IEnumerable<string>) queryString.AllKeys).Contains<string>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁핆()))
        return;
      string str = queryString[\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁핆()];
      this.taskSource.TrySetResult(query);
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
  }

  public override Task<string> WaitForCallbackAsync(CancellationToken token)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    LoopbackRedirects.퓏 퓏 = new LoopbackRedirects.퓏();
    // ISSUE: reference to a compiler-generated field
    퓏.퓑퓭 = token;
    // ISSUE: reference to a compiler-generated field
    퓏.퓑퓣 = this;
    // ISSUE: reference to a compiler-generated field
    퓏.퓑퓭.Register(new Action(((LoopbackBase) this).CancelWaiting));
    // ISSUE: reference to a compiler-generated method
    // ISSUE: reference to a compiler-generated field
    Task.Factory.StartNew(new Action(퓏.퓏), 퓏.퓑퓭);
    return this.taskSource.Task;
  }
}
