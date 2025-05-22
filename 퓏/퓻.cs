// Decompiled with JetBrains decompiler
// Type: 퓏.퓻
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using IdentityModel.OidcClient.Browser;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using TradingPlatform.BusinessLayer;
using TradingPlatform.BusinessLayer.Licence;

#nullable enable
namespace 퓏;

internal class 퓻 : IBrowser
{
  internal 
  #nullable disable
  IOAuthBrowserCreator 퓲픶;
  private readonly int 퓲픀;
  private readonly bool 퓲픖;

  public 퓻([In] bool obj0, int? _param2 = null)
  {
    this.퓲픖 = obj0;
    if (!_param2.HasValue)
      this.퓲픀 = TcpIpHelper.GetRandomUnusedPort;
    else
      this.퓲픀 = _param2.Value;
  }

  public async Task<BrowserResult> InvokeAsync(
    BrowserOptions options,
    CancellationToken cancellationToken = default (CancellationToken))
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    퓻.퓏 퓏 = new 퓻.퓏();
    IOAuthBrowserControl browserControl = this.퓏(options.StartUrl);
    // ISSUE: reference to a compiler-generated field
    퓏.픣퓓 = (LoopbackBase) null;
    // ISSUE: reference to a compiler-generated field
    퓏.픣퓓 = !options.EndUrl.Contains(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픷()) ? (LoopbackBase) new LoopbackRedirects(browserControl) : (LoopbackBase) new LoopbackHttpListenerWithoutKestrel(this.퓲픀);
    if (browserControl != null)
    {
      // ISSUE: reference to a compiler-generated method
      browserControl.BrowserClosed += new Action(퓏.퓏);
    }
    try
    {
      // ISSUE: reference to a compiler-generated field
      string str = await 퓏.픣퓓.WaitForCallbackAsync(cancellationToken);
      Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓻() + str, LoggingLevel.Verbose);
      if (string.IsNullOrWhiteSpace(str))
      {
        BrowserResult browserResult = new BrowserResult();
        browserResult.ResultType = BrowserResultType.UnknownError;
        browserResult.Error = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픸();
        return browserResult;
      }
      return new BrowserResult()
      {
        Response = str,
        ResultType = BrowserResultType.Success
      };
    }
    catch (TimeoutException ex)
    {
      BrowserResult browserResult = new BrowserResult();
      browserResult.ResultType = BrowserResultType.Timeout;
      browserResult.Error = ex.Message;
      return browserResult;
    }
    catch (TaskCanceledException ex)
    {
      BrowserResult browserResult = new BrowserResult();
      browserResult.ResultType = BrowserResultType.UserCancel;
      browserResult.Error = ex.Message;
      return browserResult;
    }
    catch (Exception ex)
    {
      BrowserResult browserResult = new BrowserResult();
      browserResult.ResultType = BrowserResultType.UnknownError;
      browserResult.Error = ex.Message;
      return browserResult;
    }
    finally
    {
      browserControl?.CloseBrowser();
      // ISSUE: reference to a compiler-generated field
      퓏.픣퓓.Dispose();
    }
  }

  private IOAuthBrowserControl 퓏([In] string obj0)
  {
    if (this.퓲픶 == null)
    {
      퓻.퓬(obj0);
      return (IOAuthBrowserControl) null;
    }
    IOAuthBrowserControl browser = this.퓲픶.CreateBrowser(!obj0.Contains(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픕()));
    browser.ShowBrowser(obj0, this.퓲픖);
    return browser;
  }

  private static void 퓬([In] string obj0)
  {
    try
    {
      Process.Start(obj0);
    }
    catch
    {
      if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
      {
        obj0 = obj0.Replace(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픱(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픶());
        Process.Start(new ProcessStartInfo(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픀(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픖() + obj0)
        {
          CreateNoWindow = true
        });
      }
      else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        Process.Start(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓘(), obj0);
      else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        Process.Start(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픓(), obj0);
      else
        throw;
    }
  }
}
