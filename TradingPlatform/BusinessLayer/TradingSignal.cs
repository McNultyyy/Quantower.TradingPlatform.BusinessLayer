// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.TradingSignal
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Integration;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public sealed class TradingSignal : BusinessObject, IMessageBuilder<MessageTradingSignal>
{
  public string Id { get; [param: In] private set; }

  public string Ticker { get; [param: In] private set; }

  public string Root { get; [param: In] private set; }

  public string VendorName { get; [param: In] private set; }

  public Side Side { get; [param: In] private set; }

  public OrderTypeBehavior OrderTypeBehavior { get; [param: In] private set; }

  public double EntryPrice { get; [param: In] private set; }

  public double TargetPrice { get; [param: In] private set; }

  public double StopPrice { get; [param: In] private set; }

  public double Confidence { get; [param: In] private set; }

  public double Profitability
  {
    get
    {
      return this.Side != Side.Buy ? 1.0 - this.TargetPrice / this.EntryPrice : this.TargetPrice / this.EntryPrice - 1.0;
    }
  }

  public DateTime Published { get; [param: In] private set; }

  public DateTime Updated { get; [param: In] private set; }

  public DateTime ExpiresAt { get; [param: In] private set; }

  public string Duration { get; [param: In] private set; }

  public string Status { get; [param: In] private set; }

  public string Description { get; [param: In] private set; }

  public string Details { get; [param: In] private set; }

  public string Source { get; [param: In] private set; }

  internal TradingSignal([In] string obj0)
    : base(obj0)
  {
  }

  internal void 퓏([In] MessageTradingSignal obj0)
  {
    this.Id = obj0.Id;
    this.Ticker = obj0.Ticker;
    this.Root = obj0.Root;
    this.VendorName = obj0.VendorName;
    this.Side = obj0.Side;
    this.OrderTypeBehavior = obj0.OrderTypeBehavior;
    this.EntryPrice = obj0.EntryPrice;
    this.TargetPrice = obj0.TargetPrice;
    this.StopPrice = obj0.StopPrice;
    this.Confidence = obj0.Confidence;
    this.Published = obj0.Published;
    this.Updated = obj0.Updated;
    this.ExpiresAt = obj0.ExpiresAt;
    this.Duration = obj0.Duration;
    this.Status = obj0.Status;
    this.Description = obj0.Description;
    this.Details = obj0.Details;
    this.Source = obj0.Source;
  }

  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(5, 4);
    interpolatedStringHandler.AppendFormatted<Side>(this.Side);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프());
    interpolatedStringHandler.AppendFormatted<OrderTypeBehavior>(this.OrderTypeBehavior);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프());
    interpolatedStringHandler.AppendFormatted(this.Ticker ?? this.Root);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓓());
    interpolatedStringHandler.AppendFormatted(this.Description);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픗());
    return interpolatedStringHandler.ToStringAndClear();
  }

  MessageTradingSignal IMessageBuilder<MessageTradingSignal>.퓏()
  {
    return new MessageTradingSignal(this.Id)
    {
      Ticker = this.Ticker,
      Root = this.Root,
      VendorName = this.VendorName,
      Side = this.Side,
      OrderTypeBehavior = this.OrderTypeBehavior,
      EntryPrice = this.EntryPrice,
      TargetPrice = this.TargetPrice,
      StopPrice = this.StopPrice,
      Confidence = this.Confidence,
      Published = this.Published,
      Updated = this.Updated,
      ExpiresAt = this.ExpiresAt,
      Duration = this.Duration,
      Status = this.Status,
      Description = this.Description,
      Details = this.Details,
      Source = this.Source
    };
  }

  public string Format()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 7);
    interpolatedStringHandler.AppendFormatted<double>(this.Confidence, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣퓮());
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓛());
    interpolatedStringHandler.AppendFormatted(this.Status);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프());
    interpolatedStringHandler.AppendFormatted(this.Ticker ?? this.Root);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픕());
    interpolatedStringHandler.AppendFormatted<double>(this.EntryPrice);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픱());
    interpolatedStringHandler.AppendFormatted<double>(this.TargetPrice);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픶());
    interpolatedStringHandler.AppendFormatted<double>(this.StopPrice);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓛());
    interpolatedStringHandler.AppendFormatted<DateTime>(this.Updated, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇핆());
    return interpolatedStringHandler.ToStringAndClear();
  }
}
