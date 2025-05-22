// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.OptionSerie
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using TradingPlatform.BusinessLayer.Integration;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[DataContract(Name = "OptionSerie", Namespace = "TradingPlatform")]
public sealed class OptionSerie : BusinessObject, IMessageBuilder<MessageOptionSerie>, IComparable
{
  public string Id { get; [param: In] private set; }

  public DateTime ExpirationDate { get; [param: In] private set; }

  public string Name { get; [param: In] private set; }

  public string UnderlierId { get; [param: In] private set; }

  public Exchange Exchange { get; [param: In] private set; }

  public OptionSerieType SerieType { get; [param: In] private set; }

  public string VisualName
  {
    get
    {
      string shortDateString = this.ExpirationDate.ToShortDateString();
      return string.IsNullOrEmpty(this.Name) ? shortDateString : this.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프() + shortDateString;
    }
  }

  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
    interpolatedStringHandler.AppendFormatted(this.UnderlierId);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프());
    interpolatedStringHandler.AppendFormatted(this.Name);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프());
    interpolatedStringHandler.AppendFormatted(this.ExpirationDate.ToShortDateString());
    return interpolatedStringHandler.ToStringAndClear();
  }

  internal OptionSerie([In] string obj0)
    : base(obj0)
  {
  }

  internal void 퓏([In] MessageOptionSerie obj0)
  {
    this.Id = obj0.Id;
    this.ExpirationDate = obj0.ExpirationDate;
    this.Name = obj0.Name;
    this.UnderlierId = obj0.UnderlierId;
    this.SerieType = obj0.SerieType;
    Exchange exchange;
    if (string.IsNullOrEmpty(obj0.ExchangeId) || this.ConnectionCache == null || !this.ConnectionCache.ExchangesCache.퓏(obj0.ExchangeId, out exchange))
      return;
    this.Exchange = exchange;
  }

  MessageOptionSerie IMessageBuilder<MessageOptionSerie>.퓏()
  {
    return new MessageOptionSerie()
    {
      Id = this.Id,
      ExpirationDate = this.ExpirationDate,
      Name = this.Name,
      UnderlierId = this.UnderlierId
    };
  }

  public override bool Equals(object obj)
  {
    return obj is OptionSerie optionSerie && this.ConnectionId == optionSerie.ConnectionId && this.Id == optionSerie.Id && this.UnderlierId == optionSerie.UnderlierId;
  }

  public override int GetHashCode()
  {
    return ((-1159877490 * -1521134295 + this.ExpirationDate.GetHashCode()) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.Id)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.UnderlierId);
  }

  public int CompareTo(object obj) => this.CompareTo(obj);
}
