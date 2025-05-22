// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemPassword
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>Typecasts setting as Password item</summary>
[DataContract]
[Serializable]
public sealed class SettingItemPassword : SettingItem
{
  public override SettingItemType Type => SettingItemType.Password;

  public SettingItemPassword()
  {
  }

  public SettingItemPassword(string name, PasswordHolder passwordHolder, int sortIndex = 0)
    : base(name, (object) passwordHolder, sortIndex)
  {
  }

  private SettingItemPassword([In] SettingItemPassword obj0)
    : base((SettingItem) obj0)
  {
  }

  public override SettingItem GetCopy() => (SettingItem) new SettingItemPassword(this);

  public static implicit operator PasswordHolder(SettingItemPassword item)
  {
    return (PasswordHolder) item.Value;
  }

  protected override bool IsValueTypeValid(object value) => value is PasswordHolder;

  [DataMember(Name = "Value")]
  private PasswordHolder PasswordHolder
  {
    get => (PasswordHolder) this.Value;
    [param: In] set => this.Value = (object) value;
  }

  protected override void ValueFromXElement(
    XElement element,
    DeserializationInfo deserializationInfo)
  {
    PasswordHolder passwordHolder = new PasswordHolder(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓥(), recoverUrl: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓥());
    XElement element1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓼());
    if (element1 == null)
      return;
    passwordHolder.FromXElement(element1, deserializationInfo);
    this.PasswordHolder = passwordHolder;
  }

  internal override void 퓏([In] object obj0, bool _param2 = false)
  {
    PasswordHolder passwordHolder = (PasswordHolder) this;
    base.퓏(obj0, _param2);
    ((PasswordHolder) this.Value).RecoverUrl = passwordHolder.RecoverUrl;
  }
}
