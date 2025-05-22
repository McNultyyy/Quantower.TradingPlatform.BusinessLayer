// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Strategy
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;
using TradingPlatform.BusinessLayer.Utils;

#nullable enable
namespace TradingPlatform.BusinessLayer;

/// <summary>The base class for strategies</summary>
[Published]
public abstract class Strategy : ExecutionEntity, IXElementSerialization, IConnectionStateDependent
{
  private StrategyState 퓯퓩;
  private 
  #nullable disable
  ILogger 퓯픊;
  private DateTime 퓯픈;
  private DateTime 퓯퓒;
  private Meter 퓯퓚;
  private readonly ConnectionStateObserver 퓯픃;
  private StrategyState? 퓯퓎;

  /// <summary>Unique ID of the strategy</summary>
  public string Id { get; [param: In] internal set; }

  /// <summary>The current state of the strategy</summary>
  public StrategyState State
  {
    get => this.퓯퓩;
    [param: In] internal set
    {
      StrategyState 퓯퓩 = this.퓯퓩;
      this.퓯퓩 = value;
      Core.Instance.Strategies.퓏(this, this.퓯퓩, 퓯퓩);
    }
  }

  public string InstanceName { get; set; }

  public override IList<SettingItem> Settings
  {
    get
    {
      IList<SettingItem> settings = base.Settings;
      SettingItemString settingItemString = new SettingItemString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픙(), this.InstanceName);
      settingItemString.Text = loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓭(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓣());
      settingItemString.SeparatorGroup = new SettingItemSeparatorGroup(loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픦(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓣()), -1100);
      settings.Add((SettingItem) settingItemString);
      return settings;
    }
    set
    {
      string str;
      if (value.TryGetValue<string>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픙(), out str))
        this.InstanceName = str;
      if (this.State == StrategyState.Working)
        throw new InvalidOperationException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픍());
      base.Settings = value;
      Action<Strategy> 퓯픹 = this.퓯픹;
      if (퓯픹 == null)
        return;
      퓯픹(this);
    }
  }

  /// <summary>Event occured when strategy write a new log</summary>
  public event StrategyEventHandler NewLog;

  /// <summary>Event occured if any of strategy settings was changed</summary>
  public event Action<Strategy> SettingsChanged;

  public bool NewVersionAvailable { get; [param: In] internal set; }

  public virtual string[] MonitoringConnectionsIds => new string[0];

  internal void 퓏()
  {
    this.CheckDisposed();
    string dataFolderPath = this.DataFolderPath;
    if (!Directory.Exists(dataFolderPath))
      Directory.CreateDirectory(dataFolderPath);
    this.퓯픊 = Core.Instance.Loggers.GetLogger(new LoggerConfig()
    {
      LoggerName = this.DataFolderName,
      OutputFolderPath = Path.Combine(this.DataFolderPath, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픆()),
      Scope = LoggerScope.General
    });
    try
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
      interpolatedStringHandler.AppendFormatted(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픅());
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픻());
      interpolatedStringHandler.AppendFormatted<ScriptKey>(this.Key);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픻());
      interpolatedStringHandler.AppendFormatted(this.Id);
      this.퓯퓚 = new Meter(interpolatedStringHandler.ToStringAndClear(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픠());
      this.OnInitializeMetrics(this.퓯퓚);
    }
    catch (Exception ex)
    {
      this.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓮() + (ex.InnerException?.Message ?? ex.Message), StrategyLoggingLevel.Error);
      Core.Instance.Loggers.Log(ex, this.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픕());
    }
    this.State = StrategyState.Created;
    try
    {
      this.OnCreated();
      this.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픱());
    }
    catch (Exception ex)
    {
      this.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓮() + (ex.InnerException?.Message ?? ex.Message), StrategyLoggingLevel.Error);
      Core.Instance.Loggers.Log(ex, this.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픶());
    }
  }

  /// <summary>Run strategy</summary>
  public void Run()
  {
    this.CheckDisposed();
    if (this.State == StrategyState.Working)
      return;
    string[] monitoringConnectionsIds = this.MonitoringConnectionsIds;
    if (monitoringConnectionsIds != null)
    {
      foreach (string id in monitoringConnectionsIds)
      {
        if (id != null)
        {
          Connection connection = Core.Instance.Connections[id];
          if (connection == null || connection.State != ConnectionState.Connected)
          {
            this.State = StrategyState.WaitingForConnection;
            return;
          }
        }
      }
    }
    this.State = StrategyState.Working;
    this.퓯픈 = Core.Instance.TimeUtils.DateTimeUtcNow;
    try
    {
      this.OnRun();
      this.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픀());
    }
    catch (Exception ex)
    {
      this.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픖() + (ex.InnerException?.Message ?? ex.Message), StrategyLoggingLevel.Error);
      Core.Instance.Loggers.Log(ex, this.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓘());
    }
  }

  /// <summary>Stop strategy</summary>
  public void Stop()
  {
    this.CheckDisposed();
    if (this.State != StrategyState.Working && this.State != StrategyState.WaitingForConnection)
      return;
    int num = this.State != StrategyState.WaitingForConnection ? 1 : 0;
    this.State = StrategyState.Stopped;
    this.퓯퓒 = Core.Instance.TimeUtils.DateTimeUtcNow;
    if (num == 0)
      return;
    try
    {
      this.OnStop();
      this.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픓());
    }
    catch (Exception ex)
    {
      this.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픩() + (ex.InnerException?.Message ?? ex.Message), StrategyLoggingLevel.Error);
      Core.Instance.Loggers.Log(ex, this.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙필());
    }
  }

  /// <summary>Remove the strategy</summary>
  public void Remove()
  {
    this.CheckDisposed();
    if (this.State == StrategyState.Removed)
      return;
    if (this.State == StrategyState.Working)
      this.Stop();
    try
    {
      string dataFolderPath = this.DataFolderPath;
      if (Directory.Exists(dataFolderPath))
        Directory.Delete(dataFolderPath, true);
    }
    catch (Exception ex)
    {
      this.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓖() + ex.GetFullMessageRecursive(), StrategyLoggingLevel.Error);
      Core.Instance.Loggers.Log(ex, this.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픵());
    }
    this.State = StrategyState.Removed;
    try
    {
      this.OnRemove();
      this.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픬());
    }
    catch (Exception ex)
    {
      this.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓕() + (ex.InnerException?.Message ?? ex.Message), StrategyLoggingLevel.Error);
      Core.Instance.Loggers.Log(ex, this.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픵());
    }
    finally
    {
      this.퓯픊?.Dispose();
      this.퓯픊 = (ILogger) null;
    }
  }

  /// <summary>Get current metrics from the strategy</summary>
  /// <returns></returns>
  public List<StrategyMetric> GetMetrics()
  {
    this.CheckDisposed();
    List<StrategyMetric> metrics = (List<StrategyMetric>) null;
    try
    {
      metrics = this.OnGetMetrics();
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex, this.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픐());
    }
    return metrics;
  }

  /// <summary>Get logs from the strategy for specified date range</summary>
  /// <param name="from"></param>
  /// <param name="to"></param>
  /// <returns></returns>
  public LoggerEvent[] GetLogs(DateTime from, DateTime to)
  {
    ILogger 퓯픊 = this.퓯픊;
    LoggerEvent[] loggerEventArray;
    if (퓯픊 == null)
    {
      loggerEventArray = (LoggerEvent[]) null;
    }
    else
    {
      List<LoggerEvent> history = 퓯픊.GetHistory(from, to);
      loggerEventArray = history != null ? history.OfType<LoggerEvent>().ToArray<LoggerEvent>() : (LoggerEvent[]) null;
    }
    return loggerEventArray ?? Array.Empty<LoggerEvent>();
  }

  protected virtual void OnCreated()
  {
  }

  protected virtual void OnRun()
  {
  }

  protected virtual void OnStop()
  {
  }

  protected virtual void OnRemove()
  {
  }

  [Obsolete("Use OnInitializeMetrics() method to initialize System.Diagnostics.Metrics")]
  protected virtual List<StrategyMetric> OnGetMetrics()
  {
    List<StrategyMetric> metrics = new List<StrategyMetric>();
    string name1 = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픭();
    DateTime dateTime1;
    string formattedValue1;
    if (!(this.퓯픈 == new DateTime()))
    {
      dateTime1 = ExecutionEntity.Core.TimeUtils.ConvertFromUTCToSelectedTimeZone(this.퓯픈);
      formattedValue1 = dateTime1.ToString();
    }
    else
      formattedValue1 = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓯();
    StrategyMetricExtensions.Add(metrics, name1, formattedValue1);
    string name2 = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픔();
    DateTime 퓯픈 = this.퓯픈;
    dateTime1 = new DateTime();
    DateTime dateTime2 = dateTime1;
    string formattedValue2 = 퓯픈 == dateTime2 ? \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓯() : (this.State == StrategyState.Working ? (Core.Instance.TimeUtils.DateTimeUtcNow - this.퓯픈).ToString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙핈()) : (this.퓯퓒 - this.퓯픈).ToString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙핈()));
    StrategyMetricExtensions.Add(metrics, name2, formattedValue2);
    return metrics;
  }

  protected virtual void OnInitializeMetrics(Meter meter)
  {
  }

  /// <summary>Write log message</summary>
  /// <param name="message"></param>
  /// <param name="level"></param>
  protected internal void Log(string message, StrategyLoggingLevel level = StrategyLoggingLevel.Info)
  {
    DateTime dateTimeUtcNow = Core.Instance.TimeUtils.DateTimeUtcNow;
    LoggingLevel loggingLevel;
    switch (level)
    {
      case StrategyLoggingLevel.Trading:
        loggingLevel = LoggingLevel.Trading;
        break;
      case StrategyLoggingLevel.Error:
        loggingLevel = LoggingLevel.Error;
        break;
      default:
        loggingLevel = LoggingLevel.System;
        break;
    }
    LoggingLevel level1 = loggingLevel;
    this.퓯픊?.Log(message, dateTimeUtcNow, level1);
    // ISSUE: reference to a compiler-generated field
    if (this.퓯퓱 == null)
      return;
    this.퓏(new LoggerEvent()
    {
      Date = dateTimeUtcNow,
      Event = message,
      Type = level1
    });
  }

  [NotPublished]
  public override void Dispose()
  {
    this.퓯픃.Dispose();
    this.퓯퓚?.Dispose();
    if (this.State == StrategyState.Working)
      this.Stop();
    base.Dispose();
  }

  private string DataFolderName
  {
    get
    {
      return this.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓓() + this.Id + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픗();
    }
  }

  internal string DataFolderPath => Path.Combine(Const.SCRIPTS_DATA_PATH, this.DataFolderName);

  protected Strategy()
  {
    this.Id = Guid.NewGuid().ToString();
    this.퓯픃 = new ConnectionStateObserver((IConnectionStateDependent) this, ConnectionStateObserverPriority.Normal, new ConnectionState[3]
    {
      ConnectionState.Connected,
      ConnectionState.Disconnected,
      ConnectionState.ConnectionLost
    });
  }

  private void 퓏([In] LoggerEvent obj0)
  {
    // ISSUE: reference to a compiler-generated field
    StrategyEventHandler 퓯퓱 = this.퓯퓱;
    if (퓯퓱 == null)
      return;
    퓯퓱(this, new StrategyEventArgs(this.State, obj0));
  }

  [NotPublished]
  public XElement ToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓵());
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픥(), (object) this.Key.ToString()));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓶(), (object) this.Id));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픜(), (object) this.Name));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓼(), (object) this.GetType().Name));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픤(), (object) (int) this.State));
    XElement content = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓱());
    foreach (SettingItem setting in (IEnumerable<SettingItem>) this.Settings)
      content.Add((object) setting.ToXElement());
    xelement.Add((object) content);
    return xelement;
  }

  [NotPublished]
  public void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    this.Key = ScriptKey.CreateScriptKeyFromString(element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픥())?.Value);
    this.Id = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓶())?.Value;
    this.Name = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픜())?.Value;
    XElement element1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓱());
    if (element1 != null)
      this.Settings = (IList<SettingItem>) Serializer.DeserializeXML(element1, deserializationInfo).OfType<SettingItem>().ToList<SettingItem>();
    XElement element2 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픤());
    this.퓯퓎 = new StrategyState?(element2 != null ? (StrategyState) element2.ToInt() : StrategyState.Created);
  }

  internal void 퓬()
  {
    StrategyState? 퓯퓎 = this.퓯퓎;
    bool flag;
    if (퓯퓎.HasValue)
    {
      switch (퓯퓎.GetValueOrDefault())
      {
        case StrategyState.Working:
        case StrategyState.WaitingForConnection:
          flag = true;
          goto label_4;
      }
    }
    flag = false;
label_4:
    if (flag)
      Task.Factory.StartNew(new Action(this.Run));
    this.퓯퓎 = new StrategyState?();
  }

  public ConnectionDependency GetConnectionStateDependency()
  {
    return new ConnectionDependency()
    {
      Behavior = ConnectionDependencyBehavior.PartialDependency,
      DependentConnectionsIds = this.MonitoringConnectionsIds
    };
  }

  void IConnectionStateDependent.퓏([In] Connection obj0, [In] ConnectionStateChangedEventArgs obj1)
  {
    if (obj1.NewState == ConnectionState.Connected)
    {
      if (this.State != StrategyState.WaitingForConnection)
        return;
      Task.Factory.StartNew(new Action(this.Run));
    }
    else
    {
      if (this.State != StrategyState.Working)
        return;
      Task.Factory.StartNew(new Action(this.Stop)).ContinueWith<StrategyState>((Func<Task, StrategyState>) delegate
      {
        return this.State = StrategyState.WaitingForConnection;
      });
    }
  }
}
