// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.TimeInTradeItem
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils;

public class TimeInTradeItem : ITriggerItem, IEquatable<TimeInTradeItem>
{
  private bool 픇픆;

  public bool IsChecked
  {
    get => this.픇픆;
    set
    {
      this.NeedTimeResetToNow = value;
      this.픇픆 = value;
    }
  }

  public Symbol Symbol { get; set; }

  public int TimeInSeconds { get; set; }

  public TimeInTradePlDirection PLDirection { get; set; }

  public DateTime ActivatedTime { get; [param: In] private set; }

  public bool NeedTimeResetToNow { get; set; }

  public TimeInTradeItem()
  {
  }

  public TimeInTradeItem(TimeInTradeItem source)
    : this()
  {
    this.IsChecked = source.IsChecked;
    this.Symbol = source.Symbol;
    this.TimeInSeconds = source.TimeInSeconds;
    this.PLDirection = source.PLDirection;
    this.ActivatedTime = source.ActivatedTime;
  }

  public bool Equals(TimeInTradeItem other)
  {
    if (other == null)
      return false;
    if (other == this)
      return true;
    return this.IsChecked == other.IsChecked && this.Symbol.Equals(other.Symbol) && this.TimeInSeconds.Equals(other.TimeInSeconds) && this.PLDirection.Equals((object) other.PLDirection);
  }

  public override bool Equals(object obj) => this.Equals(obj as TimeInTradeItem);

  public void ResetTriggerTime(bool toNow = false)
  {
    this.ActivatedTime = toNow ? Core.Instance.TimeUtils.DateTimeUtcNow : new DateTime();
    this.NeedTimeResetToNow = false;
  }
}
