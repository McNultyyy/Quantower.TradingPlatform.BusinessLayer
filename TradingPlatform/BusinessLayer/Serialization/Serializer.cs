// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Serialization.Serializer
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml.Linq;

#nullable enable
namespace TradingPlatform.BusinessLayer.Serialization;

public static class Serializer
{
  private const double 퓲퓦 = 1.3;
  /// <summary>
  /// Version 1.1: изменилась схема работы с коннектами: стали доступны кастомные коннекты
  /// </summary>
  public const double VERSION_NEW_CONNECTIONS_SCHEMA = 1.1;
  public const double VERSION_CHANGE_ENCRYPTION_KEY_SCHEMA = 1.2;
  public const double VERSION_CHANGE_DATE_TIME_SERIALIZATION_FORMAT = 1.3;
  public const double VERSION_CHANGE_HOTKEYS_SETTING_ITEM_CLASS_NAME = 1.4;
  public const 
  #nullable disable
  string CORE_SERIALIZATION_NAMESPACE_NAME = "TradingPlatform";

  public static bool SerializeXML(string filePath, List<IXElementSerialization> list)
  {
    try
    {
      XElement xelement = Serializer.퓏(list);
      if (xelement == null)
        return false;
      xelement.Save(filePath);
      return true;
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
      return false;
    }
  }

  public static bool SerializeXML(Stream stream, List<IXElementSerialization> list)
  {
    try
    {
      XElement xelement = Serializer.퓏(list);
      if (xelement == null)
        return false;
      xelement.Save(stream);
      return true;
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
      return false;
    }
  }

  public static List<IXElementSerialization> DeserializeXML(
    string filePath,
    out double version,
    Func<XElement, IXElementSerialization> fabric)
  {
    List<IXElementSerialization> xelementSerializationList = new List<IXElementSerialization>();
    version = 1.3;
    if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
      return xelementSerializationList;
    FileStream fileStream = (FileStream) null;
    try
    {
      fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
      xelementSerializationList = Serializer.DeserializeXML((Stream) fileStream, out version, fabric);
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
    finally
    {
      fileStream?.Close();
    }
    return xelementSerializationList;
  }

  public static List<IXElementSerialization> DeserializeXML(
    Stream stream,
    out double version,
    Func<XElement, IXElementSerialization> fabric)
  {
    List<IXElementSerialization> xelementSerializationList = new List<IXElementSerialization>();
    version = 1.3;
    if (stream == null)
      return xelementSerializationList;
    try
    {
      XElement xelement = XElement.Load(stream);
      DeserializationInfo info = new DeserializationInfo(fabric);
      if (double.TryParse(xelement.Attribute((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓩()).Value, NumberStyles.Float, (IFormatProvider) CultureInfo.InvariantCulture, out version))
        info.Version = version;
      foreach (XElement node in xelement.Nodes())
      {
        IXElementSerialization xelementSerialization = Serializer.DeserializeNode(node, info);
        if (xelementSerialization != null)
          xelementSerializationList.Add(xelementSerialization);
      }
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
    return xelementSerializationList;
  }

  public static IEnumerable<IXElementSerialization> DeserializeXML(
    XElement element,
    DeserializationInfo info)
  {
    IEnumerator<XNode> enumerator = element.Nodes().GetEnumerator();
    while (enumerator.MoveNext())
    {
      IXElementSerialization xelementSerialization = Serializer.DeserializeNode((XElement) enumerator.Current, info);
      if (xelementSerialization != null)
        yield return xelementSerialization;
    }
    // ISSUE: reference to a compiler-generated method
    this.퓬();
    enumerator = (IEnumerator<XNode>) null;
  }

  public static IXElementSerialization DeserializeNode(XElement node, DeserializationInfo info)
  {
    try
    {
      IXElementSerialization xelementSerialization = info.CreateObject(node);
      xelementSerialization?.FromXElement(node, info);
      return xelementSerialization;
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓨());
    }
    return (IXElementSerialization) null;
  }

  private static XElement 퓏([In] List<IXElementSerialization> obj0)
  {
    try
    {
      XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓱(), (object) new XAttribute((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓩(), (object) 1.3));
      for (int index = 0; index < obj0.Count; ++index)
      {
        try
        {
          xelement.Add((object) obj0[index].ToXElement());
        }
        catch (Exception ex)
        {
          Core.Instance.Loggers.Log(ex);
        }
      }
      return xelement;
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
      return (XElement) null;
    }
  }
}
