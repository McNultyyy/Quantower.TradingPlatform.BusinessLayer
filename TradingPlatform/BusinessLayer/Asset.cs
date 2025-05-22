// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Asset
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Integration;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>Defines asset entity</summary>
[Published]
/// <summary>Creates an Asset instance</summary>
/// <param name="connectionId">given connection Id</param>
[method: NotPublished]
public class Asset(string connectionId) : BusinessObject(connectionId), IComparable, IMessageBuilder<MessageAsset>
{
  private double 퓗픩;

  /// <summary>Asset id bearer</summary>
  public string Id { get; [param: In] private set; }

  /// <summary>Asset name bearer</summary>
  public string Name { get; [param: In] private set; }

  /// <summary>Asset description</summary>
  public string Description { get; [param: In] private set; }

  /// <summary>Defines a number precision of the change value</summary>
  public double MinimumChange
  {
    get => this.퓗픩;
    set
    {
      if (this.퓗픩 == value)
        return;
      this.퓗픩 = value;
      this.Precision = CoreMath.GetValuePrecision((Decimal) this.퓗픩);
    }
  }

  /// <summary>Gets precision value</summary>
  public int Precision { get; [param: In] private set; }

  /// <summary>Gets asset ISO 4217 code</summary>
  public string IsoCode { get; [param: In] private set; }

  /// <summary>Formats price into precision normalized string</summary>
  /// <param name="price"></param>
  /// <returns></returns>
  public string FormatPrice(double price)
  {
    return !double.IsNaN(price) ? price.Format(this.Precision) : \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓯();
  }

  /// <summary>
  /// Formats price into concatenated string which contains the precision normalized value and Asset's name
  /// </summary>
  /// <param name="price"></param>
  /// <returns></returns>
  public string FormatPriceWithCurrency(double price)
  {
    return !double.IsNaN(price) ? price.Format(this.Precision) + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프() + this.Name : \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓯();
  }

  public string FormatWithCurrency(double value)
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
    interpolatedStringHandler.AppendFormatted<double>(value);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프());
    interpolatedStringHandler.AppendFormatted(this.Name);
    return interpolatedStringHandler.ToStringAndClear();
  }

  internal void 퓏([In] MessageAsset obj0)
  {
    this.Id = obj0.Id;
    this.Name = obj0.Name;
    this.Description = obj0.Description;
    this.MinimumChange = obj0.MinimumChange;
    this.IsoCode = obj0.IsoCode;
  }

  MessageAsset IMessageBuilder<MessageAsset>.퓏()
  {
    return new MessageAsset()
    {
      Id = this.Id,
      Name = this.Name,
      Description = this.Description,
      MinimumChange = this.MinimumChange,
      IsoCode = this.IsoCode
    };
  }

  /// <summary>Gets Asset name</summary>
  /// <returns></returns>
  [NotPublished]
  public override string ToString() => this.Name;

  /// <summary>Uses comparison by Assets names</summary>
  /// <param name="obj"></param>
  /// <returns></returns>
  [NotPublished]
  public int CompareTo(object obj) => !(obj is Asset asset) ? 1 : this.Name.CompareTo(asset.Name);
}
