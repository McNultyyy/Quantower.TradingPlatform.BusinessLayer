// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.RssItem
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Runtime.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils;

[DataContract(Name = "RssItem", Namespace = "TradingPlatform")]
public class RssItem : ICloneable
{
  private string 퓲핋;

  [DataMember(Name = "Active")]
  public bool Active { get; set; }

  [DataMember(Name = "Name")]
  public string Name { get; set; }

  [DataMember(Name = "Url")]
  public string Url
  {
    get => this.퓲핋;
    set
    {
      if (this.퓲핋 == value)
        return;
      this.퓲핋 = value;
      this.Subscribed = false;
    }
  }

  public bool Subscribed { get; set; }

  public object Clone()
  {
    return (object) new RssItem()
    {
      Active = this.Active,
      Name = this.Name,
      Url = this.Url,
      Subscribed = this.Subscribed
    };
  }
}
