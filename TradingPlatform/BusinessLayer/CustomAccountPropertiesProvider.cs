// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.CustomAccountPropertiesProvider
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public sealed class CustomAccountPropertiesProvider : ICustomizable
{
  public const string CUSTOM_NAME = "CustomName";
  public const string LOCKED = "Locked";
  private readonly ConcurrentDictionary<Account, Dictionary<string, object>> 픂픆;

  public event Action ParametersChanged;

  public CustomAccountPropertiesProvider()
  {
    this.픂픆 = new ConcurrentDictionary<Account, Dictionary<string, object>>();
  }

  public IList<SettingItem> Settings
  {
    get
    {
      List<SettingItem> settings = new List<SettingItem>();
      foreach (KeyValuePair<Account, Dictionary<string, object>> keyValuePair1 in this.픂픆)
      {
        List<SettingItem> items = new List<SettingItem>()
        {
          (SettingItem) new SettingItemAccount(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픆(), keyValuePair1.Key)
        };
        foreach (KeyValuePair<string, object> keyValuePair2 in keyValuePair1.Value)
          items.Add(this.퓏(keyValuePair2.Key, keyValuePair2.Value));
        SettingItemGroup settingItemGroup = new SettingItemGroup(string.Empty, (IList<SettingItem>) items);
        settings.Add((SettingItem) settingItemGroup);
      }
      return (IList<SettingItem>) settings;
    }
    set
    {
      foreach (SettingItem settingItem1 in (IEnumerable<SettingItem>) value)
      {
        if (settingItem1 is SettingItemGroup settingItemGroup)
        {
          Account key = (Account) null;
          Dictionary<string, object> dictionary = new Dictionary<string, object>();
          foreach (SettingItem settingItem2 in (IEnumerable<SettingItem>) (settingItemGroup.Value as IList<SettingItem>))
          {
            if (settingItem2.Name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픆())
              key = settingItem2.Value as Account;
            else
              dictionary[settingItem2.Name] = settingItem2.Value;
          }
          if (key != null)
            this.픂픆[key] = dictionary;
        }
      }
    }
  }

  public void SetProperty(Account account, string name, object value)
  {
    if (this.픂픆.ContainsKey(account))
      this.픂픆[account][name] = value;
    else
      this.픂픆[account] = new Dictionary<string, object>()
      {
        {
          name,
          value
        }
      };
    // ISSUE: reference to a compiler-generated field
    Action 픂픍 = this.픂픍;
    if (픂픍 == null)
      return;
    픂픍();
  }

  public object GetProperty(Account account, string name)
  {
    if (account == null)
      return (object) null;
    Dictionary<string, object> dictionary;
    object obj;
    return this.픂픆.TryGetValue(account, out dictionary) && dictionary.TryGetValue(name, out obj) ? obj : (object) null;
  }

  private SettingItem 퓏([In] string obj0, [In] object obj1)
  {
    switch (obj1)
    {
      case int num1:
        return (SettingItem) new SettingItemInteger(obj0, num1);
      case double num2:
        return (SettingItem) new SettingItemDouble(obj0, num2);
      case string _:
        return (SettingItem) new SettingItemString(obj0, (string) obj1);
      case bool flag:
        return (SettingItem) new SettingItemBoolean(obj0, flag);
      default:
        throw new ArgumentException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픅());
    }
  }
}
