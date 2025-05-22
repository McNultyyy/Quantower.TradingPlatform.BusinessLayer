// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemFile
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

[DataContract]
[Serializable]
public class SettingItemFile : SettingItem
{
  public string Filter;

  public override SettingItemType Type => SettingItemType.File;

  public bool Checked { get; set; }

  public bool WithCheckBox { get; set; }

  public string DefaultFolder { get; set; }

  public SettingItemFile()
  {
  }

  public SettingItemFile(string name, string value, string filter, int sortIndex = 0)
    : base(name, (object) value, sortIndex)
  {
    this.Filter = filter;
  }

  private SettingItemFile([In] SettingItemFile obj0)
    : base((SettingItem) obj0)
  {
    this.Filter = obj0.Filter;
  }

  public override SettingItem GetCopy() => (SettingItem) new SettingItemFile(this);

  public static implicit operator string(SettingItemFile item) => item.Value as string;

  protected override bool IsValueTypeValid(object value) => value is string;

  [DataMember(Name = "Value")]
  private string ValueString
  {
    get => this.Value as string;
    [param: In] set => this.Value = (object) value;
  }

  public override XElement ToXElement()
  {
    XElement xelement = base.ToXElement();
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓪(), (object) this.Checked));
    return xelement;
  }

  public override void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    base.FromXElement(element, deserializationInfo);
    XElement element1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓪());
    this.Checked = element1 != null && element1.ToBool();
  }
}
