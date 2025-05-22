// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.GlobalVariables.VariableNotExistsException
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer.GlobalVariables;

[Serializable]
public class VariableNotExistsException : Exception
{
  public string VariableName { get; [param: In] private set; }

  public VariableNotExistsException()
  {
  }

  public VariableNotExistsException(string message)
    : base(message)
  {
  }

  public VariableNotExistsException(string message, Exception inner)
    : base(message, inner)
  {
  }

  public VariableNotExistsException(string message, string variableName)
    : base(message)
  {
    this.VariableName = variableName;
  }

  protected VariableNotExistsException(SerializationInfo info, StreamingContext context)
    : base(info, context)
  {
  }
}
