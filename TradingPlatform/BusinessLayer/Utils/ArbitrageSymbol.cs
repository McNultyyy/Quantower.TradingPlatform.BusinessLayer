// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.ArbitrageSymbol
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils;

/// <summary>The arbitrage symbol.</summary>
[Serializable]
public class ArbitrageSymbol : IXElementSerialization, IComparable<ArbitrageSymbol>
{
  /// <summary>Gets or Sets the index.</summary>
  public int Index { get; set; }

  /// <summary>Gets the unique ID.</summary>
  public Guid UniqueID { get; }

  /// <summary>Gets the symbol id.</summary>
  public string SymbolId
  {
    get
    {
      return this.Symbol == null ? \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픿() : this.Symbol.ConnectionId + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픉() + this.Symbol.Id;
    }
  }

  /// <summary>Gets or Sets a value indicating whether is selected.</summary>
  public bool IsSelected { get; set; }

  /// <summary>Gets or Sets the symbol.</summary>
  public Symbol Symbol { get; set; }

  /// <summary>Gets or Sets the account.</summary>
  public Account Account { get; set; }

  /// <summary>Gets or Sets the commission.</summary>
  public double Commission { get; set; }

  /// <summary>
  /// Initializes a new instance of the <see cref="T:TradingPlatform.BusinessLayer.Utils.ArbitrageSymbol" /> class.
  /// </summary>
  public ArbitrageSymbol() => this.UniqueID = Guid.NewGuid();

  /// <summary>Compare to.</summary>
  /// <param name="other">The other.</param>
  /// <returns>An int.</returns>
  public int CompareTo(ArbitrageSymbol other) => this.Index.CompareTo(other.Index);

  /// <summary>Froms the X element.</summary>
  /// <param name="element">The element.</param>
  /// <param name="deserializationInfo">The deserialization info.</param>
  public void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    XElement element1 = element.XPathSelectElement(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓔());
    if (element1 != null)
    {
      BusinessObjectInfo symbolInfo = new BusinessObjectInfo();
      symbolInfo.FromXElement(element1, deserializationInfo);
      this.Symbol = Core.Instance.GetSymbol(symbolInfo);
    }
    XElement element2 = element.XPathSelectElement(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픢());
    if (element2 != null)
    {
      BusinessObjectInfo accountInfo = new BusinessObjectInfo();
      accountInfo.FromXElement(element2, deserializationInfo);
      this.Account = Core.Instance.GetAccount(accountInfo);
    }
    this.IsSelected = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓝()).ToBool();
    this.Commission = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓶()).ToDouble();
  }

  /// <summary>Tos the X element.</summary>
  /// <returns>A XElement.</returns>
  public XElement ToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓽());
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓝(), (object) this.IsSelected));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픟(), (object) this.Symbol?.CreateInfo().ToXElement()));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픆(), (object) this.Account?.CreateInfo().ToXElement()));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓶(), (object) this.Commission));
    return xelement;
  }
}
