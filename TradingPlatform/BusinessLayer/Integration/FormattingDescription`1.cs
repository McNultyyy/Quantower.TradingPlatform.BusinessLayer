// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.FormattingDescription`1
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

public abstract class FormattingDescription<TValue> : IFormattingDescription
{
  private readonly TValue 픣퓱;

  public string ConnectionId { get; set; }

  public bool AllowFormatDefaultValue { get; init; }

  protected virtual TValue DefaultValue => default (TValue);

  protected FormattingDescription(TValue value) => this.픣퓱 = value;

  public string GetFormattedData()
  {
    return !this.IsValueValid(this.픣퓱) ? string.Empty : this.FormatValue(this.픣퓱);
  }

  protected virtual bool IsValueValid(TValue value)
  {
    return this.AllowFormatDefaultValue || !object.Equals((object) this.DefaultValue, (object) this.픣퓱);
  }

  protected abstract string FormatValue(TValue value);
}
