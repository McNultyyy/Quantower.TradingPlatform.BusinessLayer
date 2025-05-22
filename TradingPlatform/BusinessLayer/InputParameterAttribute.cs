// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.InputParameterAttribute
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>
/// Use this attribute to mark input parameters of your script. You will see them in the settings screen on adding
/// </summary>
[Published]
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
public class InputParameterAttribute : Attribute
{
  /// <summary>Displayed name of input parameter</summary>
  public string Name { get; [param: In] private set; }

  /// <summary>Sort index for input paramter</summary>
  public int SortIndex { get; [param: In] private set; }

  /// <summary>Minimal value for numeric input parameters</summary>
  public double Minimum { get; [param: In] private set; }

  /// <summary>Maximal value for numeric input parameters</summary>
  public double Maximum { get; [param: In] private set; }

  /// <summary>Increment value for numeric input parameters</summary>
  public double Increment { get; [param: In] private set; }

  /// <summary>Decimal palces for numeric input parameters</summary>
  public int DecimalPlaces { get; [param: In] private set; }

  /// <summary>List of predefined values</summary>
  public IComparable[] Variants { get; [param: In] private set; }

  public InputParameterAttribute(
    string name = "",
    int sortIndex = 0,
    double minimum = -2147483648.0,
    double maximum = 2147483647.0,
    double increment = 0.01,
    int decimalPlaces = 2,
    object[] variants = null)
  {
    this.Name = name;
    this.SortIndex = sortIndex;
    this.Minimum = minimum;
    this.Maximum = maximum;
    this.Increment = increment;
    this.DecimalPlaces = decimalPlaces;
    IComparable[] comparableArray;
    if (variants == null)
    {
      comparableArray = (IComparable[]) null;
    }
    else
    {
      IEnumerable<IComparable> source = variants.Cast<IComparable>();
      comparableArray = source != null ? source.ToArray<IComparable>() : (IComparable[]) null;
    }
    this.Variants = comparableArray;
  }
}
