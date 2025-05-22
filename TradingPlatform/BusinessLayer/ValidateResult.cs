// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.ValidateResult
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

#nullable disable
namespace TradingPlatform.BusinessLayer;

public struct ValidateResult
{
  public ValidateState State { get; set; }

  public string Reason { get; set; }

  public static ValidateResult Valid
  {
    get
    {
      return new ValidateResult()
      {
        State = ValidateState.Valid
      };
    }
  }

  public static ValidateResult NotValid(string reason)
  {
    return new ValidateResult()
    {
      State = ValidateState.NotValid,
      Reason = reason
    };
  }
}
