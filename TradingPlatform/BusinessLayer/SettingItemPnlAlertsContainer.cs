// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemPnlAlertsContainer
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

public class SettingItemPnlAlertsContainer : SettingItem
{
  public override SettingItemType Type => SettingItemType.PnlAlertsContainer;

  public SettingItemPnlAlertsContainer()
  {
  }

  public SettingItemPnlAlertsContainer(
    string name,
    PnlAlertsContainer pnLAlertsCollection,
    int sortIndex = 0)
    : base(name, (object) pnLAlertsCollection, sortIndex)
  {
  }

  public SettingItemPnlAlertsContainer(SettingItemPnlAlertsContainer settingItem)
    : base((SettingItem) settingItem)
  {
    this.value = (object) ((PnlAlertsContainer) settingItem.Value).Clone();
  }

  public override SettingItem GetCopy() => (SettingItem) new SettingItemPnlAlertsContainer(this);

  [DataMember(Name = "Value")]
  [ProtoMember(1)]
  private PnlAlertsContainer PnlAlertsContainer
  {
    get => (PnlAlertsContainer) this.Value;
    [param: In] set => this.Value = (object) value;
  }

  protected override bool IsValueTypeValid(object value) => value is PnlAlertsContainer;

  protected override XElement ValueToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픰());
    foreach (PnlAlertItem pnlAlert in this.PnlAlertsContainer.PnlAlerts)
    {
      XElement content = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓢());
      content.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓪(), (object) pnlAlert.IsChecked));
      if (pnlAlert.Symbol != null)
        content.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픟(), (object) pnlAlert.Symbol.CreateInfo().ToXElement()));
      content.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픫(), (object) pnlAlert.TargetValue));
      content.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픝(), (object) pnlAlert.Increment));
      content.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓨(), (object) pnlAlert.Precision));
      xelement.Add((object) content);
    }
    return xelement;
  }

  protected override void ValueFromXElement(
    XElement element,
    DeserializationInfo deserializationInfo)
  {
    XElement xelement1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픰());
    if (xelement1 != null)
      element = xelement1;
    List<PnlAlertItem> pnlAlertItemList = new List<PnlAlertItem>();
    IEnumerable<XElement> xelements = element.Elements((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓢());
    if (xelements != null)
    {
      foreach (XElement xelement2 in xelements)
      {
        PnlAlertItem pnlAlertItem1 = new PnlAlertItem();
        XElement element1 = xelement2.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓪());
        pnlAlertItem1.IsChecked = element1 != null && element1.ToBool();
        XElement element2 = xelement2.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픫());
        pnlAlertItem1.TargetValue = element2 != null ? element2.ToDouble() : 0.0;
        XElement element3 = xelement2.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픝());
        pnlAlertItem1.Increment = element3 != null ? element3.ToDouble() : 1.0;
        XElement element4 = xelement2.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓨());
        pnlAlertItem1.Precision = element4 != null ? element4.ToInt() : 0;
        PnlAlertItem pnlAlertItem2 = pnlAlertItem1;
        XElement xelement3 = xelement2.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픟());
        if (xelement3 != null)
        {
          XElement element5 = xelement3.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픍());
          if (element5 != null)
          {
            BusinessObjectInfo symbolInfo = new BusinessObjectInfo();
            symbolInfo.FromXElement(element5, deserializationInfo);
            pnlAlertItem2.Symbol = Core.Instance.GetSymbol(symbolInfo);
          }
        }
        pnlAlertItemList.Add(pnlAlertItem2);
      }
    }
    this.Value = (object) new PnlAlertsContainer()
    {
      PnlAlerts = pnlAlertItemList.ToArray()
    };
  }
}
