// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Serialization.SnapshotData
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Integration;

#nullable enable
namespace TradingPlatform.BusinessLayer.Serialization;

/// <summary>Снапшот для эмулятора</summary>
[ProtoContract]
public class SnapshotData : IXElementSerialization
{
  [ProtoMember(1)]
  public 
  #nullable disable
  IEnumerable<MessageAccount> AccountMessages { get; [param: In] private set; }

  [ProtoMember(2)]
  public IEnumerable<MessageSymbol> SymbolMessages { get; [param: In] private set; }

  [ProtoMember(3)]
  public IEnumerable<MessageAsset> AssetsMessages { get; [param: In] private set; }

  [ProtoMember(4)]
  public IEnumerable<MessageExchange> ExchangeMessages { get; [param: In] private set; }

  [ProtoMember(5)]
  public IEnumerable<DayBar> DayBars { get; [param: In] private set; }

  [ProtoMember(7)]
  public IEnumerable<MessageCryptoAssetBalances> AssetBalances { get; [param: In] private set; }

  [ProtoMember(8)]
  public IEnumerable<MessageCryptoAccount> CryptoAccounts { get; [param: In] private set; }

  [ProtoMember(9)]
  public IEnumerable<MessageOpenPosition> PositionMessages { get; [param: In] private set; }

  [ProtoMember(10)]
  public IEnumerable<MessageOpenOrder> OpenOrdersMessages { get; [param: In] private set; }

  [ProtoMember(11)]
  public IEnumerable<MessageOpenDeliveredAsset> OpenDeliveredAssetMessages { get; [param: In] private set; }

  [ProtoMember(12)]
  public IEnumerable<MessageOptionSerie> OptionSeries { get; [param: In] private set; }

  [ProtoMember(13)]
  public IEnumerable<MessageSessionsContainer> SessionsContainers { get; [param: In] private set; }

  public SnapshotData()
  {
    this.AccountMessages = (IEnumerable<MessageAccount>) new List<MessageAccount>();
    this.OpenOrdersMessages = (IEnumerable<MessageOpenOrder>) new List<MessageOpenOrder>();
    this.PositionMessages = (IEnumerable<MessageOpenPosition>) new List<MessageOpenPosition>();
    this.OpenDeliveredAssetMessages = (IEnumerable<MessageOpenDeliveredAsset>) new List<MessageOpenDeliveredAsset>();
    this.CryptoAccounts = (IEnumerable<MessageCryptoAccount>) new List<MessageCryptoAccount>();
    this.AssetBalances = (IEnumerable<MessageCryptoAssetBalances>) new List<MessageCryptoAssetBalances>();
    this.OptionSeries = (IEnumerable<MessageOptionSerie>) new List<MessageOptionSerie>();
    this.SessionsContainers = (IEnumerable<MessageSessionsContainer>) new List<MessageSessionsContainer>();
  }

  public static SnapshotData Create(
    IEnumerable<MessageSymbol> symbolItems,
    IEnumerable<MessageAsset> uniqueAssets,
    IEnumerable<MessageExchange> uniqueExchanges,
    IEnumerable<DayBar> dayBars,
    IEnumerable<MessageAccount> accounts,
    IEnumerable<MessageCryptoAccount> cryptoAccounts,
    IEnumerable<MessageCryptoAssetBalances> assetBalances,
    IEnumerable<MessageOptionSerie> messageOptionSeries,
    IEnumerable<MessageSessionsContainer> sessionsData,
    IDictionary<string, MessageSymbol> idsMap,
    IDictionary<string, DayBar> idsMap1)
  {
    foreach (KeyValuePair<string, MessageSymbol> ids in (IEnumerable<KeyValuePair<string, MessageSymbol>>) idsMap)
      ids.Value.Id = ids.Key;
    foreach (KeyValuePair<string, DayBar> keyValuePair in (IEnumerable<KeyValuePair<string, DayBar>>) idsMap1)
      keyValuePair.Value.SymbolId = keyValuePair.Key;
    return SnapshotData.Create(symbolItems, uniqueAssets, uniqueExchanges, dayBars, accounts, cryptoAccounts, assetBalances, messageOptionSeries, sessionsData);
  }

  public static SnapshotData Create(
    IEnumerable<MessageSymbol> symbolItems,
    IEnumerable<MessageAsset> uniqueAssets,
    IEnumerable<MessageExchange> uniqueExchanges,
    IEnumerable<DayBar> dayBars,
    IEnumerable<MessageAccount> accounts,
    IEnumerable<MessageCryptoAccount> cryptoAccounts,
    IEnumerable<MessageCryptoAssetBalances> assetBalances,
    IEnumerable<MessageOptionSerie> messageOptionSeries,
    IEnumerable<MessageSessionsContainer> sessionsData)
  {
    return new SnapshotData()
    {
      SymbolMessages = symbolItems,
      DayBars = dayBars,
      AssetsMessages = uniqueAssets,
      ExchangeMessages = uniqueExchanges,
      AccountMessages = accounts,
      CryptoAccounts = cryptoAccounts,
      AssetBalances = assetBalances,
      OptionSeries = messageOptionSeries,
      SessionsContainers = sessionsData
    };
  }

