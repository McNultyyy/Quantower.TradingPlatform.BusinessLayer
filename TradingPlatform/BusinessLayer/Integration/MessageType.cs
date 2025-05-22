// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.MessageType
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

public enum MessageType
{
  Account,
  Symbol,
  OpenOrder,
  CloseOrder,
  OpenPosition,
  ClosePosition,
  Trade,
  Quote,
  Level2,
  Last,
  DayBar,
  Asset,
  Custom,
  DOM,
  Exchange,
  ReportMetadata,
  SymbolTypes,
  OrderHistory,
  Rule,
  DealTicket,
  SymbolGroup,
  CryptoAssetBalances,
  CryptoAccount,
  OptionSerie,
  SymbolInfo,
  Session,
  OpenDeliveredAsset,
  CloseDeliveredAsset,
  CorporateAction,
  AccountOperation,
  ClosedPosition,
  Mark,
  NewsHeadline,
  TradingSignal,
  RemoveTradingSignal,
}
