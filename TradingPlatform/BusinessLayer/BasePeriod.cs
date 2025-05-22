// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.BasePeriod
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Runtime.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>
/// Period that can be used as a basis for history aggregations
/// </summary>
[DataContract(Name = "BasePeriod", Namespace = "TradingPlatform")]
[Published]
public enum BasePeriod
{
  [EnumMember] Tick,
  [EnumMember] Second,
  [EnumMember] Minute,
  [EnumMember] Hour,
  [EnumMember] Day,
  [EnumMember] Week,
  [EnumMember] Month,
  [EnumMember] Year,
}
