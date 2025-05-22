// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.MessageNewsHeadline
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

public class MessageNewsHeadline : Message
{
  public override MessageType Type => MessageType.NewsHeadline;

  public string Id { get; set; }

  public DateTime CreationDate { get; set; }

  public string Title { get; set; }

  public IEnumerable<string> SymbolsIds { get; set; }

  public string Category { get; set; }

  public string SourceLink { get; set; }

  public string SubscribeId { get; set; }
}
