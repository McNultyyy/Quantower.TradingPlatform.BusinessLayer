// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.DataBinding.Extensions.CommandBindableEntityExtensions
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Windows.Input;

#nullable disable
namespace TradingPlatform.BusinessLayer.DataBinding.Extensions;

public static class CommandBindableEntityExtensions
{
  public static void TryExecuteCommand(this ICommandBindableEntity entity, object parameter = null)
  {
    entity.TryExecuteCommand(entity.Command, parameter);
  }

  public static void TryExecuteCommand(
    this IBindableEntity entity,
    ICommand command,
    object parameter = null)
  {
    try
    {
      if (command == null)
        return;
      if (parameter == null)
        parameter = (object) entity;
      if (!command.CanExecute(parameter))
        return;
      command.Execute(parameter);
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
  }
}
