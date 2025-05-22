// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SymbolsListManager
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using FluentFTP;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>The symbols list manager.</summary>
public sealed class SymbolsListManager : ICustomizable
{
  private readonly Dictionary<string, SymbolList> 픂픠;
  private readonly Dictionary<string, SymbolList> 픂퓮;

  /// <summary>Gets the count.</summary>
  public int Count => this.픂픠.Count + this.픂퓮.Count;

  /// <summary>Gets or Sets the settings.</summary>
  public IList<SettingItem> Settings
  {
    get
    {
      List<SettingItem> settings = new List<SettingItem>();
      foreach (KeyValuePair<string, SymbolList> keyValuePair in this.픂픠)
        settings.Add((SettingItem) new SettingItemGroup(keyValuePair.Key, keyValuePair.Value.Settings));
      return (IList<SettingItem>) settings;
    }
    set
    {
      foreach (SettingItem settingItem in (IEnumerable<SettingItem>) value)
      {
        if (settingItem.Value is IList<SettingItem> settingItemList)
        {
          SymbolList symbolList;
          if (this.픂픠.TryGetValue(settingItem.Name, out symbolList))
          {
            symbolList.Settings = settingItemList;
          }
          else
          {
            symbolList = new SymbolList()
            {
              Settings = settingItemList
            };
            this.픂픠.Add(settingItem.Name, symbolList);
          }
        }
      }
    }
  }

  internal SymbolList[] Items
  {
    get
    {
      return this.픂퓮.Values.Concat<SymbolList>((IEnumerable<SymbolList>) this.픂픠.Values).ToArray<SymbolList>();
    }
  }

  internal SymbolsListManager()
  {
    this.픂픠 = new Dictionary<string, SymbolList>();
    this.픂퓮 = new Dictionary<string, SymbolList>();
  }

  internal void 퓏()
  {
  }

  internal void 퓏([In] string obj0, [In] IEnumerable<Symbol> obj1)
  {
    this.픂픠.Add(obj0, new SymbolList(obj0, obj1));
  }

  internal void 퓏([In] string obj0, [In] IList<Symbol> obj1)
  {
    this.픂픠[obj0].Symbols = (IEnumerable<Symbol>) obj1;
  }

  internal void 퓏([In] string obj0) => this.픂픠.Remove(obj0);

  internal void 퓏([In] string obj0, [In] string obj1)
  {
    SymbolList symbolList;
    if (!this.픂픠.TryGetValue(obj0, out symbolList))
      throw new ArgumentException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픕() + obj0);
    this.픂픠.Remove(obj0);
    symbolList.퓏(obj1);
    this.픂픠.Add(obj1, symbolList);
  }

  [Conditional("quantower_in_licences")]
  private void 퓬()
  {
    Task.Factory.StartNew((Action) (() =>
    {
      try
      {
        using (FtpClient ftpClient = new FtpClient(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픱(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픶(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픀()))
        {
          ftpClient.Connect();
          foreach (FtpListItem ftpListItem1 in ((IEnumerable<FtpListItem>) ftpClient.GetListing(Path.Combine(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픖(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓘()))).Where<FtpListItem>((Func<FtpListItem, bool>) (([In] obj0) => obj0.Type == FtpObjectType.Directory)))
          {
            foreach (FtpListItem ftpListItem2 in ((IEnumerable<FtpListItem>) ftpClient.GetListing(ftpListItem1.FullName)).Where<FtpListItem>((Func<FtpListItem, bool>) (([In] obj0) => obj0.Type == FtpObjectType.File)).Where<FtpListItem>((Func<FtpListItem, bool>) (([In] obj0) => Path.GetExtension(obj0.Name) == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픣픖())).ToArray<FtpListItem>())
            {
              using (MemoryStream outStream = new MemoryStream())
              {
                ftpClient.DownloadStream((Stream) outStream, ftpListItem2.FullName, 0L, (Action<FtpProgress>) null, 0L);
                outStream.Position = 0L;
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                List<SettingItem> list = Serializer.DeserializeXML((Stream) outStream, out double _, SymbolsListManager.퓏.퓠퓑 ?? (SymbolsListManager.퓏.퓠퓑 = new Func<XElement, IXElementSerialization>(SettingItem.DesserrializationFabric))).OfType<SettingItem>().ToList<SettingItem>();
                if (list != null)
                {
                  if (list.Any<SettingItem>())
                  {
                    SymbolList symbolList = new SymbolList((IList<SettingItem>) list, false)
                    {
                      Group = ftpListItem1.Name
                    };
                    this.픂퓮[Path.Combine(ftpListItem1.Name, symbolList.Name)] = symbolList;
                  }
                }
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        Core.Instance.Loggers.Log(ex);
      }
    }));
  }
}
