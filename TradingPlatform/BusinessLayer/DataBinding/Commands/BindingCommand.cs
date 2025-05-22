// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.DataBinding.Commands.BindingCommand
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Windows.Input;

#nullable disable
namespace TradingPlatform.BusinessLayer.DataBinding.Commands;

public class BindingCommand : ICommand
{
  private readonly Action<object> 퓲퓜;
  private readonly Predicate<object> 퓲픺;

  public BindingCommand(Action<object> action, Predicate<object> canExecutePredicate = null)
  {
    this.퓲퓜 = action;
    this.퓲픺 = canExecutePredicate;
  }

  public event EventHandler CanExecuteChanged;

  public bool CanExecute(object parameter)
  {
    Predicate<object> 퓲픺 = this.퓲픺;
    return 퓲픺 == null ? this.퓲퓜 != null : 퓲픺(parameter);
  }

  public void Execute(object parameter)
  {
    try
    {
      Action<object> 퓲퓜 = this.퓲퓜;
      if (퓲퓜 == null)
        return;
      퓲퓜(parameter);
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
  }
}
