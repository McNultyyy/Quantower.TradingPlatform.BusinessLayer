// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.CryptoAssetBalances
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using TradingPlatform.BusinessLayer.Integration;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[Published]
[DataContract(Name = "CryptoAssetBalances", Namespace = "TradingPlatform")]
public class CryptoAssetBalances : BusinessObject, IMessageBuilder<MessageCryptoAssetBalances>
{
  private string 퓗퓨;

  [DataMember(Name = "AssetId")]
  public string AssetId { get; [param: In] internal set; }

  public Asset Asset { get; [param: In] private set; }

  [DataMember(Name = "TotalBalance")]
  public double TotalBalance { get; [param: In] internal set; }

  [DataMember(Name = "AvailableBalance")]
  public double AvailableBalance { get; [param: In] internal set; }

  [DataMember(Name = "ReservedBalance")]
  public double ReservedBalance { get; [param: In] internal set; }

  [DataMember(Name = "TotalInUSD")]
  public double TotalInUSD { get; [param: In] internal set; }

  [DataMember(Name = "TotalInBTC")]
  public double TotalInBTC { get; [param: In] internal set; }

  [DataMember(Name = "Debt")]
  public double Debt { get; [param: In] internal set; }

  [DataMember(Name = "Equity")]
  public double Equity { get; [param: In] internal set; }

  [DataMember(Name = "EquityInBTC")]
  public double EquityInBTC { get; [param: In] internal set; }

  public DateTime LastUpdateTime { get; [param: In] private set; }

  public GetAvailableBalanceHandler AvailableBalanceHandler { get; set; }

  public double GetAvailableBalance(OrderRequestParameters requestParameters)
  {
    double availableBalance = 0.0;
    GetAvailableBalanceHandler availableBalanceHandler = this.AvailableBalanceHandler;
    if ((availableBalanceHandler != null ? (availableBalanceHandler(this.AssetId, requestParameters, out availableBalance) ? 1 : 0) : 0) != 0)
      return availableBalance;
    availableBalance = this.AvailableBalance;
    return availableBalance;
  }

  internal CryptoAssetBalances([In] string obj0)
    : base(obj0)
  {
  }

  internal void 퓏([In] MessageCryptoAssetBalances obj0)
  {
    this.AssetId = obj0.AssetId;
    this.TotalBalance = obj0.TotalBalance;
    this.AvailableBalance = obj0.AvailableBalance;
    this.ReservedBalance = obj0.ReservedBalance;
    this.TotalInUSD = obj0.TotalInUSD;
    this.TotalInBTC = obj0.TotalInBTC;
    this.Debt = obj0.Debt;
    this.Equity = obj0.Equity;
    this.EquityInBTC = obj0.EquityInBTC;
    this.AvailableBalanceHandler = obj0.AvailableBalanceHandler;
    this.퓗퓨 = obj0.AccountId;
    Asset asset;
    if (!string.IsNullOrEmpty(obj0.AssetId) && this.ConnectionCache.픾핁.TryGetValue(obj0.AssetId, out asset))
      this.Asset = asset;
    this.LastUpdateTime = Core.Instance.TimeUtils.DateTimeUtcNow;
  }

  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 2);
    interpolatedStringHandler.AppendFormatted(this.AssetId);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픿());
    interpolatedStringHandler.AppendFormatted<double>(this.TotalBalance);
    return interpolatedStringHandler.ToStringAndClear();
  }

  public MessageCryptoAssetBalances BuildMessage()
  {
    return new MessageCryptoAssetBalances()
    {
      AssetId = this.AssetId,
      TotalBalance = this.TotalBalance,
      AvailableBalance = this.AvailableBalance,
      ReservedBalance = this.ReservedBalance,
      TotalInUSD = this.TotalInUSD,
      TotalInBTC = this.TotalInBTC,
      Debt = this.Debt,
      Equity = this.Equity,
      EquityInBTC = this.EquityInBTC,
      AvailableBalanceHandler = this.AvailableBalanceHandler,
      AccountId = this.퓗퓨
    };
  }
}
