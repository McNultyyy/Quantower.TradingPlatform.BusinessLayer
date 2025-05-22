// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.ExceptionExtensions
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Text;

#nullable enable
namespace TradingPlatform.BusinessLayer;

public static class ExceptionExtensions
{
  public static 
  #nullable disable
  string GetMessageRecursive(this Exception exception)
  {
    string str;
    if (exception == null)
    {
      str = (string) null;
    }
    else
    {
      Exception innerException = exception.InnerException;
      str = innerException != null ? innerException.GetMessageRecursive() : (string) null;
    }
    return str ?? exception?.Message ?? string.Empty;
  }

  public static string GetFullMessageRecursive(this Exception exception)
  {
    StringBuilder stringBuilder1 = new StringBuilder(exception.Message);
    if (exception.InnerException != null)
    {
      StringBuilder stringBuilder2 = stringBuilder1;
      StringBuilder stringBuilder3 = stringBuilder2;
      StringBuilder.AppendInterpolatedStringHandler interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(18, 1, stringBuilder2);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픢());
      interpolatedStringHandler.AppendFormatted(exception.InnerException.GetFullMessageRecursive());
      ref StringBuilder.AppendInterpolatedStringHandler local = ref interpolatedStringHandler;
      stringBuilder3.Append(ref local);
    }
    return stringBuilder1.ToString();
  }

  public static IEnumerable<Exception> GetInnerExceptionsRecursive(this Exception exception)
  {
    for (Exception exception1 = exception; exception1 != null; exception1 = exception1.InnerException)
      yield return exception1;
  }
}
