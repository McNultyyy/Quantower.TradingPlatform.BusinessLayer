// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.DeltaCalculationType
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.ComponentModel;
using System.Runtime.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[DataContract(Name = "DeltaCalculationType", Namespace = "TradingPlatform")]
public enum DeltaCalculationType
{
  [Description("Aggressor flag"), EnumMember(Value = "Aggressor flag")] AggressorFlag,
  [Description("Tick direction"), EnumMember(Value = "Tick direction")] TickDirection,
}
