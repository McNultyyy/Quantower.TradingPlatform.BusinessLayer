// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.TradingObject
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[DataContract(Name = "TradingObject")]
public abstract class TradingObject : BusinessObject, ITradingObject
{
  private readonly Lazy<AdditionalInfoCollection> 퓠픗;

  [DataMember(Name = "ID")]
  public string Id { get; protected set; }

  [DataMember(Name = "Account")]
  public Account Account { get; protected set; }

  [DataMember(Name = "Instrument")]
  public Symbol Symbol { get; protected set; }

  [DataMember(Name = "Side")]
  public Side Side { get; protected set; }

  [DataMember(Name = "Comment")]
  public string Comment { get; protected set; }

  public AdditionalInfoCollection AdditionalInfo
  {
    get => !this.퓠픗.IsValueCreated ? (AdditionalInfoCollection) null : this.퓠픗.Value;
  }

  protected TradingObject(string connectionId)
    : base(connectionId)
  {
    this.퓠픗 = new Lazy<AdditionalInfoCollection>();
  }

  protected void ProcessAdditionalItems(List<AdditionalInfoItem> items)
  {
    if (items == null)
      return;
    foreach (AdditionalInfoItem additionalInfoItem in items)
      this.퓠픗.Value.퓏(additionalInfoItem);
  }
}
