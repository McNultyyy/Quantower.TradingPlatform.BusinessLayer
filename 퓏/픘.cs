// Decompiled with JetBrains decompiler
// Type: 퓏.픘
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Collections.Generic;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer;

#nullable disable
namespace 퓏;

internal class 픘([In] string obj0, params object[] relationValues) : SettingItemRelation((IDictionary<string, IEnumerable<object>>) new Dictionary<string, IEnumerable<object>>()
{
  {
    obj0,
    (IEnumerable<object>) new List<object>((IEnumerable<object>) relationValues)
  }
}, 픘.퓏.픎퓞 ?? (픘.퓏.픎퓞 = new SettingItemRelationDelegate(픘.퓏)))
{
  private static bool 퓏([In] SettingItemRelationParameters obj0)
  {
    SettingItemRelation.CheckVisibilityRelation(obj0);
    if (!SettingItemRelation.CheckValues(obj0.RelationValuesByParentItem, obj0.MultipleRelationCondition) || !(obj0.DependentItem is SettingItemDateTime dependentItem))
      return false;
    int num = obj0.ChangedItem.GetValue<TimeInForce>() == TimeInForce.GTD ? 0 : 1;
    dependentItem.Format = (DatePickerFormat) num;
    return true;
  }
}
