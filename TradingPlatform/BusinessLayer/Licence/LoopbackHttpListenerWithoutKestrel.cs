// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Licence.LoopbackHttpListenerWithoutKestrel
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

#nullable enable
namespace TradingPlatform.BusinessLayer.Licence;

/// <summary>The loopback http listener without kestrel.</summary>
public sealed class LoopbackHttpListenerWithoutKestrel : LoopbackBase, IDisposable
{
  private readonly 
  #nullable disable
  HttpListener 픣픪;

  /// <summary>
  /// Initializes a new instance of the <see cref="T:TradingPlatform.BusinessLayer.Licence.LoopbackHttpListenerWithoutKestrel" /> class.
  /// </summary>
  /// <param name="port">The port.</param>
  public LoopbackHttpListenerWithoutKestrel(int port)
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 1);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓥());
    interpolatedStringHandler.AppendFormatted<int>(port);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픉());
    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
    Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓞() + stringAndClear, LoggingLevel.Verbose);
    this.픣픪 = new HttpListener();
    this.픣픪.Prefixes.Add(stringAndClear);
    this.픣픪.Start();
  }

  /// <summary>Dispose</summary>
  public override void Dispose()
  {
    Task.Run((Func<Task>) (async () =>
    {
      await Task.Delay(500);
      this.픣픪.Stop();
      this.픣픪.Close();
    }));
  }

  private void 퓏([In] string obj0, [In] HttpListenerResponse obj1)
  {
    using (Stream outputStream = obj1.OutputStream)
    {
      try
      {
        obj1.StatusCode = 200;
        obj1.ContentType = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓎();
        byte[] bytes = Encoding.UTF8.GetBytes(string.Format(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇핅()));
        obj1.ContentLength64 = (long) bytes.Length;
        outputStream.WriteAsync(bytes, 0, bytes.Length);
        this.taskSource.TrySetResult(obj0);
      }
      catch
      {
        obj1.StatusCode = 400;
      }
    }
  }

  private void 퓏()
  {
    try
    {
      HttpListenerContext context = this.픣픪.GetContext();
      if (context.Request.HttpMethod == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픡() || context.Request.HttpMethod == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픏())
      {
        string query = context.Request.Url.Query;
        NameValueCollection queryString = HttpUtility.ParseQueryString(query);
        if (((IEnumerable<string>) queryString.AllKeys).Contains<string>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁핆()))
        {
          string str = queryString[\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁핆()];
        }
        this.퓏(query, context.Response);
      }
      else if (context.Request.HttpMethod == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓳())
      {
        if (!context.Request.ContentType.Equals(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇핆(), StringComparison.OrdinalIgnoreCase))
        {
          context.Response.StatusCode = 415;
        }
        else
        {
          using (StreamReader streamReader = new StreamReader(context.Request.InputStream, Encoding.UTF8))
            this.퓏(streamReader.ReadToEnd(), context.Response);
        }
      }
      else
        context.Response.StatusCode = 405;
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
  }

  /// <summary>Wait for callback asynchronously.</summary>
  /// <param name="token">The token.</param>
  /// <returns><![CDATA[Task<string>]]></returns>
  public override Task<string> WaitForCallbackAsync(CancellationToken token)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    LoopbackHttpListenerWithoutKestrel.퓬 퓬 = new LoopbackHttpListenerWithoutKestrel.퓬();
    // ISSUE: reference to a compiler-generated field
    퓬.퓑픳 = this;
    // ISSUE: reference to a compiler-generated field
    퓬.퓑픙 = token;
    // ISSUE: reference to a compiler-generated field
    퓬.퓑픙.Register(new Action(((LoopbackBase) this).CancelWaiting));
    // ISSUE: reference to a compiler-generated method
    // ISSUE: reference to a compiler-generated field
    Task.Factory.StartNew(new Action(퓬.퓏), 퓬.퓑픙);
    // ISSUE: reference to a compiler-generated method
    // ISSUE: reference to a compiler-generated field
    Task.Factory.StartNew(new Action(퓬.퓬), 퓬.퓑픙);
    return this.taskSource.Task;
  }
}
