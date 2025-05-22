// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.Sounds.Sound
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System.Collections.Generic;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils.Sounds;

public static class Sound
{
  public static string ConnectionFinished = loc.key(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픁());
  public static string ConnectionLost = loc.key(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픞());
  public static string OrderCreatedCancelledReplaced = loc.key(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲핁());
  public static string OrderFilled = loc.key(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픇());
  public static string OrderRejected = loc.key(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픣());
  public static string PositionClosed = loc.key(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓙());
  public static string DefaultAlert = loc.key(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓗());
  public static string UpdateAvailable = loc.key(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픎());

  public static Dictionary<string, string> Defaults { get; } = new Dictionary<string, string>()
  {
    [Sound.ConnectionFinished] = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓠(),
    [Sound.ConnectionLost] = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓥(),
    [Sound.OrderCreatedCancelledReplaced] = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓯(),
    [Sound.OrderFilled] = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픜(),
    [Sound.OrderRejected] = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓑(),
    [Sound.PositionClosed] = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲핋(),
    [Sound.DefaultAlert] = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓞(),
    [Sound.UpdateAvailable] = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲핅()
  };

  private static class 퓏
  {
    public const string 픇픺 = "connectionFinished.wav";
    public const string 픇핃 = "connectionLost.wav";
    public const string 픇퓫 = "orderFilled.wav";
    public const string 픇핌 = "orderRejected.wav";
    public const string 픇퓩 = "PositionClosed.wav";
    public const string 픇퓨 = "DefaultAlert.wav";
    public const string 픇퓱 = "OrderCreated.wav";
    public const string 픇픹 = "Update.wav";
  }
}
