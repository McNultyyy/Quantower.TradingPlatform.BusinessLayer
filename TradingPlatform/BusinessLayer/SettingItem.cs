// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingItem
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.DataBinding;
using TradingPlatform.BusinessLayer.Serialization;
using TradingPlatform.BusinessLayer.Settings.Condition;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[DataContract]
[KnownType(typeof (SettingItemAccount))]
[KnownType(typeof (SettingItemBoolean))]
[KnownType(typeof (SettingItemBooleanSwitcher))]
[KnownType(typeof (SettingItemDateTime))]
[KnownType(typeof (SettingItemSymbol))]
[KnownType(typeof (SettingItemPassword))]
[KnownType(typeof (SettingItemPeriod))]
[KnownType(typeof (SettingItemSelector))]
[KnownType(typeof (SettingItemSelectorLocalized))]
[KnownType(typeof (SettingItemString))]
[KnownType(typeof (SettingItemFile))]
[KnownType(typeof (SettingItemGroup))]
[KnownType(typeof (SettingItemRadioLocalized))]
[KnownType(typeof (SettingItemAction))]
[KnownType(typeof (SettingItemFont))]
[KnownType(typeof (SettingItemTimeZone))]
[KnownType(typeof (SettingItemRss))]
[KnownType(typeof (SettingItemAlignment))]
[KnownType(typeof (SettingItemPairColor))]
[KnownType(typeof (SettingItemColor))]
[KnownType(typeof (SettingItemSound))]
[KnownType(typeof (SettingItemLineOptions))]
[KnownType(typeof (SettingItemTimeZoneManager))]
[KnownType(typeof (SettingItemAlert))]
[KnownType(typeof (SettingItemFibonacciLevelOptions))]
[KnownType(typeof (SettingItemMinotauroFibonacciLevelOptions))]
[KnownType(typeof (SettingItemRangeSelector))]
[KnownType(typeof (SettingitemPoints))]
[KnownType(typeof (SettingItemTimeFrameConfig))]
[KnownType(typeof (SettingItemBooleanLocalized))]
[KnownType(typeof (SettingItemNumber<int>))]
[KnownType(typeof (SettingItemNumber<double>))]
[KnownType(typeof (SettingItemNumber<long>))]
[KnownType(typeof (SettingItemClusterColoringLevel))]
[KnownType(typeof (SettingItemOrderRequestParameters))]
[KnownType(typeof (SettingItemIconedAction))]
[KnownType(typeof (SettingItemSlider))]
[KnownType(typeof (SettingItemDoubleWithLink))]
[KnownType(typeof (SettingItemCondition))]
[ProtoContract]
[ProtoInclude(2, typeof (SettingItemAccount))]
[ProtoInclude(3, typeof (SettingItemBoolean))]
[ProtoInclude(4, typeof (SettingItemBooleanSwitcher))]
[ProtoInclude(5, typeof (SettingItemDateTime))]
[ProtoInclude(6, typeof (SettingItemNumber<double>))]
[ProtoInclude(7, typeof (SettingItemSymbol))]
[ProtoInclude(8, typeof (SettingItemNumber<int>))]
[ProtoInclude(9, typeof (SettingItemPassword))]
[ProtoInclude(10, typeof (SettingItemPeriod))]
[ProtoInclude(11, typeof (SettingItemSelector))]
[ProtoInclude(12, typeof (SettingItemSelectorLocalized))]
[ProtoInclude(13, typeof (SettingItemString))]
[ProtoInclude(14, typeof (SettingItemFile))]
[ProtoInclude(15, typeof (SettingItemGroup))]
[ProtoInclude(16 /*0x10*/, typeof (SettingItemRadioLocalized))]
[ProtoInclude(17, typeof (SettingItemAction))]
[ProtoInclude(18, typeof (SettingItemFont))]
[ProtoInclude(19, typeof (SettingItemTimeZone))]
[ProtoInclude(20, typeof (SettingItemRss))]
[ProtoInclude(21, typeof (SettingItemAlignment))]
[ProtoInclude(22, typeof (SettingItemPairColor))]
[ProtoInclude(23, typeof (SettingItemColor))]
[ProtoInclude(24, typeof (SettingItemSound))]
[ProtoInclude(25, typeof (SettingItemLineOptions))]
[ProtoInclude(26, typeof (SettingItemTimeZoneManager))]
[ProtoInclude(27, typeof (SettingItemAlert))]
[ProtoInclude(28, typeof (SettingItemFibonacciLevelOptions))]
[ProtoInclude(29, typeof (SettingItemRangeSelector))]
[ProtoInclude(30, typeof (SettingitemPoints))]
[ProtoInclude(31 /*0x1F*/, typeof (SettingItemTimeFrameConfig))]
[ProtoInclude(32 /*0x20*/, typeof (SettingItemBooleanLocalized))]
[ProtoInclude(33, typeof (SettingItemClusterColoringLevel))]
[ProtoInclude(34, typeof (SettingItemArbitageSymbols))]
[ProtoInclude(36, typeof (SettingItemOrderRequestParameters))]
[ProtoInclude(38, typeof (SettingItemIconedAction))]
[ProtoInclude(39, typeof (SettingItemSlider))]
[ProtoInclude(40, typeof (SettingItemDoubleWithLink))]
[ProtoInclude(41, typeof (SettingItemNumber<long>))]
[ProtoInclude(42, typeof (SettingItemCondition))]
[Serializable]
public abstract class SettingItem : 
  BindableEntity,
  IComparable<SettingItem>,
  IEquatable<SettingItem>,
  IXElementSerialization
{
  private string 픜퓢;
  protected object value;
  private bool 픜플;
  private bool 픜퓴;

  public abstract SettingItemType Type { get; }

  [DataMember(Name = "Name")]
  [ProtoMember(1)]
  public string Name { get; set; }

  [Bindable("text")]
  public virtual string Text
  {
    get => string.IsNullOrEmpty(this.픜퓢) ? this.Name : this.픜퓢;
    set
    {
      this.SetValue<string>(ref this.픜퓢, value, propertyName: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗핇());
    }
  }

  [Bindable("value")]
  public virtual object Value
  {
    get => this.value;
    set
    {
      if (this.value == value)
        return;
      if (value == null)
      {
        this.SetValue<object>(ref this.value, value, propertyName: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓣());
      }
      else
      {
        if (!this.IsValueTypeValid(value))
          throw new InvalidCastException();
        this.SetValue<object>(ref this.value, this.ValidateValue(value), propertyName: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓣());
      }
    }
  }

  public int SortIndex { get; set; }

  public VisibilityMode VisibilityMode { get; set; }

  public string Description { get; set; }

  public SettingItemGroup Group { get; set; }

  public SettingItemSeparatorGroup SeparatorGroup { get; set; }

  public ISettingsGroup VisualGroup { get; set; }

  [Bindable("enabled")]
  public bool Enabled
  {
    get => this.픜플;
    set
    {
      this.SetValue<bool>(ref this.픜플, value, propertyName: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픏());
    }
  }

  public SettingItemValueChangingBehavior ValueChangingBehavior { get; set; }

  public SettingItemValueChangingReason ValueChangingReason { get; set; }

  [Bindable("visible")]
  public bool Visible
  {
    get => this.픜퓴;
    set
    {
      this.SetValue<bool>(ref this.픜퓴, value, propertyName: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픗());
    }
  }

  public bool IsVisualizationAllowed
  {
    get
    {
      if (this.VisibilityMode == VisibilityMode.Hidden)
        return false;
      return this.Group == null || this.Group.IsVisualizationAllowed;
    }
  }

  public event SettingItemEventHandler Updated;

  public SettingItemRelation Relation { get; set; }

  public bool UseEnabilityToggler { get; set; }

  public static IXElementSerialization DesserrializationFabric(XElement node)
  {
    string str = node?.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓼())?.Value;
    IXElementSerialization xelementSerialization;
    if (str != null)
    {
      switch (str.Length)
      {
        case 14:
          if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픴())
          {
            xelementSerialization = (IXElementSerialization) new SettingItemRss();
            goto label_93;
          }
          break;
        case 15:
          switch (str[14])
          {
            case 'e':
              if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓞())
              {
                xelementSerialization = (IXElementSerialization) new SettingItemFile();
                goto label_93;
              }
              break;
            case 'g':
              if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픡())
              {
                xelementSerialization = (IXElementSerialization) new SettingItemLong();
                goto label_93;
              }
              break;
            case 't':
              if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗핅())
              {
                xelementSerialization = (IXElementSerialization) new SettingItemFont();
                goto label_93;
              }
              break;
          }
          break;
        case 16 /*0x10*/:
          switch (str[11])
          {
            case 'A':
              if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픷())
              {
                xelementSerialization = (IXElementSerialization) new SettingItemAlert();
                goto label_93;
              }
              break;
            case 'C':
              if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓳())
              {
                xelementSerialization = (IXElementSerialization) new SettingItemColor();
                goto label_93;
              }
              break;
            case 'G':
              if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픏())
              {
                xelementSerialization = (IXElementSerialization) new SettingItemGroup();
                goto label_93;
              }
              break;
            case 'O':
              if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓻())
              {
                xelementSerialization = (IXElementSerialization) new SettingItemOAuth();
                goto label_93;
              }
              break;
            case 'S':
              if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗핆())
              {
                xelementSerialization = (IXElementSerialization) new SettingItemSound();
                goto label_93;
              }
              break;
          }
          break;
        case 17:
          switch (str[16 /*0x10*/])
          {
            case 'd':
              if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픎())
              {
                xelementSerialization = (IXElementSerialization) new SettingItemPeriod();
                goto label_93;
              }
              break;
            case 'e':
              if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픜())
              {
                xelementSerialization = (IXElementSerialization) new SettingItemDouble();
                goto label_93;
              }
              break;
            case 'g':
              if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓠())
              {
                xelementSerialization = (IXElementSerialization) new SettingItemString();
                goto label_93;
              }
              break;
            case 'l':
              if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓗())
              {
                xelementSerialization = (IXElementSerialization) new SettingItemSymbol();
                goto label_93;
              }
              break;
            case 'n':
              if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓥())
              {
                xelementSerialization = (IXElementSerialization) new SettingItemAction();
                goto label_93;
              }
              break;
            case 'r':
              if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓑())
              {
                xelementSerialization = (IXElementSerialization) new SettingItemSlider();
                goto label_93;
              }
              break;
            case 's':
              if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓯())
              {
                xelementSerialization = (IXElementSerialization) new SettingitemPoints();
                goto label_93;
              }
              break;
          }
          break;
        case 18:
          switch (str[11])
          {
            case 'A':
              if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓲())
              {
                xelementSerialization = (IXElementSerialization) new SettingItemAccount();
                goto label_93;
              }
              break;
            case 'B':
              if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗핂())
              {
                xelementSerialization = (IXElementSerialization) new SettingItemBoolean();
                goto label_93;
              }
              break;
            case 'I':
              if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픂())
              {
                xelementSerialization = (IXElementSerialization) new SettingItemInteger();
                goto label_93;
              }
              break;
          }
          break;
        case 19:
          switch (str[13])
          {
            case 'l':
              if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픇())
              {
                xelementSerialization = (IXElementSerialization) new SettingItemSelector();
                goto label_93;
              }
              break;
            case 'm':
              if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픣())
              {
                xelementSerialization = (IXElementSerialization) new SettingItemTimeZone();
                goto label_93;
              }
              break;
            case 's':
              if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗핁())
              {
                xelementSerialization = (IXElementSerialization) new SettingItemPassword();
                goto label_93;
              }
              break;
            case 't':
              if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픞())
              {
                xelementSerialization = (IXElementSerialization) new SettingItemDateTime();
                goto label_93;
              }
              break;
            case 'x':
              if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓙())
              {
                xelementSerialization = (IXElementSerialization) new SettingItemTextArea();
                goto label_93;
              }
              break;
          }
          break;
        case 20:
          switch (str[11])
          {
            case 'A':
              if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픑())
              {
                xelementSerialization = (IXElementSerialization) new SettingItemAlignment();
                goto label_93;
              }
              break;
            case 'C':
              if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓔())
              {
                xelementSerialization = (IXElementSerialization) new SettingItemCondition();
                goto label_93;
              }
              break;
            case 'P':
              if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픿())
              {
                xelementSerialization = (IXElementSerialization) new SettingItemPairColor();
                goto label_93;
              }
              break;
          }
          break;
        case 22:
          if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픢())
          {
            xelementSerialization = (IXElementSerialization) new SettingItemLineOptions();
            goto label_93;
          }
          break;
        case 23:
          if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픪())
          {
            xelementSerialization = (IXElementSerialization) new SettingItemIconedAction();
            goto label_93;
          }
          break;
        case 24:
          if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓽())
          {
            xelementSerialization = (IXElementSerialization) new SettingItemRangeSelector();
            goto label_93;
          }
          break;
        case 25:
          switch (str[11])
          {
            case 'D':
              if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗프())
              {
                xelementSerialization = (IXElementSerialization) new SettingItemDoubleWithLink();
                goto label_93;
              }
              break;
            case 'R':
              if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픸())
              {
                xelementSerialization = (IXElementSerialization) new SettingItemRadioLocalized();
                goto label_93;
              }
              break;
          }
          break;
        case 26:
          switch (str[15])
          {
            case 'F':
              if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픁())
              {
                xelementSerialization = (IXElementSerialization) new SettingItemTimeFrameConfig();
                goto label_93;
              }
              break;
            case 'Z':
              if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓍())
              {
                xelementSerialization = (IXElementSerialization) new SettingItemTimeZoneManager();
                goto label_93;
              }
              break;
            case 'e':
              if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픾())
              {
                xelementSerialization = (IXElementSerialization) new SettingItemBooleanSwitcher();
                goto label_93;
              }
              break;
          }
          break;
        case 27:
          if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픘())
          {
            xelementSerialization = (IXElementSerialization) new SettingItemBooleanLocalized();
            goto label_93;
          }
          break;
        case 28:
          if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗핋())
          {
            xelementSerialization = (IXElementSerialization) new SettingItemSelectorLocalized();
            goto label_93;
          }
          break;
        case 31 /*0x1F*/:
          if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픨())
          {
            xelementSerialization = (IXElementSerialization) new SettingItemClusterColoringLevel();
            goto label_93;
          }
          break;
        case 32 /*0x20*/:
          if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓝())
          {
            xelementSerialization = (IXElementSerialization) new SettingItemFibonacciLevelOptions();
            goto label_93;
          }
          break;
        case 33:
          if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓪())
          {
            xelementSerialization = (IXElementSerialization) new SettingItemOrderRequestParameters();
            goto label_93;
          }
          break;
        case 41:
          if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓶())
          {
            xelementSerialization = (IXElementSerialization) new SettingItemMinotauroFibonacciLevelOptions();
            goto label_93;
          }
          break;
      }
    }
    xelementSerialization = (IXElementSerialization) null;
