// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.AssetFormattingDescription
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

/// <summary>The asset formatting description.</summary>
public class AssetFormattingDescription : FormattingDescription<double>
{
  private readonly string 핂픞;
  private readonly bool 핂핁;

  /// <summary>
  /// Initializes a new instance of the <see cref="T:TradingPlatform.BusinessLayer.Integration.AssetFormattingDescription" /> class.
  /// </summary>
  /// <param name="assetId">The asset id.</param>
  /// <param name="value">The value.</param>
  /// <param name="addCurrencyName">If true, add currency name.</param>
  public AssetFormattingDescription(string assetId, double value, bool addCurrencyName = true)
    : base(value)
  {
    this.핂픞 = assetId;
    this.핂핁 = addCurrencyName;
  }

  protected override bool IsValueValid(double value)
  {
    return !double.IsNaN(value) && base.IsValueValid(value);
  }

  protected override string FormatValue(double value)
  {
    Connection connection = Core.Instance.Connections[this.ConnectionId];
    Asset asset1;
    if (connection == null)
    {
      asset1 = (Asset) null;
    }
    else
    {
      IBusinessObjectsProvider businessObjects = connection.BusinessObjects;
      asset1 = businessObjects != null ? ((IEnumerable<Asset>) businessObjects.Assets).FirstOrDefault<Asset>((Func<Asset, bool>) (([In] obj0) => obj0.Id == this.핂픞)) : (Asset) null;
    }
    Asset asset2 = asset1;
    if (asset2 == null)
      return value.Format();
    return !this.핂핁 ? asset2.FormatPrice(value) : asset2.FormatPriceWithCurrency(value);
  }
}
