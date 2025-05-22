// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.ITradingVendor
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Collections.Generic;
using System.Threading;
using TradingPlatform.BusinessLayer.Integration.Limitation;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

public interface ITradingVendor : IVendor
{
  LimitationMetadata GetLimitationMetadata();

  IList<MessageAccount> GetAccounts(CancellationToken token);

  IList<MessageCryptoAssetBalances> GetCryptoAssetBalances(CancellationToken token);

  IList<MessageRule> GetRules(CancellationToken token);

  IList<MessageAccountOperation> GetAccountOperations(CancellationToken token);

  IList<OrderType> GetAllowedOrderTypes(CancellationToken token);

  IList<MessageOpenOrder> GetPendingOrders(CancellationToken token);

  IList<MessageOpenPosition> GetPositions(CancellationToken token);

  TradesHistoryMetadata GetTradesMetadata();

  IList<MessageTrade> GetTrades(TradesHistoryRequestParameters parameters);

  void GetTrades(TradesHistoryRequestParameters parameters, AccountTradesLoadingCallback callback);

  IList<MessageOrderHistory> GetOrdersHistory(OrdersHistoryRequestParameters parameters);

  PnL CalculatePnL(PnLRequestParameters parameters);

  TradingOperationResult PlaceOrder(PlaceOrderRequestParameters parameters);

  TradingOperationResult PlaceMultiOrder(PlaceMultiOrderOrderRequestParameters parameters);

  TradingOperationResult ModifyOrder(ModifyOrderRequestParameters parameters);

  TradingOperationResult CancelOrder(CancelOrderRequestParameters parameters);

  TradingOperationResult ClosePosition(ClosePositionRequestParameters parameters);

  MarginInfo GetMarginInfo(OrderRequestParameters orderRequestParameters);

  IList<MessageReportType> GetReportsMetaData(CancellationToken token);

  Report GenerateReport(ReportRequestParameters reportRequestParameters);
}
