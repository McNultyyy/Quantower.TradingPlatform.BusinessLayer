// Decompiled with JetBrains decompiler
// Type: 퓏.퓞`2
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace 퓏;

internal class 퓞<퓏, 퓬> where 퓬 : IBufferedProcessorValue<퓏>
{
  private readonly Dictionary<퓏, List<Action<퓬>>> 핇퓨;
  private readonly object 핇퓱;

  public 퓞()
  {
    this.핇퓨 = new Dictionary<퓏, List<Action<퓬>>>();
    this.핇퓱 = new object();
  }

  public void 퓏([In] Action<퓬> obj0, params 퓏[] messagesTypes)
  {
    if (obj0 == null)
      return;
    lock (this.핇퓱)
    {
      foreach (퓏 messagesType in messagesTypes)
      {
        List<Action<퓬>> collection;
        if (this.핇퓨.TryGetValue(messagesType, out collection))
        {
          List<Action<퓬>> actionList = new List<Action<퓬>>((IEnumerable<Action<퓬>>) collection)
          {
            obj0
          };
          this.핇퓨[messagesType] = actionList;
        }
        else
          this.핇퓨.Add(messagesType, new List<Action<퓬>>()
          {
            obj0
          });
      }
    }
  }

  public void 퓬([In] Action<퓬> obj0, params 퓏[] messagesTypes)
  {
    if (obj0 == null)
      return;
    lock (this.핇퓱)
    {
      if (messagesTypes.Length == 0)
      {
        foreach (KeyValuePair<퓏, List<Action<퓬>>> keyValuePair in this.핇퓨)
          keyValuePair.Value.Remove(obj0);
      }
      else
      {
        foreach (퓏 messagesType in messagesTypes)
        {
          List<Action<퓬>> collection;
          if (this.핇퓨.TryGetValue(messagesType, out collection))
          {
            List<Action<퓬>> actionList = new List<Action<퓬>>((IEnumerable<Action<퓬>>) collection);
            actionList.Remove(obj0);
            this.핇퓨[messagesType] = actionList;
          }
        }
      }
    }
  }

  public void 퓏([In] 퓬 obj0)
  {
    List<Action<퓬>> actionList;
    lock (this.핇퓱)
      this.핇퓨.TryGetValue(obj0.Key, out actionList);
    if (actionList == null)
      return;
    foreach (Action<퓬> action in actionList)
    {
      try
      {
        action(obj0);
      }
      catch
      {
      }
    }
  }
}
