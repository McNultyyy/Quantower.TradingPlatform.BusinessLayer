// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.AdditionalInfoItem
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using ProtoBuf;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Integration;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>The additional info item.</summary>
[ProtoContract]
public class AdditionalInfoItem : ICloneable, IXElementSerialization, IEquatable<AdditionalInfoItem>
{
  /// <summary>
  /// ключ для апи, обязательно для заполнения и должен быть уникальным
  /// </summary>
  [ProtoMember(1)]
  public string Id { get; set; }

  /// <summary>Gets or Sets the group info.</summary>
  [ProtoMember(2)]
  public string GroupInfo { get; set; }

  /// <summary>Gets or Sets the sort index.</summary>
  [ProtoMember(3)]
  public int SortIndex { get; set; }

  /// <summary>Gets or Sets the name key.</summary>
  [ProtoMember(4)]
  public string NameKey { get; set; }

  /// <summary>Gets or Sets the tool tip key.</summary>
  [ProtoMember(5)]
  public string ToolTipKey { get; set; }

  /// <summary>Gets or Sets the data type.</summary>
  [ProtoMember(6)]
  public ComparingType DataType { get; set; }

  /// <summary>Gets or Sets the value.</summary>
  [ProtoIgnore]
  public object Value { get; set; }

  /// <summary>Gets or Sets a value indicating whether hidden.</summary>
  [ProtoMember(7)]
  public bool Hidden { get; set; }

  /// <summary>Gets or Sets the formating type.</summary>
  [ProtoMember(8)]
  public AdditionalInfoItemFormatingType FormatingType { get; set; }

  /// <summary>
  /// используется в связке с AccountAdditionalInfoItemFormatingType.CustomAsset для форматирования в заданном ассете
  /// </summary>
  [ProtoMember(9)]
  public string CustomAssetID { get; set; }

  /// <summary>Gets or Sets a value indicating whether visible.</summary>
  [ProtoMember(10)]
  public bool Visible { get; set; }

  /// <summary>Gets or Sets a value indicating whether is link.</summary>
  [ProtoMember(11)]
  public bool IsLink { get; set; }

  [ProtoMember(12, IsRequired = false)]
  private string ProtoDynamicPropertySurrogateString
  {
    get => this.DataType != ComparingType.String ? (string) null : (string) this.Value;
    [param: In] set
    {
      if (this.DataType != ComparingType.String || value == null)
        return;
      this.Value = (object) value;
    }
  }

  [ProtoMember(13, IsRequired = false)]
  private int? ProtoDynamicPropertySurrogateInt
  {
    get => this.DataType != ComparingType.Int ? new int?() : new int?((int) this.Value);
    [param: In] set
    {
      if (this.DataType != ComparingType.Int || !value.HasValue)
        return;
      this.Value = (object) value;
    }
  }

  [ProtoMember(14, IsRequired = false)]
  private double? ProtoDynamicPropertySurrogateDouble
  {
    get => this.DataType != ComparingType.Double ? new double?() : new double?((double) this.Value);
    [param: In] set
    {
      if (this.DataType != ComparingType.Double || !value.HasValue)
        return;
      this.Value = (object) value;
    }
  }

  [ProtoMember(15, IsRequired = false)]
  private long? ProtoDynamicPropertySurrogateLong
  {
    get => this.DataType != ComparingType.Long ? new long?() : new long?((long) this.Value);
    [param: In] set
    {
      if (this.DataType != ComparingType.Long || !value.HasValue)
        return;
      this.Value = (object) value;
    }
  }

  [ProtoMember(16 /*0x10*/, IsRequired = false)]
  private DateTime? ProtoDynamicPropertySurrogateDateTime
  {
    get
    {
      return this.DataType != ComparingType.DateTime ? new DateTime?() : new DateTime?((DateTime) this.Value);
    }
    [param: In] set
    {
      if (this.DataType != ComparingType.DateTime || !value.HasValue)
        return;
      this.Value = (object) value;
    }
  }

  /// <summary>Gets or Sets the editing info.</summary>
  public EditingInfo EditingInfo { get; set; }

  /// <summary>Gets or Sets the formatting description.</summary>
  public IFormattingDescription FormattingDescription { get; set; }

  /// <summary>
  /// Initializes a new instance of the <see cref="T:TradingPlatform.BusinessLayer.AdditionalInfoItem" /> class.
  /// </summary>
  public AdditionalInfoItem() => this.Visible = true;

