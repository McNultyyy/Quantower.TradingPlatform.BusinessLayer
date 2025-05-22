// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Serialization.TypedObjectSurrogate`1
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using ProtoBuf;

#nullable disable
namespace TradingPlatform.BusinessLayer.Serialization;

[ProtoContract]
public sealed class TypedObjectSurrogate<T> : TypedObjectSurrogate
{
  public TypedObjectSurrogate()
  {
  }

  public TypedObjectSurrogate(T value) => this.Value = value;

  [ProtoIgnore]
  public override object ObjectValue => (object) this.Value;

  [ProtoMember(1)]
  public T Value { get; set; }
}
