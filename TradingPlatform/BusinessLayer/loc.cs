// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.loc
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public static class loc
{
  private const string 핇퓯 = "CoreLocarizer";
  public const string HIDDEN = "#hidden#";
  private static 퓏.퓠 핇픜;
  private static Dictionary<string, 퓏.퓠> 핇퓑 = new Dictionary<string, 퓏.퓠>();

  private static CultureInfo DefaultCultureInfo => CultureInfo.CurrentUICulture;

  private static CultureInfo TerminalCultureInfo => CultureInfo.DefaultThreadCurrentUICulture;

  /// <summary>
  /// 
  /// </summary>
  public static void OnLocaleChanged()
  {
    foreach (퓏.퓠 퓠 in loc.핇퓑.Values)
      퓠.퓏(loc.TerminalCultureInfo);
    loc.핇픜?.퓏(loc.TerminalCultureInfo);
  }

  private static 퓏.픎 퓏([In] string obj0, [In] string obj1)
  {
    return new 퓏.픎()
    {
      DirectoryPath = Path.GetDirectoryName(obj0),
      Name = obj1
    };
  }

  /// <summary>Чисто, як маркер для парсера xgettext.exe</summary>
  /// <param name="text"></param>
  /// <returns></returns>
  public static string key(string text) => text;

  public static string _(string text, string pluginFolderName = null, [CallerFilePath] string callerFilePath = null)
  {
    if (string.IsNullOrWhiteSpace(text))
      return string.Empty;
    string empty = string.Empty;
    string str = text;
    string key = !string.IsNullOrWhiteSpace(pluginFolderName) ? pluginFolderName : loc.퓏(callerFilePath);
    if (!string.IsNullOrWhiteSpace(key))
    {
      if (loc.핇퓑.ContainsKey(key) && loc.핇퓑[key].Catalog.Translations.ContainsKey(text))
        str = loc.핇퓑[key].Catalog.GetString(text);
      if (!str.Equals(text))
        return str;
    }
    if (loc.핇픜 != null && loc.핇픜.Catalog.Translations.ContainsKey(text))
      str = loc.핇픜.Catalog.GetString(text);
    return str;
  }

  /// <summary>Check, whether current translation equal to hidden</summary>
  public static bool IsHidden(string text, string pluginFolderName = null, [CallerFilePath] string callerFilePath = null)
  {
    try
    {
      if (string.IsNullOrWhiteSpace(text))
        return false;
      if (text == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓐())
        return true;
      string empty = string.Empty;
      bool flag = false;
      string key = !string.IsNullOrWhiteSpace(pluginFolderName) ? pluginFolderName : loc.퓏(callerFilePath);
      if (!string.IsNullOrWhiteSpace(key))
      {
        if (loc.핇퓑.ContainsKey(key) && loc.핇퓑[key].CatalogEN.Translations.ContainsKey(text))
          flag = loc.핇퓑[key].CatalogEN.GetString(text) == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓐();
        if (flag)
          return flag;
      }
      if (loc.핇픜 != null && loc.핇픜.CatalogEN.Translations.ContainsKey(text))
        flag = loc.핇픜.CatalogEN.GetString(text) == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓐();
      return flag;
    }
    catch
    {
      return false;
    }
  }

  private static string 퓏([In] string obj0)
  {
    if (obj0 == null)
      return string.Empty;
    foreach (string key in ((IEnumerable<string>) Path.GetDirectoryName(obj0).Split(Path.DirectorySeparatorChar)).Reverse<string>())
    {
      if (loc.핇퓑.ContainsKey(key))
        return key;
    }
    return string.Empty;
  }

  /// <summary>
  /// 
  /// </summary>
  /// <param name="pluginName"></param>
  public static void UnRegisterPlugin(string pluginName)
  {
    if (!loc.핇퓑.ContainsKey(pluginName))
      return;
    퓏.퓠 퓠 = loc.핇퓑[pluginName];
    퓠.퓬();
    if (퓠.AttachedPluginCounter > 0)
      return;
    loc.핇퓑.Remove(pluginName);
  }

  /// <summary>
  /// 
  /// </summary>
  /// <param name="pluginName"></param>
  /// <param name="location"></param>
  public static void RegisterPlugin(string pluginName, string location)
  {
    if (loc.핇퓑.ContainsKey(pluginName))
      return;
    퓏.픎 픎 = loc.퓏(location, pluginName);
    loc.핇퓑[pluginName] = new 퓏.퓠(loc.TerminalCultureInfo ?? loc.DefaultCultureInfo, 픎);
  }

  /// <summary>
  /// 
  /// </summary>
  public static void InitializeCoreLocalizer()
  {
    퓏.픎 픎 = loc.퓏(Assembly.GetCallingAssembly().Location, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픚());
    loc.핇픜 = new 퓏.퓠(loc.TerminalCultureInfo ?? loc.DefaultCultureInfo, 픎);
  }
}
