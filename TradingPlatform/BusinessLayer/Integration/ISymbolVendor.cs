// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.ISymbolVendor
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Collections.Generic;
using System.Threading;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

public interface ISymbolVendor : IVendor
{
  bool AllowNonFixedList { get; }

  IList<MessageSessionsContainer> GetSessions(CancellationToken token);

  IList<MessageExchange> GetExchanges(CancellationToken token);

  IList<MessageAsset> GetAssets(CancellationToken token);

  IList<MessageSymbol> GetSymbols(CancellationToken token);

  MessageSymbolTypes GetSymbolTypes(CancellationToken token);

  IList<MessageSymbolGroup> GetSymbolGroups(CancellationToken token);

  MessageSymbol GetNonFixedSymbol(GetSymbolRequestParameters requestParameters);

  IList<MessageSymbolInfo> SearchSymbols(SearchSymbolsRequestParameters requestParameters);

  IList<MessageSymbolInfo> GetFutureContracts(
    GetFutureContractsRequestParameters requestParameters);

  IList<MessageOptionSerie> GetOptionSeries(GetOptionSeriesRequestParameters requestParameters);

  IList<MessageSymbolInfo> GetStrikes(GetStrikesRequestParameters requestParameters);
}
