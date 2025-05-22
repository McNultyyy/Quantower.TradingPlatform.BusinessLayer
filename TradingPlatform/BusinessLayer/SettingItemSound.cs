// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemSound
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;
using TradingPlatform.BusinessLayer.Utils.Sounds;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[DataContract]
[Serializable]
public class SettingItemSound : SettingItem
{
  public bool EnableSounds;

  public override SettingItemType Type => SettingItemType.Sound;

  public SettingItemSound()
  {
  }

  public SettingItemSound(
    string name,
    Dictionary<string, SoundItem> value,
    bool enableSounds = true,
    int sortIndex = 0)
    : base(name, (object) value, sortIndex)
  {
    this.EnableSounds = enableSounds;
  }

  private SettingItemSound([In] SettingItemSound obj0)
    : base((SettingItem) obj0)
  {
    this.EnableSounds = obj0.EnableSounds;
  }

  public override SettingItem GetCopy() => (SettingItem) new SettingItemSound(this);

  [DataMember(Name = "Value")]
  private Dictionary<string, SoundItem> ValuDictionrary
  {
    get => this.value as Dictionary<string, SoundItem>;
    [param: In] set => this.value = (object) value;
  }

  protected override bool IsValueTypeValid(object value) => value is Dictionary<string, SoundItem>;

  protected override XElement ValueToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓣());
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎플(), (object) this.EnableSounds));
    foreach (KeyValuePair<string, SoundItem> keyValuePair in this.ValuDictionrary)
      xelement.Add((object) keyValuePair.Value.ToXElement());
    return xelement;
  }

  protected override void ValueFromXElement(
    XElement element,
    DeserializationInfo deserializationInfo)
  {
    XElement xelement = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓣());
    this.EnableSounds = xelement.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎플()).ToBool();
    Dictionary<string, SoundItem> dictionary = new Dictionary<string, SoundItem>();
    foreach (XElement element1 in xelement.Elements((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁핈()))
    {
      SoundItem soundItem = new SoundItem();
      soundItem.FromXElement(element1, deserializationInfo);
      dictionary[soundItem.Name] = soundItem;
    }
    this.ValuDictionrary = dictionary;
  }
}