  public static SnapshotData Create(Connection connection)
  {
    return new SnapshotData()
    {
      AccountMessages = (IEnumerable<MessageAccount>) ((IEnumerable<Account>) connection.BusinessObjects.Accounts).Where<Account>((Func<Account, bool>) (([In] obj0) => !(obj0 is CryptoAccount))).Select<Account, MessageAccount>((Func<Account, MessageAccount>) (([In] obj0) => ((IMessageBuilder<MessageAccount>) obj0).BuildMessage())).ToArray<MessageAccount>(),
      CryptoAccounts = (IEnumerable<MessageCryptoAccount>) connection.BusinessObjects.Accounts.OfType<CryptoAccount>().Select<CryptoAccount, MessageCryptoAccount>((Func<CryptoAccount, MessageCryptoAccount>) (([In] obj0) => ((IMessageBuilder<MessageCryptoAccount>) obj0).BuildMessage())).ToArray<MessageCryptoAccount>(),
      AssetBalances = (IEnumerable<MessageCryptoAssetBalances>) connection.BusinessObjects.Accounts.OfType<CryptoAccount>().SelectMany<CryptoAccount, CryptoAssetBalances>((Func<CryptoAccount, IEnumerable<CryptoAssetBalances>>) (([In] obj0) => (IEnumerable<CryptoAssetBalances>) obj0.Balances)).Select<CryptoAssetBalances, MessageCryptoAssetBalances>((Func<CryptoAssetBalances, MessageCryptoAssetBalances>) (([In] obj0) => obj0.BuildMessage())).ToArray<MessageCryptoAssetBalances>(),
      AssetsMessages = (IEnumerable<MessageAsset>) ((IEnumerable<Asset>) connection.BusinessObjects.Assets).Select<Asset, MessageAsset>((Func<Asset, MessageAsset>) (([In] obj0) => ((IMessageBuilder<MessageAsset>) obj0).BuildMessage())).ToArray<MessageAsset>(),
      ExchangeMessages = (IEnumerable<MessageExchange>) ((IEnumerable<Exchange>) connection.BusinessObjects.Exchanges).Select<Exchange, MessageExchange>((Func<Exchange, MessageExchange>) (([In] obj0) => ((IMessageBuilder<MessageExchange>) obj0).BuildMessage())).ToArray<MessageExchange>(),
      SymbolMessages = (IEnumerable<MessageSymbol>) ((IEnumerable<Symbol>) connection.BusinessObjects.Symbols).Select<Symbol, MessageSymbol>((Func<Symbol, MessageSymbol>) (([In] obj0) => ((IMessageBuilder<MessageSymbol>) obj0).BuildMessage())).ToArray<MessageSymbol>(),
      DayBars = (IEnumerable<DayBar>) ((IEnumerable<Symbol>) connection.BusinessObjects.Symbols).Select<Symbol, DayBar>((Func<Symbol, DayBar>) (([In] obj0) => ((IMessageBuilder<DayBar>) obj0).BuildMessage())).ToArray<DayBar>(),
      OpenOrdersMessages = (IEnumerable<MessageOpenOrder>) ((IEnumerable<Order>) connection.BusinessObjects.Orders).Select<Order, MessageOpenOrder>((Func<Order, MessageOpenOrder>) (([In] obj0) => obj0.BuildMessage())).ToArray<MessageOpenOrder>(),
      PositionMessages = (IEnumerable<MessageOpenPosition>) ((IEnumerable<Position>) connection.BusinessObjects.Positions).Select<Position, MessageOpenPosition>((Func<Position, MessageOpenPosition>) (([In] obj0) => obj0.BuildMessage())).ToArray<MessageOpenPosition>(),
      OpenDeliveredAssetMessages = (IEnumerable<MessageOpenDeliveredAsset>) ((IEnumerable<DeliveredAsset>) connection.BusinessObjects.DeliveredAssets).Select<DeliveredAsset, MessageOpenDeliveredAsset>((Func<DeliveredAsset, MessageOpenDeliveredAsset>) (([In] obj0) => obj0.BuildMessage())).ToArray<MessageOpenDeliveredAsset>(),
      SessionsContainers = (IEnumerable<MessageSessionsContainer>) connection.픂픹.TradingSessions.Values.Select<SessionsContainer, MessageSessionsContainer>((Func<SessionsContainer, MessageSessionsContainer>) (([In] obj0) => obj0.BuildMessage())).ToArray<MessageSessionsContainer>()
    };
  }

