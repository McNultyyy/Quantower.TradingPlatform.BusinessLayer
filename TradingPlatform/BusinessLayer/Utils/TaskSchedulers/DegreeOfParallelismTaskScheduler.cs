// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.TaskSchedulers.DegreeOfParallelismTaskScheduler
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

#nullable enable
namespace TradingPlatform.BusinessLayer.Utils.TaskSchedulers;

public class DegreeOfParallelismTaskScheduler : TaskScheduler, IDisposable
{
  private 
  #nullable disable
  List<Task> 퓲픗;
  private readonly object 퓲퓰;
  private int 퓲픧;

  public sealed override int MaximumConcurrencyLevel { get; }

  public DegreeOfParallelismTaskScheduler(int maxDegreeOfParallelism)
  {
    this.MaximumConcurrencyLevel = maxDegreeOfParallelism >= 1 ? maxDegreeOfParallelism : throw new ArgumentOutOfRangeException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓍());
    this.퓲픗 = new List<Task>();
    this.퓲퓰 = new object();
    this.퓲픧 = 0;
  }

  protected sealed override void QueueTask(Task task)
  {
    lock (this.퓲퓰)
    {
      if (this.퓲픗 == null)
        return;
      this.퓲픗.Add(task);
      if (this.퓲픧 >= this.MaximumConcurrencyLevel)
        return;
      ++this.퓲픧;
    }
    ThreadPool.UnsafeQueueUserWorkItem((WaitCallback) delegate
    {
      try
      {
        Task task1;
        // ISSUE: reference to a compiler-generated method
        while (this.퓏(out task1))
        {
          try
          {
            if (task1 != null)
              this.TryExecuteTask(task1);
          }
          catch
          {
          }
        }
      }
      finally
      {
        --this.퓲픧;
      }
    }, (object) null);
  }

  protected sealed override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
  {
    if (!taskWasPreviouslyQueued)
      return this.TryExecuteTask(task);
    return this.TryDequeue(task) && this.TryExecuteTask(task);
  }

  protected sealed override bool TryDequeue(Task task)
  {
    lock (this.퓲퓰)
    {
      List<Task> 퓲픗 = this.퓲픗;
      // ISSUE: explicit non-virtual call
      return 퓲픗 != null && __nonvirtual (퓲픗.Remove(task));
    }
  }

  protected sealed override IEnumerable<Task> GetScheduledTasks()
  {
    List<Task> 퓲픗 = this.퓲픗;
    return 퓲픗 == null ? (IEnumerable<Task>) null : (IEnumerable<Task>) 퓲픗.ToArray();
  }

  public void Dispose()
  {
    lock (this.퓲퓰)
      this.퓲픗 = (List<Task>) null;
  }
}
