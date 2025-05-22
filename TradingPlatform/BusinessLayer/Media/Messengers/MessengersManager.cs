// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Media.Messengers.MessengersManager
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace TradingPlatform.BusinessLayer.Media.Messengers;

public class MessengersManager : ICustomizable, IDisposable
{
  private readonly Dictionary<string, IMessenger> 픣픆;

  public IMessenger Telegram
  {
    get => this[\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픢()];
  }

  public IMessenger Email
  {
    get => this[\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓝()];
  }

  public IMessenger[] All => this.픣픆.Values.ToArray<IMessenger>();

  public IMessenger this[string name]
  {
    get
    {
      IMessenger messenger;
      return !this.TryGetMessenger(name, out messenger) ? (IMessenger) null : messenger;
    }
  }

  public IList<SettingItem> Settings
  {
    get
    {
      List<SettingItem> settings = new List<SettingItem>();
      foreach (IMessenger messenger in this.All)
        settings.Add((SettingItem) new SettingItemGroup(messenger.Name, messenger.Settings));
      return (IList<SettingItem>) settings;
    }
    set
    {
      foreach (SettingItem settingItem in (IEnumerable<SettingItem>) value)
      {
        IMessenger messenger;
        if (settingItem is SettingItemGroup settingItemGroup && settingItemGroup.Value is IList<SettingItem> settingItemList && this.TryGetMessenger(settingItemGroup.Name, out messenger))
          messenger.Settings = settingItemList;
      }
    }
  }

  internal MessengersManager() => this.픣픆 = new Dictionary<string, IMessenger>();

  internal void 퓏()
  {
    try
    {
      Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓶());
      foreach (TypeWrapper loadType in AssemblyLoader.LoadTypes(Const.MESSENGERS_PATH, typeof (IMessenger), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓽(), SearchOption.AllDirectories))
      {
        Type type = (Type) loadType;
        try
        {
          if (!type.IsAbstract)
          {
            if (!(Activator.CreateInstance(type) is IMessenger instance))
              Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픘() + type.Name);
            else if (this.픣픆.ContainsKey(instance.Name))
              Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픨() + instance.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓪());
            else
              this.픣픆.Add(instance.Name, instance);
          }
        }
        catch (Exception ex)
        {
          Core.Instance.Loggers.Log(ex);
        }
      }
      LoggerManager loggers = Core.Instance.Loggers;
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(26, 2);
      interpolatedStringHandler.AppendFormatted(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픪());
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓡());
      interpolatedStringHandler.AppendFormatted<int>(this.픣픆.Count);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓓());
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      loggers.Log(stringAndClear);
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
    finally
    {
      Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픗());
    }
  }

  public bool TryGetMessenger(string messengerName, out IMessenger messenger)
  {
    return this.픣픆.TryGetValue(messengerName, out messenger);
  }

  public void Dispose() => this.픣픆.Clear();
}
