// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.HistoryRequestParameters
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using ProtoBuf;
using System;
using TradingPlatform.BusinessLayer.History.Storage;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>Resolves a history request parameters per symbol</summary>
[Published]
[ProtoContract]
public sealed class HistoryRequestParameters : RequestParameters
{
  private Symbol 퓍픳;
  private string 퓍픙;

  public override RequestType Type => RequestType.History;

  public Symbol Symbol
  {
    get => this.퓍픳;
    set
    {
      this.퓍픳 = value;
      this.퓍픙 = this.퓍픳?.Id;
    }
  }

  [ProtoMember(1)]
  public string SymbolId
  {
    get
    {
      string 퓍픙 = this.퓍픙;
      if (퓍픙 != null)
        return 퓍픙;
      return this.Symbol?.Id;
    }
    set => this.퓍픙 = value;
  }

  [ProtoMember(2)]
  public DateTime FromTime { get; set; }

  [ProtoMember(3)]
  public DateTime ToTime { get; set; }

  public TradingPlatform.BusinessLayer.Utils.Interval<DateTime> Interval
  {
    get => new TradingPlatform.BusinessLayer.Utils.Interval<DateTime>(this.FromTime, this.ToTime);
    set
    {
      this.FromTime = value.From;
      this.ToTime = value.To;
    }
  }

  public HistoryAggregation Aggregation { get; set; }

  public bool ForceReload { get; set; }

  public bool ExcludeOutOfSession { get; set; }

  public ISessionsContainer SessionsContainer { get; set; }

  public HistoryRequestParameters()
  {
    this.ProgressInfo = (IProgress<float>) new HistoryRequestParametersProgressInfo();
    this.ForceReload = false;
    this.ExcludeOutOfSession = true;
  }

  public HistoryRequestParameters(HistoryRequestParameters original)
  {
    this.Symbol = original.Symbol;
    this.SymbolId = original.SymbolId;
    this.Aggregation = original.Aggregation?.Clone() as HistoryAggregation;
    this.FromTime = original.FromTime;
    this.ToTime = original.ToTime;
    this.ForceReload = original.ForceReload;
    this.CancellationToken = original.CancellationToken;
    this.SessionsContainer = original.SessionsContainer;
    this.ExcludeOutOfSession = original.ExcludeOutOfSession;
  }

  public IProgress<float> ProgressInfo { get; set; }

  public HistoryRequestParameters Copy => new HistoryRequestParameters(this);

  public HistoryDescription ToDescription()
  {
    return new HistoryDescription(this.SymbolId, this.Aggregation);
  }
}
