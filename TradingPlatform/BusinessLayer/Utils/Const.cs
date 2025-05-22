// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.Const
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System.IO;
using System.Reflection;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils;

public static class Const
{
  public const double DOUBLE_UNDEFINED = double.NaN;
  public const string SETTINGS_FOLDER_NAME = "Settings";
  public const string SCRIPTS_FOLDER_NAME = "Scripts";
  public const string INDICATORS_FOLDER_NAME = "Indicators";
  public const string STRATEGIES_FOLDER_NAME = "Strategies";
  public const string PLACE_ORDER_STRATEGIES_FOLDER_NAME = "PlaceOrderStrategies";
  public const string SCRIPTS_DATA_FOLDER_NAME = "ScriptsData";
  public const string MEDIA_FOLDER_NAME = "Media";
  public const string MESSENGERS_FOLDER_NAME = "Messengers";
  private const string 핇퓺 = "History";
  internal const string 핇픊 = "history.db";
  private const string 핇픈 = "VolumeAnalysis";
  internal const string 핇퓒 = "volume-analysis.db";
  private const string 핇퓚 = "UserTradesCache";
  public const string USER_TRADES_STORAGE_FILE_NAME = "user-trades.db";
  public const string ORDERS_HISTORY_STORAGE_FILE_NAME = "orders-history.db";
  public static readonly string EXECUTING_FOLDER = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
  public static readonly string PLUGINS_FOLDER = Path.Combine(Const.EXECUTING_FOLDER, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓒());
  public static readonly string HISTORY_PATH = Path.Combine(Const.EXECUTING_FOLDER, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓚(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픃());
  public static readonly string VOLUME_ANALYSIS_PATH = Path.Combine(Const.EXECUTING_FOLDER, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓚(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓎());
  public static readonly string USER_TRADES_CACHE_PATH = Path.Combine(Const.EXECUTING_FOLDER, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓚(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇피());
  public static readonly string LOGS_FOLDER_PATH = Path.Combine(Const.EXECUTING_FOLDER, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓚(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓷());
  public static readonly string CUSTOM_SCRIPTS_PATH = Path.Combine(Const.EXECUTING_FOLDER, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓚(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓸(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓦());
  public static readonly string SCRIPTS_DATA_PATH = Path.Combine(Const.CUSTOM_SCRIPTS_PATH, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픋());
  public static readonly string DEFAULT_INDICATORS_RELATIVE_PATH = Path.Combine(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓦(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇핀());
  public static readonly string CUSTOM_INDICATORS_PATH = Path.Combine(Const.CUSTOM_SCRIPTS_PATH, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇핀());
  public static readonly string DEFAULT_STRATEGIES_RELATIVE_PATH = Path.Combine(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓦(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픲());
  public static readonly string CUSTOM_STRATEGIES_PATH = Path.Combine(Const.CUSTOM_SCRIPTS_PATH, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픲());
  public static readonly string DEFAULT_PLACE_ORDER_STRATEGIES_RELATIVE_PATH;
  public static readonly string CUSTOM_PLACE_ORDER_STRATEGIES_PATH;
  public static readonly string CUSTOM_PLUGINS_PATH;
  public static readonly string CUSTOM_VENDORS_PATH;
  public static readonly string CUSTOM_BIN_PATH;
  public static readonly string TEMP_PATH;
  public static readonly string MEDIA_PATH;
  public static readonly string MESSENGERS_PATH;
  public const string PLUGINS_FOLDER_NAME = "plug-ins";
  public const string VENDORS_FOLDER_NAME = "Vendors";
  public const string BIN_FOLDER_NAME = "bin";
  public const string NOT_AVAILABLE_STRING = "N/A";
  public const string CONSOLE_SCREEN_STRING = "*console#";
  public const string TEMP_STRING = "Temp";
  public const string LOGS_FOLDER_NAME = "Logs";

  static Const()
  {
    Const.DEFAULT_STRATEGIES_RELATIVE_PATH = Path.Combine(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓦(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픲());
    Const.CUSTOM_STRATEGIES_PATH = Path.Combine(Const.CUSTOM_SCRIPTS_PATH, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픲());
    Const.DEFAULT_PLACE_ORDER_STRATEGIES_RELATIVE_PATH = Path.Combine(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓦(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픽());
    Const.CUSTOM_PLACE_ORDER_STRATEGIES_PATH = Path.Combine(Const.CUSTOM_SCRIPTS_PATH, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픽());
    Const.CUSTOM_PLUGINS_PATH = Path.Combine(Const.CUSTOM_SCRIPTS_PATH, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓒());
    Const.CUSTOM_VENDORS_PATH = Path.Combine(Const.CUSTOM_SCRIPTS_PATH, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓏());
    Const.CUSTOM_BIN_PATH = Path.Combine(Const.CUSTOM_SCRIPTS_PATH, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓬());
    Const.TEMP_PATH = Path.Combine(Const.EXECUTING_FOLDER, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓚(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲핇());
    Const.MEDIA_PATH = Path.Combine(Const.EXECUTING_FOLDER, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓲());
    Const.MESSENGERS_PATH = Path.Combine(Const.MEDIA_PATH, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲핂());
  }
}
