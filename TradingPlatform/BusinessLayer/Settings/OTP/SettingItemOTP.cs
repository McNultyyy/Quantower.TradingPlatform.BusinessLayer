// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Settings.OTP.SettingItemOTP
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using ProtoBuf;
using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer.Settings.OTP;

[DataContract]
[Serializable]
public sealed class SettingItemOTP : SettingItem
{
  public override SettingItemType Type => SettingItemType.OTP;

  public SettingItemOTP()
  {
  }

  public SettingItemOTP(string name, OTPHolder value, int sortIndex = 0)
    : base(name, (object) value, sortIndex)
  {
  }

  private SettingItemOTP([In] SettingItemOTP obj0)
    : base((SettingItem) obj0)
  {
  }

  [NotPublished]
  public override SettingItem GetCopy() => (SettingItem) new SettingItemOTP(this);

  [NotPublished]
  public static implicit operator OTPHolder(SettingItemOTP item) => (OTPHolder) item.Value;

  [NotPublished]
  protected override bool IsValueTypeValid(object value) => value is OTPHolder;

  [DataMember(Name = "Value")]
  [ProtoMember(1, IsRequired = true)]
  private OTPHolder ValueOTPHolder
  {
    get => (OTPHolder) this.value;
    [param: In] set => this.value = (object) value;
  }

  protected override void ValueFromXElement(
    XElement element,
    DeserializationInfo deserializationInfo)
  {
    OTPHolder otpHolder = new OTPHolder();
    XElement element1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁핉());
    if (element1 == null)
      return;
    otpHolder.FromXElement(element1, deserializationInfo);
    this.ValueOTPHolder = otpHolder;
  }
}
