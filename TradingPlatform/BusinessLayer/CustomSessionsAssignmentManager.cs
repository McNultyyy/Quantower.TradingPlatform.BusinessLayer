// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.CustomSessionsAssignmentManager
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

public class CustomSessionsAssignmentManager : 
  IEnumerable<CustomSessionsAssignment>,
  IEnumerable,
  ICustomizable
{
  private readonly IDictionary<string, CustomSessionsAssignment> 퓍픸;
  private readonly CustomSessionsAssignmentManager.퓏 퓍프;

  public IList<SettingItem> Settings
  {
    get
    {
      return (IList<SettingItem>) this.Select<CustomSessionsAssignment, SettingItemGroup>((Func<CustomSessionsAssignment, SettingItemGroup>) (([In] obj0) => new SettingItemGroup(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픵(), obj0.Settings))).Cast<SettingItem>().ToList<SettingItem>();
    }
    set
    {
      foreach (SettingItem settingItem in (IEnumerable<SettingItem>) value)
      {
        if (settingItem.Value is IList<SettingItem> settingItemList)
          this.Add(new CustomSessionsAssignment()
          {
            Settings = settingItemList
          });
      }
    }
  }

  public event EventHandler<CustomSessionEventArgs> Updated;

  public CustomSessionsAssignmentManager()
  {
    this.퓍픸 = (IDictionary<string, CustomSessionsAssignment>) new Dictionary<string, CustomSessionsAssignment>();
    this.퓍프 = new CustomSessionsAssignmentManager.퓏();
  }

  public void Add(CustomSessionsAssignment assignment)
  {
    this.퓍픸.Add(assignment.UniqueId, assignment);
    this.퓏(assignment, EntityLifecycle.Created);
  }

  public void Edit(string assignmentId, CustomSessionsAssignment newAssignment)
  {
    CustomSessionsAssignment sessionsAssignment;
    if (!this.퓍픸.TryGetValue(assignmentId, out sessionsAssignment))
      return;
    sessionsAssignment.퓏(newAssignment);
    this.퓏(sessionsAssignment, EntityLifecycle.Changed);
  }

  public void Delete(string assignmentId)
  {
    CustomSessionsAssignment sessionsAssignment;
    if (!this.퓍픸.TryGetValue(assignmentId, out sessionsAssignment))
      return;
    this.퓍픸.Remove(assignmentId);
    this.퓏(sessionsAssignment, EntityLifecycle.Removed);
  }

  public bool TryGetSessionsContainer(Symbol symbol, out CustomSessionsContainer container)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    CustomSessionsAssignmentManager.핇 핇 = new CustomSessionsAssignmentManager.핇();
    // ISSUE: reference to a compiler-generated field
    핇.퓥픎 = symbol;
    container = (CustomSessionsContainer) null;
    List<CustomSessionsAssignment> list = this.ToList<CustomSessionsAssignment>();
    list.Sort((IComparer<CustomSessionsAssignment>) this.퓍프);
    // ISSUE: reference to a compiler-generated method
    CustomSessionsAssignment sessionsAssignment = list.FirstOrDefault<CustomSessionsAssignment>(new Func<CustomSessionsAssignment, bool>(핇.퓏));
    container = sessionsAssignment?.SessionsContainer;
    return container != null;
  }

  private void 퓏([In] CustomSessionsAssignment obj0, [In] EntityLifecycle obj1)
  {
    // ISSUE: reference to a compiler-generated field
    EventHandler<CustomSessionEventArgs> 퓍퓻 = this.퓍퓻;
    if (퓍퓻 == null)
      return;
    object[] objArray = new object[2]{ (object) this, null };
    CustomSessionEventArgs sessionEventArgs = new CustomSessionEventArgs();
    sessionEventArgs.Assignment = obj0;
    sessionEventArgs.Lifecycle = obj1;
    objArray[1] = (object) sessionEventArgs;
    퓍퓻.InvokeSafely(objArray);
  }

  public IEnumerator<CustomSessionsAssignment> GetEnumerator() => this.퓍픸.Values.GetEnumerator();

  IEnumerator IEnumerable.퓏() => (IEnumerator) this.GetEnumerator();

  private class 퓏 : IComparer<CustomSessionsAssignment>
  {
    public int Compare(CustomSessionsAssignment x, CustomSessionsAssignment y)
    {
      if (x == null && y != null)
        return 1;
      if (x != null && y == null)
        return -1;
      if (x == y)
        return 0;
      if (!string.IsNullOrEmpty(x.SymbolId))
        return -1;
      if (!string.IsNullOrEmpty(y.SymbolId))
        return 1;
      if (!string.IsNullOrEmpty(x.ExchangeId))
        return -1;
      return !string.IsNullOrEmpty(y.ExchangeId) ? 1 : 0;
    }
  }
}
