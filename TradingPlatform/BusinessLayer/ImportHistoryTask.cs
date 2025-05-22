// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.ImportHistoryTask
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public sealed class ImportHistoryTask : IHistoryProcessingTask, IDisposable
{
  private HistoryTaskStateEnum 픂픜;
  private int 픂퓞;
  private string 픂핅;
  private readonly IHistoryDataProvider 픂픡;
  private readonly IHistoryDataReceiver 픂픏;
  private CancellationTokenSource 픂퓳;

  public event Action<HistoryTaskStateEnum> TaskStateChanged;

  public HistoryTaskStateEnum TaskState
  {
    get => this.픂픜;
    [param: In] private set
    {
      if (this.픂픜 == HistoryTaskStateEnum.Completed)
        return;
      this.픂픜 = value;
      switch (this.픂픜)
      {
        case HistoryTaskStateEnum.Stopped:
          this.픂퓳.Cancel();
          break;
        case HistoryTaskStateEnum.Active:
          this.퓏();
          break;
        case HistoryTaskStateEnum.Completed:
          this.픂핅 = string.Empty;
          break;
      }
      Action<HistoryTaskStateEnum> 픂퓯 = this.픂퓯;
      if (픂퓯 == null)
        return;
      픂퓯(this.픂픜);
    }
  }

  public string Description { get; set; }

  public event Action<string> ProgressChanged;

  public string ProgressValue
  {
    get
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 1);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픒());
      interpolatedStringHandler.AppendFormatted<int>(this.픂퓞);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓷());
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      return string.IsNullOrEmpty(this.픂핅) ? stringAndClear : stringAndClear + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픆() + this.픂핅;
    }
  }

  public ImportHistoryTask(
    IHistoryDataProvider historyDataProvider,
    IHistoryDataReceiver historyDataReceiver)
  {
    this.픂픡 = historyDataProvider;
    this.픂픏 = historyDataReceiver;
  }

  public void Dispose()
  {
    if (this.픂퓳 == null)
      return;
    this.픂퓳.Cancel();
    this.픂퓳.Dispose();
    this.픂퓳 = (CancellationTokenSource) null;
  }

  public void Start() => this.TaskState = HistoryTaskStateEnum.Active;

  public void Stop() => this.TaskState = HistoryTaskStateEnum.Stopped;

  private void 퓏()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    ImportHistoryTask.퓏 퓏 = new ImportHistoryTask.퓏();
    // ISSUE: reference to a compiler-generated field
    퓏.퓗퓺 = this;
    this.픂퓳 = new CancellationTokenSource();
    // ISSUE: reference to a compiler-generated field
    퓏.퓗픹 = this.픂퓳.Token;
    this.픂픡.ProgressChanged += new Action<string>(this.퓏);
    this.픂퓞 = 0;
    // ISSUE: reference to a compiler-generated field
    Action<string> 픂핋 = this.픂핋;
    if (픂핋 != null)
      픂핋(this.ProgressValue);
    // ISSUE: reference to a compiler-generated method
    // ISSUE: reference to a compiler-generated field
    Task.Factory.StartNew(new Action(퓏.퓏), 퓏.퓗픹);
  }

  private void 퓏([In] string obj0)
  {
    this.픂핅 = obj0;
    // ISSUE: reference to a compiler-generated field
    Action<string> 픂핋 = this.픂핋;
    if (픂핋 == null)
      return;
    픂핋(this.ProgressValue);
  }
}
