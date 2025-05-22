// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Renamable
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public class Renamable : IRenamable
{
  public bool AllowFileSystemForbiddenSymbols = true;

  public bool AllowEmptyName { get; set; }

  public List<string> ExcludeNames { get; set; }

  public string Name { get; set; }

  public bool IsNameAllowed(string s, ref string error)
  {
    if (!this.AllowEmptyName && string.IsNullOrWhiteSpace(s))
    {
      error = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞핌();
      return false;
    }
    if (this.ExcludeNames != null && ((IEnumerable<string>) this.ExcludeNames.ConvertAll<string>((Converter<string, string>) (([In] obj0) => obj0.ToLower())).ToArray()).Contains<string>(s.ToLower()))
    {
      error = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓩();
      return false;
    }
    char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
    if (s.IndexOfAny(invalidFileNameChars) != -1)
    {
      string str1 = string.Empty;
      string str2 = string.Empty;
      DefaultInterpolatedStringHandler interpolatedStringHandler;
      foreach (char c in invalidFileNameChars)
      {
        if (char.IsWhiteSpace(c) || char.IsControl(c))
        {
          string str3 = str2;
          interpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 1);
          interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓨());
          interpolatedStringHandler.AppendFormatted<int>((int) c);
          interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픆());
          string stringAndClear = interpolatedStringHandler.ToStringAndClear();
          str2 = str3 + stringAndClear;
        }
        else
        {
          string str4 = str1;
          interpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 1);
          interpolatedStringHandler.AppendFormatted<char>(c);
          interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픆());
          string stringAndClear = interpolatedStringHandler.ToStringAndClear();
          str1 = str4 + stringAndClear;
        }
      }
      string str5 = str2.Trim().Trim(',');
      string str6 = str1 + str5;
      error = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓱() + str6;
      return false;
    }
    error = string.Empty;
    return true;
  }
}
