// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.HistoryItemCustom
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public sealed class HistoryItemCustom : HistoryItem
{
  private const int 퓥퓢 = 0;
  private const int 퓥픫 = 1;
  private const int 퓥픯 = 2;
  private const int 퓥퓾 = 3;
  private double[] 퓥퓐;

  internal double Open
  {
    get => this.퓥퓐[0];
    [param: In] set => this.퓥퓐[0] = value;
  }

  internal double High
  {
    get => this.퓥퓐[1];
    [param: In] set => this.퓥퓐[1] = value;
  }

  internal double Low
  {
    get => this.퓥퓐[2];
    [param: In] set => this.퓥퓐[2] = value;
  }

  internal double Close
  {
    get => this.퓥퓐[3];
    [param: In] set => this.퓥퓐[3] = value;
  }

  public override double this[PriceType priceType]
  {
    get
    {
      switch (priceType)
      {
        case PriceType.Open:
          return this.Open;
        case PriceType.High:
          return this.High;
        case PriceType.Low:
          return this.Low;
        case PriceType.Close:
          return this.Close;
        default:
          return base[priceType];
      }
    }
  }

  internal bool IsEmpty { get; [param: In] set; }

  internal HistoryItemCustom([In] double obj0, [In] double obj1, [In] double obj2, [In] double obj3)
  {
    this.퓥퓐 = new double[4];
    this.Open = obj0;
    this.High = obj1;
    this.Low = obj2;
    this.Close = obj3;
    this.IsEmpty = double.IsNaN(obj0) && double.IsNaN(obj1) && double.IsNaN(obj2) && double.IsNaN(obj3);
  }

  private HistoryItemCustom([In] HistoryItemCustom obj0)
    : base((HistoryItem) obj0)
  {
    this.퓥퓐 = new double[4];
    for (int index = 0; index < obj0.퓥퓐.Length; ++index)
      this.퓥퓐[index] = obj0.퓥퓐[index];
  }

  public override object Clone() => (object) new HistoryItemCustom(this);
}
