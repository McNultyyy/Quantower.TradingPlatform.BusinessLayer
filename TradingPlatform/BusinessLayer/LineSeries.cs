// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.LineSeries
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public sealed class LineSeries : Line
{
  internal List<double> 퓯퓟;
  private static int 퓯핊;
  private readonly List<IndicatorLineMarker> 퓯핃;
  private readonly List<bool> 퓯퓫 = new List<bool>();

  internal int LineSeriesId { get; [param: In] private set; }

  internal int Count => this.퓯퓟.Count;

  /// <summary>
  /// Sets the bar number (from the data beginning) from which the drawing of the given indicator line must start;
  /// </summary>
  public int DrawBegin { get; set; }

  /// <summary>Time shift of indicator's line</summary>
  public int TimeShift { get; set; }

  public bool ShowLineMarker { get; set; } = true;

  public LineSeries(string name, Color color, int width, LineStyle style)
    : base(name, color, width, style)
  {
    this.LineSeriesId = LineSeries.퓯핊++;
    this.퓯퓟 = new List<double>();
    this.퓯핃 = new List<IndicatorLineMarker>();
  }

  public double this[int offset = 0, SeekOriginHistory origin = SeekOriginHistory.End]
  {
    get => this.GetValue(offset, origin);
    set => this.SetValue(value, offset);
  }

  public double GetValue(int offset = 0, SeekOriginHistory origin = SeekOriginHistory.End)
  {
    double num = double.NaN;
    int index = this.퓏(offset, origin);
    if (index >= 0 && index < this.Count)
      num = this.퓯퓟[index];
    return num;
  }

  public void SetValue(double value, int offset = 0, SeekOriginHistory origin = SeekOriginHistory.End)
  {
    this.퓯퓟[this.퓏(offset, origin)] = value;
  }

  internal void 퓏()
  {
    this.퓯퓟.Add(double.NaN);
    this.퓯핃.Add((IndicatorLineMarker) null);
    this.퓯퓫.Add(false);
  }

  public void Clear()
  {
    this.퓯퓟.Clear();
    this.ClearMarkers();
    this.퓯퓫.Clear();
  }

  public override IList<SettingItem> Settings
  {
    get
    {
      IList<SettingItem> settings = base.Settings;
      SettingItemInteger settingItemInteger1 = new SettingItemInteger(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픥(), this.TimeShift);
      settingItemInteger1.SortIndex = 3;
      settings.Add((SettingItem) settingItemInteger1);
      SettingItemBoolean settingItemBoolean = new SettingItemBoolean(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓼(), this.ShowLineMarker);
      settingItemBoolean.SortIndex = 4;
      settings.Add((SettingItem) settingItemBoolean);
      SettingItemInteger settingItemInteger2 = new SettingItemInteger(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓴(), this.LineSeriesId);
      settingItemInteger2.VisibilityMode = VisibilityMode.Hidden;
      settings.Add((SettingItem) settingItemInteger2);
      return settings;
    }
    set
    {
      base.Settings = value;
      IList<SettingItem> list = value;
      SettingItem itemByName1 = list.GetItemByName(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픥());
      if (itemByName1 != null && itemByName1.Value is int num)
        this.TimeShift = num;
      SettingItem itemByName2 = list.GetItemByName(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙퓼());
      if (itemByName2 == null || !(itemByName2.Value is bool flag))
        return;
      this.ShowLineMarker = flag;
    }
  }

  /// <summary>
  /// Redraws parts of indicator's line within the interval set by offset
  /// </summary>
  public void SetMarker(int offset, Color color)
  {
    this.SetMarker(offset, new IndicatorLineMarker()
    {
      Color = color
    });
  }

  public void SetMarker(int offset, IndicatorLineMarker indicatorMarker)
  {
    if (offset < 0 || offset >= this.퓯핃.Count)
      throw new ArgumentOutOfRangeException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픳());
    this.퓯핃[this.퓯핃.Count - 1 - offset] = indicatorMarker;
  }

  /// <summary>
  /// Removes redrawn parts of indicator's line within the interval set by offset
  /// </summary>
  public void RemoveMarker(int offset)
  {
    if (offset < 0 || offset >= this.퓯핃.Count)
      throw new ArgumentOutOfRangeException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픳());
    this.퓯핃[this.퓯핃.Count - 1 - offset] = (IndicatorLineMarker) null;
  }

  /// <summary>
  /// 
  /// </summary>
  public IndicatorLineMarker GetMarker(int offset)
  {
    return offset < 0 || offset >= this.퓯핃.Count ? (IndicatorLineMarker) null : this.퓯핃[this.퓯핃.Count - 1 - offset];
  }

  /// <summary>Fully clears markers from line</summary>
  public void ClearMarkers()
  {
    for (int index = 0; index < this.퓯핃.Count; ++index)
      this.퓯핃[index] = (IndicatorLineMarker) null;
  }

  public void SetLineBreak(int offset)
  {
    if (offset < 0 || offset >= this.퓯퓫.Count)
      throw new ArgumentOutOfRangeException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픳());
    this.퓯퓫[this.퓯퓫.Count - 1 - offset] = true;
  }

  public void RemoveLineBreak(int offset)
  {
    if (offset < 0 || offset >= this.퓯퓫.Count)
      throw new ArgumentOutOfRangeException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픳());
    this.퓯퓫[this.퓯퓫.Count - 1 - offset] = false;
  }

  public bool GetLineBreak(int offset)
  {
    if (offset < 0 || offset >= this.퓯퓫.Count)
      throw new ArgumentOutOfRangeException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓙픳());
    return this.퓯퓫[this.퓯퓫.Count - 1 - offset];
  }

  private int 퓏([In] int obj0, [In] SeekOriginHistory obj1)
  {
    int num = obj0;
    if (obj1 == SeekOriginHistory.End)
      num = this.Count - 1 - obj0;
    return num;
  }
}
