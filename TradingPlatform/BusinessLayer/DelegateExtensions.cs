// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.DelegateExtensions
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public static class DelegateExtensions
{
  public static void InvokeSafely(this Delegate @delegate, params object[] args)
  {
    if ((object) @delegate == null)
      return;
    foreach (Delegate invocation in @delegate.GetInvocationList())
    {
      try
      {
        invocation.DynamicInvoke(args);
      }
      catch (Exception ex)
      {
        Core.Instance.Loggers.Log(ex);
      }
    }
  }
}
