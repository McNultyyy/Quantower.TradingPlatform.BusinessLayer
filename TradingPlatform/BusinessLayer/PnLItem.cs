// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.PnLItem
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[DataContract(Name = "PnLItem", Namespace = "TradingPlatform")]
[ProtoContract]
public class PnLItem : BusinessObject
{
  private Asset 퓠픿;

  [DataMember(Name = "Value")]
  [ProtoMember(1)]
  public double Value { get; set; }

  [DataMember(Name = "AssetID")]
  [ProtoMember(2)]
  public string AssetID { get; set; }

  [DataMember(Name = "ValuePercent")]
  [ProtoMember(3)]
  public double ValuePercent { get; set; }

  public Asset Asset
  {
    get
    {
      return this.퓠픿 ?? (this.퓠픿 = ((IEnumerable<Asset>) Core.Instance.Assets).FirstOrDefault<Asset>((Func<Asset, bool>) (([In] obj0) => obj0.ConnectionId == this.ConnectionId && obj0.Id == this.AssetID)));
    }
  }

  public PnLItem()
    : base(string.Empty)
  {
    this.ValuePercent = double.NaN;
  }

  public override bool Equals(object obj)
  {
    return obj is PnLItem pnLitem && this.Value == pnLitem.Value && !(this.AssetID != pnLitem.AssetID);
  }

  public override int GetHashCode()
  {
    return (13 * 7 + this.Value.GetHashCode()) * 7 + this.AssetID.GetHashCode();
  }

  public string Format()
  {
    string str = this.FormatPercent();
    return str == null ? this.FormatValue() : this.FormatValue() + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓓() + str + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픗();
  }

  public string FormatValue()
  {
    return this.Asset?.FormatPriceWithCurrency(this.Value) ?? this.Value.Format();
  }

  public string FormatPercent()
  {
    if (double.IsNaN(this.ValuePercent))
      return (string) null;
    return $"{this.ValuePercent}";
  }

  public override string ToString() => this.Format();
}
