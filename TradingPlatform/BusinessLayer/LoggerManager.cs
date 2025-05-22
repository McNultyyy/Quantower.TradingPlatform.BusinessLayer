// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.LoggerManager
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using CommandLine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using TradingPlatform.BusinessLayer.Utils;
using 퓏;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public sealed class LoggerManager : BufferedProcessor<Action>, IDisposable
{
  private const int 핇픾 = 864000;
  private const int 핇퓍 = 600;
  private const string 핇픁 = "Loggers";
  private int 핇픞;
  private ILogger 핇퓗;
  private readonly List<Type> 핇픎;
  private readonly List<ILogger> 핇퓠;
  private readonly List<string> 핇퓥;

  public bool EnableAutoDeleting { get; set; }

  public int AutoDeletePeriod { get; set; }

  public event Action<ApplicationLoggerEvent> NewLog;

  /// <summary>Current logging level</summary>
  public LoggingLevel CurrentLogLevel { get; [param: In] private set; }

  public LoggerManager()
  {
    this.AutoDeletePeriod = 30;
    this.EnableAutoDeleting = true;
    this.핇픞 = 863400;
    this.핇픎 = new List<Type>();
    this.핇퓠 = new List<ILogger>();
    this.핇퓥 = new List<string>();
    this.CurrentLogLevel = LoggingLevel.System | LoggingLevel.Error | LoggingLevel.Trading;
    new Parser((Action<ParserSettings>) (([In] obj0) => obj0.IgnoreUnknownArguments = true)).ParseArguments<퓏.퓗>((IEnumerable<string>) Environment.GetCommandLineArgs()).WithParsed<퓏.퓗>((Action<퓏.퓗>) (([In] obj0) => this.AddLogLevel(obj0.LoggingLevel))).WithNotParsed<퓏.퓗>((Action<IEnumerable<Error>>) (([In] obj0) =>
    {
      foreach (object obj in obj0)
        this.Log(obj.ToString(), LoggingLevel.Error);
    }));
  }

  internal void 퓏()
  {
    List<TypeWrapper> source = AssemblyLoader.LoadTypes(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓤(), typeof (ILogger), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픮(), SearchOption.AllDirectories);
    if (source == null)
      return;
    this.핇픎.AddRange(source.Where<TypeWrapper>((Func<TypeWrapper, bool>) (([In] obj0) => !obj0.Type.IsAbstract)).Select<TypeWrapper, Type>((Func<TypeWrapper, Type>) (([In] obj0) => obj0.Type)));
    this.핇퓗 = this.GetLogger(new LoggerConfig()
    {
      LoggerName = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픉(),
      OutputFolderPath = Path.Combine(Directory.GetParent(Const.EXECUTING_FOLDER).FullName, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픒(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓷(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓿()),
      Scope = LoggerScope.Application
    });
    this.Start();
    Core.Instance.퓏(new Action(this.핇));
  }

  public void Dispose()
  {
    Core.Instance.퓬(new Action(this.핇));
    this.Stop();
    if (this.핇퓗 == null)
      return;
    this.핇퓗.Dispose();
    this.핇퓗 = (ILogger) null;
  }

  public ILogger GetLogger(LoggerConfig loggerConfig)
  {
    List<ILogger> loggerList = new List<ILogger>();
    foreach (Type type in this.핇픎)
    {
      ILogger instance = (ILogger) Activator.CreateInstance(type);
      if (instance.AllowedScopes.HasFlag((Enum) loggerConfig.Scope))
        loggerList.Add(instance);
    }
    퓓 logger = new 퓓((ICollection<ILogger>) loggerList);
    logger.Configure(loggerConfig);
    this.퓏((ILogger) logger);
    return (ILogger) logger;
  }

  /// <summary>
  /// Sets logs with custom messag, logging level, connection name
  /// </summary>
  public void Log(string message, LoggingLevel loggingLevel = LoggingLevel.System, string connectionName = null)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    LoggerManager.퓬 퓬 = new LoggerManager.퓬();
    // ISSUE: reference to a compiler-generated field
    퓬.핁픢 = this;
    // ISSUE: reference to a compiler-generated field
    퓬.핁퓝 = message;
    // ISSUE: reference to a compiler-generated field
    퓬.핁퓶 = loggingLevel;
    // ISSUE: reference to a compiler-generated field
    퓬.핁퓽 = connectionName;
    // ISSUE: reference to a compiler-generated field
    if (!this.퓏(퓬.핁퓶))
      return;
    // ISSUE: reference to a compiler-generated method
    this.Push(new Action(퓬.퓏));
  }

  /// <summary>
  /// Sets logs with exception and custom message (optional), logging level, connection name
  /// </summary>
  public void Log(Exception ex, string message = null, LoggingLevel loggingLevel = LoggingLevel.Error, string connectionName = null)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    LoggerManager.핇 핇 = new LoggerManager.핇();
    // ISSUE: reference to a compiler-generated field
    핇.핁픘 = this;
    // ISSUE: reference to a compiler-generated field
    핇.핁픨 = message;
    // ISSUE: reference to a compiler-generated field
    핇.핁퓪 = ex;
    // ISSUE: reference to a compiler-generated field
    핇.핁픪 = loggingLevel;
    // ISSUE: reference to a compiler-generated field
    핇.핁퓡 = connectionName;
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    if (핇.핁퓪 is ThreadAbortException || !this.퓏(핇.핁픪))
      return;
    // ISSUE: reference to a compiler-generated method
    this.Push(new Action(핇.퓏));
  }

  /// <summary>
  /// Sets logs with objects inherited from ILoggable interface,logging level, connection name
  /// </summary>
  public void Log(ILoggable loggable, LoggingLevel loggingLevel = LoggingLevel.System, string connectionName = null)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    LoggerManager.퓲 퓲 = new LoggerManager.퓲();
    // ISSUE: reference to a compiler-generated field
    퓲.핁퓓 = this;
    // ISSUE: reference to a compiler-generated field
    퓲.핁픗 = loggable;
    // ISSUE: reference to a compiler-generated field
    퓲.핁퓰 = loggingLevel;
    // ISSUE: reference to a compiler-generated field
    퓲.핁픧 = connectionName;
    // ISSUE: reference to a compiler-generated field
    if (퓲.핁픗 == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픟());
    // ISSUE: reference to a compiler-generated field
    if (!this.퓏(퓲.핁퓰))
      return;
    // ISSUE: reference to a compiler-generated method
    this.Push(new Action(퓲.퓏));
  }

  public void Log(string @event, string message, LoggingLevel loggingLevel = LoggingLevel.System, string connectionName = null)
  {
    this.Log((ILoggable) new Loggable(@event, message), loggingLevel, connectionName);
  }

  private void 퓏([In] ApplicationLoggerEvent obj0)
  {
    // ISSUE: reference to a compiler-generated field
    Action<ApplicationLoggerEvent> 핇픣 = this.핇픣;
    if (핇픣 == null)
      return;
    핇픣(obj0);
  }

  /// <summary>Sets a log level in case of deep debug</summary>
  public void AddLogLevel(LoggingLevel loggingLevel) => this.CurrentLogLevel |= loggingLevel;

  /// <summary>Remove a log level if one has not needed already</summary>
  public void RemoveLogLevel(LoggingLevel loggingLevel) => this.CurrentLogLevel &= ~loggingLevel;

  public List<ApplicationLoggerEvent> GetHistory(DateTime from, DateTime to)
  {
    List<ApplicationLoggerEvent> history = new List<ApplicationLoggerEvent>();
    if (this.핇퓗 != null)
      history.AddRange(this.핇퓗.GetHistory(from, to).OfType<ApplicationLoggerEvent>());
    return history;
  }

  /// <summary>Manage files existence in folder.</summary>
  public void RegisterExternalLogFolder(string path)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    LoggerManager.핂 핂 = new LoggerManager.핂();
    // ISSUE: reference to a compiler-generated field
    핂.핁퓹 = this;
    // ISSUE: reference to a compiler-generated field
    핂.핁퓛 = path;
    // ISSUE: reference to a compiler-generated field
    if (!Directory.Exists(핂.핁퓛))
      return;
    // ISSUE: reference to a compiler-generated field
    this.핇퓥.Add(핂.핁퓛);
    if (!this.EnableAutoDeleting || this.핇픞 >= 863400)
      return;
    // ISSUE: reference to a compiler-generated field
    핂.핁픝 = Core.Instance.TimeUtils.DateTimeUtcNow.AddDays((double) -this.AutoDeletePeriod);
    // ISSUE: reference to a compiler-generated method
    this.Push(new Action(핂.퓏));
  }

  private void 퓬()
  {
    if (this.핇퓗 == null || !this.EnableAutoDeleting)
      return;
    this.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓧());
    DateTime dateTimeUtcNow = Core.Instance.TimeUtils.DateTimeUtcNow;
    DateTime from = dateTimeUtcNow.AddDays((double) -this.AutoDeletePeriod);
    foreach (ILogger logger in this.핇퓠)
      logger?.DeleteLogFilesExcept(from, dateTimeUtcNow);
    foreach (string str in this.핇퓥)
      this.퓏(str, from);
    this.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픰());
  }

  private void 퓏([In] string obj0, [In] DateTime obj1)
  {
    if (string.IsNullOrEmpty(obj0))
      return;
    try
    {
      if (!Directory.Exists(obj0))
        return;
      foreach (string file in Directory.GetFiles(obj0))
      {
        if (new FileInfo(file).CreationTimeUtc < obj1)
          File.Delete(file);
      }
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓢());
    }
  }

  private void 퓏([In] ILogger obj0_1)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    LoggerManager.픂 픂 = new LoggerManager.픂();
    // ISSUE: reference to a compiler-generated field
    픂.핁픻 = obj0_1;
    this.핇퓠.RemoveAll((Predicate<ILogger>) (([In] obj0_2) => obj0_2 != null));
    // ISSUE: reference to a compiler-generated field
    this.핇퓠.Add(픂.핁픻);
    if (!this.EnableAutoDeleting || this.핇픞 >= 863400)
      return;
    // ISSUE: reference to a compiler-generated field
    픂.핁픮 = Core.Instance.TimeUtils.DateTimeUtcNow;
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    픂.핁퓤 = 픂.핁픮.AddDays((double) -this.AutoDeletePeriod);
    // ISSUE: reference to a compiler-generated method
    this.Push(new Action(픂.퓏));
  }

  private void 핇()
  {
    if (this.핇픞 < 864000)
    {
      ++this.핇픞;
    }
    else
    {
      this.Push(new Action(this.퓬));
      this.핇픞 = 0;
    }
  }

  private bool 퓏([In] LoggingLevel obj0)
  {
    return this.CurrentLogLevel.HasFlag((Enum) obj0) || (LoggingLevel.System | LoggingLevel.Error | LoggingLevel.Trading).HasFlag((Enum) obj0);
  }

  private void 퓏([In] DateTime obj0, [In] string obj1, [In] string obj2)
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler1 = new DefaultInterpolatedStringHandler(4, 1);
    interpolatedStringHandler1.AppendFormatted<DateTime>(obj0, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픫());
    interpolatedStringHandler1.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핆());
    StringBuilder stringBuilder1 = new StringBuilder(interpolatedStringHandler1.ToStringAndClear());
    StringBuilder.AppendInterpolatedStringHandler interpolatedStringHandler2;
    if (!string.IsNullOrEmpty(obj1))
    {
      StringBuilder stringBuilder2 = stringBuilder1;
      StringBuilder stringBuilder3 = stringBuilder2;
      interpolatedStringHandler2 = new StringBuilder.AppendInterpolatedStringHandler(9, 1, stringBuilder2);
      interpolatedStringHandler2.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픯());
      interpolatedStringHandler2.AppendFormatted(obj1);
      ref StringBuilder.AppendInterpolatedStringHandler local = ref interpolatedStringHandler2;
      stringBuilder3.Append(ref local);
    }
    if (string.IsNullOrEmpty(obj2))
      return;
    StringBuilder stringBuilder4 = stringBuilder1;
    StringBuilder stringBuilder5 = stringBuilder4;
    interpolatedStringHandler2 = new StringBuilder.AppendInterpolatedStringHandler(11, 1, stringBuilder4);
    interpolatedStringHandler2.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓾());
    interpolatedStringHandler2.AppendFormatted(obj2);
    ref StringBuilder.AppendInterpolatedStringHandler local1 = ref interpolatedStringHandler2;
    stringBuilder5.Append(ref local1);
  }

  protected override void Process(Action subject)
  {
    if (subject == null)
      return;
    subject();
  }
}
