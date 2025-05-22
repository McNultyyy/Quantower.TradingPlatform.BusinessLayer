// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemExtensions
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

#nullable enable
namespace TradingPlatform.BusinessLayer;

public static class SettingItemExtensions
{
  public static 
  #nullable disable
  SettingItem GetItemByName(this IEnumerable<SettingItem> list, string name)
  {
    if (string.IsNullOrEmpty(name))
      return (SettingItem) null;
    foreach (SettingItem itemByName in list)
    {
      if (itemByName != null && itemByName.Name == name)
        return itemByName;
    }
    return (SettingItem) null;
  }

  public static SettingItem GetItemByPath(
    this IEnumerable<SettingItem> list,
    params string[] pathLevels)
  {
    if (pathLevels == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓪());
    IEnumerable<SettingItem> list1 = list;
    for (int index = 0; index < pathLevels.Length; ++index)
    {
      string pathLevel = pathLevels[index];
      SettingItem itemByName = list1.GetItemByName(pathLevel);
      if (itemByName == null)
        return (SettingItem) null;
      if (index == pathLevels.Length - 1)
        return itemByName;
      list1 = (IEnumerable<SettingItem>) (itemByName.Value as IList<SettingItem>);
    }
    return (SettingItem) null;
  }

  /// <summary>
  /// Get all settings or particular settings by provided hierarchy path
  /// </summary>
  public static IEnumerable<SettingItem> GetItemsByPath(
    this IEnumerable<SettingItem> list,
    params string[] pathLevels)
  {
    if (pathLevels == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓪());
    IEnumerable<SettingItem> list1 = list;
    for (int index = 0; index < pathLevels.Length; ++index)
    {
      string pathLevel = pathLevels[index];
      if (string.IsNullOrEmpty(pathLevel))
        return list1;
      SettingItem itemByName = list1.GetItemByName(pathLevel);
      if (itemByName == null)
        return (IEnumerable<SettingItem>) null;
      if (itemByName.Value is IList<SettingItem> settingItemList)
        list1 = (IEnumerable<SettingItem>) settingItemList;
      else if (index == pathLevels.Length - 1)
        return (IEnumerable<SettingItem>) new List<SettingItem>()
        {
          itemByName
        };
    }
    return list1;
  }

  public static bool TryGetItemByName(
    this IEnumerable<SettingItem> items,
    string name,
    out SettingItem item)
  {
    item = items != null ? items.GetItemByName(name) : (SettingItem) null;
    return item != null;
  }

