// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.DealTicketItem
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[DataContract]
public sealed class DealTicketItem
{
  private readonly object 퓻;

  [DataMember(Name = "key")]
  public string Key { get; [param: In] private set; }

  [DataMember(Name = "value")]
  public string FormattedValue => this.퓻?.ToString();

  public int SortIndex { get; }

  public DealTicketItem(string key, object value, int sortIndex = 0)
  {
    this.Key = key;
    this.퓻 = value;
    this.SortIndex = sortIndex;
  }
}
