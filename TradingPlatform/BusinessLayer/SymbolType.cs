// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SymbolType
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Runtime.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>
/// Договориль использовать множественное число для типа инструмента
/// </summary>
[DataContract(Name = "InstrumentType", Namespace = "TradingPlatform")]
public enum SymbolType
{
  [EnumMember] Unknown,
  [EnumMember] Forex,
  [EnumMember] Equities,
  [EnumMember] CFD,
  [EnumMember] Indexes,
  [EnumMember] Futures,
  [EnumMember] Options,
  [EnumMember] ETF,
  [EnumMember] Crypto,
  [EnumMember] Synthetic,
  [EnumMember] Spot,
  [EnumMember] Forward,
  [EnumMember] FixedIncome,
  [EnumMember] Warrants,
  /// <summary>Завели для индийской интеграции</summary>
  [EnumMember] Debentures,
  [EnumMember] Bond,
  [EnumMember] Swap,
}
