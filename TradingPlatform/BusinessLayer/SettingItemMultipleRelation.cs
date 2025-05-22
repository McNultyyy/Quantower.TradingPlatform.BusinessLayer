// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemMultipleRelation
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

public class SettingItemMultipleRelation : SettingItemRelation
{
  private readonly 
  #nullable disable
  List<SettingItemRelation> 픁퓞;

  public SettingItemMultipleRelation(params SettingItemRelation[] relations)
    : base((IDictionary<string, IEnumerable<object>>) ((IEnumerable<SettingItemRelation>) relations).SelectMany<SettingItemRelation, KeyValuePair<string, IEnumerable<object>>>((Func<SettingItemRelation, IEnumerable<KeyValuePair<string, IEnumerable<object>>>>) (([In] obj0) => (IEnumerable<KeyValuePair<string, IEnumerable<object>>>) obj0.퓬픝)).ToDictionary<KeyValuePair<string, IEnumerable<object>>, string, IEnumerable<object>>((Func<KeyValuePair<string, IEnumerable<object>>, string>) (([In] obj0) => obj0.Key), (Func<KeyValuePair<string, IEnumerable<object>>, IEnumerable<object>>) (([In] obj0) => obj0.Value)))
  {
    this.픁퓞 = ((IEnumerable<SettingItemRelation>) relations).ToList<SettingItemRelation>();
  }

  public void AddRelation(SettingItemRelation relation)
  {
    foreach (KeyValuePair<string, IEnumerable<object>> keyValuePair in (IEnumerable<KeyValuePair<string, IEnumerable<object>>>) relation.퓬픝)
      this.퓬픝.Add(keyValuePair.Key, keyValuePair.Value);
    this.픁퓞.Add(relation);
  }

  public void InsertRelation(int index, SettingItemRelation relation)
  {
    foreach (KeyValuePair<string, IEnumerable<object>> keyValuePair in (IEnumerable<KeyValuePair<string, IEnumerable<object>>>) relation.퓬픝)
      this.퓬픝.Add(keyValuePair.Key, keyValuePair.Value);
    this.픁퓞.Insert(0, relation);
  }

  public override bool CheckRelation(
    SettingItem dependentItem,
    SettingItem changedItem,
    bool isPopulating,
    params SettingItem[] parentItems)
  {
    bool flag = false;
    foreach (SettingItemRelation settingItemRelation in this.픁퓞)
    {
      if (this.MultipleRelationCondition == MultipleRelationCondition.IfAll)
        flag &= settingItemRelation.CheckRelation(dependentItem, changedItem, isPopulating, parentItems);
      else
        flag |= settingItemRelation.CheckRelation(dependentItem, changedItem, isPopulating, parentItems);
    }
    return flag;
  }
}