  public void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    XElement xelement1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓰());
    if (xelement1 != null)
    {
      List<MessageAsset> messageAssetList = new List<MessageAsset>();
      foreach (XElement element1 in xelement1.Elements())
      {
        MessageAsset messageAsset = new MessageAsset();
        messageAsset.FromXElement(element1, deserializationInfo);
        messageAssetList.Add(messageAsset);
      }
      this.AssetsMessages = (IEnumerable<MessageAsset>) messageAssetList;
    }
    XElement xelement2 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픧());
    if (xelement2 != null)
    {
      List<MessageExchange> messageExchangeList = new List<MessageExchange>();
      foreach (XElement element2 in xelement2.Elements())
      {
        MessageExchange messageExchange = new MessageExchange();
        messageExchange.FromXElement(element2, deserializationInfo);
        messageExchangeList.Add(messageExchange);
      }
      this.ExchangeMessages = (IEnumerable<MessageExchange>) messageExchangeList;
    }
    XElement xelement3 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓹());
    if (xelement3 != null)
    {
      List<MessageAccount> messageAccountList = new List<MessageAccount>();
      foreach (XElement element3 in xelement3.Elements())
      {
        MessageAccount messageAccount = new MessageAccount();
        messageAccount.FromXElement(element3, deserializationInfo);
        messageAccountList.Add(messageAccount);
      }
      this.AccountMessages = (IEnumerable<MessageAccount>) messageAccountList;
    }
    XElement xelement4 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓛());
    if (xelement4 != null)
    {
      string name = typeof (MessageSymbol).Name;
      List<MessageSymbol> messageSymbolList = new List<MessageSymbol>();
      foreach (XElement element4 in xelement4.Elements())
      {
        try
        {
          MessageSymbol messageSymbol = new MessageSymbol(string.Empty);
          if (element4.Name == (XName) name)
          {
            messageSymbol.FromXElement(element4, deserializationInfo);
          }
          else
          {
            XElement element5 = element4.Element((XName) name);
            if (element5 != null)
              messageSymbol.FromXElement(element5, deserializationInfo);
          }
          messageSymbolList.Add(messageSymbol);
        }
        catch (Exception ex)
        {
          Core.Instance.Loggers.Log(ex);
        }
      }
      this.SymbolMessages = (IEnumerable<MessageSymbol>) messageSymbolList;
    }
    XElement xelement5 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픝());
    if (xelement5 != null)
    {
      List<MessageOptionSerie> messageOptionSerieList = new List<MessageOptionSerie>();
      foreach (XElement element6 in xelement5.Elements())
      {
        MessageOptionSerie messageOptionSerie = new MessageOptionSerie();
        messageOptionSerie.FromXElement(element6, deserializationInfo);
        messageOptionSerieList.Add(messageOptionSerie);
      }
      this.OptionSeries = (IEnumerable<MessageOptionSerie>) messageOptionSerieList;
    }
    XElement xelement6 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픻());
    if (xelement6 != null)
    {
      List<DayBar> dayBarList = new List<DayBar>();
      foreach (XElement element7 in xelement6.Elements())
      {
        DayBar dayBar = new DayBar(string.Empty, Core.Instance.TimeUtils.DateTimeUtcNow);
        dayBar.FromXElement(element7, deserializationInfo);
        dayBarList.Add(dayBar);
      }
      this.DayBars = (IEnumerable<DayBar>) dayBarList;
    }
    XElement xelement7 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓤());
    if (xelement7 != null)
    {
      List<MessageCryptoAccount> messageCryptoAccountList = new List<MessageCryptoAccount>();
      foreach (XElement element8 in xelement7.Elements())
      {
        MessageCryptoAccount messageCryptoAccount = new MessageCryptoAccount();
        messageCryptoAccount.FromXElement(element8, deserializationInfo);
        messageCryptoAccountList.Add(messageCryptoAccount);
      }
      this.CryptoAccounts = (IEnumerable<MessageCryptoAccount>) messageCryptoAccountList;
    }
    XElement xelement8 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픮());
    if (xelement8 != null)
    {
      List<MessageCryptoAssetBalances> cryptoAssetBalancesList = new List<MessageCryptoAssetBalances>();
      foreach (XElement element9 in xelement8.Elements())
      {
        MessageCryptoAssetBalances cryptoAssetBalances = new MessageCryptoAssetBalances();
        cryptoAssetBalances.FromXElement(element9, deserializationInfo);
        cryptoAssetBalancesList.Add(cryptoAssetBalances);
      }
      this.AssetBalances = (IEnumerable<MessageCryptoAssetBalances>) cryptoAssetBalancesList;
    }
    XElement xelement9 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픉());
    if (xelement9 != null)
    {
      List<MessageOpenOrder> messageOpenOrderList = new List<MessageOpenOrder>();
      foreach (XElement element10 in xelement9.Elements())
      {
        MessageOpenOrder messageOpenOrder = new MessageOpenOrder();
        messageOpenOrder.FromXElement(element10, deserializationInfo);
        messageOpenOrderList.Add(messageOpenOrder);
      }
      this.OpenOrdersMessages = (IEnumerable<MessageOpenOrder>) messageOpenOrderList;
    }
    XElement xelement10 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픒());
    if (xelement10 != null)
    {
      List<MessageOpenPosition> messageOpenPositionList = new List<MessageOpenPosition>();
      foreach (XElement element11 in xelement10.Elements())
      {
        MessageOpenPosition messageOpenPosition = new MessageOpenPosition();
        messageOpenPosition.FromXElement(element11, deserializationInfo);
        messageOpenPositionList.Add(messageOpenPosition);
      }
      this.PositionMessages = (IEnumerable<MessageOpenPosition>) messageOpenPositionList;
    }
    XElement xelement11 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓷());
    if (xelement11 != null)
    {
      List<MessageOpenDeliveredAsset> openDeliveredAssetList = new List<MessageOpenDeliveredAsset>();
      foreach (XElement element12 in xelement11.Elements())
      {
        MessageOpenDeliveredAsset openDeliveredAsset = new MessageOpenDeliveredAsset();
        openDeliveredAsset.FromXElement(element12, deserializationInfo);
        openDeliveredAssetList.Add(openDeliveredAsset);
      }
      this.OpenDeliveredAssetMessages = (IEnumerable<MessageOpenDeliveredAsset>) openDeliveredAssetList;
    }
    XElement xelement12 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓿());
    if (xelement12 == null)
      return;
    List<MessageSessionsContainer> sessionsContainerList = new List<MessageSessionsContainer>();
    foreach (XElement element13 in xelement12.Elements())
    {
      MessageSessionsContainer sessionsContainer = new MessageSessionsContainer();
      sessionsContainer.FromXElement(element13, deserializationInfo);
      sessionsContainerList.Add(sessionsContainer);
    }
    this.SessionsContainers = (IEnumerable<MessageSessionsContainer>) sessionsContainerList;
  }

  public XElement ToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픟());
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓼(), (object) typeof (SnapshotData).Name));
    XElement content1 = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓰());
    foreach (MessageAsset assetsMessage in this.AssetsMessages)
      content1.Add((object) assetsMessage.ToXElement());
    xelement.Add((object) content1);
    XElement content2 = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픧());
    foreach (MessageExchange exchangeMessage in this.ExchangeMessages)
      content2.Add((object) exchangeMessage.ToXElement());
    xelement.Add((object) content2);
    XElement content3 = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓹());
    XElement content4 = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓤());
    foreach (MessageAccount accountMessage in this.AccountMessages)
    {
      if (accountMessage is MessageCryptoAccount)
        content4.Add((object) accountMessage.ToXElement());
      else
        content3.Add((object) accountMessage.ToXElement());
    }
    xelement.Add((object) content3);
    xelement.Add((object) content4);
    XElement content5 = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓛());
    foreach (MessageSymbol symbolMessage in this.SymbolMessages)
      content5.Add((object) symbolMessage.ToXElement());
    xelement.Add((object) content5);
    XElement content6 = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픝());
    foreach (MessageOptionSerie messageOptionSerie in this.OptionSeries)
      content6.Add((object) messageOptionSerie.ToXElement());
    xelement.Add((object) content6);
    XElement content7 = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픻());
    foreach (DayBar dayBar in this.DayBars)
      content7.Add((object) dayBar.ToXElement());
    xelement.Add((object) content7);
    XElement content8 = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픮());
    foreach (MessageCryptoAssetBalances assetBalance in this.AssetBalances)
      content8.Add((object) assetBalance.ToXElement());
    xelement.Add((object) content8);
    XElement content9 = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픉());
    foreach (MessageOpenOrder openOrdersMessage in this.OpenOrdersMessages)
      content9.Add((object) openOrdersMessage.ToXElement());
    xelement.Add((object) content9);
    XElement content10 = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픒());
    foreach (MessageOpenPosition positionMessage in this.PositionMessages)
      content10.Add((object) positionMessage.ToXElement());
    xelement.Add((object) content10);
    XElement content11 = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓷());
    foreach (MessageOpenDeliveredAsset deliveredAssetMessage in this.OpenDeliveredAssetMessages)
      content11.Add((object) deliveredAssetMessage.ToXElement());
    xelement.Add((object) content11);
    XElement content12 = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓿());
    foreach (MessageSessionsContainer sessionsContainer in this.SessionsContainers)
      content12.Add((object) sessionsContainer.ToXElement());
    xelement.Add((object) content12);
    return xelement;
  }
}
