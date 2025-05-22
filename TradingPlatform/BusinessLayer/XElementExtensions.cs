// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.XElementExtensions
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public static class XElementExtensions
{
  public static bool ToBool(this XElement element)
  {
    bool result;
    return bool.TryParse(element.Value, out result) && result;
  }

  public static int ToInt(this XElement element)
  {
    int result;
    return !int.TryParse(element.Value, out result) ? 0 : result;
  }

  public static long ToLong(this XElement element)
  {
    long result;
    return !long.TryParse(element.Value, out result) ? 0L : result;
  }

  public static double ToDouble(this XElement element)
  {
    double result;
    return !double.TryParse(element.Value, NumberStyles.Float, (IFormatProvider) CultureInfo.InvariantCulture, out result) ? 0.0 : result;
  }

  public static Decimal ToDecimal(this XElement element)
  {
    Decimal result;
    return !Decimal.TryParse(element.Value, out result) ? 0M : result;
  }

  public static DateTime ToDateTime(this XElement element, bool toUTC = false)
  {
    DateTime result;
    if (!DateTime.TryParse(element.Value, out result))
      return new DateTime();
    return !toUTC ? result : result.ToUniversalTime();
  }

  public static DateTime ToDateTime(this XElement element, string format)
  {
    DateTime result;
    return DateTime.TryParseExact(element.Value, format, (IFormatProvider) CultureInfo.InvariantCulture, DateTimeStyles.None, out result) ? DateTime.SpecifyKind(result, DateTimeKind.Utc) : new DateTime();
  }

  public static TimeSpan ToTimeSpan(this XElement element)
  {
    TimeSpan result;
    return !TimeSpan.TryParse(element.Value, out result) ? new TimeSpan() : result;
  }

  public static Color ToColor(this XElement element)
  {
    if (string.IsNullOrEmpty(element.Value))
      return Color.Empty;
    int length = element.Value.IndexOf(',');
    int num1 = element.Value.IndexOf(',', length + 1);
    int num2 = element.Value.IndexOf(',', num1 + 1);
    return Color.FromArgb(int.Parse(element.Value.Substring(num2 + 1, element.Value.Length - num2 - 1)), int.Parse(element.Value.Substring(0, length)), int.Parse(element.Value.Substring(length + 1, num1 - length - 1)), int.Parse(element.Value.Substring(num1 + 1, num2 - num1 - 1)));
  }

  public static XElement ToXElement(this Color color, string nodeName = "Color")
  {
    XName name = (XName) nodeName;
    string content;
    if (!color.IsEmpty)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 4);
      interpolatedStringHandler.AppendFormatted<byte>(color.R);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픧());
      interpolatedStringHandler.AppendFormatted<byte>(color.G);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픧());
      interpolatedStringHandler.AppendFormatted<byte>(color.B);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픧());
      interpolatedStringHandler.AppendFormatted<byte>(color.A);
      content = interpolatedStringHandler.ToStringAndClear();
    }
    else
      content = string.Empty;
    return new XElement(name, (object) content);
  }

  public static Font ToFont(this XElement element)
  {
    if (string.IsNullOrEmpty(element.Value))
      return (Font) null;
    int length = element.Value.IndexOf(',');
    int num1 = element.Value.IndexOf(',', length + 1);
    int num2 = element.Value.IndexOf(',', num1 + 1);
    float result;
    float.TryParse(element.Value.Substring(length + 1, num1 - length - 1), NumberStyles.Float, (IFormatProvider) CultureInfo.InvariantCulture, out result);
    return new Font(element.Value.Substring(0, length), result, (FontStyle) int.Parse(element.Value.Substring(num1 + 1, num2 - num1 - 1)), (GraphicsUnit) int.Parse(element.Value.Substring(num2 + 1, element.Value.Length - num2 - 1)));
  }

  public static XElement ToXElement(this Font font, string nodeName = "Font")
  {
    XName name = (XName) nodeName;
    string content;
    if (font != null)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 4);
      interpolatedStringHandler.AppendFormatted(font.Name);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픧());
      interpolatedStringHandler.AppendFormatted(font.Size.ToString((IFormatProvider) CultureInfo.InvariantCulture));
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픧());
      interpolatedStringHandler.AppendFormatted<int>((int) font.Style);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픧());
      interpolatedStringHandler.AppendFormatted<int>((int) font.Unit);
      content = interpolatedStringHandler.ToStringAndClear();
    }
    else
      content = string.Empty;
    return new XElement(name, (object) content);
  }
}
