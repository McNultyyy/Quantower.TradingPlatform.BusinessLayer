// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.IHistoryItem
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public interface IHistoryItem : ICloneable
{
  DateTime TimeLeft { get; }

  long TicksLeft { get; set; }

  long TicksRight { get; set; }

  double this[PriceType priceType] { get; }

  void SetData(string key, object value);

  bool TryGetData<TData>(string key, out TData data);

  VolumeAnalysisData VolumeAnalysisData { get; set; }
}
