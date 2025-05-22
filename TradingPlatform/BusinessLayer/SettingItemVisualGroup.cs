// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemVisualGroup
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public class SettingItemVisualGroup : ISettingsGroup, ISettingsGroupCollapseBehaviour
{
  public string Text { get; [param: In] private set; }

  public int SortIndex { get; [param: In] private set; }

  public ISettingsGroup ParentGroup { get; [param: In] private set; }

  public GroupActionInfo FirstActionInfo { get; set; }

  public GroupActionInfo SecondActionInfo { get; set; }

  public IList<ISettingsGroup> ChildGroups { get; [param: In] private set; }

  public SettingsGroupCollapseBehaviour CollapseBehaviour { get; set; }

  public SettingItemVisualGroup(string text, int sortIndex = 0, ISettingsGroup parentGroup = null)
  {
    this.Text = text;
    this.SortIndex = sortIndex;
    this.ParentGroup = parentGroup;
    this.ChildGroups = (IList<ISettingsGroup>) new List<ISettingsGroup>();
    if (this.ParentGroup == null)
      return;
    this.ParentGroup.ChildGroups.Add((ISettingsGroup) this);
  }

  public override bool Equals(object obj) => this.GetHashCode() == obj.GetHashCode();

  public override int GetHashCode() => SettingItemVisualGroup.퓏((ISettingsGroup) this);

  public override string ToString() => this.Text;

  internal static int 퓏([In] ISettingsGroup obj0)
  {
    int num = (17 * 23 + obj0.Text.GetHashCode()) * 23 + obj0.SortIndex.GetHashCode();
    foreach (ISettingsGroup childGroup in (IEnumerable<ISettingsGroup>) obj0.ChildGroups)
      num = num * 23 + childGroup.GetHashCode();
    return num;
  }
}
