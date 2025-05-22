// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemRss
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[DataContract]
[Serializable]
public sealed class SettingItemRss : SettingItem
{
  public override SettingItemType Type => SettingItemType.Rss;

  public SettingItemRss()
  {
  }

  public SettingItemRss(string name, Rss value, int sortIndex = 0)
    : base(name, (object) value, sortIndex)
  {
  }

  private SettingItemRss([In] SettingItemRss obj0)
    : base((SettingItem) obj0)
  {
  }

  public override SettingItem GetCopy() => (SettingItem) new SettingItemRss(this);

  protected override bool IsValueTypeValid(object value) => value is Rss;

  [DataMember(Name = "Value")]
  private Rss ValueRss
  {
    get => this.Value as Rss;
    [param: In] set => this.Value = (object) value;
  }

  protected override void ValueFromXElement(
    XElement element,
    DeserializationInfo deserializationInfo)
  {
    Rss rss = new Rss();
    rss.FromXElement(element, deserializationInfo);
    this.Value = (object) rss;
  }
}
