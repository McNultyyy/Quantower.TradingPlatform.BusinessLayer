// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.DataBinding.Mvvm.BindableView
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;

#nullable disable
namespace TradingPlatform.BusinessLayer.DataBinding.Mvvm;

public abstract class BindableView : BindableEntity, IBindableView, IDisposable
{
  private IBindableEntity 퓑픅;
  private 퓏.픸 퓑픠;

  public IBindableEntity BindingContext
  {
    get => this.퓑픅;
    set
    {
      this.퓑픅 = value;
      this.퓑픠?.Dispose();
      if (this.퓑픅 == null)
        return;
      this.퓑픠 = new 퓏.픸(this.퓑픅);
      try
      {
        this.BindContext();
      }
      catch (Exception ex)
      {
        Core.Instance.Loggers.Log(ex);
      }
    }
  }

  protected virtual void BindContext()
  {
  }

  public Binding Bind(string propertyName) => this.퓑픠.퓏((IBindableEntity) this, propertyName);

  public Binding Bind(string propertyName1, string propertyName2)
  {
    return this.퓑픠.퓏((IBindableEntity) this, propertyName1, propertyName2);
  }

  public Binding Bind(IBindableEntity entity1, string propertyName)
  {
    return this.퓑픠.퓏(entity1, propertyName, propertyName);
  }

  public Binding Bind(IBindableEntity entity1, string propertyName1, string propertyName2)
  {
    return this.퓑픠.퓏(entity1, propertyName1, propertyName2);
  }

  public Binding Bind(
    IBindableEntity entity1,
    string propertyName1,
    IBindableEntity entity2,
    string propertyName2)
  {
    return this.퓑픠.퓏(entity1, propertyName1, entity2, propertyName2);
  }

  public void Unbind(IBindableEntity entity) => this.퓑픠.퓏(entity);

  public virtual void Dispose() => this.BindingContext = (IBindableEntity) null;
}
