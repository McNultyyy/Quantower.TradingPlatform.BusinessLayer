// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Utils.PnlAlertsContainer
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer.Utils;

public class PnlAlertsContainer
{
  public Action<PnlAlertItem> OnAlertEnabilityChanged;

  public PnlAlertItem[] PnlAlerts { get; set; }

  public PnlAlertsContainer() => this.PnlAlerts = new PnlAlertItem[0];

  public PnlAlertsContainer Clone()
  {
    PnlAlertsContainer pnlAlertsContainer = new PnlAlertsContainer();
    if (this.PnlAlerts.Length != 0)
      pnlAlertsContainer.PnlAlerts = ((IEnumerable<PnlAlertItem>) this.PnlAlerts).Select<PnlAlertItem, PnlAlertItem>((Func<PnlAlertItem, PnlAlertItem>) (([In] obj0) => new PnlAlertItem(obj0))).ToArray<PnlAlertItem>();
    return pnlAlertsContainer;
  }
}
