// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.ColumnBaseInformation
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils;

public class ColumnBaseInformation : IComparable, IXElementSerialization
{
  public string Name { get; [param: In] private set; }

  public TableBaseType Type { get; [param: In] private set; }

  public string HeaderText { get; [param: In] private set; }

  public bool IsIndicatorColumn { get; [param: In] private set; }

  public ColumnBaseInformation()
  {
  }

  public ColumnBaseInformation(
    string name,
    TableBaseType type,
    string headerText,
    bool isIndicatorColumn)
  {
    this.Name = name;
    this.Type = type;
    this.HeaderText = headerText;
    this.IsIndicatorColumn = isIndicatorColumn;
  }

  public int CompareTo(object obj) => this.Name.CompareTo(obj);

  public XElement ToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓤());
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픜(), (object) this.Name));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓼(), (object) this.Type.ToString()));
    return xelement;
  }

  public void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    XElement xelement = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓤());
    this.Name = xelement.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픜()).Value.ToString();
    this.Type = (TableBaseType) Enum.Parse(typeof (TableBaseType), xelement.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓼()).Value.ToString());
  }
}