  /// <summary>
  /// 
  /// </summary>
  /// <param name="item">The item.</param>
  public virtual void Update(AdditionalInfoItem item)
  {
    this.GroupInfo = item.GroupInfo;
    this.SortIndex = item.SortIndex;
    this.NameKey = item.NameKey;
    this.ToolTipKey = item.ToolTipKey;
    this.DataType = item.DataType;
    this.Value = item.Value;
    this.Hidden = item.Hidden;
    this.Visible = item.Visible;
    this.IsLink = item.IsLink;
    this.Id = item.Id;
    this.FormatingType = item.FormatingType;
    this.CustomAssetID = item.CustomAssetID;
    this.EditingInfo = item.EditingInfo == null ? (EditingInfo) null : new EditingInfo(item.EditingInfo);
    this.FormattingDescription = item.FormattingDescription;
  }

  /// <summary>
  /// 
  /// </summary>
  /// <returns>An object.</returns>
  public object Clone()
  {
    AdditionalInfoItem additionalInfoItem = new AdditionalInfoItem();
    additionalInfoItem.Update(this);
    return (object) additionalInfoItem;
  }

  /// <summary>To the XML element.</summary>
  /// <returns>A XElement.</returns>
  public XElement ToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓝());
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓶(), (object) this.Id));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓽(), (object) this.GroupInfo));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픘(), (object) this.SortIndex));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픨(), (object) this.NameKey));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓪(), (object) this.ToolTipKey));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픪(), (object) (int) this.DataType));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓣(), this.Value));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓭(), (object) this.Hidden));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓡(), (object) (int) this.FormatingType));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓓(), (object) this.CustomAssetID));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픗(), (object) this.Visible));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓰(), (object) this.IsLink));
    return xelement;
  }

  /// <summary>From the XML element.</summary>
  /// <param name="element">The element.</param>
  /// <param name="deserializationInfo">The deserialization info.</param>
  public void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    XElement xelement1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓶());
    if (xelement1 != null)
      this.Id = xelement1.Value;
    XElement xelement2 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓽());
    if (xelement2 != null)
      this.GroupInfo = xelement2.Value;
    XElement element1 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픘());
    if (element1 != null)
      this.SortIndex = element1.ToInt();
    XElement xelement3 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픨());
    if (xelement3 != null)
      this.NameKey = xelement3.Value;
    XElement xelement4 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓪());
    if (xelement4 != null)
      this.ToolTipKey = xelement4.Value;
    XElement element2 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픪());
    if (element2 != null)
      this.DataType = (ComparingType) element2.ToInt();
    XElement element3 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓣());
    if (element3 != null)
    {
      object dateTime;
      switch (this.DataType)
      {
        case ComparingType.Int:
          dateTime = (object) element3.ToInt();
          break;
        case ComparingType.Double:
          dateTime = (object) element3.ToDouble();
          break;
        case ComparingType.Long:
          dateTime = (object) element3.ToLong();
          break;
        case ComparingType.DateTime:
          dateTime = (object) element3.ToDateTime();
          break;
        default:
          dateTime = (object) element3.Value;
          break;
      }
      this.Value = dateTime;
    }
    XElement element4 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓭());
    if (element4 != null)
      this.Hidden = element4.ToBool();
    XElement element5 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓡());
    if (element5 != null)
      this.FormatingType = (AdditionalInfoItemFormatingType) element5.ToInt();
    XElement xelement5 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓓());
    if (xelement5 != null)
      this.CustomAssetID = xelement5.Value;
    XElement element6 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픗());
    if (element6 != null)
      this.Visible = element6.ToBool();
    XElement element7 = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓰());
    if (element7 == null)
      return;
    this.IsLink = element7.ToBool();
  }

  /// <summary>To the string.</summary>
  /// <returns>A string.</returns>
  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(38, 4);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픧());
    interpolatedStringHandler.AppendFormatted(this.Id);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓹());
    interpolatedStringHandler.AppendFormatted(this.GroupInfo);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓛());
    interpolatedStringHandler.AppendFormatted<bool>(this.Visible);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픝());
    interpolatedStringHandler.AppendFormatted<bool>(this.Hidden);
    return interpolatedStringHandler.ToStringAndClear();
  }

  public bool Equals(AdditionalInfoItem other)
  {
    if (other == null)
      return false;
    if (this == other)
      return true;
    return this.NameKey == other.NameKey && object.Equals(this.Value, other.Value);
  }

  public override bool Equals(object obj)
  {
    if (obj == null)
      return false;
    if (this == obj)
      return true;
    return !(obj.GetType() != this.GetType()) && this.Equals((AdditionalInfoItem) obj);
  }

  public override int GetHashCode() => HashCode.Combine<string, object>(this.NameKey, this.Value);
}
