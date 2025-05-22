// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.BufferedProcessorWithPriority`1
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using TradingPlatform.BusinessLayer.Utils.Extensions;

#nullable enable
namespace TradingPlatform.BusinessLayer.Utils;

public abstract class BufferedProcessorWithPriority<T>
{
  private readonly 
  #nullable disable
  TasksHolder<T> 핇핉;
  private readonly object 핇핊;
  private readonly ManualResetEvent 핇픛;
  private CancellationTokenSource 핇퓜;
  protected int ProcessTreadsCount;
  private readonly HashSet<int> 핇퓫;
  private readonly HashSet<string> 핇핌;
  private readonly string 핇퓩;

  internal bool Started { get; [param: In] private set; }

  internal bool ProcessMessageNow { get; [param: In] private set; }

  protected BufferedProcessorWithPriority(int threadsCount = 1)
  {
    this.핇퓩 = Guid.NewGuid().ToShortString();
    this.ProcessTreadsCount = threadsCount;
    this.핇핉 = new TasksHolder<T>(2);
    this.핇핊 = new object();
    this.핇픛 = new ManualResetEvent(false);
    this.핇퓫 = new HashSet<int>();
    this.핇핌 = new HashSet<string>();
  }

  public void Start()
  {
    this.핇퓜 = new CancellationTokenSource();
    Task.Factory.StartNew(new Action(this.퓏), this.핇퓜.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
    this.Started = true;
  }

  public virtual void Stop()
  {
    lock (this.핇핊)
    {
      this.핇퓜?.Cancel();
      this.Clear();
      this.핇픛.Set();
      this.Started = false;
    }
  }

  protected virtual void Clear() => this.핇핉?.퓏();

  private void 퓏()
  {
label_0:
    while (true)
    {
      try
      {
        this.핇픛.WaitOne();
        this.핇픛.Reset();
        CancellationTokenSource 핇퓜1 = this.핇퓜;
        if ((핇퓜1 != null ? (핇퓜1.IsCancellationRequested ? 1 : 0) : 0) != 0)
          break;
        while (true)
        {
          // ISSUE: variable of a compiler-generated type
          BufferedProcessorWithPriority<T>.퓏\u00601 퓏;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          do
          {
            if (this.핇핉.Count > 0)
            {
              if (this.핇퓫.Count < this.ProcessTreadsCount)
              {
                // ISSUE: object of a compiler-generated type is created
                퓏 = new BufferedProcessorWithPriority<T>.퓏\u00601();
                // ISSUE: reference to a compiler-generated field
                퓏.픇픞 = this;
                CancellationTokenSource 핇퓜2 = this.핇퓜;
                if ((핇퓜2 != null ? (핇퓜2.IsCancellationRequested ? 1 : 0) : 0) == 0)
                {
                  // ISSUE: reference to a compiler-generated field
                  퓏.픇퓍 = (QueueObj<T>) null;
                  lock (this.핇핊)
                  {
                    // ISSUE: reference to a compiler-generated field
                    퓏.픇퓍 = this.핇핉.Dequeue(this.핇핌);
                    // ISSUE: reference to a compiler-generated field
                    if (퓏.픇퓍 != null)
                    {
                      // ISSUE: reference to a compiler-generated field
                      this.핇핌.Add(퓏.픇퓍.Marker);
                    }
                    else
                      goto label_0;
                  }
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated method
                  퓏.픇픁 = Task.Factory.StartNew(new Action(퓏.퓏));
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated method
                  퓏.픇픁.ContinueWith(new Action<Task>(퓏.퓏));
                }
                else
                  goto label_5;
              }
              else
                goto label_0;
            }
            else
              goto label_0;
          }
          while (퓏.픇픁.Status == TaskStatus.RanToCompletion || 퓏.픇픁.Status == TaskStatus.Canceled || 퓏.픇픁.Status == TaskStatus.Faulted);
          // ISSUE: reference to a compiler-generated field
          this.핇퓫.Add(퓏.픇픁.Id);
        }
label_5:
        break;
      }
      catch (Exception ex)
      {
        Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓺() + ex.Message, LoggingLevel.Verbose);
      }
    }
  }

  public void Push(T subject, int priority, string marker)
  {
    if (Thread.CurrentThread.Name == this.핇퓩)
    {
      try
      {
        this.Process(subject);
      }
      catch (Exception ex)
      {
        Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픊() + ex.Message, LoggingLevel.Verbose);
      }
    }
    else
    {
      lock (this.핇핊)
        this.핇핉.Enqueue(subject, priority, marker);
      this.핇픛.Set();
    }
  }

  [Obfuscation(Exclude = false)]
  protected abstract void Process([In] T obj0);
}
