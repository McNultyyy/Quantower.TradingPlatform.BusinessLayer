// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.ActionBufferedProcessorWithPriority
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils;

/// <summary>The action buffered processor with priority.</summary>
/// <summary>
/// Initializes a new instance of the <see cref="T:TradingPlatform.BusinessLayer.Utils.ActionBufferedProcessorWithPriority" /> class.
/// </summary>
/// <param name="threadsCount">The threads count.</param>
public class ActionBufferedProcessorWithPriority(int threadsCount = 1) : 
  BufferedProcessorWithPriority<Action>(threadsCount)
{
  protected override void Process(Action action)
  {
    if (action == null)
      return;
    action();
  }
}
