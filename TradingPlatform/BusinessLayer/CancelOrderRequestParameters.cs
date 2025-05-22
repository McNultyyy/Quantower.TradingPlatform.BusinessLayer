// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.CancelOrderRequestParameters
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Runtime.CompilerServices;
using System.Text;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[Published]
public sealed class CancelOrderRequestParameters : TradingRequestParameters, ILoggable
{
  private string 픜퓗;

  public override RequestType Type => RequestType.CancelOrder;

  public IOrder Order { get; set; }

  public string OrderId
  {
    get
    {
      string 픜퓗 = this.픜퓗;
      if (픜퓗 != null)
        return 픜퓗;
      return this.Order?.Id;
    }
    set => this.픜퓗 = value;
  }

  public override string ConnectionId => this.Order.Symbol?.ConnectionId;

  public CancelOrderRequestParameters()
  {
  }

  public CancelOrderRequestParameters(CancelOrderRequestParameters original)
    : base((TradingRequestParameters) original)
  {
    this.OrderId = original.OrderId;
    this.Order = original.Order;
  }

  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 2);
    interpolatedStringHandler.AppendFormatted(base.ToString());
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓟());
    interpolatedStringHandler.AppendFormatted<IOrder>(this.Order);
    return interpolatedStringHandler.ToStringAndClear();
  }

  public override string Event
  {
    get
    {
      try
      {
        return OrderType.Format(this.Order) + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙핉();
      }
      catch (Exception ex)
      {
        Core.Instance.Loggers.Log(ex);
      }
      return \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙핊() + this.Order.OrderTypeId;
    }
  }

  public override string Message
  {
    get
    {
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder.AppendInterpolatedStringHandler interpolatedStringHandler;
      if (this.Order is TradingPlatform.BusinessLayer.Order order)
      {
        StringBuilder stringBuilder2 = stringBuilder1;
        StringBuilder stringBuilder3 = stringBuilder2;
        interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(14, 1, stringBuilder2);
        interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픛());
        interpolatedStringHandler.AppendFormatted(order.Connection.Name);
        interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬());
        ref StringBuilder.AppendInterpolatedStringHandler local = ref interpolatedStringHandler;
        stringBuilder3.Append(ref local);
      }
      StringBuilder stringBuilder4 = stringBuilder1;
      StringBuilder stringBuilder5 = stringBuilder4;
      interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(10, 1, stringBuilder4);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓺());
      interpolatedStringHandler.AppendFormatted(this.Order.Symbol.Name);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬());
      ref StringBuilder.AppendInterpolatedStringHandler local1 = ref interpolatedStringHandler;
      stringBuilder5.Append(ref local1);
      string property = Core.Instance.CustomAccountPropertiesProvider.GetProperty(this.Order.Account, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픡()) as string;
      string str = string.IsNullOrEmpty(property) ? this.Order.Account.Name : this.Order.Account.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓓() + property + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픗();
      StringBuilder stringBuilder6 = stringBuilder1;
      StringBuilder stringBuilder7 = stringBuilder6;
      interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(11, 1, stringBuilder6);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓜());
      interpolatedStringHandler.AppendFormatted(str);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬());
      ref StringBuilder.AppendInterpolatedStringHandler local2 = ref interpolatedStringHandler;
      stringBuilder7.Append(ref local2);
      StringBuilder stringBuilder8 = stringBuilder1;
      StringBuilder stringBuilder9 = stringBuilder8;
      interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(12, 1, stringBuilder8);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픺());
      interpolatedStringHandler.AppendFormatted(this.Order.Symbol.FormatQuantity(this.Order.RemainingQuantity));
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬());
      ref StringBuilder.AppendInterpolatedStringHandler local3 = ref interpolatedStringHandler;
      stringBuilder9.Append(ref local3);
      StringBuilder stringBuilder10 = stringBuilder1;
      StringBuilder stringBuilder11 = stringBuilder10;
      interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(12, 1, stringBuilder10);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙핃());
      interpolatedStringHandler.AppendFormatted(this.Order.Id);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬());
      ref StringBuilder.AppendInterpolatedStringHandler local4 = ref interpolatedStringHandler;
      stringBuilder11.Append(ref local4);
      StringBuilder stringBuilder12 = stringBuilder1;
      StringBuilder stringBuilder13 = stringBuilder12;
      interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(8, 1, stringBuilder12);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓫());
      interpolatedStringHandler.AppendFormatted<Side>(this.Order.Side);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬());
      ref StringBuilder.AppendInterpolatedStringHandler local5 = ref interpolatedStringHandler;
      stringBuilder13.Append(ref local5);
      StringBuilder stringBuilder14 = stringBuilder1;
      StringBuilder stringBuilder15 = stringBuilder14;
      interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(14, 1, stringBuilder14);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙핌());
      interpolatedStringHandler.AppendFormatted(OrderType.Format(this.Order));
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬());
      ref StringBuilder.AppendInterpolatedStringHandler local6 = ref interpolatedStringHandler;
      stringBuilder15.Append(ref local6);
      string orderTypeId = this.Order.OrderTypeId;
      if (!(orderTypeId == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁핃()) && !(orderTypeId == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픜()))
      {
        if (!(orderTypeId == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픛()))
        {
          if (orderTypeId == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁픺())
          {
            StringBuilder stringBuilder16 = stringBuilder1;
            StringBuilder stringBuilder17 = stringBuilder16;
            interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(17, 1, stringBuilder16);
            interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓨());
            interpolatedStringHandler.AppendFormatted(this.Order.Symbol.FormatOffset(this.Order.TrailOffset, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픹()));
            ref StringBuilder.AppendInterpolatedStringHandler local7 = ref interpolatedStringHandler;
            stringBuilder17.Append(ref local7);
          }
        }
        else
        {
          StringBuilder stringBuilder18 = stringBuilder1;
          StringBuilder stringBuilder19 = stringBuilder18;
          interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(17, 1, stringBuilder18);
          interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓩());
          interpolatedStringHandler.AppendFormatted(this.Order.Symbol.FormatPrice(this.Order.TriggerPrice));
          interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬());
          ref StringBuilder.AppendInterpolatedStringHandler local8 = ref interpolatedStringHandler;
          stringBuilder19.Append(ref local8);
        }
      }
      else
      {
        StringBuilder stringBuilder20 = stringBuilder1;
        StringBuilder stringBuilder21 = stringBuilder20;
        interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(9, 1, stringBuilder20);
        interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픏());
        interpolatedStringHandler.AppendFormatted(this.Order.Symbol.FormatPrice(this.Order.Price));
        interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬());
        ref StringBuilder.AppendInterpolatedStringHandler local9 = ref interpolatedStringHandler;
        stringBuilder21.Append(ref local9);
      }
      if (this.Order.StopLoss != null)
      {
        StringBuilder stringBuilder22 = stringBuilder1;
        StringBuilder stringBuilder23 = stringBuilder22;
        interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(11, 1, stringBuilder22);
        interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓱());
        interpolatedStringHandler.AppendFormatted(this.Order.StopLoss.Format(this.Order.Symbol));
        ref StringBuilder.AppendInterpolatedStringHandler local10 = ref interpolatedStringHandler;
        stringBuilder23.Append(ref local10);
      }
      if (this.Order.TakeProfit != null)
      {
        StringBuilder stringBuilder24 = stringBuilder1;
        StringBuilder stringBuilder25 = stringBuilder24;
        interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(13, 1, stringBuilder24);
        interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픹());
        interpolatedStringHandler.AppendFormatted(this.Order.TakeProfit.Format(this.Order.Symbol));
        ref StringBuilder.AppendInterpolatedStringHandler local11 = ref interpolatedStringHandler;
        stringBuilder25.Append(ref local11);
      }
      StringBuilder stringBuilder26 = stringBuilder1;
      StringBuilder stringBuilder27 = stringBuilder26;
      interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(13, 1, stringBuilder26);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓺());
      interpolatedStringHandler.AppendFormatted<DateTime>(Core.Instance.TimeUtils.DateTimeUtcNow);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬());
      ref StringBuilder.AppendInterpolatedStringHandler local12 = ref interpolatedStringHandler;
      stringBuilder27.Append(ref local12);
      if (!string.IsNullOrEmpty(this.SendingSource))
      {
        StringBuilder stringBuilder28 = stringBuilder1;
        StringBuilder stringBuilder29 = stringBuilder28;
        interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(8, 1, stringBuilder28);
        interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픊());
        interpolatedStringHandler.AppendFormatted(this.SendingSource);
        ref StringBuilder.AppendInterpolatedStringHandler local13 = ref interpolatedStringHandler;
        stringBuilder29.Append(ref local13);
      }
      StringBuilder stringBuilder30 = stringBuilder1;
      StringBuilder stringBuilder31 = stringBuilder30;
      interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(13, 1, stringBuilder30);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픈());
      interpolatedStringHandler.AppendFormatted<long>(this.RequestId);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬());
      ref StringBuilder.AppendInterpolatedStringHandler local14 = ref interpolatedStringHandler;
      stringBuilder31.Append(ref local14);
      return stringBuilder1.ToString();
    }
  }

  protected override Account GetAccount() => this.Order?.Account;
}
