// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.Interval`1
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable enable
namespace TradingPlatform.BusinessLayer.Utils;

public readonly struct Interval<T>(
#nullable disable
T from, T to) : IEquatable<Interval<T>> where T : IComparable<T>
{
  public T From { get; } = from;

  public T To { get; } = to;

  public T Min => !this.IsReversal ? this.From : this.To;

  public T Max => !this.IsReversal ? this.To : this.From;

  public bool IsReversal => this.From.CompareTo(this.To) > 0;

  public bool IsEmpty => this.From.CompareTo(this.To) == 0;

  public static Interval<T> Default => new Interval<T>(default (T), default (T));

  public Interval<T> Reverse() => new Interval<T>(this.To, this.From);

  public bool Contains(T value)
  {
    ref T local1 = ref value;
    T obj;
    if ((object) default (T) == null)
    {
      obj = local1;
      local1 = ref obj;
    }
    T min = this.Min;
    if (local1.CompareTo(min) < 0)
      return false;
    ref T local2 = ref value;
    obj = default (T);
    if ((object) obj == null)
    {
      obj = local2;
      local2 = ref obj;
    }
    T max = this.Max;
    return local2.CompareTo(max) <= 0;
  }

  public Interval<T> Intersect(Interval<T> other)
  {
    T from = default (T);
    T to = default (T);
    if (this.Contains(other.Min))
    {
      from = other.Min;
      to = this.Contains(other.Max) ? other.Max : this.Max;
    }
    else if (this.Contains(other.Max))
    {
      from = this.Min;
      to = other.Max;
    }
    else if (other.Contains(this.Min) && other.Contains(this.Max))
      return this;
    return new Interval<T>(from, to);
  }

  public IEnumerable<Interval<T>> Subtract(IEnumerable<Interval<T>> intervals)
  {
    if (!this.IsEmpty)
    {
      if (!intervals.Any<Interval<퓏>>())
      {
        yield return this;
      }
      else
      {
        Interval<퓏>[] array = intervals.Select<Interval<퓏>, Interval<퓏>>(new Func<Interval<퓏>, Interval<퓏>>(this.Intersect)).Where<Interval<퓏>>((Func<Interval<퓏>, bool>) (([In] obj0) => !obj0.IsEmpty)).OrderBy<Interval<퓏>, 퓏>((Func<Interval<퓏>, 퓏>) (([In] obj0) => obj0.Min)).ThenByDescending<Interval<퓏>, 퓏>((Func<Interval<퓏>, 퓏>) (([In] obj0) => obj0.Max)).ToArray<Interval<퓏>>();
        퓏 from = this.Min;
        Interval<퓏>[] intervalArray = array;
        퓏 퓏;
        for (int index = 0; index < intervalArray.Length; ++index)
        {
          Interval<퓏> interval1 = intervalArray[index];
          if (interval1 == this)
            yield break;
          ref 퓏 local1 = ref from;
          퓏 = default (퓏);
          if ((object) 퓏 == null)
          {
            퓏 = local1;
            local1 = ref 퓏;
          }
          퓏 max1 = this.Max;
          if (local1.CompareTo(max1) == 0)
            yield break;
          ref 퓏 local2 = ref from;
          퓏 = default (퓏);
          if ((object) 퓏 == null)
          {
            퓏 = local2;
            local2 = ref 퓏;
          }
          퓏 max2 = interval1.Max;
          if (local2.CompareTo(max2) <= 0)
          {
            ref 퓏 local3 = ref from;
            퓏 = default (퓏);
            if ((object) 퓏 == null)
            {
              퓏 = local3;
              local3 = ref 퓏;
            }
            퓏 min = interval1.Min;
            if (local3.CompareTo(min) >= 0)
            {
              ref 퓏 local4 = ref from;
              퓏 = default (퓏);
              if ((object) 퓏 == null)
              {
                퓏 = local4;
                local4 = ref 퓏;
              }
              퓏 max3 = interval1.Max;
              if (local4.CompareTo(max3) < 0)
              {
                from = interval1.Max;
                continue;
              }
            }
            Interval<퓏> interval2 = new Interval<퓏>(from, interval1.Min);
            from = interval1.Max;
            yield return interval2;
          }
        }
        intervalArray = (Interval<퓏>[]) null;
        ref 퓏 local = ref from;
        퓏 = default (퓏);
        if ((object) 퓏 == null)
        {
          퓏 = local;
          local = ref 퓏;
        }
        퓏 max = this.Max;
        if (local.CompareTo(max) != 0)
          yield return new Interval<퓏>(from, this.Max);
      }
    }
  }

  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 2);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픂());
    interpolatedStringHandler.AppendFormatted<T>(this.From, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픾());
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓛());
    interpolatedStringHandler.AppendFormatted<T>(this.To, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픾());
    return interpolatedStringHandler.ToStringAndClear();
  }

  public bool Equals(Interval<T> other)
  {
    return EqualityComparer<T>.Default.Equals(this.From, other.From) && EqualityComparer<T>.Default.Equals(this.To, other.To);
  }

  public override bool Equals(object obj) => obj is Interval<T> other && this.Equals(other);

  public override int GetHashCode()
  {
    return HashCode.Combine<int, int>(EqualityComparer<T>.Default.GetHashCode(this.From), EqualityComparer<T>.Default.GetHashCode(this.To));
  }

  public static bool operator ==(Interval<T> left, Interval<T> right) => left.Equals(right);

  public static bool operator !=(Interval<T> left, Interval<T> right) => !left.Equals(right);
}
