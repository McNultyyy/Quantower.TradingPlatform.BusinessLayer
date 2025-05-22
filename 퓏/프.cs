// Decompiled with JetBrains decompiler
// Type: 퓏.프
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer;

#nullable disable
namespace 퓏;

internal class 프
{
  private static readonly IList<픴> 퓲퓫 = (IList<픴>) new List<픴>()
  {
    new 픴(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲핈(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픤()),
    new 픴(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓟(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲핉()),
    new 픴(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲핊(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픛())
  };

  public void 퓏([In] SettingItem obj0)
  {
    IList<SettingItem> list = obj0.GetValue<IList<SettingItem>>();
    SettingItem itemByName1 = list.GetItemByName(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픐());
    SettingItem itemByName2 = list.GetItemByName(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픭());
    string input = itemByName1.Value.ToString();
    foreach (픴 픴 in (IEnumerable<픴>) 프.퓲퓫)
    {
      if (픴.Regex.Match(input).Success)
      {
        itemByName1.Value = (object) input.Replace(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픔() + 픴.OldName, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픔() + 픴.NewName);
        itemByName2.Value = (object) 픴.NewName;
        break;
      }
    }
  }

  public string 퓏([In] string obj0)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    프.퓏 퓏 = new 프.퓏();
    // ISSUE: reference to a compiler-generated field
    퓏.픣퓣 = obj0;
    // ISSUE: reference to a compiler-generated method
    픴 픴 = 프.퓲퓫.FirstOrDefault<픴>(new Func<픴, bool>(퓏.퓏));
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    return 픴 == null ? 퓏.픣퓣 : 퓏.픣퓣.Replace(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픔() + 픴.OldName, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픔() + 픴.NewName);
  }
}
