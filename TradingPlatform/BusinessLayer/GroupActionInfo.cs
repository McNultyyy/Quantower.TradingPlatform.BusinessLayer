// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.GroupActionInfo
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public class GroupActionInfo
{
  public Func<object, string> Action { get; [param: In] private set; }

  public IconType IconType { get; set; }

  public object Tag { get; set; } = new object();

  public GroupActionInfo(Func<object, string> action) => this.Action = action;

  public bool NeedActionConfirmation { get; set; }

  public ManualChangesApplyingType ManualChangesApplyingType { get; set; }

  public string ConfirmationText { get; set; }

  public string Marker { get; set; }

  public string Tooltip { get; set; }
}
