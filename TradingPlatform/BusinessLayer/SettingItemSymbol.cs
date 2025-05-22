// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemSymbol
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>Typecasts setting as SymbolLookup item</summary>
[DataContract]
[Serializable]
public sealed class SettingItemSymbol : SettingItem
{
  public override SettingItemType Type => SettingItemType.Symbol;

  public SettingItemSymbol()
  {
  }

  public SettingItemSymbol(string name, Symbol value = null, int sortIndex = 0)
    : base(name, (object) value, sortIndex)
  {
  }

  private SettingItemSymbol([In] SettingItemSymbol obj0)
    : base((SettingItem) obj0)
  {
  }

  public override SettingItem GetCopy() => (SettingItem) new SettingItemSymbol(this);

  public static implicit operator Symbol(SettingItemSymbol item) => item.Value as Symbol;

  protected override bool IsValueTypeValid(object value) => value is Symbol;

  [DataMember(Name = "Value")]
  private BusinessObjectInfo ValueInfo
  {
    get
    {
      BusinessObjectInfo info = this.Value is Symbol symbol ? symbol.CreateInfo() : (BusinessObjectInfo) null;
      return (object) info != null ? info : BusinessObjectInfo.Empty;
    }
    [param: In] set
    {
      if (value == BusinessObjectInfo.Empty || value == (BusinessObjectInfo) SymbolInfo.Empty)
        return;
      this.Value = (object) Core.Instance.GetSymbol(value);
    }
  }

  protected override void ValueFromXElement(
    XElement element,
    DeserializationInfo deserializationInfo)
  {
    SymbolInfo empty = SymbolInfo.Empty;
    XElement element1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픍());
    if (element1 == null)
      return;
    empty.FromXElement(element1, deserializationInfo);
    this.ValueInfo = (BusinessObjectInfo) empty;
  }

  protected override XElement ValueToXElement() => this.ValueInfo.ToXElement();
}
