// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.VendorManager
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

public class VendorManager
{
  private readonly Dictionary<string, VendorInfo> 핂픟;

  public VendorInfo[] Vendors => this.핂픟.Values.ToArray<VendorInfo>();

  public VendorInfo this[string vendorName]
  {
    get
    {
      VendorInfo vendorInfo;
      this.핂픟.TryGetValue(vendorName, out vendorInfo);
      return vendorInfo;
    }
  }

  internal VendorManager() => this.핂픟 = new Dictionary<string, VendorInfo>();

  internal void 퓏()
  {
    Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픁(), LoggingLevel.Verbose);
    if (!Directory.Exists(Const.CUSTOM_VENDORS_PATH))
      Directory.CreateDirectory(Const.CUSTOM_VENDORS_PATH);
    List<TypeWrapper> source = AssemblyLoader.LoadTypes(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓏(), typeof (Vendor), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픞(), SearchOption.AllDirectories);
    source.AddRange((IEnumerable<TypeWrapper>) AssemblyLoader.LoadTypes(Const.CUSTOM_VENDORS_PATH, typeof (Vendor), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픞(), SearchOption.AllDirectories));
    if (!source.Any<TypeWrapper>())
    {
      Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍핁(), LoggingLevel.Verbose);
    }
    else
    {
      LoggerManager loggers1 = Core.Instance.Loggers;
      DefaultInterpolatedStringHandler interpolatedStringHandler1 = new DefaultInterpolatedStringHandler(38, 1);
      interpolatedStringHandler1.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픇());
      interpolatedStringHandler1.AppendFormatted<int>(source.Count);
      interpolatedStringHandler1.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픣());
      string stringAndClear1 = interpolatedStringHandler1.ToStringAndClear();
      loggers1.Log(stringAndClear1, LoggingLevel.Verbose);
      foreach (TypeWrapper typeWrapper in source)
      {
        Type type = (Type) typeWrapper;
        try
        {
          if (!type.IsAbstract)
          {
            MethodInfo method = type.GetMethod(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓙(), BindingFlags.Static | BindingFlags.Public);
            if (method != (MethodInfo) null)
            {
              if (method.Invoke((object) null, (object[]) null) is VendorMetaData vendorMetaData)
              {
                if (vendorMetaData == null || string.IsNullOrEmpty(vendorMetaData.VendorName))
                {
                  LoggerManager loggers2 = Core.Instance.Loggers;
                  DefaultInterpolatedStringHandler interpolatedStringHandler2 = new DefaultInterpolatedStringHandler(54, 1);
                  interpolatedStringHandler2.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓗());
                  interpolatedStringHandler2.AppendFormatted<Type>(type);
                  string stringAndClear2 = interpolatedStringHandler2.ToStringAndClear();
                  loggers2.Log(stringAndClear2, LoggingLevel.Verbose);
                }
                else if (this.핂픟.ContainsKey(vendorMetaData.VendorName))
                {
                  Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픎() + vendorMetaData.VendorName, LoggingLevel.Verbose);
                }
                else
                {
                  this.핂픟.Add(vendorMetaData.VendorName, new VendorInfo(vendorMetaData, type));
                  Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픇() + vendorMetaData.VendorName + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓠(), LoggingLevel.Verbose);
                }
              }
              else
                Core.Instance.Loggers.Log(type.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓥(), LoggingLevel.Verbose);
            }
          }
        }
        catch (Exception ex)
        {
          Core.Instance.Loggers.Log(ex);
        }
      }
      Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓯(), LoggingLevel.Verbose);
    }
  }

  internal void 퓬() => this.핂픟?.Clear();
}
