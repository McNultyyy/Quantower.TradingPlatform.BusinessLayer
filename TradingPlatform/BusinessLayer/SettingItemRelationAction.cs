// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemRelationAction
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

#nullable enable
namespace TradingPlatform.BusinessLayer;

public class SettingItemRelationAction : SettingItemRelation
{
  private readonly 
  #nullable disable
  IDictionary<string, SettingItemRelationCallback> 픁퓳;

  public SettingItemRelationAction(
    IDictionary<string, SettingItemRelationCallback> callbacks)
    : base((IDictionary<string, IEnumerable<object>>) callbacks.ToDictionary<KeyValuePair<string, SettingItemRelationCallback>, string, IEnumerable<object>>((Func<KeyValuePair<string, SettingItemRelationCallback>, string>) (([In] obj0) => obj0.Key), (Func<KeyValuePair<string, SettingItemRelationCallback>, IEnumerable<object>>) delegate
    {
      return Enumerable.Empty<object>();
    }))
  {
    this.픁퓳 = callbacks;
    this.RelationDelegate = new SettingItemRelationDelegate(this.퓏);
  }

  private bool 퓏([In] SettingItemRelationParameters obj0)
  {
    SettingItemRelationCallback relationCallback;
    if (!this.픁퓳.TryGetValue(obj0.ChangedItem.Name, out relationCallback))
      return false;
    try
    {
      return relationCallback(obj0.ChangedItem, obj0.DependentItem);
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
    return false;
  }
}