label_93:
    return xelementSerialization;
  }

  public void Update()
  {
    // ISSUE: reference to a compiler-generated field
    SettingItemEventHandler 픜픳 = this.픜픳;
    if (픜픳 == null)
      return;
    픜픳(this, SettingItemEventArgs.Empty);
  }

  protected SettingItem(string name, object value, int sortIndex = 0)
    : this()
  {
    this.Name = name;
    this.value = value;
    this.SortIndex = sortIndex;
    this.VisibilityMode = VisibilityMode.Visible;
    this.ValueChangingBehavior = SettingItemValueChangingBehavior.Default;
    this.Enabled = true;
    this.Visible = true;
  }

  protected SettingItem() => this.ValueChangingReason = SettingItemValueChangingReason.Unknown;

  protected SettingItem(SettingItem settingItem)
    : this()
  {
    this.Name = settingItem.Name;
    this.SortIndex = settingItem.SortIndex;
    this.Text = settingItem.Text;
    this.Description = settingItem.Description;
    this.Enabled = settingItem.Enabled;
    this.Group = settingItem.Group;
    this.Relation = settingItem.Relation;
    this.SeparatorGroup = settingItem.SeparatorGroup;
    this.VisibilityMode = settingItem.VisibilityMode;
    this.Visible = settingItem.Visible;
    this.VisualGroup = settingItem.VisualGroup;
    this.value = !(settingItem.value is ICloneable cloneable) ? settingItem.Value : cloneable.Clone();
    this.ValueChangingBehavior = settingItem.ValueChangingBehavior;
    this.UseEnabilityToggler = settingItem.UseEnabilityToggler;
  }

  public abstract SettingItem GetCopy();

  protected abstract bool IsValueTypeValid(object value);

  protected virtual object ValidateValue(object value) => value;

  internal bool 퓏([In] IList<SettingItem> obj0)
  {
    if (obj0 == null)
      return false;
    SettingItem itemByName = obj0.GetItemByName(this.Name);
    if (itemByName == null)
      return false;
    this.Value = itemByName.Value;
    return true;
  }

  internal virtual void 퓏([In] object obj0, bool _param2 = false)
  {
    if (_param2)
      this.SetValue<object>(ref this.value, obj0, propertyName: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓣());
    else
      this.Value = obj0;
  }

  internal virtual void 퓏([In] SettingItem obj0)
  {
    this.퓏(obj0.Value);
    this.VisibilityMode = obj0.VisibilityMode;
    this.SortIndex = obj0.SortIndex;
  }

  public int CompareTo(SettingItem other) => this.SortIndex.CompareTo(other.SortIndex);

  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 2);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓼());
    interpolatedStringHandler.AppendFormatted(this.Name);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗퓡());
    interpolatedStringHandler.AppendFormatted<object>(this.Value);
    return interpolatedStringHandler.ToStringAndClear();
  }

  public virtual XElement ToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁핋());
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픜(), (object) this.Name));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓼(), (object) this.GetType().Name));
    if (this.UseEnabilityToggler)
      xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픏(), (object) this.Enabled));
    xelement.Add((object) this.ValueToXElement());
    return xelement;
  }

  protected virtual XElement ValueToXElement()
  {
    return this.Value is IXElementSerialization xelementSerialization ? xelementSerialization.ToXElement() : new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓣(), this.Value);
  }

  public virtual void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    this.Name = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픜()).Value;
    this.UseEnabilityToggler = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픏()) != null;
    XElement element1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픏());
    this.Enabled = element1 != null && element1.ToBool();
    this.ValueFromXElement(element, deserializationInfo);
  }

  protected virtual void ValueFromXElement(
    XElement element,
    DeserializationInfo deserializationInfo)
  {
    XElement xelement = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓣());
    if (xelement == null)
      return;
    this.Value = (object) xelement.Value;
  }

  public virtual bool Equals(SettingItem other)
  {
    if (other == null)
      return false;
    if (this == other)
      return true;
    return this.Text == other.Text && this.ValueEquals(other.Value) && this.Enabled == other.Enabled && this.Visible == other.Visible && this.Type == other.Type && this.Name == other.Name && this.SortIndex == other.SortIndex && this.VisibilityMode == other.VisibilityMode && this.Description == other.Description && object.Equals((object) this.SeparatorGroup, (object) other.SeparatorGroup) && object.Equals((object) this.VisualGroup, (object) other.VisualGroup) && this.ValueChangingReason == other.ValueChangingReason && this.ValueChangingBehavior == other.ValueChangingBehavior && this.UseEnabilityToggler == other.UseEnabilityToggler;
  }

  protected virtual bool ValueEquals(object other) => object.Equals(this.Value, other);

  public override bool Equals(object obj)
  {
    if (obj == null)
      return false;
    if (this == obj)
      return true;
    return !(obj.GetType() != this.GetType()) && this.Equals((SettingItem) obj);
  }

  public override int GetHashCode()
  {
    HashCode hashCode = new HashCode();
    hashCode.Add<string>(this.Text);
    hashCode.Add<object>(this.Value);
    hashCode.Add<bool>(this.Enabled);
    hashCode.Add<bool>(this.Visible);
    hashCode.Add<int>((int) this.Type);
    hashCode.Add<string>(this.Name);
    hashCode.Add<int>(this.SortIndex);
    hashCode.Add<int>((int) this.VisibilityMode);
    hashCode.Add<string>(this.Description);
    hashCode.Add<SettingItemSeparatorGroup>(this.SeparatorGroup);
    hashCode.Add<ISettingsGroup>(this.VisualGroup);
    hashCode.Add<SettingItemValueChangingReason>(this.ValueChangingReason);
    hashCode.Add<int>((int) this.ValueChangingBehavior);
    hashCode.Add<bool>(this.UseEnabilityToggler);
    return hashCode.ToHashCode();
  }
}
