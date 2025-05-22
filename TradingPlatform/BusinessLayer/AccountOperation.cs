// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.AccountOperation
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using TradingPlatform.BusinessLayer.Integration;

#nullable disable
namespace TradingPlatform.BusinessLayer;

/// <summary>The account operation.</summary>
public class AccountOperation : BusinessObject, IComparable
{
  private AccountOperationUpdateHandler 퓗픱;
  private AccountOperationConfirmationHandler 퓗픶;
  private AccountOperationExecuteHandler 퓗픀;

  /// <summary>Gets the name.</summary>
  public string Name { get; [param: In] private set; }

  /// <summary>Gets the button text.</summary>
  public string ButtonText { get; [param: In] private set; }

  /// <summary>Gets the settings.</summary>
  public IList<SettingItem> Settings { get; [param: In] private set; }

  internal AccountOperation([In] string obj0)
    : base(obj0)
  {
  }

  /// <summary>
  /// 
  /// </summary>
  /// <param name="settings">The settings.</param>
  public void Update(IList<SettingItem> settings)
  {
    AccountOperationUpdateHandler 퓗픱 = this.퓗픱;
    if (퓗픱 == null)
      return;
    퓗픱(settings);
  }

  /// <summary>Builds the confirmation.</summary>
  /// <param name="settings">The settings.</param>
  /// <returns>A string.</returns>
  public string BuildConfirmation(IList<SettingItem> settings)
  {
    AccountOperationConfirmationHandler 퓗픶 = this.퓗픶;
    return 퓗픶 == null ? (string) null : 퓗픶(settings);
  }

  /// <summary>
  /// 
  /// </summary>
  /// <param name="settings">The settings.</param>
  public void Execute(IList<SettingItem> settings)
  {
    AccountOperationExecuteHandler 퓗픀 = this.퓗픀;
    if (퓗픀 == null)
      return;
    퓗픀(settings);
  }

  internal void 퓏([In] MessageAccountOperation obj0)
  {
    this.Name = obj0.Name;
    this.ButtonText = obj0.ButtonText;
    this.Settings = (IList<SettingItem>) obj0.Settings.DeepCopy().ToList<SettingItem>();
    this.퓗픱 = obj0.UpdateHandler;
    this.퓗픶 = obj0.BuildConfirmationHandler;
    this.퓗픀 = obj0.ExecuteHandler;
  }

  /// <summary>Compare to.</summary>
  /// <param name="obj">The obj.</param>
  /// <returns>An int.</returns>
  public int CompareTo(object obj)
  {
    return !(obj is AccountOperation accountOperation) ? 0 : string.Compare(this.Name, accountOperation.Name, StringComparison.Ordinal);
  }
}
