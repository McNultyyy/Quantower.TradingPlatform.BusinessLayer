// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.ActionWrapper
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System.Collections.Generic;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils;

/// <summary>The action wrapper.</summary>
public class ActionWrapper : IXElementSerialization
{
  /// <summary>Gets or Sets the items.</summary>
  public List<SettingItem> Items { get; set; }

  /// <summary>
  /// Initializes a new instance of the <see cref="T:TradingPlatform.BusinessLayer.Utils.ActionWrapper" /> class.
  /// </summary>
  public ActionWrapper() => this.Items = new List<SettingItem>();

  /// <summary>Froms the X element.</summary>
  /// <param name="element">The element.</param>
  /// <param name="deserializationInfo">The deserialization info.</param>
  public void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    foreach (XElement element1 in element.Elements((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁핋()))
    {
      if (Serializer.DeserializeNode(element1, deserializationInfo) is SettingItem settingItem)
        this.Items.Add(settingItem);
    }
  }

  /// <summary>Tos the X element.</summary>
  /// <returns>A XElement.</returns>
  public XElement ToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓞());
    foreach (SettingItem settingItem in this.Items)
      xelement.Add((object) settingItem.ToXElement());
    return xelement;
  }
}
