// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.BusinessObject
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Threading;
using 퓏;

#nullable disable
namespace TradingPlatform.BusinessLayer;

[DataContract]
[KnownType(typeof (Account))]
[KnownType(typeof (PnLItem))]
public abstract class BusinessObject : IConnectionBindedObject, IUniqueID
{
  private Connection 픂핇;
  private static long 픂핂;

  public string ConnectionId { get; [param: In] internal set; }

  public virtual BusinessObjectState State { get; protected internal set; }

  public virtual Connection Connection
  {
    get => this.픂핇 ?? (this.픂핇 = Core.Instance.Connections[this.ConnectionId]);
  }

  internal virtual 퓪 ConnectionCache => this.Connection?.픂픹;

  /// <summary>
  /// Unique ID during active session. Don't use for serialization
  /// </summary>
  public string UniqueId { get; [param: In] private set; }

  internal BusinessObject()
  {
  }

  internal BusinessObject([In] string obj0)
  {
    this.UniqueId = Interlocked.Increment(ref BusinessObject.픂핂).ToString();
    this.ConnectionId = obj0;
    this.State = BusinessObjectState.Normal;
  }

  [NotPublished]
  public virtual BusinessObjectInfo CreateInfo()
  {
    return new BusinessObjectInfo()
    {
      ConnectionId = this.ConnectionId
    };
  }
}
