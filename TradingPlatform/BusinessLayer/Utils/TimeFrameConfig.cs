// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.TimeFrameConfig
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils;

public class TimeFrameConfig : IXElementSerialization, ICloneable
{
  public List<string> TFList;

  /// <summary>
  /// Агрегація, що буде використовуватись як дефолтна для "TimeFrameScreen".
  /// Повинна відповідати агрегації чарта.
  /// </summary>
  public HistoryAggregation DefaultAggregation { get; set; }

  public TimeFrameConfig() => this.TFList = new List<string>();

  public void AddTF(HistoryAggregation info) => this.TFList.Add(info.ToString());

  public bool IsAllowed(HistoryAggregation otherTf)
  {
    return this.TFList.Count == 0 || otherTf == null || this.TFList.Contains(otherTf.ToString());
  }

  public XElement ToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픘());
    foreach (string tf in this.TFList)
      xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픨(), (object) tf));
    return xelement;
  }

  public void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    this.TFList = new List<string>();
    foreach (XElement element1 in element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픘()).Elements())
    {
      string str = element1.Value.ToString();
      if (str.StartsWith(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓪()) && str.EndsWith(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픹()) && str != \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픪())
        str = str.Replace(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓑(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓡());
      this.TFList.Add(str);
    }
  }

  public object Clone()
  {
    return (object) new TimeFrameConfig()
    {
      TFList = new List<string>((IEnumerable<string>) this.TFList),
      DefaultAggregation = (this.DefaultAggregation == null ? (HistoryAggregation) null : (HistoryAggregation) this.DefaultAggregation.Clone())
    };
  }
}
