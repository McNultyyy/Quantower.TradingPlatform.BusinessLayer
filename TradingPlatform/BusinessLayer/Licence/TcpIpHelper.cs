// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Licence.TcpIpHelper
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer.Licence;

public static class TcpIpHelper
{
  private static readonly Random 퓲퓘 = new Random();

  public static int GetRandomUnusedPort
  {
    get
    {
      IPGlobalProperties globalProperties = IPGlobalProperties.GetIPGlobalProperties();
      IEnumerable<int> second = ((IEnumerable<TcpConnectionInformation>) globalProperties.GetActiveTcpConnections()).Where<TcpConnectionInformation>((Func<TcpConnectionInformation, bool>) (([In] obj0) => obj0.State != TcpState.Closed)).Select<TcpConnectionInformation, int>((Func<TcpConnectionInformation, int>) (([In] obj0) => obj0.LocalEndPoint.Port)).Union<int>(((IEnumerable<IPEndPoint>) globalProperties.GetActiveTcpListeners()).Select<IPEndPoint, int>((Func<IPEndPoint, int>) (([In] obj0) => obj0.Port))).Union<int>(((IEnumerable<IPEndPoint>) globalProperties.GetActiveUdpListeners()).Select<IPEndPoint, int>((Func<IPEndPoint, int>) (([In] obj0) => obj0.Port)));
      int start = 49152 /*0xC000*/;
      int maxValue = (int) ushort.MaxValue;
      int[] array = Enumerable.Range(start, maxValue - start + 1).Except<int>(second).ToArray<int>();
      if (!((IEnumerable<int>) array).Any<int>())
        throw new ApplicationException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픩());
      int index = TcpIpHelper.퓲퓘.Next(0, array.Length - 1);
      return array[index];
    }
  }
}
