﻿// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Settings.OTP.OTPHolder
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer.Settings.OTP;

public class OTPHolder : IXElementSerialization, ICloneable
{
  public Action Callback;

  public string OTPValue { get; set; }

  public void RequestOTP(string title, string text) => Core.Instance.RequestOTP(this, title, text);

  public XElement ToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁핉());
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁핊(), (object) this.OTPValue));
    return xelement;
  }

  public void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    this.OTPValue = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁핊()).Value;
  }

  public object Clone()
  {
    return (object) new OTPHolder()
    {
      OTPValue = this.OTPValue
    };
  }
}
