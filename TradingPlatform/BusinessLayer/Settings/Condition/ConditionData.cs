// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Settings.Condition.ConditionData
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

public sealed class ConditionData : IXElementSerialization
{
  /// <summary>Gets or Sets the groups.</summary>
  public List<ConditionSet> ConditionGroups { get; set; }

  public ConditionData() => this.ConditionGroups = new List<ConditionSet>();

  public ConditionData(ConditionData conditions)
  {
    this.ConditionGroups = conditions.ConditionGroups.Select<ConditionSet, ConditionSet>((Func<ConditionSet, ConditionSet>) (([In] obj0) => new ConditionSet(obj0))).ToList<ConditionSet>();
  }

  public XElement ToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픛());
    XElement content = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁프());
    foreach (ConditionSet conditionGroup in this.ConditionGroups)
      content.Add((object) conditionGroup.ToXElement());
    xelement.Add((object) content);
    return xelement;
  }

  public void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    XElement xelement = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픛());
    List<ConditionSet> conditionSetList = new List<ConditionSet>();
    XName name = (XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁프();
    foreach (XElement element1 in xelement.Element(name).Elements())
    {
      ConditionSet conditionSet = new ConditionSet();
      conditionSet.FromXElement(element1, deserializationInfo);
      conditionSetList.Add(conditionSet);
    }
    this.ConditionGroups = conditionSetList;
  }
}
