// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.DataBinding.BindingExtensions
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;

#nullable disable
namespace TradingPlatform.BusinessLayer.DataBinding;

public static class BindingExtensions
{
  public static Binding WithConvertor(this Binding binding, IBindingValueConverter converter)
  {
    Binding binding1 = binding;
    if (binding1.ConvertersQueue == null)
    {
      Queue<IBindingValueConverter> bindingValueConverterQueue;
      binding1.ConvertersQueue = bindingValueConverterQueue = new Queue<IBindingValueConverter>();
    }
    binding.ConvertersQueue.Enqueue(converter);
    return binding;
  }

  public static Binding WithPredicate(this Binding binding, Predicate<IBindableEntity> predicate)
  {
    binding.Predicate = predicate;
    return binding;
  }

  public static Binding WithItemsFactory(this Binding binding, Func<object, object> itemsFactory)
  {
    binding.ItemsFactory = itemsFactory;
    return binding;
  }

  public static Binding WithRemoveItemCallback(
    this Binding binding,
    Action<object> removeItemCallback)
  {
    binding.RemoveItemCallback = removeItemCallback;
    return binding;
  }

  public static Binding WithClearItemsCallback(this Binding binding, Action clearItemsCallback)
  {
    binding.ClearItemsCallback = clearItemsCallback;
    return binding;
  }

  public static Binding WithApplyCallback(this Binding binding, Action applyCallback)
  {
    binding.ApplyCallback = applyCallback;
    return binding;
  }

  public static Binding ApplyValue(this Binding binding)
  {
    return binding.퓏(binding.Accessor2, binding.Accessor1);
  }
}
