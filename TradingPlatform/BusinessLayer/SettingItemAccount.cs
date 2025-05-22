// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemAccount
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
using 퓏;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>Typecasts setting as AccountLookup item</summary>
[DataContract]
[Serializable]
public sealed class SettingItemAccount : SettingItem
{
  public override SettingItemType Type => SettingItemType.Account;

  public SettingItemAccount()
  {
  }

  public SettingItemAccount(string name, Account value = null, int sortIndex = 0)
    : base(name, (object) value, sortIndex)
  {
  }

  private SettingItemAccount([In] SettingItemAccount obj0)
    : base((SettingItem) obj0)
  {
  }

  public override SettingItem GetCopy() => (SettingItem) new SettingItemAccount(this);

  public static implicit operator Account(SettingItemAccount item) => item.Value as Account;

  protected override bool IsValueTypeValid(object value) => value is Account;

  [DataMember(Name = "Value")]
  private BusinessObjectInfo ValueInfo
  {
    get
    {
      BusinessObjectInfo info = this.Value is Account account ? account.CreateInfo() : (BusinessObjectInfo) null;
      return (object) info != null ? info : BusinessObjectInfo.Empty;
    }
    [param: In] set => this.Value = (object) Core.Instance.GetAccount(value);
  }

  protected override void ValueFromXElement(
    XElement element,
    DeserializationInfo deserializationInfo)
  {
    픟 픟 = new 픟();
    XElement element1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픍());
    if (element1 == null)
      return;
    픟.FromXElement(element1, deserializationInfo);
    if (string.IsNullOrEmpty(픟.Id))
      return;
    this.ValueInfo = (BusinessObjectInfo) 픟;
  }

  protected override XElement ValueToXElement() => this.ValueInfo.ToXElement();
}
