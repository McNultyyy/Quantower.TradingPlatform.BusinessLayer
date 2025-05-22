// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.ActionBufferedProcessor
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils;

/// <summary>The action buffered processor.</summary>
public class ActionBufferedProcessor : BufferedProcessor<Action>
{
  protected override void Process(Action subject)
  {
    try
    {
      subject();
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
  }
}
