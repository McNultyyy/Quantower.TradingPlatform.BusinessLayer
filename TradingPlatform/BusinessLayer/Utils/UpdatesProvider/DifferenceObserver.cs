// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.UpdatesProvider.DifferenceObserver
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

#nullable enable
namespace TradingPlatform.BusinessLayer.Utils.UpdatesProvider;

public class DifferenceObserver
{
  private readonly 
  #nullable disable
  IDictionary<Type, ICollection<PropertyInfo>> 퓲퓝;

  public ApplyDifferencePredicate ApplyDifferencePredicate { get; set; }

  public DifferenceObserver()
  {
    this.퓲퓝 = (IDictionary<Type, ICollection<PropertyInfo>>) new Dictionary<Type, ICollection<PropertyInfo>>();
  }

  public void RegisterType(Type type, params string[] propertyNamesToObserve)
  {
    List<PropertyInfo> propertyInfoList = new List<PropertyInfo>();
    this.퓲퓝[type] = (ICollection<PropertyInfo>) propertyInfoList;
    foreach (PropertyInfo property in type.GetProperties())
    {
      if (property.CanRead && property.CanWrite && (propertyNamesToObserve.Length == 0 || ((IEnumerable<string>) propertyNamesToObserve).Contains<string>(property.Name)))
        propertyInfoList.Add(property);
    }
  }

  public IEnumerable<string> GetDifference<T>(T entity1, T entity2, bool updateEntity1 = false)
  {
    ICollection<PropertyInfo> propertyInfos;
    if (this.퓲퓝.TryGetValue(typeof (퓏), out propertyInfos))
    {
      IEnumerator<PropertyInfo> enumerator = propertyInfos.GetEnumerator();
      while (enumerator.MoveNext())
      {
        PropertyInfo current = enumerator.Current;
        object objA = current.GetValue((object) (퓏) entity1);
        object propertyValue = current.GetValue((object) (퓏) entity2);
        object objB = propertyValue;
        if (!object.Equals(objA, objB))
        {
          if (updateEntity1)
          {
            ApplyDifferencePredicate differencePredicate = this.ApplyDifferencePredicate;
            if ((differencePredicate != null ? (differencePredicate(current.Name, propertyValue) ? 1 : 0) : 1) != 0)
              current.SetValue((object) (퓏) entity1, propertyValue);
          }
          yield return current.Name;
        }
      }
      // ISSUE: reference to a compiler-generated method
      this.퓬();
      enumerator = (IEnumerator<PropertyInfo>) null;
    }
  }

  public void UpdateEntity<T>(T entity1, T entity2)
  {
    ICollection<PropertyInfo> propertyInfos;
    if (!this.퓲퓝.TryGetValue(typeof (T), out propertyInfos))
      return;
    foreach (PropertyInfo propertyInfo in (IEnumerable<PropertyInfo>) propertyInfos)
    {
      object objA = propertyInfo.GetValue((object) entity1);
      object propertyValue = propertyInfo.GetValue((object) entity2);
      object objB = propertyValue;
      if (!object.Equals(objA, objB))
      {
        ApplyDifferencePredicate differencePredicate = this.ApplyDifferencePredicate;
        if ((differencePredicate != null ? (differencePredicate(propertyInfo.Name, propertyValue) ? 1 : 0) : 1) != 0)
          propertyInfo.SetValue((object) entity1, propertyValue);
      }
    }
  }
}