  public static void ApplyVisualGroup(
    this IEnumerable<SettingItem> list,
    SettingItemVisualGroup visualGroup,
    params string[] pathLevels)
  {
    IEnumerable<SettingItem> settingItems = pathLevels != null ? list.GetItemsByPath(pathLevels) : throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓪());
    if (settingItems == null)
      return;
    foreach (SettingItem settingItem in settingItems)
    {
      if (settingItem.Type == SettingItemType.Group && settingItem.Value is IEnumerable<SettingItem> list1)
        list1.ApplyVisualGroup(visualGroup);
      else
        settingItem.VisualGroup = (ISettingsGroup) visualGroup;
    }
  }

  public static SettingItem UpdateItemValue(
    this IEnumerable<SettingItem> list,
    string name,
    object newValue,
    bool force = false)
  {
    SettingItem itemByName = list.GetItemByName(name);
    if (itemByName == null)
      return (SettingItem) null;
    if (itemByName is SettingItemGroup && itemByName.Value is IList<SettingItem> list1 && newValue is IList<SettingItem> settingItemList)
    {
      foreach (SettingItem settingItem in (IEnumerable<SettingItem>) settingItemList)
        list1.UpdateItemValue(settingItem.Name, settingItem.Value);
    }
    else
      itemByName.퓏(newValue, force);
    return itemByName;
  }

  public static void UpdateValues(
    this IEnumerable<SettingItem> list,
    IEnumerable<SettingItem> other,
    bool ignoreValidation = false,
    params string[] filterNames)
  {
    if (list == null || other == null)
      return;
    Dictionary<string, SettingItem> dictionary = other.DistinctBy<SettingItem, string>((Func<SettingItem, string>) (([In] obj0) => obj0.Name)).ToDictionary<SettingItem, string, SettingItem>((Func<SettingItem, string>) (([In] obj0) => obj0.Name), (Func<SettingItem, SettingItem>) (([In] obj0) => obj0));
    foreach (SettingItem settingItem1 in list)
    {
      SettingItem settingItem2;
      if ((!((IEnumerable<string>) filterNames).Any<string>() || ((IEnumerable<string>) filterNames).Contains<string>(settingItem1.Name)) && dictionary.TryGetValue(settingItem1.Name, out settingItem2))
      {
        if (settingItem1.Value is IList<SettingItem> list1 && settingItem2.Value is IList<SettingItem> other1)
        {
          list1.UpdateValues((IEnumerable<SettingItem>) other1, ignoreValidation);
        }
        else
        {
          try
          {
            settingItem1.퓏(settingItem2.Value, ignoreValidation);
          }
          catch (Exception ex)
          {
            Core.Instance.Loggers.Log(ex);
          }
        }
      }
    }
  }

  public static void UpdateValues(
    this IEnumerable<SettingItem> list,
    AdditionalInfoCollection additionalInfoCollection)
  {
    if (additionalInfoCollection == null)
      return;
    Dictionary<string, object> dictionary = additionalInfoCollection.ToDictionary<AdditionalInfoItem, string, object>((Func<AdditionalInfoItem, string>) (([In] obj0) => obj0.Id), (Func<AdditionalInfoItem, object>) (([In] obj0) => obj0.Value));
    foreach (SettingItem settingItem in list)
    {
      try
      {
        object obj;
        if (dictionary.TryGetValue(settingItem.Name, out obj))
          settingItem.퓏(obj);
      }
      catch (Exception ex)
      {
        Core.Instance.Loggers.Log(ex);
      }
    }
  }

  public static bool IsAny(this IEnumerable<SettingItem> list, Predicate<SettingItem> predicate)
  {
    foreach (SettingItem settingItem in list)
    {
      if (predicate(settingItem) || settingItem.Value is IList<SettingItem> list1 && list1.IsAny(predicate))
        return true;
    }
    return false;
  }

  public static T GetValueOrDefault<T>(
    this IEnumerable<SettingItem> settings,
    T defaultValue,
    params string[] pathLevels)
  {
    SettingItem itemByPath = settings.GetItemByPath(pathLevels);
    return itemByPath == null ? defaultValue : itemByPath.GetValue<T>();
  }

  public static T GetVisibleValueOrDefault<T>(
    this IEnumerable<SettingItem> settings,
    T defaultValue,
    params string[] pathLevels)
  {
    SettingItem itemByPath = settings.GetItemByPath(pathLevels);
    return itemByPath == null || !itemByPath.Enabled || !itemByPath.Visible ? defaultValue : itemByPath.GetValue<T>();
  }

  public static T GetValue<T>(this IEnumerable<SettingItem> settings, params string[] pathLevels)
  {
    SettingItem itemByPath = settings.GetItemByPath(pathLevels);
    return itemByPath == null ? default (T) : itemByPath.GetValue<T>();
  }

  public static T GetVisibleValue<T>(
    this IEnumerable<SettingItem> settings,
    params string[] pathLevels)
  {
    SettingItem itemByPath = settings.GetItemByPath(pathLevels);
    return itemByPath == null || !itemByPath.Enabled || !itemByPath.Visible ? default (T) : itemByPath.GetValue<T>();
  }

  public static T GetValue<T>(this SettingItem item)
  {
    try
    {
      T password;
      switch (item.Value)
      {
        case SelectItem selectItem:
          password = (T) selectItem.Value;
          break;
        case PasswordHolder passwordHolder:
          password = (T) passwordHolder.Password;
          break;
        default:
          password = (T) item.Value;
          break;
      }
      return password;
    }
    catch
    {
      return default (T);
    }
  }

  public static bool TryGetValue<T>(
    this IEnumerable<SettingItem> settings,
    string name,
    out T value)
  {
    value = default (T);
    SettingItem itemByName = settings.GetItemByName(name);
    if (itemByName == null)
      return false;
    value = itemByName.GetValue<T>();
    return true;
  }

  public static bool TryGetVisibleValue<T>(
    this IEnumerable<SettingItem> settings,
    string name,
    out T value)
  {
    value = default (T);
    SettingItem itemByName = settings.GetItemByName(name);
    if (itemByName == null || !itemByName.Enabled || !itemByName.Visible)
      return false;
    value = itemByName.GetValue<T>();
    return true;
  }

  public static IEnumerable<SettingItem> ExpandGroups(this IEnumerable<SettingItem> settings)
  {
    if (settings != null)
    {
      IEnumerator<SettingItem> enumerator1 = settings.GetEnumerator();
      while (enumerator1.MoveNext())
      {
        SettingItem current = enumerator1.Current;
        if (current.Value is IEnumerable<SettingItem> settings1)
        {
          IEnumerator<SettingItem> enumerator2 = settings1.ExpandGroups().GetEnumerator();
          while (enumerator2.MoveNext())
            yield return enumerator2.Current;
          // ISSUE: reference to a compiler-generated method
          this.핇();
          enumerator2 = (IEnumerator<SettingItem>) null;
        }
        else
          yield return current;
      }
      // ISSUE: reference to a compiler-generated method
      this.퓬();
      enumerator1 = (IEnumerator<SettingItem>) null;
    }
  }

  public static SettingItem RestoreGroupsNesting(this SettingItem settingItem)
  {
    List<SettingItemList> source = new List<SettingItemList>();
    SettingItemExtensions.퓏(settingItem, (ICollection<SettingItemList>) source);
    if (source.Count <= 0)
      return settingItem;
    (source[0].Value as IList<SettingItem>).Add(settingItem);
    for (int index = 0; index < source.Count - 1; ++index)
      (source[index + 1].Value as IList<SettingItem>).Add((SettingItem) source[index]);
    return (SettingItem) source.Last<SettingItemList>();
  }

  public static void MergeWith(this IList<SettingItem> origin, IList<SettingItem> other)
  {
    if (other == null)
      return;
    foreach (SettingItem settingItem in (IEnumerable<SettingItem>) other)
    {
      SettingItem itemByName = origin.GetItemByName(settingItem.Name);
      if (itemByName == null)
        origin.Add(settingItem);
      else if ((itemByName is SettingItemGroup settingItemGroup1 ? settingItemGroup1.Value : (object) null) is IList<SettingItem> origin1 && (settingItem is SettingItemGroup settingItemGroup2 ? settingItemGroup2.Value : (object) null) is IList<SettingItem> other1)
        origin1.MergeWith(other1);
      else
        itemByName.퓏(settingItem);
    }
  }

  public static IEnumerable<SettingItem> DeepCopy(this IEnumerable<SettingItem> settings)
  {
    return settings.Select<SettingItem, SettingItem>((Func<SettingItem, SettingItem>) (([In] obj0) => obj0.GetCopy()));
  }

  public static void SetValueWithReason(
    this SettingItem settingItem,
    object value,
    SettingItemValueChangingReason reason)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    SettingItemExtensions.퓬 퓬 = new SettingItemExtensions.퓬();
    // ISSUE: reference to a compiler-generated field
    퓬.픞픓 = settingItem;
    // ISSUE: reference to a compiler-generated field
    퓬.픞픩 = value;
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated method
    퓬.픞픓.InvokeActionWithReason(reason, new Action(퓬.퓏));
  }

  public static void InvokeActionWithReason(
    this SettingItem settingItem,
    SettingItemValueChangingReason reason,
    Action action)
  {
    SettingItemValueChangingReason valueChangingReason = settingItem.ValueChangingReason;
    try
    {
      settingItem.ValueChangingReason = reason;
      if (action == null)
        return;
      action();
    }
    finally
    {
      settingItem.ValueChangingReason = valueChangingReason;
    }
  }

  [CompilerGenerated]
  internal static void 퓏([In] SettingItem obj0, [In] ICollection<SettingItemList> obj1)
  {
    if (obj0.Type == SettingItemType.Group)
    {
      SettingItemGroup settingItemGroup = new SettingItemGroup(obj0.Name, (IList<SettingItem>) new List<SettingItem>());
      obj1.Add((SettingItemList) settingItemGroup);
    }
    if (obj0.Group == null)
      return;
    SettingItemExtensions.퓏((SettingItem) obj0.Group, obj1);
  }
}
