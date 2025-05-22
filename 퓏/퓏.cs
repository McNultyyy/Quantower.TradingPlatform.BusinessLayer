// Decompiled with JetBrains decompiler
// Type: 퓏.퓏
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

#nullable disable
namespace 퓏;

internal static class 퓏
{
  public static string 퓏([In] this Assembly obj0) => obj0.핇<AssemblyProductAttribute>()?.Product;

  public static string 퓬([In] this Assembly obj0)
  {
    string version = obj0.핇<AssemblyVersionAttribute>()?.Version;
    if (version != null)
      return version;
    return obj0.핇<AssemblyFileVersionAttribute>()?.Version;
  }

  public static 퓏 핇<퓏>([In] this Assembly obj0) where 퓏 : Attribute
  {
    return ((IEnumerable<object>) obj0.GetCustomAttributes(typeof (퓏), false)).FirstOrDefault<object>() as 퓏;
  }
}
