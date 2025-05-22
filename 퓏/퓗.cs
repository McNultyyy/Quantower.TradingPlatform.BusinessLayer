// Decompiled with JetBrains decompiler
// Type: 퓏.퓗
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using CommandLine;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer;

#nullable disable
namespace 퓏;

internal class 퓗
{
  [Option('l', "log", Required = false, HelpText = "Set logging level")]
  public LoggingLevel LoggingLevel { get; [param: In] set; }
}
