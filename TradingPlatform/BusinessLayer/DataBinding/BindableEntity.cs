// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.DataBinding.BindableEntity
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Utils.EqualityComparers;

#nullable enable
namespace TradingPlatform.BusinessLayer.DataBinding;

public abstract class BindableEntity : IBindableEntity, INotifyPropertyChanged
{
  public const 
  #nullable disable
  string SYMBOL = "symbol";
  public const string ACCOUNT = "account";
  public const string ACCOUNTS = "accounts";
  public const string ORDER_TYPE = "orderType";
  public const string SIDE = "side";
  public const string QUANTITY = "quantity";
  public const string PRICE = "price";
  public const string TRIGGER_PRICE = "triggerPrice";
  public const string CONNECTION_ID = "connectionId";
  public const string CONNECTIONS = "connections";
  public const string CONNECTION = "connection";
  public const string EXCHANGES = "exchanges";
  public const string EXCHANGE = "exchange";
  public const string CONTAINERS = "containers";
  public const string CONTAINER = "container";
  public const string VISIBLE = "visible";
  public const string ENABLED = "enabled";
  public const string CHECKED = "checked";
  public const string HIDDEN = "hidden";
  public const string ERROR = "error";
  public const string WARNING = "warning";
  public const string ORDER = "order";
  public const string POSITION = "position";
  public const string GROSS_PNL = "grossPnl";
  public const string FEE = "fee";
  public const string NET_PNL = "netPnl";
  public const string STOP_LOSS = "stopLoss";
  public const string TAKE_PROFIT = "takeProfit";
  public const string BRACKET = "bracket";
  public const string IS_TRAILING = "isTrailing";
  public const string IS_TRAILING_ALLOWED = "isTrailingAllowed";
  public const string TICKS = "ticks";
  public const string PERIOD = "period";
  public const string SELECTED_ITEM = "selectedItem";
  public const string ITEMS = "items";
  public const string SETTINGS = "settings";
  public const string COMMAND = "command";
  public const string CANCEL_COMMAND = "cancelCommand";
  public const string CLOSE_COMMAND = "closeCommand";
  public const string ADD_COMMAND = "addCommand";
  public const string EDIT_COMMAND = "editCommand";
  public const string DELETE_COMMAND = "deleteCommand";
  public const string SELECT_COMMAND = "selectCommand";
  public const string SAVE_COMMAND = "saveCommand";
  public const string CLEAR_COMMAND = "clearAllCommand";
  public const string APPLY_COMMAND = "applyCommand";
  public const string DISCARD_COMMAND = "discardCommand";
  public const string CHANGED_COMMAND = "changedCommand";
  public const string VALUE = "value";
  public const string TEXT = "text";
  public const string LABEL = "label";
  public const string TOOLTIP = "tooltip";
  public const string MAXIMUM = "maximum";
  public const string MINIMUM = "minimum";
  public const string INCREMENT = "increment";
  public const string DECIMAL_PLACES = "decimalPlaces";
  public const string DIMENSION = "dimension";
  public const string LINK_TEXT = "linkText";
  public const string STEPS_COUNT = "stepsCount";
  public const string CURRENT_STEP = "currentStep";
  public const string WIDTH = "width";
  public const string IS_SLIM_MODE_ENABLED = "isSlimModeEnabled";
  public const string COLOR = "color";
  public const string FOREGROUND_COLOR = "foregroundColor";
  public const string BACKGROUND_COLOR = "backgroundColor";
  public const string FORMAT = "format";
  public const string INDEX = "index";
  public const string SHOW = "show";
  public const string SHOW_TOOLBAR = "showToolbar";
  public const string IS_ACTIVE = "isActive";
  public const string MULTIPLIER = "multiplier";
  public const string NAME = "name";
  public const string DESCRIPTION = "description";
  public const string FROM = "from";
  public const string TO = "to";
  public const string TYPE = "type";
  public const string START = "start";
  public const string END = "end";
  public const string DAY = "day";
  public const string TIMEZONE = "timeZone";
  public const string IS_VALID = "isValid";
  public const string DATE = "date";
  public const string DIRECTION = "direction";
  public const string PROGRESS = "progress";
  public const string COUNT = "count";
  public const string IS_ALLOWED = "isAllowed";
  public const string IS_LOADING = "isLoading";
  public const string COLUMNS = "columns";
  public const string ROWS = "rows";
  private static readonly BusinessObjectEqualityComparer 픣픟 = new BusinessObjectEqualityComparer();
  private static readonly ListEqualityComparer<SettingItem> 픣퓧 = new ListEqualityComparer<SettingItem>((IEqualityComparer<SettingItem>) EqualityComparer<SettingItem>.Default);
  private static readonly ListEqualityComparer<SlTpHolder> 픣픰 = new ListEqualityComparer<SlTpHolder>((IEqualityComparer<SlTpHolder>) EqualityComparer<SlTpHolder>.Default);
  private static readonly UniqueIdEqualityComparer 픣퓢 = new UniqueIdEqualityComparer();
  private readonly Lazy<ConcurrentDictionary<string, NotifyCollectionChangedEventHandler>> 픣픫 = new Lazy<ConcurrentDictionary<string, NotifyCollectionChangedEventHandler>>();

