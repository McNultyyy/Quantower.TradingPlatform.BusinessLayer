// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SettingitemPoints
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public class SettingitemPoints : SettingItem
{
  public override SettingItemType Type => SettingItemType.DrawingPoints;

  public int PointsInitialized { get; set; }

  public Func<double, VariableTick> FindVariableTick { get; set; }

  public bool EnablePriceSelection { get; set; }

  public SettingitemPoints()
  {
  }

  public SettingitemPoints(string name, double[][] Points, int sortIndex = 0)
    : base(name, (object) Points, sortIndex)
  {
    this.EnablePriceSelection = true;
    this.Value = (object) this.퓏(Points);
  }

  private SettingitemPoints([In] SettingitemPoints obj0)
  {
    this.EnablePriceSelection = obj0.EnablePriceSelection;
    this.Value = (object) this.퓏((double[][]) obj0.value);
  }

  public override SettingItem GetCopy() => (SettingItem) new SettingitemPoints(this);

  protected override bool IsValueTypeValid(object value) => value is double[][];

  protected override XElement ValueToXElement()
  {
    double[][] numArray1 = (double[][]) this.Value;
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픯());
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣핀(), (object) numArray1.Length));
    XElement content1 = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓾());
    foreach (double[] numArray2 in numArray1)
    {
      XElement content2 = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓐());
      content2.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓵(), (object) numArray2[0]));
      content2.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍핈(), (object) numArray2[1]));
      content1.Add((object) content2);
    }
    xelement.Add((object) content1);
    return xelement;
  }

  protected override void ValueFromXElement(
    XElement element,
    DeserializationInfo deserializationInfo)
  {
    XElement xelement = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎픯());
    double[][] numArray = this.InitPoints(xelement.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣핀()).ToInt());
    int index = 0;
    foreach (XElement element1 in xelement.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픎퓾()).Elements())
    {
      numArray[index][0] = element1.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓵()).ToDouble();
      numArray[index][1] = element1.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍핈()).ToDouble();
      ++index;
    }
    this.value = (object) numArray;
  }

  protected double[][] InitPoints(int level)
  {
    double[][] numArray = new double[level][];
    for (int index = 0; index < numArray.Length; ++index)
      numArray[index] = new double[2];
    return numArray;
  }

  private double[][] 퓏([In] double[][] obj0)
  {
    double[][] numArray1 = this.InitPoints(obj0.Length);
    for (int index1 = 0; index1 < obj0.GetLength(0); ++index1)
    {
      double[] numArray2 = obj0[index1];
      for (int index2 = 0; index2 < numArray2.Length; ++index2)
        numArray1[index1][index2] = numArray2[index2];
    }
    return numArray1;
  }
}
