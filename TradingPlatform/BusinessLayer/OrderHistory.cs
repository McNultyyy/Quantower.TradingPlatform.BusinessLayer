// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.OrderHistory
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using TradingPlatform.BusinessLayer.Integration;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>
/// Represents an <see cref="T:TradingPlatform.BusinessLayer.Order" /> wrapper
/// </summary>
public class OrderHistory(string connectionId) : 
  Order(connectionId),
  IMessageBuilder<MessageOrderHistory>,
  IEquatable<OrderHistory>
{
  MessageOrderHistory IMessageBuilder<MessageOrderHistory>.퓏()
  {
    return new MessageOrderHistory(this.BuildMessage());
  }

  public bool Equals(OrderHistory other)
  {
    if (other == null)
      return false;
    if (this == other)
      return true;
    return this.ConnectionId == other.ConnectionId && this.Id == other.Id && this.UniqueId == other.UniqueId && object.Equals((object) this.Symbol, (object) other.Symbol) && object.Equals((object) this.Account, (object) other.Account) && object.Equals((object) this.OrderType, (object) other.OrderType) && object.Equals((object) this.StopLoss, (object) other.StopLoss) && object.Equals((object) this.TakeProfit, (object) other.TakeProfit) && object.Equals((object) this.StopLossItems, (object) other.StopLossItems) && object.Equals((object) this.TakeProfitItems, (object) other.TakeProfitItems) && object.Equals((object) this.AdditionalInfo, (object) other.AdditionalInfo) && this.Comment == other.Comment && this.Price == other.Price && this.TriggerPrice == other.TriggerPrice && this.TrailOffset == other.TrailOffset && this.AverageFillPrice == other.AverageFillPrice && this.TotalQuantity == other.TotalQuantity && this.FilledQuantity == other.FilledQuantity && this.RemainingQuantity == other.RemainingQuantity && this.Side == other.Side && this.State == other.State && this.Status == other.Status && this.ExpirationTime == other.ExpirationTime && this.GroupId == other.GroupId && this.OriginalStatus == other.OriginalStatus && this.PositionId == other.PositionId && this.LastUpdateTime == other.LastUpdateTime && this.OrderTypeId == other.OrderTypeId && this.TimeInForce == other.TimeInForce;
  }

  public override bool Equals(object obj)
  {
    if (obj == null)
      return false;
    if (this == obj)
      return true;
    return !(obj.GetType() != this.GetType()) && this.Equals((OrderHistory) obj);
  }

  public override int GetHashCode()
  {
    HashCode hashCode = new HashCode();
    hashCode.Add<string>(this.ConnectionId);
    hashCode.Add<string>(this.Id);
    hashCode.Add<string>(this.UniqueId);
    hashCode.Add<Symbol>(this.Symbol);
    hashCode.Add<Account>(this.Account);
    hashCode.Add<OrderType>(this.OrderType);
    hashCode.Add<SlTpHolder>(this.StopLoss);
    hashCode.Add<SlTpHolder>(this.TakeProfit);
    hashCode.Add<SlTpHolder[]>(this.StopLossItems);
    hashCode.Add<SlTpHolder[]>(this.TakeProfitItems);
    hashCode.Add<AdditionalInfoCollection>(this.AdditionalInfo);
    hashCode.Add<string>(this.Comment);
    hashCode.Add<double>(this.Price);
    hashCode.Add<double>(this.TriggerPrice);
    hashCode.Add<double>(this.TrailOffset);
    hashCode.Add<double>(this.AverageFillPrice);
    hashCode.Add<double>(this.TotalQuantity);
    hashCode.Add<double>(this.FilledQuantity);
    hashCode.Add<double>(this.RemainingQuantity);
    hashCode.Add<Side>(this.Side);
    hashCode.Add<BusinessObjectState>(this.State);
    hashCode.Add<OrderStatus>(this.Status);
    hashCode.Add<DateTime>(this.ExpirationTime);
    hashCode.Add<string>(this.GroupId);
    hashCode.Add<string>(this.OriginalStatus);
    hashCode.Add<string>(this.PositionId);
    hashCode.Add<DateTime>(this.LastUpdateTime);
    hashCode.Add<string>(this.OrderTypeId);
    hashCode.Add<TimeInForce>(this.TimeInForce);
    return hashCode.ToHashCode();
  }
}
