// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.Limitation.Limit
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System.Runtime.CompilerServices;
using System.Text;

#nullable enable
namespace TradingPlatform.BusinessLayer.Integration.Limitation;

public record Limit(
  Period Period,
  int Value,
  LimitInterval Interval,
  params 
  #nullable disable
  RequestType[] RequestTypes)
{
  [CompilerGenerated]
  public override 
  #nullable enable
  string ToString()
  {
    StringBuilder builder = new StringBuilder();
    builder.Append(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픜());
    builder.Append(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓲());
    if (this.PrintMembers(builder))
      builder.Append(' ');
    builder.Append('}');
    return builder.ToString();
  }

  [CompilerGenerated]
  protected virtual bool PrintMembers(StringBuilder builder)
  {
    RuntimeHelpers.EnsureSufficientExecutionStack();
    builder.Append(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓑());
    builder.Append(this.Period.ToString());
    builder.Append(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍핋());
    builder.Append(this.Value.ToString());
    builder.Append(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍퓞());
    builder.Append(this.Interval.ToString());
    builder.Append(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍핅());
    builder.Append((object) this.RequestTypes);
    return true;
  }
}
