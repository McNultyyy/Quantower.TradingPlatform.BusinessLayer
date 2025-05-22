// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.GlobalVariables.TooBigObjectException
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Runtime.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer.GlobalVariables;

/// <summary>Object too big</summary>
[Serializable]
public class TooBigObjectException : Exception
{
  public TooBigObjectException()
  {
  }

  public TooBigObjectException(string message)
    : base(message)
  {
  }

  public TooBigObjectException(string message, Exception inner)
    : base(message, inner)
  {
  }

  protected TooBigObjectException(SerializationInfo info, StreamingContext context)
    : base(info, context)
  {
  }
}
