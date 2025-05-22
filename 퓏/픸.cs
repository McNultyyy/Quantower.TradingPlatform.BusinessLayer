// Decompiled with JetBrains decompiler
// Type: 퓏.픸
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer;
using TradingPlatform.BusinessLayer.DataBinding;

#nullable disable
namespace 퓏;

internal class 픸 : IDisposable
{
  private IBindableEntity 퓲핊;
  private readonly IList<Binding> 퓲픛;

  public 픸([In] IBindableEntity obj0)
  {
    this.퓲핊 = obj0;
    this.퓲픛 = (IList<Binding>) new List<Binding>();
  }

  public Binding 퓏([In] IBindableEntity obj0, [In] string obj1)
  {
    return this.퓏(obj0, obj1, this.퓲핊, obj1);
  }

  public Binding 퓏([In] IBindableEntity obj0, [In] string obj1, [In] string obj2)
  {
    return this.퓏(obj0, obj1, this.퓲핊, obj2);
  }

  public Binding 퓏([In] IBindableEntity obj0, [In] string obj1, [In] IBindableEntity obj2, [In] string obj3)
  {
    try
    {
      Binding binding = new Binding(obj0, obj1, obj2, obj3);
      this.퓲픛.Add(binding);
      return binding;
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
    return (Binding) null;
  }

  public void 퓏([In] IBindableEntity obj0)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    픸.퓏 퓏 = new 픸.퓏();
    // ISSUE: reference to a compiler-generated field
    퓏.픣픙 = obj0;
    // ISSUE: reference to a compiler-generated field
    if (퓏.픣픙 == null)
      return;
    try
    {
      // ISSUE: reference to a compiler-generated method
      foreach (Binding binding in this.퓲픛.Where<Binding>(new Func<Binding, bool>(퓏.퓏)).ToList<Binding>())
      {
        this.퓲픛.Remove(binding);
        binding.Dispose();
      }
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
  }

  public void Dispose()
  {
    this.퓲핊 = (IBindableEntity) null;
    foreach (Binding binding in (IEnumerable<Binding>) this.퓲픛)
      binding.Dispose();
  }
}
