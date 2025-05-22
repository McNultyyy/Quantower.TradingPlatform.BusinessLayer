// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemTimeInTradeContainer
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using ProtoBuf;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public class SettingItemTimeInTradeContainer : SettingItem
{
  [DataMember(Name = "Value")]
  [ProtoMember(1)]
  private TimeInTradeContainer TimeInTradeContainer
  {
    get => (TimeInTradeContainer) this.Value;
    [param: In] set => this.Value = (object) value;
  }

  public override SettingItemType Type => SettingItemType.TimeInTradeContainer;

  public SettingItemTimeInTradeContainer()
  {
  }

  public SettingItemTimeInTradeContainer(
    string name,
    TimeInTradeContainer timeInTradeCollection,
    int sortIndex = 0)
    : base(name, (object) timeInTradeCollection, sortIndex)
  {
  }

  public SettingItemTimeInTradeContainer(SettingItemTimeInTradeContainer settingItem)
  {
    this.value = (object) ((TimeInTradeContainer) settingItem.Value).Clone();
  }

  public override SettingItem GetCopy() => (SettingItem) new SettingItemTimeInTradeContainer(this);

  protected override bool IsValueTypeValid(object value) => value is TimeInTradeContainer;

  protected override XElement ValueToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픥());
    foreach (TimeInTradeItem timeInTradeItem in this.TimeInTradeContainer.TimeInTradeItems)
    {
      XElement content = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓼());
      content.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓪(), (object) timeInTradeItem.IsChecked));
      if (timeInTradeItem.Symbol != null)
        content.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픟(), (object) timeInTradeItem.Symbol.CreateInfo().ToXElement()));
      content.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓴(), (object) timeInTradeItem.TimeInSeconds));
      content.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픳(), (object) (int) timeInTradeItem.PLDirection));
      xelement.Add((object) content);
    }
    return xelement;
  }

  protected override void ValueFromXElement(
    XElement element,
    DeserializationInfo deserializationInfo)
  {
    XElement xelement1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픥());
    if (xelement1 != null)
      element = xelement1;
    List<TimeInTradeItem> timeInTradeItemList = new List<TimeInTradeItem>();
    IEnumerable<XElement> xelements = element.Elements((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓼());
    if (xelements != null)
    {
      foreach (XElement xelement2 in xelements)
      {
        TimeInTradeItem timeInTradeItem1 = new TimeInTradeItem();
        XElement element1 = xelement2.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓪());
        timeInTradeItem1.IsChecked = element1 != null && element1.ToBool();
        XElement element2 = xelement2.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓴());
        timeInTradeItem1.TimeInSeconds = element2 != null ? element2.ToInt() : 0;
        XElement element3 = xelement2.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픳());
        timeInTradeItem1.PLDirection = element3 != null ? (TimeInTradePlDirection) element3.ToInt() : TimeInTradePlDirection.Any;
        TimeInTradeItem timeInTradeItem2 = timeInTradeItem1;
        XElement xelement3 = xelement2.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픟());
        if (xelement3 != null)
        {
          XElement element4 = xelement3.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픍());
          if (element4 != null)
          {
            BusinessObjectInfo symbolInfo = new BusinessObjectInfo();
            symbolInfo.FromXElement(element4, deserializationInfo);
            timeInTradeItem2.Symbol = Core.Instance.GetSymbol(symbolInfo);
          }
        }
        timeInTradeItemList.Add(timeInTradeItem2);
      }
    }
    this.Value = (object) new TimeInTradeContainer()
    {
      TimeInTradeItems = timeInTradeItemList.ToArray()
    };
  }
}
