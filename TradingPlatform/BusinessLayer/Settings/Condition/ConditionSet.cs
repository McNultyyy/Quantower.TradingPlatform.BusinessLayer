// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Settings.Condition.ConditionSet
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer.Settings.Condition;

public sealed class ConditionSet : IXElementSerialization
{
  public List<ConditionItem> ConditionItems { get; set; }

  public ConditionSet() => this.ConditionItems = new List<ConditionItem>();

  public ConditionSet(ConditionSet conditionSet)
  {
    this.ConditionItems = conditionSet.ConditionItems.Select<ConditionItem, ConditionItem>((Func<ConditionItem, ConditionItem>) (([In] obj0) => new ConditionItem(obj0))).ToList<ConditionItem>();
  }

  public void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    List<ConditionItem> conditionItemList = new List<ConditionItem>();
    foreach (XElement element1 in element.Elements((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픮()))
    {
      ConditionItem conditionItem = new ConditionItem();
      conditionItem.FromXElement(element1, deserializationInfo);
      conditionItemList.Add(conditionItem);
    }
    this.ConditionItems = conditionItemList;
  }

  public XElement ToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁핃());
    foreach (ConditionItem conditionItem in this.ConditionItems)
      xelement.Add((object) conditionItem.ToXElement());
    return xelement;
  }
}
