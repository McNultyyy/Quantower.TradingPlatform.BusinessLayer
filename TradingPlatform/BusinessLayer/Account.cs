// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Account
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Integration;
using 퓏;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>Contains all user's account information</summary>
[Published]
public class Account : 
  BusinessObject,
  퓏.픾,
  IMessageBuilder<MessageAccount>,
  IComparable,
  IComparable<Account>,
  IEquatable<Account>
{
  private readonly 핅<string, Rule> 퓗픆;

  /// <summary>Gets account unique code.</summary>
  public string Id { get; [param: In] private set; }

  /// <summary>Obtaining account name.</summary>
  public string Name { get; [param: In] private set; }

  /// <summary>
  /// Gets base currency of account. Account CCY is always equal to the server CCY in AlgoStudio
  /// </summary>
  public Asset AccountCurrency { get; [param: In] private set; }

  /// <summary>Gets current balance of the account.</summary>
  public double Balance { get; [param: In] private set; }

  public NettingType NettingType { get; set; }

  /// <summary>Gets additional account information</summary>
  [NotPublished]
  public AdditionalInfoCollection AdditionalInfo { get; [param: In] private set; }

  int 퓏.픾.TradingPlatform\u002EBusinessLayer\u002EIRulesContainer\u002EPriorityIndex => 10;

  핅<string, Rule> 퓏.픾.TradingPlatform\u002EBusinessLayer\u002EIRulesContainer\u002ERules => this.퓗픆;

  /// <summary>
  /// Will be triggered on each account information updating
  /// </summary>
  public event Action<Account> Updated;

  [NotPublished]
  protected internal Account(string connectionId)
    : base(connectionId)
  {
    this.퓗픆 = new 핅<string, Rule>();
    Core.Instance.RulesManager.Defaults.ForEach((Action<Rule>) (([In] obj0) => this.퓗픆.퓏(obj0.Name, obj0)));
  }

  [NotPublished]
  protected internal Account(BusinessObjectInfo accountInfo)
    : base(accountInfo.ConnectionId)
  {
    this.Id = accountInfo.Id;
    this.Name = accountInfo.Name;
    this.State = BusinessObjectState.Fake;
  }

  internal void 퓏([In] MessageAccount obj0)
  {
    this.Id = obj0.AccountId;
    this.Name = obj0.AccountName;
    Asset asset;
    if (obj0.AssetId != null && this.ConnectionCache != null && this.ConnectionCache.픾핁.TryGetValue(obj0.AssetId, out asset))
      this.AccountCurrency = asset;
    this.Balance = obj0.Balance;
    this.NettingType = obj0.NettingType;
    if (obj0.AccountAdditionalInfo != null)
    {
      if (this.AdditionalInfo == null)
      {
        AdditionalInfoCollection additionalInfoCollection;
        this.AdditionalInfo = additionalInfoCollection = new AdditionalInfoCollection();
      }
      foreach (AdditionalInfoItem additionalInfoItem in obj0.AccountAdditionalInfo)
        this.AdditionalInfo.퓏(additionalInfoItem);
    }
    // ISSUE: reference to a compiler-generated field
    Action<Account> 퓗픅 = this.퓗픅;
    if (퓗픅 == null)
      return;
    퓗픅(this);
  }

  MessageAccount IMessageBuilder<MessageAccount>.퓏()
  {
    MessageAccount messageAccount = new MessageAccount();
    messageAccount.AccountId = this.Id;
    messageAccount.AccountName = this.Name;
    messageAccount.AssetId = this.AccountCurrency.Id;
    messageAccount.Balance = this.Balance;
    AdditionalInfoCollection additionalInfo = this.AdditionalInfo;
    messageAccount.AccountAdditionalInfo = additionalInfo != null ? additionalInfo.Items.ToList<AdditionalInfoItem>() : (List<AdditionalInfoItem>) null;
    return messageAccount;
  }

  /// <summary>Gets Account name</summary>
  /// <returns></returns>
  [NotPublished]
  public override string ToString() => this.Name;

  /// <summary>
  /// Creates a business object info with an Account data which can be used for the restoring/serialization process.
  /// </summary>
  /// <returns></returns>
  [NotPublished]
  public override BusinessObjectInfo CreateInfo()
  {
    픟 info = new 픟();
    info.ConnectionId = this.ConnectionId;
    info.Id = this.Id;
    info.Name = this.Name;
    info.IsCrypto = false;
    return (BusinessObjectInfo) info;
  }

  public int CompareTo(object obj) => this.CompareTo(obj as Account);

  public int CompareTo(Account other)
  {
    if (this == other)
      return 0;
    return other == null ? 1 : string.Compare(this.Id, other.Id, StringComparison.Ordinal);
  }

  public bool Equals(Account other)
  {
    if (other == null)
      return false;
    if (this == other)
      return true;
    return this.Id == other.Id && this.ConnectionId == other.ConnectionId;
  }

  public override bool Equals(object obj)
  {
    if (obj == null)
      return false;
    if (this == obj)
      return true;
    return !(obj.GetType() != this.GetType()) && this.Equals((Account) obj);
  }

  public override int GetHashCode() => HashCode.Combine<string, string>(this.Id, this.ConnectionId);
}
