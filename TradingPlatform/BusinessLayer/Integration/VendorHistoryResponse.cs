// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.VendorHistoryResponse
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

public class VendorHistoryResponse : VendorIntervalResponse<IList<IHistoryItem>>
{
  public VendorHistoryResponse(IList<IHistoryItem> data)
    : base(data)
  {
  }

  public VendorHistoryResponse(string errorText)
    : base(errorText)
  {
  }

  public static VendorHistoryResponse CreateSuccess(IList<IHistoryItem> data)
  {
    return new VendorHistoryResponse(data);
  }

  public static VendorHistoryResponse CreateError(string errorText)
  {
    return new VendorHistoryResponse(errorText);
  }

  public static VendorHistoryResponse CreateError(Exception exception)
  {
    return new VendorHistoryResponse(exception.GetMessageRecursive());
  }
}
