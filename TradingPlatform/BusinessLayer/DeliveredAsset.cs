// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.DeliveredAsset
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Integration;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public sealed class DeliveredAsset : TradingObject, IMessageBuilder<MessageOpenDeliveredAsset>
{
  public double Quantity { get; [param: In] private set; }

  public string Status { get; [param: In] private set; }

  public DateTime CreationTime { get; [param: In] private set; }

  /// <summary>
  /// Will be triggered on each <see cref="M:TradingPlatform.BusinessLayer.DeliveredAsset.UpdateByMessage(TradingPlatform.BusinessLayer.Integration.MessageOpenDeliveredAsset)" /> invocation
  /// </summary>
  public event Action<DeliveredAsset> Updated;

  internal DeliveredAsset([In] string obj0)
    : base(obj0)
  {
  }

  internal void 퓏([In] MessageOpenDeliveredAsset obj0)
  {
    this.Id = obj0.Id;
    Symbol symbol;
    if (this.ConnectionCache != null && this.ConnectionCache.SymbolsCache.퓏(obj0.SymbolId, out symbol))
      this.Symbol = symbol;
    Account account;
    if (this.ConnectionCache != null && this.ConnectionCache.AccountsCache.퓏(obj0.AccountId, out account))
      this.Account = account;
    this.Quantity = obj0.Quantity;
    this.Status = obj0.Status;
    this.CreationTime = obj0.CreationTime;
    this.ProcessAdditionalItems(obj0.AdditionalInfoItems);
    // ISSUE: reference to a compiler-generated field
    Action<DeliveredAsset> 핋퓍 = this.핋퓍;
    if (핋퓍 == null)
      return;
    핋퓍(this);
  }

  public MessageOpenDeliveredAsset BuildMessage()
  {
    return new MessageOpenDeliveredAsset()
    {
      Id = this.Id,
      AccountId = this.Account?.Id,
      SymbolId = this.Symbol?.Id,
      Quantity = this.Quantity,
      Status = this.Status,
      CreationTime = this.CreationTime
    };
  }
}
