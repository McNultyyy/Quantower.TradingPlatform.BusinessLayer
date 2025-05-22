// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.LoggerConfig
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

#nullable enable
namespace TradingPlatform.BusinessLayer;

public record LoggerConfig()
{
  public 
  #nullable disable
  string LoggerName { get; set; }

  public string OutputFolderPath { get; set; }

  public LoggerScope Scope { get; set; }

  [CompilerGenerated]
  public override 
  #nullable enable
  string ToString()
  {
    StringBuilder builder = new StringBuilder();
    builder.Append(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓹());
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
    builder.Append(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓛());
    builder.Append((object) this.LoggerName);
    builder.Append(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픝());
    builder.Append((object) this.OutputFolderPath);
    builder.Append(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픻());
    builder.Append(this.Scope.ToString());
    return true;
  }

  [CompilerGenerated]
  public override int GetHashCode()
  {
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    return ((EqualityComparer<Type>.Default.GetHashCode(this.EqualityContract) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.핇퓏)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.핇퓬)) * -1521134295 + EqualityComparer<LoggerScope>.Default.GetHashCode(this.핇핇);
  }

  [CompilerGenerated]
  public virtual bool Equals(LoggerConfig? other)
  {
    if ((object) this == (object) other)
      return true;
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    return (object) other != null && this.EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(this.핇퓏, other.핇퓏) && EqualityComparer<string>.Default.Equals(this.핇퓬, other.핇퓬) && EqualityComparer<LoggerScope>.Default.Equals(this.핇핇, other.핇핇);
  }

  [CompilerGenerated]
  protected LoggerConfig(LoggerConfig original)
  {
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    this.핇퓏 = original.핇퓏;
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    this.핇퓬 = original.핇퓬;
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    this.핇핇 = original.핇핇;
  }
}
