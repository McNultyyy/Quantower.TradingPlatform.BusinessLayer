// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.ClosePositionRequestParameters
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System.Runtime.CompilerServices;
using System.Text;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[Published]
public class ClosePositionRequestParameters : TradingRequestParameters, ILoggable
{
  public override RequestType Type => RequestType.ClosePosition;

  public Position Position { get; set; }

  public double CloseQuantity { get; set; }

  public override string ConnectionId => this.Position?.Symbol?.ConnectionId;

  public ClosePositionRequestParameters()
  {
  }

  public ClosePositionRequestParameters(ClosePositionRequestParameters origin)
    : base((TradingRequestParameters) origin)
  {
    this.Position = origin.Position;
    this.CloseQuantity = origin.CloseQuantity;
  }

  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 3);
    interpolatedStringHandler.AppendFormatted(base.ToString());
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓒());
    interpolatedStringHandler.AppendFormatted<double>(this.CloseQuantity);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프());
    interpolatedStringHandler.AppendFormatted<Position>(this.Position);
    return interpolatedStringHandler.ToStringAndClear();
  }

  public override string Event
  {
    get => \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓚();
  }

  public override string Message
  {
    get
    {
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = stringBuilder1;
      StringBuilder stringBuilder3 = stringBuilder2;
      StringBuilder.AppendInterpolatedStringHandler interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(14, 1, stringBuilder2);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픛());
      interpolatedStringHandler.AppendFormatted(this.Position.Connection.Name);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬());
      ref StringBuilder.AppendInterpolatedStringHandler local1 = ref interpolatedStringHandler;
      stringBuilder3.Append(ref local1);
      StringBuilder stringBuilder4 = stringBuilder1;
      StringBuilder stringBuilder5 = stringBuilder4;
      interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(10, 1, stringBuilder4);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓺());
      interpolatedStringHandler.AppendFormatted(this.Position.Symbol.Name);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬());
      ref StringBuilder.AppendInterpolatedStringHandler local2 = ref interpolatedStringHandler;
      stringBuilder5.Append(ref local2);
      string property = Core.Instance.CustomAccountPropertiesProvider.GetProperty(this.Position.Account, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픡()) as string;
      string str = string.IsNullOrEmpty(property) ? this.Position.Account.Name : this.Position.Account.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓓() + property + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픗();
      StringBuilder stringBuilder6 = stringBuilder1;
      StringBuilder stringBuilder7 = stringBuilder6;
      interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(11, 1, stringBuilder6);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓜());
      interpolatedStringHandler.AppendFormatted(str);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬());
      ref StringBuilder.AppendInterpolatedStringHandler local3 = ref interpolatedStringHandler;
      stringBuilder7.Append(ref local3);
      StringBuilder stringBuilder8 = stringBuilder1;
      StringBuilder stringBuilder9 = stringBuilder8;
      interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(12, 1, stringBuilder8);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픺());
      interpolatedStringHandler.AppendFormatted(this.Position.Symbol.FormatQuantity(this.Position.Quantity));
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬());
      ref StringBuilder.AppendInterpolatedStringHandler local4 = ref interpolatedStringHandler;
      stringBuilder9.Append(ref local4);
      StringBuilder stringBuilder10 = stringBuilder1;
      StringBuilder stringBuilder11 = stringBuilder10;
      interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(15, 1, stringBuilder10);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픃());
      interpolatedStringHandler.AppendFormatted(this.Position.Id);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬());
      ref StringBuilder.AppendInterpolatedStringHandler local5 = ref interpolatedStringHandler;
      stringBuilder11.Append(ref local5);
      StringBuilder stringBuilder12 = stringBuilder1;
      StringBuilder stringBuilder13 = stringBuilder12;
      interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(8, 1, stringBuilder12);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓫());
      interpolatedStringHandler.AppendFormatted<Side>(this.Position.Side);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬());
      ref StringBuilder.AppendInterpolatedStringHandler local6 = ref interpolatedStringHandler;
      stringBuilder13.Append(ref local6);
      StringBuilder stringBuilder14 = stringBuilder1;
      StringBuilder stringBuilder15 = stringBuilder14;
      interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(9, 1, stringBuilder14);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픏());
      interpolatedStringHandler.AppendFormatted(this.Position.Symbol.FormatPrice(this.Position.CurrentPrice));
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬());
      ref StringBuilder.AppendInterpolatedStringHandler local7 = ref interpolatedStringHandler;
      stringBuilder15.Append(ref local7);
      Order stopLoss = this.Position.StopLoss;
      if (stopLoss != null)
      {
        StringBuilder stringBuilder16 = stringBuilder1;
        StringBuilder stringBuilder17 = stringBuilder16;
        interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(11, 1, stringBuilder16);
        interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓱());
        interpolatedStringHandler.AppendFormatted(stopLoss.OrderTypeId == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픺() ? this.Position.Symbol.FormatOffset(stopLoss.TrailOffset, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픹()) : this.Position.Symbol.FormatPrice(stopLoss.Price));
        ref StringBuilder.AppendInterpolatedStringHandler local8 = ref interpolatedStringHandler;
        stringBuilder17.Append(ref local8);
      }
      Order takeProfit = this.Position.TakeProfit;
      if (takeProfit != null)
      {
        StringBuilder stringBuilder18 = stringBuilder1;
        StringBuilder stringBuilder19 = stringBuilder18;
        interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(13, 1, stringBuilder18);
        interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픹());
        interpolatedStringHandler.AppendFormatted(this.Position.Symbol.FormatPrice(takeProfit.Price));
        ref StringBuilder.AppendInterpolatedStringHandler local9 = ref interpolatedStringHandler;
        stringBuilder19.Append(ref local9);
      }
      StringBuilder stringBuilder20 = stringBuilder1;
      StringBuilder stringBuilder21 = stringBuilder20;
      interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(13, 1, stringBuilder20);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓺());
      interpolatedStringHandler.AppendFormatted(Core.Instance.TimeUtils.DateTimeUtcNow.ToString());
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬());
      ref StringBuilder.AppendInterpolatedStringHandler local10 = ref interpolatedStringHandler;
      stringBuilder21.Append(ref local10);
      if (!string.IsNullOrEmpty(this.SendingSource))
      {
        StringBuilder stringBuilder22 = stringBuilder1;
        StringBuilder stringBuilder23 = stringBuilder22;
        interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(8, 1, stringBuilder22);
        interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픊());
        interpolatedStringHandler.AppendFormatted(this.SendingSource);
        ref StringBuilder.AppendInterpolatedStringHandler local11 = ref interpolatedStringHandler;
        stringBuilder23.Append(ref local11);
      }
      StringBuilder stringBuilder24 = stringBuilder1;
      StringBuilder stringBuilder25 = stringBuilder24;
      interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(13, 1, stringBuilder24);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픈());
      interpolatedStringHandler.AppendFormatted<long>(this.RequestId);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬());
      ref StringBuilder.AppendInterpolatedStringHandler local12 = ref interpolatedStringHandler;
      stringBuilder25.Append(ref local12);
      return stringBuilder1.ToString();
    }
  }

  protected override Account GetAccount() => this.Position?.Account;
}
