// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SessionsSet
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[ProtoContract]
public class SessionsSet : IXElementSerialization
{
  [ProtoMember(1)]
  public Session[] Sessions { get; set; }

  [ProtoMember(2)]
  public DayOfWeek[] Days { get; set; }

  [ProtoMember(3)]
  public DateTime[] CertainDates { get; set; }

  public SessionsSet()
  {
  }

  internal SessionsSet([In] SessionsSet obj0_1)
  {
    this.Sessions = ((IEnumerable<Session>) obj0_1.Sessions).Select<Session, Session>((Func<Session, Session>) (([In] obj0_2) => new Session(obj0_2))).ToArray<Session>();
    this.Days = obj0_1.Days?.Clone() as DayOfWeek[];
    DateTime[] certainDates = obj0_1.CertainDates;
    this.CertainDates = certainDates != null ? ((IEnumerable<DateTime>) certainDates).ToArray<DateTime>() : (DateTime[]) null;
  }

  public XElement ToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픚());
    XElement content1 = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픙());
    foreach (Session session in this.Sessions)
      content1.Add((object) session.ToXElement());
    xelement.Add((object) content1);
    XElement content2 = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓭());
    foreach (DayOfWeek day in this.Days)
      content2.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓣(), (object) (int) day));
    xelement.Add((object) content2);
    if (this.CertainDates != null)
    {
      XElement content3 = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓭());
      foreach (DateTime certainDate in this.CertainDates)
        content3.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓵(), (object) certainDate));
      xelement.Add((object) content3);
    }
    return xelement;
  }

  public void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    XElement xelement1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픙());
    if (xelement1 != null)
    {
      List<Session> sessionList = new List<Session>();
      foreach (XElement element1 in xelement1.Elements())
      {
        Session session = new Session();
        session.FromXElement(element1, deserializationInfo);
        sessionList.Add(session);
      }
      this.Sessions = sessionList.ToArray();
    }
    XElement xelement2 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓭());
    if (xelement2 != null)
      this.Days = xelement2.Elements().Select<XElement, DayOfWeek>((Func<XElement, DayOfWeek>) (([In] obj0) => (DayOfWeek) obj0.ToInt())).ToArray<DayOfWeek>();
    XElement xelement3 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픦());
    if (xelement3 == null)
      return;
    this.CertainDates = xelement3.Elements().Select<XElement, DateTime>((Func<XElement, DateTime>) (([In] obj0) => obj0.ToDateTime(true))).ToArray<DateTime>();
  }
}
