// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.TimeZone
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public readonly struct TimeZone : IEquatable<TimeZone>, IComparable<TimeZone>, IComparable
{
  public TimeZoneInfo TimeZoneInfo { get; }

  public TimeZoneType Type { get; }

  public bool IsEmpty => this.Type == TimeZoneType.Specific && this.TimeZoneInfo == null;

  public TimeZone(TimeZoneType type, TimeZoneInfo timeZoneInfo = null)
  {
    if (type == TimeZoneType.Local && timeZoneInfo != null)
      throw new ArgumentException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픙());
    this.Type = type != TimeZoneType.Specific || timeZoneInfo != null ? type : throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓭());
    this.TimeZoneInfo = type == TimeZoneType.Local ? TimeZoneInfo.Local : timeZoneInfo;
  }

  public static string ShortName(TimeZone timeZone)
  {
    return timeZone.Type != TimeZoneType.Local ? TimeZone.퓏(timeZone.TimeZoneInfo, false) : \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓣();
  }

  public static string Cities(TimeZone timeZone) => TimeZone.퓏(timeZone.TimeZoneInfo, true);

  private static string 퓏([In] TimeZoneInfo obj0, [In] bool obj1)
  {
    if (obj0 == null)
      return string.Empty;
    if (obj0.Id == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픦())
      return \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픍();
    if (!obj1)
      return \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프() + obj0.DisplayName.Substring(1, obj0.DisplayName.IndexOf(')') - 1);
    int startIndex = obj0.DisplayName.IndexOf(')') + 1;
    return \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프() + obj0.DisplayName.Substring(startIndex, obj0.DisplayName.Length - startIndex);
  }

  public static bool operator ==(TimeZone timeZone1, TimeZone timeZone2)
  {
    return timeZone1.Type == timeZone2.Type && timeZone1.TimeZoneInfo?.Id == timeZone2.TimeZoneInfo?.Id;
  }

  public static bool operator !=(TimeZone timeZone1, TimeZone timeZone2)
  {
    return timeZone1.Type != timeZone2.Type || timeZone1.TimeZoneInfo?.Id != timeZone2.TimeZoneInfo?.Id;
  }

  public bool Equals(TimeZone other)
  {
    return object.Equals((object) this.TimeZoneInfo, (object) other.TimeZoneInfo) && this.Type == other.Type;
  }

  public override bool Equals(object obj) => obj is TimeZone other && this.Equals(other);

  public override int GetHashCode()
  {
    return (int) ((TimeZoneType) ((this.TimeZoneInfo != null ? this.TimeZoneInfo.GetHashCode() : 0) * 397) ^ this.Type);
  }

  public int CompareTo(TimeZone other)
  {
    if (this.TimeZoneInfo == null)
      return 1;
    if (other.TimeZoneInfo == null)
      return -1;
    int num = this.TimeZoneInfo.BaseUtcOffset.CompareTo(other.TimeZoneInfo.BaseUtcOffset);
    return num != 0 ? num : string.Compare(this.TimeZoneInfo.Id, other.TimeZoneInfo.Id, StringComparison.Ordinal);
  }

  public int CompareTo(object obj) => obj is TimeZone other ? this.CompareTo(other) : 0;

  public override string ToString() => this.TimeZoneInfo?.DisplayName;
}
