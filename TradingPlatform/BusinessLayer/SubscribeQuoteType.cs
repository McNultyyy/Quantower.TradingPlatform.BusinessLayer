// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SubscribeQuoteType
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>Quote type for subscribtion dictum</summary>
public enum SubscribeQuoteType
{
  /// <summary>Level 1 quote</summary>
  Quote,
  /// <summary>Level 2 quote</summary>
  Level2,
  /// <summary>Last</summary>
  Last,
  /// <summary>Mark price</summary>
  Mark,
}
