// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.DataBinding.CollectionChangedEventArgs
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Collections.Specialized;
using System.ComponentModel;

#nullable disable
namespace TradingPlatform.BusinessLayer.DataBinding;

public class CollectionChangedEventArgs : PropertyChangedEventArgs
{
  public NotifyCollectionChangedEventArgs CollectionChangedArgs { get; }

  public CollectionChangedEventArgs(
    string propertyName,
    NotifyCollectionChangedEventArgs collectionChangedArgs)
    : base(propertyName)
  {
    this.CollectionChangedArgs = collectionChangedArgs;
  }
}
