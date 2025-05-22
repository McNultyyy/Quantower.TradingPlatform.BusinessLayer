// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.SelectItem
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[Serializable]
public class SelectItem : IEquatable<SelectItem>
{
  public string Text { get; set; }

  public IComparable Value { get; set; }

  public SettingItemSeparatorGroup SeparatorGroup { get; set; }

  public object SelectConfirmation { get; set; }

  public Action Action { get; set; }

  public SelectItem(string text, IComparable value = null)
  {
    this.Text = text;
    this.Value = value ?? (IComparable) this.Text;
  }

  public SelectItem(string text, int value)
  {
    this.Text = text;
    this.Value = (IComparable) value;
  }

  public SelectItem(string text, string value)
  {
    this.Text = text;
    this.Value = (IComparable) value;
  }

  public override string ToString() => this.Text;

  public bool Equals(SelectItem other)
  {
    if (other == null)
      return false;
    return this == other || object.Equals((object) this.Value, (object) other.Value);
  }

  public override bool Equals(object obj)
  {
    if (obj == null)
      return false;
    if (this == obj)
      return true;
    return !(obj.GetType() != this.GetType()) && this.Equals((SelectItem) obj);
  }

  public override int GetHashCode() => this.Value == null ? 0 : this.Value.GetHashCode();
}
