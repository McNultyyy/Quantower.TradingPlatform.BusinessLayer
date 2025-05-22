// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.EmailSendCompletedResult
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public class EmailSendCompletedResult
{
  public EmailSendCompletedStatus Status;
  public string Message;

  public void SetError(Exception ex)
  {
    this.Message = ex.Message;
    this.Status = EmailSendCompletedStatus.Failure;
  }
}
