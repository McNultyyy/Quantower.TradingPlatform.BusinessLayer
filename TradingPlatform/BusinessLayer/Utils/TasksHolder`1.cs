// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.TasksHolder`1
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils;

public class TasksHolder<TTask>
{
  private readonly List<QueueObj<TTask>>[] 핇픹;

  public int Count
  {
    get
    {
      return ((IEnumerable<List<QueueObj<TTask>>>) this.핇픹).Sum<List<QueueObj<TTask>>>((Func<List<QueueObj<TTask>>, int>) (([In] obj0) => obj0.Count));
    }
  }

  /// <summary>
  /// 
  /// </summary>
  public TasksHolder(int prioritiesCount)
  {
    this.핇픹 = new List<QueueObj<TTask>>[prioritiesCount];
    for (int index = 0; index < this.핇픹.Length; ++index)
      this.핇픹[index] = new List<QueueObj<TTask>>();
  }

  public void Enqueue(TTask task, int priority, string marker)
  {
    if (priority >= this.핇픹.Length)
      throw new Exception(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픈());
    QueueObj<TTask> queueObj = new QueueObj<TTask>(task, marker);
    lock (this.핇픹)
      this.핇픹[priority].Add(queueObj);
  }

  public QueueObj<TTask> Dequeue(HashSet<string> markersAtWork)
  {
    QueueObj<TTask> queueObj1 = (QueueObj<TTask>) null;
    lock (this.핇픹)
    {
      foreach (List<QueueObj<TTask>> queueObjList in this.핇픹)
      {
        foreach (QueueObj<TTask> queueObj2 in queueObjList)
        {
          if (!markersAtWork.Contains(queueObj2.Marker))
          {
            queueObj1 = queueObj2;
            queueObjList.Remove(queueObj2);
            break;
          }
        }
        if (queueObj1 != null)
          break;
      }
    }
    return queueObj1;
  }

  internal void 퓏()
  {
    for (int index = 0; index < this.핇픹.Length; ++index)
      this.핇픹[index].Clear();
  }
}
