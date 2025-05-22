// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.PnLRequestParameters
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

#nullable disable
namespace TradingPlatform.BusinessLayer;

[Published]
public class PnLRequestParameters : RequestParameters
{
  public override RequestType Type => RequestType.PnL;

  public Symbol Symbol { get; set; }

  public Account Account { get; set; }

  public double OpenPrice { get; set; }

  public double ClosePrice { get; set; }

  public Side Side { get; set; }

  public double Quantity { get; set; }

  public string PositionId { get; set; }

  public PnLRequestParameters()
  {
    this.OpenPrice = double.NaN;
    this.ClosePrice = double.NaN;
    this.Quantity = double.NaN;
  }

  public PnLRequestParameters(PnLRequestParameters original)
  {
    this.Symbol = original.Symbol;
    this.Account = original.Account;
    this.OpenPrice = original.OpenPrice;
    this.ClosePrice = original.ClosePrice;
    this.Side = original.Side;
    this.Quantity = original.Quantity;
    this.PositionId = original.PositionId;
  }
}
