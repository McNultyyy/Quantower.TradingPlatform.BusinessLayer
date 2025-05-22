// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.CryptoAccount
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using TradingPlatform.BusinessLayer.Integration;
using 퓏;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[Published]
[DataContract(Name = "CryptoAccount", Namespace = "TradingPlatform")]
public class CryptoAccount : Account, IMessageBuilder<MessageCryptoAccount>
{
  private readonly Dictionary<string, CryptoAssetBalances> 핋퓏;

  public CryptoAssetBalances[] Balances => this.핋퓏.Values.ToArray<CryptoAssetBalances>();

  public event EventHandler<CryptoAccountEventArgs> BalanceUpdated;

  internal CryptoAccount([In] string obj0)
    : base(obj0)
  {
    this.핋퓏 = new Dictionary<string, CryptoAssetBalances>();
  }

  internal CryptoAccount([In] BusinessObjectInfo obj0)
    : base(obj0)
  {
    this.핋퓏 = new Dictionary<string, CryptoAssetBalances>();
  }

  public bool TryGetAssetBalances(string assetId, out CryptoAssetBalances cryptoAssetBalances)
  {
    return this.핋퓏.TryGetValue(assetId, out cryptoAssetBalances);
  }

  internal void 퓏([In] MessageCryptoAssetBalances obj0)
  {
    AccountBalanceEventReason reason = AccountBalanceEventReason.Update;
    CryptoAssetBalances balances;
    if (!this.핋퓏.TryGetValue(obj0.AssetId, out balances))
    {
      this.핋퓏[obj0.AssetId] = balances = new CryptoAssetBalances(this.ConnectionId);
      reason = AccountBalanceEventReason.New;
    }
    balances.퓏(obj0);
    // ISSUE: reference to a compiler-generated field
    this.핋퓬.InvokeSafely((object) this, (object) new CryptoAccountEventArgs(reason, balances));
  }

  public override BusinessObjectInfo CreateInfo()
  {
    픟 info = base.CreateInfo() as 픟;
    info.IsCrypto = true;
    return (BusinessObjectInfo) info;
  }

  MessageCryptoAccount IMessageBuilder<MessageCryptoAccount>.퓏()
  {
    MessageCryptoAccount messageCryptoAccount = new MessageCryptoAccount();
    messageCryptoAccount.AccountId = this.Id;
    messageCryptoAccount.AccountName = this.Name;
    messageCryptoAccount.AssetId = this.AccountCurrency?.Id;
    messageCryptoAccount.Balance = this.Balance;
    AdditionalInfoCollection additionalInfo = this.AdditionalInfo;
    messageCryptoAccount.AccountAdditionalInfo = additionalInfo != null ? additionalInfo.Items.ToList<AdditionalInfoItem>() : (List<AdditionalInfoItem>) null;
    return messageCryptoAccount;
  }
}
