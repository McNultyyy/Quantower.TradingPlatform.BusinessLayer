// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Serialization.DeserializationInfo
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Xml.Linq;

#nullable disable
namespace TradingPlatform.BusinessLayer.Serialization;

public class DeserializationInfo
{
  private readonly Func<XElement, IXElementSerialization> 퓲퓸;

  public double Version { get; set; }

  private DeserializationInfo() => this.Version = 1.0;

  public DeserializationInfo(Func<XElement, IXElementSerialization> fabric)
    : this()
  {
    this.퓲퓸 = fabric;
  }

  public IXElementSerialization CreateObject(XElement node)
  {
    try
    {
      Func<XElement, IXElementSerialization> 퓲퓸 = this.퓲퓸;
      return 퓲퓸 != null ? 퓲퓸(node) : (IXElementSerialization) null;
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex.Message, LoggingLevel.Verbose);
      return (IXElementSerialization) null;
    }
  }
}
