// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.ScriptInfo
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public abstract class ScriptInfo
{
  protected ConstructorInfo ctor;

  public ScriptKey Key { get; protected set; }

  public ScriptCreationType ScriptCreationType { get; [param: In] private set; }

  public string Name { get; protected set; }

  public string Description { get; protected set; }

  public Version Version { get; protected set; }

  public List<SettingItem> Settings { get; protected set; }

  protected ScriptInfo(
    ConstructorInfo ctor,
    ScriptCreationType scriptCreationType,
    string relativePath,
    string assemblyName)
  {
    this.ctor = ctor;
    this.ScriptCreationType = scriptCreationType;
    try
    {
      this.Initialize(relativePath, assemblyName);
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓷() + assemblyName + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓿());
    }
  }

  protected abstract void Initialize(string relativePath, string assemblyName);
}
