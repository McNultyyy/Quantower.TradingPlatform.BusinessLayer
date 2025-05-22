// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SymbolGroup
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using TradingPlatform.BusinessLayer.Integration;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>
/// Provides possibility to group and sort symbols for each connection
/// </summary>
[Published]
[DataContract(Name = "InstrumentGroup", Namespace = "TradingPlatform")]
public class SymbolGroup : BusinessObject
{
  /// <summary>Gets group Id</summary>
  [DataMember(Name = "GroupId")]
  public string Id { get; [param: In] private set; }

  /// <summary>Gets group name</summary>
  [DataMember(Name = "GroupName")]
  public string GroupName { get; [param: In] private set; }

  /// <summary>Gets sort index for comparing process</summary>
  [DataMember(Name = "SortIndex")]
  public int SortIndex { get; [param: In] private set; }

  internal SymbolGroup([In] string obj0)
    : base(obj0)
  {
  }

  internal void 퓏([In] MessageSymbolGroup obj0)
  {
    this.Id = obj0.Id;
    this.GroupName = obj0.GroupName;
    this.SortIndex = obj0.SortIndex;
  }
}
