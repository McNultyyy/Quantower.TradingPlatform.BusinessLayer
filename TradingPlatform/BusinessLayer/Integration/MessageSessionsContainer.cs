// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.MessageSessionsContainer
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using ProtoBuf;
using System.Collections.Generic;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

[ProtoContract]
public class MessageSessionsContainer : Message, IXElementSerialization
{
  public override MessageType Type => MessageType.Session;

  [ProtoMember(1)]
  public string Id { get; set; }

  [ProtoMember(2)]
  public string Name { get; set; }

  [ProtoMember(3)]
  public string Description { get; set; }

  [ProtoMember(4)]
  public HolidayInfo[] Holidays { get; set; }

  [ProtoMember(5)]
  public SessionsSet[] SessionsSets { get; set; }

  public void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    XElement xelement1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓶());
    if (xelement1 != null)
      this.Id = xelement1.Value;
    XElement xelement2 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픜());
    if (xelement2 != null)
      this.Name = xelement2.Value;
    XElement xelement3 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓵());
    if (xelement3 != null)
      this.Description = xelement3.Value;
    XElement xelement4 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇피());
    if (xelement4 != null)
    {
      List<HolidayInfo> holidayInfoList = new List<HolidayInfo>();
      foreach (XElement element1 in xelement4.Elements())
      {
        HolidayInfo holidayInfo = new HolidayInfo();
        holidayInfo.FromXElement(element1, deserializationInfo);
        holidayInfoList.Add(holidayInfo);
      }
      this.Holidays = holidayInfoList.ToArray();
    }
    XElement xelement5 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓸());
    if (xelement5 == null)
      return;
    List<SessionsSet> sessionsSetList = new List<SessionsSet>();
    foreach (XElement element2 in xelement5.Elements())
    {
      SessionsSet sessionsSet = new SessionsSet();
      sessionsSet.FromXElement(element2, deserializationInfo);
      sessionsSetList.Add(sessionsSet);
    }
    this.SessionsSets = sessionsSetList.ToArray();
  }

  public XElement ToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓦());
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓶(), (object) this.Id));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픜(), (object) this.Name));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓵(), (object) this.Description));
    XElement content1 = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇피());
    if (this.Holidays != null)
    {
      foreach (HolidayInfo holiday in this.Holidays)
        content1.Add((object) holiday.ToXElement());
    }
    xelement.Add((object) content1);
    XElement content2 = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓸());
    foreach (SessionsSet sessionsSet in this.SessionsSets)
      content2.Add((object) sessionsSet.ToXElement());
    xelement.Add((object) content2);
    return xelement;
  }
}
