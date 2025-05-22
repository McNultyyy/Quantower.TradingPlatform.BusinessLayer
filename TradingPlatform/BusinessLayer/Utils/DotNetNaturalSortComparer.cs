// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.DotNetNaturalSortComparer
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils;

public class DotNetNaturalSortComparer : IComparer<string>
{
  private readonly StringComparison 퓲핁;
  private readonly IComparer<string> 퓲픇;
  private const byte 퓲픣 = 0;
  private const byte 퓲퓙 = 1;
  private const byte 퓲퓗 = 2;
  private const byte 퓲픎 = 3;

  public DotNetNaturalSortComparer(StringComparison stringComparison) => this.퓲핁 = stringComparison;

  public DotNetNaturalSortComparer(IComparer<string> stringComparer) => this.퓲픇 = stringComparer;

  public int Compare(string str1, string str2)
  {
    if (str1 == str2)
      return 0;
    if (str1 == null)
      return -1;
    if (str2 == null)
      return 1;
    int length1 = str1.Length;
    int length2 = str2.Length;
    int num1 = 0;
    int num2 = 0;
    int num3;
    int num4;
    int num5;
    int num6;
    while (true)
    {
      int index1 = num1;
      byte num7 = 0;
      for (; index1 < length1; ++index1)
      {
        byte num8 = DotNetNaturalSortComparer.퓏(str1[index1]);
        if (num7 == (byte) 0)
          num7 = num8;
        else if ((int) num7 != (int) num8)
          break;
      }
      int index2 = num2;
      byte num9 = 0;
      for (; index2 < length2; ++index2)
      {
        byte num10 = DotNetNaturalSortComparer.퓏(str2[index2]);
        if (num9 == (byte) 0)
          num9 = num10;
        else if ((int) num9 != (int) num10)
          break;
      }
      num3 = num7.CompareTo(num9);
      if (num3 == 0)
      {
        if (num7 != (byte) 0)
        {
          int num11 = index1 - num1;
          int num12 = index2 - num2;
          if (num7 == (byte) 2)
          {
            int num13 = Math.Max(num11, num12);
            int num14 = num13 - num11;
            int num15 = num13 - num12;
            for (int index3 = 0; index3 < num13; ++index3)
            {
              int num16 = (index3 < num14 ? '0' : str1[num1 + index3 - num14]).CompareTo(index3 < num15 ? '0' : str2[num2 + index3 - num15]);
              if (num16 != 0)
                return num16;
            }
            num4 = num14.CompareTo(num15);
            if (num4 != 0)
              goto label_30;
          }
          else if (this.퓲픇 != null)
          {
            num5 = this.퓲픇.Compare(str1.Substring(num1, num11), str2.Substring(num2, num12));
            if (num5 != 0)
              goto label_33;
          }
          else
          {
            int length3 = Math.Min(num11, num12);
            num6 = string.Compare(str1, num1, str2, num2, length3, this.퓲핁);
            if (num6 == 0)
              num6 = num11 - num12;
            if (num6 != 0)
              goto label_37;
          }
          num1 = index1;
          num2 = index2;
        }
        else
          goto label_22;
      }
      else
        break;
    }
    return num3;
label_22:
    return 0;
label_30:
    return num4;
label_33:
    return num5;
label_37:
    return num6;
  }

  private static byte 퓏([In] char obj0)
  {
    return obj0 < 'a' ? (obj0 < 'A' ? (obj0 < '0' || obj0 > '9' ? (byte) 1 : (byte) 2) : (obj0 > 'Z' ? (byte) 1 : (byte) 3)) : (obj0 > 'z' && (obj0 < '\u0080' || !char.IsLetter(obj0)) ? (byte) 1 : (byte) 3);
  }
}
