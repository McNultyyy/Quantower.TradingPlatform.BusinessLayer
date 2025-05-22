// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Session
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using ProtoBuf;
using System;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[ProtoContract]
public class Session : ISession, IXElementSerialization
{
  [ProtoMember(1)]
  public string Name { get; [param: In] private set; }

  [ProtoMember(2)]
  public TimeSpan OpenTime { get; [param: In] private set; }

  [ProtoMember(3)]
  public TimeSpan CloseTime { get; [param: In] private set; }

  [ProtoMember(4)]
  public SessionType Type { get; [param: In] private set; }

  [ProtoMember(5)]
  public bool IsPrimary { get; set; }

  public Session(
    string name,
    TimeSpan openTime,
    TimeSpan closeTime,
    SessionType type = SessionType.Main,
    bool isPrimary = false)
    : this()
  {
    this.Name = name;
    this.OpenTime = openTime;
    this.CloseTime = closeTime;
    this.Type = type;
    this.IsPrimary = isPrimary;
  }

  public Session(Session session)
    : this(session.Name, session.OpenTime, session.CloseTime, session.Type, session.IsPrimary)
  {
  }

  internal Session() => this.Type = SessionType.Main;

  public XElement ToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍플());
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픜(), (object) this.Name));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픥(), (object) this.OpenTime));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픥(), (object) this.OpenTime));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓼(), (object) (int) this.Type));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓴(), (object) this.IsPrimary));
    return xelement;
  }

  public void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    XElement xelement = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픜());
    if (xelement != null)
      this.Name = xelement.Value;
    XElement element1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픥());
    if (element1 != null)
      this.OpenTime = element1.ToTimeSpan();
    XElement element2 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픳());
    if (element2 != null)
      this.CloseTime = element2.ToTimeSpan();
    XElement element3 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓼());
    if (element3 != null)
      this.Type = (SessionType) element3.ToInt();
    XElement element4 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓴());
    if (element4 == null)
      return;
    this.IsPrimary = element4.ToBool();
  }
}
