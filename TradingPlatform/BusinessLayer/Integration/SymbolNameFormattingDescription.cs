// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Integration.SymbolNameFormattingDescription
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

#nullable disable
namespace TradingPlatform.BusinessLayer.Integration;

public class SymbolNameFormattingDescription(string symbolId) : FormattingDescription<string>(symbolId)
{
  protected override string FormatValue(string value)
  {
    Core instance = Core.Instance;
    GetSymbolRequestParameters requestParameters = new GetSymbolRequestParameters();
    requestParameters.SymbolId = value;
    string connectionId = this.ConnectionId;
    return instance.GetSymbol(requestParameters, connectionId, NonFixedListDownload.IgnoreDownload)?.Name ?? value;
  }
}
