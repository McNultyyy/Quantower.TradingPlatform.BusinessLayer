// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.CustomSessionsManager
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public class CustomSessionsManager : IEnumerable<CustomSessionsContainer>, IEnumerable, ICustomizable
{
  private readonly IDictionary<string, CustomSessionsContainer> 퓍퓽;

  public CustomSessionsAssignmentManager Assignments { get; }

  public event EventHandler<CustomSessionEventArgs> Updated;

  public CustomSessionsContainer this[string id]
  {
    get
    {
      CustomSessionsContainer sessionsContainer;
      return !string.IsNullOrEmpty(id) && this.퓍퓽.TryGetValue(id, out sessionsContainer) ? sessionsContainer : (CustomSessionsContainer) null;
    }
  }

  public IList<SettingItem> Settings
  {
    get
    {
      return (IList<SettingItem>) new List<SettingItem>()
      {
        (SettingItem) new SettingItemGroup(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞핁(), (IList<SettingItem>) this.Select<CustomSessionsContainer, SettingItemGroup>((Func<CustomSessionsContainer, SettingItemGroup>) (([In] obj0) => new SettingItemGroup(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픐(), obj0.Settings))).Cast<SettingItem>().ToList<SettingItem>()),
        (SettingItem) new SettingItemGroup(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픇(), this.Assignments.Settings)
      };
    }
    set
    {
      IList<SettingItem> settingItemList1;
      if (value.TryGetValue<IList<SettingItem>>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞핁(), out settingItemList1))
      {
        this.퓍퓽.Clear();
        foreach (SettingItem settingItem in (IEnumerable<SettingItem>) settingItemList1)
        {
          if (settingItem.Value is IList<SettingItem> settingItemList2)
          {
            CustomSessionsContainer sessionsContainer = new CustomSessionsContainer()
            {
              Settings = settingItemList2
            };
            this.퓍퓽.Add(sessionsContainer.Id, sessionsContainer);
          }
        }
      }
      IList<SettingItem> settingItemList3;
      if (!value.TryGetValue<IList<SettingItem>>(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픇(), out settingItemList3))
        return;
      this.Assignments.Settings = settingItemList3;
    }
  }

  internal CustomSessionsManager()
  {
    this.Assignments = new CustomSessionsAssignmentManager();
    this.퓍퓽 = (IDictionary<string, CustomSessionsContainer>) new Dictionary<string, CustomSessionsContainer>();
  }

  public void Add(CustomSessionsContainer container)
  {
    this.퓍퓽.Add(container.Id, container);
    this.퓏(container, EntityLifecycle.Created);
  }

  public void Edit(string containerId, CustomSessionsContainer newContainer)
  {
    CustomSessionsContainer sessionsContainer;
    if (!this.퓍퓽.TryGetValue(containerId, out sessionsContainer))
      return;
    sessionsContainer.퓏(newContainer);
    this.퓏(sessionsContainer, EntityLifecycle.Changed);
  }

  public void Delete(string containerId)
  {
    CustomSessionsContainer sessionsContainer;
    if (!this.퓍퓽.TryGetValue(containerId, out sessionsContainer))
      return;
    this.퓍퓽.Remove(containerId);
    this.퓏(sessionsContainer, EntityLifecycle.Removed);
  }

  private void 퓏([In] CustomSessionsContainer obj0, [In] EntityLifecycle obj1)
  {
    // ISSUE: reference to a compiler-generated field
    EventHandler<CustomSessionEventArgs> 퓍퓶 = this.퓍퓶;
    if (퓍퓶 == null)
      return;
    object[] objArray = new object[2]{ (object) this, null };
    CustomSessionEventArgs sessionEventArgs = new CustomSessionEventArgs();
    sessionEventArgs.Container = obj0;
    sessionEventArgs.Lifecycle = obj1;
    objArray[1] = (object) sessionEventArgs;
    퓍퓶.InvokeSafely(objArray);
  }

  public IEnumerator<CustomSessionsContainer> GetEnumerator() => this.퓍퓽.Values.GetEnumerator();

  IEnumerator IEnumerable.퓏() => (IEnumerator) this.GetEnumerator();
}
