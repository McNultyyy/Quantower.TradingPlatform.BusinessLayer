// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.GroupTradingOperation
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System.Runtime.CompilerServices;
using System.Text;

#nullable enable
namespace TradingPlatform.BusinessLayer;

public record GroupTradingOperation(
  GroupTradingOperationType Type,
  GroupTradingOperationFilters Filters)
{
  [CompilerGenerated]
  public override string ToString()
  {
    StringBuilder builder = new StringBuilder();
    builder.Append(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇핇());
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
    builder.Append(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇핂());
    builder.Append(this.Type.ToString());
    builder.Append(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픂());
    builder.Append(this.Filters.ToString());
    return true;
  }
}
