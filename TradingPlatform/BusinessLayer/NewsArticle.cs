// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.NewsArticle
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

public sealed class NewsArticle : BusinessObject
{
  private string[] 픎퓬;
  private bool 픎핇;

  public string Id { get; [param: In] private set; }

  public DateTime CreationDate { get; [param: In] private set; }

  public string Title { get; [param: In] private set; }

  public string SourceLink { get; [param: In] private set; }

  public string Category { get; [param: In] private set; }

  public IEnumerable<Symbol> Symbols { get; [param: In] private set; }

  public bool NeedToLoadSymbols => this.픎퓬 != null && ((IEnumerable<string>) this.픎퓬).Any<string>();

  internal NewsArticle([In] string obj0)
    : base(obj0)
  {
    this.Symbols = (IEnumerable<Symbol>) new Symbol[0];
    this.픎퓬 = new string[0];
  }

  internal void 퓏([In] MessageNewsHeadline obj0)
  {
    this.Id = obj0.Id;
    this.CreationDate = obj0.CreationDate;
    this.Title = obj0.Title;
    this.SourceLink = obj0.SourceLink;
    this.Category = obj0.Category;
    if (obj0.SymbolsIds == null || !obj0.SymbolsIds.Any<string>())
      return;
    this.픎퓬 = obj0.SymbolsIds.ToArray<string>();
  }

  public void LoadSymbols()
  {
    if (this.픎핇)
      return;
    this.픎핇 = true;
    if (!this.NeedToLoadSymbols)
      return;
    try
    {
      this.Symbols = (IEnumerable<Symbol>) ((IEnumerable<string>) this.픎퓬).Select<string, Symbol>((Func<string, Symbol>) (([In] obj0) => this.Connection.퓏(new GetSymbolRequestParameters()
      {
        SymbolId = obj0
      }))).Where<Symbol>((Func<Symbol, bool>) (([In] obj0) => obj0 != null)).ToArray<Symbol>();
      this.픎퓬 = (string[]) null;
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
    finally
    {
      this.픎핇 = false;
    }
  }
}
