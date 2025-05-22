// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Serialization.TypedObjectSurrogate
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using ProtoBuf;
using System;

#nullable disable
namespace TradingPlatform.BusinessLayer.Serialization;

[ProtoContract]
public abstract class TypedObjectSurrogate
{
  [ProtoIgnore]
  public abstract object ObjectValue { get; }

  public static object CreateSurrogate<T>(T value)
  {
    if ((object) value == null)
      return (object) new TypedObjectSurrogate<T>();
    Type type = value.GetType();
    if (type == typeof (T))
      return (object) new TypedObjectSurrogate<T>(value);
    return Activator.CreateInstance(typeof (TypedObjectSurrogate<>).MakeGenericType(type), (object) value);
  }
}
