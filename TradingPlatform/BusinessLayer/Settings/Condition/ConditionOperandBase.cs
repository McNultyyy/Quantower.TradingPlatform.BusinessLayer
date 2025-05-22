// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Settings.Condition.ConditionOperandBase
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer.Settings.Condition;

public abstract class ConditionOperandBase : IXElementSerialization, IComparable, ICloneable
{
  protected const string XML_TYPE = "Type";

  public abstract string Name { get; }

  public abstract ConditionOperandBaseType ValueType { get; }

  public static ConditionOperandBase CreateFromXml(
    XElement element,
    DeserializationInfo deserializationInfo)
  {
    string str = element?.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓼())?.Value;
    ConditionOperandBase fromXml;
    if (str != null)
    {
      switch (str.Length)
      {
        case 17:
          if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓩())
          {
            fromXml = (ConditionOperandBase) new OperandCustomDate();
            goto label_19;
          }
          break;
        case 19:
          switch (str[14])
          {
            case 't':
              if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓫())
              {
                fromXml = (ConditionOperandBase) new OperandCustomString();
                goto label_19;
              }
              break;
            case 'y':
              if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁핌())
              {
                fromXml = (ConditionOperandBase) new OperandCustomSymbol();
                goto label_19;
              }
              break;
          }
          break;
        case 20:
          if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓨())
          {
            fromXml = (ConditionOperandBase) new OperandCustomAccount();
            goto label_19;
          }
          break;
        case 21:
          switch (str[7])
          {
            case 'C':
              if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓱())
              {
                fromXml = (ConditionOperandBase) new OperandCustomSelector();
                goto label_19;
              }
              break;
            case 'O':
              if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픹())
              {
                fromXml = (ConditionOperandBase) new OperandObjectProperty();
                goto label_19;
              }
              break;
          }
          break;
        case 29:
          if (str == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓺())
          {
            fromXml = (ConditionOperandBase) new OperandObjectPropertySelector();
            goto label_19;
          }
          break;
      }
    }
    fromXml = (ConditionOperandBase) null;
label_19:
    return fromXml;
  }

  public abstract object Clone();

  public int CompareTo(object obj)
  {
    return this.Name.CompareTo(obj is ConditionOperandBase conditionOperandBase ? conditionOperandBase.Name : (string) null);
  }

  public abstract void FromXElement(XElement element, DeserializationInfo deserializationInfo);

  public abstract XElement ToXElement();
}
