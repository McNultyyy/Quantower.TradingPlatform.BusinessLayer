// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.GlobalVariables.GlobalVariable
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer.GlobalVariables;

/// <summary>Global variable entry</summary>
[Obsolete("Should be removed at future releases")]
public sealed class GlobalVariable
{
  /// <summary>Variable name</summary>
  /// <example>
  ///  <span id="Example 1">
  ///  <code>
  /// using System;
  /// using System.Text;
  /// using PTLRuntime.NETScript;
  /// 
  /// namespace GlobalVariablesManager
  /// {
  ///      public class GlobalVariablesManager : NETIndicator
  ///      {
  ///          List&lt;GlobalVariable&gt; global_List=new List&lt;GlobalVariable&gt;();
  /// 
  ///          public override void Init()
  ///          {
  ///               if(GlobalVariablesManager.Count()&gt;0)
  ///               {
  ///                  global_List=GlobalVariablesManager.GetGlobalVariablesList();
  ///                  foreach (var el in global_List)
  ///                  {
  ///                  Print(el.Name);
  ///                  Print(el.Value);
  ///                  }
  ///               }
  ///          }
  ///      }
  /// }
  ///  </code>
  ///  </span>
  ///  </example>
  public string Name { get; [param: In] private set; }

  /// <summary>Variable value</summary>
  /// <example>
  ///  <span id="Example 1">
  ///  <code>
  /// using System;
  /// using System.Text;
  /// using PTLRuntime.NETScript;
  /// 
  /// namespace GlobalVariablesManager
  /// {
  ///      public class GlobalVariablesManager : NETIndicator
  ///      {
  ///          List&lt;GlobalVariable&gt; global_List=new List&lt;GlobalVariable&gt;();
  ///          public override void Init()
  ///          {
  ///               if(GlobalVariablesManager.Count()&gt;0)
  ///               {
  ///                  global_List=GlobalVariablesManager.GetGlobalVariablesList();
  ///                  foreach (var el in global_List)
  ///                  {
  ///                  Print(el.Name);
  ///                  Print(el.Value);
  ///                  }
  ///               }
  ///          }
  ///      }
  /// }
  ///  </code>
  ///  </span>
  ///  </example>
  public object Value { get; set; }

  /// <summary>Initializes new variable</summary>
  /// <example>
  ///  <span id="Example 1">
  ///  <code>
  /// using System;
  /// using System.Text;
  /// using PTLRuntime.NETScript;
  /// 
  /// namespace GlobalVariablesManager
  /// {
  ///      public class GlobalVariablesManager : NETIndicator
  ///      {
  ///          List&lt;GlobalVariable&gt; global_List=new List&lt;GlobalVariable&gt;();
  ///          public override void Init()
  ///          {
  ///               if(GlobalVariablesManager.Count()&gt;0)
  ///              {
  ///                  global_List=GlobalVariablesManager.GetGlobalVariablesList();
  ///                  foreach (var el in global_List)
  ///                  {
  ///                     //Simplified way to retrieve global variable value
  ///                     el.GlobalVariable("new_global_variable_period", period)
  /// 
  ///                     //However, to obtain certain variable, which belongs to indicator/strategy and to avoid unexpected erasing of data the best practice is to provide to a key holder multiple details such as name, params, hashed password etc. Follow SetValue() example.
  ///                  }
  ///              }
  ///          }
  ///      }
  /// }
  ///  </code>
  ///  </span>
  ///  </example>
  /// <param name="name">Variable name</param>
  /// <param name="value">Variable value</param>
  public GlobalVariable(string name, object value)
  {
    this.Name = name;
    this.Value = value;
  }

  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 2);
    interpolatedStringHandler.AppendFormatted(this.Name);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓓());
    interpolatedStringHandler.AppendFormatted<Type>(this.Value.GetType());
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픗());
    return interpolatedStringHandler.ToStringAndClear();
  }
}
