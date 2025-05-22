// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemRelationVisibility
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

public class SettingItemRelationVisibility : SettingItemRelation
{
  public SettingItemRelationVisibility(
  #nullable disable
  string parentSettingsName, params object[] relationValues)
    : base((IDictionary<string, IEnumerable<object>>) new Dictionary<string, IEnumerable<object>>()
    {
      {
        parentSettingsName,
        (IEnumerable<object>) new List<object>((IEnumerable<object>) relationValues)
      }
    }, SettingItemRelationVisibility.퓏.픜퓷 ?? (SettingItemRelationVisibility.퓏.픜퓷 = new SettingItemRelationDelegate(SettingItemRelation.CheckVisibilityRelation)))
  {
    // ISSUE: reference to a compiler-generated field (out of statement scope)
    // ISSUE: reference to a compiler-generated field (out of statement scope)
  }

  public SettingItemRelationVisibility(string[] parentSettingsNames, object relationValue)
    : base((IDictionary<string, IEnumerable<object>>) ((IEnumerable<string>) parentSettingsNames).ToDictionary<string, string, IEnumerable<object>>((Func<string, string>) (([In] obj0) => obj0), new Func<string, IEnumerable<object>>(new SettingItemRelationVisibility.핇()
    {
      픜퓧 = relationValue
    }.퓏)), SettingItemRelationVisibility.퓏.픜퓷 ?? (SettingItemRelationVisibility.퓏.픜퓷 = new SettingItemRelationDelegate(SettingItemRelation.CheckVisibilityRelation)))
  {
    // ISSUE: reference to a compiler-generated field (out of statement scope)
    // ISSUE: reference to a compiler-generated field (out of statement scope)
    // ISSUE: reference to a compiler-generated method (out of statement scope)
    // ISSUE: object of a compiler-generated type is created (out of statement scope)
  }

  public SettingItemRelationVisibility(
    IDictionary<string, IEnumerable<object>> relationValuesByParentItemName)
    : base(relationValuesByParentItemName, SettingItemRelationVisibility.퓏.픜퓷 ?? (SettingItemRelationVisibility.퓏.픜퓷 = new SettingItemRelationDelegate(SettingItemRelation.CheckVisibilityRelation)))
  {
    // ISSUE: reference to a compiler-generated field (out of statement scope)
    // ISSUE: reference to a compiler-generated field (out of statement scope)
  }
}
