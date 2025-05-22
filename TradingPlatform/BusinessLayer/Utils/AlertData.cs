// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.AlertData
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils;

/// <summary>The alert data.</summary>
[DataContract(Name = "Alert", Namespace = "TradingPlatform")]
public class AlertData : IXElementSerialization
{
  /// <summary>The name.</summary>
  [DataMember(Name = "Name")]
  public string Name;

  /// <summary>Gets or Sets the columns.</summary>
  public List<ColumnBaseInformation> Columns { get; set; }

  /// <summary>Gets or Sets the groups.</summary>
  public List<ConditionGroup> Groups { get; set; }

  /// <summary>Gets or Sets the actions.</summary>
  public List<ActionWrapper> Actions { get; set; }

  /// <summary>Gets or Sets a value indicating whether enabled.</summary>
  [DataMember(Name = "Enabled")]
  public bool Enabled { get; set; }

  /// <summary>Gets or Sets the table dictionary.</summary>
  public Hashtable TableDictionary { get; set; }

  /// <summary>
  /// Gets or Sets a value indicating whether coloring is alert.
  /// </summary>
  [DataMember(Name = "IsColoringAlert")]
  public bool IsColoringAlert { get; set; }

  /// <summary>Gets or Sets a value indicating whether filter alert.</summary>
  [DataMember(Name = "FilterAlert")]
  public bool FilterAlert { get; set; }

  /// <summary>Gets or Sets a value indicating whether search alert.</summary>
  [DataMember(Name = "SearchAlert")]
  public bool SearchAlert { get; set; }

  /// <summary>Gets or Sets a value indicating whether to remove.</summary>
  public bool ToRemove { get; set; }

  /// <summary>Gets or Sets the ID.</summary>
  public string ID { get; set; }

  /// <summary>Gets or Sets the command sender.</summary>
  public object CommandSender { get; set; }

  /// <summary>
  /// Gets or Sets a value indicating whether need confirm trading.
  /// </summary>
  public bool NeedConfirmTrading { get; set; }

  /// <summary>
  /// Initializes a new instance of the <see cref="T:TradingPlatform.BusinessLayer.Utils.AlertData" /> class.
  /// </summary>
  public AlertData()
  {
    this.Columns = new List<ColumnBaseInformation>();
    this.Groups = new List<ConditionGroup>();
    this.Actions = new List<ActionWrapper>();
    this.NeedConfirmTrading = true;
  }

  /// <summary>To the XML element.</summary>
  /// <returns>A XElement.</returns>
  public XElement ToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픡());
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픜(), (object) this.Name));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픏(), (object) this.Enabled));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓳(), (object) this.IsColoringAlert));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁핆(), (object) this.FilterAlert));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픷(), (object) this.NeedConfirmTrading));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓻(), (object) this.SearchAlert));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픸(), (object) this.ID));
    XElement content1 = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁프());
    foreach (ConditionGroup group in this.Groups)
      content1.Add((object) group.ToXElement());
    xelement.Add((object) content1);
    XElement content2 = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픴());
    foreach (ActionWrapper action in this.Actions)
      content2.Add((object) action.ToXElement());
    xelement.Add((object) content2);
    return xelement;
  }

  /// <summary>From the XML element.</summary>
  /// <param name="element">The element.</param>
  /// <param name="deserializationInfo">The deserialization info.</param>
  public void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    XElement xelement = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픡());
    this.Name = xelement.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픜()).Value.ToString();
    this.Enabled = xelement.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픏()).ToBool();
    this.IsColoringAlert = xelement.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓳()).ToBool();
    this.FilterAlert = xelement.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁핆()).ToBool();
    XElement element1 = xelement?.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픷());
    if (element1 != null)
      this.NeedConfirmTrading = element1.ToBool();
    this.SearchAlert = xelement.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓻()).ToBool();
    this.ID = xelement.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픸()).Value.ToString();
    List<ConditionGroup> conditionGroupList = new List<ConditionGroup>();
    foreach (XElement element2 in xelement.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁프()).Elements((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픑()))
    {
      ConditionGroup conditionGroup = new ConditionGroup();
      conditionGroup.FromXElement(element2, deserializationInfo);
      conditionGroupList.Add(conditionGroup);
    }
    this.Groups = conditionGroupList;
    List<ActionWrapper> actionWrapperList = new List<ActionWrapper>();
    foreach (XElement element3 in xelement.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픴()).Elements((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓞()))
    {
      ActionWrapper actionWrapper = new ActionWrapper();
      actionWrapper.FromXElement(element3, deserializationInfo);
      actionWrapperList.Add(actionWrapper);
    }
    this.Actions = actionWrapperList;
  }
}
