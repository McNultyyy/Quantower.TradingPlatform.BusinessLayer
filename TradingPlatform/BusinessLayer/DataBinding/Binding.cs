// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.DataBinding.Binding
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.DataBinding.Exceptions;
using TradingPlatform.BusinessLayer.Utils.EqualityComparers;

#nullable enable
namespace TradingPlatform.BusinessLayer.DataBinding;

public class Binding : IDisposable
{
  private bool 퓲퓟;

  internal 
  #nullable disable
  Binding.퓏 Accessor1 { get; }

  internal Binding.퓏 Accessor2 { get; }

  internal Queue<IBindingValueConverter> ConvertersQueue { get; [param: In] set; }

  internal System.Predicate<IBindableEntity> Predicate { get; [param: In] set; }

  internal Func<object, object> ItemsFactory { get; [param: In] set; }

  internal Action<object> RemoveItemCallback { get; [param: In] set; }

  internal Action ClearItemsCallback { get; [param: In] set; }

  internal Action ApplyCallback { get; [param: In] set; }

  public Binding(
    IBindableEntity entity1,
    string propertyName1,
    IBindableEntity entity2,
    string propertyName2)
  {
    if (entity1 == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픵());
    if (entity2 == null)
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픬());
    this.Accessor1 = new Binding.퓏(entity1, propertyName1);
    this.Accessor2 = new Binding.퓏(entity2, propertyName2);
    this.Accessor1.Entity.PropertyChanged += new PropertyChangedEventHandler(this.퓏);
    this.Accessor2.Entity.PropertyChanged += new PropertyChangedEventHandler(this.퓏);
  }

  private void 퓏([In] object obj0, [In] PropertyChangedEventArgs obj1)
  {
    Binding.퓏 퓏1 = obj0 == this.Accessor1.Entity ? this.Accessor1 : this.Accessor2;
    Binding.퓏 퓏2 = obj0 == this.Accessor1.Entity ? this.Accessor2 : this.Accessor1;
    if (퓏1 == null || 퓏2 == null || obj1.PropertyName != 퓏1.PropertyName || this.Predicate != null && !this.Predicate(퓏1.Entity))
      return;
    try
    {
      if (this.퓲퓟)
        return;
      this.퓲퓟 = true;
      if (obj1 is CollectionChangedEventArgs changedEventArgs && 퓏2.퓏() is IList list)
        this.퓏(퓏1, list, changedEventArgs);
      else
        this.퓏(퓏1, 퓏2);
    }
    finally
    {
      this.퓲퓟 = false;
    }
  }

  internal Binding 퓏([In] Binding.퓏 obj0, [In] Binding.퓏 obj1)
  {
    object obj = obj0.퓏();
    if (this.ConvertersQueue == null || !this.ConvertersQueue.Any<IBindingValueConverter>())
    {
      obj1.퓏(obj);
      return this;
    }
    object convertedValue = obj;
    foreach (IBindingValueConverter converters in this.ConvertersQueue)
    {
      if (!converters.TryConvert(convertedValue, obj0.PropertyType, obj0.Entity, out convertedValue))
        return this;
    }
    obj1.퓏(convertedValue);
    Action applyCallback = this.ApplyCallback;
    if (applyCallback != null)
      applyCallback.InvokeSafely();
    return this;
  }

  private Binding 퓏([In] Binding.퓏 obj0, [In] IList obj1, [In] CollectionChangedEventArgs obj2)
  {
    // ISSUE: variable of a compiler-generated type
    Binding.퓬 퓬;
    // ISSUE: reference to a compiler-generated field
    퓬.픣퓼 = this;
    // ISSUE: reference to a compiler-generated field
    퓬.픣퓴 = obj1;
    // ISSUE: reference to a compiler-generated field
    퓬.픣픳 = obj2.CollectionChangedArgs;
    // ISSUE: reference to a compiler-generated field
    switch (퓬.픣픳.Action)
    {
      case NotifyCollectionChangedAction.Add:
        // ISSUE: reference to a compiler-generated field
        IEnumerator enumerator1 = 퓬.픣픳.NewItems.GetEnumerator();
        try
        {
          while (enumerator1.MoveNext())
          {
            // ISSUE: reference to a compiler-generated method
            this.퓏(enumerator1.Current, ref 퓬);
          }
          break;
        }
        finally
        {
          if (enumerator1 is IDisposable disposable)
            disposable.Dispose();
        }
      case NotifyCollectionChangedAction.Remove:
        // ISSUE: reference to a compiler-generated method
        this.퓏(ref 퓬);
        break;
      case NotifyCollectionChangedAction.Replace:
        // ISSUE: reference to a compiler-generated method
        this.퓏(ref 퓬);
        // ISSUE: reference to a compiler-generated field
        IEnumerator enumerator2 = 퓬.픣픳.NewItems.GetEnumerator();
        try
        {
          while (enumerator2.MoveNext())
          {
            // ISSUE: reference to a compiler-generated method
            this.퓏(enumerator2.Current, ref 퓬);
          }
          break;
        }
        finally
        {
          if (enumerator2 is IDisposable disposable)
            disposable.Dispose();
        }
      case NotifyCollectionChangedAction.Move:
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = 퓬.픣퓴[퓬.픣픳.OldStartingIndex];
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        퓬.픣퓴.RemoveAt(퓬.픣픳.OldStartingIndex);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        퓬.픣퓴.Insert(퓬.픣픳.NewStartingIndex, obj);
        break;
      case NotifyCollectionChangedAction.Reset:
        Action clearItemsCallback = this.ClearItemsCallback;
        if (clearItemsCallback != null)
          clearItemsCallback.InvokeSafely();
        // ISSUE: reference to a compiler-generated field
        퓬.픣퓴.Clear();
        break;
      default:
        throw new ArgumentOutOfRangeException();
    }
    return this;
  }

  internal bool 퓏([In] object obj0)
  {
    return this.Accessor1.Entity == obj0 || this.Accessor2.Entity == obj0;
  }

  public void Dispose()
  {
    this.Accessor1.Entity.PropertyChanged -= new PropertyChangedEventHandler(this.퓏);
    this.Accessor2.Entity.PropertyChanged -= new PropertyChangedEventHandler(this.퓏);
  }

  public override string ToString()
  {
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 3);
    interpolatedStringHandler.AppendFormatted<Binding.퓏>(this.Accessor1);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓛());
    interpolatedStringHandler.AppendFormatted<Binding.퓏>(this.Accessor2);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓕());
    interpolatedStringHandler.AppendFormatted<int?>(this.ConvertersQueue?.Count);
    return interpolatedStringHandler.ToStringAndClear();
  }

  internal class 퓏
  {
    private readonly PropertyInfo 픣퓵;
    private static readonly ConcurrentDictionary<Type, List<PropertyInfo>> 픣플 = new ConcurrentDictionary<Type, List<PropertyInfo>>();
    private static readonly PropertyInfoEqualityComparer 픣픥 = new PropertyInfoEqualityComparer();

    public IBindableEntity Entity { get; }

    public string PropertyName { get; }

    public Type PropertyType { get; }

    public 퓏([In] IBindableEntity obj0, [In] string obj1)
    {
      this.Entity = obj0;
      this.PropertyName = obj1;
      foreach (PropertyInfo element in Binding.퓏.퓏(this.Entity.GetType()))
      {
        if (!((element.GetCustomAttribute<BindableAttribute>()?.Alias ?? element.Name) != obj1))
        {
          this.PropertyName = element.Name;
          this.PropertyType = element.PropertyType;
          this.픣퓵 = element;
          break;
        }
      }
      if (this.픣퓵 == (PropertyInfo) null)
        throw new BindingPropertyMissingException(obj1);
    }

    public object 퓏()
    {
      try
      {
        return this.픣퓵 == (PropertyInfo) null || !this.픣퓵.CanRead ? (object) null : this.픣퓵?.GetValue((object) this.Entity);
      }
      catch (Exception ex)
      {
        Core.Instance.Loggers.Log(ex);
      }
      return (object) null;
    }

    public void 퓏([In] object obj0)
    {
      try
      {
        if (this.픣퓵 == (PropertyInfo) null || !this.픣퓵.CanWrite)
          return;
        this.픣퓵.SetValue((object) this.Entity, obj0);
      }
      catch (Exception ex)
      {
        Core.Instance.Loggers.Log(ex);
      }
    }

    public override string ToString()
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 2);
      interpolatedStringHandler.AppendFormatted(this.PropertyName);
      interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇프());
      interpolatedStringHandler.AppendFormatted<Type>(this.Entity.GetType());
      return interpolatedStringHandler.ToStringAndClear();
    }

    private static List<PropertyInfo> 퓏([In] Type obj0)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Binding.퓏.퓏 퓏 = new Binding.퓏.퓏();
      List<PropertyInfo> propertyInfoList;
      if (Binding.퓏.픣플.TryGetValue(obj0, out propertyInfoList))
        return propertyInfoList;
      // ISSUE: reference to a compiler-generated field
      퓏.퓑픆 = new List<PropertyInfo>();
      Type type = obj0;
      do
      {
        PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        // ISSUE: reference to a compiler-generated field
        퓏.퓑픆.AddRange((IEnumerable<PropertyInfo>) properties);
        type = type.BaseType;
      }
      while (type != (Type) null);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      퓏.퓑픆 = 퓏.퓑픆.Distinct<PropertyInfo>((IEqualityComparer<PropertyInfo>) Binding.퓏.픣픥).ToList<PropertyInfo>();
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      Binding.퓏.픣플.AddOrUpdate(obj0, new Func<Type, List<PropertyInfo>>(퓏.퓏), new Func<Type, List<PropertyInfo>, List<PropertyInfo>>(퓏.퓏));
      // ISSUE: reference to a compiler-generated field
      return 퓏.퓑픆;
    }
  }
}
