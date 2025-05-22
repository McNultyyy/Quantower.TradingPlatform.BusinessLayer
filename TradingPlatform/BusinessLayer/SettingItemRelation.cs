// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemRelation
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public class SettingItemRelation
{
  internal readonly IDictionary<string, IEnumerable<object>> 퓬픝;
  protected SettingItemRelationDelegate RelationDelegate;

  public string[] ParentSettingsNames => this.퓬픝.Keys.ToArray<string>();

  public MultipleRelationCondition MultipleRelationCondition { get; set; }

  public SettingItemRelation(
    IDictionary<string, IEnumerable<object>> relationValuesByParentItemName,
    SettingItemRelationDelegate relationDelegate = null)
  {
    if (relationValuesByParentItemName.Keys.Count == 0)
      throw new ArgumentException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓴());
    this.RelationDelegate = relationDelegate;
    this.퓬픝 = relationValuesByParentItemName;
    this.MultipleRelationCondition = MultipleRelationCondition.IfAny;
  }

  public virtual bool CheckRelation(
    SettingItem dependentItem,
    SettingItem changedItem,
    bool isPopulating,
    params SettingItem[] parentItems)
  {
    if (dependentItem == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픳());
    if (parentItems.Length == 0)
      throw new AggregateException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픙());
    SettingItemRelationParameters relationParameters = new SettingItemRelationParameters()
    {
      DependentItem = dependentItem,
      ChangedItem = changedItem,
      RelationValuesByParentItem = (IDictionary<SettingItem, IEnumerable<object>>) new Dictionary<SettingItem, IEnumerable<object>>(),
      MultipleRelationCondition = this.MultipleRelationCondition,
      IsPopulating = isPopulating
    };
    foreach (SettingItem parentItem in parentItems)
    {
      IEnumerable<object> objects;
      if (this.퓬픝.TryGetValue(parentItem.Name, out objects) && !relationParameters.RelationValuesByParentItem.ContainsKey(parentItem))
        relationParameters.RelationValuesByParentItem.Add(parentItem, objects);
    }
    return this.RelationDelegate(relationParameters);
  }

  protected static bool CheckEnabilityRelation(SettingItemRelationParameters relationParameters)
  {
    SettingItem dependentItem = relationParameters.DependentItem;
    bool flag1 = SettingItemRelation.CheckValues(relationParameters.RelationValuesByParentItem, relationParameters.MultipleRelationCondition);
    bool flag2 = dependentItem.Enabled != flag1;
    dependentItem.Enabled = flag1;
    return flag2;
  }

  protected static bool CheckVisibilityRelation(SettingItemRelationParameters relationParameters)
  {
    SettingItem dependentItem = relationParameters.DependentItem;
    bool flag1 = SettingItemRelation.CheckValues(relationParameters.RelationValuesByParentItem, relationParameters.MultipleRelationCondition);
    bool flag2 = dependentItem.Visible != flag1;
    dependentItem.Visible = flag1;
    return flag2;
  }

  protected static bool CheckValues(
    IDictionary<SettingItem, IEnumerable<object>> relationValuesByParentItem,
    MultipleRelationCondition condition)
  {
    Func<KeyValuePair<SettingItem, IEnumerable<object>>, bool> predicate = (Func<KeyValuePair<SettingItem, IEnumerable<object>>, bool>) (([In] obj0) =>
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      SettingItemRelation.퓬 퓬 = new SettingItemRelation.퓬();
      // ISSUE: reference to a compiler-generated field
      퓬.픁픏 = obj0.Key;
      IEnumerable<object> source = obj0.Value;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      return 퓬.픁픏.Visible && source.Any<object>(new Func<object, bool>(퓬.퓏));
    });
    return condition == MultipleRelationCondition.IfAny ? relationValuesByParentItem.Any<KeyValuePair<SettingItem, IEnumerable<object>>>(predicate) : relationValuesByParentItem.All<KeyValuePair<SettingItem, IEnumerable<object>>>(predicate);
  }

  [CompilerGenerated]
  internal static bool 퓏([In] object obj0, [In] object obj1)
  {
    if (obj0.Equals(obj1) || obj0 == obj1)
      return true;
    return obj1 is SelectItem selectItem && SettingItemRelation.퓏(obj0, (object) selectItem.Value);
  }
}
