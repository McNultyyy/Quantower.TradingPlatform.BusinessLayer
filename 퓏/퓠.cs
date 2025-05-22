// Decompiled with JetBrains decompiler
// Type: 퓏.퓠
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using NGettext;
using NGettext.Loaders;
using System;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer;

#nullable disable
namespace 퓏;

internal class 퓠
{
  private const string 핇핅 = "locale";
  private 픎 핇픡;

  internal int AttachedPluginCounter { get; [param: In] private set; }

  internal Catalog Catalog { get; [param: In] private set; }

  internal 퓠([In] CultureInfo obj0, [In] 픎 obj1)
  {
    this.Catalog = new Catalog();
    this.AttachedPluginCounter = 0;
    this.핇픡 = obj1;
    this.퓏();
    this.퓏(obj0);
    this.핇();
  }

  internal void 퓏([In] CultureInfo obj0)
  {
    this.Catalog = new Catalog();
    if (obj0 == null)
      return;
    string str = this.퓏(this.핇픡, obj0);
    if (!File.Exists(str))
      return;
    this.Catalog = new Catalog((ILoader) new MoLoader(str));
  }

  internal void 퓏() => ++this.AttachedPluginCounter;

  internal void 퓬() => --this.AttachedPluginCounter;

  private string 퓏([In] 픎 obj0, [In] CultureInfo obj1)
  {
    return Path.Combine(obj0.DirectoryPath, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓵(), obj1.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇플());
  }

  internal Catalog CatalogEN { get; [param: In] private set; }

  private void 핇()
  {
    this.CatalogEN = new Catalog();
    try
    {
      string str = this.퓏(this.핇픡, CultureInfo.GetCultureInfo(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픥()));
      if (!File.Exists(str))
        return;
      this.CatalogEN = new Catalog((ILoader) new MoLoader(str));
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓼());
      this.CatalogEN = new Catalog();
    }
  }
}
