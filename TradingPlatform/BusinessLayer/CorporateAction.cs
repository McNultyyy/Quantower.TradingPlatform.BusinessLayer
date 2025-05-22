// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.CorporateAction
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using TradingPlatform.BusinessLayer.Integration;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>Represents information about corporate action.</summary>
[Published]
public class CorporateAction(string connectionId) : BusinessObject(connectionId)
{
  /// <summary>Get the date and time when trade was executed</summary>
  public DateTime DateTime { get; [param: In] private set; }

  [DataMember(Name = "ID")]
  public string Id { get; protected set; }

  [DataMember(Name = "Instrument")]
  public Symbol Symbol { get; protected set; }

  public string Details { get; set; }

  public CorporateActionType CorporateActionType { get; set; }

  /// <summary>Will be triggered on corporate action updating</summary>
  public event Action Updated;

  internal void 퓏([In] MessageCorporateAction obj0)
  {
    this.Id = obj0.CorporateActionId;
    Symbol symbol;
    if (!string.IsNullOrEmpty(obj0.SymbolId) && this.ConnectionCache != null && this.ConnectionCache.SymbolsCache.퓏(obj0.SymbolId, out symbol))
      this.Symbol = symbol;
    this.DateTime = obj0.DateTime;
    this.Details = obj0.Details;
    this.CorporateActionType = obj0.CorporateActionType;
    // ISSUE: reference to a compiler-generated field
    Action 퓗픔 = this.퓗픔;
    if (퓗픔 == null)
      return;
    퓗픔();
  }
}
