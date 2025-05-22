// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.ExecutionEntity
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public abstract class ExecutionEntity : IDisposable, ICustomizable
{
  private static readonly Type 퓍픖 = typeof (SettingItem);
  private static readonly Dictionary<Type, SettingItemType> 퓍퓘 = new Dictionary<Type, SettingItemType>()
  {
    {
      typeof (bool),
      SettingItemType.Boolean
    },
    {
      typeof (int),
      SettingItemType.Integer
    },
    {
      typeof (string),
      SettingItemType.String
    },
    {
      typeof (long),
      SettingItemType.Integer
    },
    {
      typeof (double),
      SettingItemType.Double
    },
    {
      typeof (Decimal),
      SettingItemType.Double
    },
    {
      typeof (DateTime),
      SettingItemType.DateTime
    },
    {
      typeof (Period),
      SettingItemType.Period
    },
    {
      typeof (Account),
      SettingItemType.Account
    },
    {
      typeof (Symbol),
      SettingItemType.Symbol
    },
    {
      typeof (Color),
      SettingItemType.Color
    },
    {
      typeof (PairColor),
      SettingItemType.PairColor
    },
    {
      typeof (LineOptions),
      SettingItemType.LineOptions
    }
  };
  private readonly Type 퓍픬;

  protected static Core Core => Core.Instance;

  public string Name { get; protected set; }

  public string Description { get; protected set; }

  public ScriptKey Key { get; [param: In] internal set; }

  public Version Version { get; }

  public virtual IList<SettingItem> Settings
  {
    get
    {
      List<SettingItem> settings = new List<SettingItem>();
      SettingItemSeparatorGroup itemSeparatorGroup = new SettingItemSeparatorGroup(loc._(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓛(), callerFilePath: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픝()), -1000)
      {
        Key = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픻()
      };
      foreach (FieldInfo element in ((IEnumerable<FieldInfo>) this.퓍픬.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)).Where<FieldInfo>((Func<FieldInfo, bool>) (([In] obj0) => Attribute.IsDefined((MemberInfo) obj0, typeof (InputParameterAttribute)))))
      {
        InputParameterAttribute customAttribute = element.GetCustomAttribute<InputParameterAttribute>(true);
        object obj1 = element.GetValue((object) this);
        Type fieldType = element.FieldType;
        string name = element.Name;
        object obj2 = obj1;
        SettingItem settingItem = ExecutionEntity.퓏(customAttribute, fieldType, name, obj2);
        if (settingItem != null)
          settings.Add(settingItem);
      }
      foreach (PropertyInfo element in ((IEnumerable<PropertyInfo>) this.퓍픬.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)).Where<PropertyInfo>((Func<PropertyInfo, bool>) (([In] obj0) => Attribute.IsDefined((MemberInfo) obj0, typeof (InputParameterAttribute)))))
      {
        InputParameterAttribute customAttribute = element.GetCustomAttribute<InputParameterAttribute>(true);
        object obj3 = element.GetValue((object) this);
        Type propertyType = element.PropertyType;
        string name = element.Name;
        object obj4 = obj3;
        SettingItem settingItem = ExecutionEntity.퓏(customAttribute, propertyType, name, obj4);
        if (settingItem != null)
          settings.Add(settingItem);
      }
      foreach (FieldInfo fieldInfo in ((IEnumerable<FieldInfo>) this.퓍픬.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)).Where<FieldInfo>((Func<FieldInfo, bool>) (([In] obj0) => ExecutionEntity.퓍픖.IsAssignableFrom(obj0.FieldType) && !Attribute.IsDefined((MemberInfo) obj0, typeof (InputParameterAttribute)))))
      {
        if (fieldInfo.GetValue((object) this) is SettingItem settingItem)
          settings.Add(settingItem.GetCopy());
      }
      foreach (PropertyInfo propertyInfo in ((IEnumerable<PropertyInfo>) this.퓍픬.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)).Where<PropertyInfo>((Func<PropertyInfo, bool>) (([In] obj0) => ExecutionEntity.퓍픖.IsAssignableFrom(obj0.PropertyType) && !Attribute.IsDefined((MemberInfo) obj0, typeof (InputParameterAttribute)))))
      {
        if (propertyInfo.GetValue((object) this) is SettingItem settingItem)
          settings.Add(settingItem.GetCopy());
      }
      List<SettingItem> settingItemList = settings;
      SettingItemString settingItemString = new SettingItemString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓤(), this.Key.ToString());
      settingItemString.VisibilityMode = VisibilityMode.Hidden;
      settingItemList.Add((SettingItem) settingItemString);
      for (int index = 0; index < settings.Count; ++index)
        settings[index].SeparatorGroup = itemSeparatorGroup;
      return (IList<SettingItem>) settings;
    }
    set
    {
      if (value == null)
        throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓸());
      bool flag = false;
      Dictionary<string, FieldInfo> dictionary1 = (Dictionary<string, FieldInfo>) null;
      Dictionary<string, PropertyInfo> dictionary2 = (Dictionary<string, PropertyInfo>) null;
      IEnumerable<FieldInfo> source1 = ((IEnumerable<FieldInfo>) this.퓍픬.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)).Where<FieldInfo>((Func<FieldInfo, bool>) (([In] obj0) => Attribute.IsDefined((MemberInfo) obj0, typeof (InputParameterAttribute))));
      IEnumerable<PropertyInfo> source2 = ((IEnumerable<PropertyInfo>) this.퓍픬.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)).Where<PropertyInfo>((Func<PropertyInfo, bool>) (([In] obj0) => Attribute.IsDefined((MemberInfo) obj0, typeof (InputParameterAttribute))));
      if (source1.Count<FieldInfo>() > 0)
      {
        dictionary1 = new Dictionary<string, FieldInfo>();
        foreach (FieldInfo element in source1)
        {
          InputParameterAttribute customAttribute = element.GetCustomAttribute<InputParameterAttribute>(true);
          string key = string.IsNullOrEmpty(customAttribute.Name) ? element.Name : customAttribute.Name;
          dictionary1.Add(key, element);
        }
      }
      if (source2.Count<PropertyInfo>() > 0)
      {
        dictionary2 = new Dictionary<string, PropertyInfo>();
        foreach (PropertyInfo element in source2)
        {
          InputParameterAttribute customAttribute = element.GetCustomAttribute<InputParameterAttribute>(true);
          string key = string.IsNullOrEmpty(customAttribute.Name) ? element.Name : customAttribute.Name;
          dictionary2.Add(key, element);
        }
      }
      foreach (SettingItem settingItem in (IEnumerable<SettingItem>) value)
      {
        object obj;
        if (settingItem.Type == SettingItemType.SelectorLocalized)
        {
          if (settingItem.Value is SelectItem selectItem)
            obj = (object) selectItem.Value;
          else
            continue;
        }
        else
          obj = settingItem.Value;
        FieldInfo fieldInfo = (FieldInfo) null;
        if (dictionary1 != null && __nonvirtual (dictionary1.TryGetValue(settingItem.Name, out fieldInfo)))
        {
          fieldInfo.SetValue((object) this, obj);
          flag = true;
        }
        else
        {
          PropertyInfo propertyInfo = (PropertyInfo) null;
          if (dictionary2 != null && __nonvirtual (dictionary2.TryGetValue(settingItem.Name, out propertyInfo)))
          {
            propertyInfo.SetValue((object) this, obj);
            flag = true;
          }
        }
      }
      foreach (FieldInfo fieldInfo in ((IEnumerable<FieldInfo>) this.퓍픬.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)).Where<FieldInfo>((Func<FieldInfo, bool>) (([In] obj0) => ExecutionEntity.퓍픖.IsAssignableFrom(obj0.FieldType) && !Attribute.IsDefined((MemberInfo) obj0, typeof (InputParameterAttribute)))))
      {
        if (fieldInfo.GetValue((object) this) is SettingItem settingItem)
          flag |= settingItem.퓏(value);
      }
      foreach (PropertyInfo propertyInfo in ((IEnumerable<PropertyInfo>) this.퓍픬.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)).Where<PropertyInfo>((Func<PropertyInfo, bool>) (([In] obj0) => ExecutionEntity.퓍픖.IsAssignableFrom(obj0.PropertyType) && !Attribute.IsDefined((MemberInfo) obj0, typeof (InputParameterAttribute)))))
      {
        if (propertyInfo.GetValue((object) this) is SettingItem settingItem)
          flag |= settingItem.퓏(value);
      }
      if (value.GetItemByName(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓤()) is SettingItemString itemByName && !string.IsNullOrEmpty(itemByName.Value as string))
        this.Key = ScriptKey.CreateScriptKeyFromString(itemByName.Value.ToString());
      if (!flag)
        return;
      this.OnSettingsUpdated();
    }
  }

  public event Action<ExecutionEntity> OnDispose;

  private protected bool Disposed { get; [param: In] private set; }

  protected ExecutionEntity()
  {
    this.퓍픬 = this.GetType();
    string version = this.퓍픬.Assembly.퓬();
    this.Version = string.IsNullOrEmpty(version) ? (Version) null : new Version(version);
  }

  public virtual void Dispose()
  {
    this.Disposed = true;
    // ISSUE: reference to a compiler-generated field
    Action<ExecutionEntity> 퓍픵 = this.퓍픵;
    if (퓍픵 == null)
      return;
    퓍픵(this);
  }

  protected virtual void OnSettingsUpdated()
  {
  }

  protected void CheckDisposed()
  {
    if (this.Disposed)
      throw new ObjectDisposedException(this.Name);
  }

  private static SettingItem 퓏([In] InputParameterAttribute obj0, [In] Type obj1, [In] string obj2, [In] object obj3)
  {
    string name = string.IsNullOrEmpty(obj0.Name) ? obj2 : obj0.Name;
    int sortIndex = obj0.SortIndex;
    double minimum = obj0.Minimum;
    double maximum = obj0.Maximum;
    double increment = obj0.Increment;
    int decimalPlaces = obj0.DecimalPlaces;
    SettingItem settingItem1 = (SettingItem) null;
    if (obj0.Variants != null)
    {
      if (obj0.Variants.Length % 2 != 0)
        throw new ArgumentException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픮());
      if (!(obj3 is IComparable comparable1))
        throw new ArgumentException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픉());
      List<SelectItem> items = new List<SelectItem>();
      SelectItem selectItem1 = (SelectItem) null;
      for (int index = 0; index < obj0.Variants.Length; index += 2)
      {
        IComparable comparable2 = obj0.Variants[index + 1];
        if (comparable2 == null)
          throw new ArgumentException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픒());
        if (comparable2.GetType() != obj1)
        {
          DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(70, 2);
          interpolatedStringHandler.AppendFormatted(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓷());
          interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓿());
          interpolatedStringHandler.AppendFormatted<Type>(obj1);
          throw new ArgumentException(interpolatedStringHandler.ToStringAndClear());
        }
        if (comparable2 is Enum)
        {
          comparable2 = (IComparable) (int) comparable2;
          comparable1 = (IComparable) (int) comparable1;
        }
        SelectItem selectItem2 = new SelectItem(obj0.Variants[index].ToString(), comparable2);
        items.Add(selectItem2);
        if (comparable2.CompareTo((object) comparable1) == 0)
          selectItem1 = selectItem2;
      }
      settingItem1 = (SettingItem) new SettingItemSelectorLocalized(name, selectItem1, items, sortIndex);
    }
    else
    {
      SettingItemType settingItemType;
      if (ExecutionEntity.퓍퓘.TryGetValue(obj1, out settingItemType))
      {
        SettingItem settingItem2;
        switch (settingItemType)
        {
          case SettingItemType.String:
            settingItem2 = (SettingItem) new SettingItemString(name, obj3 == null ? (string) null : (string) obj3, sortIndex);
            break;
          case SettingItemType.Boolean:
            settingItem2 = (SettingItem) new SettingItemBoolean(name, obj3 != null && (bool) obj3, sortIndex);
            break;
          case SettingItemType.Integer:
            SettingItemInteger settingItemInteger = new SettingItemInteger(name, obj3 == null ? 0 : (int) obj3, sortIndex);
            settingItemInteger.Minimum = (int) minimum;
            settingItemInteger.Maximum = (int) maximum;
            settingItemInteger.Increment = Math.Max((int) increment, 1);
            settingItem2 = (SettingItem) settingItemInteger;
            break;
          case SettingItemType.Double:
            SettingItemDouble settingItemDouble = new SettingItemDouble(name, obj3 == null ? 0.0 : (double) obj3, sortIndex);
            settingItemDouble.Minimum = minimum;
            settingItemDouble.Maximum = maximum;
            settingItemDouble.Increment = increment;
            settingItemDouble.DecimalPlaces = decimalPlaces;
            settingItem2 = (SettingItem) settingItemDouble;
            break;
          case SettingItemType.DateTime:
            settingItem2 = (SettingItem) new SettingItemDateTime(name, obj3 == null ? new DateTime() : (DateTime) obj3, sortIndex);
            break;
          case SettingItemType.Account:
            settingItem2 = (SettingItem) new SettingItemAccount(name, obj3 == null ? (Account) null : (Account) obj3, sortIndex);
            break;
          case SettingItemType.Symbol:
            settingItem2 = (SettingItem) new SettingItemSymbol(name, obj3 == null ? (Symbol) null : (Symbol) obj3, sortIndex);
            break;
          case SettingItemType.Period:
            settingItem2 = (SettingItem) new SettingItemPeriod(name, obj3 == null ? new Period() : (Period) obj3, sortIndex);
            break;
          case SettingItemType.PairColor:
            settingItem2 = (SettingItem) new SettingItemPairColor(name, obj3 == null ? (PairColor) null : (PairColor) obj3, sortIndex);
            break;
          case SettingItemType.Color:
            settingItem2 = (SettingItem) new SettingItemColor(name, obj3 == null ? new Color() : (Color) obj3, sortIndex);
            break;
          case SettingItemType.LineOptions:
            settingItem2 = (SettingItem) new SettingItemLineOptions(name, obj3 == null ? (LineOptions) null : (LineOptions) obj3, sortIndex);
            break;
          default:
            DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(37, 1);
            interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픟());
            interpolatedStringHandler.AppendFormatted<Type>(obj3.GetType());
            interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픗());
            throw new ArgumentException(interpolatedStringHandler.ToStringAndClear());
        }
        settingItem1 = settingItem2;
      }
    }
    return settingItem1;
  }
}