  public event PropertyChangedEventHandler PropertyChanged;

  protected bool SetValue<T>(
    ref T storage,
    T value,
    IEqualityComparer<T> comparer = null,
    [CallerMemberName] string propertyName = null)
  {
    if (this.IsValueEquals<T>(storage, value, comparer))
      return false;
    this.퓏<T>(storage, propertyName);
    storage = value;
    this.OnPropertyChanged(propertyName);
    this.퓬<T>(storage, propertyName);
    return true;
  }

  protected bool IsValueEquals<T>(T oldValue, T newValue, IEqualityComparer<T> comparer = null)
  {
    IEqualityComparer<T> equalityComparer = comparer;
    bool flag;
    if (equalityComparer != null)
    {
      flag = equalityComparer.Equals(oldValue, newValue);
    }
    else
    {
      T obj = oldValue ?? newValue;
      flag = (object) obj is Symbol ? BindableEntity.픣픟.Equals((object) oldValue as BusinessObject, (object) newValue as BusinessObject) : ((object) obj is IUniqueID ? BindableEntity.픣퓢.Equals((object) oldValue as IUniqueID, (object) newValue as IUniqueID) : ((object) obj is IList<SettingItem> ? BindableEntity.픣퓧.Equals((object) oldValue as IList<SettingItem>, (object) newValue as IList<SettingItem>) : ((object) obj is IList<SlTpHolder> ? BindableEntity.픣픰.Equals((object) oldValue as IList<SlTpHolder>, (object) newValue as IList<SlTpHolder>) : EqualityComparer<object>.Default.Equals((object) oldValue, (object) newValue))));
    }
    return flag;
  }

  private void 퓏<퓏>([In] 퓏 obj0, [In] string obj1)
  {
    NotifyCollectionChangedEventHandler changedEventHandler;
    if (!(obj0 is INotifyCollectionChanged collectionChanged) || obj1 == null || !this.픣픫.Value.TryRemove(obj1, out changedEventHandler))
      return;
    collectionChanged.CollectionChanged -= changedEventHandler;
  }

  private void 퓬<퓏>([In] 퓏 obj0, [In] string obj1)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    BindableEntity.퓏<퓏> 퓏 = new BindableEntity.퓏<퓏>();
    // ISSUE: reference to a compiler-generated field
    퓏.퓑픦 = this;
    // ISSUE: reference to a compiler-generated field
    퓏.퓑픍 = obj1;
    // ISSUE: reference to a compiler-generated field
    if (!(obj0 is INotifyCollectionChanged collectionChanged) || 퓏.퓑픍 == null)
      return;
    // ISSUE: reference to a compiler-generated method
    NotifyCollectionChangedEventHandler changedEventHandler = new NotifyCollectionChangedEventHandler(퓏.퓏);
    // ISSUE: reference to a compiler-generated field
    if (!this.픣픫.Value.TryAdd(퓏.퓑픍, changedEventHandler))
      return;
    collectionChanged.CollectionChanged += changedEventHandler;
  }

  protected void OnPropertyChanged(string propertyName)
  {
    this.퓏(new PropertyChangedEventArgs(propertyName));
  }

  private void 퓏([In] string obj0, [In] NotifyCollectionChangedEventArgs obj1)
  {
    this.퓏((PropertyChangedEventArgs) new CollectionChangedEventArgs(obj0, obj1));
  }

  private void 퓏([In] PropertyChangedEventArgs obj0)
  {
    // ISSUE: reference to a compiler-generated field
    PropertyChangedEventHandler 픣픯 = this.픣픯;
    if (픣픯 == null)
      return;
    픣픯.InvokeSafely((object) this, (object) obj0);
  }
}
