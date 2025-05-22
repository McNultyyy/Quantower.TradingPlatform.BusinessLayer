// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.AdditionalInfoCollection
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using TradingPlatform.BusinessLayer.Utils.EqualityComparers;

#nullable enable
namespace TradingPlatform.BusinessLayer;

/// <summary>The additional info collection.</summary>
public class AdditionalInfoCollection : 
  IEnumerable<
  #nullable disable
  AdditionalInfoItem>,
  IEnumerable,
  IEquatable<AdditionalInfoCollection>
{
  private readonly Dictionary<string, AdditionalInfoItem> 퓲;
  private readonly object 핂;
  private static readonly ListEqualityComparer<AdditionalInfoItem> 픂 = new ListEqualityComparer<AdditionalInfoItem>((IEqualityComparer<AdditionalInfoItem>) EqualityComparer<AdditionalInfoItem>.Default);

  /// <summary>Gets the count.</summary>
  public int Count => this.퓲.Count;

  public AdditionalInfoItem this[string key]
  {
    get
    {
      AdditionalInfoItem additionalInfoItem;
      if (this.TryGetItem(key, out additionalInfoItem))
        return additionalInfoItem;
      throw new KeyNotFoundException();
    }
  }

  /// <summary>Gets the items.</summary>
  public IEnumerable<AdditionalInfoItem> Items
  {
    get
    {
      object obj = this.핂;
      bool lockTaken = false;
      Monitor.Enter(obj, ref lockTaken);
      Dictionary<string, AdditionalInfoItem>.Enumerator enumerator = this.퓲.GetEnumerator();
      while (enumerator.MoveNext())
        yield return enumerator.Current.Value.Clone() as AdditionalInfoItem;
      this.핇();
      enumerator = new Dictionary<string, AdditionalInfoItem>.Enumerator();
      this.퓬();
      obj = (object) null;
    }
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="T:TradingPlatform.BusinessLayer.AdditionalInfoCollection" /> class.
  /// </summary>
  public AdditionalInfoCollection()
  {
    this.퓲 = new Dictionary<string, AdditionalInfoItem>();
    this.핂 = new object();
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="T:TradingPlatform.BusinessLayer.AdditionalInfoCollection" /> class.
  /// </summary>
  /// <param name="items">The items.</param>
  public AdditionalInfoCollection(params AdditionalInfoItem[] items)
    : this()
  {
    foreach (AdditionalInfoItem additionalInfoItem in items)
      this.퓏(additionalInfoItem);
  }

  /// <summary>Try get item.</summary>
  /// <param name="apiKey">The api key.</param>
  /// <param name="item">The item.</param>
  /// <returns>A bool.</returns>
  public bool TryGetItem(string apiKey, out AdditionalInfoItem item)
  {
    item = (AdditionalInfoItem) null;
    lock (this.핂)
    {
      AdditionalInfoItem additionalInfoItem;
      if (this.퓲.TryGetValue(apiKey, out additionalInfoItem))
      {
        item = additionalInfoItem.Clone() as AdditionalInfoItem;
        return true;
      }
    }
    return false;
  }

  internal void 퓏([In] AdditionalInfoItem obj0)
  {
    lock (this.핂)
    {
      AdditionalInfoItem additionalInfoItem;
      if (!this.퓲.TryGetValue(obj0.Id, out additionalInfoItem))
      {
        additionalInfoItem = new AdditionalInfoItem();
        this.퓲.Add(obj0.Id, additionalInfoItem);
      }
      additionalInfoItem.Update(obj0);
    }
  }

  internal void 퓏([In] IEnumerable<SettingItem> obj0)
  {
    lock (this.핂)
    {
      foreach (SettingItem settingItem in obj0)
      {
        AdditionalInfoItem additionalInfoItem;
        if (this.퓲.TryGetValue(settingItem.Name, out additionalInfoItem))
          additionalInfoItem.Value = settingItem.Value;
      }
    }
  }

  /// <summary>Gets the enumerator.</summary>
  /// <returns><![CDATA[IEnumerator<AdditionalInfoItem>]]></returns>
  public IEnumerator<AdditionalInfoItem> GetEnumerator() => this.Items.GetEnumerator();

  IEnumerator IEnumerable.퓏() => (IEnumerator) this.GetEnumerator();

  /// <summary>Tos the string.</summary>
  /// <returns>A string.</returns>
  public override string ToString()
  {
    StringBuilder stringBuilder1 = new StringBuilder();
    foreach (AdditionalInfoItem additionalInfoItem in this)
    {
      if (!additionalInfoItem.Hidden && additionalInfoItem.Visible)
      {
        string str = additionalInfoItem.FormattingDescription == null ? additionalInfoItem.Value.ToString() : additionalInfoItem.FormattingDescription.GetFormattedData();
        StringBuilder.AppendInterpolatedStringHandler interpolatedStringHandler;
        if (!string.IsNullOrEmpty(additionalInfoItem.NameKey) || !string.IsNullOrEmpty(str))
        {
          if (string.IsNullOrEmpty(additionalInfoItem.NameKey))
          {
            StringBuilder stringBuilder2 = stringBuilder1;
            StringBuilder stringBuilder3 = stringBuilder2;
            interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(2, 1, stringBuilder2);
            interpolatedStringHandler.AppendFormatted(str);
            interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬());
            ref StringBuilder.AppendInterpolatedStringHandler local = ref interpolatedStringHandler;
            stringBuilder3.Append(ref local);
          }
          else if (additionalInfoItem.Value is bool flag)
          {
            if (flag)
            {
              StringBuilder stringBuilder4 = stringBuilder1;
              StringBuilder stringBuilder5 = stringBuilder4;
              interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(2, 1, stringBuilder4);
              interpolatedStringHandler.AppendFormatted(additionalInfoItem.NameKey);
              interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬());
              ref StringBuilder.AppendInterpolatedStringHandler local = ref interpolatedStringHandler;
              stringBuilder5.Append(ref local);
            }
          }
          else
          {
            StringBuilder stringBuilder6 = stringBuilder1;
            StringBuilder stringBuilder7 = stringBuilder6;
            interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(5, 2, stringBuilder6);
            interpolatedStringHandler.AppendFormatted(additionalInfoItem.NameKey);
            interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇());
            interpolatedStringHandler.AppendFormatted(str);
            interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬());
            ref StringBuilder.AppendInterpolatedStringHandler local = ref interpolatedStringHandler;
            stringBuilder7.Append(ref local);
          }
        }
      }
    }
    return stringBuilder1.ToString().TrimEnd(' ', ';');
  }

  public bool Equals(AdditionalInfoCollection other)
  {
    List<AdditionalInfoItem> list1 = this.Items.ToList<AdditionalInfoItem>();
    List<AdditionalInfoItem> list2 = other.Items.ToList<AdditionalInfoItem>();
    return AdditionalInfoCollection.픂.Equals((IList<AdditionalInfoItem>) list1, (IList<AdditionalInfoItem>) list2);
  }

  public override bool Equals(object obj)
  {
    if (obj == null)
      return false;
    if (this == obj)
      return true;
    return !(obj.GetType() != this.GetType()) && this.Equals((AdditionalInfoCollection) obj);
  }

  public override int GetHashCode()
  {
    return AdditionalInfoCollection.픂.GetHashCode((IList<AdditionalInfoItem>) this.Items.ToList<AdditionalInfoItem>());
  }
}
