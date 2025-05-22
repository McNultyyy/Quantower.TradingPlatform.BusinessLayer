// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.Sounds.SoundItem
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Serialization;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils.Sounds;

public class SoundItem : IXElementSerialization
{
  public bool Enabled { get; set; }

  public string Name { get; [param: In] private set; }

  public string CurrentPath { get; set; }

  public SoundItem()
  {
  }

  public SoundItem(string name)
  {
    this.Enabled = true;
    this.Name = name;
    this.CurrentPath = Sound.Defaults[name];
  }

  public void FromXElement(XElement element, DeserializationInfo deserializationInfo)
  {
    this.Enabled = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픏()).ToBool();
    this.Name = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픜()).Value;
    this.CurrentPath = element.Element((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픔()).Value;
  }

  public XElement ToXElement()
  {
    XElement xelement = new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁핈());
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픏(), (object) this.Enabled));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픜(), (object) this.Name));
    xelement.Add((object) new XElement((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픔(), (object) this.CurrentPath));
    return xelement;
  }
}
