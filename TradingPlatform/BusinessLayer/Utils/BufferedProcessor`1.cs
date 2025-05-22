// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.BufferedProcessor`1
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

#nullable enable
namespace TradingPlatform.BusinessLayer.Utils;

/// <summary>The buffered processor.</summary>
/// <typeparam name="T"></typeparam>
public abstract class BufferedProcessor<T>
{
  protected int ProcessTreadsCount;
  private 
  #nullable disable
  CancellationTokenSource 핇픭;
  private readonly Queue<T> 핇픔;
  private readonly object 핇핈;
  private readonly ManualResetEventSlim 핇픤;
  private readonly HashSet<int> 핇퓟;

  public event Action<Exception> ExceptionOccurred;

  /// <summary>Gets the state.</summary>
  public BufferedProcessorState State { get; [param: In] private set; }

  /// <summary>Gets the queue depth.</summary>
  public int QueueDepth => this.핇픔.Count;

  protected BufferedProcessor()
  {
    this.ProcessTreadsCount = 1;
    this.핇픔 = new Queue<T>();
    this.핇핈 = new object();
    this.핇픤 = new ManualResetEventSlim(false);
    this.핇퓟 = new HashSet<int>();
    this.State = BufferedProcessorState.Created;
  }

  /// <summary>
  /// 
  /// </summary>
  public virtual void Start()
  {
    this.핇픭 = new CancellationTokenSource();
    if (this.ProcessTreadsCount == 1)
      Task.Factory.StartNew(new Action(this.퓏), this.핇픭.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
    else
      Task.Factory.StartNew(new Action(this.퓬), this.핇픭.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
    this.State = BufferedProcessorState.Started;
  }

  /// <summary>
  /// 
  /// </summary>
  public virtual void Stop()
  {
    lock (this.핇핈)
    {
      this.핇픭?.Cancel();
      this.Clear();
      this.핇픤.Set();
      this.State = BufferedProcessorState.Stopped;
    }
  }

  /// <summary>
  /// 
  /// </summary>
  /// <param name="subject">The subject.</param>
  public virtual void Push(T subject)
  {
    lock (this.핇핈)
    {
      this.핇픔.Enqueue(subject);
      this.핇픤.Set();
    }
  }

  private void 퓏()
  {
    CancellationToken token = this.핇픭.Token;
    while (true)
    {
      try
      {
        if (token.IsCancellationRequested)
          break;
        this.핇픤.Wait(token);
        if (token.IsCancellationRequested)
          break;
        while (this.핇픔.Count > 0)
        {
          if (token.IsCancellationRequested)
            return;
          try
          {
            T obj = default (T);
            lock (this.핇핈)
            {
              this.State = BufferedProcessorState.ProcessSubject;
              obj = this.핇픔.Dequeue();
            }
            this.Process(obj);
          }
          catch (Exception ex)
          {
            this.퓏(ex.InnerException ?? ex);
          }
          finally
          {
            this.State = BufferedProcessorState.Started;
          }
        }
      }
      catch (Exception ex)
      {
        this.퓏(ex.InnerException ?? ex);
      }
      finally
      {
        lock (this.핇핈)
        {
          if (this.핇픔.Count == 0)
            this.핇픤.Reset();
        }
      }
    }
  }

  private void 퓬()
  {
    CancellationToken token = this.핇픭.Token;
label_1:
    while (true)
    {
      try
      {
        if (token.IsCancellationRequested)
          break;
        this.핇픤.Wait(token);
        if (token.IsCancellationRequested)
          break;
        while (true)
        {
          // ISSUE: variable of a compiler-generated type
          BufferedProcessor<T>.퓏\u00601 퓏;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          do
          {
            if (this.핇픔.Count > 0)
            {
              if (this.핇퓟.Count < this.ProcessTreadsCount)
              {
                // ISSUE: object of a compiler-generated type is created
                퓏 = new BufferedProcessor<T>.퓏\u00601();
                // ISSUE: reference to a compiler-generated field
                퓏.픇핂 = this;
                if (!token.IsCancellationRequested)
                {
                  // ISSUE: reference to a compiler-generated field
                  퓏.픇핇 = default (T);
                  lock (this.핇핈)
                  {
                    // ISSUE: reference to a compiler-generated field
                    퓏.픇핇 = this.핇픔.Dequeue();
                  }
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated method
                  퓏.픇퓲 = Task.Factory.StartNew(new Action(퓏.퓏));
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated method
                  퓏.픇퓲.ContinueWith(new Action<Task>(퓏.퓏));
                }
                else
                  goto label_4;
              }
              else
                goto label_1;
            }
            else
              goto label_1;
          }
          while (퓏.픇퓲.Status == TaskStatus.RanToCompletion || 퓏.픇퓲.Status == TaskStatus.Canceled || 퓏.픇퓲.Status == TaskStatus.Faulted);
          // ISSUE: reference to a compiler-generated field
          this.핇퓟.Add(퓏.픇퓲.Id);
        }
label_4:
        break;
      }
      catch (Exception ex)
      {
        this.퓏(ex.InnerException ?? ex);
      }
      finally
      {
        this.핇픤.Reset();
      }
    }
  }

  private void 퓏([In] Exception obj0)
  {
    // ISSUE: reference to a compiler-generated field
    Action<Exception> 핇퓕 = this.핇퓕;
    if (핇퓕 == null)
      return;
    핇퓕(obj0);
  }

  [Obfuscation(Exclude = false)]
  protected abstract void Process([In] T obj0);

  protected internal virtual void Clear() => this.핇픔?.Clear();

  /// <summary>Wait all messages process.</summary>
  /// <param name="externalToken">The external token.</param>
  public void WaitAllMessagesProcess(CancellationToken? externalToken = null)
  {
    // ISSUE: variable of a compiler-generated type
    BufferedProcessor<T>.퓬\u00601 퓬;
    // ISSUE: reference to a compiler-generated field
    퓬.픇픂 = this;
    // ISSUE: reference to a compiler-generated field
    퓬.픇픾 = externalToken;
    // ISSUE: reference to a compiler-generated method
    if (this.퓏(ref 퓬))
      return;
    // ISSUE: reference to a compiler-generated method
    do
    {
      lock (this.핇핈)
      {
        if (this.QueueDepth <= 0)
        {
          if (this.State != BufferedProcessorState.ProcessSubject)
            break;
        }
      }
    }
    while (!this.퓏(ref 퓬));
  }
}
