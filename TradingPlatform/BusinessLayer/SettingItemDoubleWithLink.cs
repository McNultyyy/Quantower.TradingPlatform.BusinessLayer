// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItemDoubleWithLink
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.DataBinding;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public class SettingItemDoubleWithLink : SettingItemDouble
{
  private string 픁핆;

  public override SettingItemType Type => SettingItemType.DoubleWithLink;

  [Bindable("linkText")]
  public string LinkText
  {
    get => this.픁핆;
    set
    {
      this.SetValue<string>(ref this.픁핆, value, propertyName: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픥());
    }
  }

  public Action<object> LinkAction { get; set; }

  public SettingItemDoubleWithLink()
  {
  }

  public SettingItemDoubleWithLink(
    string name,
    double value,
    Action<object> linkAction,
    int sortIndex = 0)
    : base(name, value, sortIndex)
  {
    this.LinkAction = linkAction;
  }

  private SettingItemDoubleWithLink([In] SettingItemDoubleWithLink obj0)
    : base((SettingItemDouble) obj0)
  {
    this.LinkText = obj0.LinkText;
    this.LinkAction = obj0.LinkAction;
  }

  public override SettingItem GetCopy() => (SettingItem) new SettingItemDoubleWithLink(this);
}
